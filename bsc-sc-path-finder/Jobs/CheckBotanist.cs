using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsc_sc_path_finder.Jobs
{
    public class CheckBotanist : Jobs
    {

        string Symbol = "1";
        int Priority = 1;
        Image Sprite { get { return Properties.Resources.check_botanist; } }
        Point Location { get; private set; }

        public CheckBotanist(bool active)
        {

        }

    }
}
