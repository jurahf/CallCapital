using Services.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Services.CapitalServices
{
    public class CapitalDataService : ICapitalDataService
    {
        private Random random = new Random();

        public List<Capital> GetAll()
        {
            return CapitalDataSource.Instance().Get();
        }


        public Capital GetRandom(string userId, int points)
        {
            (int minComplexity, int maxComplexity)= CalcComplexity(userId, points);

            List<Capital> all = CapitalDataSource.Instance().Get()
                .Where(x => minComplexity <= x.Complexity && x.Complexity <= maxComplexity)
                .ToList();

            int index = random.Next(0, all.Count); // максимум не включительно
            return all[index];
        }


        private (int minComplexity, int maxComplexity) CalcComplexity(string userId, int points)
        {
            // userId пока не используется, пусть будет на перспективу


            // в справочнике сложность от 1 до 5
            // распределяется так: 1 - 21, 2 - 18, 3 - 33, 4 - 28, 5 - 92


            if (points < 10)
                return (1, 2);
            else if (points < 20)
                return (2, 3);
            else if (points < 25)
                return (2, 4);
            else if (points < 35)
                return (3, 5);
            else if (points < 40)
                return (4, 5);
            else
                return (4, 5);
        }



    }
}
