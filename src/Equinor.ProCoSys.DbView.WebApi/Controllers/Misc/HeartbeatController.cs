﻿using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Equinor.ProCoSys.DbView.WebApi.Controllers.Misc
{
    [ApiController]
    [Route("api/DbView/Heartbeat")]
    public class HeartbeatController : ControllerBase
    {
        private readonly ILogger<HeartbeatController> _logger;

        public HeartbeatController(ILogger<HeartbeatController> logger) => _logger = logger;

        [AllowAnonymous]
        [HttpGet("IsAlive")]
        public IActionResult IsAlive()
        {
            var timestampString = $"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC";
            _logger.LogDebug($"The application is running at {timestampString}");
            return new JsonResult(new
            {
                IsAlive = true,
                TimeStamp = timestampString
            });
        }
    }
}
