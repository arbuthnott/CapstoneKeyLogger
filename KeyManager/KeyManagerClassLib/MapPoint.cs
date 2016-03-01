using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyManagerClassLib
{
    public class MapPoint
    {
        public int x;
        public int y;
        public Door door;

        public MapPoint(int x, int y, Door door)
        {
            this.x = x;
            this.y = y;
            this.door = door;
        }
    }
}
