#region ▶ Description & History
/* 
 * 프로그램명 : BIW 내역관리
 * 설     명 : 
 * 최초작성자 : 배명희
 * 최초작성일 : 2017-06-15
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				-------------------------------------------------------------------------------------------------------------------------------------
 *				2017-06-15	    배명희		신규 개발
 *              2017-07-06      배명희       "비고"항목 추가.
 *				2017-09-22      배명희       체크박스 기본값 날짜조건사용 안함. 
 * 
*/
#endregion

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using Ax.SIS.QA.QA09.UI;

using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using System.IO;
using HE.Framework.ServiceModel;
using System.Diagnostics;

namespace Ax.SIS.QA.QA00.UI
{

    public partial class ZQA20017 : AxCommonBaseControl
    {        
        private string _CRT_DATE = string.Empty;
        private string _CRT_TIME = string.Empty;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "ZPG_ZQA20017";

        private CellStyle CS1;
        private CellStyle CS2;
        private CellStyle CS3;

        #region [ 초기화 작업 정의 ]

        public ZQA20017()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.BeforeInvokeServer(true);
   
                this._buttonsControl.BtnPrint.Visible = false;                
                this._buttonsControl.BtnProcess.Visible = false;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cdx02_PARTNO.HEPopupHelper = new QASubWindow();
                this.cdx02_PARTNO.PopupTitle = this.GetLabel("PARTNO_INFO");//"품번정보";
                this.cdx02_PARTNO.CodeParameterName = "PARTNO_OF_VENDCD";
                this.cdx02_PARTNO.NameParameterName = "PARTNO_OF_VENDNM";
                this.cdx02_PARTNO.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx02_PARTNO.HEParameterAdd("CORCD", this.UserInfo.CorporationCode);
                this.cdx02_PARTNO.HEParameterAdd("BIZCD", this.UserInfo.BusinessCode);
                this.cdx02_PARTNO.HEParameterAdd("VENDCD", "");
                this.cdx02_PARTNO.CodePixedLength = 20;
                this.cdx02_PARTNO.SetReadOnly(true);

                // Supplier
                this.cdx01_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("COOPER_CODE");// "협력사코드";
                this.cdx01_VENDCD.CodeParameterName = "VENDCD";
                this.cdx01_VENDCD.NameParameterName = "VENDNM";
                this.cdx01_VENDCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx02_VENDCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VENDCD.PopupTitle = this.GetLabel("COOPER_CODE");//"협력사코드";
                this.cdx02_VENDCD.CodeParameterName = "VENDCD";
                this.cdx02_VENDCD.NameParameterName = "VENDNM";
                this.cdx02_VENDCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx02_VENDCD.SetReadOnly(true);

                // Vehicle
                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx01_VINCD.SetCodePixedLength();
                this.cdx02_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx02_VINCD.PopupTitle = this.GetLabel("VINCD");
                this.cdx02_VINCD.CodeParameterName = "VINCD";
                this.cdx02_VINCD.NameParameterName = "VINCDNM";
                this.cdx02_VINCD.HEParameterAdd("LANG_SET", this.UserInfo.Language);
                this.cdx02_VINCD.SetCodePixedLength();
                this.cdx02_VINCD.SetReadOnly(true);

                // Plant Division
                DataSet source_PLANT_DIV = this.GetTypeCode("U9");
                this.cbo01_PLANT_DIV.DataBindCodeName(source_PLANT_DIV.Tables[0], false);
                this.cbo01_PLANT_DIV.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_PLANT_DIV.DataBindCodeName(source_PLANT_DIV.Tables[0], false);
                this.cbo02_PLANT_DIV.DropDownStyle = ComboBoxStyle.DropDownList;

