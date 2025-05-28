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
using System.IO;
using HE.Framework.Core.Report;

namespace Ax.SIS.HR.UI
{
    public partial class HR10010 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;
        public HR10010()
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
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 60, "Vendor", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "EMP NO", "EMPNO", "EMPNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 185, "EMP Name", "EMPNM", "EMPNM");

                
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



                Ax.SIS.HR.UI.HRCOMM_DLG dlg3 = new Ax.SIS.HR.UI.HRCOMM_DLG("STATE", "STATE Name", "", "");
                dlg3.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                dlg3.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                dlg3.HEUserParameterSetValue("VENDCD", UserInfo.Vendcd);
                dlg3.HEUserParameterSetValue("TY", "D");
                dlg3.HEUserParameterSetValue("CD", "");
                dlg3.HEUserParameterSetValue("NM", "");

                this.cdx01_NATIVE.HEPopupHelper = dlg3;
                this.cdx01_NATIVE.PopupTitle = "STATE List";

                Ax.SIS.HR.UI.HRCOMM_DLG dlg4 = new Ax.SIS.HR.UI.HRCOMM_DLG("SKILL", "SKILL Name", "", "");
                dlg4.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                dlg4.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                dlg4.HEUserParameterSetValue("VENDCD", UserInfo.Vendcd);
                dlg4.HEUserParameterSetValue("TY", "S");
                dlg4.HEUserParameterSetValue("CD", "");
                dlg4.HEUserParameterSetValue("NM", "");

                this.cdx01_CATEGORY.HEPopupHelper = dlg4;
                this.cdx01_CATEGORY.PopupTitle = "Skill List";
                

