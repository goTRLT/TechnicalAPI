using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BancoController : Controller
    {
        // GET: BancoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BancoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BancoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BancoController/Create
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

        // GET: BancoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BancoController/Edit/5
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

        // GET: BancoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BancoController/Delete/5
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
