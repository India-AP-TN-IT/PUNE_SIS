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

namespace Ax.SIS.QA.QA09.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class ZQA40150 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_ZQA40150";
        #region [ 초기화 작업 정의 ]

        public ZQA40150()
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

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 24, "C", "CHK", "CHK");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 50, "CAR", "VINNM", "VINNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "PART NAME", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 200, "VENDCD", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 200, "VINCD", "VINCD", "VINCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 200, "EONO", "EONO", "EONO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 200, "EO_BEG_DATE", "EO_BEG_DATE", "EO_BEG_DATE");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");                           //2019.04.16
                //전체 선택 체크박스.                                                                   //2019.04.16
                C1.Win.C1FlexGrid.CellStyle cs = this.grd01.Styles.Add("Boolean");                     //2019.04.16
                cs.DataType = typeof(Boolean);                                                         //2019.04.16
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;                         //2019.04.16
                this.grd01.SetCellStyle(0, this.grd01.Cols["CHK"].Index, cs);                          //2019.04.16


                this.grd02.AllowEditing = true;
                this.grd02.Initialize();
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 24, "C", "CHK", "CHK");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "PART NO", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "PART NAME", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 200, "VINCD", "VINCD", "VINCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 200, "EONO", "EONO", "EONO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 200, "VENDCD", "VENDCD", "VENDCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 200, "EO_BEG_DATE", "EO_BEG_DATE", "EO_BEG_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");                           //2019.04.16
                //전체 선택 체크박스.                                                                   //2019.04.16
                C1.Win.C1FlexGrid.CellStyle cs2 = this.grd02.Styles.Add("Boolean");                     //2019.04.16
                cs2.DataType = typeof(Boolean);                                                         //2019.04.16
                cs2.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;                         //2019.04.16
                this.grd02.SetCellStyle(0, this.grd02.Cols["CHK"].Index, cs);                          //2019.04.16

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
                if(string.IsNullOrEmpty(cdx01_VENDCD.GetValue().ToString()))
                {
                    MsgBox.Show("You have to select Vendor!!");
                    return;
                }
                else if (string.IsNullOrEmpty(cdx01_DOCCD.GetValue().ToString()))
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
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_LEFT"), set, "OUT_CURSOR");
                grd01.SetValue(source);

                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_RIGHT"), set, "OUT_CURSOR");
                grd02.SetValue(source);
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
            if(cdx01_DOCCD.HEPopupHelper is Ax.SIS.QA.QA09.UI.ZQA40150_DLG)
            {
                ((Ax.SIS.QA.QA09.UI.ZQA40150_DLG)cdx01_DOCCD.HEPopupHelper).TY = cdx01_VINCD.GetValue().ToString();
            }
        }

        private void axButton1_Click(object sender, EventArgs e)
        {
            if(grd01.Rows.Count<=1)
            {
                MsgBox.Show("There is no data to assign!!");
                return;
            }
            string bizcd = cbo01_BIZCD.GetValue().ToString();
            HEParameterSet set = new HEParameterSet();
            for(int row =1;row<grd01.Rows.Count;row++)
            {
                string check = grd01.GetValue(row, "CHK").ToString();
                if(check =="Y")
                {
                    set = new HEParameterSet();
                    set.Add("CORCD", grd01.GetValue(row, "CORCD"));
                    set.Add("BIZCD", grd01.GetValue(row, "BIZCD"));
                    set.Add("VINCD", grd01.GetValue(row, "VINCD"));
                    set.Add("EONO", grd01.GetValue(row, "EONO"));
                    set.Add("VENDCD", grd01.GetValue(row, "VENDCD"));
                    set.Add("PARTNO", grd01.GetValue(row, "PARTNO"));
                    set.Add("PARTNM", grd01.GetValue(row, "PARTNM"));
                    set.Add("EO_BEG_DATE", grd01.GetValue(row, "EO_BEG_DATE"));
                    set.Add("UPDATE_ID", this.UserInfo.UserID);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_RIGHT"), set);
                }
            }
            BtnQuery_Click(null, null);
            MsgBox.Show("Data was Saved!!");
        }

        private void axButton2_Click(object sender, EventArgs e)
        {
            if (grd02.Rows.Count <= 1)
            {
                MsgBox.Show("There is no data to assign!!");
                return;
            }
            string bizcd = cbo01_BIZCD.GetValue().ToString();
            HEParameterSet set = new HEParameterSet();
            for (int row = 1; row < grd02.Rows.Count; row++)
            {
                string check = grd02.GetValue(row, "CHK").ToString();
                if (check == "Y")
                {
                    set = new HEParameterSet();
                    set.Add("CORCD", grd02.GetValue(row, "CORCD"));
                    set.Add("BIZCD", grd02.GetValue(row, "BIZCD"));
                    set.Add("VINCD", grd02.GetValue(row, "VINCD"));
                    set.Add("EONO", grd02.GetValue(row, "EONO"));
                    set.Add("VENDCD", grd02.GetValue(row, "VENDCD"));
                    set.Add("PARTNO", grd02.GetValue(row, "PARTNO"));
                   
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DEL_RIGHT"), set);
                }
            }
            BtnQuery_Click(null, null);
        }

        private void grd01_MouseClick(object sender, MouseEventArgs e)
        {
            
            if (this.grd01.MouseCol == 1)
            {
                if (this.grd01.MouseRow == 0)
                {
                    string s_value = this.grd01.GetValue(0, "CHK").ToString();
                    for (int j_cnt = this.grd01.Rows.Fixed; j_cnt < this.grd01.Rows.Count; j_cnt++)
                    {
                        this.grd01.SetValue(j_cnt, "CHK", s_value == "Y" ? "1" : "0");
                    }
                }
                else
                {
                    //C1.Win.C1FlexGrid.CheckEnum e_all_check = this.grd01.GetCellCheck(0, IDX_CHECK_COLUMN);
                    //C1.Win.C1FlexGrid.CheckEnum e_sin_check = this.grd01.GetCellCheck(this.grd01.MouseRow, IDX_CHECK_COLUMN);
                    string s_all_check = this.grd01.GetValue(0, "CHK").ToString();
                    string s_single = this.grd01.GetValue(this.grd01.MouseRow, "CHK").ToString();
                    if (s_single != "Y" && s_all_check == "Y") this.grd01.SetValue(0, "CHK", "0");
                }
            }
        }

        private void grd02_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.grd02.MouseCol == 1)
            {
                if (this.grd02.MouseRow == 0)
                {
                    string s_value = this.grd02.GetValue(0, "CHK").ToString();
                    for (int j_cnt = this.grd02.Rows.Fixed; j_cnt < this.grd02.Rows.Count; j_cnt++)
                    {
                        this.grd02.SetValue(j_cnt, "CHK", s_value == "Y" ? "1" : "0");
                    }
                }
                else
                {
                    //C1.Win.C1FlexGrid.CheckEnum e_all_check = this.grd01.GetCellCheck(0, IDX_CHECK_COLUMN);
                    //C1.Win.C1FlexGrid.CheckEnum e_sin_check = this.grd01.GetCellCheck(this.grd01.MouseRow, IDX_CHECK_COLUMN);
                    string s_all_check = this.grd02.GetValue(0, "CHK").ToString();
                    string s_single = this.grd02.GetValue(this.grd02.MouseRow, "CHK").ToString();
                    if (s_single != "Y" && s_all_check == "Y") this.grd02.SetValue(0, "CHK", "0");
                }
            }
        }

        



    }
}

