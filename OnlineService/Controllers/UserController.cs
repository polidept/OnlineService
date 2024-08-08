using Microsoft.AspNetCore.Mvc;
using OnlineService.Interfaces;
using OnlineService.Models;
using System.Collections.Generic;

namespace OnlineService.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUser _userRepository;

        public UserController(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userRepository.GetAll();
            return View(users);
        }

        [HttpGet("{id}")]
        public IActionResult Details(uint id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(uint id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(uint id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _userRepository.Update(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(uint id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost("delete/{id}")]
        public IActionResult ConfirmDelete(uint id)
        {
            _userRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("{id}/orders")]
        public IActionResult Orders(uint id)
        {
            var orders = _userRepository.GetByUser(id);
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);
        }
    }
}
