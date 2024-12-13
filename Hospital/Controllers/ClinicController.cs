using Hospital.Data;
using Hospital.Interface;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    public class ClinicController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IClinic _clinic;
        public ClinicController(ApplicationDbContext ctx, IClinic clinic)
        {
            _ctx = ctx;
            _clinic = clinic;
        }
        public IActionResult Index()
        {
            List<Clinic> clns = _clinic.GetAllClinic();
            return View(clns);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Clinic clns)
        {
            try
            {
                _clinic.AddClinic(clns);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var clns = _clinic.GetClinicById(id);
            return View(clns);
        }

        [HttpPost]
        public IActionResult Edit(Clinic clns)
        {
            _clinic.UpdateClinic(clns);
            _ctx.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var clns = _clinic.GetClinicById(id);
            return View(clns);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clns = _ctx.clinic.Find(id);
            return View(clns);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _clinic.DeleteClinic(id);
            _ctx.SaveChanges(true);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
