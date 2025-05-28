#region ▶ Description & History
/* 
 * 프로그램명 : PD40520 금형투입이력 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
 *				
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using System.Drawing;
using System.IO;

namespace Ax.SIS.QA.QA09.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class ZQA40160 : AxCommonBaseControl
    {
        public struct SelectedST
        {
            public string vendcd;
            public string actno;
            public string eono;
            public string vincd;
        }
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_ZQA40160";
        private string m_OTP = "";
        private string m_Status = "";

        SelectedST m_selectedVal;

        private void ClearSelected()
        {
            m_selectedVal.actno = "";
            m_selectedVal.eono = "";
            m_selectedVal.vendcd = "";
            m_selectedVal.vincd = "";
        }
        #region [ 초기화 작업 정의 ]

        public ZQA40160()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                axTextBox1.SetValue("");
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));


                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1(this.cdx01_VENDCD);
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");// "업체 코드";
                this.cdx01_VINCD.HEPopupHelper = new Ax.SIS.CM.UI.CM30010P1("A3", true, true, this.cdx01_VINCD);
                this.cdx01_DOCCD.HEPopupHelper = new Ax.SIS.QA.QA09.UI.ZQA40150_DLG("EONO", "EO No.", "EO Name", "", "");
                this.cdx01_DOCCD.PopupTitle = "EO List";
                this.cdx01_DOCCD.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                this.cdx01_DOCCD.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                this.cdx01_DOCCD.CodeParameterName = "CD";
                this.cdx01_DOCCD.NameParameterName = "NM";
                this.cdx01_DOCCD.HEPopupHelper.Initialize_Helper(cdx01_DOCCD);


                axCodeBox3.HEPopupHelper = new Ax.SIS.QA.QA09.UI.ZQA40160_DLG("", "Member No.", "Member Name", "", "");
                this.axCodeBox3.PopupTitle = "Mebmer List";
                this.axCodeBox3.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                this.axCodeBox3.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                this.axCodeBox3.CodeParameterName = "CD";
                this.axCodeBox3.NameParameterName = "NM";
                this.axCodeBox3.HEPopupHelper.Initialize_Helper(axCodeBox3);


                axCodeBox2.HEPopupHelper = new Ax.SIS.QA.QA09.UI.ZQA40160_DLG("", "Member No.", "Member Name", "", "");
                this.axCodeBox2.PopupTitle = "Mebmer List";
                this.axCodeBox2.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                this.axCodeBox2.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                this.axCodeBox2.CodeParameterName = "CD";
                this.axCodeBox2.NameParameterName = "NM";
                this.axCodeBox2.HEPopupHelper.Initialize_Helper(axCodeBox2);
                

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 158, "VENDCD", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 158, "VENDOR", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "CAR", "VINNM", "VINNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "VINCD", "VINCD", "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PART No.", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 210, "PART Name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 210, "EONO", "EONO", "EONO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 45, "#1", "ISIR01", "ISIR01");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 45, "#2", "ISIR02", "ISIR02");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 45, "#3", "ISIR03", "ISIR03");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 45, "#4", "ISIR04", "ISIR04");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 45, "#5", "ISIR05", "ISIR05");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 45, "#6", "ISIR06", "ISIR06");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 45, "#7", "ISIR07", "ISIR07");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 45, "#8", "ISIR08", "ISIR08");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 45, "#1", "ISIR01_DOC", "ISIR01_DOC");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 45, "#2", "ISIR02_DOC", "ISIR02_DOC");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 45, "#3", "ISIR03_DOC", "ISIR03_DOC");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 45, "#4", "ISIR04_DOC", "ISIR04_DOC");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 45, "#5", "ISIR05_DOC", "ISIR05_DOC");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 45, "#6", "ISIR06_DOC", "ISIR06_DOC");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 45, "#7", "ISIR07_DOC", "ISIR07_DOC");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 45, "#8", "ISIR08_DOC", "ISIR08_DOC");


                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 48, "SEQ", "SEQ", "SEQ");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 48, "SEQ", "ORD_SEQ", "ORD_SEQ");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 158, "VENDCD", "VENDCD", "VENDCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 158, "VENDOR", "VENDNM", "VENDNM");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 158, "MID", "MID", "MID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 188, "NAME", "NAME", "NAME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 65, "STATUS", "CONFIRM", "CONFIRM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "C/Date", "CON_DATE", "CON_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "CON_DATE");

                this.grd03.AllowEditing = false;
                this.grd03.Initialize();
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 45, "SEQ", "SEQ", "SEQ");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "File Name", "FILE_NAME", "FILE_NAME");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 158, "FILE_OBJ", "FILE_OBJ", "FILE_OBJ");

                C1.Win.C1FlexGrid.CellStyle cStyle1 = grd01.Styles.Add("C_CELL");
                cStyle1.BackColor = Color.Lime;
                cStyle1.ForeColor = Color.Black;
                C1.Win.C1FlexGrid.CellStyle cStyle2 = grd01.Styles.Add("D_CELL");
                cStyle2.BackColor = Color.Silver;
                cStyle2.ForeColor = Color.Black;
                C1.Win.C1FlexGrid.CellStyle cStyle3 = grd01.Styles.Add("P_CELL");
                cStyle3.BackColor = Color.Yellow;
                cStyle3.ForeColor = Color.Black;

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]
        
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cdx01_DOCCD.GetValue().ToString()))
                {
                    MsgBox.Show("You have to select EO No.!!");
                    return;
                }
                else if (string.IsNullOrEmpty(cdx01_VINCD.GetValue().ToString()))
                {
                    MsgBox.Show("You have to select Car!!");
                    return;
                }
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);

                set.Add("VINCD", cdx01_VINCD.GetValue());
                set.Add("EONO", cdx01_DOCCD.GetValue());
                set.Add("VENDCD ", cdx01_VENDCD.GetValue());
                set.Add("PARTNO ", axTextBox1.GetValue());
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_DATA"), set, "OUT_CURSOR");
                grd01.SetValue(source);

                for (int row = grd01.Rows.Fixed; row < grd01.Rows.Count; row++)
                {
                    for (int i = 0; i < 8;i++ )
                    {
                        string colStatus = grd01.GetValue(row, "ISIR"+(i+1).ToString().PadLeft(2,'0')).ToString();
                        if(colStatus == "C" || colStatus == "D" || colStatus == "P")
                        {
                            int col = grd01.Cols["ISIR" + (i + 1).ToString().PadLeft(2, '0')].Index;
                            grd01.SetCellStyle(row, col, colStatus + "_CELL");
                        }
                        
                    }
                        
                }
                this.AfterInvokeServer();

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

        private void cdx01_VINCD_ValueChanged(object sender, EventArgs e)
        {
            if (cdx01_DOCCD.HEPopupHelper is Ax.SIS.QA.QA09.UI.ZQA40150_DLG)
            {
                ((Ax.SIS.QA.QA09.UI.ZQA40150_DLG)cdx01_DOCCD.HEPopupHelper).TY = cdx01_VINCD.GetValue().ToString();
            }
        }

        private void axButton9_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
        private string GetActivity(string corcd, string bizcd, string actno)
        {

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);

            set.Add("ACTNO", actno);
            DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_ACTIVITY"), set, "OUT_CURSOR");
            if(source.Tables.Count>0)
            {
                if(source.Tables[0].Rows.Count >0)
                {
                    return source.Tables[0].Rows[0]["ACTNO"].ToString() + ":" + source.Tables[0].Rows[0]["ACTNM"].ToString();
                }
            }
            return "";
        }
            
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            int row = grd01.SelectedRowIndex;
            int col = grd01.Col;
            if (row >= this.grd01.Rows.Fixed)
            {
                string actno = "";
                string colName = grd01.Cols[col].Name;
                
                switch (colName)
                {
                    case "ISIR01":
                        actno = "01";
                        break;
                    case "ISIR02":
                        actno = "02";
                        break;
                    case "ISIR03":
                        actno = "03";
                        break;
                    case "ISIR04":
                        actno = "04";
                        break;
                    case "ISIR05":
                        actno = "05";
                        break;
                    case "ISIR06":
                        actno = "06";
                        break;
                    case "ISIR07":
                        actno = "07";
                        break;
                    case "ISIR08":
                        actno = "08";
                        break;
                }
                if (string.IsNullOrEmpty(actno) == false)
                {

                    string vendcd = grd01.GetValue(row, "VENDCD").ToString();
                    string eono = grd01.GetValue(row, "EONO").ToString();
                    string vincd = grd01.GetValue(row, "VINCD").ToString();
                    string partno = grd01.GetValue(row, "PARTNO").ToString();
                    string status = grd01.GetValue(row, colName).ToString();
                    string corcd = grd01.GetValue(row, "CORCD").ToString();
                    string bizcd = grd01.GetValue(row, "BIZCD").ToString();
                    string isirno = grd01.GetValue(row, "ISIR" + actno + "_DOC").ToString();
                    DispDetDlg(corcd, bizcd, actno, vendcd, eono, vincd, partno, status, isirno);
                }
            }
        }

        private void DispDetDlg(string corcd, string bizcd, string actno, string vendcd, string eono, string vincd, string partno, string status, string isirno)
        {
            panel1.BringToFront();
            panel1.Visible = false;
            m_Status = "";
            ClearSelected();
            if (string.IsNullOrEmpty(actno) == false)
            {
                Lbl_Status.Text = status;
                m_selectedVal.actno = actno;
                m_selectedVal.vendcd = vendcd;
                m_selectedVal.eono = eono;
                m_selectedVal.vincd = vincd;
                axTextBox4.SetValue(GetActivity(corcd, bizcd, actno));
                axTextBox2.SetValue(partno);

                m_Status = status;
                panel1.Visible = true;
                tabControl1.SelectedIndex = 0;
                DispISIR(corcd, bizcd, isirno);

                DispApprLine(corcd, bizcd, isirno);
                DispFiles(corcd, bizcd, isirno);
                if(m_Status == "D" || m_Status == "-" || m_Status =="")
                {
                    panel3.Enabled = true;
                    Txt_CONT.ReadOnly = false;
                    Btn_FileAdd.Enabled = true;
                    Btn_FileRem.Enabled = true;
                    grd03.Enabled = true;
                }
                else
                {
                    panel3.Enabled = false;
                    Txt_CONT.ReadOnly = true;
                    Btn_FileAdd.Enabled = false;
                    Btn_FileRem.Enabled = false;
                    grd03.Enabled = true;
                }
            }

        }
        private void DispApprLine(string corcd, string bizcd, string isirno)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);
            set.Add("ISIRNO", isirno);
            DataSet ds = _WSCOM_N.ExecuteDataSetTx(string.Format("{0}.{1}", PACKAGE_NAME, "GET_APPROV_LINE"), set, "OUT_CURSOR");
            grd02.SetValue(ds);
        }

        private void DispISIR(string corcd, string bizcd, string isirno)
        {
            ClearISIR();
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);
            set.Add("ISIRNO", isirno);
            DataTable dt = _WSCOM_N.ExecuteDataSetTx(string.Format("{0}.{1}", PACKAGE_NAME, "GET_ISIR"), set, "OUT_CURSOR").Tables[0];

            if(dt.Rows.Count>0)
            {
                Txt_PartNo.SetValue(dt.Rows[0]["PARTNM"].ToString());
                Txt_ISIRNO.SetValue(isirno);
                axCodeBox3.SetValue(dt.Rows[0]["DRAFTER"].ToString());
                Txt_CONT.Text = dt.Rows[0]["CONT"].ToString();
            }
            
        }
        private void DispFiles(string corcd, string bizcd, string isirno)
        {
           
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);
            set.Add("ISIRNO", isirno);
            DataSet ds = _WSCOM_N.ExecuteDataSetTx(string.Format("{0}.{1}", PACKAGE_NAME, "GET_FILE_DATA"), set, "OUT_CURSOR");
            grd03.SetValue(ds);

        }

        private void ClearISIR()
        {
            Txt_ISIRNO.SetValue("");
            axCodeBox3.SetValue("");
            axCodeBox2.SetValue("");
            Txt_CONT.Text = "";
            

        }
        private void SaveDataDoc(string approval)
        {
            string drafter = axCodeBox3.GetValue().ToString();
            if (string.IsNullOrEmpty(drafter))
            {
                MsgBox.Show("Drafter is mandatory!!");
                return;
            }
            string bizcd = cbo01_BIZCD.GetValue().ToString();
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", bizcd);
            set.Add("EONO", m_selectedVal.eono);
            set.Add("VINCD", m_selectedVal.vincd);
            set.Add("ISIRNO", Txt_ISIRNO.GetValue());
            set.Add("STATUS", m_Status);
            set.Add("APPROVAL", approval);
            set.Add("VENDCD", m_selectedVal.vendcd);
            set.Add("PARTNO", axTextBox2.GetValue());
            set.Add("ACTNO", m_selectedVal.actno);
            set.Add("DRAFTER", axCodeBox3.GetValue());
            set.Add("UDATE_ID", UserInfo.UserID);
            set.Add("CONT", Txt_CONT.Text);
            DataTable dt = _WSCOM_N.ExecuteDataSetTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_DATA_DOC"), set, "OUT_CURSOR").Tables[0];
            if (dt.Rows.Count > 0)
            {
                Txt_ISIRNO.SetValue(dt.Rows[0]["ISIRNO"].ToString());
            }
        }
        private void axButton1_Click(object sender, EventArgs e)
        {
            SaveDataDoc("");
            BtnQuery_Click(null, null);

        }

        private void ShowOTP(string corcd, string bizcd, string mid)
        {
            m_OTP = "";
            panel2.Visible = true;
            Lbl_Turn.Text = "";
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", corcd);
            set.Add("BIZCD", bizcd);

            set.Add("MID", mid);

            DataTable dt = _WSCOM_N.ExecuteDataSetTx("APG_ZQA40160.SEND_OTP_RTN", set, "OUT_CURSOR").Tables[0];

            if(dt.Rows.Count>0)
            {
                m_OTP = dt.Rows[0]["OTP"].ToString();
                Lbl_Turn.Text = dt.Rows[0]["NAME"].ToString();
            }
        }

        private void axButton10_Click(object sender, EventArgs e)
        {
            string txtOTP = axTextBox5.GetValue().ToString();
            axTextBox5.SetValue("");
            if(string.IsNullOrEmpty(txtOTP))
            {
                MsgBox.Show("Empty OTP is not allowed!!");
                return;
            }
            if(txtOTP == m_OTP && m_Status == "D")
            {
                panel2.Visible = false;
                panel1.Visible = false;
                SaveDataDoc(m_Status);
                m_Status = "P";
                BtnQuery_Click(null, null);
            }
            else if (txtOTP == m_OTP && m_Status == "P")
            {
                panel2.Visible = false;
                panel1.Visible = false;
                
                
                SetApprovalConfirm("C");
                SaveDataDoc(m_Status);
                m_Status = "P";
                BtnQuery_Click(null, null);
            }
            else if (txtOTP == m_OTP && m_Status == "X")
            {
                panel2.Visible = false;
                panel1.Visible = false;


                SetApprovalConfirm("X");
                SaveDataDoc(m_Status);
                
                BtnQuery_Click(null, null);
            }
             
        }
        private void SetApprovalConfirm(string ty)
        {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("MID", GetDetMID());
                set.Add("ISIRNO", Txt_ISIRNO.GetValue());
                set.Add("UPDATE_ID", UserInfo.UserID);
                set.Add("TY", ty);
                _WSCOM_N.ExecuteNonQueryTx("APG_ZQA40160.SET_CONFIRM", set);
            
                
        }
        private void axButton2_Click(object sender, EventArgs e)
        {
            string addMember = axCodeBox2.GetValue().ToString();
            string drafter = axCodeBox3.GetValue().ToString();
            string isirno = Txt_ISIRNO.GetValue().ToString();
            if(string.IsNullOrEmpty(drafter))
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
            if(string.IsNullOrEmpty(isirno))
            {
                SaveDataDoc("");
            }
            
            if(grd02.Rows.Count>grd02.Rows.Fixed)
            {
                for (int row = grd02.Rows.Fixed; row < grd02.Rows.Count; row++)
                {
                    if(grd02.GetValue(row, "MID").ToString()==addMember)
                    {
                        MsgBox.Show("Duplicated Approval Line!!");
                        return;
                    }
                }
            }

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", UserInfo.CorporationCode);
            set.Add("BIZCD", cbo01_BIZCD.GetValue());

            set.Add("ISIRNO", Txt_ISIRNO.GetValue());
            set.Add("MID", addMember);
            set.Add("UPDATE_ID", UserInfo.UserID);
            _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "ADD_APPROV_LINE"), set);


            DispApprLine(UserInfo.CorporationCode, cbo01_BIZCD.GetValue().ToString(), Txt_ISIRNO.GetValue().ToString());
            axCodeBox2.SetValue("");

        }

        private void axButton3_Click(object sender, EventArgs e)
        {
            UpdateSeq("UP");
        }

        private void UpdateSeq(string ty)
        {

            if (grd02.Rows.Count <= grd02.Rows.Fixed)
            {
                MsgBox.Show("No Approval Line!!");
                return;
            }
            string seq = grd02.GetValue(grd02.SelectedRowIndex, "SEQ").ToString();
            string ord_seq = grd02.GetValue(grd02.SelectedRowIndex, "ORD_SEQ").ToString();
            string last_seq =  grd02.GetValue(grd02.Rows.Count - 1, "SEQ").ToString();
            if(ty == "UP")
            {
                if (ord_seq == "1")
                {
                    MsgBox.Show("It's Top Approval Line!!");
                    return;
                }
            }
            else if(ty == "DOWN")
            {

                if (seq == last_seq)
                {
                    MsgBox.Show("It's the lowest Approval Line!!");
                    return;
                }
            }

            string mid = grd02.GetValue(grd02.SelectedRowIndex, "MID").ToString();
            
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", UserInfo.CorporationCode);
            set.Add("BIZCD", cbo01_BIZCD.GetValue());

            set.Add("ISIRNO", Txt_ISIRNO.GetValue());
            set.Add("MID", mid);
            set.Add("CUR_SEQ", ord_seq);
            set.Add("TY", ty);
            _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "UPDATE_APPROV_SEQ"), set);


            DispApprLine(UserInfo.CorporationCode, cbo01_BIZCD.GetValue().ToString(), Txt_ISIRNO.GetValue().ToString());
        }

        private void axButton4_Click(object sender, EventArgs e)
        {
            UpdateSeq("DOWN");
        }

        private void axButton11_Click(object sender, EventArgs e)
        {
            if(MsgBox.Show("Do you want to remove data?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                UpdateSeq("X");
            }

        }
        private void axButton5_Click(object sender, EventArgs e)
        {
            SaveDataFile("SAVE");
        }

        private void SaveDataFile(string ty)
        {
            try
            {
                string filename = "";
                byte[] obj = null;
                if (ty == "SAVE")
                {
                    DialogResult result = this.fileDlg.ShowDialog(this);

                    if (result == DialogResult.Cancel)
                        return;

                    filename = this.fileDlg.FileName;
                    if (File.Exists(filename) == false)
                    {
                        MsgBox.Show("Wrong File!!");
                        return;
                    }
                    obj = File.ReadAllBytes(filename);
                }

                

                //string extension = ((string[])filename.Split('.'))[filename.Split('.').Length - 1].ToUpper();
                //string endfilename = ((string[])filename.Split('\\'))[filename.Split('\\').Length - 1];
                if (string.IsNullOrEmpty(Txt_ISIRNO.GetValue().ToString()))
                {
                    SaveDataDoc("");
                }
                string seq = "";
                if (grd03.SelectedRowIndex >= grd03.Rows.Fixed)
                {
                    seq = grd03.GetValue(grd03.SelectedRowIndex, "SEQ").ToString();
                }
                if(ty == "DEL" && string.IsNullOrEmpty(seq))
                {
                    MsgBox.Show("There is no selection for removing!!");
                    return;
                }
                else if(ty == "DEL" && string.IsNullOrEmpty(seq) == false)
                {
                    if(MsgBox.Show("Do you want to remove selected file?", "Question", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }
                }
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("ISIRNO", Txt_ISIRNO.GetValue());
                set.Add("FILE_NAME", this.fileDlg.SafeFileName);
                set.Add("BLOB$FILE_OBJ", obj);
                set.Add("UPDATE_ID", UserInfo.UserID);
                set.Add("TY", ty);
                set.Add("SEQ", seq);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_DATA_FILE"), set);

                DispFiles(UserInfo.CorporationCode, cbo01_BIZCD.GetValue().ToString(), Txt_ISIRNO.GetValue().ToString());
                

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }


        private void axButton6_Click(object sender, EventArgs e)
        {
            SaveDataFile("DEL");
        }

        private void grd03_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = grd03.SelectedRowIndex;
            if(row >= grd03.Rows.Fixed)
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.FileName = grd03.GetValue(row, "FILE_NAME").ToString();

                DialogResult dlg= fileDialog.ShowDialog();
                if(dlg == DialogResult.OK)
                {
                    byte[] data = (byte[])grd03.GetValue(row, "FILE_OBJ");
                    FileStream stream = new FileStream(fileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    stream.Write(data, 0, data.Length);
                    stream.Close();
                }
                
                
            }
        }
        private string GetDetMID()
        {
            string mid = "";
            for(int row=grd02.Rows.Fixed;row<grd02.Rows.Count;row++)
            {
                if(grd02.GetValue(row, "CONFIRM").ToString() == "P")
                {
                    mid = grd02.GetValue(row, "MID").ToString();
                        
                }
            }
            return mid;
        }
        private void axButton7_Click(object sender, EventArgs e)
        {
            if (m_Status == "D")
            {
                ShowOTP(UserInfo.CorporationCode, cbo01_BIZCD.GetValue().ToString(), axCodeBox3.GetValue().ToString());                
            }
            else if(m_Status == "P")
            {
                string mid =GetDetMID();
                if(string.IsNullOrEmpty(mid) == false)
                {
                    ShowOTP(UserInfo.CorporationCode, cbo01_BIZCD.GetValue().ToString(), mid); 
                }
                else
                {
                    MsgBox.Show("Wrong Approval Line!!");
                    return;
                }
            }
            else if(m_Status == "X" || m_Status == "-" || m_Status =="")
            {
                SaveDataDoc("");
                m_Status = "D";
                ShowOTP(UserInfo.CorporationCode, cbo01_BIZCD.GetValue().ToString(), axCodeBox3.GetValue().ToString());         
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GoToISIRNO();

            
        }
        private void GoToISIRNO()
        {
            if(string.IsNullOrEmpty(axTextBox6.GetValue().ToString()))
            {
                MsgBox.Show("Empty ISIR No.!!");
                return;
            }
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", UserInfo.CorporationCode);
            set.Add("BIZCD", cbo01_BIZCD.GetValue());
            set.Add("ISIRNO", axTextBox6.GetValue());

            DataTable dt = _WSCOM_N.ExecuteDataSetTx(string.Format("{0}.{1}", PACKAGE_NAME, "GET_ISIR"), set, "OUT_CURSOR").Tables[0];
            if (dt.Rows.Count <= 0)
            {
                MsgBox.Show("There is no ISIR no.");
                return;
            }
            else
            {
                cdx01_VINCD.SetValue(dt.Rows[0]["VINCD"].ToString());
                cdx01_DOCCD.SetValue(dt.Rows[0]["EONO"].ToString());
                DispDetDlg(dt.Rows[0]["CORCD"].ToString()
                           , dt.Rows[0]["BIZCD"].ToString()
                           , dt.Rows[0]["ACTNO"].ToString()
                           , dt.Rows[0]["VENDCD"].ToString()
                           , dt.Rows[0]["EONO"].ToString()
                           , dt.Rows[0]["VINCD"].ToString()
                           , dt.Rows[0]["PARTNO"].ToString()
                           , dt.Rows[0]["STATUS"].ToString()
                           , dt.Rows[0]["ISIRNO"].ToString()
                        );
                axTextBox6.SetValue("");
            }
        }

        private void axTextBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                GoToISIRNO();
            }
        }

        private void axButton8_Click(object sender, EventArgs e)
        {
            if (m_Status == "P")
            {

                string mid = GetDetMID();
                if (string.IsNullOrEmpty(mid) == false)
                {
                    m_Status = "X";
                    ShowOTP(UserInfo.CorporationCode, cbo01_BIZCD.GetValue().ToString(), mid);
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


