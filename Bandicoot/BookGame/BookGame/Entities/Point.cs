using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookGame
{
    public class Point
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Point(int i, int j)
        {
            Row = i;
            Column = j;
        }       
    }
}
