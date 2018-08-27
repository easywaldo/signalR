using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalR.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushController : ControllerBase
    {
        private readonly IHubContext<MyPushService> _hubContext;

        public PushController(IHubContext<MyPushService> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<ActionResult> Push(string message)
        {
            await _hubContext.Clients.All.SendAsync("SendMessageOut", message);

            return Ok();
        }
    }
}