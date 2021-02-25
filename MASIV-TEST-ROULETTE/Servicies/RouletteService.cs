using System;
using System.Collections.Generic;
using MASIV_TEST_ROULETTE.Exceptions;
using MASIV_TEST_ROULETTE.Models;
using MASIV_TEST_ROULETTE.Repositories;

namespace MASIV_TEST_ROULETTE.Services
{
    public class RouletteService : IRouletteService
    {
        private IRouletteRepository rouletteRepository;

        public RouletteService(IRouletteRepository rouletteRepository)
        {
            this.rouletteRepository = rouletteRepository;
        }

        public Roulette create()
        {
            Roulette roulette = new Roulette()
            {
                Id    = Guid.NewGuid().ToString(),
                IsOpen = false,
                OpenedAt = null,
                ClosedAt = null
            };
            rouletteRepository.Save(roulette);
            return roulette;
        }

        public Roulette Open(string Id)
        {
            Roulette roulette = rouletteRepository.GetById(Id);
            if (roulette == null)
            {
                throw new RouletteNotFound();
            }

            if (roulette.OpenedAt != null)
            {
                throw new NotAllowedOpenException();
            }
            roulette.OpenedAt = DateTime.Now;
            roulette.IsOpen = true;
            return rouletteRepository.Update(Id, roulette);
        }

        public Roulette Bet(string Id, string UserId, int position, double moneyBet)
        {
            if (moneyBet > 10000 || moneyBet < 1)
            {
                throw new CashOutRangeException();
            }
            Roulette roulette = rouletteRepository.GetById(Id);
            if (roulette == null)
            {
                throw new RouletteNotFound();
            }

            if (roulette.IsOpen == false)
            {
                throw new RouletteClosedException();
            }

            double value = 0d;
            roulette.board[position].TryGetValue(UserId, out value);
            roulette.board[position].Remove(UserId+"");
            roulette.board[position].TryAdd(UserId + "", value + moneyBet);

            return  rouletteRepository.Update(roulette.Id, roulette);
        }

        public List<Roulette> GetAll()
        {
            return rouletteRepository.GetAll();
        }
    }
}