using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportCareer.Career
{
    class SeriesNode
    {
        public string SeriesName;
        public string GameName;
        public string LicenseName;
       
        public SeriesNode(string series, string game, string license)
        {
            this.SeriesName = series;
            this.GameName = game;
            this.LicenseName = license;
        }
    }
}
