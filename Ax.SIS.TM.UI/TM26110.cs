using System;
using System.Data;
using System.ServiceModel;

using System.Drawing;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using Ax.DEV.Utility.Library;
using HE.Framework.Core.Report;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;


namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class TM26110 : AxCommonBaseControl
    {
        private string m_OTP = "";
        private AxClientProxy _WSCOM;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private const string _IntFormat = "###,###,###,###,##0";
        private bool m_bDel = false;
        private const int COUNT_OF_FILES = 5;//2019.04.16
        public struct fileST
        {
            public byte[] file;
            public string ext;
        }
        private Dictionary<string, fileST> m_dicFiles = new Dictionary<string, fileST>();
        public TM26110()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }
        private void ResetFiles()
        {
            m_dicFiles = new Dictionary<string, fileST>();
            for(int i=0;i<COUNT_OF_FILES;i++)
            {
                fileST fileData = new fileST();
                fileData.file = null;
                fileData.ext = "";
                m_dicFiles.Add("CON_FILE" + (i + 1).ToString().PadLeft(2, '0'), fileData);
            }

        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                Txt_Status.SetValue("S");
                //CORCD
                cbo01_CORCD.DataBind_CORCD();
                cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                cbo01_CORCD.SetReadOnly(true);
                //BIZCD
                cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;

                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;

                ResetFiles();
                DispDownBtn();

                CD_Drafter.HEPopupHelper = new TM26110_DLG("", "Member No.", "Member Name", "", "");
                this.CD_Drafter.PopupTitle = "Mebmer List";
                this.CD_Drafter.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                this.CD_Drafter.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                this.CD_Drafter.CodeParameterName = "CD";
                this.CD_Drafter.NameParameterName = "NM";
                this.CD_Drafter.HEPopupHelper.Initialize_Helper(CD_Drafter);


                axCodeBox2.HEPopupHelper = new TM26110_DLG("", "Member No.", "Member Name", "", "");
                this.axCodeBox2.PopupTitle = "Mebmer List";
                this.axCodeBox2.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                this.axCodeBox2.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                this.axCodeBox2.CodeParameterName = "CD";
                this.axCodeBox2.NameParameterName = "NM";
                this.axCodeBox2.HEPopupHelper.Initialize_Helper(axCodeBox2);
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "Construction No.", "CONCD", "CONCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "Construction Name", "CONNM", "CONNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "Construction Place", "CONPLACE", "CONPLACE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 50, "STATUS", "STATUS", "STATUS");

                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "BIZCD", "BIZCD", "BIZCD");

                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "DRAFTER", "DRAFTER", "DRAFTER");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");


                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 48, "SEQ", "SEQ", "SEQ");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 48, "SEQ", "ORD_SEQ", "ORD_SEQ");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 158, "MID", "MID", "MID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 188, "NAME", "NAME", "NAME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 65, "STATUS", "CONFIRM", "CONFIRM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "C/Date", "CON_DATE", "CON_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "CON_DATE");

                DispApprovalLine();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #region [공통버튼]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

               

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("CONCD", axTextBox4.GetValue());
                set.Add("CONNM", axTextBox5.GetValue());
                set.Add("ST_DATE", axDateEdit3.GetDateText());
               
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_TM26110.GET_DATA", set, "OUT_CURSOR");

                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
                
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }
        
        
        #endregion

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            if(grd01.Rows.Count>1)
            {
                string corcd = grd01.GetValue(grd01.Row, "CORCD").ToString();
                string bizcd = grd01.GetValue(grd01.Row, "BIZCD").ToString();
                string concd = grd01.GetValue(grd01.Row, "CONCD").ToString();
                ShowDetData(corcd, bizcd, concd);
            }
            
        }
        private void ShowDetData(string corcd, string bizcd, string concd)
        {
            
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);
            set.Add("CONCD", concd);

            DataTable dt = _WSCOM.ExecuteDataSet("APG_TM26100.GET_DATA_DET", set, "OUT_CURSOR").Tables[0];
            if (dt.Rows.Count > 0)
            {

                Txt_CONNM.SetValue(dt.Rows[0]["CONNM"].ToString());
                Txt_CONCD.SetValue(dt.Rows[0]["CONCD"].ToString());
                Txt_CONPLACE.SetValue(dt.Rows[0]["CONPLACE"].ToString());
                Dat_ST_DATE.SetValue(dt.Rows[0]["ST_DATE"].ToString());
                Dat_ED_DATE.SetValue(dt.Rows[0]["ED_DATE"].ToString());

                Txt_Status.SetValue(dt.Rows[0]["STATUS"].ToString());
                CD_Drafter.SetValue(dt.Rows[0]["DRAFTER"].ToString());
                for (int i = 0; i < COUNT_OF_FILES; i++)
                {
                    fileST file = new fileST();
                    var conFile = dt.Rows[0]["CON_FILE" + (i + 1).ToString().PadLeft(2, '0')];
                    file.file = conFile != DBNull.Value ? (byte[])conFile : null;
                    file.ext = dt.Rows[0]["FILE_EXT" + (i + 1).ToString().PadLeft(2, '0')].ToString();
                    m_dicFiles["CON_FILE" + (i + 1).ToString().PadLeft(2, '0')] = file;


                }
                DispDownBtn();
                DispApprLine(corcd, bizcd, concd);
            }
            DispApprovalLine();
        }
        private void DispApprovalLine()
        {
            if( grd01.Rows.Fixed <grd01.Rows.Count)
            {
                if(string.IsNullOrEmpty(Txt_CONCD.GetValue().ToString()))
                {
                    groupBox2.Enabled = false;
                }
                else
                {
                    string status = Txt_Status.GetValue().ToString();
                    if (status == "S")
                    {
                        groupBox2.Enabled = true;
                        axButton1.Enabled = true;
                        Btn_Approve.Enabled = true;
                        Btn_Deny.Enabled = true; 
                    }
                    else if (status == "P")
                    {
                        groupBox2.Enabled = false;
                        axButton1.Enabled = false;
                        Btn_Approve.Enabled = true;
                        Btn_Deny.Enabled = true; 
                    }
                    else
                    {
                        groupBox2.Enabled = false;
                        axButton1.Enabled = false;
                        Btn_Approve.Enabled = false;
                        Btn_Deny.Enabled = false; 
                    }
                }
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }
        private void DispDownBtn()
        {
            Btn_DON_FILE01.Visible = false;
            Btn_DON_FILE02.Visible = false;
            Btn_DON_FILE03.Visible = false;
            Btn_DON_FILE04.Visible = false;
            Btn_DON_FILE05.Visible = false;
            for(int i=0;i<COUNT_OF_FILES;i++)
            {
                string key = "CON_FILE" + (i + 1).ToString().PadLeft(2, '0');
                if(m_dicFiles.ContainsKey(key))
                {
                    if(string.IsNullOrEmpty(m_dicFiles[key].ext) == false)
                    {
                        if (i == 0)
                        {
                            Btn_DON_FILE01.Visible = true;
                        }
                        else if(i==1)
                        {
                            Btn_DON_FILE02.Visible = true;
                        }
                        else if (i == 2)
                        {
                            Btn_DON_FILE03.Visible = true;
                        }
                        else if (i == 3)
                        {
                            Btn_DON_FILE04.Visible = true;
                        }
                        else if (i == 4)
                        {
                            Btn_DON_FILE05.Visible = true;
                        }
                    }
                }
            }
        }
        private DataTable PrintData()
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", cbo01_CORCD.GetValue());
            set.Add("BIZCD", cbo01_BIZCD.GetValue());
            set.Add("CONCD", Txt_CONCD.GetValue());


            DataTable source = _WSCOM.ExecuteDataSet("APG_TM26110.GET_PRINT", set, "OUT_CURSOR").Tables[0];
            return source;
        }
        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if(Txt_Status.GetValue().ToString() != "C")
                {
                    MsgBox.Show("Incomplete Approval Data!!");
                    return;
                }
                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = @"RPT/TM26110";

               
                DataTable dtRpt = new DataTable("DATA");
                dtRpt = PrintData();



                // Main section(메인리포트 파라미터 셋)
                HERexSection main_section = new HERexSection();
                main_section.ReportParameter.Add("RPT_TITLE", "The Contents of WareHouse");
                main_section.ReportParameter.Add("EMP_NO", this.UserInfo.EmpNo);
                main_section.ReportParameter.Add("EMP_NAME", this.UserInfo.UserName);
                report.Sections.Add("MAIN", main_section);

                HERexSection xml_section = new HERexSection(dtRpt.DataSet, new HEParameterSet());
                report.Sections.Add("XML1", xml_section);//레포트파일의 커넥션이름과동일해야함.
                AxRexpertReportViewer.ShowReport(report);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }
        private void Btn_SaveClick(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    string name = ((Button)sender).Name;
                    byte[] filebyte = null;
                    string fileName = "";
                    if (name.Contains("FILE01"))
                    {


                        filebyte = m_dicFiles["CON_FILE01"].file;
                        fileName = folder.SelectedPath+"\\"+ m_dicFiles["CON_FILE01"].ext;
                        
                    }
                    else if (name.Contains("FILE02"))
                    {
                        filebyte = m_dicFiles["CON_FILE02"].file;
                        fileName = folder.SelectedPath + "\\" + m_dicFiles["CON_FILE02"].ext;
                    }
                    else if (name.Contains("FILE03"))
                    {
                        filebyte = m_dicFiles["CON_FILE03"].file;
                        fileName = folder.SelectedPath + "\\" + m_dicFiles["CON_FILE03"].ext;
                    }
                    else if (name.Contains("FILE04"))
                    {
                        filebyte = m_dicFiles["CON_FILE04"].file;
                        fileName = folder.SelectedPath + "\\" + m_dicFiles["CON_FILE04"].ext;
                    }
                    else if (name.Contains("FILE05"))
                    {
                        filebyte = m_dicFiles["CON_FILE05"].file;
                        fileName = folder.SelectedPath + "\\" + m_dicFiles["CON_FILE05"].ext;
                    }

                    int ArraySize = filebyte.GetUpperBound(0);
                    FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                    stream.Write(filebyte, 0, ArraySize + 1);
                    stream.Close();

                    Process.Start(fileName, null);
                }
            }
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            CD_Drafter.HEPopupHelper = new TM26110_DLG("", "Member No.", "Member Name", "", "");
            this.CD_Drafter.PopupTitle = "Mebmer List";
            this.CD_Drafter.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
            this.CD_Drafter.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
            this.CD_Drafter.CodeParameterName = "CD";
            this.CD_Drafter.NameParameterName = "NM";
            this.CD_Drafter.HEPopupHelper.Initialize_Helper(CD_Drafter);


            axCodeBox2.HEPopupHelper = new TM26110_DLG("", "Member No.", "Member Name", "", "");
            this.axCodeBox2.PopupTitle = "Mebmer List";
            this.axCodeBox2.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
            this.axCodeBox2.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
            this.axCodeBox2.CodeParameterName = "CD";
            this.axCodeBox2.NameParameterName = "NM";
            this.axCodeBox2.HEPopupHelper.Initialize_Helper(axCodeBox2);
        }

        private void axButton2_Click(object sender, EventArgs e)
        {
            string addMember = axCodeBox2.GetValue().ToString();
            string drafter = CD_Drafter.GetValue().ToString();
            string concd = Txt_CONCD.GetValue().ToString();
            if (string.IsNullOrEmpty(drafter))
            {
                MsgBox.Show("Drafter is mandatory!!");
                return;
            }
            else if (string.IsNullOrEmpty(addMember))
            {
                MsgBox.Show("Member is mandatory!!");
                return;
            }
            else if (drafter == addMember)
            {
                MsgBox.Show("Duplicated Approval Line!!");
                return;
            }
           
            if (grd02.Rows.Count > grd02.Rows.Fixed)
            {
                for (int row = grd02.Rows.Fixed; row < grd02.Rows.Count; row++)
                {
                    if (grd02.GetValue(row, "MID").ToString() == addMember)
                    {
                        MsgBox.Show("Duplicated Approval Line!!");
                        return;
                    }
                }
            }
          
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", UserInfo.CorporationCode);
            set.Add("BIZCD", cbo01_BIZCD.GetValue());

            set.Add("CONCD", Txt_CONCD.GetValue());
            set.Add("DRAFT", CD_Drafter.GetValue());
            set.Add("MID", addMember);
            set.Add("UPDATE_ID", UserInfo.UserID);
            _WSCOM.ExecuteNonQueryTx("APG_TM26110.ADD_APPROV_LINE", set);


            DispApprLine(cbo01_CORCD.GetValue().ToString(), cbo01_BIZCD.GetValue().ToString(), Txt_CONCD.GetValue().ToString());
            axCodeBox2.SetValue("");
          
        }
        private void DispApprLine(string corcd, string bizcd, string concd)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);
            set.Add("CONCD", concd);
            DataSet ds = _WSCOM.ExecuteDataSetTx("APG_TM26110.GET_APPROV_LINE", set, "OUT_CURSOR");
            grd02.SetValue(ds);

            
        }

        private void UpdateSeq(string ty)
        {
            if (grd02.Row < grd02.Rows.Fixed)
            {
                MsgBox.Show("Select Approval Line!!");
                return;
            }
            else if (grd02.Rows.Count <= grd02.Rows.Fixed)
            {
                MsgBox.Show("No Approval Line!!");
                return;
            }
            string seq = grd02.GetValue(grd02.SelectedRowIndex, "SEQ").ToString();
            string ord_seq = grd02.GetValue(grd02.SelectedRowIndex, "ORD_SEQ").ToString();
            string last_seq = grd02.GetValue(grd02.Rows.Count - 1, "SEQ").ToString();
            if (ty == "UP")
            {
                if (ord_seq == "1")
                {
                    MsgBox.Show("It's Top Approval Line!!");
                    return;
                }
            }
            else if (ty == "DOWN")
            {

                if (seq == last_seq)
                {
                    MsgBox.Show("It's the lowest Approval Line!!");
                    return;
                }
            }

            string mid = grd02.GetValue(grd02.SelectedRowIndex, "MID").ToString();

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", cbo01_CORCD.GetValue());
            set.Add("BIZCD", cbo01_BIZCD.GetValue());

            set.Add("CONCD", Txt_CONCD.GetValue());
            set.Add("MID", mid);
            set.Add("CUR_SEQ", ord_seq);
            set.Add("TY", ty);
            _WSCOM.ExecuteNonQueryTx("APG_TM26110.UPDATE_APPROV_SEQ", set);


            DispApprLine(cbo01_CORCD.GetValue().ToString(), cbo01_BIZCD.GetValue().ToString(), Txt_CONCD.GetValue().ToString());
        }

        private void axButton11_Click(object sender, EventArgs e)
        {
            if (MsgBox.Show("Do you want to remove data?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UpdateSeq("X");
            }
        }

        private void axButton3_Click(object sender, EventArgs e)
        {
            UpdateSeq("UP");
        }

        private void axButton4_Click(object sender, EventArgs e)
        {
            UpdateSeq("DOWN");
        }

        private void axButton1_Click(object sender, EventArgs e)
        {
            string drafter = CD_Drafter.GetValue().ToString();
            string status = Txt_Status.GetValue().ToString();
            if (string.IsNullOrEmpty(drafter))
            {
                MsgBox.Show("Drafter is mandatory!!");
                return;
            }

            SaveDoc(drafter, status);
            BtnQuery_Click(null, null);
        }
        private void SaveDoc(string drafter, string status)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", cbo01_CORCD.GetValue());
            set.Add("BIZCD", cbo01_BIZCD.GetValue());

            set.Add("CONCD", Txt_CONCD.GetValue());

            set.Add("DRAFT", drafter);
            set.Add("STATUS", status);
            set.Add("UPDATE_ID", UserInfo.UserID);
            _WSCOM.ExecuteNonQueryTx("APG_TM26110.SAVE_DOC", set);
        }
        private void UpdateApproval(string status)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", cbo01_CORCD.GetValue());
            set.Add("BIZCD", cbo01_BIZCD.GetValue());
            set.Add("CONCD", Txt_CONCD.GetValue());
            set.Add("STATUS", status);
            _WSCOM.ExecuteNonQueryTx("APG_TM26110.UPDATE_NEXT_APPROVAL", set);
        }
        private void ShowOTP(string corcd, string bizcd, string mid)
        {
            m_OTP = "";
            Pan_OTP.Visible = true;
            Lbl_Turn.Text = "";
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);

            set.Add("MID", mid);

            DataTable dt = _WSCOM.ExecuteDataSetTx("APG_TM26110.SEND_OTP_RTN", set, "OUT_CURSOR").Tables[0];

            if (dt.Rows.Count > 0)
            {
                m_OTP = dt.Rows[0]["OTP"].ToString();
                Lbl_Turn.Text = dt.Rows[0]["NAME"].ToString();
            }
        }

        private void axButton7_Click(object sender, EventArgs e)
        {
            string drafter = CD_Drafter.GetValue().ToString();
            string status = Txt_Status.GetValue().ToString();
            if (string.IsNullOrEmpty(drafter))
            {
                MsgBox.Show("Drafter is mandatory!!");
                return;
            }
            else
            {
                SaveDoc(drafter, status);
            }
            if(grd02.Rows.Count <=grd02.Rows.Fixed)
            {
                MsgBox.Show("There is no Approval Line!!");
                return;
            }
            if (Pan_OTP.Visible == false)
            {
                if (Txt_Status.GetValue().ToString() == "S")
                {
                    ShowOTP(UserInfo.CorporationCode, cbo01_BIZCD.GetValue().ToString(), CD_Drafter.GetValue().ToString());
                    m_bDel = false;
                }
                else if (Txt_Status.GetValue().ToString() == "P")
                {
                    string mid = GetDetMID();
                    if (string.IsNullOrEmpty(mid) == false)
                    {
                        ShowOTP(UserInfo.CorporationCode, cbo01_BIZCD.GetValue().ToString(), mid);
                        m_bDel = false;
                    }
                    else
                    {
                        MsgBox.Show("Wrong Approval Line!!");
                        return;
                    }
                }
            }
        }


        private string GetDetMID()
        {
            string mid = "";
            for (int row = grd02.Rows.Fixed; row < grd02.Rows.Count; row++)
            {
                if (grd02.GetValue(row, "CONFIRM").ToString() == "P")
                {
                    mid = grd02.GetValue(row, "MID").ToString();
                }
            }
            return mid;
        }

        private void axButton10_Click(object sender, EventArgs e)
        {
            string txtOTP = axTextBox1.GetValue().ToString();
            axTextBox1.SetValue("");
            string txtStatus = Txt_Status.GetValue().ToString();
            if (string.IsNullOrEmpty(txtOTP))
            {
                MsgBox.Show("Empty OTP is not allowed!!");
                return;
            }
            if (txtOTP == m_OTP && txtStatus == "S")
            {
                Pan_OTP.Visible = false;
                SaveDoc(CD_Drafter.GetValue().ToString(), "P");
                Txt_Status.SetValue("P");
                if (m_bDel)
                {
                    UpdateApproval("X");
                }
                else
                {
                    UpdateApproval("S");
                }
                
            }
            else if (txtOTP == m_OTP && txtStatus == "P")
            {
                Pan_OTP.Visible = false;
                if (m_bDel)
                {
                    UpdateApproval("X");
                }
                else
                {
                    UpdateApproval("P");
                }
                
            }
            BtnQuery_Click(null, null);
            ShowDetData(cbo01_CORCD.GetValue().ToString(), cbo01_BIZCD.GetValue().ToString(), Txt_CONCD.GetValue().ToString());
        }

        private void Btn_Deny_Click(object sender, EventArgs e)
        {
            if (grd02.Rows.Count <= grd02.Rows.Fixed)
            {
                MsgBox.Show("There is no Approval Line!!");
                return;
            }
            if (Pan_OTP.Visible == false)
            {
                if (Txt_Status.GetValue().ToString() == "S")
                {
                    ShowOTP(UserInfo.CorporationCode, cbo01_BIZCD.GetValue().ToString(), CD_Drafter.GetValue().ToString());
                    m_bDel = true;
                }
                else if (Txt_Status.GetValue().ToString() == "P")
                {
                    string mid = GetDetMID();
                    if (string.IsNullOrEmpty(mid) == false)
                    {
                        ShowOTP(UserInfo.CorporationCode, cbo01_BIZCD.GetValue().ToString(), mid);
                        m_bDel = true;
                    }
                    else
                    {
                        MsgBox.Show("Wrong Approval Line!!");
                        return;
                    }
                }
            }
        }

    }
}
