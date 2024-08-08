using Microsoft.AspNetCore.Mvc;
using OnlineService.Interfaces;
using OnlineService.Models;
using OnlineService.Repositories;
using System.Collections.Generic;

namespace OnlineService.Controllers
{
    [Route("specialist")]
    public class SpecialistController : Controller
    {
        private readonly ISpecialist _specialistRepository;

        public SpecialistController(ISpecialist specialistRepository)
        {
            _specialistRepository = specialistRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var specialists = _specialistRepository.GetAll();
            return View(specialists);
        }

        [HttpGet("{id}")]
        public IActionResult Details(uint id)
        {
            var specialist = _specialistRepository.GetById(id);
            if (specialist == null)
            {
                return NotFound();
            }
            return View(specialist);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Specialist specialist)
        {
            if (ModelState.IsValid)
            {
                _specialistRepository.Add(specialist);
                return RedirectToAction(nameof(Index));
            }
            return View(specialist);
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(uint id)
        {
            var specialist = _specialistRepository.GetById(id);
            if (specialist == null)
            {
                return NotFound();
            }
            return View(specialist);
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(uint id, Specialist specialist)
        {
            if (id != specialist.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _specialistRepository.Update(specialist);
                return RedirectToAction(nameof(Index));
            }
            return View(specialist);
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(uint id)
        {
            var specialist = _specialistRepository.GetById(id);
            if (specialist == null)
            {
                return NotFound();
            }
            return View(specialist);
        }

        [HttpPost("delete/{id}")]
        public IActionResult ConfirmDelete(uint id)
        {
            _specialistRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
