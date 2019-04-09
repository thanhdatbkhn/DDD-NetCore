
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iStorage.Business.DataTransferObjects;
using iStorage.Domain.AggregatesModels.Users;
using iStorage.Data.UnitOfWork;
using iStorage.Data.Repository;
using AutoMapper;
using iStorage.Common.Crypto;

namespace iStorage.Business.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersService(IMapper mapper,IUnitOfWork uow, IUserRepository userRepository)
        {
            _unitOfWork = uow;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public UserDTO Register(string userName, string password, string email)
        {
            User newUser = new User()
            {
                Name = userName,
                Password = CustomEncrypt.Encrypt(password),
                Email = email
            };

            _userRepository.Insert(newUser);
            _unitOfWork.Save();
            return _mapper.Map<UserDTO>(newUser);
        }
        public long Authenticate(string userName, string password)
        {
            var user = _userRepository.Get(u => u.Name == userName && u.Password == CustomEncrypt.Encrypt(password));
            if (user != null && user.Id > 0)
            {
                return user.Id;
            }
            return -1;
        }
    }
}
