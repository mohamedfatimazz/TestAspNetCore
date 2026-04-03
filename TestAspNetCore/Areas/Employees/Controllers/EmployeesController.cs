using Microsoft.AspNetCore.Mvc;
using TestAspNetCore.Data;
using TestAspNetCore.Models;

namespace TestAspNetCore.Areas.Employees.Controllers
{
    public class EmployeesController : Controller
    {
        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }
        private readonly AppDbContext _context;
        [Area("Employees")]
        public IActionResult Index()
        {
            IEnumerable<Employee> employees = _context.Employee.ToList();
            return View(employees);
        }
        [Area("Employees")]
        public IActionResult New()
        {
            return View();
        }
        [Area("Employees")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Employee employee)
        {
           
                // return message
            if (ModelState.IsValid)
            {
                _context.Employee.Add(employee);
               _context.SaveChanges();
                messege("Item created successfully.");
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        [Area("Employees")]
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var employee = _context.Employee.Find(Id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [Area("Employees")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employee.Update(employee);
                _context.SaveChanges();
                messege("Item updated successfully.");
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [Area("Employees")]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var employee = _context.Employee.Find(Id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [Area("Employees")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            var employee = _context.Employee.Find(Id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employee.Remove(employee);
            _context.SaveChanges();
            messege("Item deleted successfully.");
            return RedirectToAction("Index");
        }
        void messege(string message)
        {
            TempData["message"] = message;
        }
    }
}
