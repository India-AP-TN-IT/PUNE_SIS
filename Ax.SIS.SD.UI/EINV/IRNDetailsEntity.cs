using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ax.SIS.SD.UI.EINV
{
    public class IRNDetailsEntity
    {
        public string InoviceNo { get; set; }
        public string AckNo { get; set; }
        public string AckDt { get; set; }
        public string Irn { get; set; }
        public string SignedInvoice { get; set; }
        public string SignedQRCode { get; set; }
        public string Status { get; set; }
        public string EwbNo { get; set; }
        public string EwbDt { get; set; }
        public string EwbValidTill { get; set; }
        public string Remarks { get; set; }
        public string ResultCode { get; set; }
    }
}
