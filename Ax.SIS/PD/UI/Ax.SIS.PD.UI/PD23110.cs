#region ▶ Description & History
/* 
 * 프로그램명 : 실사 생산실적 관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2014-07-23    배명희     cdx01_LINECD 연결 팝업 변경 (CM20020P1 -> CM30030P1)
 *                                       cdx01_VINCD 연결 팝업 변경 (CM20011P1 -> CM30010P1)
 *                                       cdx01_ITEMCD 연결 팝업 변경 (CM20011P2 -> CM30010P1)
 *              2014-10-07    진승모     다국어 적용
 *              2017-07~09    배명희     SIS 이관
 *              2017-10-16    배명희     2017-10-10일 이전 데이터는 변경 금지(저장시 rslt_date 체크)
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
using System.Data.OleDb;
using System.Text;
using System.Collections.Generic;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>실사 생산 실적 관리</b>
    /// </summary>
    public partial class PD23110 : AxCommonBaseControl
    {
        //private IPM23110 _WSCOM;
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD23110";

        public PD23110()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPM23110>("PM03", "PM23110.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();	
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SelectedValueChanged += new EventHandler(cbo01_BIZCD_SelectedValueChanged);
                DataTable dtSTR_LOC = this.GetSTR_LOC();

                this.cbo02_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo02_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo03_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo03_BIZCD.SetValue(this.UserInfo.BusinessCode);

                label1.Visible = false;
                axDateEdit1.Visible = false;
                if (this.UserInfo.IsAdmin.Equals("Y"))
                {
                    this.cbo01_BIZCD.SetReadOnly(false);
                    this.cbo02_BIZCD.SetReadOnly(false);
                }
                else
                {
                    this.cbo01_BIZCD.SetReadOnly(true);
                    this.cbo02_BIZCD.SetReadOnly(true);
                }

                this.dte01_STD_DATE.SetMMFromStart();
                this.dte02_STD_DATE.SetMMFromStart();
                this.dte03_STD_DATE.SetMMFromStart();

                DataSet source = this.GetTypeCode("A0", "A1", "A3", "A4", "A7", "A6", "AP", "EI", "C5", "A5");

                this.grd01.AllowEditing = true;
                this.grd01.Initialize(1, 1, false);

                //행취소 기능만 사용. 조정수량 입력하지 않았는데 행 모드가 "U"로 바뀐 경우 행취소 처리할 수 있도록.
                this.grd01.CurrentContextMenu.Items[0].Visible = false; //행추가 사용안함
                this.grd01.CurrentContextMenu.Items[1].Visible = false; //행삭제 사용안함
                

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "계획일자", "RSLT_DATE", "PLAN_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "PART NAME", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "LINE", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "장착위치", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "MOLDNO", "MOLDNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "주야", "SHIFT", "SHIFT");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "업무유형", "JOB_TYPE", "JOB_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "업무유형", "JOB_TYPENM", "JOB_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "저장위치", "STR_LOC", "STR_LOC");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 140, "저장위치명", "STR_LOCNM", "STR_LOCNM2");        
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "계획수량", "PLAN_QTY", "PLAN_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 140, "총실적수량", "TOT_RSLT_QTY", "TOT_RSLT_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "실적수량", "SUM_QTY", "RSLT_QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "실적조정수량", "CHNG_QTY", "CHNG_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "NG/QTY", "NG_QTY", "NG_QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 300, "REMARKS", "REMARKS", "REMARKS");
                
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddHiddenColumn("WORK_ORDNO");
                this.grd01.AddHiddenColumn("ORDNO");
                this.grd01.AddHiddenColumn("SEQNO");
                this.grd01.AddHiddenColumn("ORD_TYPE");
                this.grd01.AddHiddenColumn("ENFOR_DIV");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "RSLT_DATE");


                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[1], "JOB_TYPENM");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtSTR_LOC, "STR_LOCNM");
                this.grd01.Cols["JOB_TYPENM"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd01.Cols["SUM_QTY"].Format = "#,###,###,###,###,###";
                this.grd01.Cols["CHNG_QTY"].Format = "#,###,###,###,###,##0";
                this.grd01.Cols["NG_QTY"].Format = "#,###,###,###,###,##0";
                this.grd01.Cols["CHNG_QTY"].StyleDisplay.BackColor = Color.LightYellow;
                this.grd01.Cols["TOT_RSLT_QTY"].Format = "#,###,###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PLAN_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "SUM_QTY");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "CHNG_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_RSLT_QTY");                
                this.grd01.KeyActionEnter = KeyActionEnum.MoveDown;

                CellStyle csPARTNO = grd01.Styles.Add("PARTNO");
                csPARTNO.BackColor = Color.Red;

                CellStyle csCHNG_QTY = grd01.Styles.Add("CHNG_QTY");
                csCHNG_QTY.BackColor = Color.LightYellow;

                CellStyle csLIME = grd01.Styles.Add("LIME_EQ");
                csLIME.BackColor = Color.Lime;

                this.grd01_2.AllowEditing = false;
                this.grd01_2.Initialize(1, 1, false);
                this.grd01_2.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "순번", "SEQ", "SEQ_NO");
                this.grd01_2.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "조정일자", "UPDATE_DATE", "CHNG_DATE");
                this.grd01_2.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "조정수량", "CHNG_QTY", "CHNG_QTY");
                this.grd01_2.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "사번", "UPDATE_ID", "EMPNO");
                this.grd01_2.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "성명", "NAME_KOR", "NAME_KOR");
                this.grd01_2.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "REMARKS", "REMARKS", "REMARKS");
                this.grd01_2.Cols["CHNG_QTY"].Format = "#,###,###,###,###,##0";
                //this.grd01_2.SetColumnType(AxFlexGrid.FCellType.Int, "CHNG_QTY");
                
                #region [grdExcel-숨김그리드]

                this.grdExcel.AllowEditing = false;
                this.grdExcel.AllowDragging = AllowDraggingEnum.None;
                this.grdExcel.Initialize();
                this.grdExcel.Cols.RemoveRange(1, this.grdExcel.Cols.Count - 1);
                this.grdExcel.Cols.Fixed = 1;
                this.grdExcel.Styles.Fixed.BackColor = Color.Yellow;
                this.grdExcel.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                this.grdExcel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "ALC", "ALCCD", "ALCCD");                
                this.grdExcel.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "조정수량", "CHNG_QTY", "CHNG_QTY");
                this.grdExcel.Cols["PARTNO"].DataType = typeof(string);
                this.grdExcel.Cols["ALCCD"].DataType = typeof(string);
                this.grdExcel.Cols["CHNG_QTY"].DataType = typeof(decimal);
                this.grdExcel.Cols["CHNG_QTY"].Format = "###,##0";
                this.grdExcel.Cols[0].Visible = false;
                this.grdExcel.Styles.Fixed.Border.Color = Color.DarkGray;
                this.AddRow();
                #endregion
                
                this.grd02.AllowEditing = true;
                this.grd02.Initialize(1, 1, false);
                this.grd02.AllowMerging = AllowMergingEnum.RestrictCols; //merge기능 사용함.
                this.grd02.AllowSorting = AllowSortingEnum.None;        //sorting기능 사용안함.

                //행취소 기능만 사용. 조정수량 입력하지 않았는데 행 모드가 "U"로 바뀐 경우 행취소 처리할 수 있도록.
                this.grd02.CurrentContextMenu.Items[0].Visible = false; //행추가 사용안함.
                this.grd02.CurrentContextMenu.Items[1].Visible = false; //행삭제 사용안함

                this.grd02.Cols.Count = this.grd02.Cols.Fixed;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "작업지시번호", "WORK_ORDNO", "WORK_ORDNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "판매오더번호", "ORDNO", "SALE_ORDNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "판매오더순번", "SEQNO", "SALE_SEQNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "계획일자", "RSLT_DATE", "PLAN_DATE");
                
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PART NO", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 200, "PART NAME", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "LINE", "LINECD", "LINECD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "장착위치", "INSTALL_POS", "INSTALL_POS");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 050, "ALC", "ALCCD", "ALCCD");
                
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 060, "업무유형", "JOB_TYPE", "JOB_TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "업무유형", "JOB_TYPENM", "JOB_TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "저장위치", "STR_LOC", "STR_LOC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "저장위치명", "STR_LOCNM", "STR_LOCNM2");        
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "계획수량", "PLAN_QTY", "PLAN_QTY");                
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 140, "총실적수량", "TOT_RSLT_QTY", "TOT_RSLT_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "주야", "SHIFT", "SHIFT");

                this.grd02.AddHiddenColumn("CORCD");
                this.grd02.AddHiddenColumn("BIZCD");
                this.grd02.AddHiddenColumn("ORD_TYPE");
                this.grd02.AddHiddenColumn("ENFOR_DIV");
                this.grd02.AddHiddenColumn("DATA_DIV");

                

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 0100, "실적수량", "SUM_QTY", "RSLT_QTY");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "실적일자", "RSLT_DATE_INPUT", "RSLT_DATE");                
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "실적조정수량", "CHNG_QTY", "CHNG_QTY");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "RSLT_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "RSLT_DATE_INPUT");
                this.grd02.Cols["RSLT_DATE_INPUT"].StyleDisplay.BackColor = Color.LightYellow;
                //merge기능 사용함.
                for (int i = this.grd02.Cols.Fixed; i <= this.grd02.Cols["TOT_RSLT_QTY"].Index; i++)
                {
                    this.grd02.Cols[i].AllowMerging = true;
                }

                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, source.Tables[1], "JOB_TYPENM");
                this.grd02.Cols["JOB_TYPENM"].TextAlign = TextAlignEnum.LeftCenter;
                this.grd02.Cols["SUM_QTY"].Format = "#,###,###,###,###,###";
                this.grd02.Cols["CHNG_QTY"].Format = "#,###,###,###,###,##0";
                this.grd02.Cols["TOT_RSLT_QTY"].Format = "#,###,###,###,###,##0";
                this.grd02.Cols["CHNG_QTY"].StyleDisplay.BackColor = Color.LightYellow;
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "PLAN_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "SUM_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "CHNG_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_RSLT_QTY");
                
                
                CellStyle csPARTNO2 = grd02.Styles.Add("PARTNO");
                csPARTNO2.BackColor = Color.Red;

                CellStyle csCHNG_QTY2 = grd02.Styles.Add("CHNG_QTY");
                csCHNG_QTY2.BackColor = Color.LightYellow;

                //실적일자 편집 가능시 배경색
                CellStyle csRSLT_DATE_INPUT = grd02.Styles.Add("RSLT_DATE_INPUT");
                csRSLT_DATE_INPUT.BackColor = Color.LightYellow;

                //실적일자 != 계획일자 배경색 핫핑크
                CellStyle csDATE_DIFF = grd02.Styles.Add("DATE_DIFF");
                csDATE_DIFF.BackColor = Color.HotPink;

                this.grd02.KeyActionEnter = KeyActionEnum.MoveDown;

                //실적추가 Context Menu 추가
                string title = this.GetLabel("ADD_RSLT");
                ToolStripMenuItem insertItem = new ToolStripMenuItem(title.Equals(string.Empty)? "Add Result" : title);
                insertItem.Click += new EventHandler(insertItem_Click);
                this.grd02.CurrentContextMenu.Items.Insert(0, insertItem);


                this.grd02_2.AllowEditing = false;
                this.grd02_2.Initialize(1, 1, false);
                this.grd02_2.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "순번", "SEQ", "SEQ_NO");
                this.grd02_2.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "조정일자", "UPDATE_DATE", "CHNG_DATE");
                this.grd02_2.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "조정수량", "CHNG_QTY", "CHNG_QTY");
                this.grd02_2.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "사번", "UPDATE_ID", "EMPNO");
                this.grd02_2.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "성명", "NAME_KOR", "NAME_KOR");
                this.grd02_2.Cols["CHNG_QTY"].Format = "#,###,###,###,###,##0";
                this.grd02_2.SetColumnType(AxFlexGrid.FCellType.Int, "CHNG_QTY");

                this.grd03.AllowEditing = true;
                this.grd03.Initialize(1, 1, false);
                         
                //행취소 3능만 사용. 조정수량 입력하지 않았는데 행 모드가 "U"로 바뀐 경우 행취소 처리할 수 있도록.
                this.grd03.CurrentContextMenu.Items[0].Visible = false; //행추가 사용안함
                this.grd03.CurrentContextMenu.Items[1].Visible = false; //행삭제 사용안함
                         
                  
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PART NO", "PARTNO", "PARTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "PART NAME", "PARTNM", "PARTNM");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "LINE", "LINECD", "LINECD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "장착위치", "INSTALL_POS", "INSTALL_POS");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "ALC", "ALCCD", "ALCCD");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "업무유형", "JOB_TYPE", "JOB_TYPE");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "업무유형", "JOB_TYPENM", "JOB_TYPE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "저장위치", "STR_LOC", "STR_LOC");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "D0", "D0");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "D1", "D1");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "D2", "D2");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "D3", "D3");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "D4", "D4");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "D5", "D5");

                         
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");

                this.grd03.KeyActionEnter = KeyActionEnum.MoveDown;
                CellStyle csPARTNO3 = grd03.Styles.Add("PARTNO");
                csPARTNO3.BackColor = Color.Red;
                CellStyle csRegular = grd03.Styles.Add("REGULAR");
                csRegular.BackColor = Color.LightGray;
                
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

                this.cdx01_STR_LOC.HEPopupHelper = new CM30040P1(); //new PM20015P1();
                this.cdx01_STR_LOC.PopupTitle = this.GetLabel("STR_LOC");
                this.cdx01_STR_LOC.CodeParameterName = "STR_LOC";
                this.cdx01_STR_LOC.NameParameterName = "STR_LOCNM";
                this.cdx01_STR_LOC.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_STR_LOC.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_STR_LOC.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                

                this.cdx02_LINECD.HEPopupHelper = new CM30030P1(); //new PM20015P1();
                this.cdx02_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx02_LINECD.CodeParameterName = "LINECD";
                this.cdx02_LINECD.NameParameterName = "LINENM";
                this.cdx02_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue());
                this.cdx02_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx02_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx02_LINECD.HEUserParameterSetValue("DATE", this.dte02_STD_DATE.GetDateText());
                this.cdx02_LINECD.HEUserParameterSetValue("PLANT_DIV", this.UserInfo.PlantDiv); //2013.03.20 공장구분 추가(배명희)   
                this.cdx02_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                this.cdx03_LINECD.HEPopupHelper = new CM30030P1(); //new PM20015P1();
                this.cdx03_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx03_LINECD.CodeParameterName = "LINECD";
                this.cdx03_LINECD.NameParameterName = "LINENM";
                this.cdx03_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx03_LINECD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue());
                this.cdx03_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx03_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx03_LINECD.HEUserParameterSetValue("DATE", this.dte02_STD_DATE.GetDateText());
                this.cdx03_LINECD.HEUserParameterSetValue("PLANT_DIV", this.UserInfo.PlantDiv); //2013.03.20 공장구분 추가(배명희)   
                this.cdx03_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                this.chk01_PD23110_CHK1.Checked = true;
                this.chk01_PD23110_CHK2.Checked = true;
                this.chk02_PD23110_CHK2.Checked = true;

                //this.SetRequired(this.lbl01_BIZNM, this.lbl01_LINECD, this.lbl02_BIZNM);
                this.SetRequired(this.lbl01_BIZNM, this.lbl02_BIZNM, this.lbl03_BIZNM);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnSave_Click(object sender, EventArgs e)
        {  

            if (this.tabControl1.SelectedIndex == 0)
            {
                this.SaveOEM();
            }
            else
            {
                this.SaveETC();
            }

        }

        private void SaveOEM()
        {
            try
            {
                DataSet source = this.grd01.GetValue(
                                                         AxFlexGrid.FActionType.Save,
                                                         "CORCD", "BIZCD", "RSLT_DATE",  "JOB_TYPE", "SHIFT", "LINECD",
                                                         "PARTNO", "PARTNM", "WORK_ORDNO", "ORDNO", "SEQNO", "STR_LOC", "ORD_TYPE",
                                                         "ALCCD", "ENFOR_DIV", "SUM_QTY", "CHNG_QTY", "USER_ID", "REMARKS"
                                                     );

                List<DataRow> drList = new List<DataRow>();

                foreach (DataRow row in source.Tables[0].Rows)
                {
                    row["WORK_ORDNO"] = "X";
                    row["ORDNO"] = "X";
                    row["SEQNO"] = "0";
                    row["ORD_TYPE"] = "1";
                    row["ENFOR_DIV"] = "I0";
                    row["USER_ID"] = this.UserInfo.UserID;

                    ////Save Only have Value in CHNG_QTY -- 20190807 LYZ
                    if (row["CHNG_QTY"].ToString() == "")
                    {
                        drList.Add(row);
                    }
                }

                foreach (DataRow row in drList)
                {
                    source.Tables[0].Rows.Remove(row);
                }

                if (!this.IsSaveValid(source))
                    return;

                //엑셀 업로드시 CD0021, CD0020L 에 없는 품번인 경우 PARTNM에 "X"값 들어 있음. 
                //품명 체크 후 불필요한 컬럼이므로 제거처리함.
                source.Tables[0].Columns.Remove("PARTNM");
                source.Tables[0].Columns.Remove("SUM_QTY");

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 실사생산실적 정보가 저장되었습니다.");
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
        
        private void SaveETC()
        {
            try
            {                
                //RSLT_DATE는 계획일자 정보를 가지고 있고,  RSLT_DATE_INPUT은 실적데이터의 실적일자이거나 사용자가 직접 입력한 실적일자임. 
                DataSet source = this.grd02.GetValue(
                                                         AxFlexGrid.FActionType.Save,
                                                         "CORCD", "BIZCD", "RSLT_DATE", "RSLT_DATE_INPUT", "JOB_TYPE", "SHIFT", "LINECD",
                                                         "PARTNO", "WORK_ORDNO", "ORDNO", "SEQNO", "STR_LOC", "ORD_TYPE",
                                                         "ALCCD", "ENFOR_DIV", "SUM_QTY", "CHNG_QTY", "USER_ID", "PLAN_QTY", "TOT_RSLT_QTY", "DATA_DIV"
                                                     );
                
                if (!this.IsSaveValid(source))
                    return;


                foreach (DataRow row in source.Tables[0].Rows)
                {
                    row["ORD_TYPE"] = "1";
                    row["ENFOR_DIV"] = "I0";
                    row["USER_ID"] = this.UserInfo.UserID;                    
                    row["RSLT_DATE"] = row["RSLT_DATE_INPUT"].ToString();//실적일자 파라메터에 사용자가 직접 입력한 실적일자 반영
                }
                //유효성 체크를 위해 추출했던 PLAN_QTY, TOT_RSLT_QTY ,DATA_DIV 컬럼은 저장시 필요없으므로 삭제 처리함.
                //불필요한 RSLT_DATE_INPUT 삭제 처리함.
                source.Tables[0].Columns.Remove("PLAN_QTY");
                source.Tables[0].Columns.Remove("TOT_RSLT_QTY");
                source.Tables[0].Columns.Remove("RSLT_DATE_INPUT");
                source.Tables[0].Columns.Remove("DATA_DIV"); 

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("입력하신 실사생산실적 정보가 저장되었습니다.");
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
                if (!this.IsQueryValid())
                    return;
                AxFlexGrid grd;
                HEParameterSet set = new HEParameterSet();
                //string strLinecd = Nvl(this.cdx01_LINECD.GetValue().ToString(), "").ToString();
                
                string QUERY;
                if (this.tabControl1.SelectedIndex == 0)
                {
                    grd =  this.grd01; 
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                    set.Add("RSLT_DATE", this.dte01_STD_DATE.GetDateText());
                    set.Add("LINECD", this.cdx01_LINECD.GetValue());
                    set.Add("LANG_SET", this.UserInfo.Language);
                    set.Add("PLAN", this.chk01_PD23110_CHK1.Checked ? "1" : "0");
                    set.Add("RSLT", this.chk01_PD23110_CHK2.Checked ? "1" : "0");
                    set.Add("PARTNO", this.txt01_PARTNO.GetValue().ToString());
                    set.Add("ALCCD", this.txt01_ALCCD.GetValue().ToString());
                    set.Add("STR_LOC", this.cdx01_STR_LOC.GetValue().ToString());
                    set.Add("END_DATE", this.axDateEdit1.GetDateText());
                    QUERY = "INQUERY_OEM";
                }
                else if (this.tabControl1.SelectedIndex == 1)
                {
                    grd =  this.grd02; 
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.cbo02_BIZCD.GetValue());
                    set.Add("RSLT_DATE", this.dte02_STD_DATE.GetDateText());
                    set.Add("LINECD", this.cdx01_LINECD.GetValue());
                    set.Add("LANG_SET", this.UserInfo.Language);
                    set.Add("RSLT", this.chk02_PD23110_CHK2.Checked ? "1" : "0");
                    set.Add("PARTNO", this.txt02_PARTNO.GetValue().ToString());
                    set.Add("ALCCD", this.txt02_ALCCD.GetValue().ToString());
                    QUERY = "INQUERY_ELSE";
                }
                else
                {
                    grd = this.grd03;
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.cbo03_BIZCD.GetValue());
                    set.Add("PLAN_DATE", this.dte03_STD_DATE.GetDateText());
                    set.Add("LINECD", this.cdx03_LINECD.GetValue());
                    set.Add("LANG_SET", this.UserInfo.Language);
                    set.Add("PARTNO", this.txt03_PARTNO.GetValue().ToString());
                    set.Add("ALCCD", this.txt03_ALCCD.GetValue().ToString());
                    QUERY = "INQUERY_FDAY_PLAN";
                }
                
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(set);
                
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, QUERY), set);

                grd.SetValue(source);
                this.AfterInvokeServer();
                ShowDataCount(source);

                if (this.tabControl1.SelectedIndex == 0)
                {
                    grd.setAlternateRowStyle(6);
                    this.grd01_2.InitializeDataSource(); //조정이력 초기화
                }
                else if (this.tabControl1.SelectedIndex == 1)
                {
                    grd.setAlternateRowStyle(grd.Cols["ALCCD"].Index);
                    this.grd02_2.InitializeDataSource();//조정이력 초기화
                }
                else
                {
                    grd.setAlternateRowStyle(grd.Cols["ALCCD"].Index);
                    DateTime dte = Convert.ToDateTime(this.dte03_STD_DATE.GetDateText());
                    for (int i = 0; i < 6; i++)
                    {
                        grd03.Rows[0]["D" + i] = dte.AddDays(i).Date.ToString("dd-MM");
                        grd03.SetCellStyle(0, grd03.Cols["D" + i].Index, "REGULAR");
                        if (dte.AddDays(i).DayOfWeek.ToString() == "Sunday")
                        {
                            grd03.SetCellStyle(0, grd03.Cols["D" + i].Index, "PARTNO");
                        }
                    }
                }

                if (this.tabControl1.SelectedIndex == 0 || this.tabControl1.SelectedIndex == 1)
                {
                    for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
                    {
                        grd.Rows[i].StyleNew.Clear();

                        // 2019-07-09
                        ////계획수량 != 총실적수량 이면 두 컬럼 배경색 RED로 설정함. (PARTNO컬럼이 아니라...) 2017-11-03                                        
                        //if (grd.GetValue(i, "PLAN_QTY").ToString() != grd.GetValue(i, "TOT_RSLT_QTY").ToString())
                        //{
                        //    grd.SetCellStyle(i, grd.Cols["PLAN_QTY"].Index, "PARTNO");
                        //    grd.SetCellStyle(i, grd.Cols["TOT_RSLT_QTY"].Index, "PARTNO");
                        //}
                        //grd.SetCellStyle(i, grd.Cols["CHNG_QTY"].Index, "CHNG_QTY"); //grd01.Styles["PARTNO"]);
                        int n_plan_qty = 0;
                        int n_total_qty = 0;
                        Int32.TryParse(grd.GetValue(i, "PLAN_QTY").ToString(), out n_plan_qty);
                        Int32.TryParse(grd.GetValue(i, "TOT_RSLT_QTY").ToString(), out n_total_qty);
                        if (n_plan_qty != 0 || n_total_qty != 0)
                        {
                            if (n_plan_qty > n_total_qty)
                            {
                                // Change the cell's background Red.
                                grd.SetCellStyle(i, grd.Cols["PLAN_QTY"].Index, "PARTNO");
                                grd.SetCellStyle(i, grd.Cols["TOT_RSLT_QTY"].Index, "PARTNO");
                            }
                            else if (n_plan_qty == n_total_qty)
                            {
                                // Change the cell's background Lime
                                grd.SetCellStyle(i, grd.Cols["PLAN_QTY"].Index, "LIME_EQ");
                                grd.SetCellStyle(i, grd.Cols["TOT_RSLT_QTY"].Index, "LIME_EQ");
                            }
                            else if (n_plan_qty < n_total_qty)
                            {
                                // Change the cell's background Yellow
                                grd.SetCellStyle(i, grd.Cols["PLAN_QTY"].Index, "CHNG_QTY");
                                grd.SetCellStyle(i, grd.Cols["TOT_RSLT_QTY"].Index, "CHNG_QTY");
                            }
                        }
                        grd.SetCellStyle(i, grd.Cols["CHNG_QTY"].Index, "CHNG_QTY"); //grd01.Styles["PARTNO"]);


                        //기타 실적 등록 그리드 :: 실적일자 컬럼 편집 가능 배경색 지정
                        if (grd.Cols.Contains("RSLT_DATE_INPUT"))
                        {
                            if (grd.GetValue(i, "DATA_DIV").ToString().Equals("PLAN"))
                            {
                                //계획만 있는 데이터의 경우 실적일자 입력 가능 표시
                                grd.SetCellStyle(i, grd.Cols["RSLT_DATE_INPUT"].Index, "RSLT_DATE_INPUT");
                            }
                            else
                            {
                                //실적데이터가 있는데, 계획일자와 실적일자가 다른 경우 핫핑크로 표시함.
                                if (grd.GetValue(i, "RSLT_DATE").ToString() != grd.GetValue(i, "RSLT_DATE_INPUT").ToString())
                                {
                                    grd.SetCellStyle(i, grd.Cols["RSLT_DATE_INPUT"].Index, "DATE_DIFF");
                                    grd.SetCellStyle(i, grd.Cols["RSLT_DATE"].Index, "DATE_DIFF");
                                }
                            }
                        }
                    }
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

        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = this.GetSTR_LOC();
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, dt, "STR_LOCNM");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
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
        
        private void cdx02_LINECD_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo02_BIZCD.GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        private void cdx01_LINECD_ButtonClickAfter(object sender, EventArgs args)
        {
            try
            {
                //2017-11-03 라인코드 → 저장위치 연동 기능 제거
                //if (this.cdx01_LINECD.SelectedPopupValue != null)
                //{
                //    if (this.cdx01_LINECD.SelectedPopupValue["STR_LOC"].ToString() != "")
                //    {
                //        this.cdx01_STR_LOC.SetValue(this.cdx01_LINECD.SelectedPopupValue["STR_LOC"].ToString());
                //    }
                //}
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //저장위치
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

        //비고정보 표시
        private void grd01_Click(object sender, EventArgs e)
        {
            int row = grd01.RowSel;
           
            if (row < this.grd01.Rows.Fixed || row >= this.grd01.Rows.Count) return;

            txt01_REMARK.Text = this.grd01.GetValue(row, "REMARKS").ToString();
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

                //int rsltQty = string.IsNullOrEmpty(this.grd01.GetValue(row, "SUM_QTY").ToString()) ? 0 : Convert.ToInt32(this.grd01.GetValue(row, "SUM_QTY"));
                //int inputQty = string.IsNullOrEmpty(this.grd01.GetValue(row, "CHNG_QTY").ToString()) ? 0 : Convert.ToInt32(this.grd01.GetValue(row, "CHNG_QTY"));

                //this.grd01.SetValue(row, "TOT_RSLT_QTY", rsltQty + inputQty);
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }
        }
        //조정수량 입력시 총실적수량 계산(총실적수량 =  실적수량 + 조정수량) - 값 입력하는 그때그떄 계산하여 표시 (사용)
        private void grd01_ChangeEdit(object sender, EventArgs e)
        {
            try
            {
                int row = grd01.Row;
                int col = grd01.Col;
                if (row < this.grd01.Rows.Fixed || row >= this.grd01.Rows.Count) return;
                if (col != this.grd01.Cols["CHNG_QTY"].Index) return;

                string value = grd01.Editor.Text.Replace(",","");
                int rsltQty = string.IsNullOrEmpty(this.grd01.GetValue(row, "SUM_QTY").ToString()) ? 0 : Convert.ToInt32(this.grd01.GetValue(row, "SUM_QTY"));
                int inputQty = string.IsNullOrEmpty(value) ? 0 : Convert.ToInt32(value);

                this.grd01.SetValue(row, "TOT_RSLT_QTY", rsltQty + inputQty);
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }

        }

        //조정수량 입력시 총실적수량 계산(총실적수량 =  실적수량 + 조정수량) - 값 입력후 포커스 이동시 계산하여 표시 (사용안함)
        private void grd02_AfterEdit(object sender, RowColEventArgs e)
        {
            //try
            //{
            //    int row = e.Row;
            //    int col = e.Col;
            //    if (row < this.grd02.Rows.Fixed || row >= this.grd02.Rows.Count) return;
            //    if (col != this.grd02.Cols["CHNG_QTY"].Index) return;

            //    int rsltQty = string.IsNullOrEmpty(this.grd02.GetValue(row, "SUM_QTY").ToString()) ? 0 : Convert.ToInt32(this.grd02.GetValue(row, "SUM_QTY"));
            //    int inputQty = string.IsNullOrEmpty(this.grd02.GetValue(row, "CHNG_QTY").ToString()) ? 0 : Convert.ToInt32(this.grd02.GetValue(row, "CHNG_QTY"));

            //    this.grd02.SetValue(row, "TOT_RSLT_QTY", rsltQty + inputQty);
            //}
            //catch (Exception ex)
            //{
            //    MsgBox.Show(ex.Message);
            //}
        }
        //조정수량 입력시 총실적수량 계산(총실적수량 =  실적수량 + 조정수량) - 값 입력하는 그때그떄 계산하여 표시 (사용)
        private void grd02_ChangeEdit(object sender, EventArgs e)
        {
            try
            {
                int row = grd02.Row;
                int col = grd02.Col;
                if (row < this.grd02.Rows.Fixed || row >= this.grd02.Rows.Count) return;
                if (col != this.grd02.Cols["CHNG_QTY"].Index) return;

                //조정수량 입력행의 WORK_ORDNO
                string myWorkOrdNo = this.grd02.GetValue(row, "WORK_ORDNO").ToString();
                
                //조정수량 입력행의 "실적수량" 및 "조정수량" 추출.
                int myRsltQty = string.IsNullOrEmpty(this.grd02.GetValue(row, "SUM_QTY").ToString()) ? 0 : Convert.ToInt32(this.grd02.GetValue(row, "SUM_QTY"));  //실적수량
                string value = grd02.Editor.Text.Replace(",", "");
                int myInputQty = string.IsNullOrEmpty(value) ? 0 : Convert.ToInt32(value);

                //같은 WORK_ORDNO인 다른 행들의 "실적수량" + "조정수량" 계산하기
                int rsltQty = 0; 
                for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                {
                    if (i != row && this.grd02.GetValue(i, "WORK_ORDNO").ToString().Equals(myWorkOrdNo))
                    {
                        rsltQty += string.IsNullOrEmpty(this.grd02.GetValue(i, "SUM_QTY").ToString()) ? 0 : Convert.ToInt32(this.grd02.GetValue(i, "SUM_QTY"));
                        rsltQty += string.IsNullOrEmpty(this.grd02.GetValue(i, "CHNG_QTY").ToString()) ? 0 : Convert.ToInt32(this.grd02.GetValue(i, "CHNG_QTY"));
                    }
                }


                //같은 WORK_ORDNO 총실적수량에 계산값 적용.
                this.grd02.EnabledActionFlag = false;
                for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                {
                    if (this.grd02.GetValue(i, "WORK_ORDNO").ToString().Equals(myWorkOrdNo))
                    {
                        this.grd02.SetValue(i, "TOT_RSLT_QTY", rsltQty + myRsltQty + myInputQty);
                    }
                }
                this.grd02.EnabledActionFlag = true;
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }

        }

        private void grd02_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                int row = grd02.Row;
                int col = grd02.Col;
                if (row < this.grd02.Rows.Fixed || row >= this.grd02.Rows.Count) return;
                if (col != this.grd02.Cols["RSLT_DATE_INPUT"].Index) return;

                //신규 실적 입력인 경우에만 실적일자 입력 허용.  (DATA_DIV - PLAN:계획만 존재, RSLT:실적 존재)
                string val = this.grd02.GetValue(row, "DATA_DIV").ToString();
                if (val == "RSLT")
                    e.Cancel = true;
            }
            catch (Exception ex)
            {
                MsgBox.Show(ex.Message);
            }

        }

        //context 메뉴명 설정함. (선택한 행의 작업지시번호 표시)
        private void grd02_MouseClick(object sender, MouseEventArgs e)
        {
            int r = this.grd02.Row;
            if (r < this.grd02.Rows.Fixed || r >= this.grd02.Rows.Count) return;

            string title ="[" + this.GetLabel("WORK_ORDNO") + " : " + this.grd02.GetValue(r, "WORK_ORDNO").ToString() + "] " + this.GetLabel("ADD_RSLT");
            this.grd02.CurrentContextMenu.Items[0].Text = title;

        }



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
                    this.sfdExcel.FileName = this.GetLabel("PD23110_FORM");

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

        #region 조정수량 입력 이력 조회 (oem 및 기타 - 공통으로 사용)
        //실적 데이터가 있다면 조정수량 등록 이력 조회
        private void grd_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                int r = grd.MouseRow;
                if (r < grd.Rows.Fixed || r >= grd.Rows.Count) return;

                string corcd = grd.GetValue(r, "CORCD").ToString();
                string bizcd = grd.GetValue(r, "BIZCD").ToString();
                string rslt_date = grd.GetValue(r, (grd.Name == "grd01" ? "RSLT_DATE" : "RSLT_DATE_INPUT")).ToString(); //기타실적인 경우에는 "RSLT_DATE_INPUT"가 실적일자임. 2018.01.04
                string shift = grd.GetValue(r, "SHIFT").ToString();
                string linecd = grd.GetValue(r, "LINECD").ToString();
                string partno = grd.GetValue(r, "PARTNO").ToString();
                string job_type = grd.GetValue(r, "JOB_TYPE").ToString();
                string work_ordno = grd.GetValue(r, "WORK_ORDNO").ToString();
                string ordno = grd.GetValue(r, "ORDNO").ToString();
                string seqno = grd.GetValue(r, "SEQNO").ToString();
                string str_loc = grd.GetValue(r, "STR_LOC").ToString();
                string ord_type = grd.GetValue(r, "ORD_TYPE").ToString();
                string alccd = grd.GetValue(r, "ALCCD").ToString();
                string enfor_div = grd.GetValue(r, "ENFOR_DIV").ToString();;

                DataSet source = this.getHistory(corcd, bizcd, rslt_date, shift, linecd, partno, job_type, work_ordno, ordno, seqno, str_loc, ord_type, alccd, enfor_div);

                if (grd.Name == "grd01")
                    this.grd01_2.SetValue(source);
                else
                    this.grd02_2.SetValue(source);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        //조정이력 조회
        private DataSet getHistory(string corcd, string bizcd, string rslt_date, string shift, string linecd, string partno,
                                    string job_type, string work_ordno, string ordno, string seqno, string str_loc, 
                                    string ord_type, string alccd, string enfor_div)
        {
            try
            {

                HEParameterSet param = new HEParameterSet();
                param.Add("CORCD", corcd);
                param.Add("BIZCD", bizcd);
                param.Add("RSLT_DATE", rslt_date);
                param.Add("SHIFT", shift);
                param.Add("LINECD", linecd);
                param.Add("PARTNO", partno);
                param.Add("JOB_TYPE", job_type);
                param.Add("WORK_ORDNO", work_ordno);
                param.Add("ORDNO", ordno);
                param.Add("SEQNO", seqno);
                param.Add("STR_LOC", str_loc);
                param.Add("ORD_TYPE", ord_type);
                param.Add("ALCCD", alccd);
                param.Add("ENFOR_DIV", enfor_div);

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

        //context menu 실적 추가 클릭시, 선택한 행의 계획 데이터를 그대로 복사하여 아래쪽에 1행 추가함.
        private void insertItem_Click(object sender, EventArgs e)
        {

            int index = this.grd02.Selection.r2 ;
            int newRowIdx = index + this.grd02.Rows.Fixed;       
            if (this.grd02.DataSource == null)
                this.grd02.InitializeDataSource();

            
            DataTable source = (DataTable)this.grd02.DataSource;

            source.Rows.InsertAt(source.NewRow(), index);

            this.grd02[newRowIdx, 0] = AxFlexGrid.FLAG_N;
            this.grd02[newRowIdx, this.grd02.Cols["CORCD"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["CORCD"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["BIZCD"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["BIZCD"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["RSLT_DATE"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["RSLT_DATE"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["INSTALL_POS"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["INSTALL_POS"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["JOB_TYPE"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["JOB_TYPE"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["JOB_TYPENM"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["JOB_TYPENM"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["SHIFT"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["SHIFT"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["LINECD"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["LINECD"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["PARTNO"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["PARTNO"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["PARTNM"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["PARTNM"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["WORK_ORDNO"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["WORK_ORDNO"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["ORDNO"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["ORDNO"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["SEQNO"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["SEQNO"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["STR_LOC"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["STR_LOC"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["STR_LOCNM"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["STR_LOCNM"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["ORD_TYPE"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["ORD_TYPE"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["ALCCD"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["ALCCD"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["ENFOR_DIV"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["ENFOR_DIV"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["PLAN_QTY"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["PLAN_QTY"].Index];
            this.grd02[newRowIdx, this.grd02.Cols["TOT_RSLT_QTY"].Index] = this.grd02[newRowIdx - 1, this.grd02.Cols["TOT_RSLT_QTY"].Index];

            this.grd02.Row = newRowIdx;
        }

        #region [ 유효성 체크 ]

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

                //2017.11.03 이제 저장위치는 필수 입력 아님.
                //if (this.cdx01_STR_LOC.IsEmpty)
                //{
                //    //{0} 가(이) 입력되지 않았습니다.
                //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_STR_LOC.Text);
                //    return false;
                //}


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
                
                if (this.tabControl1.SelectedIndex == 0)//업무유형 "OEM" 저장인 경우
                {
                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = source.Tables[0].Rows[i];
                        ////Save Only have Value in CHNG_QTY -- 20190807 LYZ
                        if (dr["CHNG_QTY"].ToString() == "" ) continue;

                        int rIdx = Convert.ToInt32(source.Tables[1].Rows[i][0]);
                        
                        DateTime rsltDate = Convert.ToDateTime(dr["RSLT_DATE"]);
                        if (rsltDate < this.GetSysdate().AddDays(-35)) //D-10일 이전 데이터는 변경 금지
                        {
                            //날짜 지정이 올바르지 않습니다.
                            MsgCodeBox.ShowFormat("PD00-0080");
                            return false;
                        }

                        if (dr["PARTNM"].ToString() == "X") //품번명에 "X"인 경우는 엑셀 업로드한 품번이 CD0021, CD0020L에 없는 경우임.
                        {
                            //{0}번째 행에 {1} 정보가 잘 못 입력되었습니다.
                            MsgCodeBox.ShowFormat("CD00-0096", rIdx, this.grd01.Cols["PARTNO"].Caption);
                            return false;
                        }

                        //2017-11-03저장우치 체크 로직 추가함.
                        //저장위치 빈값인 경우는 엑셀 업로드한 품번의 STR_LOC값이 CD0021에서 NULL인 경우
                        //저장위치 X인 경우는 엑셀 업로드한 품번의 CD0021등에 없는 경우임.
                        if (dr["STR_LOC"].ToString() == "X" || dr["STR_LOC"].ToString().Equals(string.Empty)) 
                        {
                            //{0}번째 행에 {1} 정보가 잘 못 입력되었습니다.
                            MsgCodeBox.ShowFormat("CD00-0096", rIdx, this.grd01.Cols["STR_LOC"].Caption);
                            return false;
                        }

                        //해당 품번의 CD0021.LINECD와 화면에서 입력한 LINECD가 다른 경우 저장 불가
                        if (dr["LINECD"].ToString() != this.cdx01_LINECD.GetValue().ToString())
                        {
                            //{0}번째 행에 {1} 정보가 잘 못 입력되었습니다.
                            MsgCodeBox.ShowFormat("CD00-0096", rIdx, this.grd01.Cols["LINECD"].Caption);
                            return false;
                        }

          

                        if (this.GetByteCount(dr["ALCCD"].ToString()) == 0)
                        {
                            //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                            MsgCodeBox.ShowFormat("CD00-0091", rIdx, this.grd01.Cols["ALCCD"].Caption);
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
                        int iCHNG_QTY = 0;
                        int iSUM_QTY = 0;
                        if (!int.TryParse(dr["CHNG_QTY"].ToString(), out iCHNG_QTY))
                        {
                            //{0}번째 행에 {1} 정보가 잘 못 입력되었습니다.
                            MsgCodeBox.ShowFormat("CD00-0096", rIdx, this.grd01.Cols["CHNG_QTY"].Caption);
                            return false;
                        }

                        if (!int.TryParse(dr["SUM_QTY"].ToString(), out iSUM_QTY))
                        {
                            //{0}번째 행에 {1} 정보가 잘 못 입력되었습니다.
                            MsgCodeBox.ShowFormat("CD00-0096", rIdx, this.grd01.Cols["SUM_QTY"].Caption);
                            return false;
                        }

                        if (iCHNG_QTY + iSUM_QTY < 0)
                        {
                            //{0}번째 행에 {1} 정보가 잘 못 입력되었습니다.
                            MsgCodeBox.ShowFormat("CD00-0096", rIdx, this.grd01.Cols["CHNG_QTY"].Caption);
                            return false;
                        }
                    }
                }

                if (this.tabControl1.SelectedIndex == 1) //업무유형 "기타" 저장인 경우
                {
                   
                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = source.Tables[0].Rows[i];
                        int rIdx = Convert.ToInt32(source.Tables[1].Rows[i][0]);

                        if (this.GetByteCount(dr["RSLT_DATE_INPUT"].ToString()) == 0)
                        {  
                            //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                            MsgCodeBox.ShowFormat("CD00-0091", rIdx, this.grd02.Cols["RSLT_DATE_INPUT"].Caption);
                            this.grd02.Row = rIdx;
                            this.grd02.Col = this.grd02.Cols["RSLT_DATE_INPUT"].Index;
                            return false;
                        
                        }
                        DateTime rsltDate = Convert.ToDateTime(dr["RSLT_DATE_INPUT"]);
                        if (rsltDate < this.GetSysdate().AddDays(-35)) //D-10일 이전 데이터는 변경 금지
                        {
                            //날짜 지정이 올바르지 않습니다.
                            MsgCodeBox.ShowFormat("PD00-0080");
                            this.grd02.Row = rIdx;
                            this.grd02.Col = this.grd02.Cols["RSLT_DATE_INPUT"].Index;
                            return false;
                        }

                        //실적일자가 계획일자 이전이어도 저장되도록 변경함. 2018.01.04
                        ////신규로 실적일자와 조정수량을 등록하는 경우에는(계획만 있고 실적이 없었던 경우 data_div값이 PLAN임) 
                        ////실적일자가 계획일자 이전 날짜이면 안된다. 2017.12.12
                        //if (dr["DATA_DIV"].ToString().Equals("PLAN"))
                        //{
                        //    DateTime planDate = Convert.ToDateTime(dr["RSLT_DATE"]); //현재는 RSLT_DATE에 계획일자정보가 있음.
                        //    if (rsltDate < planDate)
                        //    {
                        //        //날짜 지정이 올바르지 않습니다.
                        //        MsgCodeBox.ShowFormat("PD00-0080");
                        //        this.grd02.Row = rIdx;
                        //        this.grd02.Col = this.grd02.Cols["RSLT_DATE_INPUT"].Index;
                        //        return false;
                        //    }
                        //}

                        //조정수량은 필수입력
                        if (dr["CHNG_QTY"].ToString() == "" )//|| dr["CHNG_QTY"].ToString() == "0")
                        {
                            //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                            MsgCodeBox.ShowFormat("CD00-0091", rIdx, this.grd02.Cols["CHNG_QTY"].Caption);
                            this.grd02.Row = rIdx;
                            this.grd02.Col = this.grd02.Cols["CHNG_QTY"].Index;
                            return false;
                        }

                        if (this.GetByteCount(dr["JOB_TYPE"].ToString()) == 0)
                        {
                            //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                            MsgCodeBox.ShowFormat("CD00-0091", rIdx, this.grd02.Cols["JOB_TYPE"].Caption);
                            this.grd02.Row = rIdx;
                            return false;
                        }

                        if (this.GetByteCount(dr["SHIFT"].ToString()) == 0)
                        {
                            //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                            MsgCodeBox.ShowFormat("CD00-0091", rIdx, this.grd02.Cols["SHIFT"].Caption);
                            this.grd02.Row = rIdx;
                            return false;
                        }

                        if (this.GetByteCount(dr["ORDNO"].ToString()) == 0)
                        {
                            //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                            MsgCodeBox.ShowFormat("CD00-0091", rIdx, this.grd02.Cols["ORDNO"].Caption);
                            this.grd02.Row = rIdx;
                            return false;
                        }

                        if (this.GetByteCount(dr["SEQNO"].ToString()) == 0)
                        {
                            //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                            MsgCodeBox.ShowFormat("CD00-0091", rIdx, this.grd02.Cols["SEQNO"].Caption);
                            this.grd02.Row = rIdx;
                            return false;
                        }

                        if (this.GetByteCount(dr["STR_LOC"].ToString()) == 0)
                        {
                            //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                            MsgCodeBox.ShowFormat("CD00-0091", rIdx, this.grd02.Cols["STR_LOC"].Caption);
                            this.grd02.Row = rIdx;
                            return false;
                        }

                        //실적수량 + 조정수량은 0보다 커야함. (총 실적수량은 0보다 커야함)
                        int chngQty = string.IsNullOrEmpty(dr["CHNG_QTY"].ToString()) ? 0 : Convert.ToInt32(dr["CHNG_QTY"]);
                        int sumQty = string.IsNullOrEmpty(dr["SUM_QTY"].ToString()) ? 0 : Convert.ToInt32(dr["SUM_QTY"]);                        
                        
                        if (chngQty + sumQty < 0)
                        {
                            //{0}번째 행에 {1} 정보가 잘 못 입력되었습니다.
                            MsgCodeBox.ShowFormat("CD00-0096", rIdx, this.grd02.Cols["CHNG_QTY"].Caption);
                            return false;
                        }

                        //2017-11-01 총실적합은 계획수량을 초과할수 없음.
                        int planQty = string.IsNullOrEmpty(dr["PLAN_QTY"].ToString()) ? 0 : Convert.ToInt32(dr["PLAN_QTY"]);
                        int totRsltQty = string.IsNullOrEmpty(dr["TOT_RSLT_QTY"].ToString()) ? 0 : Convert.ToInt32(dr["TOT_RSLT_QTY"]);
                        if (totRsltQty > planQty)
                        {
                            //{0} 번째 행의 총실적합은 계획수량을 초과할 수 없습니다.
                            MsgCodeBox.ShowFormat("PD00-0054", rIdx);
                            this.grd02.Row = rIdx;
                            this.grd02.Col = this.grd02.Cols["CHNG_QTY"].Index;
                            return false;
                        }
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


        private DateTime GetSysdate()
        {
            try
            {
                return (DateTime)_WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SYSDATE")).Tables[0].Rows[0][0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool IsQueryValid()
        {
            try
            {
                if (this.tabControl1.SelectedIndex == 0)
                {
                    //if (cdx01_LINECD.ByteCount == 0)
                    //{
                    //    //MsgBox.Show("데이터 조회를 위하여 라인코드를 입력하십시오.");
                    //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_LINECD.Text); // this.GetLabel("LINECD"));
                    //    return false;
                    //}
                    //저장위치 필수 조건에서 제외함.2017-11-03
                    //if (this.cdx01_STR_LOC.IsEmpty)
                    //{
                    //    //{0} 가(이) 입력되지 않았습니다.
                    //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_STR_LOC.Text);
                    //    return false;
                    //}
                }
                else if (this.tabControl1.SelectedIndex == 1)
                {
                    //if (cdx02_LINECD.ByteCount == 0)
                    //{
                    //    //MsgBox.Show("데이터 조회를 위하여 라인코드를 입력하십시오.");
                    //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl02_LINECD.Text);  //this.GetLabel("LINECD"));
                    //    return false;
                    //}
                }
                else
                {

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

        #region [ 사용자 정의 메서드 ]

        private void AddRow()
        {
            this.grdExcel.Rows.Add();
            this.grdExcel.SetValue(1, "PARTNO", "82301-XXXXXXXX");
            this.grdExcel.SetValue(1, "ALCCD", "T01X");            
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
                                                     "         '{3}' AS RSLT_DATE, '{4}' AS JOB_TYPE, '{5}' AS SHIFT, " +
                                                     "          '' AS PLAN_QTY, '' AS RSLT_QTY, '' AS PARTNM, " + 
                                                     "          '' AS INSTALL_POS, '{6}' AS JOB_TYPENM,   " +
                                                     "          '{7}' AS STR_LOCNM, '{8}' AS STR_LOC " +
                                                     " FROM    [{9}]" +
                                                     " WHERE   TRIM([{10}]) <> ''  ",
                                                this.UserInfo.CorporationCode, //CORCD
                                                this.cbo01_BIZCD.GetValue(), //BIZCD
                                                this.cdx01_LINECD.GetValue(), //LINECD
                                                this.dte01_STD_DATE.GetDateText(), //STD_DATE
                                                "0",  //JOB_TYPE
                                                "1", //SHIFT
                                                "A10",  //JOB_TYPENM
                                                string.Empty,
                                                string.Empty,
                                                worksheets.Rows[0]["TABLE_NAME"], //SHEET NAME
                                                this.grdExcel.Cols["PARTNO"].Caption, //PART NO
                                                this.grdExcel.Cols["PARTNO"].Caption); //PART NO
                OleDbCommand commend = new OleDbCommand(commandString, oleDB);
                OleDbDataAdapter adapter = new OleDbDataAdapter(commend);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                oleDB.Close();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("PARTNO", dr["PARTNO"].ToString());
                    set.Add("LANG_SET", this.UserInfo.Language);
                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", this.PACKAGE_NAME, "INQUERY_PARTNO"), set);
                    if (source.Tables[0].Rows.Count > 0)
                    {
                        dr["PARTNM"] = source.Tables[0].Rows[0]["PARTNM"].ToString();
                        dr["INSTALL_POS"] = source.Tables[0].Rows[0]["INSTALL_POS"].ToString();
                        dr["LINECD"] = source.Tables[0].Rows[0]["LINECD"].ToString();  //ACD0021로부터 해당 PARTNO의 LINECD를 가져온다.

                        dr["STR_LOC"] = source.Tables[0].Rows[0]["STR_LOC"].ToString();  //ACD0021로부터 해당 PARTNO의 STR_LOC를 가져온다.
                        dr["STR_LOCNM"] = source.Tables[0].Rows[0]["STR_LOC"].ToString();  //ACD0021로부터 해당 PARTNO의 STR_LOC를 가져온다.
                    }
                    else
                    {
                        dr["PARTNM"] = "X";
                        dr["INSTALL_POS"] = "X";
                        dr["LINECD"] = "X";
                        dr["STR_LOC"] = "X";
                        dr["STR_LOCNM"] = "X";
                    }

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

        private DataTable GetSTR_LOC()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", "APG_PD23110", "INQUERY_STR_LOC"), set);

                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                throw ex;
            }
        }
        #endregion
        
        private void txt01_REMARK_TextChanged(object sender, EventArgs e)
        {
            int row = grd01.RowSel;

            if (row < this.grd01.Rows.Fixed || row >= this.grd01.Rows.Count) return;

            this.grd01.SetValue(row, "REMARKS", txt01_REMARK.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                label1.Visible = true;
                axDateEdit1.Visible = true;
            }
            else
            {
                label1.Visible = false;
                axDateEdit1.Visible = false;
            }
        }
    }
}
