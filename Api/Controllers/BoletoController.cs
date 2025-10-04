using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BoletoController : Controller
    {
        // GET: BoletoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BoletoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BoletoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoletoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BoletoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BoletoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BoletoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BoletoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
