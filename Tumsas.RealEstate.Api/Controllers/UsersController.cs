using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Tumsas.RealEstate.Business.Abstract;
using Tumsas.RealEstate.DataAccess.Concrete.Dto;
using Tumsas.RealEstate.DataAccess.Concrete.Dto.Base;

namespace Tumsas.RealEstate.Api.Controllers
{
    [EnableCors("ApiCORS")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/<controller>/1
        [HttpGet("{id}")]
        public ActionResult<ResponseBase<UserDto>> Get(int id)
        {
            ResponseBase<UserDto> responseBase;

            try
            {
                responseBase = _userService.GetById(id);
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<UserDto>(null)
                {
                    Success = false,
                    Message = exception.ToString()
                };
            }
            return Ok(responseBase);
        }

        // GET api/<controller>/email/admin@admin.com
        [HttpGet("email/{email}")]
        public ActionResult<ResponseBase<UserDto>> GetByEmail(string email)
        {
            ResponseBase<UserDto> responseBase;

            try
            {
                responseBase = _userService.GetByEmail(email);
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<UserDto>(null)
                {
                    Success = false,
                    Message = exception.ToString()
                };
            }
            return Ok(responseBase);
        }
    }
}
