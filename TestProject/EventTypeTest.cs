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

namespace TestProject
{
    public class EventTypeTest
    {
        private EventTypesController EventTypesController;
        private Mock<IRepositoryWrapper> mockRepo;
        private AddEventTypeBindingModel addRecipe;

        public EventTypeTest()
        {
            mockRepo = new Mock<IRepositoryWrapper>();
            EventTypesController = new EventTypesController(mockRepo.Object);

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

        //its not meant to return anything
        private void AddEventType_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.EventTypes.FindByCondition(e => e.ID == It.IsAny<int>())).Returns(GetEventTypes());
            //Act                                                                       //when i put add eventtype doesnt work. perhaps binding?
            var controllerActionResult = new EventTypesController(mockRepo.Object).Create(AddEventType);
            //Assert                                                                           
            Assert.NotNull(controllerActionResult);
            Assert.IsType<RedirectToActionResult>(controllerActionResult);
        }

        [Fact]
        public void DeleteEventType_Test()
        {
            //Arrange
            mockRepo.Setup(repo => repo.EventTypes.FindByCondition(e => e.ID == It.IsAny<int>())).Returns(GetEventTypes());
            mockRepo.Setup(repo => repo.EventTypes.Delete(GetEventType));
            //Act
            var controllerActionResult = EventTypesController.Delete(It.IsAny<int>());
            //Assert
            Assert.NotNull(controllerActionResult);
        }
        //private IEnumerable<Registration> GetRegistrations()
        //{
        //    return new List<Registration>() {
        //        new Registration { Id = 1, Course = GetCourses().ToList()[0] },
        //        new Registration { Id = 2, Course = GetCourses().ToList()[1] },
        //    };
        //}


    }
}