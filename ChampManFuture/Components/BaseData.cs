using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampManFuture.Components
{
    public class BaseData 
    {
        public int Passing{get; set;}
        public int Shooting { get; set; }
        public int Tackling { get; set; }
        public int Goalkeeping { get; set; }
        public int Determination { get; set; }
        public String Name { get; set; }
        public String TeamName { get; set; }

        public BaseData(String name, int passing, int shooting, int tackling, int goalkeeping, int determination)
        {
            Name = name;
            Passing = passing;
            Shooting = shooting;
            Tackling = tackling;
            Goalkeeping = goalkeeping;
            Determination = determination;
        }
    }
}
