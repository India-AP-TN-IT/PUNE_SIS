using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.HR.UI
{
    public partial class HR10020 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;
        public HR10020()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "VENDOR", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 185, "VENDOR Name", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "EMP NO.", "EMPNO", "EMPNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 185, "EMP Name", "EMPNM", "EMPNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "DOJ", "DOJ", "DOJ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "SCAN DATE", "SCAN_DATE", "SCAN_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "CATEGORY", "SKNM", "SKNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "TEL", "TEL1", "TEL1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "Aadhar No", "AADHNO", "AADHNO");

                Ax.SIS.HR.UI.HRCOMM_DLG dlg = new Ax.SIS.HR.UI.HRCOMM_DLG("Vendor", "Vendor Name", "", "");
                dlg.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                dlg.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                dlg.HEUserParameterSetValue("VENDCD", UserInfo.Vendcd);
                dlg.HEUserParameterSetValue("TY", "V");
                dlg.HEUserParameterSetValue("CD", "");
                dlg.HEUserParameterSetValue("NM", "");

                this.cdx01_VENDCD.HEPopupHelper = dlg;

                this.cdx01_VENDCD.PopupTitle = "Vendor List";
                this.cdx01_VENDCD.SetValue(UserInfo.Vendcd);


                Ax.SIS.HR.UI.HRCOMM_DLG dlg2 = new Ax.SIS.HR.UI.HRCOMM_DLG("EMP", "EMP Name", "", "");
                dlg2.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                dlg2.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                dlg2.HEUserParameterSetValue("VENDCD", UserInfo.Vendcd);
                dlg2.HEUserParameterSetValue("TY", "E");
                dlg2.HEUserParameterSetValue("CD", "");
                dlg2.HEUserParameterSetValue("NM", "");

                this.cdx01_EMPNO.HEPopupHelper = dlg2;
                this.cdx01_EMPNO.PopupTitle = "Employee List";

                Ax.SIS.HR.UI.HRCOMM_DLG dlg4 = new Ax.SIS.HR.UI.HRCOMM_DLG("SKILL", "SKILL Name", "", "");
                dlg4.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                dlg4.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                dlg4.HEUserParameterSetValue("VENDCD", UserInfo.Vendcd);
                dlg4.HEUserParameterSetValue("TY", "S");
                dlg4.HEUserParameterSetValue("CD", "");
                dlg4.HEUserParameterSetValue("NM", "");

                this.cdx01_CATEGORY.HEPopupHelper = dlg4;
                this.cdx01_CATEGORY.PopupTitle = "Skill List";

                if (string.IsNullOrEmpty(UserInfo.Vendcd) == false)
                {
                    this.cdx01_VENDCD.SetReadOnly(true);
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        private bool HasEmpVendor()
        {
            if (string.IsNullOrEmpty(((Ax.SIS.HR.UI.HRCOMM_DLG)this.cdx01_EMPNO.HEPopupHelper).HEUserParameterGetValue("VENDCD").ToString()))
            {
                return false;
            }
            return true;
        }
        private string GetTY()
        {
            if (axRadioButton1.Checked)
            {
                return "A";
            }
            else if (axRadioButton2.Checked)
            {
                return "L";
            }
            else if (axRadioButton3.Checked)
            {
                return "M";
            }
            else if (axRadioButton4.Checked)
            {
                return "O";
            }
            return "N";
        }
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            base.BtnQuery_Click(sender, e);
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("DATE", Dat_DOJ.GetDateText());
                set.Add("TY", GetTY());
                set.Add("VENDCD", cdx01_VENDCD.GetValue());
                set.Add("EMPNO", cdx01_EMPNO.GetValue());
                set.Add("CATEGORY", cdx01_CATEGORY.GetValue());
                DataSet ds = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_HR10020", "INQUERY"), set);

                grd01.SetValue(ds);
            }
            catch (Exception eLog)
            {
                MsgBox.Show(eLog.ToString());
            }
        }

    }
}
