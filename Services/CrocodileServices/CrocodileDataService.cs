using Services.DataClasses;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.CrocodileServices
{
    public class CrocodileDataService : ICrocodileDataService
    {
        private Random random = new Random();


        public List<Crocodile> GetAll()
        {
            return CrocodileDataSource.Instance().Get();
        }

        public Crocodile GetRandom(string theme)
        {
            List<Crocodile> all = CrocodileDataSource.Instance().Get()
                .Where(x => string.IsNullOrEmpty(theme) || theme.Equals(x.Theme, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            int index = random.Next(0, all.Count); // максимум не включительно
            return all[index];
        }
    }
}
