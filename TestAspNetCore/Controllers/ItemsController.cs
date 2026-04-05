using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using TestAspNetCore.Data;
using TestAspNetCore.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace TestAspNetCore.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        public ItemsController(AppDbContext db ,IHostingEnvironment host)
        {
            _db = db;
            _host = host;
        }
        private readonly IHostingEnvironment _host;
        private readonly AppDbContext _db;
        public IActionResult Index()
        {
            IEnumerable<Item> itemsList = _db.Items.Include(c=>c.Categorecs).ToList();
            return View(itemsList);
        }
        //GET
        public IActionResult New()
        {
            creatSelectList();
            return View();
        }
        // post
        [HttpPost]
        [ValidateAntiForgeryToken]// we can use the same view for both create and edit, so we can use the same action method for both create and edit
        public IActionResult New(Item item)
        {
            if (item.Price == 0)
            {
                // return message
                ModelState.AddModelError("Price", "Price must be greater than zero.");
            }
            string fileName = string.Empty;
            if (ModelState.IsValid)
            {
                if (item.ClientFile !=null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "Images");   
                    fileName = item.ClientFile.FileName;
                    string fullPath = Path.Combine(myUpload, fileName);
                    item.ClientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    item.ImagePath = fileName;
                }
                _db.Items.Add(item);
                _db.SaveChanges();
                messege("Item created successfully.");
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            creatSelectList(item.CatogoreId);
            return View(item);
        }
        // post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (item.Price == 0)
            {
                // return message
                ModelState.AddModelError("Price", "Price must be greater than zero.");
            }
            string fileName = string.Empty;
            if (ModelState.IsValid)
            {
                if (item.ClientFile != null)
                {
                    string myUpload = Path.Combine(_host.WebRootPath, "Images");
                    fileName = item.ClientFile.FileName;
                    string fullPath = Path.Combine(myUpload, fileName);
                    item.ClientFile.CopyTo(new FileStream(fullPath, FileMode.Create));
                    item.ImagePath = fileName;
                }
                _db.Items.Update(item);
                _db.SaveChanges();
                messege("Item updated successfully.");
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            creatSelectList(item.CatogoreId);
            return View(item);
        }
        // post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int? Id)
        {
            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            _db.Items.Remove(item);
            _db.SaveChanges();
            messege("Item deleted successfully.");
            return RedirectToAction("Index");
        }
        void messege(string message)
        {
            TempData["message"] = message;
        }
        public void creatSelectList(int SelectId=0)
        {
           List<Categore> categorecs = _db.Categorecs.ToList();
            SelectList selectList = new SelectList(categorecs, "Id", "Name",SelectId);
            ViewBag.Categorecs = selectList;
        }
    }
}
