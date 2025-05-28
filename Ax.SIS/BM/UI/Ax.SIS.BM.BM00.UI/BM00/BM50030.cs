#region ▶ Description & History
/* 
 * 프로그램명 : Color Combination chart
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 :  
 * 최종수정일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-06-18      배명희      환경변수 테이블에(XD1530) BOM관련하여 사업장 선택 가능한 사번 정보 넣어두고,  이 사번에 있는 사용자만 사업장 콤보상자 READONLY 해제함.
 *				                            삭제시 화면에서 선택한 사업장 전달
 * 
*/
#endregion
using System;
using System.Drawing;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.ServiceModel;

namespace Ax.SIS.BM.BM00.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>
    /// - 작 성 자 : 이태호<br />
    /// - 작 성 일 : 2010-05-18 오후 12:25:48<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-18 오후 12:25:48   이태호 : 최초 클래스 생성<br />
    /// </summary>
    public partial class BM50030 : AxCommonBaseControl
    {
     
        private AxClientProxy _WSCOM_N;

        public BM50030()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
        
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //법인
                cbo01_CORCD.DataBind_CORCD();
                cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                cbo01_CORCD.SetReadOnly(true);
                //사업장
                cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                //품목
                this.cbo01_ITEMCD.DataBind("A4", true);
                //그리드
                this.grd01.Initialize();

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "C/CODE", "CORCD", "CORCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "1 LVL", "P1DESC", "@@");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "2 LVL", "P2DESC", "@@");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "CODE", "PRDHA", "CODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 170, "DETAIL", "P3DESC", "DETAILS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "PATTERN(R/EXP)", "PAT_PART", "@@");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "ITEM(ERM)", "ITEMCD", "@@");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "ITEM(ERM)", "ITEMNM", "@@");




                this.grd01.AddMerge(0, 0, "ITEMCD", "ITEMNM");

                this.grd01.Cols["PAT_PART"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd01.Cols["ITEMCD"].Style.BackColor = Color.LightGoldenrodYellow;



                this.grd02.Initialize();

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "C/CODE", "CORCD", "CORCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "1 LVL", "P1DESC", "@@");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "2 LVL", "P2DESC", "@@");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "CODE", "MATKL", "CODE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 170, "DETAIL", "P3DESC", "DETAILS");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "PATTERN(R/EXP)", "PAT_PART", "@@");



                this.grd02.Cols["PAT_PART"].Style.BackColor = Color.LightGoldenrodYellow;

                

                this.grd03.Initialize();

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "PROCUREMENT TYPE", "SOURCE", "@@");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 170, "PROCUREMENT TYPE", "SRCDESC", "@@");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "P/KIND", "BESKZ", "@@");
                this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "SPECIAL", "SOBSL", "@@");
                this.grd03.AddMerge(0, 0, "SOURCE", "SRCDESC");


                this.grd03.Cols["SRCDESC"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd03.Cols["BESKZ"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd03.Cols["SOBSL"].Style.BackColor = Color.LightGoldenrodYellow;

                this.grd04.Initialize();

                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "SAP CODE", "ACD", "@@");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "ERM CODE", "BCD", "@@");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 170, "CODE NAME", "BNM", "CODENM");
                this.grd04.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "CLASS", "CLASS", "ANLKL");


                this.grd04.Cols["ACD"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd04.Cols["BCD"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd04.Cols["BNM"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd04.Cols["CLASS"].Style.BackColor = Color.LightGoldenrodYellow;
                



            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private int GetPage()
        {
            return tabControl1.SelectedIndex;
        }
        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = null;
                HEParameterSet set = null;
                if (GetPage() == 0)
                {
                    source = grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD","PAT_PART", "PRDHA", "ITEMCD");
                }
                else if(GetPage() == 1)
                {
                    source = grd02.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "PAT_PART", "MATKL", "ITEMCD");
                }
                else if (GetPage() == 2)
                {                    
                    source = grd03.GetValue(AxFlexGrid.FActionType.Save, "SOURCE", "SRCDESC", "BESKZ", "SOBSL");
                }
                else if (GetPage() == 3)
                {
                    
                    source = grd04.GetValue(AxFlexGrid.FActionType.Save, "ACD", "BCD", "BNM", "CLASS");
                }
                this.BeforeInvokeServer(true);
                
                int cnt = 0;
                foreach (DataRow dr in source.Tables[0].Rows)
                {
                   
                    set = new HEParameterSet();
                    
                    if (GetPage() == 0)
                    {
                        set.Add("CORCD", dr["CORCD"].ToString());
                        set.Add("BIZCD", dr["BIZCD"].ToString());
                        set.Add("PAT_PART", dr["PAT_PART"].ToString());
                        set.Add("CODE", dr["PRDHA"].ToString());
                        
                        set.Add("ITEMCD", dr["ITEMCD"].ToString());
                        _WSCOM_N.ExecuteNonQueryTx("APG_BM50030.SAVE_PRDHA", set);
                    }
                    else if (GetPage() == 1)
                    {
                        set.Add("CORCD", dr["CORCD"].ToString());
                        set.Add("BIZCD", dr["BIZCD"].ToString());
                        set.Add("PAT_PART", dr["PAT_PART"].ToString());
                        set.Add("CODE", dr["MATKL"].ToString());
                        set.Add("ITEMCD", "");
                        _WSCOM_N.ExecuteNonQueryTx("APG_BM50030.SAVE_MATKL", set);
                    }

                    else if (GetPage() == 2)
                    {
                        set.Add("SOURCE", dr["SOURCE"].ToString());
                        set.Add("SRCDESC", dr["SRCDESC"].ToString());
                        set.Add("BESKZ", dr["BESKZ"].ToString());
                        set.Add("SOBSL", dr["SOBSL"].ToString());
                        _WSCOM_N.ExecuteNonQueryTx("APG_BM50030.SAVE_SOURCE", set);
                    }
                    else if (GetPage() == 3)
                    {
                        set.Add("ACD", dr["ACD"].ToString());
                        set.Add("BCD", dr["BCD"].ToString());
                        set.Add("BNM", dr["BNM"].ToString());
                        set.Add("CLASS", dr["CLASS"].ToString());
                        _WSCOM_N.ExecuteNonQueryTx("APG_BM50030.SAVE_UDC", set);
                    }
                    cnt++;
                }
                this.AfterInvokeServer();
                BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
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
                

                this.BtnReset_Click(null, null);
               
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                //DataSet source = _WSCOM_N.ExecuteDataSet("APG_BM20150.INQUERY", set, "OUT_CURSOR");
                
                if(GetPage() == 0)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", cbo01_CORCD.GetValue());
                    set.Add("CODE", heTextBox1.GetValue());
                    set.Add("DESC", heTextBox2.GetValue());
                    set.Add("ITEMCD", this.cbo01_ITEMCD.GetValue());
                    this.BeforeInvokeServer(true);
                    DataSet source = _WSCOM_N.ExecuteDataSet("APG_BM50030.INQUERY_PRDHA", set, "OUT_CURSOR");
                    this.grd01.SetValue(source);
                }
                else if (GetPage() == 1)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", cbo01_CORCD.GetValue());
                    set.Add("CODE", heTextBox1.GetValue());
                    set.Add("DESC", heTextBox2.GetValue());
                    set.Add("ITEMCD", this.cbo01_ITEMCD.GetValue());
                    this.BeforeInvokeServer(true);
                    DataSet source = _WSCOM_N.ExecuteDataSet("APG_BM50030.INQUERY_MATKL", set, "OUT_CURSOR");
                    this.grd02.SetValue(source);
                }
                else if (GetPage() == 2)
                {
                    HEParameterSet set = new HEParameterSet();
                   
                    set.Add("CODE", heTextBox1.GetValue());
                    set.Add("DESC", heTextBox2.GetValue());
                    this.BeforeInvokeServer(true);
                    DataSet source = _WSCOM_N.ExecuteDataSet("APG_BM50030.INQUERY_SOURCE", set, "OUT_CURSOR");
                    this.grd03.SetValue(source);
                }
                else if (GetPage() == 3)
                {
                    HEParameterSet set = new HEParameterSet();

                    set.Add("CODE", heTextBox1.GetValue());
                    set.Add("DESC", heTextBox2.GetValue());
                    set.Add("CLASS", heTextBox3.GetValue());
                    this.BeforeInvokeServer(true);
                    DataSet source = _WSCOM_N.ExecuteDataSet("APG_BM50030.INQUERY_UDC", set, "OUT_CURSOR");
                    this.grd04.SetValue(source);
                }
               
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }
        #endregion

        #region [ 기타 이벤트 정의 ]

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (sender is AxFlexGrid)
            {


                AxFlexGrid pGrid = (AxFlexGrid)sender;
                HEParameterSet paramSet = new HEParameterSet();
                string cdStr = "";
                string descStr = "";
                string findStr = pGrid.GetValue(e.Row, e.Col).ToString();
                paramSet.Add("CORCD", cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                paramSet.Add("TY_CODE", "");
                paramSet.Add("CODE", string.IsNullOrEmpty(findStr) ? "@#@#@#@#" : findStr);
                paramSet.Add("DESC", "");
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                if (pGrid.Cols[pGrid.Col].Name == "ITEMCD")
                {
                    paramSet["TY_CODE"] = "UDC:A4";
                    cdStr = "ITEMCD";
                    descStr = "ITEMNM";
                }
                else if(pGrid.Cols[pGrid.Col].Name == "PAT_PART")
                {
                    pGrid.SetValue(pGrid.Row, 0, "U");
                    return;
                }
                else if (pGrid.Cols[pGrid.Col].Name == "SRCDESC" || pGrid.Cols[pGrid.Col].Name == "BESKZ" || pGrid.Cols[pGrid.Col].Name == "SOBSL")
                {
                    
                    pGrid.SetValue(pGrid.Row, 0, "U");
                    return;
                }
                else if (pGrid.Cols[pGrid.Col].Name == "ACD" || pGrid.Cols[pGrid.Col].Name == "BCD" || pGrid.Cols[pGrid.Col].Name == "BNM" || pGrid.Cols[pGrid.Col].Name == "CLASS")
                {

                    pGrid.SetValue(pGrid.Row, 0, "U");
                    return;
                }
                DataTable dt = _WSCOM_N.ExecuteDataSet("APG_BM20115.INQUERY_DLG", paramSet, "OUT_CURSOR").Tables[0];

                if (dt.Rows.Count >= 1)
                {
                    pGrid.SetValue(pGrid.Row, 0, "U");
                    pGrid.SetValue(e.Row, cdStr, dt.Rows[0]["T_CODE"]);
                    pGrid.SetValue(e.Row, descStr, dt.Rows[0]["T_DESC"]);
                }
                else
                {
                    pGrid.SetValue(pGrid.Row, 0, "U");
                    pGrid.SetValue(e.Row, cdStr, "");
                    pGrid.SetValue(e.Row, descStr, "");
                }
            }
        }

        private void grd01_MouseDoubleClick(object sender, EventArgs e)
        {
            if (sender is AxFlexGrid)
            {
                AxFlexGrid pGrid = (AxFlexGrid)sender;
                if (pGrid.Cols[pGrid.Col].Name == "ITEMCD" || pGrid.Cols[pGrid.Col].Name == "ITEMNM")
                {

                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0(this.GetLabel("ITEM")/*"품목"*/, this.GetLabel("ITEMNM3")/*"품목명"*/, pGrid.GetValue(pGrid.Row, "ITEMCD").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                    _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                    _bm1.HEUserParameterSetValue("TY_CODE", "UDC:A4");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, this.GetLabel("ITEM"));//"품목");
                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "ITEMCD", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "ITEMNM", row["T_DESC"]);
                    }
                }
            }
        }

        #endregion

    }
}
