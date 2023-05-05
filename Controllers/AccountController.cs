using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnDInventoryApp.Data;
using DnDInventoryApp.Repositories;
using DnDInventoryApp.Models;

namespace DnDInventoryApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //public IActionResult Login(LoginModel userInfo)
        //{
            
        //}

    }
}
