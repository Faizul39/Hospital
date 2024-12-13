using Hospital.Data;
using Hospital.Interface;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IPatient _patient;
        public PatientController(ApplicationDbContext ctx, IPatient patient)
        {
            _ctx = ctx;
            _patient = patient;
        }
        public IActionResult Index()
        {
            List<Patients> ptnts = _patient.GetAllPatient();
            return View(ptnts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patients patnts)
        {
            try
            {
                _patient.AddPatient(patnts);
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
            var ptns = _patient.GetPatientById(id);
            return View(ptns);
        }
        [HttpPost]
        public IActionResult Edit(Patients ptnts)
        {
            _patient.UpdatePatient(ptnts);
            _ctx.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }
        public IActionResult Details(int id)
        {
            var pitns = _patient.GetPatientById(id);
            return View(pitns);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {     
            var pitns = _ctx.patient.Find(id);
            return View(pitns);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            _patient.DeletePatient(id);
            _ctx.SaveChanges(true);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
