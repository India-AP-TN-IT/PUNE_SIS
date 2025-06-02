#region ▶ Description & History
/* 
 * 프로그램명 : ZPD23111 출고실적 관리(상차)
 * 설     명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2019-07-04    김지복     출고를 위해 상차 처리된 실적 조회 및 조정 처리
 *
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using C1.Win.C1FlexGrid;
using System.Drawing;
using HE.Framework.ServiceModel;
using System.IO;
using System.Data.OleDb;
using System.Text;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>실사 생산 실적 관리</b>
    /// </summary>
    public partial class ZPD23111 : AxCommonBaseControl
    {
        //private IPM23110 _WSCOM;
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_ZPD23111";

        #region [ 초기화 작업 정의 ]

        public ZPD23111()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPM23110>("PM03", "PM23110.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();	
        }
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                
                if (this.UserInfo.IsAdmin.Equals("Y"))                
                    this.cbo01_BIZCD.SetReadOnly(false);         
                else               
                    this.cbo01_BIZCD.SetReadOnly(true);               
                
                this.dte01_STD_DATE.SetMMFromStart();                

                //유형코드
                DataSet source = this.GetTypeCode("A1", "C5");
                source.Tables[1].DefaultView.RowFilter = "TYPECD LIKE 'O%'";
                DataTable dtINV_STATUS = source.Tables[1].DefaultView.ToTable();

                //Delivery Type
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("LANG_SET", this.UserInfo.Language);
                DataTable dt = _WSCOM.ExecuteDataSet("APG_ZPD23111.INQUERY_DELI_TYPE", set, "OUT_CURSOR").Tables[0];
                this.cbo01_DELI_TYPE.DataBind(dt, this.GetLabel("DELI_TYPE") + ";" + this.GetLabel("DELI_NAME"), "C;L");

                //CAR NO
                set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                dt = _WSCOM.ExecuteDataSet("APG_ZPD23111.INQUERY_CARNO", set, "OUT_CURSOR").Tables[0];
                this.cbo01_CARNO.DataBind(dt, this.GetLabel("CAR_PLATE_NO") + ";" + this.GetLabel("TRKNM"), "C;L");

                this.grd01.AllowEditing = true;
                this.grd01.Initialize(1, 1, false);

                //행취소 기능만 사용. 조정수량 입력하지 않았는데 행 모드가 "U"로 바뀐 경우 행취소 처리할 수 있도록.
                this.grd01.CurrentContextMenu.Items[0].Visible = false; //행추가 사용안함
                this.grd01.CurrentContextMenu.Items[1].Visible = false; //행삭제 사용안함

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "사업장코드", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "기준일자", "DELI_DATE", "STD_DATE");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "DEP/DATE", "SY_DEP_DATE", "SY_DEP_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "TRUCK NO", "TRUCKNO", "TRUCKNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "TRUCK SEQ", "TRUCKSEQ", "TRUCKSEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "D.TYPE", "DELI_TYPE", "DELI_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "BUCKET", "TAG_SEQ", "TAG_SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "PART NAME", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "ALC", "ALCCD", "ALCCD"); 
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "LINE", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "업무유형", "JOB_TYPE", "JOB_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "출고유형", "INV_STATUS", "USGETYP");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "납품처", "CUST_PLANT", "DELI_PART");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "실적수량", "RSLT_QTY", "MES_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "실적조정수량", "CHNG_QTY", "MANUAL_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "총실적수량", "TOT_RSLT_QTY", "TOT_RSLT_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "TAG NO", "TAG", "TAG");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[0], "JOB_TYPE"); //업무유형
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtINV_STATUS, "INV_STATUS"); //출고유형
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], "BIZCD");

                this.grd01.Cols["RSLT_QTY"].Format = "#,###,###,###,###,###";
                this.grd01.Cols["CHNG_QTY"].Format = "#,###,###,###,###,##0";
                this.grd01.Cols["TOT_RSLT_QTY"].Format = "#,###,###,###,###,##0";
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RSLT_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "CHNG_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_RSLT_QTY");
                
                //this.grd01.Cols["CHNG_QTY"].StyleDisplay.BackColor = Color.LightYellow;

                this.grd01.KeyActionEnter = KeyActionEnum.MoveDown;

                CellStyle csPARTNO = grd01.Styles.Add("PARTNO");
                csPARTNO.BackColor = Color.Red;

                //CellStyle csCHNG_QTY = grd01.Styles.Add("CHNG_QTY");
                //csCHNG_QTY.BackColor = Color.LightYellow;



                this.grd01_2.AllowEditing = false;
                this.grd01_2.Initialize(1, 1, false);
                this.grd01_2.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "순번", "SEQ", "SEQ_NO");
                this.grd01_2.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "조정일자", "UPDATE_DATE", "CHNG_DATE");
                this.grd01_2.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "조정수량", "CHNG_QTY", "CHNG_QTY");
                this.grd01_2.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "사번", "UPDATE_ID", "EMPNO");
                this.grd01_2.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "성명", "NAME_KOR", "NAME_KOR");
                this.grd01_2.Cols["CHNG_QTY"].Format = "#,###,###,###,###,##0";                
                this.grd01_2.SetColumnType(AxFlexGrid.FCellType.Int, "CHNG_QTY");                

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(); //new PM20015P1();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dte01_STD_DATE.GetDateText());
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", this.UserInfo.PlantDiv); //2013.03.20 공장구분 추가(배명희)   
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                
                this.chk01_RSLT.Checked = true;
                
                this.SetRequired(this.lbl01_BIZNM2);



                #region [grd02-숨김그리드]

                this.grd02.AllowEditing = false;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.Initialize();
                this.grd02.Cols.RemoveRange(1, this.grd02.Cols.Count - 1);
                this.grd02.Styles.Fixed.BackColor = Color.Yellow;
                
                
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "ALC", "ALCCD", "ALCCD");
                //this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "납품처", "CUST_PLANT", "DELI_PART");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 080, "조정수량", "CHNG_QTY", "MANUAL_QTY");
                this.grd02.Cols["PARTNO"].DataType = typeof(string);
                this.grd02.Cols["ALCCD"].DataType = typeof(string);
                //this.grd02.Cols["CUST_PLANT"].DataType = typeof(string);
                this.grd02.Cols["CHNG_QTY"].DataType = typeof(decimal);
                this.grd02.Cols["CHNG_QTY"].Format = "#,###,###,###,###,##0";
                this.grd02.Cols[0].Visible = false;
                this.AddRow();
                #endregion

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        //protected override void BtnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        DataSet source = new DataSet();

        //        source = this.grd01.GetValue
        //         (
        //             AxFlexGrid.FActionType.Save,
        //             "CORCD", "BIZCD", "DELI_DATE", "PARTNO", "PARTNM", "JOB_TYPE", "INV_STATUS", "TRUCKNO", "TRUCKSEQ",
        //              "LINECD", "ALCCD", "CHNG_QTY", "TAG", "DELI_TYPE", "USER_ID", "RSLT_QTY"
        //         );
        //        foreach (DataRow row in source.Tables[0].Rows)
        //        {
        //            row["JOB_TYPE"] = row["JOB_TYPE"].ToString() == "" ? "" : row["JOB_TYPE"].ToString().Substring(2);//TYPECD만 저장함. (OBJECT_ID에서 앞 두자리 제거)
        //            row["INV_STATUS"] = row["INV_STATUS"].ToString() == "" ? "" : row["INV_STATUS"].ToString().Substring(2);//TYPECD만 저장함. (OBJECT_ID에서 앞 두자리 제거)
        //            row["USER_ID"] = this.UserInfo.UserID;
        //        }

        //        if (!this.IsSaveValid(source))
        //            return;

        //        //엑셀 업로드시 CD0021, CD0020L 에 없는 품번인 경우 PARTNM에 "X"값 들어 있음. 
        //        //품명 체크 후 불필요한 컬럼이므로 제거처리함.
        //        source.Tables[0].Columns.Remove("PARTNM");
        //        //실적수량 + 조정수량은 0보다 커야함. 수량 체크 후 불필요한 컬럼 제거 처리함.
        //        source.Tables[0].Columns.Remove("RSLT_QTY");

        //        this.BeforeInvokeServer(true);
        //        //_WSCOM.Save(source);
        //        _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);
        //        this.AfterInvokeServer();

        //        this.BtnQuery_Click(null, null);

        //        //MsgBox.Show("입력하신 실사생산실적 정보가 저장되었습니다.");
        //        MsgCodeBox.Show("CD00-0071");
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.Message);
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
                AxFlexGrid grd =  this.grd01; 
                HEParameterSet set = new HEParameterSet();

                string strCarSeq = this.txt01_CARSEQ.GetValue().ToString();
                if (string.IsNullOrEmpty(strCarSeq) == false)
                {
                    strCarSeq = strCarSeq.PadLeft(3, '0');

                }
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("DELI_DATE", this.dte01_STD_DATE.GetDateText());
                set.Add("LINECD", this.cdx01_LINECD.GetValue());
                set.Add("RSLT", this.chk01_RSLT.Checked ? "1" : "0");
                set.Add("PARTNO", this.txt01_PARTNO.GetValue().ToString());
                set.Add("ALCCD", this.txt01_ALCCD.GetValue().ToString());
                set.Add("CARNO", this.cbo01_CARNO.GetValue());
                set.Add("CARSEQ", strCarSeq);
                set.Add("DELI_TYPE ", this.cbo01_DELI_TYPE.GetValue());
                set.Add("TAG", this.txt01_TAGNO.GetValue().ToString());
                set.Add("LANG_SET", this.UserInfo.Language);                
                

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(set);
                
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set);

                grd.SetValue(source);
                this.AfterInvokeServer();
                ShowDataCount(source);
                               
                //grd.setAlternateRowStyle(6);
                this.grd01_2.InitializeDataSource(); //조정이력 초기화
               
                int idx = grd.Cols["PARTNO"].Index;
                for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
                {
                    //GetValue는 숫자컬럼인 경우에는 빈값이면 "0"을 리턴함. 수량입력 여부를 체크하기 위해서는 GetValue가 적합하지 않음.
                    //조정수량이 0이라도 입력된 경우에 품번 셀 배경색을 RED로...
                    //if (!(grd.GetValue(i, "CHNG_QTY").ToString().Equals("0") || grd.GetValue(i, "CHNG_QTY").ToString().Equals("")))
                    if (!(grd[i, "CHNG_QTY"].ToString().Equals("")))
                    {
                        grd.SetCellStyle(i, idx, "PARTNO");
                    }
                    grd.SetCellStyle(i, grd.Cols["CHNG_QTY"].Index, "CHNG_QTY");
                }

                if (chk01_RSLT.Checked)
                { 
                    //실적데이터 - JOB_TYPE, INV_STATUS, CUST_PLANT 편집 불가
                    
                    this.grd01.Cols["CUST_PLANT"].AllowEditing = false;
                    this.grd01.Cols["CUST_PLANT"].StyleDisplay.BackColor = Color.White;
                }
                else
                {
                    //cd0021 전체 데이터 -  JOB_TYPE, INV_STATUS, CUST_PLANT 편집 허용. 
                    this.grd01.Cols["CUST_PLANT"].AllowEditing = true;
                    this.grd01.Cols["CUST_PLANT"].StyleDisplay.BackColor = Color.LightYellow;

                }
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

        #region [ 기타 컨트롤들에 대한 이벤트 정의 ]

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

        #region 엑셀 양식 다운로드 / 엑셀 업로드

        private void btn01_UPLOAD_Click(object sender, EventArgs e)
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

        private void btn01_EXCEL_FORM_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grd02.Rows.Count > 0)
                {
                    this.sfdExcel.DefaultExt = "xlsx";
                    this.sfdExcel.Filter = "Excel files (*.xls)|*.xls";
                    this.sfdExcel.FileName = this.GetLabel("ZPD23111_FORM");

                    if (this.sfdExcel.ShowDialog() == DialogResult.OK)
                    {
                        string temp_file = this.sfdExcel.FileName;

                        //행번호 컬럼은 엑셀로 전환되지 않도록..
                        this.grd02.Cols.Fixed = 0;
                        FileFlags flags = FileFlags.IncludeFixedCells | FileFlags.VisibleOnly;
                        this.grd02.SaveGrid(temp_file, FileFormatEnum.Excel, flags);

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

        #region [   └─ 조정수량 입력 이력 조회 ]
        //실적 데이터가 있다면 조정수량 등록 이력 조회
        private void grd_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                try
                {
                    AxFlexGrid grd = (AxFlexGrid)sender;
                    int r = grd.MouseRow;
                    if (r < grd.Rows.Fixed || r >= grd.Rows.Count) return;

                    string CORCD = grd.GetValue(r, "CORCD").ToString();
                    string BIZCD = grd.GetValue(r, "BIZCD").ToString();
                    string DELI_DATE = grd.GetValue(r, "DELI_DATE").ToString();
                    string PARTNO = grd.GetValue(r, "PARTNO").ToString();
                    string JOB_TYPE = grd.GetValue(r, "JOB_TYPE").ToString();
                    string INV_STATUS = grd.GetValue(r, "INV_STATUS").ToString();
                    string TRUCK_NO = grd.GetValue(r, "TRUCKNO").ToString();
                    string TRUCK_SEQ = grd.GetValue(r, "TRUCKSEQ").ToString();
                    string TAG_NO = grd.GetValue(r, "TAG").ToString();

                    DataSet source = this.getHistory(CORCD, BIZCD, DELI_DATE, PARTNO, JOB_TYPE, INV_STATUS, TRUCK_NO, TRUCK_SEQ, TAG_NO);

                    if (grd.Name == "grd01")
                        this.grd01_2.SetValue(source);

                }
                catch (FaultException<ExceptionDetail> ex)
                {
                    MsgBox.Show(ex.ToString());
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        //조정이력 조회
        private DataSet getHistory(string corcd, string bizcd, string deli_date, string partno,
                                    string job_type, string inv_status, string truck_no, string truck_seq, string tag_no)
        {
            try
            {
                HEParameterSet param = new HEParameterSet();
                param.Add("CORCD", corcd);
                param.Add("BIZCD", bizcd);
                param.Add("DELI_DATE", deli_date);
                param.Add("PARTNO", partno);
                param.Add("JOB_TYPE", job_type.Substring(2));
                param.Add("INV_STATUS", inv_status.Substring(2));
                param.Add("CARNO", truck_no);
                param.Add("CARSEQ", truck_seq);
                param.Add("TAG", tag_no);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(set);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_HISTORY"), param);
                this.AfterInvokeServer();
                return source;  
            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
                throw ex;
            }
        }
        #endregion

        #endregion

        #region [ 유효성 체크 ]
        protected bool IsVaildFile(string FilePath)
        {
            FileInfo FI = new FileInfo(FilePath);
            FileStream FS = null;

            try
            {
                FS = FI.Open(FileMode.Open);
            }
            catch (IOException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (FS != null)
                    FS.Close();
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



                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

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

                string strTagno = "MANUAL" + DateTime.Now.ToString("yyyyMMddHHmmss");
                int iSeq = 0;

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

                    //해당 품번의 CD0021.LINECD와 화면에서 입력한 LINECD가 다른 경우 저장 불가
                    if (dr["LINECD"].ToString() != this.cdx01_LINECD.GetValue().ToString()) 
                    {
                        //{0}번째 행에 {1} 정보가 잘 못 입력되었습니다.
                        MsgCodeBox.ShowFormat("CD00-0096", rIdx, this.grd01.Cols["LINECD"].Caption);
                        return false;
                    }

          

                    ////조정수량은 필수입력
                    //if (dr["CHNG_QTY"].ToString() == "")// || dr["CHNG_QTY"].ToString() == "0")
                    //{
                    //    //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                    //    MsgCodeBox.ShowFormat("CD00-0091", rIdx, this.grd01.Cols["CHNG_QTY"].Caption);
                    //    return false;
                    //}

                    //실적수량 + 조정수량은 0보다 커야함. (총 실적수량은 0보다 커야함)
                    int chngQty = string.IsNullOrEmpty(dr["CHNG_QTY"].ToString()) ? 0 : Convert.ToInt32(dr["CHNG_QTY"]);
                    int rsltQty = string.IsNullOrEmpty(dr["RSLT_QTY"].ToString()) ? 0 : Convert.ToInt32(dr["RSLT_QTY"]);
                  
                    if (chngQty + rsltQty < 0)
                    {
                        //{0}번째 행에 {1} 정보가 잘 못 입력되었습니다.
                        MsgCodeBox.ShowFormat("CD00-0096", rIdx, this.grd01.Cols["CHNG_QTY"].Caption);
                        return false;
                    }


                    if (this.GetByteCount(dr["JOB_TYPE"].ToString()) == 0)
                    {
                        //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rIdx, this.grd01.Cols["JOB_TYPE"].Caption);
                        return false;
                    }
                    
                    if (this.GetByteCount(dr["INV_STATUS"].ToString()) == 0)
                    {
                        //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rIdx, this.grd01.Cols["INV_STATUS"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["TRUCKNO"].ToString()) == 0)
                    {
                        dr["TRUCKNO"] = "X";
                    }

                    if (this.GetByteCount(dr["TRUCKSEQ"].ToString()) == 0)
                    {
                        dr["TRUCKSEQ"] = "001";
                    }

                    if (this.GetByteCount(dr["TAG"].ToString()) == 0)
                    {
                        iSeq++;
                        dr["TAG"] = strTagno + iSeq.ToString().PadLeft(4, '0');
                    }

                    if (this.GetByteCount(dr["ALCCD"].ToString()) == 0)
                    {
                        //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rIdx, this.grd01.Cols["ALCCD"].Caption);
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

        private bool IsQueryValid()
        {
            try
            {
                
                
                
                //if (cbo01_PRDT_DIV.ByteCount == 0)
                //{
                //    MsgBox.Show("데이터 조회를 위하여 제품구분을 입력하십시오.");
                //    return false;
                //}
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        #endregion

        #region [ 사용자 정의 메서드 ]
        
        private void AddRow()
        {
            this.grd02.Rows.Add();
            //((DataTable)this.grd02.DataSource).AcceptChanges();
            this.grd02.SetValue(1, "PARTNO", "82301-XXXXXXXX");
            this.grd02.SetValue(1, "ALCCD", "T01X");          
            this.grd02.SetValue(1, "CHNG_QTY", "1");

            Font f = new Font(this.grd02.Font, FontStyle.Italic);
            this.grd02.Rows[1].StyleDisplay.Font = f;
            this.grd02.Rows[1].StyleDisplay.BackColor = Color.Transparent;
            this.grd02.Rows[1].StyleDisplay.ForeColor = Color.Gray;
            
            //this.grd02.Rows[1].Visible = false;
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
                for (int i = this.grd02.Cols.Fixed; i < this.grd02.Cols.Count; i++)
                {
                    if (!this.grd02.Cols[i].Name.Equals(string.Empty))
                    {
                        temp += " TRIM([" + this.grd02.Cols[i].Caption + "])  AS " + this.grd02.Cols[i].Name + ",";
                    }
                }

                string commandString = String.Format(" SELECT  " + temp + 
                                                     "         '{0}' AS CORCD, '{1}' AS BIZCD, '{2}' AS LINECD, " +
                                                     "         '{3}' AS DELI_DATE, '{4}' AS JOB_TYPE, '{5}' AS INV_STATUS, " +
                                                     "          '' AS RSLT_QTY, '' AS PARTNM, '' AS TAG, " +
                                                     "          'X' AS TRUCKNO, '001' AS TRUCKSEQ, 'JIT' AS DELI_TYPE" +
                                                     " FROM    [{6}]" +
                                                     " WHERE   TRIM([" + this.grd02.Cols["PARTNO"].Caption + "]) <> '' ", 
                                                this.UserInfo.CorporationCode, this.cbo01_BIZCD.GetValue(), this.cdx01_LINECD.GetValue(),
                                                this.dte01_STD_DATE.GetDateText(), "A10", "C5O1",
                                                worksheets.Rows[0]["TABLE_NAME"]);
                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                oleDB.Close();

                string strTagno = "MANUAL" + DateTime.Now.ToString("yyyyMMddHHmmss");
                int iSeq = 0;
                foreach (DataRow dr in ds.Tables[0].Rows)
                { 
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", dr["CORCD"].ToString());
                    set.Add("BIZCD", dr["BIZCD"].ToString());
                    set.Add("PARTNO", dr["PARTNO"].ToString());
                    set.Add("LANG_SET", this.UserInfo.Language);
                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", this.PACKAGE_NAME, "INQUERY_PARTNO"), set);
                    if (source.Tables[0].Rows.Count > 0)
                    {
                        dr["PARTNM"] = source.Tables[0].Rows[0]["PARTNM"].ToString();
                        dr["LINECD"] = source.Tables[0].Rows[0]["LINECD"].ToString(); //ACD0021로부터 해당 PARTNO의 LINECD를 가져온다.
                    }
                    else
                    {
                        dr["PARTNM"] = "X";
                        dr["LINECD"] = "X";
                    }

                    iSeq++;
                    dr["TAG"] = strTagno + iSeq.ToString().PadLeft(4, '0');
                }
                this.grd01.SetValue(ds);
                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    this.grd01[i, 0] = AxFlexGrid.FLAG_N;
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
                oleDB.Close();
                
                this.AfterInvokeServer();
            }
        }

        #endregion

        //조정수량 입력시 총실적수량 계산(총실적수량 =  실적수량 + 조정수량) - 값 입력하는 그때그떄 계산하여 표시 (사용)
        private void grd01_ChangeEdit(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.Row;
                int col = this.grd01.Col;
                if (row < this.grd01.Rows.Fixed || row >= this.grd01.Rows.Count) return;
                if (col != this.grd01.Cols["CHNG_QTY"].Index) return;

                string value = this.grd01.Editor.Text.Replace(",", "");
                int rsltQty = string.IsNullOrEmpty(this.grd01.GetValue(row, "RSLT_QTY").ToString()) ? 0 : Convert.ToInt32(this.grd01.GetValue(row, "RSLT_QTY"));
                int inputQty = string.IsNullOrEmpty(value) ? 0 : Convert.ToInt32(value);

                this.grd01.SetValue(row, "TOT_RSLT_QTY", rsltQty + inputQty);
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        //조정수량 입력시 총실적수량 계산(총실적수량 =  실적수량 + 조정수량) - 값 입력후 포커스 이동시 계산하여 표시 (사용안함)
        private void grd01_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                //int row = e.Row;
                //int col = e.Col;
                //if (row < this.grd01.Rows.Fixed || row >= this.grd01.Rows.Count) return;
                //if (col != this.grd01.Cols["CHNG_QTY"].Index) return;

                //int rsltQty = string.IsNullOrEmpty(this.grd01.GetValue(row, "RSLT_QTY").ToString()) ? 0 : Convert.ToInt32(this.grd01.GetValue(row, "RSLT_QTY"));
                //int inputQty = string.IsNullOrEmpty(this.grd01.GetValue(row, "CHNG_QTY").ToString()) ? 0 : Convert.ToInt32(this.grd01.GetValue(row, "CHNG_QTY"));

                //this.grd01.SetValue(row, "TOT_RSLT_QTY", rsltQty + inputQty);
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

    }
}
