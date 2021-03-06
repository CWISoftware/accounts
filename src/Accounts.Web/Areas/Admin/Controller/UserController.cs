﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Accounts.Web.Areas.Admin.Model;
using Accounts.Web.Services.Domain;
using Common.Pagination;

namespace Accounts.Web.Areas.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
