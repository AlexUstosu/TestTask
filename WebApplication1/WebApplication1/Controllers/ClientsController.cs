using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : Controller
    {
        public IClientsRepository ClientsItems { get; set; }
        public ClientsController(IClientsRepository clientItems)
        {
            ClientsItems = clientItems;
        }
        
        public IEnumerable<Client> GetAll()
        {
            return ClientsItems.GetAll();
        }

        [HttpGet("{id: int}")]
        public IActionResult GetById(int id)
        {
            var item = ClientsItems.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //// GET: ClientsController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: ClientsController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: ClientsController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ClientsController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ClientsController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: ClientsController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: ClientsController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: ClientsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
