using Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IGameResultService
    {
        UserResults GetBestResult(string userId);

        UserResults UpdateBestResult(string userId, int points);
    }
}
