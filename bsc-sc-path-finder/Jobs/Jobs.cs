using PriorityQueue;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsc_sc_path_finder.Jobs
{
    public class Jobs
    {

        public string Symbol;
        public int Priority;
        public Image Sprite { get { return Properties.Resources.floor; } }
        public Point Location;
        public bool active = true;



        public setPosition(Point location)
        {

        }

    }
}