                if(string.IsNullOrEmpty(UserInfo.Vendcd) == false)
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
            if(string.IsNullOrEmpty((( Ax.SIS.HR.UI.HRCOMM_DLG)this.cdx01_EMPNO.HEPopupHelper).HEUserParameterGetValue("VENDCD").ToString()))
            {
                return false;
            }
            return true;
        }
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            base.BtnReset_Click(sender, e);
            ResetRight();
        }
        
        private void ResetRight()
        {
            Txt_EMPNO.SetValue("");
            Txt_EMPNM.SetValue("");
            Txt_ADDR1.SetValue("");
            
            cdx01_NATIVE.SetValue("");
            Txt_AADHNO.SetValue("");
            
            Txt_PAN.SetValue("");
            cdx01_CATEGORY.SetValue("");
            Dat_DOJ.SetValue(DateTime.Now);
            Dat_DOB.SetValue(DateTime.Now);
            Txt_ADDR1.SetValue("");
            Txt_ADDR2.SetValue("");
            Txt_CONSTITUENCY.SetValue("");
            Txt_DISTRICT.SetValue("");
            Txt_QUALIFICATION.SetValue("");
            Txt_DEPARTMENT.SetValue("");
            Txt_TEL2.SetValue("");
            Txt_TEL1.SetValue("");
            RD_MALE.Checked = true;
            Txt_INSU.SetValue("");
            Txt_ESI.SetValue("");
            Txt_FANAME.SetValue("");
            Txt_MONAME.SetValue("");
            Txt_UAN.SetValue("");
            Txt_WINAME.SetValue("");
            Txt_IFSC.SetValue("");
            Txt_BANKNM.SetValue("");
            Txt_ACCNO.SetValue("");
            
        }
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            base.BtnQuery_Click(sender, e);
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());

                set.Add("VENDCD", cdx01_VENDCD.GetValue());
                set.Add("EMPNO", cdx01_EMPNO.GetValue());
                set.Add("EMPNM", "");
                DataSet ds = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_HR10010", "INQUERY"), set);

                grd01.SetValue(ds);
            }
            catch(Exception eLog)
            {
                MsgBox.Show(eLog.ToString());
            }
        }
        private string GetSex()
        {
            if(RD_MALE.Checked)
            {
                return "M";
            }
            else
            {
                return "F";
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

                set.Add("VENDCD", cdx01_VENDCD.GetValue());
                set.Add("EMPNO", Txt_EMPNO.GetValue());
                set.Add("EMPNM", Txt_EMPNM.GetValue());
                set.Add("SEX", GetSex());

                set.Add("QUALIFICATION", Txt_QUALIFICATION.GetValue());
                set.Add("DEPARTMENT", Txt_DEPARTMENT.GetValue());
                set.Add("CATEGORY", cdx01_CATEGORY.GetValue());
                set.Add("FANAME", Txt_FANAME.GetValue());
                set.Add("MONAME", Txt_MONAME.GetValue());
                set.Add("WINAME", Txt_WINAME.GetValue());
                set.Add("BLOB$EMPPIC", axPictureBox1.GetValue());
                set.Add("ADDR1", Txt_ADDR1.GetValue());
                set.Add("ADDR2", Txt_ADDR2.GetValue());
                set.Add("AADHNO", Txt_AADHNO.GetValue());
                set.Add("PANNO", Txt_PAN.GetValue());
                set.Add("ESINO", Txt_ESI.GetValue());
                set.Add("PFNO", "");
                set.Add("BIR_DATE", Dat_DOB.GetDateText());
                set.Add("JOIN_DATE", Dat_DOJ.GetDateText());
                set.Add("RESIGN_DATE", "");
                set.Add("NATIVE", cdx01_NATIVE.GetValue());
                set.Add("DISTRICT", Txt_DISTRICT.GetValue());
                set.Add("BANK_NAME", Txt_BANKNM.GetValue());
                set.Add("BANK_ACCOUNT", Txt_ACCNO.GetValue());
                set.Add("BANK_IFSC", Txt_IFSC.GetValue());
                set.Add("CONSTITUENCY", Txt_CONSTITUENCY.GetValue());
                set.Add("TEL1", Txt_TEL1.GetValue());
                set.Add("TEL2", Txt_TEL2.GetValue());
                set.Add("BLOODTYPE", GetBloodType());
                set.Add("UAN", Txt_UAN.GetValue());
                set.Add("INSURENO", Txt_INSU.GetValue());
                set.Add("DEL_YN", "N");

                DataTable dt= _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_HR10010", "SAVE"), set).Tables[0];

                if(dt.Rows.Count>0)
                {
                    Txt_EMPNO.SetValue(dt.Rows[0]["EMPNO"].ToString());
                }
                else
                {
                    Txt_EMPNO.SetValue("");
                }
                BtnQuery_Click(null, null);

            }
            catch(Exception eLog)
            {
                MsgBox.Show(eLog.ToString());
            }
        }
        private string GetBloodType()
        {
            if(RD_BT_A.Checked)
            {
                return "A";
            }
            else if(RD_BT_B.Checked)
            {
                return "B";
            }
            else if(RD_BT_O.Checked)
            {
                return "O";
            }
            else if (RD_BT_AB.Checked)
            {
                return "AB";
            }
            return "";
        }
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(grd01.Row >0)
            {
                ResetRight();
                string vendcd = grd01.GetValue(grd01.Row, "VENDCD").ToString();
                string empno = grd01.GetValue(grd01.Row, "EMPNO").ToString();
                
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());

                set.Add("VENDCD", vendcd);
                set.Add("EMPNO", empno);
                set.Add("EMPNM", "");
                DataTable dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_HR10010", "INQUERY"), set).Tables[0];

                if(dt.Rows.Count>0)
                {
                    Txt_EMPNO.SetValue(empno);
                    cdx01_VENDCD.SetValue(vendcd);
                    Txt_EMPNM.SetValue(dt.Rows[0]["EMPNM"].ToString());
                    Txt_ADDR1.SetValue(dt.Rows[0]["ADDR1"].ToString());
                    Txt_ADDR2.SetValue(dt.Rows[0]["ADDR2"].ToString());
                    cdx01_CATEGORY.SetValue(dt.Rows[0]["CATEGORY"].ToString());
                    cdx01_NATIVE.SetValue(dt.Rows[0]["NATIVE"].ToString());
                    Txt_PAN.SetValue(dt.Rows[0]["PANNO"].ToString());
                    Txt_AADHNO.SetValue(dt.Rows[0]["AADHNO"].ToString());
                    Dat_DOJ.SetValue(dt.Rows[0]["JOIN_DATE"].ToString());
                    Dat_DOB.SetValue(dt.Rows[0]["BIR_DATE"].ToString());
                    axPictureBox1.SetValue(dt.Rows[0]["EMPPIC"]);
                    DispBloodType(dt.Rows[0]["BLOODTYPE"].ToString());
                    DispSEX(dt.Rows[0]["SEX"].ToString());
                    Txt_DISTRICT.SetValue(dt.Rows[0]["DISTRICT"].ToString());
                    Txt_CONSTITUENCY.SetValue(dt.Rows[0]["CONSTITUENCY"].ToString());
                    Txt_TEL1.SetValue(dt.Rows[0]["TEL1"].ToString());
                    Txt_TEL2.SetValue(dt.Rows[0]["TEL2"].ToString());
                    Txt_QUALIFICATION.SetValue(dt.Rows[0]["QUALIFICATION"].ToString());
                    Txt_DEPARTMENT.SetValue(dt.Rows[0]["DEPARTMENT"].ToString());
                    Txt_IFSC.SetValue(dt.Rows[0]["BANK_IFSC"].ToString());
                    Txt_BANKNM.SetValue(dt.Rows[0]["BANK_NAME"].ToString());
                    Txt_ACCNO.SetValue(dt.Rows[0]["BANK_ACCOUNT"].ToString());
                    Txt_FANAME.SetValue(dt.Rows[0]["FANAME"].ToString());
                    Txt_MONAME.SetValue(dt.Rows[0]["MONAME"].ToString());
                    Txt_WINAME.SetValue(dt.Rows[0]["WINAME"].ToString());
                    Txt_INSU.SetValue(dt.Rows[0]["INSURENO"].ToString());
                    Txt_ESI.SetValue(dt.Rows[0]["ESINO"].ToString());
                    Txt_UAN.SetValue(dt.Rows[0]["UAN"].ToString());

                }
            }
        }
        private void DispBloodType(string data)
        {
            switch(data)
            {
                case "A":
                    RD_BT_A.Checked = true;
                    break;
                case "B":
                    RD_BT_B.Checked = true;
                    break;
                case "O":
                    RD_BT_O.Checked = true;
                    break;
                case "AB":
                    RD_BT_AB.Checked = true;
                    break;
            }
        }
        private void DispSEX(string data)
        {
            switch (data)
            {
                case "M":
                    RD_MALE.Checked = true;
                    break;
                case "F":
                    RD_FEMALE.Checked = true;
                    break;
            }
        }
        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            base.BtnPrint_Click(sender, e);

            try
            {
                if (string.IsNullOrEmpty(cdx01_VENDCD.GetValue().ToString()))
                {
                    MsgBox.Show("Select the Vendor", "Notice", MessageBoxButtons.OK, ImageKinds.Error);
                    return;
                }
                if (string.IsNullOrEmpty(Txt_EMPNO.GetValue().ToString()))
                {
                    MsgBox.Show("Select the Employee", "Notice", MessageBoxButtons.OK, ImageKinds.Error);
                    return;
                }
                
                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = "RPT/HR10010";

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());

                set.Add("VENDCD", cdx01_VENDCD.GetValue());
                set.Add("EMPNO", Txt_EMPNO.GetValue().ToString());
                set.Add("EMPNM", "");


                this.BeforeInvokeServer(true);
                DataSet ds = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "ZPG_HR10010", "INQUERY"), set, "OUT_CURSOR");
                this.AfterInvokeServer();
                HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());
               // ds.WriteXml("D:\\A\\HR10010.XML");
                report.Sections.Add("MAIN", xmlSection);

                AxRexpertReportViewer.ShowReport(report);

            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }

        }
        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            base.BtnDelete_Click(sender, e);
            if(string.IsNullOrEmpty(Txt_EMPNO.GetValue().ToString()))
            {
                MsgBox.Show("You didn't select the vendor!!", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (MsgBox.Show("Do you want to remove [" + Txt_EMPNO.GetValue().ToString() + "]?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", cbo01_BIZCD.GetValue());

                    set.Add("VENDCD", cdx01_VENDCD.GetValue().ToString());
                    set.Add("EMPNO", Txt_EMPNO.GetValue().ToString());
                    set.Add("DEL_YN", "Y");
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", "ZPG_HR10010", "REMOVE"), set);
                    ResetRight();
                    BtnQuery_Click(null, null);
                }
            }
        }

        private void cdx01_EMPNO_ButtonClickAfter(object sender, EventArgs args)
        {
            if(HasEmpVendor() == false)
            {
                MsgBox.Show("You didn't select the vendor!!", "Error", MessageBoxButtons.OK);
                return;
            }
        }

        private void cdx01_VENDCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            if (((Ax.SIS.HR.UI.HRCOMM_DLG)this.cdx01_EMPNO.HEPopupHelper) != null)
            {
                ((Ax.SIS.HR.UI.HRCOMM_DLG)this.cdx01_EMPNO.HEPopupHelper).HEUserParameterSetValue("VENDCD", cdx01_VENDCD.GetValue());
            }
        }

        private void axButton1_Click(object sender, EventArgs e)
        {
            FileStream fs = null;

            try
            {
                OpenFileDialog file = new OpenFileDialog();

                file.Filter = "Image files (jpg, gif, bmp, png)|*.jpg;*.gif;*.bmp;*.png";

                if (file.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(file.FileName, FileMode.OpenOrCreate, FileAccess.Read);

                    byte[] _PHOTO = new byte[(int)fs.Length];
                    fs.Read(_PHOTO, 0, _PHOTO.Length);
                    fs.Close();
                    axPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    axPictureBox1.SetValue(_PHOTO);
                }
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
        }
    }
}


