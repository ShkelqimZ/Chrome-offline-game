﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Rex_offline_game
{
    class Cloud
    {
        public int x { get; set; }
        public int y { get; set; }
        public int speed = 3;

        public Cloud(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void update()
        {
            x -= speed;
        }
    }
}
