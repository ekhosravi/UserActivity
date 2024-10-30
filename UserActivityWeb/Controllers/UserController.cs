using Microsoft.AspNetCore.Mvc;
using UserActivityWeb.Models;
using UserActivityWeb.Models.ViewModel;
using UserActivityWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UserActivityWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly IStatusRepository _StRepo;
        private readonly IUserRepository _usrRepo;

        public UserController(IStatusRepository stRepo , IUserRepository usrRepo)
        {
            _StRepo = stRepo;
            _usrRepo = usrRepo;
        }

        public IActionResult Index()
        {
            return View(new User() { });
        }

        public async Task<IActionResult> Upsert(int? Id)
        {
            IEnumerable<Status> stList = await _StRepo.GetAllAsync(SD.StatusAPIPath);

            UsersVM objVM = new UsersVM()
            {
                StatusList = stList.Select(i => new SelectListItem
                {
                    Text = i.StatusName,
                    Value = i.StatusId.ToString()
                }),
                User = new User()
            };

            if (Id == null)
            {
                //this will be true for Insert/Create
                return View(objVM);
            }

            //Flow will come gete for update 
            objVM.User = await _usrRepo.GetAsync(SD.UserAPIPath, Id.GetValueOrDefault());
            if (objVM.User == null) 
            {
                return NotFound();           
            }

            return View(objVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(UsersVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.User.UserID == 0)
                {
                    await _usrRepo.CreateAsync(SD.UserAPIPath, obj.User);
                }
                else
                {
                    await _usrRepo.UpdateAsync(SD.UserAPIPath + obj.User.UserID, obj.User);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                IEnumerable<Status> stList = await _StRepo.GetAllAsync(SD.StatusAPIPath);

                UsersVM objVM = new UsersVM()
                {
                    StatusList = stList.Select(i => new SelectListItem
                    {
                        Text = i.StatusName,
                        Value = i.StatusId.ToString()
                    }),
                    User = obj.User 
                };
                return View(objVM);
            }
        }

        public async Task<IActionResult> GetAllUser()
        {
            return Json(new { data = await _usrRepo.GetAllAsync(SD.UserAPIPath) });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var statusPr = await _usrRepo.DeleteAsync(SD.UserAPIPath, Id);  
            if (statusPr)
            {
                return Json(new {success = true , message ="Delete Successful"});
            }
            return Json(new {success = false , message = "Delete Not Successful" });
        }

    }
}
