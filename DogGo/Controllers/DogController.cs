using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogGo.Models;
using DogGo.Repositories;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace DogGo.Controllers
{
    public class DogController : Controller
    {
        private readonly IDogRepository _dogRespository;

        public DogController(IDogRepository dogRepo)
        {
            _dogRespository = dogRepo;
        }
        // GET: DogController
        [Authorize]
        public ActionResult Index()
        {
            int ownerId = GetCurrentUserId();

            List<Dog> dogs = _dogRespository.GetDogsByOwnerId(ownerId);

            return View(dogs);
        }

        // GET: DogController/Details/5
        public ActionResult Details(int id)
        {
            Dog dog = _dogRespository.GetById(id);
            return View(dog);
        }

        [Authorize]
        // GET: DogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dog dog)
        {
            try
            {
                // update the dogs OwnerId to the current user's Id
                dog.OwnerId = GetCurrentUserId();

                _dogRespository.AddDog(dog);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(dog);
            }
        }
        [Authorize]
        // GET: DogController/Edit/5
        public ActionResult Edit(int id)
        {

                int ownerId = GetCurrentUserId();
                Dog dog = _dogRespository.GetById(id);
                
                if (dog == null || ownerId != dog.OwnerId)
                {
                    return NotFound();
                }

                return View(dog);
        }

        // POST: DogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dog dog)
        {
            try
            {
                _dogRespository.UpdateDog(dog);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(dog);
            }
        }

        // GET: DogController/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            Dog dog = _dogRespository.GetById(id);

            return View(dog);
        }

        // POST: DogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Dog dog)
        {
            try
            {
                _dogRespository.DeleteDog(id);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(dog);
            }
        }
        private int GetCurrentUserId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
    }
}
