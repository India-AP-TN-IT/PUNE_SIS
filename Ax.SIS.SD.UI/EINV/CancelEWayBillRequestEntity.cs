using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ax.SIS.SD.UI.EINV
{
    public class CancelEWayBillRequestEntity
    {
        /// <summary>
        /// Required
        /// "type": "number",
        /// "description": "EwayBill Number
        /// </summary>
        public long ewbNo { get; set; }

        /// <summary>
        /// Required
        /// "type": "number",
        /// "description": "Reason for cancellation"
        /// </summary>
        public int cancelRsnCode { get; set; }

        /// <summary>
        /// Not Required
        /// "type": "string",
        /// "description": "Remarks"
        /// </summary>
        public string cancelRmrk { get; set; }
    }
}
