#region ▶ Description & History
/* 
 * 프로그램명 : QA20920 직거래부품 분리 입고실적
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2016-12-15      이재한      신규생성
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
using C1.Win.C1FlexGrid;
using System.IO;
using HE.Framework.ServiceModel;
using System.Drawing;

using System.Diagnostics;
using System.Threading;

namespace Ax.SIS.QA.QA02.UI
{
    /// <summary>
    /// <b>직거래부품 분리 입고실적</b>
    /// - 작 성 자 : 이재한<br />
    /// - 작 성 일 : 2016-12-15 오후 4:59:51<br />
    /// </summary>
    public partial class QA20920 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_QA20920";
        private bool _isLoadCompleted = false;
        private bool _calendarDroppedDown = false;
        
        public QA20920()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }
        
        #region [ 초기화 작업 정의 ]

        /// <summary>
        /// [ 화면 초기 설정 ]
        /// </summary>
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                #region [ 코드 데이터 호출 ]

                #endregion

                #region [ 입고실적 다운로드 TAB 설정 ]

                #region [ 입고실적 다운로드 그리드 설정 ]

                // 그리드 설정
                this.grd01.AllowEditing = true;
                this.grd01.Initialize(1, 1);

                //this.grd01.Initialize();
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "법인구분", "IPGO_CORP", "IPGO_CORP");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "회사구분", "IPGO_HKMC", "COMP_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "년도", "IPGO_YEAR", "YYYY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 030, "월", "IPGO_MONT", "MONTH");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "승상구분", "IPGO_SSGB", "IPGO_SSGB");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "업체코드", "IPGO_VANC", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "실적코드", "MOD_VANB", "MOD_VANB");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "평가종류", "EVAL_KIND", "EVAL_KIND");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "입고구분", "IPGO_GUBN", "RCV_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "지역코드", "IPGO_REGN", "REGNCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "공장코드", "IPGO_PLNT", "PLANTCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "품번", "IPGO_PTNO", "PARTNO3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "품목특성", "ITEM_PROP", "ITEM_PROP");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "업종", "IPGO_CLAS", "BIZ_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "평가품목", "EVAL_ITEM", "EVAL_ITEM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "관리품목", "ADMI_ITEM", "ADMI_ITEM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 250, "품명", "IPGO_PTNM", "PARTNONM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "입고금액", "IPGO_IMNY", "RCV_AMT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "전공장입고수량", "IPGO_ICNT", "IPGO_ICNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "전공장반송수량", "IPGO_RCNT", "IPGO_RCNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "이의제기수량", "IPGO_OCNT", "IPGO_OCNT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 130, "공장반송불량율(PPM)", "IPGO_PPM", "IPGO_PPM");

                #region [ 그리드내 포멧 설정 ]

                // 그리드내 포멧 설정
                //this.grd01.SetColumnType(HEFlexGrid.FCellType.Date, "MOD_DATE");
                //this.grd01.Cols["MOD_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "IPGO_IMNY");
                this.grd01.Cols["IPGO_IMNY"].Format = "###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "IPGO_ICNT");
                this.grd01.Cols["IPGO_ICNT"].Format = "###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "IPGO_RCNT");
                this.grd01.Cols["IPGO_RCNT"].Format = "###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "IPGO_OCNT");
                this.grd01.Cols["IPGO_OCNT"].Format = "###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "IPGO_PPM");
                this.grd01.Cols["IPGO_PPM"].Format = "###,###,###,##0";
                //this.grd01.SetColumnType(HEFlexGrid.FCellType.Check, "USE_YN");

                // 그리드내 콤보데이터 설정
                //this.grd01.SetColumnType(HEFlexGrid.FCellType.ComboBox, dsWORK_DIV_BASE.Tables[0], "MAPPINGCD");

                #endregion

                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
                //this.grd01.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                this.grd01.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
                this.grd01.AllowSorting = AllowSortingEnum.SingleColumn;
                //this.grd01.AllowSorting = AllowSortingEnum.None;    // 등록화면에는 정렬시 순번의 상태값이 움직이지 않는 버그로 인해 정렬 비활성화
                this.grd01.InitializeDataSource();
                //this.grd01.Cols["GA_DESTINY_NM"].StyleDisplay.WordWrap = true;
                //this.grd01.Rows[0].Height = 35; //헤더 높이 재 설정
                //this.grd01.AddConextMenuSetting();  // 전체 행 삭제 및 전체 행 취소 툴팁 추가
                //this.grd01.Cols.Frozen = 1;

                // 그리드 행추가 행삭제 안되게 설정
                this.grd01.CurrentContextMenu.Items[0].Visible = false;   // 행추가
                this.grd01.CurrentContextMenu.Items[1].Visible = false;   // 행삭제
                this.grd01.CurrentContextMenu.Items[2].Visible = false;   // 행취소
                this.grd01.CurrentContextMenu.Items[3].Visible = false;   // 구분선

                // 엑셀 불러오기 툴팁 추가
                ToolStripMenuItem load_excel = new ToolStripMenuItem(this.GetLabel("EXCEL_UPLOAD"));
                load_excel.Click += new EventHandler(Load_ExcelSheet);
                this.grd01.CurrentContextMenu.Items.Add(load_excel);

                #endregion

                // 초기화
                Reset_01(null, null);

                #endregion

                #region [ 입고실적 업로드 TAB 설정 ]

                #region [ 입고실적 업로드 그리드 설정 ]

                // 그리드 설정
                this.grd11.AllowEditing = true;
                this.grd11.Initialize(1, 1);

                //this.grd11.Initialize();
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "법인구분", "IPGO_CORP", "IPGO_CORP");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "회사구분", "IPGO_HKMC", "COMP_DIV");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "년도", "IPGO_YEAR", "YYYY");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 030, "월", "IPGO_MONT", "MONTH");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "개발구분", "DEV_GUBN", "DEV_DIV");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "승상구분", "IPGO_SSGB", "IPGO_SSGB");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "업체코드", "IPGO_VANC", "VENDCD");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "실적코드", "MOD_VANB", "MOD_VANB");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "서브사코드", "SUB_VANB", "SUB_VANB");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "입고구분", "IPGO_GUBN", "RCV_DIV");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "지역코드", "IPGO_REGN", "REGNCD");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "공장코드", "IPGO_PLNT", "PLANTCD");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "품번", "IPGO_PTNO", "PARTNO3");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "서브품번", "SUB_PTNO", "SUB_PTNO");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "중간품번", "MID_PTNO", "MID_PTNO");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "업종", "IPGO_CLAS", "BIZ_TYPE");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 250, "품명", "IPGO_PTNM", "PARTNONM");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 250, "서브품명", "SUB_PTNM", "SUB_PTNM");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "중간품명", "MID_PTNM", "MID_PTNM");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "입고금액", "IPGO_IMNY", "RCV_AMT");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "전공장입고수량", "IPGO_ICNT", "IPGO_ICNT");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "전공장반송수량", "IPGO_RCNT", "IPGO_RCNT");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "서브USAGE", "SUB_USAGE", "SUB_USAGE");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "서브입고단가", "SUB_PRICE", "SUB_PRICE");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "서브입고수량", "SUB_QTY", "SUB_QTY");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "서브입고금액", "SUB_AMT", "SUB_AMT");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "하드웨어소물류", "DIST_YN", "DIST_YN");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "AS공급단위", "AS_UNIT", "AS_UNIT");
                this.grd11.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "평가대상여부", "EVAL_TGT", "EVAL_TGT");
                //this.grd11.Cols[0].Visible = false;
                this.grd11.RemoveColumn(0);
                this.grd11.Cols.Fixed = 0;

                #region [ 그리드내 포멧 설정 ]

                // 그리드내 포멧 설정
                //this.grd11.SetColumnType(HEFlexGrid.FCellType.Date, "MOD_DATE");
                //this.grd11.Cols["MOD_DATE"].Format = "yyyy-MM-dd";
                //this.grd11.SetColumnType(HEFlexGrid.FCellType.Decimal, "IPGO_IMNY");
                //this.grd11.Cols["IPGO_IMNY"].Format = "###,###,###,##0";
                //this.grd11.SetColumnType(HEFlexGrid.FCellType.Check, "USE_YN");

                // 그리드내 콤보데이터 설정
                //this.grd11.SetColumnType(HEFlexGrid.FCellType.ComboBox, dsWORK_DIV_BASE.Tables[0], "MAPPINGCD");

                #endregion

                this.grd11.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
                //this.grd11.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                this.grd11.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
                this.grd11.AllowSorting = AllowSortingEnum.SingleColumn;
                //this.grd11.AllowSorting = AllowSortingEnum.None;    // 등록화면에는 정렬시 순번의 상태값이 움직이지 않는 버그로 인해 정렬 비활성화
                this.grd11.InitializeDataSource();
                //this.grd11.Cols["GA_DESTINY_NM"].StyleDisplay.WordWrap = true;
                //this.grd11.Rows[0].Height = 35; //헤더 높이 재 설정
                //this.grd11.AddConextMenuSetting();  // 전체 행 삭제 및 전체 행 취소 툴팁 추가
                //this.grd11.Cols.Frozen = 1;

                // 그리드 행추가 행삭제 안되게 설정
                this.grd11.CurrentContextMenu.Items[0].Visible = false;   // 행추가
                this.grd11.CurrentContextMenu.Items[1].Visible = false;   // 행삭제
                this.grd11.CurrentContextMenu.Items[2].Visible = false;   // 행취소
                this.grd11.CurrentContextMenu.Items[3].Visible = false;   // 구분선

                #endregion

                #region [ 입고실적 (바츠업로드데이터 엑셀다운로드) 그리드 설정 ]

                // 그리드 설정
                this.grd11_excel.AllowEditing = false;
                this.grd11_excel.Initialize(1, 1);

                //this.grd11_excel.Initialize();
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "IPGO_CORP", "IPGO_CORP");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "IPGO_HKMC", "IPGO_HKMC");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "IPGO_YEAR", "IPGO_YEAR");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 030, "IPGO_MONT", "IPGO_MONT");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "DEV_GUBN", "DEV_GUBN");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "IPGO_SSGB", "IPGO_SSGB");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "IPGO_VANC", "IPGO_VANC");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "MOD_VANB", "MOD_VANB");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "SUB_VANB", "SUB_VANB");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "IPGO_GUBN", "IPGO_GUBN");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "IPGO_REGN", "IPGO_REGN");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "IPGO_PLNT", "IPGO_PLNT");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "IPGO_PTNO", "IPGO_PTNO");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "SUB_PTNO", "SUB_PTNO");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "MID_PTNO", "MID_PTNO");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "IPGO_CLAS", "IPGO_CLAS");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 250, "IPGO_PTNM", "IPGO_PTNM");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 250, "SUB_PTNM", "SUB_PTNM");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "MID_PTNM", "MID_PTNM");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "IPGO_IMNY", "IPGO_IMNY");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "IPGO_ICNT", "IPGO_ICNT");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "IPGO_RCNT", "IPGO_RCNT");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "SUB_USAGE", "SUB_USAGE");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "SUB_PRICE", "SUB_PRICE");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "SUB_QTY", "SUB_QTY");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "SUB_AMT", "SUB_AMT");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "DIST_YN", "DIST_YN");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "AS_UNIT", "AS_UNIT");
                this.grd11_excel.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "EVAL_TGT", "EVAL_TGT");
                //this.grd11_excel.Cols[0].Visible = false;
                this.grd11_excel.RemoveColumn(0);
                this.grd11_excel.Cols.Fixed = 0;

                this.grd11_excel.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.MultiColumn;
                this.grd11_excel.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
                this.grd11_excel.AllowSorting = AllowSortingEnum.SingleColumn;
                this.grd11_excel.InitializeDataSource();

                #endregion

                // 초기화
                Reset_11(null, null);

                #endregion

                #region [ 기타 설정 ]

                // 필수입력 항목 표시
                //this.SetRequired(lbl01_VENDCD, lbl11_PARTNO);

                // 버튼 초기화
                tab01_SelectedIndexChanged(null, null);

                // 기본 조회
                this.BtnQuery_Click(null, null);
                //_isbinding = false;

                _isLoadCompleted = true;

                #endregion
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        /// <summary>
        /// [ 조회 버튼 Click 이벤트 ]
        /// </summary>
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            if (tab01_main.SelectedIndex == 0)
            {
                Query_01(sender, e);
            }
            else if (tab01_main.SelectedIndex == 1)
            {
                Query_11(sender, e);
            }
        }

        /// <summary>
        /// [ 초기화 버튼 Click 이벤트트 ]
        /// </summary>
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            if (tab01_main.SelectedIndex == 0)
            {
                Reset_01(sender, e);
            }
            else if (tab01_main.SelectedIndex == 1)
            {
                Reset_11(sender, e);
            }
        }

        /// <summary>
        /// [ 저장 버튼 Click 이벤트트 ]
        /// </summary>
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            if (tab01_main.SelectedIndex == 0)
            {
                Save_01(sender, e);
            }
        }

        /// <summary>
        /// [ 삭제 버튼 Click 이벤트트 ]
        /// </summary>
        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            if (tab01_main.SelectedIndex == 0)
            {
                Delete_01(sender, e);
            }
        }

        /// <summary>
        /// [ 처리 버튼 Click 이벤트 ]
        /// </summary>
        protected override void BtnProcess_Click(object sender, EventArgs e)
        {
            if (tab01_main.SelectedIndex == 1)
            {
                Process_11(sender, e);
            }
        }

        #endregion

        #region [ 사용자 정의 method -공통- ]

        /// <summary>
        /// [ 텝 선택에 따른 버튼 ENABLE SETTING ]
        /// </summary>
        private void tab01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab01_main.SelectedIndex == 0)
            {
                this.GetCommonButton(COMMONBUTTONTYPE.QUERY).Enabled = true;
                this.GetCommonButton(COMMONBUTTONTYPE.RESET).Enabled = true;
                this.GetCommonButton(COMMONBUTTONTYPE.SAVE).Enabled = true;
                this.GetCommonButton(COMMONBUTTONTYPE.DELETE).Enabled = true;
                this.GetCommonButton(COMMONBUTTONTYPE.PROCESS).Enabled = false;
                this.GetCommonButton(COMMONBUTTONTYPE.DOWNLOAD).Enabled = true;

                if (_isLoadCompleted)
                {
                    // 데이터 조회
                    //this.BtnQuery_Click(null, null);
                }
            }
            else if (tab01_main.SelectedIndex == 1)
            {
                this.GetCommonButton(COMMONBUTTONTYPE.QUERY).Enabled = true;
                this.GetCommonButton(COMMONBUTTONTYPE.RESET).Enabled = true;
                this.GetCommonButton(COMMONBUTTONTYPE.SAVE).Enabled = false;
                this.GetCommonButton(COMMONBUTTONTYPE.DELETE).Enabled = false;
                this.GetCommonButton(COMMONBUTTONTYPE.PROCESS).Enabled = true;
                this.GetCommonButton(COMMONBUTTONTYPE.DOWNLOAD).Enabled = true;

                if (_isLoadCompleted)
                {
                    // 데이터 조회
                    //this.BtnQuery_Click(null, null);
                }
            }
        }

        /// <summary>
        /// [ 텝 선택에 따른 이전 TAB MOVE ]
        /// </summary>
        private void tab01_main_Selecting(object sender, TabControlCancelEventArgs e)
        {
            /*if (e.TabPageIndex == 4)
            {
                MsgBox.Show("개발중입니다.");
                e.Cancel = true;
            }*/
        }

        /// <summary>
        /// [ 그리드 및 바인딩 데이터 초기화 ]
        /// </summary>
        private void Reset_Grid_BindingData(int v_Tabindex)
        {
            if (v_Tabindex == 0)
            {
                this.grd01.InitializeDataSource();
            }
        }

        /// <summary>
        /// [ 엑셀 업로드 함수 호출 ]
        /// </summary>
        private void Load_ExcelSheet(object sender, EventArgs e)
        {
            if (tab01_main.SelectedIndex == 0)
            {
                ImportExcel_01(sender, e);
            }
        }

        #endregion

        #region [ TAB 별 이벤트 설정 ]

        #region [ 입고실적 다운로드 TAB ]

        #region [ 그리드 컨트롤에 대한 이벤트 정의 ]

        /// <summary>
        /// [ 그리드에서 행취소 클릭시 발생되는 이벤트 ]
        /// </summary>
        private void grd01_RowCanceled(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                //이 이벤트는 수정, 삭제에만 일어나야함.
                for (int i = 0; i < args.RowCount; i++)
                {
                    //행취소시 배경색 초기화
                    if (args.RowIndex + i <= grd.Rows.Count - grd.Rows.Fixed)
                    {
                        if (grd[args.RowIndex + i, 0].ToString() != "N")
                        {
                            grd.Rows[args.RowIndex + i].StyleNew.Clear();
                        }
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        /// <summary>
        /// [ 조회 카렌더박스 값 변경시 ]
        /// </summary>
        private void dte01_ValueChanged(object sender, EventArgs e)
        {
            AxDateEdit dte = (AxDateEdit)sender;
            string value = dte.GetDateText().Substring(0, 7).ToString();
            if (value.Length == 7) value = value + "-01";

            // 카렌더 팝업에서 값 변경시 무한 valuechanged 발생하여 추가
            if (_calendarDroppedDown) return;

            if (_isLoadCompleted)
            {
                if (sender.Equals(dte01_YYYYMM) || sender.Equals(dte11_YYYYMM))
                {
                    if (!sender.Equals(dte11_YYYYMM)) this.dte11_YYYYMM.SetValue(value);
                    if (!sender.Equals(dte11_YYYYMM)) this.dte11_YYYYMM.SetValue(value);
                }
                // 그리드 및 바인딩 데이터 초기화
                //Reset_Grid_BindingData(tab01_main.SelectedIndex);
                for (int i = 0; i < this.tab01_main.TabCount; i++)
                {
                    // 그리드 및 바인딩 데이터 초기화
                    Reset_Grid_BindingData(i);
                }
            }
        }

        /// <summary>
        /// [ 카렌더 팝업에서 값 변경시 무한 valuechanged 발생하여 추가 ]
        /// </summary>
        private void dte01_DropDown(object sender, EventArgs e)
        {
            _calendarDroppedDown = true;
        }

        /// <summary>
        /// [ 카렌더 팝업에서 값 변경시 무한 valuechanged 발생하여 추가 ]
        /// </summary>
        private void dte01_CloseUp(object sender, EventArgs e)
        {
            _calendarDroppedDown = false;

            dte01_ValueChanged(sender, e);
        }

        #endregion

        #region [ 사용자 정의 method ]

        /// <summary>
        /// [ TAB1 조회 함수 ]
        /// </summary>
        private void Query_01(object sender, EventArgs e)
        {
            try
            {
                // 파라메타 입력
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("YYYYMM", this.dte01_YYYYMM.GetDateText().Substring(0, 7).Replace("-", ""));
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                if (!IsQueryValid_01(paramSet)) return;

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA4220"), paramSet);
                this.grd01.SetValue(source.Tables[0]);
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

        /// <summary>
        /// [ TAB1 조회 유효성 체크 함수 ]
        /// </summary>
        private bool IsQueryValid_01(HEParameterSet paramSet)
        {
            try
            {
                // 조회연월 체크
                if (paramSet["YYYYMM"].ToString().Length == 0)
                {
                    MsgCodeBox.Show("CD00-0111");
                    //MsgBox.Show("조회연월을 입력하세요.");
                    this.dte01_YYYYMM.Focus();
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

        /// <summary>
        /// [ TAB1 초기화 함수 ]
        /// </summary>
        private void Reset_01(object sender, EventArgs e)
        {
            try
            {
                //this.BeforeInvokeServer();
                //this.dte01_YYYYMM.Initialize();
                this.dte01_YYYYMM.SetValue(DateTime.Today.AddMonths(-2).ToShortDateString());

                this.grd01.InitializeDataSource();
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

        /// <summary>
        /// [ TAB1 저장 함수 ]
        /// </summary>
        private void Save_01(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01.GetValue(
                      AxFlexGrid.FActionType.Save
                    , "CORCD"
                    , "REG_EMPNO"
                    , "IPGO_CORP"
                    , "IPGO_HKMC"
                    , "IPGO_YEAR"
                    , "IPGO_MONT"
                    , "IPGO_SSGB"
                    , "IPGO_VANC"
                    , "MOD_VANB"
                    , "EVAL_KIND"
                    , "IPGO_GUBN"
                    , "IPGO_REGN"
                    , "IPGO_PLNT"
                    , "IPGO_PTNO"
                    , "ITEM_PROP"
                    , "IPGO_CLAS"
                    , "EVAL_ITEM"
                    , "ADMI_ITEM"
                    , "IPGO_PTNM"
                    , "IPGO_IMNY"
                    , "IPGO_ICNT"
                    , "IPGO_RCNT"
                    , "IPGO_OCNT"
                    , "IPGO_PPM"
                );
                //source.Tables[0].Columns["HR_EMPNO"].ColumnName = "EMPNO";

                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                    dr["REG_EMPNO"] = this.UserInfo.EmpNo;
                }
                //source.Tables[0].Columns.Remove("OBJECT_ID");

                // 직거래 입고실적 다운로드 삭제로직 데이터셋 생성
                DataSet source2 = AxFlexGrid.GetDataSourceSchema(
                      "CORCD"
                    , "YYYYMM"
                );
                DataRow drDelete = source2.Tables[0].NewRow();
                drDelete["CORCD"] = this.UserInfo.CorporationCode;
                drDelete["YYYYMM"] = this.dte01_YYYYMM.GetDateText().Substring(0, 7).Replace("-", "");
                source2.Tables[0].Rows.Add(drDelete);

                // 직거래 부품단가,직거래 입고실적 모듈처리용 임시BOM 생성로직 데이터셋 생성
                DataSet source3 = AxFlexGrid.GetDataSourceSchema(
                      "CORCD"
                    , "REG_EMPNO"
                    , "YYYYMM"
                );
                DataRow drCreate = source3.Tables[0].NewRow();
                drCreate["CORCD"] = this.UserInfo.CorporationCode;
                drCreate["REG_EMPNO"] = this.UserInfo.EmpNo;
                drCreate["YYYYMM"] = this.dte01_YYYYMM.GetDateText().Substring(0, 7).Replace("-", "");
                source3.Tables[0].Rows.Add(drCreate);

                if (!IsSaveValid_01(this.grd01, source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.ExecuteNonQueryTx("APG_QA20920.SAVE_QA4220", source);
                AxClientProxy proxy = new AxClientProxy();
                proxy.MultipleExecuteNonQueryTx(
                                        new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE_QA4220"), 
                                                       string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_QA4220"), 
                                                       string.Format("{0}.{1}", PAKAGE_NAME, "PROCESS_QA4212_QA4222") },
                                        new DataSet[] { source2, source, source3 });

                this.AfterInvokeServer();

                BtnQuery_Click(null, null);

                //#001
                //MsgBox.Show("정상적으로 저장되었습니다.");
                MsgCodeBox.Show("CD00-0009");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                //MsgBox.Show(ex.ToString());
                if (ex.Message.ToString().Split('|').Length > 1)
                {
                    MsgBox.Show(ex.Message.ToString().Split('|')[1].Replace('_', '\n'));
                }
                else
                {
                    MsgBox.Show(ex.Message.ToString());
                }
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        /// <summary>
        /// [ TAB1 저장 체크 함수 ]
        /// </summary>
        private bool IsSaveValid_01(object sender, DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //#001
                    //MsgBox.Show("저장할 데이터가 존재하지 않습니다.");
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                AxFlexGrid grd = (AxFlexGrid)sender;

                //souce라는 DataSet에는 테이블이 2개 있음
                //[0]번째 테이블은 그리드에서 추출한 데이터
                //[1]번째 테이블은 행번호 데이터
                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = source.Tables[0].Rows[i];
                    int rowIndex = Convert.ToInt32(source.Tables[1].Rows[i][0]);

                    if (this.GetByteCount(dr["IPGO_CORP"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["IPGO_CORP"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["IPGO_HKMC"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["IPGO_HKMC"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["IPGO_YEAR"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["IPGO_YEAR"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["IPGO_MONT"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["IPGO_MONT"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["IPGO_SSGB"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["IPGO_SSGB"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["IPGO_VANC"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["IPGO_VANC"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["MOD_VANB"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["MOD_VANB"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["IPGO_GUBN"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["IPGO_GUBN"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["IPGO_REGN"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["IPGO_REGN"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["IPGO_PLNT"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["IPGO_PLNT"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(dr["IPGO_PTNO"].ToString()) == 0)
                    {
                        //{0} 번째 행에 {1} 가 입력되지 않았습니다.
                        MsgCodeBox.ShowFormat("CD00-0091", rowIndex, grd.Cols["IPGO_PTNO"].Caption);
                        return false;
                    }
                }

                //저장하시겠습니까?
                //if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel) != DialogResult.OK)
                string v_YYYY = this.dte01_YYYYMM.GetDateText().Substring(0, 7).Replace("-", "").Substring(0, 4);
                string v_MM = this.dte01_YYYYMM.GetDateText().Substring(0, 7).Replace("-", "").Substring(4, 2);
                // {0}년{1}월 데이터를 저장하시겠습니까?\r\n(단, 등록된 [{0}년{1}월]의 기존데이터는 삭제됩니다.)\r\n저장완료후 [QA20910] 직거래부품 부품 단가정보의 기준데이터가 생성됩니다.
                if (MsgCodeBox.ShowFormat("QA02-0057", MessageBoxButtons.OKCancel, v_YYYY, v_MM) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        /// <summary>
        /// [ TAB1 삭제 함수 ]
        /// </summary>
        private void Delete_01(object sender, EventArgs e)
        {
            try
            {
                DataSet source = AxFlexGrid.GetDataSourceSchema(
                      "CORCD"
                    , "YYYYMM"
                );
                DataRow drDelete = source.Tables[0].NewRow();
                drDelete["CORCD"] = this.UserInfo.CorporationCode;
                drDelete["YYYYMM"] = this.dte01_YYYYMM.GetDateText().Substring(0, 7).Replace("-", "");
                source.Tables[0].Rows.Add(drDelete);

                if (!IsDeleteValid_01(this.grd01, source)) return;

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE_QA4220"), source);
                this.AfterInvokeServer();

                BtnQuery_Click(null, null);

                //#001
                //MsgBox.Show("정상적으로 삭제되었습니다.");
                MsgCodeBox.Show("CD00-0010");
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

        /// <summary>
        /// [ TAB1 삭제 체크 함수 ]
        /// </summary>
        private bool IsDeleteValid_01(object sender, DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //#001
                    //MsgBox.Show("삭제할 데이터가 존재하지 않습니다");
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }

                //#001
                //if (MsgBox.Show("삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        /// <summary>
        /// [ TAB1 엑셀업로드 함수 ]
        /// </summary>
        private void ImportExcel_01(object sender, EventArgs e)
        {
            try
            {
                this.ofdExcel.Filter = this.GetLabel("EXCEL_FILTER");
                this.ofdExcel.FilterIndex = 2;

                DialogResult result = this.ofdExcel.ShowDialog(this);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    ImportExcelFile_01(ofdExcel.FileName);
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

        /// <summary>
        /// 읽어온 엑셀 파일을 그리드에 채운다.
        /// </summary>
        /// <param name="filePath"></param>
        private void ImportExcelFile_01(string filePath)
        {
            try
            {
                string file_name = filePath;
                if (file_name.Length == 0) return;
                //if (!this.IsVaildFile(file_name))
                //{
                //    MessageBox.Show("파일에 접근할 수 없습니다. 파일이 열려있는지 확인하세요.");
                //    return;
                //}

                int ExcelVersion = this.ExcelFileType(file_name);
                if (!(ExcelVersion == 1 || ExcelVersion == 0))
                {
                    this.AfterInvokeServer();
                    //MsgBox.Show("EXCEL 파일이 아닙니다.");
                    MsgCodeBox.Show("CD00-0113");
                    return;
                    
                }

                AxFlexGrid grdExcel = new AxFlexGrid();
                //grdExcel.LoadExcel(file_name, FileFlags.VisibleOnly);
                grdExcel.LoadExcel(file_name);

                DataTable excelTable = new DataTable();
                excelTable.TableName = "EXCELTABLE";

                // 엑셀 불러오기 담을 그리드 초기화
                //grd01_excel.Rows.Remove(0);
                foreach (C1.Win.C1FlexGrid.Column c in grd01.Cols)
                {
                    //if (c.IsVisible == true)
                    excelTable.Columns.Add(c.Name);
                }

                // grd01_excel은 3,1 부터 시작 (헤더 2이면 3)
                int start_row = this.grd01.Rows.Fixed + 1 + 1;
                int insert_yyyymm_row = 0;
                for (int i = start_row; i < grdExcel.Rows.Count; i++)
                {
                    // 2번째행 [지급연월]이 존재하는 데이터만 생성
                    if (grdExcel.Rows[i][2] != null && !String.IsNullOrEmpty(grdExcel.Rows[i][2].ToString()))
                    {
                        DataRow row = excelTable.NewRow();
                        excelTable.Rows.Add(row);
                    }

                    // 순번을 제외한 항목 데이터 가져옴
                    for (int k = 1; k < grdExcel.Cols.Count; k++)
                    {
                        if (grdExcel.Rows[i][2] != null && !String.IsNullOrEmpty(grdExcel.Rows[i][2].ToString()))
                        {
                            excelTable.Rows[i - start_row][k - 1] = grdExcel.Rows[i][k];
                        }
                    }

                    if (insert_yyyymm_row == 0)
                    {
                        // 첫번째 데이터연월 조회조건에 셋팅
                        this.dte01_YYYYMM.SetValue(grdExcel.Rows[i][4].ToString() + "-" + grdExcel.Rows[i][5].ToString() + "-01");
                        insert_yyyymm_row = insert_yyyymm_row + 1;
                    }
                }

                try
                {
                    this.grd01.SetValue(excelTable);
                    for (int row = this.grd01.Rows.Fixed; row < grd01.Rows.Count; row++)
                    {
                        //그리드(바인딩후)
                        this.grd01[row, 0] = AxFlexGrid.FLAG_N;

                        // 현금비율 100% 고정
                        /*this.grd01[row, "Y_RATE"] = "100";
                        this.grd01[row, "Z_RATE"] = "0";
                        this.grd01[row, "Y_AMOUNT"] = "0";*/

                        //신규행 배경색 설정
                        //for (int i = 0; i < grd.Cols.Count; i++)
                        //{
                        grd01.Rows[row].StyleNew.BackColor = Color.Bisque;
                        //}
                    }

                    // MsgBox.Show(string.Format("{0}개의 행을 추가하였습니다.", excelTable.Rows.Count));
                    // {0}개의 행을 추가하였습니다.
                    //MsgCodeBox.ShowFormat("HR06-0021", excelTable.Rows.Count);

                    // 자동 저장
                    this.BtnSave_Click(null, null);
                }
                catch (Exception ex)
                {
                    //MsgBox.Show("파일을 읽는 도중 오류가 발생하였습니다 : " + ex.Message);
                    // 파일을 읽는 도중 오류가 발생하였습니다. : {0}
                    MsgCodeBox.ShowFormat("CD00-0114", ex.Message);
                }
                finally
                {

                }
            }
            catch (Exception ex)
            {
                //MsgBox.Show("파일을 읽는 도중 오류가 발생하였습니다 : " + ex.Message);
                // 파일을 읽는 도중 오류가 발생하였습니다. : {0}
                MsgCodeBox.ShowFormat("CD00-0114", ex.Message);
            }
        }

        #endregion

        #endregion

        #region [ 입고실적 업로드 TAB ]

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        /// <summary>
        /// [ 조회 카렌더박스 값 변경시 ]
        /// </summary>
        private void dte11_ValueChanged(object sender, EventArgs e)
        {
            AxDateEdit dte = (AxDateEdit)sender;
            string value = dte.GetDateText().Substring(0, 7);
            if (value.Length == 7) value = value + "-01";

            // 카렌더 팝업에서 값 변경시 무한 valuechanged 발생하여 추가
            if (_calendarDroppedDown) return;

            if (_isLoadCompleted)
            {
                if (sender.Equals(dte01_YYYYMM) || sender.Equals(dte11_YYYYMM))
                {
                    if (!sender.Equals(dte11_YYYYMM)) this.dte11_YYYYMM.SetValue(value);
                    if (!sender.Equals(dte11_YYYYMM)) this.dte11_YYYYMM.SetValue(value);
                }
                // 그리드 및 바인딩 데이터 초기화
                //Reset_Grid_BindingData(tab01_main.SelectedIndex);
                for (int i = 0; i < this.tab01_main.TabCount; i++)
                {
                    // 그리드 및 바인딩 데이터 초기화
                    Reset_Grid_BindingData(i);
                }
            }
        }

        /// <summary>
        /// [ 카렌더 팝업에서 값 변경시 무한 valuechanged 발생하여 추가 ]
        /// </summary>
        private void dte11_DropDown(object sender, EventArgs e)
        {
            _calendarDroppedDown = true;
        }

        /// <summary>
        /// [ 카렌더 팝업에서 값 변경시 무한 valuechanged 발생하여 추가 ]
        /// </summary>
        private void dte11_CloseUp(object sender, EventArgs e)
        {
            _calendarDroppedDown = false;

            dte11_ValueChanged(sender, e);
        }

        /// <summary>
        /// [ 바츠업로드데이터 엑셀다운로드 ]
        /// </summary>
        private void btn11_EXCELDOWN_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd11_excel.GetValue(AxFlexGrid.FActionType.All);
                if (source.Tables[0].Rows.Count == 0)
                {
                    //#001
                    //MsgBox.Show("조회된 데이터가 없습니다.");
                    MsgCodeBox.Show("CD00-0039");
                    return;
                }

                // 엑셀파일로 저장
                /*string saveFileName = string.Empty;
                // 엑셀 파일 확장자가 포함되어 있는지 확인해야 함
                saveFileName = this.ParentForm.Name;
                saveFileName = ShowDialogPopup(CoreHelper.GetFileFilter(FILETYPE.EXCEL), saveFileName);
                // 팝업창을 띄워준 후 엑셀 출력
                if (!string.IsNullOrEmpty(saveFileName))
                {
                    this.grd02_excel.SaveExcel(saveFileName, FileFlags.IncludeFixedCells);
                }*/
                // 엑셀 바로보기
                string temp_path = @"C:\Temp";
                if (!Directory.Exists(temp_path))
                    Directory.CreateDirectory(temp_path);

                string temp_file = String.Format(@"{0}\{1}.xls", temp_path, Guid.NewGuid().ToString());
                FileFlags flags = FileFlags.IncludeFixedCells | FileFlags.AsDisplayed | FileFlags.IncludeMergedRanges;

                this.grd11_excel.SaveExcel(temp_file, flags);
                Thread.Sleep(2000);

                Process.Start(temp_file);
            }
            /*catch (Exception ex)
            {
                throw;
            }*/
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

        #region [ 사용자 정의 method ]

        /// <summary>
        /// [ TAB2 조회 함수 ]
        /// </summary>
        private void Query_11(object sender, EventArgs e)
        {
            try
            {
                // 파라메타 입력
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("YYYYMM", this.dte11_YYYYMM.GetDateText().Substring(0, 7).Replace("-", ""));
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                if (!IsQueryValid_11(paramSet)) return;

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_QA4221"), paramSet);
                this.grd11.SetValue(source.Tables[0], false);
                this.grd11_excel.SetValue(source.Tables[0], false);
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

        /// <summary>
        /// [ TAB2 조회 유효성 체크 함수 ]
        /// </summary>
        private bool IsQueryValid_11(HEParameterSet paramSet)
        {
            try
            {
                // 조회연월 체크
                if (paramSet["YYYYMM"].ToString().Length == 0)
                {
                    MsgCodeBox.Show("CD00-0111");
                    //MsgBox.Show("조회연월을 입력하세요.");
                    this.dte11_YYYYMM.Focus();
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

        /// <summary>
        /// [ TAB2 초기화 함수 ]
        /// </summary>
        private void Reset_11(object sender, EventArgs e)
        {
            try
            {
                //this.BeforeInvokeServer();
                //this.dte01_YYYYMM.Initialize();
                this.dte11_YYYYMM.SetValue(DateTime.Today.AddMonths(-2).ToShortDateString());

                this.grd11.InitializeDataSource();
                this.grd11_excel.InitializeDataSource();
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

        /// <summary>
        /// [ TAB2 처리 함수 ]
        /// </summary>
        private void Process_11(object sender, EventArgs e)
        {
            try
            {
                // 파라메타 입력
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                paramSet.Add("REG_EMPNO", this.UserInfo.EmpNo);
                paramSet.Add("YYYYMM", this.dte11_YYYYMM.GetDateText().Substring(0, 7).Replace("-", ""));

                if (!IsProcessValid_11(paramSet)) return;

                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}",PAKAGE_NAME, "PROCESS_QA4221"), paramSet);

                this.AfterInvokeServer();

                // 조회
                this.BtnQuery_Click(null, null);
                //#001
                //MsgBox.Show("정상적으로 처리되었습니다.");
                MsgCodeBox.Show("CD00-0013");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                //MsgBox.Show(ex.ToString());
                if (ex.Message.ToString().Split('|').Length > 1)
                {
                    MsgBox.Show(ex.Message.ToString().Split('|')[1].Replace('_', '\n'));
                }
                else
                {
                    MsgBox.Show(ex.Message.ToString());
                }
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        /// <summary>
        /// [ TAB2 처리 체크 함수 ]
        /// </summary>
        private bool IsProcessValid_11(HEParameterSet paramSet)
        {
            try
            {
                // 조회연월 체크
                if (paramSet["YYYYMM"].ToString().Length == 0)
                {
                    MsgCodeBox.Show("CD00-0111");
                    //MsgBox.Show("조회연월을 입력하세요.");
                    this.dte11_YYYYMM.Focus();
                    return false;
                }

                // TAB NAME
                var v_TAB_NAME = tab01_main.TabPages[tab01_main.SelectedIndex].Text;

                // {0}을(를) 처리하시겠습니까??
                //if (MsgCodeBox.ShowFormat("HR06-0004", MessageBoxButtons.OKCancel, v_TAB_NAME) != DialogResult.OK)
                // {0} 데이터 생성 처리 하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0115", MessageBoxButtons.OKCancel, v_TAB_NAME) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion

        #endregion

        #endregion

    }
}
