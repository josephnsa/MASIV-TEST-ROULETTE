using System;
using Microsoft.AspNetCore.Mvc;
using MASIV_TEST_ROULETTE.DTO;
using MASIV_TEST_ROULETTE.Models;
using MASIV_TEST_ROULETTE.Services;


namespace MASIV_TEST_ROULETTE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouletteController : Controller
    {
        private IRouletteService rouletteService;

        public RouletteController(IRouletteService rouletteService)
        {
            this.rouletteService = rouletteService;
        }
        /// <summary>
        /// Create a  new rulette
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult NewRulette()
        {
            Roulette roulette = rouletteService.create();
            return Ok(roulette);
        }
 
    }
}