using Services.DataClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICrocodileDataService
    {
        Crocodile GetRandom(string theme);

        List<Crocodile> GetAll();
    }
}
