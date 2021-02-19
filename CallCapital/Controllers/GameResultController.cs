using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallCapital.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameResultController : ControllerBase
    {
        private readonly IGameResultService gameService;

        public GameResultController(IGameResultService gameService)
        {
            this.gameService = gameService;
        }


        [HttpPost]
        [ActionName("UpdateAndGetResult")]
        [Route("[action]")]
        public GameResult UpdateAndGetResult([FromBody] GameResultArgs args)
        {
            if (string.IsNullOrEmpty(args?.userId))
                throw new ArgumentNullException("UserId");

            GameResult result = new GameResult()
            {
                Points = args.newResult,
            };

            UserResults saved = gameService.GetBestResult(args.userId);
            if (saved.BestResult < args.newResult)
            {
                gameService.UpdateBestResult(args.userId, args.newResult);
                result.BestResult = args.newResult;
                result.NewBestResult = true;
            }
            else
            {
                result.BestResult = saved.BestResult;
                result.NewBestResult = false;
            }

            return result;
        }

    }


    public class GameResultArgs
    {
        public string userId { get; set; }
        public int newResult { get; set; }
    }

    public class GameResult
    {
        public bool NewBestResult { get; set; }
        public int BestResult { get; set; }
        public int Points { get; set; }
    }


}
