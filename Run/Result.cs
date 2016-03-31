using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run
{
    class Result
    {
        public String Date { get; set; }
        public List<String> Picks { get; set; }
        public List<String> Successes { get; set; }

        public String Pick0
        {
            get
            {
                if (Picks != null && Picks.Count() > 0) { return Picks[0]; }
                else{ return ""; }
            }
        }
        public String Successe0
        {
            get
            {
                if (Successes != null && Successes.Count() > 0) { return Successes[0]; }
                else { return ""; }
            }
        }

        public String Pick1
        {
            get
            {
                if (Picks != null && Picks.Count() > 1) { return Picks[1]; }
                else { return ""; }
            }
        }
        public String Successe1
        {
            get
            {
                if (Successes != null && Successes.Count() > 1) { return Successes[1]; }
                else { return ""; }
            }
        }

        public String Pick2
        {
            get
            {
                if (Picks != null && Picks.Count() > 2) { return Picks[2]; }
                else { return ""; }
            }
        }
        public String Successe2
        {
            get
            {
                if (Successes != null && Successes.Count() > 2) { return Successes[2]; }
                else { return ""; }
            }
        }

        public String Pick3
        {
            get
            {
                if (Picks != null && Picks.Count() > 3) { return Picks[3]; }
                else { return ""; }
            }
        }
        public String Successe3
        {
            get
            {
                if (Successes != null && Successes.Count() > 3) { return Successes[3]; }
                else { return ""; }
            }
        }

        public String Pick4
        {
            get
            {
                if (Picks != null && Picks.Count() > 4) { return Picks[4]; }
                else { return ""; }
            }
        }
        public String Successe4
        {
            get
            {
                if (Successes != null && Successes.Count() > 4) { return Successes[4]; }
                else { return ""; }
            }
        }

        public String Pick5
        {
            get
            {
                if (Picks != null && Picks.Count() > 5) { return Picks[5]; }
                else { return ""; }
            }
        }
        public String Successe5
        {
            get
            {
                if (Successes != null && Successes.Count() > 5) { return Successes[5]; }
                else { return ""; }
            }
        }

        public String Pick6
        {
            get
            {
                if (Picks != null && Picks.Count() > 6) { return Picks[6]; }
                else { return ""; }
            }
        }
        public String Successe6
        {
            get
            {
                if (Successes != null && Successes.Count() > 6) { return Successes[6]; }
                else { return ""; }
            }
        }

        public String Pick7
        {
            get
            {
                if (Picks != null && Picks.Count() > 7) { return Picks[7]; }
                else { return ""; }
            }
        }
        public String Successe7
        {
            get
            {
                if (Successes != null && Successes.Count() > 7) { return Successes[7]; }
                else { return ""; }
            }
        }

        public String Pick8
        {
            get
            {
                if (Picks != null && Picks.Count() > 8) { return Picks[8]; }
                else { return ""; }
            }
        }
        public String Successe8
        {
            get
            {
                if (Successes != null && Successes.Count() > 8) { return Successes[8]; }
                else { return ""; }
            }
        }

        public String Pick9
        {
            get
            {
                if (Picks != null && Picks.Count() > 9) { return Picks[9]; }
                else { return ""; }
            }
        }
        public String Successe9
        {
            get
            {
                if (Successes != null && Successes.Count() > 9) { return Successes[9]; }
                else { return ""; }
            }
        }
    }
}
