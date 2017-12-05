using ChampManFuture.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampManFuture.Core
{
    class MatchEngine
    {

        private static Random random = new Random();
        private static Dice dice = new Dice(random);

        public static MatchState SimulateMatch(Team homeTeam, Team awayTeam)
        {
            
            int timeLeft = 90;
            bool gamePaused = false;
            MatchState ms = new MatchState(homeTeam, awayTeam);
            while (timeLeft > 0 && gamePaused == false)
            {
                ms = SimulateMoment(homeTeam, awayTeam, ms);
                timeLeft--;
            }
            return ms;

        }

        public static MatchState SimulateMoment(Team home, Team away, MatchState ms)
        {
            var ballArea = ms.BallArea;
            Func<Player, bool> PlayerAreaSameAsBall = (player)=>{ return player.CurrentArea == ballArea; };
            Func<Player, Player, Player> MostDetermined = (playerA, playerB) => 
            { return (playerA.BaseData.Determination + dice.DieN(10) >= playerB.BaseData.Determination + dice.DieN(10)) ? playerA : playerB; };
            if (ms.GetPossessionState() == PossessionState.Disputed)
            {
                IEnumerable<Player> competingForBall = home.Players.Where(PlayerAreaSameAsBall); // merge with away
                Player ballWinner = competingForBall.Aggregate(MostDetermined);
                //ms.AdvanceTime();
                ms.SetPlayerInPossession(ballWinner);//also set PossessionState to home/away
                Console.Out.WriteLine("{0} picks up the loose ball.", ballWinner.BaseData.Name);
                return ms;
            }
            else
            {
                //PossessionState teamInPossession = ms.PossessionState;
                if (WillShoot(ms.GetPlayerInPossession(), ms))
                {
                    return Shoot(ms.GetPlayerInPossession(), ms);
                }
                else
                {
                    return  Pass(ms.GetPlayerInPossession(), ms);
                }
            }
        }
        //
        private static MatchState Shoot(Player shooter, MatchState ms)
        {
            int shooting = shooter.BaseData.Shooting;
            var OpposingTeam = ms.GetOpposingTeam(shooter);
            Player keeper = OpposingTeam.GetKeeper();

            if (shooting >= dice.DieN(20))//on target
            {
                Console.Out.WriteLine("The shot from {0} is on target.", shooter.BaseData.Name);
                
                
                if(keeper.BaseData.Goalkeeping < dice.DieN(10) + shooter.BaseData.Shooting)
                {
                    Console.Out.WriteLine("{0} scores! What a goal that is!", shooter.BaseData.Name);
                    ms.UpdateScore(shooter);
                    PrintScore(ms);
                    ms.SetPlayerInPossession(GeneralUtils.PickRandom(ms.GetOpposingTeam(shooter).Players, random));
                    return ms;
                }
                else
                {
                    Console.Out.WriteLine("Great save from {0}!", keeper.BaseData.Name);
                    ms.SetPlayerInPossession(keeper);
                    return ms;
                }
            }
            else
            {
                Console.Out.WriteLine("The ball has gone out for a goal kick. {0} to take.", keeper.BaseData.Name);
                ms.SetPlayerInPossession(keeper);
                return ms;
            }
        }

        private static MatchState Pass(Player passer, MatchState ms)
        {
            int passing = passer.BaseData.Passing;
            Team opposingTeam = ms.GetOpposingTeam(passer);
            Player intendedRecipient = GeneralUtils.PickRandom(ms.GetTeamOf(passer).Players
                .Where(p=>! p.BaseData.Name.Equals(passer.BaseData.Name)), random);
            if (passing >= dice.DieN(20))//Pass Completed
            {
                Console.Out.WriteLine("{0} passes to {1}.", passer.BaseData.Name, intendedRecipient.BaseData.Name);
                ms.SetPlayerInPossession(intendedRecipient);
                return ms;
            }
            else
            {
                Func<Player, bool> SameAreaAsPasser = (oppositionPlayer) =>
                {
                    return oppositionPlayer.CurrentArea == intendedRecipient.CurrentArea;
                };
                IEnumerable<Player> possibleIntercepters = opposingTeam.Players.Where(SameAreaAsPasser);
                if (possibleIntercepters.Any())
                {
                    Func<Player, Player, Player> BestInTackling = (playerA, playerB) => 
                    (playerA.BaseData.Tackling >= playerB.BaseData.Tackling) ? playerA : playerB;
                    Player intercepter = possibleIntercepters.Aggregate(BestInTackling);
                    ms.SetPlayerInPossession(intercepter);
                    Console.WriteLine("Great interception by {0}", intercepter.BaseData.Name);
                    return ms;
                }
                else
                {
                    ms.SetPossessionState(PossessionState.Disputed);
                    Console.WriteLine("{0}'s pass is wayward.", passer.BaseData.Name);
                    return ms;
                }
            }

        }
        private static bool WillShoot(Player player, MatchState ms)
        {
            if (player.BaseData.TeamName.Equals(ms.HomeTeam.Name) &&
                ((player.CurrentArea == Area.AwayGoalLeft) || (player.CurrentArea == Area.AwayGoalCenter)
                ||(player.CurrentArea == Area.AwayGoalRight)))
            {
                return true;
            }
            else if (player.BaseData.TeamName.Equals(ms.AwayTeam.Name) &&
               ((player.CurrentArea == Area.HomeGoalLeft) || (player.CurrentArea == Area.HomeGoalCenter)
               || (player.CurrentArea == Area.HomeGoalRight)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void PrintScore(MatchState ms)
        {
            if (ms.HomeGoals == ms.AwayGoals)
            {
                Console.WriteLine("The teams are now level at {0} goals a piece.", ms.HomeGoals);
            }
            else
            {
                Console.WriteLine("{0} now lead by {1} to {2}.", 
                    (ms.HomeGoals > ms.AwayGoals) ? ms.HomeTeam.Name : ms.AwayTeam.Name, 
                    Math.Max(ms.HomeGoals, ms.AwayGoals), 
                    Math.Min(ms.HomeGoals, ms.AwayGoals));
            }
            
        }

    }
}
