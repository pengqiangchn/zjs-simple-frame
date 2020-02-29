using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zjs.Application.DTOs;
using zjs.Module.Entitys;

namespace zjs.Application.Services.Interfaces
{
    public interface IUserAppService
    {
        List<User> GetUsers();

        Task<List<UserDTO>> GetUsersAsync();
    }
}
