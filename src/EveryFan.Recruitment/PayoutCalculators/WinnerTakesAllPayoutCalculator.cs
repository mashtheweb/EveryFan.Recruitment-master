using System;
using System.Collections.Generic;
using System.Linq;

namespace EveryFan.Recruitment.PayoutCalculators
{
    /// <summary>
    /// Winner takes all payout calculator, the winner recieves the entire prize pool. In the event of a tie for the winning position the
    /// prize pool is split equally between the tied players.
    /// </summary>
    public class WinnerTakesAllPayoutCalculator : IPayoutCalculator
    {
<<<<<<< HEAD
        public IReadOnlyList<TournamentPayout> Calculate(Tournament tournament)
        {
            PayoutCalculator payoutCalculator = new PayoutCalculator();
            return payoutCalculator.GetTournamentPayoutCollection(tournament);
=======
        private IReadOnlyList<PayingPosition> GetPayingPositions(Tournament tournament)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<TournamentPayout> Calculate(Tournament tournament)
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
>>>>>>> 9c01dd65928ea601259ca358a4cfed795c6ac63b
        }
    }
}
