using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampManFuture.Core
{

    public enum Role { Goalkeeper, Defender, Midfielder, Attacker };
    public enum PossessionState { Home, Away, Disputed };
    public enum Area
    {
        HomeGoalLeft, HomeGoalCenter, HomeGoalRight,
        MidLeft, MidCenter, MidRight, AwayGoalLeft, AwayGoalCenter, AwayGoalRight
    };


}
