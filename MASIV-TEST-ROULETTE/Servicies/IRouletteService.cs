using System.Collections.Generic;
using MASIV_TEST_ROULETTE.Models;

namespace MASIV_TEST_ROULETTE.Services
{
    public interface IRouletteService : IService
    {
        public Roulette create();

        public Roulette Find(string Id);

        public Roulette Open(string Id);
        public Roulette Close(string Id);

        public Roulette Bet(string Id, string UserId, int position, double money);

        public List<Roulette> GetAll();
    }
}