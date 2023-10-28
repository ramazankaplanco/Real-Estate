using AutoMapper;
using Tumsas.RealEstate.Business.Abstract;
using Tumsas.RealEstate.CrossCuttingConcern.FluentValidations;
using Tumsas.RealEstate.CrossCuttingConcern.Utilities;
using Tumsas.RealEstate.DataAccess.Abstract;
using Tumsas.RealEstate.DataAccess.Concrete.Dto;
using Tumsas.RealEstate.DataAccess.Concrete.Dto.Base;
using Tumsas.RealEstate.Entities;

namespace Tumsas.RealEstate.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ResponseBase<List<CategoryDto>> GetList()
        {
            var model = _unitOfWork.CategoryRepository.GetList();

            return new ResponseBase<List<CategoryDto>>(_mapper.Map<List<CategoryDto>>(model));
        }

        public ResponseBase<CategoryDto> GetById(int id)
        {
            var model = _unitOfWork.CategoryRepository.Get(p => p.Id == id);

            return new ResponseBase<CategoryDto>(_mapper.Map<CategoryDto>(model));
        }

        public ResponseBase<CategoryDto> Add(CategoryDto item)
        {
            ValidatorToolUtil.Validate(new CategoryValidator(), item);

            var entity = _mapper.Map<Category>(item);

            _unitOfWork.CategoryRepository.Add(entity);

            var save = _unitOfWork.Save();

            var model = _mapper.Map<CategoryDto>(entity);

            return new ResponseBase<CategoryDto>(model) { Success = save };
        }

        public ResponseBase<bool> UpdateById(int id, CategoryDto item)
        {
            ValidatorToolUtil.Validate(new CategoryValidator(), item);

            var entity = _unitOfWork.CategoryRepository.Get(p => p.Id == id);

            if (entity == null)
                throw new Exception("Not found");

            entity.ParentId = item.ParentId;
            entity.Title = item.Title;
            entity.Description = item.Description;

            _unitOfWork.CategoryRepository.Update(entity);

            var update = _unitOfWork.Save();

            return new ResponseBase<bool>(update) { Success = update };
        }

        public ResponseBase<bool> DeleteById(int id)
        {
            var entity = _unitOfWork.CategoryRepository.Get(p => p.Id == id);

            if (entity == null)
                throw new Exception("Not found");

            _unitOfWork.CategoryRepository.Delete(entity);

            var delete = _unitOfWork.Save();

            return new ResponseBase<bool>(delete) { Success = delete };
        }
    }
}