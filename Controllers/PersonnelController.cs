using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Controllers
{
    public class PersonnelController : Controller
    {
        MyContext context = new();
        public IActionResult Index()
        {
            var personnels = context.Personnels.Include(x => x.Department).ToList();
            return View(personnels);
        }

        [HttpGet]
        public IActionResult AddPers()
        {
            List<SelectListItem> departments = DepartmentsListsSelectListsItems();
            ViewBag.departments = departments;
            return View();
        }
        [HttpPost]
        public IActionResult AddPers(Personnel personnel)
        {
            var department = context.Departments.Where(x => x.DepId == personnel.DepId).FirstOrDefault();
            personnel.Department = department;
            context.Personnels.Add(personnel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult RemovePers(int id)
        {
            var personnel = context.Personnels.Find(id);
            if (personnel != null)
                context.Personnels.Remove(personnel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DetailPers(int id)
        {
            var personnel = context.Personnels.Find(id);
            List<SelectListItem> departments = DepartmentsListsSelectListsItems();
            ViewBag.departments = departments;
            return View(personnel);
        }

        public IActionResult UpdatePers(Personnel personnel)
        {
            var currentPersonnel = context.Personnels.Find(personnel.PersId);
            var department = context.Departments.Where(x => x.DepId == personnel.DepId).FirstOrDefault();
            if (currentPersonnel != null)
            {
                currentPersonnel.PersName = personnel.PersName;
                currentPersonnel.Department = department;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        private List<SelectListItem> DepartmentsListsSelectListsItems()
        {
            return (from x in context.Departments.ToList()
                    select new SelectListItem
                    {
                        Text = x.DepName,
                        Value = x.DepId.ToString()
                    }).ToList();
        }
    }
}
