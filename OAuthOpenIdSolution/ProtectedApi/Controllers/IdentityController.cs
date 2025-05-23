﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProtectedApi.Controllers
{
    [ApiController]
    [Route("identity")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(User.Claims.Select(c => new { c.Type, c.Value }));
        }
    }
}
