using Microsoft.AspNetCore.Mvc;
using OnlineService.Interfaces;
using OnlineService.Models;
using System.Collections.Generic;

namespace OnlineService.Controllers
{
    [Route("categoria")]
    public class CategoriaController : Controller
    {
        private readonly ICategoria _categoriaRepository;

        public CategoriaController(ICategoria categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categorias = _categoriaRepository.GetAll();
            return View(categorias); 
        }

        [HttpGet("{id}")]
        public IActionResult Details(uint id)
        {
            var categoria = _categoriaRepository.GetById(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria); 
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost("create")]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository.Add(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(uint id)
        {
            var categoria = _categoriaRepository.GetById(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost("edit/{id}")]
        public IActionResult Edit(uint id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _categoriaRepository.Update(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(uint id)
        {
            var categoria = _categoriaRepository.GetById(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost("delete/{id}")]
        public IActionResult ConfirmDelete(uint id)
        {
            _categoriaRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
