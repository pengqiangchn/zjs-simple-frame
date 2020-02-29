using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zjs.Application.DTOs;
using zjs.Application.Services.Interfaces;
using zjs.Module.Entitys;
using zjs.Module.Repositorys.Interfaces;
using zjs.SeedWork;
using zjs.SeedWork.Extensions;

namespace zjs.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository _repo;
        private readonly IRepository<User> _repo2;

        public UserAppService(IUserRepository repository, IRepository<User> repository2)
        {
            _repo = repository;
            _repo2 = repository2;
        }


        public List<User> GetUsers()
        {
            var s = _repo.GetAll().ToList();

            return s;
        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            var s = await _repo2.GetAllAsync();

            List<UserDTO> ss = s.MapTo<UserDTO>();

            return ss;
        }

    }
}
