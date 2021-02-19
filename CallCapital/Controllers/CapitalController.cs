using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCapital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CapitalController : ControllerBase
    {
        private readonly ILogger<CapitalController> logger;
        private readonly ICapitalDataService dataService;


        public CapitalController(ILogger<CapitalController> logger, ICapitalDataService dataService)
        {
            this.logger = logger;
            this.dataService = dataService;
        }

        [HttpGet]
        [ActionName("GetAll")]
        [Route("[action]")]
        public IEnumerable<Capital> Get()
        {
            return dataService.GetAll();
        }


        [HttpGet]
        [ActionName("GetRandom")]
        [Route("[action]")]
        public Capital GetRandom([FromQuery] string userId, [FromQuery] int points)
        {
            return dataService.GetRandom(userId, points);
        }



        // такой же, как GET, только POST. А то "салют" не может GET-параметры передать
        [HttpPost]
        [ActionName("PostRandom")]
        [Route("[action]")]
        public Capital PostRandom([FromBody] QueryQuestionArgs args)
        {
            return dataService.GetRandom(args.userId, args.points);
        }


    }


    public class QueryQuestionArgs
    {
        public string userId { get; set; }
        public int points { get; set; }
    }



}
