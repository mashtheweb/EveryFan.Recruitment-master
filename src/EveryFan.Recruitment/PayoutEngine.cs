using System;
using System.Collections.Generic;
using EveryFan.Recruitment.PayoutCalculators;

namespace EveryFan.Recruitment
{
    public class PayoutEngine
    {
<<<<<<< HEAD
        public static IPayoutCalculator payoutEngine;

        public IPayoutCalculator Create(PayoutScheme payoutScheme)
        {

            switch (payoutScheme)
            {
                case PayoutScheme.FIFTY_FIFY:
                    {
                        payoutEngine = new FiftyFiftyPayoutCalculator();
                        break;
                    }

                case PayoutScheme.WINNER_TAKES_ALL:
                    {
                        payoutEngine = new WinnerTakesAllPayoutCalculator();
                        break;
                    }

                default:
                    {
                        throw new ArgumentOutOfRangeException(payoutScheme.ToString());
                    }
            }

            return (IPayoutCalculator) payoutEngine;
        }

        public IReadOnlyList<TournamentPayout> Calculate(Tournament tournament)
        {
            return payoutEngine.Calculate(tournament);

        }

        //public IReadOnlyList<TournamentPayout> Calculate(Tournament tournament)
        //{
        //    IPayoutCalculator calculator;

        //    switch (tournament.PayoutScheme)
        //    {
        //        case PayoutScheme.FIFTY_FIFY:
        //        {
        //            calculator = new FiftyFiftyPayoutCalculator();
        //            break;
        //        }

        //        case PayoutScheme.WINNER_TAKES_ALL:
        //        {
        //            calculator = new WinnerTakesAllPayoutCalculator();
        //            break;
        //        }

        //        default:
        //        {
        //            throw new ArgumentOutOfRangeException(tournament.PayoutScheme.ToString());
        //        }
        //    }

        //    return calculator.Calculate(tournament);
        //}
=======
        public IReadOnlyList<TournamentPayout> Calculate(Tournament tournament)
        {
            IPayoutCalculator calculator;

            switch (tournament.PayoutScheme)
            {
                case PayoutScheme.FIFTY_FIFY:
                {
                    calculator = new FiftyFiftyPayoutCalculator();
                    break;
                }

                case PayoutScheme.WINNER_TAKES_ALL:
                {
                    calculator = new WinnerTakesAllPayoutCalculator();
                    break;
                }

                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(tournament.PayoutScheme));
                }
            }

            return calculator.Calculate(tournament);
        }
>>>>>>> 9c01dd65928ea601259ca358a4cfed795c6ac63b
    }
}
