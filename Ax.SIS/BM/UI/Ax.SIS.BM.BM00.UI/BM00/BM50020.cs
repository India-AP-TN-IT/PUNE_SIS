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
    public partial class BM50020 : AxCommonBaseControl
    {
     
        private AxClientProxy _WSCOM_N;

        public BM50020()
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

                cbo01_BIZCD.SetValue("");
             
                //그리드
                this.grd01.Initialize();
                
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "C/CODE", "CORCD","CORCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "B/CODE", "BIZCD","@@");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "MODEL", "MODEL","MODELNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "차종코드", "VINCD","VINCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "차종명", "VINNM","VINNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "S/DATE", "ST_DATE", "ST_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "E/DATE", "ED_DATE", "ED_DATE");



                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], "BIZCD");
                this.grd01.Cols["ST_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "ST_DATE");
                this.grd01.Cols["ED_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "ED_DATE");

                this.grd01.Cols["MODEL"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd01.Cols["VINCD"].Style.BackColor = Color.LightGoldenrodYellow;
                this.grd01.Cols["VINNM"].Style.BackColor = Color.LightGoldenrodYellow;


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
                
                DataSet source = null;
                HEParameterSet set = null;
                source = grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "VINCD", "VINNM", "MODEL","ST_DATE", "ED_DATE" ,"USER_ID");


                this.BeforeInvokeServer(true);
                
                int cnt = 0;
                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    if (string.IsNullOrEmpty(dr["MODEL"].ToString()))
                    {
                        this.AfterInvokeServer();
                        //MsgBox.Show("모델코드 미입력");                        
                        MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("MODELCD"));
                        BtnQuery_Click(null, null);
                        return;
                    }
                    if (string.IsNullOrEmpty(dr["VINCD"].ToString()))
                    {
                        this.AfterInvokeServer();
                        //MsgBox.Show("차종코드 미입력");                        
                        MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("VINCD"));
                        BtnQuery_Click(null, null);
                        return;
                    }
                    if (string.IsNullOrEmpty(dr["VINNM"].ToString()))
                    {
                        this.AfterInvokeServer();
                        //MsgBox.Show("차종명 미입력");                        
                        MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("VINNM"));
                        BtnQuery_Click(null, null);
                        return;
                    }
                    set = new HEParameterSet();
                    set.Add("CORCD", UserInfo.CorporationCode);
                    set.Add("BIZCD", dr["BIZCD"].ToString());
                    set.Add("VINCD", dr["VINCD"].ToString());
                    set.Add("VINNM", dr["VINNM"].ToString());
                    set.Add("MODEL", dr["MODEL"].ToString());
                    set.Add("ST_DATE", dr["ST_DATE"].ToString());
                    set.Add("ED_DATE", dr["ED_DATE"].ToString());
                    set.Add("USER_ID", dr["USER_ID"].ToString());
                    _WSCOM_N.ExecuteNonQueryTx("APG_BM50020.SAVE", set);
                    
                    
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
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());                
                set.Add("VINCD", heTextBox2.GetValue());
                set.Add("MODEL", heTextBox1.GetValue());
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                //DataSet source = _WSCOM_N.ExecuteDataSet("APG_BM20150.INQUERY", set, "OUT_CURSOR");
                DataSet source = _WSCOM_N.ExecuteDataSet("APG_BM50020.INQUERY", set, "OUT_CURSOR");
                this.grd01.SetValue(source);
                

               
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

                if (pGrid.Cols[pGrid.Col].Name == "VINCD")
                {
                    paramSet["TY_CODE"] = "UDC:A3";
                    cdStr = "VINCD";
                    descStr = "VINNM";
                }
                else if(pGrid.Cols[pGrid.Col].Name == "MODEL")
                {
                    pGrid.SetValue(pGrid.Row, 0, "U");
                    return;
                }
                else if (pGrid.Cols[pGrid.Col].Name == "BIZCD")
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
                if (pGrid.Cols[pGrid.Col].Name == "VINCD" || pGrid.Cols[pGrid.Col].Name == "VINNM")
                {

                    pGrid.FinishEditing(true);
                    PopupHelper helper = null;
                    BM20115P0 _bm1 = new BM20115P0(this.GetLabel("VIN")/*"차종"*/, this.GetLabel("VINNM")/*"차종명"*/, pGrid.GetValue(pGrid.Row, "VINCD").ToString(), "");
                    _bm1.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                    _bm1.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                    _bm1.HEUserParameterSetValue("TY_CODE", "UDC:A3");
                    _bm1.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                    helper = new PopupHelper(_bm1, this.GetLabel("VIN"));//"차종");
                    helper.ShowDialog();

                    DataRow row = (DataRow)helper.SelectedData;
                    if (row != null)
                    {
                        pGrid.SetValue(pGrid.Row, 0, "U");
                        pGrid.SetValue(pGrid.Row, "VINCD", row["T_CODE"]);
                        pGrid.SetValue(pGrid.Row, "VINNM", row["T_DESC"]);
                    }
                }
            }
        }

        #endregion

    }
}
