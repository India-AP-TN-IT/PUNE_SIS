#region ▶ Description & History
/* 
 * 프로그램명 : 자재 입하 등록
 * 설      명 : 
 * 최초작성자 : 김민재
 * 최초작성일 : 2015-02-04
 * 최종수정자 : 김민재
 * 최종수정일 : 2015-02-04
 * 수정  내용 : 
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-02-04		김민재		최초 개발
*/
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.ServiceModel;
using TheOne.ServiceModel;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;

using System.Drawing;
using Ax.DEV.Utility.Controls;
using HE.Framework.Core;
using HE.Framework.Core.Report;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// 자재출하요청승인 및 출하지시서발행
    /// </summary>    
    public partial class WM20420 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;        

        private AxComboList grd_LINECD;
        private AxComboList grd_PARTNO;

        private DateTime _tmpDELI_DATE;
        private bool _isSelectedIndexChangedDirectly = true;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;

        private const string _IntFormat = "###,###,###,###,##0";

        public WM20420()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
            this.grd_PARTNO = new AxComboList();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(true);

                this._tmpDELI_DATE = Convert.ToDateTime(this.dte01_REQ_DATE.GetDateText());
                //this.grd_PARTNO.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_PARTNO_BeforeOpen);

                HEParameterSet paramSet_OUT_DIV = new HEParameterSet();
                paramSet_OUT_DIV.Add("CORCD", _CORCD);
                paramSet_OUT_DIV.Add("BIZCD", _BIZCD);
                paramSet_OUT_DIV.Add("LANG_SET", _LANG_SET);
                DataSet combo_source_OUT_DIV = _WSCOM.ExecuteDataSet("APG_WM20420.INQUERY_OUT_DIV", paramSet_OUT_DIV);

                //this.cbo01_MAT_TYPE.DataBindCodeName("EA", false);
                HEParameterSet param = new HEParameterSet();
                //param.Add("CORCD", this.UserInfo.CorporationCode);
                param.Add("BIZCD", this.UserInfo.BusinessCode);

                DataSet source = GetTypeCode("EK");
                //cbo01_DOM_IMP.DataBindCodeName(source.Tables[0], false, true);

                #region [ grd01 ]

                this.grd_PARTNO.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_PARTNO_BeforeOpen);
                this.grd_PARTNO.SelectedValueChanged += new EventHandler(grd_PARTNO_SelectedValueChanged);

                this.grd01.AllowEditing = true;
                this.grd01.AutoClipboard = true;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AllowSorting = AllowSortingEnum.None;
                //this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "법인", "CORCD");
                //this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "선택", "SEL_CHECK", "CHK");
                //this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "요청일자", "REQ_DATE", "REQ_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "요청위치번호", "REQ_GRP", "REQ_GRP");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "P/NO", "PARTNO", "PARTNO");
                //this.grd01.Cols["PARTNO"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "PARTNM", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "요청순번", "REQ_SEQ", "REQ_SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "요청박스수량", "REQ_BOX_QTY", "REQ_BOX_QTY");
                //this.grd01.Cols["REQ_BOX_QTY"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "요청수량", "REQ_QTY", "REQ_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "재고수량", "INV_QTY1", "INV_QTY1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "요청일시", "REQ_TIME", "REQ_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "자재 RACK 위치번호", "LOCATION_NO", "LOCATION_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "출하지시서 번호", "NOTE_NO", "NOTE_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "발행차수", "PRINT_SEQ", "PRINT_SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "바코드 번호", "BARCODE", "BARCODE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "발행자 사번", "PRINT_USER_ID", "PRINT_USER_ID");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "발행일자", "PRINT_DATE", "PRINT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "발행일시", "PRINT_TIME", "PRINT_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "출고구분", "OUT_DIV", "OUT_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "AREA", "AREACD", "AREACD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "PRINT", "PRINT_YN", "PRINT_YN");
                //this.grd01.Cols["OUT_DIV"].Style.BackColor = Color.FromArgb(208, 253, 248);

                this.grd01.Cols["PARTNO"].Editor = grd_PARTNO;

                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_OUT_DIV.Tables[0], "OUT_DIV");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "SEL_CHECK");

                this.grd01.Cols["REQ_BOX_QTY"].Format = _IntFormat;
                this.grd01.Cols["REQ_QTY"].Format = _IntFormat;
                this.grd01.Cols["INV_QTY1"].Format = _IntFormat;

                this.grd01.Cols["REQ_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "REQ_DATE");
                this.grd01.Cols["PRINT_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PRINT_DATE");

                //this.grd01.Cols["OUT_DIV"].Style.BackColor = System.Drawing.Color.LightYellow;
                //this.grd01.Cols["GAP_QTY"].Style.BackColor = System.Drawing.Color.LightYellow;

                this.grd01.CurrentContextMenu.Items[0].Visible = false;
                this.grd01.CurrentContextMenu.Items[1].Visible = false;
                this.grd01.CurrentContextMenu.Items[2].Visible = false;
                this.grd01.CurrentContextMenu.Items[3].Visible = false;

                //전체선택 체크박스
                CellStyle cs = this.grd01.Styles.Add("Boolean");
                cs.DataType = typeof(Boolean);
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;
                //this.grd01.SetCellStyle(0, this.grd01.Cols["SEL_CHECK"].Index, cs);

                this.SetRequired(this.lbl01_BIZNM, this.lbl01_REQ_DATE, this.lbl01_PRINT_SEQ1);
                this.grd01.Cols["PARTNO"].Editor = this.grd_PARTNO;

                //this.BtnQuery_Click(null, null);   
                //rdo01_REPRINT_CheckedChanged(null, null); 
                //Bind_cbo01_PRINT_SEQ();
                this.Bind_cbo01_PRINT_SEQ();
                this.BtnQuery_Click(null, null);   

                #endregion

                DataTable combo_source_AREACD = new DataTable();
                combo_source_AREACD.Columns.Add("CODE");
                combo_source_AREACD.Columns.Add("NAME");
                combo_source_AREACD.Rows.Add("M00", "M00 : KD Material Area");
                combo_source_AREACD.Rows.Add("M01", "M01 : LOCAL Material Area");
                this.cbo01_AREACD.DataBind(combo_source_AREACD, false);
                this.cbo01_AREACD.DropDownStyle = ComboBoxStyle.DropDownList;

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
        //        string chasu = "0";
        //        string bizcd = this.cbo01_BIZCD.GetValue().ToString();

        //        chasu = this.GetLastChasu();
        //        //chasu = this.GetLastChasu();

        //        DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.All,
        //            "SEL_CHECK", "BIZCD", "REQ_DATE", "REQ_GRP", "PARTNO", "REQ_SEQ", "PRINT_SEQ", "NOTE_NO", "EMPNO", "LANG_SET");

        //        foreach (DataRow row in set.Tables[0].Rows)
        //        {
        //            row["BIZCD"] = row["BIZCD"].ToString();
        //            row["REQ_DATE"] = row["REQ_DATE"].ToString();
        //            row["REQ_GRP"] = row["REQ_GRP"].ToString();
        //            row["PARTNO"] = row["PARTNO"].ToString();
        //            row["REQ_SEQ"] = row["REQ_SEQ"].ToString();                    
        //            row["PRINT_SEQ"] = chasu;
        //            row["NOTE_NO"] = row["NOTE_NO"].ToString();
        //            row["EMPNO"] = this.UserInfo.EmpNo;
        //            row["LANG_SET"] = this.UserInfo.Language;                    
        //            //chasu.ToString();
        //            //this.GetLastChasu();
        //            //this.GetLastChasu();
        //            //this.GetLastChasu(paramSet);
        //            ////this.UserInfo.EmpNo;
        //        }

        //        for (int i = set.Tables[0].Rows.Count - 1; i > -1; i--)
        //        {
        //            if (set.Tables[0].Rows[i]["SEL_CHECK"].ToString().Equals("N"))
        //                set.Tables[0].Rows.RemoveAt(i);
        //        }

        //        set.Tables[0].Columns.Remove("SEL_CHECK");

        //        if (!this.IsSaveValid(set)) return;
        //        this.BeforeInvokeServer(true);    //저장메시지

        //        //_WSCOM.ExecuteNonQueryTx("APG_WM20160.DATA_REMOVE", set);

        //        _WSCOM.ExecuteNonQueryTx("APG_WM20420.INSERT_CHK1", set);

        //        this.AfterInvokeServer();

        //        this.Bind_cbo01_PRINT_SEQ();   //차수 재조정
        //        this.BtnQuery_Click(null, null);

        //        //MsgBox.Show("입력하신 차종별 사용표 정보를 저장하였습니다.");
        //        //저장되었습니다.
        //        MsgCodeBox.Show("CD00-0071");
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        this.AfterInvokeServer();
        //    }
        //}

        private void Btn_Save1_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                             "SEL_CHECK", "BIZCD", "REQ_DATE", "REQ_GRP", "PARTNO", "REQ_BOX_QTY", "OUT_DIV", "CORCD", "EMPNO", "LANG_SET");

                foreach (DataRow row in set.Tables[0].Rows)
                {
                    row["BIZCD"] = row["BIZCD"].ToString(); ;
                    row["REQ_DATE"] = row["REQ_DATE"].ToString();
                    row["REQ_GRP"] = row["REQ_GRP"].ToString();
                    row["PARTNO"] = row["PARTNO"].ToString();
                    row["REQ_BOX_QTY"] = row["REQ_BOX_QTY"].ToString();
                    row["OUT_DIV"] = row["OUT_DIV"].ToString();                  
                    row["CORCD"] = this.UserInfo.CorporationCode;
                    row["EMPNO"] = this.UserInfo.EmpNo;
                    row["LANG_SET"] = this.UserInfo.Language;
                }

                for (int i = set.Tables[0].Rows.Count - 1; i > -1; i--)
                {
                    if (set.Tables[0].Rows[i]["SEL_CHECK"].ToString().Equals("N"))
                        set.Tables[0].Rows.RemoveAt(i);
                }

                string val = this.grd01.GetValue(0, "SEL_CHECK").ToString();

                set.Tables[0].Columns.Remove("SEL_CHECK");

                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx("APG_WM20420.SAVE_ADD", set);

                this.AfterInvokeServer();

                this.cbo01_PRINT_SEQ.Text = "NEW";
                  
                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 자료가 저장되었습니다.");
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
        
        //protected override void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
        //                      "SEL_CHECK", "BIZCD", "REQ_DATE", "REQ_GRP", "PARTNO", "REQ_SEQ", "NOTE_NO", "OUT_DIV", "CORCD", "EMPNO", "LANG_SET");

        //        foreach (DataRow row in set.Tables[0].Rows)
        //        {
        //            row["BIZCD"] = row["BIZCD"].ToString(); ;
        //            row["REQ_DATE"] = row["REQ_DATE"].ToString();
        //            row["REQ_GRP"] = row["REQ_GRP"].ToString();
        //            row["PARTNO"] = row["PARTNO"].ToString();
        //            row["NOTE_NO"] = row["NOTE_NO"].ToString();
        //            row["OUT_DIV"] = row["OUT_DIV"].ToString();
        //            row["CORCD"] = this.UserInfo.CorporationCode;
        //            row["EMPNO"] = this.UserInfo.EmpNo;
        //            row["LANG_SET"] = this.UserInfo.Language;
        //        }

        //        //for (int i = set.Tables[0].Rows.Count - 1; i > -1; i--)
        //        //{
        //        //    if (set.Tables[0].Rows[i]["SEL_CHECK"].ToString().Equals("D"))
        //        //        set.Tables[0].Rows.RemoveAt(i);
        //        //}

        //        string val = this.grd01.GetValue(0, "SEL_CHECK").ToString();

        //        set.Tables[0].Columns.Remove("SEL_CHECK");

        //        if (!this.IsRemoveValid(set)) return;
        //        this.BeforeInvokeServer(true);

        //        _WSCOM.ExecuteNonQueryTx("APG_WM20420.REMOVE", set);

        //        this.AfterInvokeServer();

        //        this.BtnQuery_Click(null, null);

        //        //MsgBox.Show("선택하신 자료가 삭제되었습니다");
        //        //삭제되었습니다.
        //        MsgCodeBox.Show("CD00-0072");
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        this.AfterInvokeServer();
        //    }
        //}

        private string GetLastChasu()  //차수발생
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("REQ_DATE", this.dte01_REQ_DATE.GetDateText());
                set.Add("LANG_SET", this.UserInfo.Language);

                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20420.INQUERY_LAST_CHA", set);

                //return source.Tables[0].ToString();
                //return source.Tables["PRINT_SEQ1"].ToString();
                //return HEStaticCommon.Nvl(this.Text, "").ToString();
                //return source.ToString();
                //return ToString(source.Tables[0]);
                return source.Tables[0].Rows[0]["PRINT_SEQ"].ToString();
            }



            //    if (ds.Tables[0].Rows.Count > 0)
            //    return ds.Tables[0].Rows[0]["DELI_CNT"].ToString();
            //else
            //    return "";

            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return "";
            }
        }

        private void grd01_MouseClick(object sender, MouseEventArgs e)
        {
            //전체선택 체크박스 선택시 해당 선택값에 따라 모든 체크박스 업데이트 2013.10.28 (배명희)
            if (this.grd01.MouseRow == 0)
            {
                string val = this.grd01.GetValue(0, "SEL_CHECK").ToString();
                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    this.grd01.SetValue(i, "SEL_CHECK", val == "Y" ? "1" : "0");
                }
            }
        }

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                {
                    this.grd01.SetValue(i, "BIZCD", this.UserInfo.BusinessCode);  
                    this.grd01.SetValue(i, "REQ_DATE", DateTime.Now.ToString("yyyy-MM-dd"));

                    this.grd01.SetValue(i, "REQ_BOX_QTY", "1");       
                    //this.grd01.SetValue(i, "REQ_SEQ", "1");       
                    //this.grd01.SetValue(i, "REQ_QTY", "1");                      
                    this.grd01.SetValue(i, "REQ_TIME", DateTime.Now.ToString("HHmm"));
                    this.grd01.SetValue(i, "OUT_DIV", "ETC");
                  
                    //DataTable combo_source_OUT_DIV = new DataTable();
                    //combo_source_OUT_DIV.Columns.Add("CODE");
                    //combo_source_OUT_DIV.Columns.Add("NAME");
                    //combo_source_OUT_DIV.Rows.Add("N", "NOMAL");
                    //combo_source_OUT_DIV.Rows.Add("R", "RESALE");
                    //combo_source_OUT_DIV.Rows.Add("E", "ETC");
                    //this.grd01.SetValue(i, combo_source_OUT_DIV, false);
                    //this.grd01.DropDownStyle = ComboBoxStyle.DropDownList;

                  
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_PARTNO_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ////품번
            //HEParameterSet set = new HEParameterSet();
            //set.Add("LANG_SET", this.UserInfo.Language);

            ////품목코드
            //DataTable source = _WSCOM.ExecuteDataSet("APG_WMCOMMON.INQUERY_COMBO_RESPARTNO", set).Tables[0];
            ////this.grd_PARTNO.DataBind(source, "PARTNO", "PARTNO", "품번;품명", "L;L");
            //this.grd_PARTNO.DataBind(source, "PARTNO", "PARTNO", GetLabel("PARTNOTITLE") + ";" + GetLabel("PARTNONM"), "L;L");

            try
            {
                int row = this.grd01.SelectedRowIndex;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                //set.Add("PRDT_DIV", this.cbo01_PRDT_DIV.GetValue());
                set.Add("PRDT_DIV", "A0A");    //A0A : 완제품, A0S : 반제품
                set.Add("TYPECD", "");
                set.Add("LINECD", "");
                set.Add("LANG_SET", this.UserInfo.Language);

                DataTable source = _WSCOM.ExecuteDataSet("APG_WM20420.INQUERY_INSPEC_PARTNO", set).Tables[0];

                this.grd_PARTNO.DataBind(source, "PARTNO", "PARTNO", GetLabel("PARTNOTITLE") + ";" + GetLabel("PARTNONM"), "L;L");               
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_PARTNO_SelectedValueChanged(object sender, EventArgs e)
        {
            int row = this.grd01.SelectedRowIndex;

            this.grd01.SetValue(row, "PARTNM", this.grd_PARTNO.GetValue("PARTNM"));

            ////차종
            //HEParameterSet set = new HEParameterSet();
            //set.Add("CORCD", this.UserInfo.CorporationCode);
            //set.Add("BIZCD", this.UserInfo.BusinessCode);
            //set.Add("PRDT_DIV", "A0A");
            //set.Add("LANG_SET", this.UserInfo.Language);

            //// 차종코드
            //DataTable source = _WSCOM.ExecuteDataSet("APG_WMCOMMON.INQUERY_CAR_TYPE", set).Tables[0];

            //if (source.Rows.Count == 0) return;

            //this.grd01.SetValue(row, "CAR_TYPE", source.Rows[0]["OBJECT_NM"].ToString());
        }

        private void grd01_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                this.GridCell_Changed(e);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void GridCell_Changed(C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                if (e.Row >= this.grd01.Rows.Fixed)
                {
                    if (e.Col == this.grd01.Cols["PARTNO"].Index)
                    {
                        this.grd01.SetValue(e.Row, "SEL_CHECK", "1");    //MM23011
                    }
                }                
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
                //if (this.cbl01_VINCD.GetValue().ToString().Length == 0)
                //{
                //    //MsgBox.Show("{차종}을 선택하세요");
                //    //{0}이(가) 선택되지 않았습니다.
                //    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("VEHICLE"));
                //    return;
                //}

                //string print_seq1 = null;
                if(this._isSelectedIndexChangedDirectly == false)
                this.Bind_cbo01_PRINT_SEQ();

                HEParameterSet set = new HEParameterSet();                
                //DataSet source = null;

                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("REQ_DATE", this.dte01_REQ_DATE.GetDateText());
                set.Add("AREACD", this.cbo01_AREACD.GetValue());
                set.Add("PRINT_SEQ", this.cbo01_PRINT_SEQ.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                if (rdo01_PRINT.Checked)
                {                    
                    DataSet source = _WSCOM.ExecuteDataSet("APG_WM20420.INQUERY1", set);
                    this.AfterInvokeServer();
                    //this.grd01.SetValue(source.Tables[0]);
                    this.grd01.SetValue(source);
                    this.ShowDataCount(source);

                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        //if (source.Tables[0].Rows[i]["LOTNO"].ToString().Equals("Sub Total"))
                        //    this.grd01.Rows[i + this.grd02.Rows.Fixed].StyleNew.BackColor = Color.LemonChiffon;

                        if (source.Tables[0].Rows[i]["INV_QTY1"].ToString().Equals("0"))
                            //this.grd01.Rows[i + this.grd02.Rows.Fixed].StyleNew.BackColor = Color.LawnGreen;
                            this.grd01.Rows[i+1].StyleNew.BackColor = Color.Red;
                    }
                }
                else
                {                    
                    DataSet source = _WSCOM.ExecuteDataSet("APG_WM20420.INQUERY2", set);
                    this.AfterInvokeServer();
                    //this.grd01.SetValue(source.Tables[0]);
                    this.grd01.SetValue(source);
                    this.ShowDataCount(source);

                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        //if (source.Tables[0].Rows[i]["LOTNO"].ToString().Equals("Sub Total"))
                        //    this.grd01.Rows[i + this.grd02.Rows.Fixed].StyleNew.BackColor = Color.LemonChiffon;

                        if (source.Tables[0].Rows[i]["INV_QTY1"].ToString().Equals("0"))
                            //this.grd01.Rows[i + this.grd02.Rows.Fixed].StyleNew.BackColor = Color.LawnGreen;
                            this.grd01.Rows[i+1].StyleNew.BackColor = Color.Red;
                    }
                }

                //this.grd01.SetValue(source);
                //this.ShowDataCount(source);

                //if (Convert.ToString(this.cbo01_PRINT_SEQ.GetValue()) == "0")
                //{
                //    DataSet source = _WSCOM.ExecuteDataSet("APG_WM20420.INQUERY1", set);
                //    this.grd01.SetValue(source.Tables[0]);
                //}
                //else
                //{
                //    if (Convert.ToString(this.cbo01_PRINT_SEQ.GetValue()) == "NEW")
                //    {
                //        set.Add("PRINT_SEQ", 0);
                //        DataSet source = _WSCOM.ExecuteDataSet("APG_WM20420.INQUERY2", set);
                //        this.grd01.SetValue(source.Tables[0]);
                //    }
                //    else
                //    {
                //        set.Add("PRINT_SEQ", this.cbo01_PRINT_SEQ.GetValue());
                //        DataSet source = _WSCOM.ExecuteDataSet("APG_WM20420.INQUERY2", set);
                //        this.grd01.SetValue(source.Tables[0]);
                //    }
                //}

                //this.Bind_cbo01_PRINT_SEQ();   //차수 재조정



                //DataSet source = _WSCOM.ExecuteDataSet("APG_WM20420.INQUERY1", set, "OUT_CURSOR");
                //DataSet source = _WSCOM.ExecuteDataSet("APG_WM20420.INQUERY", set);

                //this.AfterInvokeServer();

                //this.grd01.SetValue(source.Tables[0]);
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

        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            //if (this.cbo01_PRINT_SEQ.GetValue().ToString() == "NEW")
            //{
            //    //MsgBox.Show("{차종}을 선택하세요");
            //    //{0}이(가) 선택되지 않았습니다.
            //    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("PRINT_SEQ1"));
            //    return;
            //}

            HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
            //report.ReportName = "RxRpt/Sample20040";  // Report ID path included (extension .reb excluded) ** Note ** The report contains resource files that you specify in the Build Properties window, and then design work.
            report.ReportName = "RxRpt/WM20420_R1";

            //string url = "D:\\project\\hanileh_POLAND\\HE_ERM\\HE.Sample\\UI\\HE.ERM.Sample.UI\\RxRpt";
            string url = "C:\\Work\\HE_ERM\\HE.ERM\\PD\\UI\\HE.ERM.PD.UI\\";     //XML 경로  
            //string url = "E:\\HANIL_MEXICO\\HE_ERM\\HE.ERM\\PD\\UI\\HE.ERM.PD.UI\\";     //XML 경로  

            
            // Main Section (main report parameter set)
            HERexSection mainSection = new HERexSection();
            mainSection.ReportParameter.Add("PRINT_USER", this.UserInfo.UserID + "(" + this.UserInfo.UserName + ")");
            mainSection.ReportParameter.Add("TEST_PARAM1", "파라메터1");
            mainSection.ReportParameter.Add("TEST_PARAM2", "파라메터2");
            report.Sections.Add("MAIN", mainSection);

            // XML Section (data connection persons) / Parameter: Data set, the report Param (sub-report in the presence of Param)
            HEParameterSet param = new HEParameterSet();
            param.Add("CORCD", this.UserInfo.CorporationCode);
            param.Add("BIZCD", this.UserInfo.BusinessCode);
            param.Add("REQ_DATE", this.dte01_REQ_DATE.Value.ToString("yyyy-MM-dd"));      //신청일자
            param.Add("AREACD", this.cbo01_AREACD.GetValue());                          //AREA
            param.Add("PRINT_SEQ", this.cbo01_PRINT_SEQ.GetValue());                    //차수
            param.Add("EMPNO", this.UserInfo.EmpNo);
            param.Add("LANG_SET", this.UserInfo.Language);

            /* 
                * New report or report columns for design changes when columns defined XML files are calling upon reports
                * To use the generated directly by using the code (note, please produce the following xml file and creates a file reb first sub-report)
                * Parry who, if the name of the DataSet object ds
                * ds.Tables[0].TableName = "DATA";
                * ds.Tables[0].WriteXml(url + "/" + report.ReportName + ".xml", XmlWriteMode.WriteSchema);
                * Please include the generated XML file is added or modified Shimada source control design for future maintenance. (/ url under the folder)
                * */

            //DataSet ds = (new Framework.ServiceModel.AxClientProxy()).ExecuteDataSet(string.Format("{0}.{1}", "APG_WM20420", "INQUERY_PRINT2"), param);



            if (rdo01_PRINT.Checked)
            {
                DataSet ds = (new HE.Framework.ServiceModel.AxClientProxy()).ExecuteDataSet(string.Format("{0}.{1}", "APG_WM20420", "INQUERY_PRINT1"), param);
                HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());

                report.Sections.Add("XML", xmlSection); // If the Add, multiple connections are in the same section to specify the connection name and file a report specifying multiple connections

                AxRexpertReportViewer.ShowReport(report);

                this.Bind_cbo01_PRINT_SEQ();
                this.BtnQuery_Click(null, null);
            }
            else
            {
                DataSet ds = (new HE.Framework.ServiceModel.AxClientProxy()).ExecuteDataSet(string.Format("{0}.{1}", "APG_WM20420", "INQUERY_PRINT2"), param);
                HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());

                report.Sections.Add("XML", xmlSection); // If the Add, multiple connections are in the same section to specify the connection name and file a report specifying multiple connections

                AxRexpertReportViewer.ShowReport(report);

                //this.Bind_cbo01_PRINT_SEQ();
                //this.BtnQuery_Click(null, null);

                //ds.Tables[0].TableName = "DATA";
                //ds.Tables[0].WriteXml(url + "/" + report.ReportName + ".xml", XmlWriteMode.WriteSchema);

                //AxRexpertReportViewer.ShowReport(report);

                //this.Bind_cbo01_PRINT_SEQ();
                //this.BtnQuery_Click(null, null);
            }



            //ds.Tables[0].TableName = "DATA";
            //ds.Tables[0].WriteXml(url + "/" + report.ReportName + ".xml", XmlWriteMode.WriteSchema);

            //HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());

            //report.Sections.Add("XML", xmlSection); // If the Add, multiple connections are in the same section to specify the connection name and file a report specifying multiple connections
            
            //AxRexpertReportViewer.ShowReport(report);

        }


        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                //this.txt01_REQ_GRP.Initialize();               
                this.grd01.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        #endregion

        #region [ 기타 컨트롤들에 대한 이벤트 정의 ]

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Bind_cbo01_PRINT_SEQ();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void dte01_DELI_DATE_CloseUp(object sender, EventArgs e)
        {
            try
            {
                if (this._tmpDELI_DATE != Convert.ToDateTime(this.dte01_REQ_DATE.GetValue()))
                {
                    this._tmpDELI_DATE = Convert.ToDateTime(this.dte01_REQ_DATE.GetValue());
                    this.Bind_cbo01_PRINT_SEQ();
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void dte01_DELI_DATE_Leave(object sender, EventArgs e)
        {
            try
            {
                if (this._tmpDELI_DATE != Convert.ToDateTime(this.dte01_REQ_DATE.GetValue()))
                {
                    this._tmpDELI_DATE = Convert.ToDateTime(this.dte01_REQ_DATE.GetValue());
                    this.Bind_cbo01_PRINT_SEQ();
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void cdx01_VENDCD_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Bind_cbo01_PRINT_SEQ();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void cbo01_MAT_TYPE_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //this.Bind_cbo01_PRINT_SEQ();

                //if (Convert.ToString(this.cbo01_MAT_TYPE.GetValue()) == "EAR")
                //    this.btn01_REG_RESALE.SetReadOnly(false);
                //else
                //    this.btn01_REG_RESALE.SetReadOnly(true);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void cbo01_YARDCD_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.Bind_cbo01_PRINT_SEQ();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void cbo01_PRINT_SEQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.cbo01_PRINT_SEQ.GetValue().ToString() == "NEW")
                //{
                //    this.grd01.Cols["SEL_CHECK"].Visible = true;
                //}
                //else
                //{
                //    this.grd01.Cols["SEL_CHECK"].Visible = false;
                //}

                if (this._isSelectedIndexChangedDirectly)
                {
                    this.BtnQuery_Click(null, null);
                }
                else
                {
                    this._isSelectedIndexChangedDirectly = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                this.GridCell_Changed(e);

                //if (this.grd01.Cols[e.Col].Name == "DEF_QTY" || this.grd01.Cols[e.Col].Name == "GAP_QTY")
                //{
                //    int tmpDELI_QTY = int.TryParse(Convert.ToString(this.grd01.GetData(e.Row, "DELI_QTY")), out tmpDELI_QTY) ? tmpDELI_QTY : 0;
                //    int tmpDEF_QTY = int.TryParse(Convert.ToString(this.grd01.GetData(e.Row, "DEF_QTY")), out tmpDEF_QTY) ? tmpDEF_QTY : 0;
                //    int tmpGAP_QTY = int.TryParse(Convert.ToString(this.grd01.GetData(e.Row, "GAP_QTY")), out tmpGAP_QTY) ? tmpGAP_QTY : 0;
                //    int tmpARRIV_QTY = int.TryParse(Convert.ToString(this.grd01.GetData(e.Row, "ARRIV_QTY")), out tmpARRIV_QTY) ? tmpARRIV_QTY : 0;

                //    this.grd01.SetData(e.Row, "ARRIV_QTY", tmpDELI_QTY - tmpDEF_QTY - tmpGAP_QTY);

                //    if (this.grd01.Cols[e.Col].Name == "GAP_QTY")
                //    {
                //        int nextRowIndex = e.Row == this.grd01.Rows.Count - 1 ? e.Row : e.Row + 1;
                //        int nextColIndex = this.grd01.Cols["DEF_QTY"].Index - 1;
                //        this.grd01.Select(nextRowIndex, nextColIndex);
                //    }
                //}
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void btn01_REG_RESALE_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region [ 유효성 체크 ]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 계측항목 정보가 존재하지 않습니다.");
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    string PARTNO = this.grd01.GetValue(i, "PARTNO").ToString();
                    string REQ_BOX_QTY = this.grd01.GetValue(i, "REQ_BOX_QTY").ToString();
                    string OUT_DIV = this.grd01.GetValue(i, "OUT_DIV").ToString();
                    string NOTE_NO = this.grd01.GetValue(i, "NOTE_NO").ToString();

                    if (this.GetByteCount(PARTNO) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {PARTNO}가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0110", i.ToString(), this.grd01.Cols[4].Caption.ToString());
                        return false;
                    }
                    if (this.GetByteCount(REQ_BOX_QTY) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {REQ_BOX_QTY}가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0110", i.ToString(), this.grd01.Cols[7].Caption.ToString());
                        return false;
                    }
                    if (this.GetByteCount(OUT_DIV) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {OUT_DIV}가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0109", i.ToString(), this.grd01.Cols[18].Caption.ToString());
                        return false;
                    }
                    if (this.GetByteCount(NOTE_NO) > 10)
                    {
                        //MsgBox.Show(i + " 번째 행에 {계측유형명칭}은 4byte 이상 입력할 수 없습니다.");
                        //MsgCodeBox.ShowFormat("XM00-0112", i.ToString(), this.grd01.Cols[5].Caption.ToString(), "2");
                        MsgCodeBox.Show("XM00-0113");
                        return false;
                    }             
                }

                //if (MsgBox.Show("입력하신 계측항목 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //저장하시겠습니까?
                //if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsSaveValid2(DataSet source)
        {
            try
            {
                if (source == null || source.Tables.Count == 0 || source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 자재입고 정보가 없습니다.");
                    MsgCodeBox.Show("CD00-0042"); // 저장할 데이터가 존재하지 않습니다.
                    return false;
                }

                //string[] tmpARRIV_TIME = Convert.ToString(this.txt01_ARRIV_TIME.GetValue()).Split(':');
                int tmpHour = -1;
                int tmpMin = -1;

                //if (tmpARRIV_TIME.Length != 2 || tmpARRIV_TIME[0].Length != 2 || tmpARRIV_TIME[1].Length != 2)
                //{
                //    //MsgBox.Show("입하시간이 올바르지 않습니다.");
                //    MsgCodeBox.Show("MM02-0001");
                //    return false;
                //}

                //tmpHour = int.TryParse(tmpARRIV_TIME[0], out tmpHour) ? tmpHour : -1;
                //tmpMin = int.TryParse(tmpARRIV_TIME[1], out tmpMin) ? tmpMin : -1;

                if (tmpHour < 0 || tmpHour > 23 || tmpMin < 0 || tmpMin > 59)
                {
                    //MsgBox.Show("입하시간이 올바르지 않습니다.");
                    MsgCodeBox.Show("MM02-0001");
                    return false;
                }

                int tmpARRIV_QTY = 0;
                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    tmpARRIV_QTY = int.TryParse(Convert.ToString(dr["ARRIV_QTY"]), out tmpARRIV_QTY) ? tmpARRIV_QTY : 0;
                    if (tmpARRIV_QTY < 0)
                    {
                        //if (MsgBox.Show(string.Format(@"[{0}]의 합격수량이 0보다 작습니다. 계속 하시겠습니까?", dr["PARTNO"]), "경고", MessageBoxButtons.OKCancel)
                        //    != DialogResult.OK)
                        if (MsgCodeBox.ShowFormat("MM02-0002", MessageBoxButtons.OKCancel, dr["PARTNO"]) != DialogResult.OK)
                        {
                            return false;
                        }
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool IsRemoveValid(DataSet source) //aa
        {
            try
            {
                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    string NOTE_NO = this.grd01.GetValue(i, "NOTE_NO").ToString();
                    
                    if (this.GetByteCount(NOTE_NO) > 10)
                    {
                        //MsgBox.Show(i + " 번째 행에 {계측유형명칭}은 4byte 이상 입력할 수 없습니다.");
                        //MsgCodeBox.ShowFormat("XM00-0112", i.ToString(), this.grd01.Cols[5].Caption.ToString(), "2");
                        MsgCodeBox.Show("XM00-0112");
                        return false;
                    }                  
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool IsQueryValid(HEParameterSet param)
        {
            try
            {
                if (param["BIZCD"] == null || string.IsNullOrEmpty(Convert.ToString(param["BIZCD"])))
                {
                    //MsgBox.Show("검색할 사업장코드가 없습니다.");
                    MsgCodeBox.ShowFormat("MM02-0003", this.lbl01_BIZNM.Text);
                    return false;
                }

                if (param["DELI_DATE"] == null || string.IsNullOrEmpty(Convert.ToString(param["DELI_DATE"])))
                {
                    //MsgBox.Show("검색할 납품일자가 없습니다.");
                    MsgCodeBox.ShowFormat("MM02-0003", this.lbl01_REQ_DATE.Text);
                    return false;
                }

                if (param["VENDCD"] == null || string.IsNullOrEmpty(Convert.ToString(param["VENDCD"])))
                {
                    //MsgBox.Show("검색할 업체코드가 없습니다.");
                    //MsgCodeBox.ShowFormat("MM02-0003", this.lbl01_VENDCD.Text);
                    return false;
                }

                if (param["PRINT_SEQ"] == null || string.IsNullOrEmpty(Convert.ToString(param["PRINT_SEQ"])))
                {
                    //MsgBox.Show("검색할 납품차수가 없습니다.");
                    //MsgCodeBox.ShowFormat("MM02-0003", this.lbl01_PRINT_SEQ.Text);
                    return false;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        #endregion

        #region [ 헬퍼 메소드 정의 ]

        private void Bind_cbo01_PRINT_SEQ()   
        {
            this.cbo01_PRINT_SEQ.Text = string.Empty;

            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", this.UserInfo.CorporationCode);
            paramSet.Add("BIZCD", this.UserInfo.BusinessCode);
            paramSet.Add("REQ_DATE", this.dte01_REQ_DATE.GetDateText());
            paramSet.Add("AREACD", this.cbo01_AREACD.GetValue());
            //paramSet.Add("LANG_SET", this.UserInfo.Language);

            if (rdo01_PRINT.Checked)
            {
                using (DataSet ds = _WSCOM.ExecuteDataSet("APG_WM20420.INQUERY_PRINT_SEQ1", paramSet))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        this._isSelectedIndexChangedDirectly = false;
                        this.cbo01_PRINT_SEQ.DataBind(ds.Tables[0], false);

                        //this.BtnQuery_Click(null, null);                   
                    }
                }
            }
            else
            {
                using (DataSet ds = _WSCOM.ExecuteDataSet("APG_WM20420.INQUERY_PRINT_SEQ2", paramSet))
                {
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        this._isSelectedIndexChangedDirectly = false;
                        this.cbo01_PRINT_SEQ.DataBind(ds.Tables[0], false);

                        //this.BtnQuery_Click(null, null);                   
                    }
                }
            }

            //this.dte01_ARRIV_DATE.Initialize();
            //this.txt01_ARRIV_TIME.SetValue(DateTime.Now.ToString("HH:mm"));
            //this.grd01.SetValue(new DataTable());
        }

        #endregion


        private void dte01_REQ_DATE_ValueChanged(object sender, EventArgs e)
        {
            this.Bind_cbo01_PRINT_SEQ();   //차수 재조정
            this.grd01.InitializeDataSource();
            this.BtnQuery_Click(null, null);
        }

        private void rdo01_REPRINT_CheckedChanged(object sender, EventArgs e)
        {
            //HEParameterSet paramSet_PRINT_SEQ = new HEParameterSet();
            //paramSet_PRINT_SEQ.Add("CORCD", this.UserInfo.CorporationCode);
            //paramSet_PRINT_SEQ.Add("BIZCD", this.UserInfo.BusinessCode);
            //paramSet_PRINT_SEQ.Add("REQ_DATE", this.dte01_REQ_DATE.GetValue());
            //paramSet_PRINT_SEQ.Add("AREACD", this.cbo01_AREACD.GetValue());
            //paramSet_PRINT_SEQ.Add("PRINT_SEQ", this.cbo01_PRINT_SEQ.GetValue());
            //paramSet_PRINT_SEQ.Add("LANG_SET", this.UserInfo.Language);
            //DataTable combo_source_PRINT_SEQ = _WSCOM.ExecuteDataSet("APG_WM20420.INQUERY_PRINT_SEQ1", paramSet_PRINT_SEQ).Tables[0];
            //this.cbo01_PRINT_SEQ.DataBind(combo_source_PRINT_SEQ, false);
            try
            {
                this.Bind_cbo01_PRINT_SEQ();
                this.BtnQuery_Click(null, null);   
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void rdo01_PRINT_CheckedChanged(object sender, EventArgs e)
        {
            //HEParameterSet paramSet_PRINT_SEQ = new HEParameterSet();
            //paramSet_PRINT_SEQ.Add("CORCD", this.UserInfo.CorporationCode);
            //paramSet_PRINT_SEQ.Add("BIZCD", this.UserInfo.BusinessCode);
            //paramSet_PRINT_SEQ.Add("REQ_DATE", this.dte01_REQ_DATE.GetValue());
            //paramSet_PRINT_SEQ.Add("AREACD", this.cbo01_AREACD.GetValue());
            //paramSet_PRINT_SEQ.Add("PRINT_SEQ", this.cbo01_PRINT_SEQ.GetValue());
            //paramSet_PRINT_SEQ.Add("LANG_SET", this.UserInfo.Language);
            //DataTable combo_source_PRINT_SEQ = _WSCOM.ExecuteDataSet("APG_WM20420.INQUERY_PRINT_SEQ2", paramSet_PRINT_SEQ).Tables[0];
            //this.cbo01_PRINT_SEQ.DataBind(combo_source_PRINT_SEQ, false);
            try
            {
                this.Bind_cbo01_PRINT_SEQ();
                this.BtnQuery_Click(null, null);   
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        private void cbo01_AREACD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Bind_cbo01_PRINT_SEQ();
                this.BtnQuery_Click(null, null);   
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

    }
}