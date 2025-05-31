#region ▶ Description & History
/* 
 * 프로그램명 : PD64110 완제품 MES 창고재고 전송 UPDATE
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2014-07-23    배명희     cdx01_LINECD 연결 팝업 변경 (CM20020P1 -> CM30030P1)
 *              2014-10-07    진승모     다국어 적용
 *              2017-07~09    배명희     SIS 이관
 *              2017.09.18    배명희     조회기능 추가.(생성된 기말재고 조회함)
 *              2017-10-24    배명희     관리자이면 사업장 선택 가능.
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
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>
    /// - 작 성 자 : 이태호<br />
    /// - 작 성 일 : 2010-07-12 오후 3:05:36<br />
    /// - 주요 변경 사항
    ///     1) 2010-07-12 오후 3:05:36   이태호 : 최초 클래스 생성<br />
    /// </summary>
    public partial class PD64110 : AxCommonBaseControl
    {
        //private IPD64110 _WSCOM;
        
        #region [ 초기화 작업 정의 ]

        public PD64110()
        {
            InitializeComponent();
            //_WSCOM = ClientFactory.CreateChannel<IPD64110>("PM04", "PD64110.svc", "CustomBinding");
            
        }
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
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
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0A");
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
                //this.grd01.EnabledActionFlag = false;

                //행취소 기능만 사용. 조정수량 입력하지 않았는데 행 모드가 "U"로 바뀐 경우 행취소 처리할 수 있도록.
                this.grd01.CurrentContextMenu.Items[0].Visible = false; //행추가 사용안함
                this.grd01.CurrentContextMenu.Items[1].Visible = false; //행삭제 사용안함

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "실사 기초일자", "INSPECT_DATE", "END_INV_STD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "사업장", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "라인코드명", "LINENM", "LINENM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PARTNO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 110, "PARTNM", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "저장위치", "STR_LOC", "STR_LOC");                                                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "재고수량", "INV_QTY", "INV_QTY1");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "조정수량", "CHNG_QTY", "CHNG_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 140, "등록일시", "UPDATE_DATE", "REG_DATETIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "등록사번", "REG_EMPNO", "REG_EMPNO");                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "SAP전송일자", "SAP_DATE", "SAP_CONFIRM_DATE");

                this.grd01.AddHiddenColumn("CORCD");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], "BIZCD");
                this.grd01.Cols["INV_QTY"].Format = "#,###,###,###,###,###,###";
                this.grd01.Cols["CHNG_QTY"].Format = "#,###,###,###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "INV_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "CHNG_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "INSPECT_DATE");

                this.grd01.Cols["CHNG_QTY"].StyleDisplay.BackColor = Color.LightYellow;

                this.grd01.KeyActionEnter = KeyActionEnum.MoveDown;

                #region [grdExcel-숨김그리드]

                this.grdExcel.AllowEditing = false;
                this.grdExcel.AllowDragging = AllowDraggingEnum.None;
                this.grdExcel.Initialize();
                this.grdExcel.Cols.RemoveRange(1, this.grdExcel.Cols.Count - 1);
                this.grdExcel.Cols.Fixed = 1;
                this.grdExcel.Styles.Fixed.BackColor = Color.Yellow;
                this.grdExcel.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");                
                this.grdExcel.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "조정수량", "CHNG_QTY", "CHNG_QTY");
                this.grdExcel.Cols["PARTNO"].DataType = typeof(string);
                this.grdExcel.SetColumnType(AxFlexGrid.FCellType.Decimal, "CHNG_QTY");
                this.grdExcel.Cols["CHNG_QTY"].Format = "#,###,###,###,###,###,##0";
                this.grdExcel.Cols[0].Visible = false;
                this.grdExcel.Styles.Fixed.Border.Color = Color.DarkGray;
                this.AddRow();
                #endregion

                this.SetRequired(this.lbl01_BIZNM, this.lbl01_END_INV_STD_DATE, this.lbl01_LINECD);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        //protected override void BtnProcess_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        HEParameterSet paramSet = new HEParameterSet();
        //        paramSet.Add("CORCD", this.UserInfo.CorporationCode);
        //        paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
        //        paramSet.Add("STD1_DATE", this.dte01_STD_DATE.GetValue());
                
        //        paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());

        //        if (!IsProcessValid(paramSet)) return;

        //        this.BeforeInvokeServer(true);
                
        //        using (HEClientProxy proxy = new HEClientProxy())
        //        {
        //            HEParameterSet set = new HEParameterSet();
        //            set.Add("CORCD", this.UserInfo.CorporationCode);
        //            set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
        //            set.Add("STD1_DATE", this.dte01_STD_DATE.GetValue()); //기말재고 반영일자
                    
        //            set.Add("LINECD", this.cdx01_LINECD.GetValue());
        //            set.Add("USERID", this.UserInfo.UserID);
        //            set.Add("LANG_SET", this.UserInfo.Language);

        //            proxy.ExecuteNonQueryTx("APG_PD64110.PROCESS", set);
        //        }
        //        //_WSCOM.Process(paramSet, this.cbo01_BIZCD.GetValue().ToString());
        //        this.AfterInvokeServer();
                
        //        //MsgBox.Show("완제품 MES창고 재고 전송을 완료 하였습니다.");
        //        MsgCodeBox.Show("CD00-0013");
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        MsgBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        this.AfterInvokeServer();
        //    }
        //}
        
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
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                using (AxClientProxy proxy = new AxClientProxy())
                {
                    DataSet source = proxy.ExecuteDataSet("APG_PD64110.INQUERY", paramSet);
                    this.grd01.SetValue(source.Tables[0]);
                    ShowDataCount(source);
                }
                
                
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
                     "CORCD", "BIZCD", "LINECD", "PARTNO", "PARTNM", "STR_LOC", "INSPECT_DATE", "CHNG_QTY", "USERID"
                 );
                foreach (DataRow row in source.Tables[0].Rows)
                {   
                    row["USERID"] = this.UserInfo.UserID;
                }

                if (!this.IsSaveValid(source))
                    return;

                //엑셀 업로드시 CD0021, CD0020L 에 없는 품번인 경우 PARTNM에 "X"값 들어 있음. 
                //품명 체크 후 불필요한 컬럼이므로 제거처리함.
                source.Tables[0].Columns.Remove("PARTNM");

                this.BeforeInvokeServer(true);
                
                using (AxClientProxy proxy = new AxClientProxy())
                {
                    proxy.ExecuteNonQueryTx("APG_PD64110.SAVE", source);
                
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

                    if (dr["PARTNM"].ToString() == "X") //품번명에 "X"인 경우는 엑셀 업로드한 품번이 CD0021, CD0020L에 없는 경우임.
                    {
                        //{0}번째 행에 {1} 정보가 잘 못 입력되었습니다.
                        MsgCodeBox.ShowFormat("CD00-0096", rIdx, this.grd01.Cols["PARTNO"].Caption);
                        return false;
                    }

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

                    if (dr["INSPECT_DATE"].ToString() == "")
                    {
                        //{0} 가(이) 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0079", this.grd01.Cols["INSPECT_DATE"].Caption);
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
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM.Text);
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
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM.Text);
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
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM.Text);
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
        
        private bool IsProcessValid()
        {
            if (this.grd01.Rows.Count <= this.grd01.Rows.Fixed)
            {
                //처리할 대상 Data가 없습니다.
                MsgCodeBox.Show("COM-00021");
                return false;
            }

            //if (MsgBox.Show("데이터를 처리하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("CD00-0021", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }

        #endregion

        #region [ 기타 컨트롤 이벤트 ]

        #region 기말재고 생성 / SAP 전송
        
        private void btn01_CREATE_END_INV_Click(object sender, EventArgs e)
        {
            //기말재고 생성은 (사업장, 날짜, 라인 기준으로만 처리함. 저장위치는 조회 및 업로드를 위한 조건임)
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("STD_DATE", this.dte01_STD_DATE.GetDateText());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());
                paramSet.Add("USER_ID", this.UserInfo.UserID);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                if (!IsSaveValid()) return;

                this.BeforeInvokeServer(true);

                using (AxClientProxy proxy = new AxClientProxy())
                {
                    DataSet source = proxy.ExecuteDataSetTx("APG_PD64110.SAVE_END_INV", paramSet);
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

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());                
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());
                paramSet.Add("STD_DATE", this.dte01_STD_DATE.GetDateText());

                if (!IsSaveValid()) return;

                this.BeforeInvokeServer(true);

                using (AxClientProxy proxy = new AxClientProxy())
                {
                    proxy.ExecuteNonQueryTx("APG_PD64110.PROCESS_SAP", paramSet);
                    
                }
                this.AfterInvokeServer();

                //정상적으로 처리되었습니다.
                MsgCodeBox.Show("CD00-0013");

                this.BtnQuery_Click(null, null);

                //this.grd01.InitializeDataSource(); //화면 표시중인 데이터 초기화..
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

        #region 엑셀 양식 다운로드 / 엑셀 업로드

        private void btn01_FILE_UPLOAD2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsDataRegisterValid()) return;

                DialogResult result = this.ofdExcel.ShowDialog(this);
                if (result == DialogResult.Cancel)
                    return;

                string filename = this.ofdExcel.FileName;
                //string extension = ((string[])filename.Split('.'))[filename.Split('.').Length - 1].ToUpper();
                //string endfilename = ((string[])filename.Split('\\'))[filename.Split('\\').Length - 1];

                if (!this.IsVaildFile(filename))
                {
                    //MessageBox.Show("파일에 접근할 수 없습니다. 파일이 열려있는지 확인하세요.");
                    MsgCodeBox.Show("CD00-0120");
                    return;
                }


                this.ReadExcel(filename);


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_EXCEL_DOWN_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdExcel.Rows.Count > 0)
                {
                    this.sfdExcel.DefaultExt = "xlsx";
                    this.sfdExcel.Filter = "Excel files (*.xls)|*.xls";
                    this.sfdExcel.FileName = this.GetLabel("PD64110_FORM");

                    if (this.sfdExcel.ShowDialog() == DialogResult.OK)
                    {
                        string temp_file = this.sfdExcel.FileName;

                        //행번호 컬럼은 엑셀로 전환되지 않도록..                     
                        this.grdExcel.Cols.Fixed = 0;
                                                                        
                        FileFlags flags = FileFlags.IncludeFixedCells | FileFlags.VisibleOnly;
                        this.grdExcel.SaveGrid(temp_file, FileFormatEnum.Excel, flags);
                        
                        //MsgBox.Show("다운로드가 완료되었습니다.");
                        MsgCodeBox.Show("CD00-0106");
                    }
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

        #endregion

        #region [ 사용자 정의 메서드 ]

        private void AddRow()
        {
            this.grdExcel.Rows.Add();
            this.grdExcel.SetValue(1, "PARTNO", "82301-XXXXXXXX");            
            this.grdExcel.SetValue(1, "CHNG_QTY", "0");

            Font f = new Font(this.grdExcel.Font, FontStyle.Italic);
            this.grdExcel.Rows[1].StyleDisplay.Font = f;
            this.grdExcel.Rows[1].StyleDisplay.BackColor = Color.Transparent;
            this.grdExcel.Rows[1].StyleDisplay.ForeColor = Color.Gray;

            //this.grdExcel.Rows[1].Visible = false;
        }

        private void ReadExcel(string FileName)
        {

            OleDbConnection oleDB = null;


            try
            {

                this.BeforeInvokeServer();
                string version = FileName.Substring(FileName.Length - 1, 1);
                this.BeforeInvokeServer(true);
                StringBuilder connectionString = new StringBuilder();

                int ExcelVersion = this.ExcelFileType(FileName);


                connectionString.AppendFormat(@"Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties='Excel 12.0;HDR=YES;';");

                connectionString.AppendFormat(@"Data Source={0}", FileName);

                oleDB = new OleDbConnection(connectionString.ToString());
                oleDB.Open();

                DataTable worksheets = oleDB.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                //양식용 숨김 그리드로부터 읽어들일 컬럼 정보 추출
                string temp = "";
                for (int i = this.grdExcel.Cols.Fixed; i < this.grdExcel.Cols.Count; i++)
                {
                    if (!this.grdExcel.Cols[i].Name.Equals(string.Empty))
                    {
                        temp += " TRIM([" + this.grdExcel.Cols[i].Caption + "])  AS " + this.grdExcel.Cols[i].Name + ",";
                    }
                }


                string commandString = String.Format(" SELECT  " + temp +
                                                     "         '{0}' AS CORCD, '{1}' AS BIZCD, '{2}' AS LINECD, " +
                                                     "         '{3}' AS INSPECT_DATE, '{4}' AS LINENM, '' AS PARTNM, " +
                                                     "         '{5}' AS STR_LOC, '' AS INV_QTY, '' AS UPDATE_DATE, '' AS REG_EMPNO " +
                                                     " FROM    [{6}]" +
                                                     " WHERE   TRIM([" + this.grdExcel.Cols["PARTNO"].Caption + "]) <> '' ",
                                                this.UserInfo.CorporationCode, 
                                                this.cbo01_BIZCD.GetValue(), 
                                                this.cdx01_LINECD.GetValue(),
                                                (Convert.ToDateTime(this.dte01_STD_DATE.GetValue())).AddDays(-1).ToString("yyyy-MM-dd"), 
                                                this.cdx01_LINECD.GetText(), 
                                                this.cdx01_STR_LOC.GetValue(),
                                                worksheets.Rows[0]["TABLE_NAME"]);
                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                oleDB.Close();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", dr["CORCD"].ToString());
                    set.Add("BIZCD", dr["BIZCD"].ToString());
                    set.Add("PARTNO", dr["PARTNO"].ToString());
                    set.Add("LANG_SET", this.UserInfo.Language);
                   
                    using (AxClientProxy proxy = new AxClientProxy())
                    {
                        DataSet source = proxy.ExecuteDataSet(string.Format("{0}.{1}", "APG_PD64110", "INQUERY_PARTNO"), set);
                        if (source.Tables[0].Rows.Count > 0)
                            dr["PARTNM"] = source.Tables[0].Rows[0]["PARTNM"].ToString();
                        else
                            dr["PARTNM"] = "X";
                    }

                }
                this.grd01.SetValue(ds);
                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    this.grd01[i, 0] = AxFlexGrid.FLAG_N;
                }

                this.ShowDataCount(ds);

                this.AfterInvokeServer();

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                oleDB.Close();

                this.AfterInvokeServer();
            }
        }

        #endregion

        
    }
}
