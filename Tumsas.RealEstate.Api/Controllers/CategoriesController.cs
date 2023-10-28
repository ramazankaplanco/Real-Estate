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
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET api/<controller>/1
        [HttpGet("{id}")]
        public ActionResult<ResponseBase<CategoryDto>> Get(int id)
        {
            ResponseBase<CategoryDto> responseBase;

            try
            {
                responseBase = _categoryService.GetById(id);
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<CategoryDto>(null)
                {
                    Success = false,
                    Message = exception.ToString()
                };
            }
            return Ok(responseBase);
        }

        // GET api/<controller>
        [HttpGet]
        public ActionResult<ResponseBase<List<CategoryDto>>> Get()
        {
            ResponseBase<List<CategoryDto>> responseBase;

            try
            {
                responseBase = _categoryService.GetList();
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<List<CategoryDto>>(null)
                {
                    Success = false,
                    Message = exception.ToString()
                };
            }
            return Ok(responseBase);
        }
    }
}