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
using DnDInventoryApp.Services;

namespace DnDInventoryApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login(LoginModel userInfo)
        {
            if(_accountService.LoginUser(userInfo))
            {
                return View();
            }
            return View();
        }

    }
}
