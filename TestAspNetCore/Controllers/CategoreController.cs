using Microsoft.AspNetCore.Mvc;
using TestAspNetCore.Models;
using TestAspNetCore.Repository.Base;
using TestAspNetCore.UnitOFWork.Base;

namespace TestAspNetCore.Controllers
{
    public class CategoreController : Controller
    {
        public CategoreController(IUnitOFWork unitOFWork)
        {
           // this._repository = _repository;
           _unitOFWork = unitOFWork;
        }
        private readonly IUnitOFWork _unitOFWork;
        // private IRepository<Categore> _repository;
        //public IActionResult Index()
        //{
        //    return View(_repository.GetAll());
        //}
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _repository.GetAllAsync());
        //}
        public async Task<IActionResult> Index()
        {
            var OneCut =  _unitOFWork.Categoreis.SelectOne(x=>x.Name == "Computer");
            var AllCut = await _unitOFWork.Categoreis.GetAllAsync("Items");
            if (OneCut == null) return NotFound();
            return View(AllCut);
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ActionName("New")]
        [ValidateAntiForgeryToken]
        public IActionResult New(Categore categore)
        {
            MemoryStream ms = new MemoryStream();
            if (ModelState.IsValid)
            {
                if (categore.ClientFile!=null)
                {
                    categore.ClientFile.CopyTo(ms);
                    categore.Image = ms.ToArray();
                }
                _unitOFWork.Categoreis.Add(categore);
                messege("Categore created successfully.");
                return RedirectToAction("Index");
            }
            return View(categore);
        }
        public IActionResult Edit(int? id)
        {

            var categore = _unitOFWork.Categoreis.SelectOne(x => x.Id == id);
            if (categore == null) 
            { return NotFound(); 
            }
            return View(categore);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categore categore)
        {
            if (ModelState.IsValid)
            {
                MemoryStream memory = new MemoryStream();
                if (categore.ClientFile != null)
                {
                    categore.ClientFile.CopyTo(memory);
                    categore.Image = memory.ToArray();
                }
                _unitOFWork.Categoreis.Update(categore);
                messege("Categore updated successfully.");
                return RedirectToAction("Index");
            }
            return View(categore);
        }
        public IActionResult Delete(int? id)
        {
            var categore = _unitOFWork.Categoreis.SelectOne(x => x.Id == id);
            if (categore == null)
            {
                return NotFound();
            }
            return View(categore);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var categore = _unitOFWork.Categoreis.SelectOne(x => x.Id == id);
            if (categore == null)
            {
                return NotFound();
            }
            _unitOFWork.Categoreis.Delete(categore);
            messege("Categore deleted successfully.");
            return RedirectToAction("Index");
        }

        void messege(string message)
        {
            TempData["message"] = message;
        }
    }
}
