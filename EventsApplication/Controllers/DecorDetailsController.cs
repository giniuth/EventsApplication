using EventsApplication.Data;
using EventsApplication.Interfaces;
using EventsApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApplication.Controllers
{
    [Route("[Controller]")]
    public class DecorDetailsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private IRepositoryWrapper repository;
        public DecorDetailsController(ApplicationDbContext applicationDbContext, IRepositoryWrapper repositoryWrapper)
        {
            dbContext = applicationDbContext;
            repository = repositoryWrapper;
        }
        //READ
        [Route("")]
        public IActionResult Index()
        {
            var allDecorDetails = dbContext.DecorDetails.ToList();
            return View(allDecorDetails);
        }
        [Route("details/{id:int}")]
        public IActionResult Details(int id)
        {
            var DecorDetailById = dbContext.DecorDetails.FirstOrDefault(e => e.ID == id);
            return View(DecorDetailById);
        }
        //UPDATE
        [Route("update/{id:int}")]
        public IActionResult Update(int id)
        {
            var DecorDetailById = dbContext.DecorDetails.FirstOrDefault(e => e.ID == id);
            return View(DecorDetailById);
        }

        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult Update(DecorDetail DecorDetail, int id)
        {
            var DecorDetailToUpdate = dbContext.DecorDetails.FirstOrDefault(e => e.ID == id);
            DecorDetailToUpdate.GuestCapacity = DecorDetail.GuestCapacity;
            DecorDetailToUpdate.Description = DecorDetail.Description;
            DecorDetailToUpdate.Alcohol = DecorDetail.Alcohol;
            DecorDetailToUpdate.Catering = DecorDetail.Catering;
            DecorDetailToUpdate.Cuisine = DecorDetail.Cuisine;

            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        //DELETE
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var DecorDetailsToDelete = dbContext.DecorDetails.FirstOrDefault(c => c.ID == id);
            dbContext.DecorDetails.Remove(DecorDetailsToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}