using Microsoft.AspNetCore.Mvc;
using MvcExamenAWS2.Models;
using MvcExamenAWS2.Services;

namespace MvcExamenAWS2.Controllers
{
    public class EventosController : Controller
    {
        private ServiceApiEventos service;

        public EventosController(ServiceApiEventos service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Evento> eventos = await this.service.GetEventosAsync();
            return View(eventos);
        }

        public async Task<IActionResult> CategoriasEventos()
        {
            List<CategoriaEvento> categorias = await this.service.GetCategoriasEventosAsync();
            return View(categorias);
        }

        public IActionResult EventosByCategoria()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EventosByCategoria(int idcategoria)
        {
            List<Evento> eventos = await this.service.GetEventosByCategoria(idcategoria);
            return View(eventos);
        }
    }
}
