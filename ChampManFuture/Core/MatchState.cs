using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampManFuture.Core
{
    public class MatchState
    {
        
        public int HomeGoals { get; private set; }
        public int AwayGoals { get; private set; }
        public Area BallArea { get; set; }
        private PossessionState _possessionState;
        private Player _playerInPossession;
        public Team HomeTeam { get; }
        public Team AwayTeam { get; }

        private MatchState() { }

        public MatchState(Team homeTeam, Team awayTeam)
        {
            _possessionState = PossessionState.Disputed;
            BallArea = Area.MidCenter;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeGoals = 0;
            AwayGoals = 0;
        }

        //public void AdvanceTime()
        //{
        //    timeGone++;
        //}


        public void SetPlayerInPossession(Player player)
        {
            _playerInPossession = player;
            PossessionState ps = (player.BaseData.TeamName.Equals(HomeTeam.Name)) ? PossessionState.Home : PossessionState.Away;
            SetPossessionState(ps);
        }

        public void SetPossessionState(PossessionState possessionState)
        {
            _possessionState = possessionState; 
        }

        public PossessionState GetPossessionState()
        {
            return _possessionState;
        }

        public Player GetPlayerInPossession()
        {
            return _playerInPossession;
        }

        public Team GetTeamOf(Player player)
        {
            string teamName = player.BaseData.TeamName;
            return (HomeTeam.Name.Equals(teamName)) ? HomeTeam : AwayTeam;
        }


        public Team GetOpposingTeam(Player player)
        {
            string teamName = player.BaseData.TeamName;
            return (HomeTeam.Name.Equals(teamName)) ? AwayTeam : HomeTeam;
        }

        public void UpdateScore(Player scorer)
        {
            if (IsHomePlayer(scorer))
            {
                HomeGoals++;
            }
            else
            {
                AwayGoals++;
            }
              
        }

        private bool IsHomePlayer(Player player)
        {
            return (player.BaseData.TeamName.Equals(HomeTeam.Name));
        }
    }
}
