using Microsoft.AspNetCore.Mvc;
using OnlineService.Interfaces;
using OnlineService.Models;
using OnlineService.Repositories;
using System.Collections.Generic;

namespace OnlineService.Controllers
{
    [Route("order")]
    public class OrderController : Controller
    {
        private readonly IOrder _orderRepository;

        public OrderController(IOrder orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orders = _orderRepository.GetAll();
            return View(orders);
        }

        [HttpGet("{id}")]
        public IActionResult Details(uint id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _orderRepository.Add(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(uint id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(uint id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _orderRepository.Update(order);
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(uint id)
        {
            var order = _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost("delete/{id}")]
        public IActionResult ConfirmDelete(uint id)
        {
            _orderRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

