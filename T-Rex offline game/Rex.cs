using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Rex_offline_game
{
    class Rex
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool jump;
        public int force;
        public int g = 100;

        public Rex()
        {
        }

        public void Jump()
        {
            if (jump != true)
            {
                jump = true;
                force = g;
            }
            
        }
    }
}
