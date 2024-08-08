using Microsoft.AspNetCore.Mvc;
using OnlineService.Interfaces;
using OnlineService.Models;
using System.Collections.Generic;

namespace OnlineService.Controllers
{
    [Route("service")]
    public class ServiceController : Controller
    {
        private readonly IService _serviceRepository;

        public ServiceController(IService serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var services = _serviceRepository.GetAll();
            return View(services);
        }

        [HttpGet("{id}")]
        public IActionResult Details(uint id)
        {
            var service = _serviceRepository.GetById(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }


        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                _serviceRepository.Add(service);
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(uint id)
        {
            var service = _serviceRepository.GetById(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(uint id, Service service)
        {
            if (id != service.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _serviceRepository.Update(service);
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(uint id)
        {
            var service = _serviceRepository.GetById(id);
            if (service == null)
            {
                return NotFound();
            }
            return View(service);
        }

        [HttpPost("delete/{id}")]
        public IActionResult ConfirmDelete(uint id)
        {
            _serviceRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult ByCategory(uint categoryId)
        {
            var services = _serviceRepository.GetByCategory(categoryId);
            return View(services);
        }
    }
}


