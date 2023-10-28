using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tumsas.RealEstate.Business.Abstract;
using Tumsas.RealEstate.DataAccess.Concrete.Dto;

namespace Tumsas.RealEstate.Pages.Users
{
    public class IndexModel : PageModel
    {
        public UserDto User { get; set; }

        private IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public async void OnGet()
        {
            await Task.CompletedTask;
        }

        public IActionResult OnGetUser(int id)
        {
            var response = _userService.GetById(id);

            return new JsonResult(response);
        }

        public IActionResult OnGetUsers()
        {
            var response = _userService.GetList();

            return new JsonResult(response);
        }

        public IActionResult OnPost(UserDto user)
        {
            var response = _userService.Add(user);

            return new JsonResult(response);
        }

        public IActionResult OnPut(UserDto user)
        {
            var response = _userService.UpdateById(user.Id, user);

            return new JsonResult(response);
        }

        public IActionResult OnDelete(int id)
        {
            var response = _userService.DeleteById(id);

            return new JsonResult(response);
        }
    }
}