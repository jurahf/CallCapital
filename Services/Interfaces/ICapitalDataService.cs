using Services.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICapitalDataService
    {
        List<Capital> GetAll();

        Capital GetRandom(string userId, int points);
    }
}
