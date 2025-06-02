#region ▶ Description & History
/* 
 * 프로그램명 : PD64120 실사재고 조회 및 SAP 전송
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2017-10-25    배명희     신규 개발.
 *
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;

using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using Ax.SIS.CM.UI;
using System.Drawing;
using System.Data.OleDb;
using System.Text;

namespace Ax.SIS.PD.UI
{
   
    public partial class PD64120 : AxCommonBaseControl
    {
        //private IPD64120 _WSCOM;
        
        #region [ 초기화 작업 정의 ]

        public PD64120()
        {
            InitializeComponent();
            //_WSCOM = ClientFactory.CreateChannel<IPD64120>("PM04", "PD64120.svc", "CustomBinding");
            
        }
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.dte01_STD_DATE.SetMMFromStart();
                
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                
                if(this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.UserInfo.BusinessCode);
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0A");
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", ""); //2017.12.05 반제품 라인코드 조회 추가(정대진)
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dte01_STD_DATE.GetDateText());
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");                

                this.cdx01_STR_LOC.HEPopupHelper = new CM30040P1(); //new PM20015P1();
                this.cdx01_STR_LOC.PopupTitle = this.GetLabel("STR_LOC");
                this.cdx01_STR_LOC.CodeParameterName = "STR_LOC";
                this.cdx01_STR_LOC.NameParameterName = "STR_LOCNM";
                this.cdx01_STR_LOC.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_STR_LOC.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_STR_LOC.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = AllowSortingEnum.None;

                //this.grd01.EnabledActionFlag = false;

                //행취소 기능만 사용. 조정수량 입력하지 않았는데 행 모드가 "U"로 바뀐 경우 행취소 처리할 수 있도록.
                this.grd01.CurrentContextMenu.Items[0].Visible = false; //행추가 사용안함
                this.grd01.CurrentContextMenu.Items[1].Visible = false; //행삭제 사용안함

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "기준일자", "STD_DATE", "STD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "사업장", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "업무유형", "JOB_TYPE", "JOB_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PARTNO", "PARTNO", "PARTNO");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "PARTNM", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "저장위치", "STR_LOC", "STR_LOC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "오더번호", "ORDNO", "ORDNO1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "순번", "SEQNO", "SEQ_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 110, "재고수량", "INV_QTY", "INV_QTY1");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "조정수량", "CHNG_QTY", "CHNG_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "등록사번", "REG_EMPNO", "REG_EMPNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "재고생성일자", "UPDATE_DATE", "INV_CREATE_DATE");                              
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "SAP전송일자", "SAP_DATE", "SAP_CONFIRM_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 40, "선택", "CHK", "CHK");

                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A1", "JOB_TYPE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], "BIZCD");
                this.grd01.Cols["INV_QTY"].Format = "#,###,###,###,###,###,###";
                this.grd01.Cols["CHNG_QTY"].Format = "#,###,###,###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "INV_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "CHNG_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "STD_DATE");

                this.grd01.Cols["CHNG_QTY"].StyleDisplay.BackColor = Color.LightYellow;
                this.grd01.KeyActionEnter = KeyActionEnum.MoveDown;

                CellStyle cs = this.grd01.Styles.Add("csBool");
                cs.DataType = typeof(Boolean);
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;
                this.grd01.SetCellStyle(0, this.grd01.Cols["CHK"].Index, "csBool");

                this.grd01.SelChange += new System.EventHandler(this.grd01_SelChange);


                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_STD_DATE, this.lbl01_LINECD);
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
                if (!this.IsQueryValid())
                    return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("STD_DATE", this.dte01_STD_DATE.GetDateText().ToString());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue().ToString());
                paramSet.Add("STR_LOC", this.cdx01_STR_LOC.GetValue().ToString());
                paramSet.Add("ORDNO", this.txt01_ORDNO.GetValue().ToString());     
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                using (AxClientProxy proxy = new AxClientProxy())
                {
                    DataSet source = proxy.ExecuteDataSet("APG_PD64120.INQUERY", paramSet);
                    this.grd01.SetValue(source.Tables[0]);
                    ShowDataCount(source);
                }
                this.grd01[0, "CHK"] = 0;
                
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
        
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                DataSet source = this.grd01.GetValue
                 (
                     AxFlexGrid.FActionType.Save,
                     "CORCD", "BIZCD", "LINECD", "JOB_TYPE", "PARTNO", "STR_LOC", "STD_DATE", "ORDNO", "SEQNO", "CHNG_QTY", "USERID"
                 );
                foreach (DataRow row in source.Tables[0].Rows)
                {   
                    row["USERID"] = this.UserInfo.UserID;
                    row["JOB_TYPE"] = row["JOB_TYPE"].ToString().Substring(2);
                }

                if (!this.IsSaveValid(source))
                    return;
               

                this.BeforeInvokeServer(true);
                
                using (AxClientProxy proxy = new AxClientProxy())
                {
                    proxy.ExecuteNonQueryTx("APG_PD64120.SAVE", source);
                
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
                

        #endregion

        #region [ 유효성 검사 ]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 실사생산실적 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                
                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = source.Tables[0].Rows[i];
                    int rIdx = Convert.ToInt32(source.Tables[1].Rows[i][0]);

                   

                    if (dr["PARTNO"].ToString() == "")
                    {
                        //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rIdx, this.grd01.Cols["PARTNO"].Caption);
                        return false;
                    }


                    //조정수량은 필수입력
                    if (dr["CHNG_QTY"].ToString() == "")//|| dr["CHNG_QTY"].ToString() == "0")
                    {
                        //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rIdx, this.grd01.Cols["CHNG_QTY"].Caption);
                        return false;
                    }

                    if (dr["STR_LOC"].ToString() ==  "")
                    {
                        //{0} 가(이) 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0079", this.grd01.Cols["STR_LOC"].Caption);
                        return false;
                    }

                    if (dr["STD_DATE"].ToString() == "")
                    {
                        //{0} 가(이) 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0079", this.grd01.Cols["STD_DATE"].Caption);
                        return false;
                    }

                    if (dr["LINECD"].ToString() == "")
                    {
                        //{0} 가(이) 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0079", this.grd01.Cols["LINECD"].Caption);
                        return false;
                    }

                    if (dr["BIZCD"].ToString() == "")
                    {
                        //{0} 가(이) 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0079", this.grd01.Cols["BIZCD"].Caption);
                        return false;
                    }
                }
                

                //if (MsgBox.Show("입력하신 실사생산실적 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }


        private bool IsDataRegisterValid()
        {
            try
            {
                if (this.cbo01_BIZCD.IsEmpty)
                {
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM2.Text);
                    return false;
                }

                if (this.cdx01_LINECD.IsEmpty)
                {
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_LINECD.Text);
                    return false;
                }

                //엑셀업로드시에만 저장위치 코드박스 필수임. (엑셀에 별도 입력받지 않고 화면의 저장위치를 그대로 DB에 넣어주기 위해)
                //기말재고 생성 및 조회시에는 필수 체크 안함. 
                if (this.cdx01_STR_LOC.IsEmpty)
                {
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_STR_LOC.Text);
                    return false;
                }


                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsQueryValid()
        {
            if (this.cbo01_BIZCD.IsEmpty)
            {
                //{0} 가(이) 입력되지 않았습니다.
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM2.Text);
                return false;
            }

            if (this.cdx01_LINECD.IsEmpty)
            {
                //{0} 가(이) 입력되지 않았습니다.
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_LINECD.Text);
                return false;
            }


            return true;
        }

        private bool IsSaveValid()
        {
            if (this.cbo01_BIZCD.IsEmpty)
            {
                //{0} 가(이) 입력되지 않았습니다.
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM2.Text);
                return false;
            }

            if (this.cdx01_LINECD.IsEmpty)
            {
                //{0} 가(이) 입력되지 않았습니다.
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_LINECD.Text);
                return false;
            }
                       

            //if (MsgBox.Show("데이터를 생성하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("CD00-0024", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }
        
        private bool IsProcessValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count <= 0)
            {
                //처리할 대상 Data가 없습니다.
                MsgCodeBox.Show("COM-00021");
                return false;
            }

            //if (MsgBox.Show("선택하신 {0}건에 대해 SAP전송 하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.ShowFormat("PD00-0052", MessageBoxButtons.OKCancel, source.Tables[0].Rows.Count) != DialogResult.OK)
                return false;

            return true;
        }

        #endregion

        #region [ 기타 컨트롤 이벤트 ]

        #region 기말재고 생성 / SAP 전송
        
        private void btn01_CREATE_INV_Click(object sender, EventArgs e)
        {
            
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("STD_DATE", this.dte01_STD_DATE.GetDateText());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());
                paramSet.Add("STR_LOC", this.cdx01_STR_LOC.GetValue());
                paramSet.Add("ORDNO", this.txt01_ORDNO.GetValue());
                paramSet.Add("USERID", this.UserInfo.UserID);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                if (!IsSaveValid()) return;

                this.BeforeInvokeServer(true);

                using (AxClientProxy proxy = new AxClientProxy())
                {
                    DataSet source = proxy.ExecuteDataSetTx("APG_PD64120.SAVE_INV", paramSet);
                    this.grd01.SetValue(source.Tables[0]);
                }                
                this.AfterInvokeServer();

                //생성되었습니다.
                MsgCodeBox.Show("CD00-0089");
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

        private void btn01_PROCESS_SAP_Click(object sender, EventArgs e)
        {
            //SAP 처리
            try
            {
                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "LINECD", "JOB_TYPE", "PARTNO", "STR_LOC", "STD_DATE", "ORDNO", "SEQNO", "CHNG_QTY", "USERID");
                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    string val = this.grd01.GetValue(i, "CHK").ToString();
                    if (!val.Equals("Y")) continue;

                    source.Tables[0].Rows.Add(this.grd01.GetValue(i, "CORCD"),
                                                this.grd01.GetValue(i, "BIZCD"),
                                                this.grd01.GetValue(i, "LINECD"),
                                                this.grd01.GetValue(i, "JOB_TYPE").ToString().Substring(2),
                                                this.grd01.GetValue(i, "PARTNO"),
                                                this.grd01.GetValue(i, "STR_LOC"),
                                                this.grd01.GetValue(i, "STD_DATE"),
                                                this.grd01.GetValue(i, "ORDNO"),
                                                this.grd01.GetValue(i, "SEQNO"),
                                                this.grd01.GetValue(i, "CHNG_QTY"),
                                                this.UserInfo.UserID);
                }
                

                if (!this.IsProcessValid(source)) return;

                
                //---------------------------------------------------------
                //StringBuilder sb = new StringBuilder("");
                //for (int i = 0; i < source.Tables[0].Columns.Count; i++)
                //{
                //    sb.AppendLine(source.Tables[0].Columns[i].ColumnName + " : " + source.Tables[0].Rows[0][i].ToString());
                
                //}
                //MsgBox.Show(sb.ToString());
                //MsgBox.Show("프로시져 작업 완료 후 로직 완성 예정입니다.");
                //---------------------------------------------------------


                this.BeforeInvokeServer(true);
                using (AxClientProxy proxy = new AxClientProxy())
                {
                    proxy.ExecuteNonQueryTx("APG_PD64120.PROCESS_SAP", source);
                }
                this.AfterInvokeServer();

                
                //정상적으로 처리되었습니다.
                MsgCodeBox.Show("CD00-0013");

                this.BtnQuery_Click(null, null);
                
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

        private void cdx01_LINECD_ButtonClickAfter(object sender, EventArgs args)
        {
            try
            {
                if (this.cdx01_LINECD.SelectedPopupValue != null)
                {
                    if (this.cdx01_LINECD.SelectedPopupValue["STR_LOC"].ToString() != "")
                    {
                        this.cdx01_STR_LOC.SetValue(this.cdx01_LINECD.SelectedPopupValue["STR_LOC"].ToString());
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx01_LINECD_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cdx01_STR_LOC_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                this.cdx01_STR_LOC.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cdx01_LINECD.Initialize();
            this.cdx01_STR_LOC.Initialize();
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            this.cdx01_STR_LOC.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
        }

        

        private void grd01_MouseClick(object sender, MouseEventArgs e)
        {
            int row = this.grd01.MouseRow;
            int col = this.grd01.MouseCol;

        
            try
            {
                //헤더의 "전체선택"용 체크박스 선택시 데이터 전체 loop돌면서 선택하거나 해제한다.
                //체크박스의 선택/해제시에는 모드 "U"로  변경되지 않도록 한다.
                if (row == this.grd01.Rows.Fixed - 1 && col == this.grd01.Cols["CHK"].Index)
                {
                    string val = this.grd01.GetValue(row, col).ToString();
                    if (val.Equals("Y"))
                    {
                        this.grd01.EnabledActionFlag = false;
                        for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                        {
                            this.grd01.SetValue(i, "CHK", true);
                        }
                        this.grd01.EnabledActionFlag = true;
                    }
                    else
                    {
                        for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                        {
                            this.grd01.EnabledActionFlag = false;
                            this.grd01.SetValue(i, "CHK", false);
                            this.grd01.EnabledActionFlag = true;
                        }
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_CellChecked(object sender, RowColEventArgs e)
        {
            try
            {
                // 전데 데이터 중에 체크박스 값이 하나라도 선택해제되면, 헤더의 "전체선택"용 체크박스도 해제되도록 함. 
                int r = e.Row;
                int c = e.Col;
                
                if (c != this.grd01.Cols["CHK"].Index) return;
                if (r < this.grd01.Rows.Fixed || r >= this.grd01.Rows.Count) return;

                string strValue = this.grd01.GetValue(r, c).ToString();
                if (strValue.Equals("N") || strValue.Equals("0") || strValue.ToLower().Equals("false"))
                    this.grd01.SetValue(0, "CHK", 0);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_BeforeEdit(object sender, RowColEventArgs e)
        {
            int c = e.Col;
            if (c == this.grd01.Cols["CHK"].Index)
            {
                //체크박스 선택시에는 "U"모드 변경되지 않도록 함.
                //체크박스값이 저장되는것 아님! 단지 선택하는 용도인데, "U"로 변경되면 "저장"시 대상 데이터 추출에 혼선이 발생함. 사용자 오해 소지가 많음.
                this.grd01.EnabledActionFlag = false;
            }
            else
            {
                //그외 컬럼 값 변경시에는 'u"모드 변경됨.
                this.grd01.EnabledActionFlag = true;
            }
        }

        private void grd01_SelChange(object sender, EventArgs e)
        {
            //블럭지정하여 체크박스 선택한 경우.. 해당 블럭안의 체크박스 값이 함께 바뀌게 되는데,
            //그때 데이터 상태 "U"로 변경되지 않도록 하기 위해,
            //그리드의 선택셀 변경 이벤트에서 블럭 지정한 영역중에 체크박스 컬럼이 포함된 경우 EnabledActionFlag = false로 준다.
            int c1 = this.grd01.Selection.c1;
            int c2 = this.grd01.Selection.c2;
            if (c1 < this.grd01.Cols.Fixed) return;
            if (c2 < this.grd01.Cols.Fixed) return;
            if (!this.grd01.Cols.Contains("CHK")) return;

            if (c1 <= this.grd01.Cols["CHK"].Index || c2 >= this.grd01.Cols["CHK"].Index)
            {
                this.grd01.EnabledActionFlag = false;
            }

        }


        #endregion

        
        
        
        
        #region [ 사용자 정의 메서드 ]


        #endregion


    }
}

