using Microsoft.AspNetCore.Mvc;
using UserActivityWeb.Models;
using UserActivityWeb.Repository.IRepository;

namespace UserActivityWeb.Controllers
{
    public class StatusController : Controller
    {
        private readonly IStatusRepository _StRepo;

        public StatusController(IStatusRepository stRepo)
        {
            _StRepo = stRepo;    
        }

        public IActionResult Index()
        {
            return View(new Status() { });
        }

        public async Task<IActionResult> Upsert(int? Id)
        {
            Status obj = new Status();

            if (Id == null)
            {
                //this will be true for Insert/Create
                return View(obj);
            }

            //Flow will come gete for update 
            obj = await _StRepo.GetAsync(SD.StatusAPIPath, Id.GetValueOrDefault());
            if (obj == null) 
            {
                return NotFound();           
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Status obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.StatusId == 0)
                {
                    await _StRepo.CreateAsync(SD.StatusAPIPath, obj);
                }
                else
                {
                    await _StRepo.UpdateAsync(SD.StatusAPIPath + obj.StatusId, obj);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(obj);   
            }
        }
        
        public async Task<IActionResult> GetAllStatus()
        {
            return Json(new { data = await _StRepo.GetAllAsync(SD.StatusAPIPath) });
        }

    }
}
