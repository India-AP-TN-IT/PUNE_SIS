using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ax.SIS.SD.UI.EINV
{
  public  class CreateEWayBillRequestEntity
    {
        /// <summary>
        /// "type": "string",
        /// "minLength": 64,
        /// "maxLength": 64,
        /// "description": "Irn Number"
        /// </summary>
        public string Irn { get; set; }

        /// <summary>
        /// "type": "string",
        /// "minLength": 15,
        /// "maxLength": 15,
        /// "pattern": "([0-9]{2}[0-9A-Z]{13})",
        /// "description": "Transin/GSTIN"
        /// </summary>
        public string TransId { get; set; }

        /// <summary>
        /// "type": "string",
        /// "minLength": 3,
        /// "maxLength": 100,
        /// "pattern": "^([^\\\"])*$",
        /// "description": "Name of the transporter"
        /// </summary>
        public string TransName { get; set; }

        /// <summary>
        /// "type": "string",
        /// "maxLength": 1,
        /// "minLength": 1,
        /// "enum": [
        ///	"1",
        /// 	"2",
        ///	"3",
        ///	"4"
        /// ],
        /// "pattern": "^([1-4]{1})?$",
        /// "description": "Mode of transport (Road-1, Rail-2, Air-3, Ship-4)"
        /// </summary>
        public string TransMode { get; set; }

        /// <summary>
        /// "type": "number",
        /// "minimum": 0,
        /// "maximum": 4000,
        /// "description": "Distance between source and destination PIN codes"
        /// </summary>
        public Int32 Distance { get; set; }

        /// <summary>
        /// "type": "string",
        /// "minLength": 1,
        /// "maxLength": 15,
        /// "pattern": "^([a-zA-Z0-9\/-]{1,15})$",
        /// "description": "Transport Document Number"
        /// </summary>
        public string TransDocNo { get; set; }

        /// <summary>
        /// "type": "string",
        /// "minLength": 10,
        /// "maxLength": 10,
        /// "pattern": "^[a-zA-Z0-9]{1}[a-zA-Z0-9-/]*$",
        /// "description": "Transport Document Date"
        /// </summary>
        public string TransDocDt { get; set; }

        /// <summary>
        /// "type": "string",
        /// "minLength": 4,
        /// "maxLength": 20,
        /// "pattern": "^([A-Z|a-z|0-9]{4,20})$",
        /// "description": "Vehicle Number"
        /// </summary>
        public string VehNo { get; set; }

        /// <summary>
        /// "type": "string",
        /// "minLength": 1,
        /// "maxLength": 1,
        /// "enum": [
        ///	"O",
        /// 	"R"
        /// ],
        /// "pattern": "^([O|R]{1})$",
        /// "description": "Whether O-ODC or R-Regular "
        /// </summary>
        public string VehType { get; set; }

        //public EWayBillShipToDetails ExpShipDtls { get; set; }

        //public EWayBillDispatchFromDtls DispDtls { get; set; }
    }

  /// <summary>
  /// "required": [
  ///    "Nm",
  ///    "Addr1",
  ///    "Loc",
  ///    "Pin",
  ///    "Stcd"
  ///]
  /// </summary>
  public class EWayBillDispatchFromDtls
  {
      /// <summary>
      ///"type": "string",
      ///"minLength": 3,
      ///"maxLength": 100,
      ///"pattern": "^([^\\\"])*$",
      ///"description": "Name of the company from which the goods are dispatched"
      /// </summary>
      public string Nm { get; set; }

      /// <summary>
      ///"type": "string",
      ///"minLength": 1,
      ///"maxLength": 100,
      ///"pattern": "^([^\\\"])*$",
      ///"description": "Address 1 of the entity from which goods are dispatched. (Building/Flat no.Road/Street etc.)"
      /// </summary>
      public string Addr1 { get; set; }

      /// <summary>
      ///"type": "string",
      ///"minLength": 3,
      ///"maxLength": 100,
      ///"pattern": "^([^\\\"])*$",
      ///"description": "Address 2 of the entity from which goods are dispatched. (Floor no., Name of the premises/building)"
      /// </summary>
      public string Addr2 { get; set; }

      /// <summary>
      /// "type": "string",
      ///"minLength": 3,
      ///"maxLength": 100,
      ///"pattern": "^([^\\\"])*$",
      ///"description": "Location"
      /// </summary>

      public string Loc { get; set; }

      /// <summary>
      ///    "type": "number",
      ///"minimum": 100000,
      ///"maximum": 999999,
      ///"description": "Pincode"
      /// </summary>
      public int Pin { get; set; }

      /// <summary>
      ///"type": "string",
      ///"minLength": 1,
      ///"maxLength": 2,
      ///"pattern": "^(?!0+$)([0-9]{1,2})$",
      ///"description": "State Code. Refer the master"
      /// </summary>
      public string Stcd { get; set; }
  }

  /// <summary>
  /// "required": [
  ///	"Addr1",
  ///	"Loc",
  ///	"Pin",
  ///	"Stcd"
  ///	]
  /// </summary>

  public class EWayBillShipToDetails
  {

      /// <summary>
      /// "type": "string",
      /// "minLength": 3,
      /// "maxLength": 100,
      /// "pattern": "^([^\\\"])*$",
      /// "description": "Address1 of the entity to whom the supplies are shipped to. (Building/Flat no.,Road/Street etc.)"
      /// </summary>
      public string Addr1 { get; set; }

      /// <summary>
      /// "type": "string",
      /// "minLength": 3,
      /// "maxLength": 100,
      /// "pattern": "^([^\\\"])*$",
      /// "description": "Address 2 of the entity to whom the supplies are shipped to. (Floor no., Name of the premises/building)."
      /// </summary>
      public string Addr2 { get; set; }

      /// <summary>
      ///"type": "string",
      ///"minLength": 3,
      ///"maxLength": 100,
      ///"pattern": "^([^\\\"])*$",
      ///"description": "Address 2 of the supplier (Floor no., Name of the premises/building)"
      /// </summary>
      public string Loc { get; set; }

      /// <summary>
      ///"type": "number",
      ///"minimum": 100000,
      ///"maximum": 999999,
      ///"description": "Pincode"
      /// </summary>
      public int Pin { get; set; }

      /// <summary>
      ///"type": "string",
      ///"minLength": 1,
      ///"maxLength": 2,
      ///"pattern": "^(?!0+$)([0-9]{1,2})$",
      ///"description": "State Code of the supplier. Refer the master"
      /// </summary>
      public string Stcd { get; set; }
  }
}
