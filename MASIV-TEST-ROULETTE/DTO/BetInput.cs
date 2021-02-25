using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MASIV_TEST_ROULETTE.DTO
{
   public class BetInput
    {

        /// <summary>
        /// position 0-36, and 37=> red, 38 => black
        /// </summary>
        [Range(0, 38)]
        public int position { get; set; }

        /// <summary>
        /// Money to bet
        /// </summary>
        [Range(0.5d, maximum: 10000)]
        public double money { get; set; }
    }
}
