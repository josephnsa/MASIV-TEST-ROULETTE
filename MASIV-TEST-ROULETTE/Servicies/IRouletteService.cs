using System.Collections.Generic;
using MASIV_TEST_ROULETTE.Models;

namespace MASIV_TEST_ROULETTE.Services
{
    public interface IRouletteService : IService
    {
        public Roulette create();

    }
}