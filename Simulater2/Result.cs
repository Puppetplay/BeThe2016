using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulater2
{
    class Result
    {
        public String Date { get; set;  }
        public List<String> Picks { get; set; }
        public List<String> Successes { get; set; }

        public String Pick1 { get { return Picks[0]; } }
        public String Successe1 { get { return Successes[0]; } }
        public String Pick2 { get { return Picks[1]; } }
        public String Successe2 { get { return Successes[1]; } }
        public String Pick3 { get { return Picks[2]; } }
        public String Successe3 { get { return Successes[2]; } }
        public String Pick4 { get { return Picks[3]; } }
        public String Successe4 { get { return Successes[3]; } }
        public String Pick5 { get { return Picks[4]; } }
        public String Successe5 { get { return Successes[4]; } }
        public String Pick6 { get { return Picks[5]; } }
        public String Successe6 { get { return Successes[5]; } }
        public String Pick7 { get { return Picks[6]; } }
        public String Successe7 { get { return Successes[6]; } }
        public String Pick8 { get { return Picks[7]; } }
        public String Successe8 { get { return Successes[7]; } }
        public String Pick9 { get { return Picks[8]; } }
        public String Successe9 { get { return Successes[8]; } }
        public String Pick10 { get { return Picks[9]; } }
        public String Successe10 { get { return Successes[9]; } }
    }
}
