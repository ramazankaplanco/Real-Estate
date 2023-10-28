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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ResponseBase<List<UserDto>> GetList()
        {
            var model = _unitOfWork.UserRepository.GetList();

            return new ResponseBase<List<UserDto>>(_mapper.Map<List<UserDto>>(model));
        }

        public ResponseBase<UserDto> GetById(int id)
        {
            var model = _unitOfWork.UserRepository.Get(p => p.Id == id);

            return new ResponseBase<UserDto>(_mapper.Map<UserDto>(model));
        }

        public ResponseBase<UserDto> GetByEmail(string email)
        {
            var model = _unitOfWork.UserRepository.Get(p => p.Email == email);

            return new ResponseBase<UserDto>(_mapper.Map<UserDto>(model));
        }

        public ResponseBase<UserDto> Add(UserDto item)
        {
            ValidatorToolUtil.Validate(new UserValidator(), item);

            var entity = _mapper.Map<User>(item);

            _unitOfWork.UserRepository.Add(entity);

            var save = _unitOfWork.Save();

            var model = _mapper.Map<UserDto>(entity);

            return new ResponseBase<UserDto>(model) { Success = save };
        }

        public ResponseBase<bool> UpdateById(int id, UserDto item)
        {
            ValidatorToolUtil.Validate(new UserValidator(), item);

            var entity = _unitOfWork.UserRepository.Get(p => p.Id == id);

            if (entity == null)
                throw new Exception("Not found");

            entity.Email = item.Email;
            entity.Password = item.Password;
            entity.PhoneNumber = item.PhoneNumber;
            entity.FirstName = item.FirstName;
            entity.LastName = item.LastName;

            _unitOfWork.UserRepository.Update(entity);

            var update = _unitOfWork.Save();

            return new ResponseBase<bool>(update) { Success = update };
        }

        public ResponseBase<bool> DeleteById(int id)
        {
            var entity = _unitOfWork.UserRepository.Get(p => p.Id == id);

            if (entity == null)
                throw new Exception("Not found");

            _unitOfWork.UserRepository.Delete(entity);

            var delete = _unitOfWork.Save();

            return new ResponseBase<bool>(delete) { Success = delete };
        }
    }
}