                // Inspection Level
                DataTable combo_source_INSPECTION_LEVEL = new DataTable();
                combo_source_INSPECTION_LEVEL.Columns.Add("CODE");
                combo_source_INSPECTION_LEVEL.Columns.Add("NAME");
                combo_source_INSPECTION_LEVEL.Rows.Add("", " ");
                combo_source_INSPECTION_LEVEL.Rows.Add("1", "Lev1 - 100% Inspection");
                combo_source_INSPECTION_LEVEL.Rows.Add("2", "Lev2 - Sampling Inspection");
                combo_source_INSPECTION_LEVEL.Rows.Add("3", "Lev3 - Without Inspection");
                this.cbo01_INSPECTION_LEVEL.DataBind(combo_source_INSPECTION_LEVEL);
                this.cbo01_INSPECTION_LEVEL.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_INSPECTION_LEVEL.DataBind(combo_source_INSPECTION_LEVEL);
                this.cbo02_INSPECTION_LEVEL.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_INSPECTION_LEVEL_NEW.DataBind(combo_source_INSPECTION_LEVEL);
                this.cbo02_INSPECTION_LEVEL_NEW.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo02_INSPECTION_LEVEL_NEW.Visible = true;
                this.lbl02_INSPECTION_LEVEL_NEW.Visible = true;

                // Expiration Period
                DataTable combo_source_EXPIRATION_PERIOD = new DataTable();
                combo_source_EXPIRATION_PERIOD.Columns.Add("CODE");
                combo_source_EXPIRATION_PERIOD.Columns.Add("NAME");
                combo_source_EXPIRATION_PERIOD.Rows.Add("", " ");
                combo_source_EXPIRATION_PERIOD.Rows.Add("1", "1 - Month");
                combo_source_EXPIRATION_PERIOD.Rows.Add("3", "3 - Month");
                this.cbo02_EXPIRATION_PERIOD.DataBind(combo_source_EXPIRATION_PERIOD);
                this.cbo02_EXPIRATION_PERIOD.DropDownStyle = ComboBoxStyle.DropDownList;

                this.AfterInvokeServer();


                #region [Inspection List]
                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 65, "Supplier", "VENDCD", "VENDCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 170, "Suplier Name", "VENDNM", "VENDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 115, "Part No", "PARTNO", "PARTNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 255, "Part Name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 0, "VINCD", "VINCD", "VINCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 55, "Vehicle", "VINNM", "VINNM");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 0, "ZINSPECTION_LEVEL", "ZINSPECTION_LEVEL", "ZINSPECTION_LEVEL");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "Inspection State", "INSPECTION_LEVEL", "INSPECTION_LEVEL");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 0, "PLANT_DIV", "PLANT_DIV", "PLANT_DIV");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 0, "Plant", "PLANT_DIVNM", "PLANT_DIVNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 75, "Historys", "HISTORYS", "HISTORYS");
                #endregion

