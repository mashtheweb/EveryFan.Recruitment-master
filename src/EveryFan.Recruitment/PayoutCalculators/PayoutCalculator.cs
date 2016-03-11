using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryFan.Recruitment.PayoutCalculators
{
    // HON LEE 
    // 10/3/2015
    public class PayoutCalculator
    {
        private IReadOnlyList<PayingPosition> GetPayingPositions(Tournament tournament)
        {
            List<PayingPosition> payingPosition = new List<PayingPosition>();

            int totalPrizePool = tournament.PrizePool;
            
            int winningBuyIn = tournament.BuyIn * 2;

            int remainingBuyIn = totalPrizePool - winningBuyIn;
            
            if (tournament.PayoutScheme == PayoutScheme.WINNER_TAKES_ALL)
            {
                
                int entries = tournament.Entries.Count;

                if (checkTied(tournament) > 0)
                {
                    long count = checkTied(tournament);

                    for (int i = 0; i < entries; i++)
                    {
                        PayingPosition position = new PayingPosition();
                        position.Position = (i + 1);

                        if (i < Convert.ToInt32(count))
                        {
                            position.Payout = totalPrizePool / Convert.ToInt32(count);
                            payingPosition.Add(position);
                        }

                        else
                        {
                            position.Payout = 0;
                        }
                    }
                }
                else
                {
                        for (int i = 0; i < entries; i++)
                        {
                            PayingPosition position = new PayingPosition();
                            position.Position = (i + 1);

                            if (position.Position == 1)
                            {
                                position.Payout = totalPrizePool;
                                payingPosition.Add(position);
                            }

                            else
                            {
                                position.Payout = 0;
                            }


                        }
                }
                return payingPosition;
            }
            else if (tournament.PayoutScheme == PayoutScheme.FIFTY_FIFY)
            {
                int entries = tournament.Entries.Count;
                if (checkTied(tournament) > 0)
                {
                    long count = checkTied(tournament);

                    for (int i = 0; i < entries; i++)
                    {
                        PayingPosition position = new PayingPosition();
                        position.Position = (i + 1);

                        if (i < Convert.ToInt32(count))
                        {
                            position.Payout = totalPrizePool / Convert.ToInt32(count);
                            payingPosition.Add(position);
                        }

                        else
                        {
                            position.Payout = 0;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < entries; i++)
                    {
                        PayingPosition position = new PayingPosition();
                        position.Position = (i + 1);

                        if (i == 0)
                        {
                            position.Payout = winningBuyIn;
                        }
                        else
                        {

                            if (IsOdd(entries))
                            {
                                position = getTopWinningHalfForOddNumbers(position, i, entries, totalPrizePool, tournament.BuyIn);
                            }
                            else
                            {
                                position = getTopWinningHalf(position, i, entries, winningBuyIn);
                            }

                        }
                        if (IsOdd(entries))
                        {
                            if (i < Convert.ToInt32(DivideRoundingUp(entries, 2)))
                            {
                                payingPosition.Add(position);
                            }
                        }
                        else if (i < (entries / 2))
                        {
                            payingPosition.Add(position);
                        }
                    }
                }

                return payingPosition;
            }

            return null;
        }

        public static int DivideRoundingUp(int x, int y)
        {
            // TODO: Define behaviour for negative numbers
            int remainder;
            int quotient = Math.DivRem(x, y, out remainder);
            return remainder == 0 ? quotient : quotient + 1;
        }

        public long checkTied(Tournament tournament)
        {
            long totalChips = 0;
            long highestChips = tournament.Entries[0].Chips;
            int count = 0;

            for (int i = 0; i < tournament.Entries.Count; i++)
            {
                if (highestChips == tournament.Entries[i].Chips)
                {
                    totalChips += tournament.Entries[i].Chips;
                    count++;
                }
            }
            if (count > 1)
            {
                return count;
            }
            return 0;
        }

        public PayingPosition getTopWinningHalf(PayingPosition position, int i, int entries, int winningPot)
        {
            int winningPositions = entries / 2;

            if (i < winningPositions)
            {
                position.Payout = winningPot;
            }
            else
            {
                position.Payout = 0;
            }

            return position;
        }

        public PayingPosition getTopWinningHalfForOddNumbers(PayingPosition position, int i, int entries, int winningPot, int stake)
        {
            //int winningPositions = Convert.ToInt32(Math.Floor(Convert.ToDouble(entries) / 2));
            int winningPositions = DivideRoundingUp(entries, 2);

            int winningMajority = winningPot - stake;

            decimal avg = Math.Round(Convert.ToDecimal(entries) / 2, MidpointRounding.AwayFromZero);
            if (i < winningPositions - 1)
            {
                position.Payout = winningMajority;
            }
            else if (i == avg - 1)
            {
                // Get middle position
                position.Payout = stake;
            }
            else
            {
                position.Payout = 0;
            }

            return position;
        }

        //int mid = nums[nums.Length/2];
        
        public static bool IsOdd(int value)
        {
            return value % 2 != 0;
        }

        public IReadOnlyList<TournamentPayout> GetTournamentPayoutCollection(Tournament tournament)
        {
            IReadOnlyList<PayingPosition> payingPositions = this.GetPayingPositions(tournament);
            IReadOnlyList<TournamentEntry> orderedEntries = tournament.Entries.OrderByDescending(p => p.Chips).ToList();
            
            List<TournamentPayout> payouts = new List<TournamentPayout>();
            payouts.AddRange(payingPositions.Select((p, i) => new TournamentPayout()
            {
                Payout = p.Payout,
                UserId = orderedEntries[i].UserId
            }));

            return payouts;
        }
    }
}
