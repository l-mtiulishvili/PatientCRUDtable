using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDtable.Models;

namespace CRUDtable.Controllers
{
    public class PatientController : Controller
    {
        private readonly PatientContext _context;

        public PatientController(PatientContext context)
        {
            _context = context;
        }

        // GET: Patient
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }

        // GET: Patient/Create
        public IActionResult AddOrEdit(int id=0)
        {

            ViewBag.Gender = GetGender();
            if (id == 0)
            {
                return View(new Patient());
            }

            else
                return View(_context.Patients.Find(id));

            
        }

        // POST: Patient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("ID,FullName,Dob,Gender,Phone,Address")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                if (patient.ID == 0)
                    _context.Add(patient);
                else
                    _context.Update(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        

        // GET: Patient/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var patient = await _context.Patients.FindAsync(id);
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private List<SelectListItem> GetGender()
        {
            List<SelectListItem> selGender = new List<SelectListItem>();

            var selItem = new SelectListItem() { Value = "", Text = "Select Gender" };

            selGender.Insert(0, selItem);

            selItem = new SelectListItem()
            {
                Value = "Male",
                Text = "Male"
            };

            selGender.Add(selItem);

            selItem = new SelectListItem()
            {
                Value = "Female",
                Text = "Female"
            };
            selGender.Add(selItem);

            return selGender;
        }

        
    }
}
