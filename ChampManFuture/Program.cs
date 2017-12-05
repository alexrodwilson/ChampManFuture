using ChampManFuture.Components;
using ChampManFuture.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampManFuture
{
    class Program
    {
        static void Main(string[] args)
        {
            var connollyBD = new BaseData("Connolly", 8, 6, 10, 0, 11);
            var connolly = new Player(connollyBD, Area.HomeGoalRight, Role.Defender);
            var carsleyBD = new BaseData("Carsley", 10, 8, 14, 0, 17);
            var carsley = new Player(carsleyBD, Area.MidCenter, Role.Midfielder);
            var branchBD = new BaseData("Branch", 8, 8, 5, 0, 11);
            var branch = new Player(branchBD, Area.AwayGoalLeft, Role.Attacker);
            var gravesenBD = new BaseData("Gravesen", 14, 10, 10, 0, 15);
            var gravesen = new Player(gravesenBD, Area.MidCenter, Role.Midfielder);
            var yoboBD = new BaseData("Yobo", 11, 4, 16, 0, 11);
            var yobo = new Player(yoboBD, Area.HomeGoalCenter, Role.Defender);
            var cummingsBD = new BaseData("Cummings", 12, 12, 12, 0, 10);
            var cummings = new Player(cummingsBD, Area.MidLeft, Role.Midfielder);
            var maldiniBD = new BaseData("Maldini", 14, 6, 18, 0, 16);
            var maldini = new Player(maldiniBD, Area.HomeGoalLeft, Role.Defender);
            var jevonsBD = new BaseData("Jevons", 8, 13, 6, 0, 8);
            var jevons = new Player(jevonsBD, Area.AwayGoalRight, Role.Attacker);
            var xavierBD = new BaseData("Xavier", 7, 6, 13, 0, 9);
            var xavier = new Player(xavierBD, Area.MidRight, Role.Midfielder);
            var dunneBD = new BaseData("Dunne", 10, 6, 15, 0, 16);
            var dunne = new Player(dunneBD, Area.HomeGoalCenter, Role.Defender);
            var southallBD = new BaseData("Southall", 13, 3, 10, 18, 15);
            var southall= new Player(southallBD, Area.HomeGoalCenter, Role.Goalkeeper);

            var finnanBD = new BaseData("Finnan", 13, 6, 14, 0, 13);
            var finnan = new Player(finnanBD, Area.AwayGoalRight, Role.Defender);
            var whelanBD = new BaseData("Whelan", 10, 8, 8, 0, 10);
            var whelan = new Player(whelanBD, Area.MidRight, Role.Midfielder);
            var babelBD = new BaseData("Babel", 12, 14, 6, 0, 10);
            var babel = new Player(babelBD, Area.AwayGoalLeft, Role.Attacker);
            var sounessBD = new BaseData("Souness", 14, 14, 16, 0, 15);
            var souness = new Player(sounessBD, Area.MidCenter, Role.Midfielder);
            var babbBD = new BaseData("Babb", 9, 4, 13, 0, 12);
            var babb = new Player(babbBD, Area.AwayGoalCenter, Role.Defender);
            var jonesBD = new BaseData("Jones", 12, 10, 15, 0, 13);
            var jones = new Player(jonesBD, Area.AwayGoalLeft, Role.Defender);
            var molbyBD = new BaseData("Molby", 17, 15, 9, 0, 8);
            var molby = new Player(molbyBD, Area.MidLeft, Role.Midfielder);
            var saundersBD = new BaseData("Saunders", 8, 16, 6, 0, 14);
            var saunders = new Player(saundersBD, Area.HomeGoalRight, Role.Attacker);
            var thompsonBD = new BaseData("Thompson", 14, 6, 13, 0, 9);
            var thompson = new Player(thompsonBD, Area.MidRight, Role.Midfielder);
            var carragherBD = new BaseData("Carragher", 10, 6, 18, 0, 18);
            var carragher = new Player(carragherBD, Area.AwayGoalLeft, Role.Defender);
            var grobelaarBD = new BaseData("Grobelaar", 11, 3, 9, 14, 12);
            var grobelaar = new Player(grobelaarBD, Area.AwayGoalCenter, Role.Goalkeeper);
            IEnumerable<Player> evertonPlayers = new List<Player> { southall, carsley, gravesen, branch, xavier, cummings,
            connolly, jevons, dunne, maldini, yobo};
            IEnumerable<Player> liverpoolPlayers = new List<Player> { grobelaar, carragher, thompson, saunders
            , molby, jones, babb, souness, babel, whelan, finnan};
            var everton = new Team("Everton", evertonPlayers);
            var liverpool = new Team("Liverpool", liverpoolPlayers);
            MatchEngine.SimulateMatch(everton, liverpool);
            Console.ReadLine();
        }
    }
}
