using EventsApplication.Controllers;
using EventsApplication.Interfaces;
using EventsApplication.Models;
using EventsApplication.Models.Binding;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EventsApplicationTest
{
    public class EventTypeTest
    {
        private EventTypesController EventTypesController;
        private DecorDetailsController DecorDetailsController;
        private readonly Mock<IRepositoryWrapper> mockRepo;
        private AddEventTypeBindingModel addEventType;
        private AddDecorDetailBindingModel addDecorDetail;
        public EventTypeTest()
        {
            //sample models
            addEventType = new AddEventTypeBindingModel { OccasionName = "Anniversary", Budget = 130, PictureURL = "data:image/jpeg;base64,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", CakeSize = Size.Small };
            addDecorDetail = new AddDecorDetailBindingModel { GuestCapacity = 123, Description = "Jungle themed", Alcohol = "Yes", Cuisine = "Italian", Catering = "No" };
            mockRepo = new Mock<IRepositoryWrapper>();
            EventTypesController = new EventTypesController(mockRepo.Object);
            DecorDetailsController = new DecorDetailsController(mockRepo.Object);
        }

        [Fact]
        public void GetAllEventTypes_Test()
        {
            //Arrange
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.EventTypes.FindAll()).Returns(GetEventTypes);
            //Act
            var controllerActionResult = EventTypesController.Index();
            //Assert
            Assert.NotNull(controllerActionResult);
        }


        private IEnumerable<EventType> GetEventTypes()
        {
            var EventTypes = new List<EventType>
{
  new EventType(){ID = 1,
OccasionName = "Birthday",
Budget = 200, CakeSize = Size.Small, PictureURL ="https://www.megaretailer.co.uk/media/catalog/product/cache/a6f4aec1db93cb13677a62a0babd5631/1/7/17UP3000-16_08_2019_10_58_53_14.jpg"  },
 new EventType(){ID = 2,
OccasionName = "Wedding",
Budget = 300, CakeSize = Size.Large, PictureURL ="https://www.megaretailer.co.uk/media/catalog/product/cache/a6f4aec1db93cb13677a62a0babd5631/1/7/17UP3000-16_08_2019_10_58_53_14.jpg" } };

            return EventTypes;
        }

        private EventType GetEventType()
        {
            return GetEventTypes().ToList()[0];
        }

        [Fact]
        public void GetAllDecorDetails_Test()
        {
            //Arrange
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.DecorDetails.FindAll()).Returns(GetDecorDetails);
            //Act
            var controllerActionResult = DecorDetailsController.Index();
            //Assert
            Assert.NotNull(controllerActionResult);
        }


        private IEnumerable<DecorDetail> GetDecorDetails()
        {
            var DecorDetails = new List<DecorDetail>
{
  new DecorDetail(){ID = 1,
GuestCapacity = 140,
Description= "Modern theme", Alcohol = "No", Cuisine="Italian", Catering="Yes" },
 new DecorDetail(){ID = 2,
 GuestCapacity = 20,
Description= "Gatsby themed", Alcohol = "Yes", Cuisine="Indian", Catering="No" } };


            return DecorDetails;
        }

        private DecorDetail GetDecorDetail()
        {
            return GetDecorDetails().ToList()[0];
        }

        [Fact]
        public void AddEventType_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.EventTypes.FindByCondition(e => e.ID == It.IsAny<int>())).Returns(GetEventTypes());
            //Act
            var controllerActionResult = EventTypesController.Create(addEventType);
            //Assert
            Assert.NotNull(controllerActionResult);
            //Assert.IsType<ActionResult<WorkoutViewModel>>(controllerActionResult);
        }

    

        [Fact]
        public void UpdateEventTypes_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.EventTypes.FindByCondition(e => e.ID == It.IsAny<int>())).Returns(GetEventTypes());
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.EventTypes.FindAll()).Returns(GetEventTypes);
            //Act
            mockRepo.Setup(repo => repo.EventTypes.Update(GetEventType()));
            //Act
            var controllerActionResult = new EventTypesController(mockRepo.Object).Update(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void UpdateDecorDetails_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.DecorDetails.FindByCondition(e => e.ID == It.IsAny<int>())).Returns(GetDecorDetails());
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.DecorDetails.FindAll()).Returns(GetDecorDetails);
            //Act
            mockRepo.Setup(repo => repo.DecorDetails.Update(GetDecorDetail()));
            //Act
            var controllerActionResult = new DecorDetailsController(mockRepo.Object).Update(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }

        [Fact]
        public void DeleteDecorDetails_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.DecorDetails.FindByCondition(e => e.ID == It.IsAny<int>())).Returns(GetDecorDetails());
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.DecorDetails.FindAll()).Returns(GetDecorDetails);
            //Act
            mockRepo.Setup(repo => repo.DecorDetails.Delete(GetDecorDetail()));
            //Act
            var controllerActionResult = new DecorDetailsController(mockRepo.Object).Update(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }


        [Fact]
        public void DeleteEventTypes_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.EventTypes.FindByCondition(e => e.ID == It.IsAny<int>())).Returns(GetEventTypes());
            Moq.Language.Flow.IReturnsResult<IRepositoryWrapper> returnsResult = mockRepo.Setup(repo => repo.EventTypes.FindAll()).Returns(GetEventTypes);
            //Act
            mockRepo.Setup(repo => repo.EventTypes.Delete(GetEventType()));
            //Act
            var controllerActionResult = new EventTypesController(mockRepo.Object).Update(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }









    }
}






