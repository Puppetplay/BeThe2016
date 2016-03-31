using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 직구구속확인
{
    class PitcherInfo
    {
        public Int32 PlayerId { get; set; }
        public String Name { get; set; }
        public String Hand { get; set; }
        public Int32? MaxSpeed { get; set; }
        public Int32? MinSpeed { get; set; }
        public Double? Average { get; set; }
    }
}
