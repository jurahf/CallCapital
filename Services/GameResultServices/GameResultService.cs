using Database;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.GameResultServices
{
    public class GameResultService : IGameResultService
    {
        private readonly CallCapitalDbContext db;

        public GameResultService(CallCapitalDbContext db)
        {
            this.db = db;
        }

        public UserResults GetBestResult(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException("UserId");

            UserResults result = db.UserResults.FirstOrDefault(x => x.UserId == userId);

            if (result == null)
            {
                result = new UserResults()
                {
                    UserId = userId,
                    BestResult = 0
                };

                db.Add(result);
                db.SaveChanges();
            }

            return result;
        }

        public UserResults UpdateBestResult(string userId, int points)
        {
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentNullException("UserId");

            UserResults result = db.UserResults.FirstOrDefault(x => x.UserId == userId);

            if (result == null)
            {
                result = new UserResults();
                result.UserId = userId;
            }

            result.BestResult = points;

            db.Update(result);
            db.SaveChanges();

            return result;
        }


    }
}
