using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ax.SIS.SD.UI.EINV
{
 public   class GetIRNDetailsRequestEntity
    {
        public string doctype { get; set; }
        public string docnum { get; set; }
        public string docdate { get; set; }
    }
}
