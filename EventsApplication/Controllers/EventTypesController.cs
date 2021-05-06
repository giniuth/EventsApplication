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
                PictureURL = "data:image/png;base64,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",
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
