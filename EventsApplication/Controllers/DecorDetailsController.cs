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
        //private readonly ApplicationDbContext dbContext;
        private IRepositoryWrapper repository;
        public DecorDetailsController(/*ApplicationDbContext applicationDbContext,*/ IRepositoryWrapper repositoryWrapper)
        {
            //dbContext = applicationDbContext;
            repository = repositoryWrapper;
        }
        //READ
        [Route("")]
        public IActionResult Index()
        {
            var allDecorDetails = repository.DecorDetails.FindAll();
            //var allDecorDetails = dbContext.DecorDetails.ToList();
            return View(allDecorDetails);
        }
        [Route("details/{id:int}")]
        public IActionResult Details(int id)
        {
            var DecorDetailById = repository.DecorDetails.FindByCondition(e => e.ID == id).FirstOrDefault();
            //var DecorDetailById = dbContext.DecorDetails.FirstOrDefault(e => e.ID == id);
            return View(DecorDetailById);
        }
        //UPDATE
        [Route("update/{id:int}")]
        public IActionResult Update(int id)
        {

            var DecorDetailById = repository.DecorDetails.FindByCondition(e => e.ID == id).FirstOrDefault();
            //var DecorDetailById = dbContext.DecorDetails.FirstOrDefault(e => e.ID == id);
            return View(DecorDetailById);
        }

        [HttpPost]
        [Route("update/{id:int}")]
        public IActionResult Update(DecorDetail DecorDetail, int id)
        {
            var DecorDetailToUpdate = repository.DecorDetails.FindByCondition(e => e.ID == id).FirstOrDefault();
            //var DecorDetailToUpdate = dbContext.DecorDetails.FirstOrDefault(e => e.ID == id);
            DecorDetailToUpdate.GuestCapacity = DecorDetail.GuestCapacity;
            DecorDetailToUpdate.Description = DecorDetail.Description;
            DecorDetailToUpdate.Alcohol = DecorDetail.Alcohol;
            DecorDetailToUpdate.Catering = DecorDetail.Catering;
            DecorDetailToUpdate.Cuisine = DecorDetail.Cuisine;

            //dbContext.SaveChanges();
            repository.Save();
            return RedirectToAction("Index");
        }
        //DELETE
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var DecorDetailsToDelete = repository.DecorDetails.FindByCondition(e => e.ID == id).FirstOrDefault();
            //var DecorDetailsToDelete = dbContext.DecorDetails.FirstOrDefault(e => e.ID == id);
            //dbContext.DecorDetails.Remove(DecorDetailsToDelete);
            repository.DecorDetails.Delete(DecorDetailsToDelete);
            //dbContext.SaveChanges();
            repository.Save();
            return RedirectToAction("Index");
        }
    }
}