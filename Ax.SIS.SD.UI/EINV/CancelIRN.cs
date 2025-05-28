using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ax.SIS.SD.UI.EINV
{
    public class CancelIRN
    {
        public string Irn { get; set; }
        public string CancelDate { get; set; }
    }

    public class IRNData
    {
        public string SlNo { get; set; }

        public string IRN { get; set; }

        public string AckNo { get; set; }

        public string AckDate { get; set; }

        public string DocNo { get; set; }

        public string DocType { get; set; }

        public string DocDate { get; set; }

        public string InvValue { get; set; }

        public string RecptGSTIN { get; set; }

        public string IRNStatus { get; set; }

        public string SignedQRCode { get; set; }

        public string EWayBill { get; set; }
    }

    public class FailedInvoiceDetails
    {
        public string SlNo { get; set; }

        public string InvoiceNo { get; set; }

        public string InvoiceDate { get; set; }

        public string BuyerGSTIN { get; set; }

        public string InvoiceValue { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorData { get; set; }
    }
}
