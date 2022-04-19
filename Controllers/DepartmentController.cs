using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        //Context sınıfını kullanabilmek için bir nesne ürettik
        MyContext context = new();

        public IActionResult Index()
        {
            var departments = context.Departments.ToList();//Departman değerlerini DB den çekerek view sayfasına gönderiyoruz.
            return View(departments);
        }

        [HttpGet]//Sayfa tıklandığında ilk çalışacak add methodu
        public IActionResult AddDep()
        {
            return View();
        }
        [HttpPost]//Ekleme işlemi başarılı olduğunda parametrede ki değerleri DB ye aktaran add methodu
        public IActionResult AddDep(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult RemoveDep(int id) //gelen id ile deparman silme işlemini context kullanarak yapıyoruz
        {
            var personnels = context.Personnels.Where(x => x.Department.DepId == id).ToList();
            var department = context.Departments.Find(id);
            if (department != null)
                context.Departments.Remove(department);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DetailDep(int id)
        {
            var department = context.Departments.Find(id);
            return View(department);
        }

        public IActionResult UpdateDep(Department department)
        {
            var currentDepartment = context.Departments.Find(department.DepId);
            if (currentDepartment != null)
                currentDepartment.DepName = department.DepName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PersonnelDep(int id)
        {
            var personnels = context.Personnels.Where(x => x.Department.DepId == id).ToList();
            ViewBag.DepHeader = context.Departments.Where(x => x.DepId == id).Select(y => y.DepName).FirstOrDefault();
            return View(personnels);
        }
    }
}
