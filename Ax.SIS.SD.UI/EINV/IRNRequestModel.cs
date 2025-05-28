using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ax.SIS.SD.UI.EINV
{
    public class IRNRequestModel
    {
        public string CorporationCode { get; set; }

        public string BusinessCode { get; set; }

        public string CustomerCode { get; set; }

        public string DeliveryDate { get; set; }

        public string TruckNo { get; set; }

        public string TruckSeqNo { get; set; }

        public string Gate { get; set; }

        public string CustomerPlant { get; set; }

        public string InvoiceNo { get; set; }

        public string Filename { get; set; }
    }
}
