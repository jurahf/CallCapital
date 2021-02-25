using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.DataClasses;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CallCapital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CrocodileController : Controller
    {
        private readonly ILogger<CrocodileController> logger;
        private readonly ICrocodileDataService dataService;

        public CrocodileController(ILogger<CrocodileController> logger, ICrocodileDataService dataService)
        {
            this.logger = logger;
            this.dataService = dataService;
        }

        [HttpGet]
        [Route("[action]")]
        [ActionName("GetRandom")]
        public Crocodile GetRandom([FromQuery] string theme)
        {
            return dataService.GetRandom(theme);
        }
    }
}
