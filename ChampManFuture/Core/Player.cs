using ChampManFuture.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampManFuture.Core
{

    public class Player
    {
        public Area CurrentArea{get; set;}
        public BaseData BaseData { get; }
        public Role CurrentRole { get; set; }

        public Player(BaseData baseData, Area area, Role currentRole)
        {
            CurrentArea = area;
            BaseData = baseData;
            CurrentRole = currentRole;
        }

    }
}
