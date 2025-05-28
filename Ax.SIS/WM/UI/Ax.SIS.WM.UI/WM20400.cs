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

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class WM20400 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_WM20400";

        #region [ 초기화 작업 정의 ]

        public WM20400()
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

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 64, "TAX ID", "TAXID", "TAXID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 88, "DESCRIPTION", "TAXDESC", "TAXDESC");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "I/DEC", "INT_DEC", "INT_DEC");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "E/DEC", "EXT_DEC", "EXT_DEC");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "BEGIN DATE", "ST_DATE", "ST_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "END DATE", "ED_DATE", "ED_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "SEQ.", "SEQ", "SEQ");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "USE", "USE_YN", "USE_YN");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "ST_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "ED_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "USE_YN");
                this.grd01.Cols["ST_DATE"].Format = "dd-MM-yyyy";
                this.grd01.Cols["ED_DATE"].Format = "dd-MM-yyyy";



                this.grd02.AllowEditing = true;
                this.grd02.Initialize();
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "HSN", "HSN", "HSN");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 450, "DESCRIPTION", "HSN_DES", "HSN_DES");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 64, "USER_ID", "USER_ID", "USER_ID");



                this.grd03.AllowEditing = true;
                this.grd03.Initialize();
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "HSN", "HSN", "HSN");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 450, "DESCRIPTION", "HSN_DES", "HSN_DES");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 64, "TAX ID", "TAXID", "TAXID");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "I/DEC", "INT_DEC", "INT_DEC");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "E/DEC", "EXT_DEC", "EXT_DEC");

                
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "BEGIN DATE", "ST_DATE", "ST_DATE");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "END DATE", "ED_DATE", "ED_DATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "AREA", "AREACD", "AREACD");                
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 64, "USER_ID", "USER_ID", "USER_ID");

                this.grd03.SetColumnType(AxFlexGrid.FCellType.Date, "ST_DATE");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Date, "ED_DATE");

                this.grd03.Cols["ST_DATE"].Format = "dd-MM-yyyy";
                this.grd03.Cols["ED_DATE"].Format = "dd-MM-yyyy";

                

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                if (tabControl1.SelectedIndex == 0)
                {
                    
                    DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "TAXID", "TAXDESC", "INT_DEC", "EXT_DEC", "SEQ", "USE_YN", "ST_DATE", "ED_DATE");

                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        source.Tables[0].Rows[i]["CORCD"] = UserInfo.CorporationCode;
                        source.Tables[0].Rows[i]["BIZCD"] = bizcd;
                    }
                    this.BeforeInvokeServer(true);

                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_DATA"), source);
                }
                else if (tabControl1.SelectedIndex == 1)
                {

                    DataSet source = this.grd02.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "HSN", "HSN_DES", "USER_ID");

                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        source.Tables[0].Rows[i]["CORCD"] = UserInfo.CorporationCode;
                        source.Tables[0].Rows[i]["BIZCD"] = bizcd;
                        source.Tables[0].Rows[i]["USER_ID"] = UserInfo.UserID;
                    }
                    this.BeforeInvokeServer(true);

                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_HSN"), source);
                }
                else if (tabControl1.SelectedIndex == 2)
                {

                    DataSet source = this.grd03.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "AREACD", "TAXID", "HSN", "INT_DEC", "EXT_DEC", "ST_DATE", "ED_DATE", "USER_ID");

                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        source.Tables[0].Rows[i]["CORCD"] = UserInfo.CorporationCode;
                        source.Tables[0].Rows[i]["BIZCD"] = bizcd;
                        source.Tables[0].Rows[i]["USER_ID"] = UserInfo.UserID;
                    }
                    this.BeforeInvokeServer(true);

                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_DET"), source);
                }

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show(" 저장되었습니다.");
                MsgCodeBox.Show("CD00-0071");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                string bizcd = cbo01_BIZCD.GetValue().ToString();
                if (tabControl1.SelectedIndex == 0)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("STD_DATE", axDateEdit1.GetDateText());
                    set.Add("TAXID", axTextBox1.GetValue());

                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(bizcd, set);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_DATA"), set, "OUT_CURSOR");
                    grd01.SetValue(source);
                }
                else if (tabControl1.SelectedIndex==1)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("HSN", axTextBox2.GetValue());
                    set.Add("HSN_DES", axTextBox3.GetValue());

                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(bizcd, set);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_HSN"), set, "OUT_CURSOR");
                    grd02.SetValue(source);
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("STD_DATE", axDateEdit2.GetDateText());
                    set.Add("TAXID", axTextBox8.GetValue());
                    set.Add("HSN", axTextBox6.GetValue());
                    set.Add("HSN_DES", axTextBox5.GetValue());
                    set.Add("AREACD", axTextBox7.GetValue());

                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(bizcd, set);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_DET"), set, "OUT_CURSOR");
                    grd03.SetValue(source);
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

        private void axButton1_Click(object sender, EventArgs e)
        {
            if(MsgBox.Show("Do you want to import Basic Tax Data?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("STD_DATE", axDateEdit2.GetDateText());

                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_IMPORT"), set);
                BtnQuery_Click(null, null);
            }
        }




    }
}

