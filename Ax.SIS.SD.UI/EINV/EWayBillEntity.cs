using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ax.SIS.SD.UI.EINV
{
    public class EWayBillEntity
    {
        public string IRN { get; set; }
        public string EwbNo { get; set; }
        public string EwbDt { get; set; }
        public string EwbValidTill { get; set; }
        public string Remarks { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string ResultCode { get; set; }
    }
}