                #region [Inspection History]
                this.grd02.AllowEditing = false;
                this.grd02.AllowDragging = AllowDraggingEnum.None;
                this.grd02.Initialize();
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "Date", "APP_DATE", "APP_DATE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 25, "V", "C_VISUAL", "C_VISUAL");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 25, "D", "C_DIMENSION", "C_DIMENSION");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 25, "F", "C_FUNCTION", "C_FUNCTION");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 25, "A", "C_ATEST", "C_ATEST");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "Plant", "PLANT_DIV", "PLANT_DIV");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 35, "Lev", "INSPECTION_LEVEL", "INSPECTION_LEVEL");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 35, "Exp", "EXPIRATION_PERIOD", "EXPIRATION_PERIOD");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 0, "ExpDate", "EXPIRATION_DATE", "EXPIRATION_DATE");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 0, "LevOld", "INSPECTION_LEVEL_OLD", "INSPECTION_LEVEL_OLD");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 0, "CRT_DATE", "CRT_DATE", "CRT_DATE");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 0, "CRT_TIME", "CRT_TIME", "CRT_TIME");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 0, "DESCRIPTION", "DESCRIPTION", "DESCRIPTION");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 0, "INSPECTION_LEVELNM", "INSPECTION_LEVELNM", "INSPECTION_LEVELNM");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 0, "INSPECTION_LEVEL_OLDNM", "INSPECTION_LEVEL_OLDNM", "INSPECTION_LEVEL_OLDNM");
                this.grd02.Cols["APP_DATE"].Format = "yyyy-MM-dd";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "APP_DATE");
                #endregion

                this.SetRequired(lbl02_PARTNO, lbl02_INSPECTION_LEVEL, lbl02_APP_DATE);

                CS1 = grd01.Styles.Add("CS1");
                CS2 = grd01.Styles.Add("CS2");
                CS3 = grd01.Styles.Add("CS3");

                CS1.BackColor = lbl03_Level1.BackColor;
                CS2.BackColor = lbl03_Level2.BackColor;
                CS3.BackColor = lbl03_Level3.BackColor;

                this.BtnReset_Click(null, null);
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control ctl in grp01_ZQA20017_GRP2.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }
                this.cbo02_INSPECTION_LEVEL_NEW.Visible = true;
                this.lbl02_INSPECTION_LEVEL_NEW.Visible = true;
                this.chk02_C_VISUAL.Checked = false;
                this.chk02_C_FUNCTION.Checked = false;
                this.chk02_C_DIMENSION.Checked = false;
                this.chk02_C_ATEST.Checked = false;
                this.cbo02_INSPECTION_LEVEL.SetReadOnly(true);
                this.lbl03_ActualStateResult.SetValue("");
                this.lbl03_ExpirationDateResult.SetValue("");
                this.lbl03_StateAfterExpirationResult.SetValue("");

                _CRT_DATE = "";
                _CRT_TIME = "";

                grd02.InitializeDataSource();

                this.lbl00_DataMode.Value = "Not Selected";
                this.lbl00_DataMode.BackColor = System.Drawing.Color.LightGray;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();

                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("VENDCD", this.cdx01_VENDCD.GetValue().ToString());
                paramSet.Add("INSPECTION_LEVEL", this.cbo01_INSPECTION_LEVEL.GetValue().ToString());
                paramSet.Add("VINCD", this.cdx01_VINCD.GetValue().ToString());
                paramSet.Add("PLANT_DIV", this.cbo01_PLANT_DIV.GetValue().ToString());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.BtnReset_Click(null, null);
                this.grd01.SetValue(source);
                this.setColorGrd1();
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

        private void setColorGrd1()
        {
            for (int i = 0; i < this.grd01.Rows.Count; i++)
            {
                switch (this.grd01.Rows[i]["ZINSPECTION_LEVEL"].ToString())
                {
                    case "1":
                        this.grd01.Rows[i].Style = CS1;
                        break;
                    case "2":
                        this.grd01.Rows[i].Style = CS2;
                        break;
                    default:
                        this.grd01.Rows[i].Style = CS3;
                        break;
                }
            }
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("PARTNO", this.cdx02_PARTNO.GetValue().ToString());
                paramSet.Add("CRT_DATE", this._CRT_DATE);
                paramSet.Add("CRT_TIME", this._CRT_TIME);
                paramSet.Add("APP_DATE", this.dte02_APP_DATE.GetDateText().ToString());
                paramSet.Add("INSPECTION_LEVEL", this.cbo02_INSPECTION_LEVEL_NEW.GetValue().ToString());
                paramSet.Add("PLANT_DIV", this.cbo02_PLANT_DIV.GetValue().ToString());
                paramSet.Add("DESCRIPTION", this.txt02_DESCRIPTION.GetValue().ToString());
                paramSet.Add("C_VISUAL", (this.chk02_C_VISUAL.GetValue().ToString().Equals("Y") ? "1" : "0"));
                paramSet.Add("C_DIMENSION", (this.chk02_C_DIMENSION.GetValue().ToString().Equals("Y") ? "1" : "0"));
                paramSet.Add("C_FUNCTION", (this.chk02_C_FUNCTION.GetValue().ToString().Equals("Y") ? "1" : "0"));
                paramSet.Add("C_ATEST", (this.chk02_C_ATEST.GetValue().ToString().Equals("Y") ? "1" : "0"));
                paramSet.Add("EXPIRATION_PERIOD", this.cbo02_EXPIRATION_PERIOD.GetValue().ToString());
                paramSet.Add("INSPECTION_LEVEL_OLD", this.cbo02_INSPECTION_LEVEL.GetValue().ToString());

                if (!IsSaveValid()) return;

                this.BeforeInvokeServer(true);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), paramSet);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("저장되었습니다.");
                MsgCodeBox.Show("CD00-0071");
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();

                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("CRT_DATE", this._CRT_DATE);
                paramSet.Add("CRT_TIME", this._CRT_TIME);
                paramSet.Add("PARTNO", this.cdx02_PARTNO.GetValue().ToString());

                if (!IsDeleteValid(null)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Remove(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), paramSet);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                //this.BtnReset_Click(null, null);

                //MsgBox.Show("삭제 되었습니다.");
                MsgCodeBox.Show("CD00-0072");
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

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd01.SelectedRowIndex;

                if (Row > 0)
                {
                    this.BtnReset_Click(null, null);
                    this.lbl00_DataMode.Value = "New Mode";
                    this.lbl00_DataMode.BackColor = System.Drawing.Color.Orange;

                    this.cdx02_PARTNO.SetValue(this.grd01.GetValue(Row, "PARTNO").ToString());
                    this.cdx02_VINCD.SetValue(this.grd01.GetValue(Row, "VINCD").ToString());
                    this.cdx02_VENDCD.SetValue(this.grd01.GetValue(Row, "VENDCD").ToString());
                    this.cbo02_INSPECTION_LEVEL.SetValue(this.grd01.GetValue(Row, "ZINSPECTION_LEVEL").ToString());
                    this.cbo02_PLANT_DIV.SetValue(this.grd01.GetValue(Row, "PLANT_DIV").ToString());

                    // New Mode
                    try
                    {
                        this.BeforeInvokeServer(true);

                        HEParameterSet paramSet = new HEParameterSet();

                        paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                        paramSet.Add("PARTNO", this.grd01.GetValue(Row, "PARTNO").ToString());
                        paramSet.Add("LANG_SET", this.UserInfo.Language);


                        //DataSet source = _WSCOM.Inquery(paramSet);
                        DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_HISTORY"), paramSet);

                        //this.AfterInvokeServer();

                        this.grd02.SetValue(source);

                        this.setColorGrd2();
                        this.txt02_DESCRIPTION.Focus();

                    }
                    catch (FaultException<ExceptionDetail> ex)
                    {
                        this.AfterInvokeServer();
                        throw ex;
                    }
                    finally
                    {
                        this.AfterInvokeServer();
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void setColorGrd2()
        {
            for (int i = 0; i < this.grd02.Rows.Count; i++)
            {
                switch (this.grd02.Rows[i]["INSPECTION_LEVEL"].ToString())
                {
                    case "1":
                        this.grd02.Rows[i].Style = CS1;
                        break;
                    case "2":
                        this.grd02.Rows[i].Style = CS2;
                        break;
                    default:
                        this.grd02.Rows[i].Style = CS3;
                        break;
                }
            }
        }

        private void grd02_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int Row = this.grd02.SelectedRowIndex;

                if (Row >= this.grd02.Rows.Fixed)
                {
                    try
                    {
                        this.BeforeInvokeServer(true);

                        // Modify Mode
                        this.cbo02_INSPECTION_LEVEL_NEW.Visible = false;
                        this.lbl02_INSPECTION_LEVEL_NEW.Visible = false;
                        this.cbo02_INSPECTION_LEVEL.SetReadOnly(false);

                        _CRT_DATE = this.grd02.GetValue(Row, "CRT_DATE").ToString();
                        _CRT_TIME = this.grd02.GetValue(Row, "CRT_TIME").ToString();

                        this.cbo02_PLANT_DIV.SetValue(this.grd02.GetValue(Row, "PLANT_DIV").ToString());
                        this.txt02_DESCRIPTION.SetValue(this.grd02.GetValue(Row, "DESCRIPTION").ToString());
                        this.cbo02_INSPECTION_LEVEL.SetValue(this.grd02.GetValue(Row, "INSPECTION_LEVEL").ToString());
                        this.cbo02_EXPIRATION_PERIOD.SetValue(this.grd02.GetValue(Row, "EXPIRATION_PERIOD").ToString());

                        this.chk02_C_VISUAL.SetValue(this.grd02.GetValue(Row, "C_VISUAL").ToString());
                        this.chk02_C_DIMENSION.SetValue(this.grd02.GetValue(Row, "C_DIMENSION").ToString());
                        this.chk02_C_FUNCTION.SetValue(this.grd02.GetValue(Row, "C_FUNCTION").ToString());
                        this.chk02_C_ATEST.SetValue(this.grd02.GetValue(Row, "C_ATEST").ToString());

                        this.lbl03_ActualStateResult.SetValue(this.grd02.GetValue(Row, "INSPECTION_LEVELNM").ToString());
                        this.lbl03_StateAfterExpirationResult.SetValue(this.grd02.GetValue(Row, "INSPECTION_LEVEL_OLDNM").ToString());

                        if (this.grd02.GetValue(Row, "EXPIRATION_DATE").ToString() != "")
                        {
                            // Temppory  Format Translate Dummy
                            dte02_APP_DATE.SetValue(this.grd02.GetValue(Row, "EXPIRATION_DATE").ToString());
                            this.lbl03_ExpirationDateResult.SetValue(dte02_APP_DATE.Text.ToString());
                        }

                        // APP_Date RealData Setting
                        this.dte02_APP_DATE.SetValue(this.grd02.GetValue(Row, "APP_DATE").ToString());

                        this.lbl00_DataMode.Value = "Modify Mode";
                        this.lbl00_DataMode.BackColor = System.Drawing.Color.LightBlue;

                        this.txt02_DESCRIPTION.Focus();

                        // this._CRT_DATE = this.grd01.GetValue(Row, "CRT_DATE").ToString();
                    }
                    catch (FaultException<ExceptionDetail> ex)
                    {
                        this.AfterInvokeServer();
                        throw ex;
                    }
                    finally
                    {
                        this.AfterInvokeServer();
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [유효성 검사]

        private bool IsSaveValid()
        {
            if (this.GetByteCount(this.cdx02_PARTNO.GetValue().ToString()) == 0)
            {
                //MsgBox.Show("차종 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_PARTNO.Text);
                return false;
            }

            if (this.GetByteCount(this.cbo02_PLANT_DIV.GetValue().ToString()) == 0)
            {
                //MsgBox.Show("차종 입력되지 않았습니다.");
                MsgCodeBox.ShowFormat("QA00-001", this.lbl02_PLANT_DIV.Text);
                return false;
            }

            if (string.IsNullOrEmpty(_CRT_DATE))
            {
                // New Mode 
                if (this.GetByteCount(this.cbo02_INSPECTION_LEVEL_NEW.GetValue().ToString()) == 0)
                {
                    //MsgBox.Show("바디번호 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_INSPECTION_LEVEL_NEW.Text);
                    return false;
                }
            }
            else
            {
                // Update Mode
                if (this.GetByteCount(this.cbo02_INSPECTION_LEVEL.GetValue().ToString()) == 0)
                {
                    //MsgBox.Show("바디번호 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.lbl02_INSPECTION_LEVEL.Text);
                    return false;
                }
            }

                   
            try
            {
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (this.GetByteCount(_CRT_DATE) == 0)
                {
                    //삭제할 데이터를 선택 하지 않았습니다.
                    MsgCodeBox.Show("QA01-0015");
                    return false;
                }

                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                return true;

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        #endregion

        private void grd01_AfterSort(object sender, SortColEventArgs e)
        {
            this.setColorGrd1();
        }

        private void grd02_AfterSort(object sender, SortColEventArgs e)
        {
            this.setColorGrd2();
        }

        private void grd01_Click(object sender, EventArgs e)
        {

        }

    }
}
