using EventsApplication.Data;
using EventsApplication.Models;
using EventsApplication.Models.Binding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApplication.Controllers
{
    [Route("[Controller]")]
    public class EventTypesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public EventTypesController(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        //READ
        [Route("")]
        public IActionResult Index()
        {
            var allEventType = dbContext.EventTypes.ToList();
            return View(allEventType);
        }
        //red placeholder maps exactly to what you put in brackets
        //essentially saying, go to details controller and get the eventtype with this id
        [Route("details/{id:int}")]
        public IActionResult Details(int id)
        {
            var EventTypeById = dbContext.EventTypes.FirstOrDefault(e => e.ID == id);
            return View(EventTypeById);
        }
        //CREATE
        [Route("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
      
        public IActionResult Create(AddEventTypeBindingModel bindingModel)
        {
            var EventTypeToCreate = new EventType
            {
                OccasionName = bindingModel.OccasionName,
                Budget = bindingModel.Budget,
                CakeSize = bindingModel.CakeSize,
                PictureURL = "https://th.bing.com/th/id/OIP.EHtzQD5HutANoX8veYZLawHaJQ?pid=ImgDet&w=151&h=188&c=7",
                CreatedAt = DateTime.Now
            };
            dbContext.EventTypes.Add(EventTypeToCreate);
            dbContext.SaveChanges();
            return RedirectToAction("Index");

        }
        //decordetail section
        //CREATE

        //[HttpPost]
        [Route("addDecorDetail/{EventTypeID:int}")]
        public IActionResult CreateDecorDetail(int EventTypeID)
        {
            var EventType = dbContext.EventTypes.FirstOrDefault(e => e.ID == EventTypeID);
            ViewBag.EventTypeOccasionName = EventType.OccasionName;           
           return View();
        }
        [HttpPost]
        [Route("addDecorDetail/{EventTypeID:int}")]
        public IActionResult CreateDecorDetail(AddDecorDetailBindingModel bindingModel, int EventTypeID)
        {
            bindingModel.EventTypeID = EventTypeID;
           var DecorDetailToCreate = new DecorDetail
          {
              GuestCapacity = bindingModel.GuestCapacity,
              Description = bindingModel.Description,
              EventType= dbContext.EventTypes.FirstOrDefault(e => e.ID == EventTypeID),
              Alcohol = bindingModel.Alcohol,
               Catering = bindingModel.Catering,
               Cuisine = bindingModel.Cuisine,
           };
           dbContext.DecorDetails.Add(DecorDetailToCreate);
           dbContext.SaveChanges();
           return RedirectToAction("Index");
            }

        [Route("{id:int}/DecorDetails")]
        public IActionResult ViewDecorDetails(int id)
        {
            var EventType = dbContext.EventTypes.FirstOrDefault(e => e.ID == id);
            var DecorDetails = dbContext.DecorDetails.Where(e => e.EventType.ID == id).ToList();
            ViewBag.EventTypeOccasionName = EventType.OccasionName;
            return View(DecorDetails);
        }
        //UPDATE
        [Route("update/{id:int}")]
        public IActionResult Update(int id)
        {
            var EventTypeById = dbContext.EventTypes.FirstOrDefault(e => e.ID == id);
            return View(EventTypeById);
        }

        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult Update(EventType EventType, int id)
        {
            var EventtypeToUpdate = dbContext.EventTypes.FirstOrDefault(e => e.ID == id);
            {
                EventtypeToUpdate.OccasionName = EventType.OccasionName;
                EventtypeToUpdate.Budget = EventType.Budget;
                EventtypeToUpdate.CakeSize = EventType.CakeSize;
                EventtypeToUpdate.PictureURL = EventType.PictureURL;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            };
        }

        //DELETE
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var EventTypeToDelete = dbContext.EventTypes.FirstOrDefault(e => e.ID == id);
            var DecorDetailToDelete = dbContext.DecorDetails.Where(e => e.EventType.ID == id);
    foreach (var e1 in DecorDetailToDelete)
            {
                dbContext.DecorDetails.Remove(e1);
                dbContext.SaveChanges();
            } 

            dbContext.EventTypes.Remove(EventTypeToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
