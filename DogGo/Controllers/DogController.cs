using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DogGo.Models;
using DogGo.Repositories;
using System.Collections.Generic;

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
        public ActionResult Index()
        {
            List<Dog> allDogs = _dogRespository.GetAllDogs();
            return View(allDogs);
        }

        // GET: DogController/Details/5
        public ActionResult Details(int id)
        {
            Dog dog = _dogRespository.GetById(id);
            return View(dog);
        }

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
                _dogRespository.AddDog(dog);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(dog);
            }
        }

        // GET: DogController/Edit/5
        public ActionResult Edit(int id)
        {
            Dog dog = _dogRespository.GetById(id);

            if (dog == null)
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
    }
}
