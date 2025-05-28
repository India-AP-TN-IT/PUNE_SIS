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
    public partial class HR10005 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;
        public HR10005()
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


                Ax.SIS.HR.UI.HRCOMM_DLG dlg3 = new Ax.SIS.HR.UI.HRCOMM_DLG("STATE", "STATE Name", "", "");
                dlg3.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                dlg3.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                dlg3.HEUserParameterSetValue("VENDCD", UserInfo.Vendcd);
                dlg3.HEUserParameterSetValue("TY", "D");
                dlg3.HEUserParameterSetValue("CD", "");
                dlg3.HEUserParameterSetValue("NM", "");

                this.cdx01_NATIVE.HEPopupHelper = dlg3;
                this.cdx01_NATIVE.PopupTitle = "STATE List";

            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            base.BtnReset_Click(sender, e);
            ResetRight();
        }

        private void ResetRight()
        {
            Txt_VENDCD.SetValue("");
            Txt_VENDNM.SetValue("");
            Txt_COMADDR.SetValue("");
            Txt_CAPA.SetValue("");
            cdx01_NATIVE.SetValue("");
            Txt_GST.SetValue("");
            Txt_OWNER.SetValue("");
            Txt_PAN.SetValue("");
            Txt_ZIP.SetValue("");
            axDateEdit1.SetValue(DateTime.Now);
            axDateEdit2.SetValue(DateTime.Now);

        }
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            base.BtnQuery_Click(sender, e);
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());

                set.Add("VENDCD", axTextBox1.GetValue());
                set.Add("VENDNM", axTextBox2.GetValue());
                DataSet ds = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_HR10005", "INQUERY"), set);

                grd01.SetValue(ds);
            }
            catch(Exception eLog)
            {
                MsgBox.Show(eLog.ToString());
            }
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            base.BtnSave_Click(sender, e);
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());

                set.Add("VENDCD", Txt_VENDCD.GetValue());
                set.Add("VENDNM", Txt_VENDNM.GetValue());
                set.Add("AREACD", cdx01_NATIVE.GetValue());
                set.Add("ZIPCD", Txt_ZIP.GetValue());
                set.Add("ADDRESS", Txt_COMADDR.GetValue());
                set.Add("CAPACITY", Txt_CAPA.GetValue());
                set.Add("OWNER", Txt_OWNER.GetValue());
                set.Add("PANNO", Txt_PAN.GetValue());
                set.Add("GSTNO", Txt_GST.GetValue());
                set.Add("EST_DATE", axDateEdit1.GetDateText());
                set.Add("ST_DATE", axDateEdit2.GetDateText());
                set.Add("ED_DATE", "");
                set.Add("DEL_YN", "N");

                DataTable dt= _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_HR10005", "SAVE"), set).Tables[0];

                if(dt.Rows.Count>0)
                {
                    Txt_VENDCD.SetValue(dt.Rows[0]["VENDCD"].ToString());
                }
                else
                {
                    Txt_VENDCD.SetValue("");
                }
                BtnQuery_Click(null, null);

            }
            catch(Exception eLog)
            {
                MsgBox.Show(eLog.ToString());
            }
        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(grd01.Row >0)
            {
                ResetRight();
                Txt_VENDCD.SetValue(grd01.GetValue(grd01.Row, "VENDCD").ToString());
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());

                set.Add("VENDCD", Txt_VENDCD.Text);
                set.Add("VENDNM", "");
                DataTable dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_HR10005", "INQUERY"), set).Tables[0];

                if(dt.Rows.Count>0)
                {
                    Txt_VENDNM.SetValue(dt.Rows[0]["VENDNM"].ToString());
                    Txt_COMADDR.SetValue(dt.Rows[0]["ADDRESS"].ToString());
                    Txt_ZIP.SetValue(dt.Rows[0]["ZIPCD"].ToString());
                    cdx01_NATIVE.SetValue(dt.Rows[0]["AREACD"].ToString());
                    Txt_CAPA.SetValue(dt.Rows[0]["CAPACITY"].ToString());
                    Txt_OWNER.SetValue(dt.Rows[0]["OWNER"].ToString());
                    Txt_PAN.SetValue(dt.Rows[0]["PANNO"].ToString());
                    Txt_GST.SetValue(dt.Rows[0]["GSTNO"].ToString());
                    axDateEdit1.SetValue(dt.Rows[0]["EST_DATE"].ToString());
                    axDateEdit2.SetValue(dt.Rows[0]["ST_DATE"].ToString());
                }
            }
        }
        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            base.BtnDelete_Click(sender, e);
            if(string.IsNullOrEmpty(Txt_VENDCD.GetValue().ToString()))
            {
                MsgBox.Show("You didn't select the vendor!!", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (MsgBox.Show("Do you want to remove [" + Txt_VENDCD.GetValue().ToString() + "]?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", cbo01_BIZCD.GetValue());

                    set.Add("VENDCD", Txt_VENDCD.Text);
                    set.Add("DEL_YN", "Y");
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", "ZPG_HR10005", "REMOVE"), set);
                    ResetRight();
                    BtnQuery_Click(null, null);
                }
            }
        }

        private void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if(char.IsDigit(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }
    }
}
