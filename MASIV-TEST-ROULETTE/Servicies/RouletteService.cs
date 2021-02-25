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

    }
}