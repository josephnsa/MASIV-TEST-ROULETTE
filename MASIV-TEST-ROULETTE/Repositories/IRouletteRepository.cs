using System.Collections.Generic;
using MASIV_TEST_ROULETTE.Models;

namespace MASIV_TEST_ROULETTE.Repositories
{
    public interface IRouletteRepository : IRepository
    {
        public Roulette GetById(string Id);

        public List<Roulette> GetAll();
        
        public Roulette Update(string Id, Roulette roulette);
        
        public Roulette Save(Roulette roulette);
    }
}