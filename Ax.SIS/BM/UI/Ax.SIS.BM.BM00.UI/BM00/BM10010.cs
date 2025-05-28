#region ▶ Description & History
/* 
 * 프로그램명 : 제조P/NO S/W현황
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2014-07-23      배명희     cdx01_VINCD 연결 팝업 변경 (CM20011P1 -> CM30010P1)
 *
*/
#endregion

using System;
using System.Data;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using HE.Framework.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using System.Collections.Generic;
using System.Drawing;
namespace Ax.SIS.BM.BM00.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>
    /// - 작 성 자 : 이태호<br />
    /// - 작 성 일 : 2010-08-19 오전 9:33:49<br />
    /// - 주요 변경 사항
    ///     1) 2010-08-19 오전 9:33:49   이태호 : 최초 클래스 생성<br />
    /// </summary>
    public partial class BM10010 : AxCommonBaseControl
    {
        //커밋테스트12345
        private AxClientProxy _WSCOM_N;
        
        public BM10010()
        {
            InitializeComponent();
            
            _WSCOM_N = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                cbo01_CORCD.DataBind_CORCD();
                cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                cbo01_CORCD.SetReadOnly(true);
                //사업장
                cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.cdx01_VINCD.HEPopupHelper = new Ax.SIS.CM.UI.CM30010P1("A3", true, true, this.cdx01_VINCD);
               
                this.grd01.PopMenuVisible = true;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 230, "Validation", "VALID");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 110, "C/CODE", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 110, "B/CODE", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 110, "Part NO.", "PARTNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "Part Name", "PARTNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 60, "REV", "REVISION");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 60, "CAR", "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 90, "CAR", "VINNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "ITEM", "ITEMCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "ITEM", "ITEMNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "MIP", "MIPV_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "MIP", "MIPV_DIV_NM");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "P/DIV", "PRDT_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "P/DIV", "PRDT_DIV_NM");

                //this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 40, "M/KIND", "MTART");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "M/KIND", "MTARTNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 40, "UNIT", "MEINS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 40, "UNIT", "MEINSNM");
               
                //this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "Level Structure", "PRDHA");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 170, "Level Structure", "P3DESC");
                //this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "Material Group", "MATKL");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 170, "Material Group", "P3DESC_MA");
                //this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "Source", "SOURCE");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Source", "SRCDESC");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 60, "P/GROUP", "SPART");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "P/GROUP", "SPARTNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 55, "POS", "INSTALL_POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "POS", "INSTALL_POSNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 130, "INPUT", "USER_ID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "UNIT QTY", "UNIT_QTY", "UNIT_QTY");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "UNIT_QTY");

                this.grd01.AddMerge(0, 0, "VINCD", "VINNM");
                this.grd01.AddMerge(0, 0, "MEINS", "MEINSNM");
                //this.grd01.AddMerge(0, 0, "MTART", "MTARTNM");
                this.grd01.AddMerge(0, 0, "MIPV_DIV", "MIPV_DIV_NM");
                this.grd01.AddMerge(0, 0, "ITEMCD", "ITEMNM");
              
                //this.grd01.AddMerge(0, 0, "PRDHA", "P3DESC");
                //this.grd01.AddMerge(0, 0, "MATKL", "P3DESC_MA");
                //this.grd01.AddMerge(0, 0, "SOURCE", "SRCDESC");
                this.grd01.AddMerge(0, 0, "PRDT_DIV", "PRDT_DIV_NM");
                this.grd01.AddMerge(0, 0, "INSTALL_POS", "INSTALL_POSNM");
               
                this.grd01.Cols.Frozen = grd01.Cols["PARTNM"].Index;
               // this.grd01.Cols["MEINS"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd01.Cols["PARTNO"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd01.Cols["PARTNM"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd01.Cols["REVISION"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd01.Cols["VINCD"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd01.Cols["SPART"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd01.Cols["MEINS"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd01.Cols["PRDT_DIV"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd01.Cols["ITEMCD"].Style.BackColor = Color.LightGoldenrodYellow;
               // this.grd01.Cols["PRDHA"].Style.BackColor = Color.LightGoldenrodYellow;
                //this.grd01.Cols["MATKL"].Style.BackColor = Color.LightGoldenrodYellow;
                //this.grd01.Cols["SOURCE"].Style.BackColor = Color.LightGoldenrodYellow;
                //this.grd01.Cols["MTART"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd01.Cols["MIPV_DIV"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd01.Cols["INSTALL_POS"].Style.BackColor = Color.LightGoldenrodYellow;



                // dtp01_STD_DATE.SetValue("1990-01-01");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private string GetPRDT_DIV()
        {
            if(radioButton1.Checked)
            {
                return "A0A";
            }
            else if (radioButton2.Checked)
            {
                return "A0S";
            }
            return "A0M";
        }
        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsQueryValid())
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("LANG_SET", UserInfo.Language);
                    paramSet.Add("CORCD", cbo01_CORCD.GetValue());
                    paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());

                    paramSet.Add("PARTNO", Txt_PartNo.Text);
                    paramSet.Add("VINCD", cdx01_VINCD.GetValue());
                    paramSet.Add("ITEMCD", "");
                    paramSet.Add("PRDT_DIV", GetPRDT_DIV());
                    paramSet.Add("STD_DATE", dtp01_STD_DATE.GetDateText());


                    DataTable dt = _WSCOM_N.ExecuteDataSet("APG_BM10010.GET_DATA", paramSet, "OUT_CURSOR").Tables[0];


                    this.grd01.SetValue(dt);
                }
               
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
            finally
            {
               
            }
        }

        protected override void BtnReset_Click(object sender, EventArgs e)
        {

        }
        private bool ValidData(ref AxFlexGrid grd)
        {
            List<string> lstPart = new List<string>();
            if(grd.Rows.Count < 2)
            {
                MsgBox.Show("It's Impossible without data validation.");
                return false;
            }
            bool bChk = true;
            HEParameterSet paramSet = new HEParameterSet();
            for (int row = 1; row < grd.Rows.Count; row++)
            {
                
                paramSet = new HEParameterSet();
                paramSet.Add("CORCD", cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                paramSet.Add("PARTNO", grd.GetValue(row, "PARTNO").ToString());
                paramSet.Add("PARTNM", grd.GetValue(row, "PARTNM").ToString());
                paramSet.Add("REVISION", grd.GetValue(row, "REVISION").ToString());
                paramSet.Add("VINCD", grd.GetValue(row, "VINCD").ToString());                
                paramSet.Add("MEINS", grd.GetValue(row, "MEINS").ToString());
                paramSet.Add("MIPV_DIV", grd.GetValue(row, "MIPV_DIV").ToString());
                paramSet.Add("PRDT_DIV", grd.GetValue(row, "PRDT_DIV").ToString());
                paramSet.Add("ITEMCD", grd.GetValue(row, "ITEMCD").ToString());
                paramSet.Add("USER_ID", UserInfo.UserID.ToString());
                
                DataTable dt = _WSCOM_N.ExecuteDataSet("APG_BM10010.GET_VALID", paramSet, "OUT_CURSOR").Tables[0];
                string errmsg = dt.Rows[0]["RTN"].ToString();
                if (lstPart.Contains(grd.GetValue(row, "PARTNO").ToString()) == false)
                {
                    lstPart.Add(grd.GetValue(row, "PARTNO").ToString());
                }
                else
                {
                    errmsg += "[Duplicated Part NO.]";
                }
                if(string.IsNullOrEmpty(errmsg) == false)
                {
                    C1.Win.C1FlexGrid.CellStyle sty = grd.Styles.Add("ERR");
                    sty.BackColor = Color.Red;
                    sty.ForeColor = Color.White;
                    
                    grd.SetValue(row, 0, "E");
                    grd.SetCellStyle(row, grd.Cols["VALID"].Index, sty);
                    grd.SetValue(row, "VALID", errmsg);
                    
                    bChk = false;
                }
                else
                {
                    
                    C1.Win.C1FlexGrid.CellStyle sty = grd.Styles.Add("OK");
                    sty.BackColor = Color.Lime;
                    sty.ForeColor = Color.Black;
                    grd.SetCellStyle(row, grd.Cols["VALID"].Index, sty);
                    grd.SetValue(row, "VALID", "OK");
                }
            }
            return bChk;
        }
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            if (grd01.Rows.Count <2)
            {
                return;
            }
            if (MsgBox.Show("Do you want to save?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if(ValidData(ref grd01) == false)
                {
                    if(MsgBox.Show("Do you want to save except invalidated data?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                    }
                    else
                    {
                        return;
                    }
                }
                
                DataSet ds = grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD","BIZCD", "ITEMCD", "PARTNO", "PARTNM", "REVISION", "VINCD"
                   , "MEINS", "MIPV_DIV", "PRDT_DIV", "INSTALL_POS", "USER_ID", "UNIT_QTY");

                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    
                    ds.Tables[0].Rows[row]["CORCD"] = cbo01_CORCD.GetValue().ToString();
                    ds.Tables[0].Rows[row]["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                    ds.Tables[0].Rows[row]["USER_ID"] = UserInfo.UserID;
                }
                _WSCOM_N.ExecuteNonQueryTx("APG_BM10010.SET_BM0300", ds);

            }

        }
        #endregion

        #region [ 유효성 검사 ]

        private bool IsQueryValid()
        {
            if (GetPRDT_DIV() != "A0A")
            {
                if (Txt_PartNo.Text.ToString().Length == 0)
                {
                    MsgBox.Show("Part NO is mandatory.");
                    return false;
                }
            }
            else
            {
                if (Txt_PartNo.Text.ToString().Length == 0 && string.IsNullOrEmpty(cdx01_VINCD.GetValue().ToString()) ==true)
                {
                    MsgBox.Show("Part NO or Car Kind is mandatory.");
                    return false;
                }
            }

            return true;
        }

        #endregion
        
        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (sender is AxFlexGrid)
            {


                AxFlexGrid pGrid = (AxFlexGrid)sender;
                HEParameterSet paramSet = new HEParameterSet();
                string cdStr = "";
                string descStr = "";
                string findStr = pGrid.GetValue(e.Row, e.Col).ToString();
                paramSet.Add("CORCD", UserInfo.CorporationCode);
                paramSet.Add("BIZCD", UserInfo.BusinessCode);
                paramSet.Add("TY_CODE", "");
                paramSet.Add("CODE", string.IsNullOrEmpty(findStr) ? "@#@#@#@#" : findStr);
                paramSet.Add("DESC", "");
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                if (pGrid.Cols[e.Col].Name == "ITEMCD")
                {
                    paramSet["TY_CODE"] = "UDC:A4";
                    cdStr = "ITEMCD";
                    descStr = "ITEMNM";
                }
                else if (pGrid.Cols[e.Col].Name == "PRDT_DIV")
                {
                    paramSet["TY_CODE"] = "UDC:A0";
                    cdStr = "PRDT_DIV";
                    descStr = "PRDT_DIV_NM";
                }
                else if (pGrid.Cols[e.Col].Name == "VINCD")
                {
                    paramSet["TY_CODE"] = "UDC:A3";
                    cdStr = "VINCD";
                    descStr = "VINNM";
                }
                else if (pGrid.Cols[e.Col].Name == "MEINS")
                {
                    paramSet["TY_CODE"] = "MEINS";
                    cdStr = "MEINS";
                    descStr = "MEINSNM";
                }
                else if (pGrid.Cols[pGrid.Col].Name == "PRDHA")
                {
                    paramSet["TY_CODE"] = "PRDHA";
                    cdStr = "PRDHA";
                    descStr = "P3DESC";
                }
                else if (pGrid.Cols[pGrid.Col].Name == "MATKL")
                {
                    paramSet["TY_CODE"] = "MATKL";
                    cdStr = "MATKL";
                    descStr = "P3DESC_MA";
                }
                else if (pGrid.Cols[pGrid.Col].Name == "MTART")
                {
                    paramSet["TY_CODE"] = "MTART";
                    cdStr = "MTART";
                    descStr = "MTARTNM";
                }
                else if (pGrid.Cols[pGrid.Col].Name == "SPART")
                {
                    paramSet["TY_CODE"] = "SPART";
                    cdStr = "SPART";
                    descStr = "SPARTNM";
                }
                else if (pGrid.Cols[pGrid.Col].Name == "SOURCE")
                {
                    paramSet["TY_CODE"] = "SOURCE";
                    cdStr = "SOURCE";
                    descStr = "SRCDESC";
                }
                else if (pGrid.Cols[pGrid.Col].Name == "MIPV_DIV")
                {
                    paramSet["TY_CODE"] = "UDC:A2";
                    cdStr = "MIPV_DIV";
                    descStr = "MIPV_DIV_NM";
                }
                else if (pGrid.Cols[pGrid.Col].Name == "INSTALL_POS")
                {
                    paramSet["TY_CODE"] = "UDC:A7";
                    cdStr = "INSTALL_POS";
                    descStr = "INSTALL_POSNM";
                }
                else if (pGrid.Cols[pGrid.Col].Name == "TYPECD")
                {
                    paramSet["TY_CODE"] = "UDC:A5";
                    cdStr = "TYPECD";
                    descStr = "TYPENM";
                }
                else
                {
                    pGrid.SetValue(e.Row, 0, "U");
                    return;
                }
                 DataTable dt= _WSCOM_N.ExecuteDataSet("APG_BM20115.INQUERY_DLG", paramSet, "OUT_CURSOR").Tables[0];

                if(dt.Rows.Count>=1)
                {
                    pGrid.SetValue(e.Row, 0, "U");
                    pGrid.SetValue(e.Row, cdStr, dt.Rows[0]["T_CODE"]);
                    if (string.IsNullOrEmpty(descStr) == false)
                    {
                        pGrid.SetValue(e.Row, descStr, dt.Rows[0]["T_DESC"]);
                    }
                }
                else
                {
                    pGrid.SetValue(e.Row, 0, "U");
                    pGrid.SetValue(e.Row, cdStr, "");
                    if (string.IsNullOrEmpty(descStr) == false)
                    {
                        pGrid.SetValue(e.Row, descStr, "");
                    }
                }
            }
        }


        private void heButton1_Click(object sender, EventArgs e)
        {
            //grd01.DataSource = null;
            grd01.InitializeDataSource();
            
            int rowCnt = 1;
            try
            {
                rowCnt= Convert.ToInt32(heTextBox1.Text);
            }
            catch
            {
                heTextBox1.Text ="1";
                rowCnt = 1;
            }

            for (int row = 0; row < rowCnt; row++)
            {
                grd01.AddRow();
            }
           
                heTextBox1.Text = "1";
            
        }

        private void heButton2_Click(object sender, EventArgs e)
        {
            ValidData(ref grd01);
        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender is AxFlexGrid)
            {
                AxFlexGrid pGrid = (AxFlexGrid)sender;
                if (pGrid.Cols[pGrid.Col].Name == "ITEMCD" || pGrid.Cols[pGrid.Col].Name == "ITEMNM")
                {
                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0("ITEM", "DESC", pGrid.GetValue(pGrid.Row, "ITEMCD").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                    _bm1.HEUserParameterSetValue("BIZCD", UserInfo.BusinessCode);
                    _bm1.HEUserParameterSetValue("TY_CODE", "UDC:A4");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, "ITEM TYPE");

                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "ITEMCD", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "ITEMNM", row["T_DESC"]);
                    }
                }
                else if (pGrid.Cols[pGrid.Col].Name == "MIPV_DIV" || pGrid.Cols[pGrid.Col].Name == "MIPV_DIV_NM")
                {

                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0("MIP", "DESC", pGrid.GetValue(pGrid.Row, "MIPV_DIV").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                    _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                    _bm1.HEUserParameterSetValue("TY_CODE", "UDC:A2");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, "IN House/Sub Contract");

                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "MIPV_DIV", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "MIPV_DIV_NM", row["T_DESC"]);
                    }
                }
                else if (pGrid.Cols[pGrid.Col].Name == "PRDT_DIV" || pGrid.Cols[pGrid.Col].Name == "PRDT_DIV_NM")
                {
                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0("P/D", "DESC", pGrid.GetValue(pGrid.Row, "PRDT_DIV").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                    _bm1.HEUserParameterSetValue("BIZCD", UserInfo.BusinessCode);
                    _bm1.HEUserParameterSetValue("TY_CODE", "UDC:A0");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, "Product Devision");

                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "PRDT_DIV", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "PRDT_DIV_NM", row["T_DESC"]);
                    }
                }
                else if (pGrid.Cols[pGrid.Col].Name == "INSTALL_POS" || pGrid.Cols[pGrid.Col].Name == "INSTALL_POSNM")
                {

                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0("POS", "DESC", pGrid.GetValue(pGrid.Row, "INSTALL_POS").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                    _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                    _bm1.HEUserParameterSetValue("TY_CODE", "UDC:A7");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, "INSTALL POSITION");

                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "INSTALL_POS", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "INSTALL_POSNM", row["T_DESC"]);
                    }
                }
                else if (pGrid.Cols[pGrid.Col].Name == "TYPECD" || pGrid.Cols[pGrid.Col].Name == "TYPENM")
                {

                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0("TYPE", "DESC", pGrid.GetValue(pGrid.Row, "TYPECD").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                    _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                    _bm1.HEUserParameterSetValue("TY_CODE", "UDC:A5");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, "TYPE");

                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "TYPECD", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "TYPENM", row["T_DESC"]);
                    }
                }
                else if (pGrid.Cols[pGrid.Col].Name == "MEINS" || pGrid.Cols[pGrid.Col].Name == "MEINSNM")
                {

                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0("UNIT", "DESC", pGrid.GetValue(pGrid.Row, "MEINS").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                    _bm1.HEUserParameterSetValue("BIZCD", UserInfo.BusinessCode);
                    _bm1.HEUserParameterSetValue("TY_CODE", "MEINS");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, "UNIT");
                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "MEINS", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "MEINSNM", row["T_DESC"]);
                    }
                }
                else if (pGrid.Cols[pGrid.Col].Name == "VINCD" || pGrid.Cols[pGrid.Col].Name == "VINNM")
                {
                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0("CAR", "DESC", pGrid.GetValue(pGrid.Row, "VINCD").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                    _bm1.HEUserParameterSetValue("BIZCD", UserInfo.BusinessCode);
                    _bm1.HEUserParameterSetValue("TY_CODE", "UDC:A3");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, "CAR");

                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "VINCD", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "VINNM", row["T_DESC"]);
                    }
                }
                else if (pGrid.Cols[pGrid.Col].Name == "PRDHA" || pGrid.Cols[pGrid.Col].Name == "P3DESC")
                {

                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0("L/S", "DESC", pGrid.GetValue(pGrid.Row, "PRDHA").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                    _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                    _bm1.HEUserParameterSetValue("TY_CODE", "PRDHA");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, "Level Structure");
                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "PRDHA", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "P3DESC", row["T_DESC"]);
                    }

                }
                else if (pGrid.Cols[pGrid.Col].Name == "MATKL" || pGrid.Cols[pGrid.Col].Name == "P3DESC_MA")
                {

                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0("M/GROUP", "DESC", pGrid.GetValue(pGrid.Row, "MATKL").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                    _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                    _bm1.HEUserParameterSetValue("TY_CODE", "MATKL");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, "Material Group");
                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "MATKL", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "P3DESC_MA", row["T_DESC"]);
                    }
                }
                else if (pGrid.Cols[pGrid.Col].Name == "MTART" || pGrid.Cols[pGrid.Col].Name == "MTARTNM")
                {

                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0("M/KIND", "DESC", pGrid.GetValue(pGrid.Row, "MTART").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                    _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                    _bm1.HEUserParameterSetValue("TY_CODE", "MTART");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, "Material Kind");
                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "MTART", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "MTARTNM", row["T_DESC"]);
                    }
                }
                else if (pGrid.Cols[pGrid.Col].Name == "SOURCE" || pGrid.Cols[pGrid.Col].Name == "SRCDESC")
                {

                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0("SOURCE", "DESC", pGrid.GetValue(pGrid.Row, "SOURCE").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                    _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                    _bm1.HEUserParameterSetValue("TY_CODE", "SOURCE");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, "SOURCE");
                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "SOURCE", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "SRCDESC", row["T_DESC"]);
                    }
                }
                else if (pGrid.Cols[pGrid.Col].Name == "SPART" || pGrid.Cols[pGrid.Col].Name == "SPARTNM")
                {

                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0("P/GROUP", "DESC", pGrid.GetValue(pGrid.Row, "SPART").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                    _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                    _bm1.HEUserParameterSetValue("TY_CODE", "SPART");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, "Product Grop");
                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "SPART", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "SPARTNM", row["T_DESC"]);
                    }
                }
            }
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopupHelper helper = null;
            BM10010P0 _bm1 = new BM10010P0();
           
            _bm1.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
            _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
            _bm1.HEUserParameterSetValue("PARTNO", Txt_PartNo.Text);
            _bm1.HEUserParameterSetValue("PARTNM", "");
            _bm1.HEUserParameterSetValue("STD_DATE", dtp01_STD_DATE.GetDateText());
            helper = new PopupHelper(_bm1, "Part NO. Search");
            helper.ShowDialog();

            DataRow row = (DataRow)helper.SelectedData;
            if (row != null)
            {
                Txt_PartNo.Text = row["PARTNO"].ToString();
            }
            
        }


    }
}

