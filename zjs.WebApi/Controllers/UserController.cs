using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zjs.Application.DTOs;
using zjs.Application.Services.Interfaces;

namespace zjs_simple_frame.Controllers
{

    [Route("api/{Controller}")]
    [ApiController]
    public class UserController
    {
        private readonly IUserAppService _userApp;

        public UserController(IUserAppService userApp)
        {
            _userApp = userApp;
        }

        [HttpGet]
        public async Task<List<UserDTO>> GetUsers()
        {
            List<UserDTO> users = await _userApp.GetUsersAsync();

            return users;
        }

    }
}
