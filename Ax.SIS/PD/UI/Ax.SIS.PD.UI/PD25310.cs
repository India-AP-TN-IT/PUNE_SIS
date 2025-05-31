#region ▶ Description & History
/* 
 * 프로그램명 : 공수일지 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2015-09-24    오세민   
 *              2017-07~09    배명희     SIS 이관
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.ServiceModel;
using C1.Win.C1FlexGrid;
//using HE.ERM.PM.PM05.UI.PM05;

namespace Ax.SIS.PD.UI
{
    public partial class PD25310 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD25310";

        private string CORCD;
        private string BIZCD;
        private string WORKDATE;
        private string SHIFT;
        private string LINECD;
        private DataTable WORKTIME;
        private bool _isDoubleClick = false;
        private Color _BtnEmpnoBackColor;
        private BorderStyleEnum _BtnEmpnoBorderStyle;

        ArrayList _ARR = new ArrayList();

        public PD25310()
        {
            InitializeComponent();
            //_WSCOM = new AxClientProxy("HANILDEV");
            _WSCOM = new AxClientProxy();
            _BtnEmpnoBackColor = Color.LightGray;
            _BtnEmpnoBorderStyle = BorderStyleEnum.Raised;
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);



                this.cdx01_LINECD.HEPopupHelper = new CM30030P1();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dtp01_WORKDATE.GetDateText());
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                this.cdx02_LINECD.HEPopupHelper = new CM30030P1();
                this.cdx02_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx02_LINECD.CodeParameterName = "LINECD";
                this.cdx02_LINECD.NameParameterName = "LINENM";
                this.cdx02_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx02_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx02_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx02_LINECD.HEUserParameterSetValue("DATE", this.dtp01_WORKDATE.GetDateText());
                this.cdx02_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx02_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                this.cdx03_LINECD.HEPopupHelper = new CM30030P1();
                this.cdx03_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx03_LINECD.CodeParameterName = "LINECD";
                this.cdx03_LINECD.NameParameterName = "LINENM";
                this.cdx03_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx03_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx03_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx03_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx03_LINECD.HEUserParameterSetValue("DATE", this.dtp01_WORKDATE.GetDateText());
                this.cdx03_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx03_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                this.cbo01_SHIFT.DataBind("EI", false);
                this.rbtn01_CUR_DOWN_MM21021.Checked = true;

                #region grd01
                this.grd01.Initialize();
                this.grd01.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.CellRange;
                this.grd01.CurrentContextMenu.Items[0].Visible = false;
                this.grd01.CurrentContextMenu.Items[1].Visible = false;
                this.grd01.CurrentContextMenu.Items[2].Visible = false;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "출근", "ATTEN_TIME", "ATTEND");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "소속Line", "LINECD", "LINE3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "성명", "NAME_KOR", "NAME_KOR");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "사번", "EMPNO", "EMPNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "근무계획", "PLAN_TM", "PLAN_TM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "실작업", "TOTAL_MM", "TOTAL_MM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "실공수", "TOTAL_HH", "TOTAL_HH");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "정취시간", "WORK_TIME", "ATN_QUITT_TM_A10");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "연장시간", "EXTRA_TIME", "EXTN_TIME");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "사고시간", "NON_TIME", "NON_TIME");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "작업1", "WORK_DIV1", "WORK_DIV_1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM1", "BEGIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM1", "CLOSE");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "작업2", "WORK_DIV2", "WORK_DIV_2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM2", "BEGIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM2", "CLOSE");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "작업3", "WORK_DIV3", "WORK_DIV_3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM3", "BEGIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM3", "CLOSE");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "작업4", "WORK_DIV4", "WORK_DIV_4");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM4", "BEGIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM4", "CLOSE");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "작업5", "WORK_DIV5", "WORK_DIV_5");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM5", "BEGIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM5", "CLOSE");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "작업6", "WORK_DIV6", "WORK_DIV_6");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM6", "BEGIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM6", "CLOSE");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "작업7", "WORK_DIV7", "WORK_DIV_7");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM7", "BEGIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM7", "CLOSE");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "작업8", "WORK_DIV8", "WORK_DIV_8");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM8", "BEGIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM8", "CLOSE");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "작업9", "WORK_DIV9", "WORK_DIV_9");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM9", "BEGIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM9", "CLOSE");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "작업10", "WORK_DIV10", "WORK_DIV_10");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM10", "BEGIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM10", "CLOSE");

                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("BIZCD");
                this.grd01.AddHiddenColumn("WORK_DATE");
                this.grd01.AddHiddenColumn("SHIFT");
                this.grd01.AddHiddenColumn("WORK_LINECD");

                this.grd01.Cols["BEG_HHMM1"].EditMask = "99:99";
                this.grd01.Cols["END_HHMM1"].EditMask = "99:99";
                this.grd01.Cols["BEG_HHMM2"].EditMask = "99:99";
                this.grd01.Cols["END_HHMM2"].EditMask = "99:99";
                this.grd01.Cols["BEG_HHMM3"].EditMask = "99:99";
                this.grd01.Cols["END_HHMM3"].EditMask = "99:99";
                this.grd01.Cols["BEG_HHMM4"].EditMask = "99:99";
                this.grd01.Cols["END_HHMM4"].EditMask = "99:99";
                this.grd01.Cols["BEG_HHMM5"].EditMask = "99:99";
                this.grd01.Cols["END_HHMM5"].EditMask = "99:99";
                this.grd01.Cols["BEG_HHMM6"].EditMask = "99:99";
                this.grd01.Cols["END_HHMM6"].EditMask = "99:99";
                this.grd01.Cols["BEG_HHMM7"].EditMask = "99:99";
                this.grd01.Cols["END_HHMM7"].EditMask = "99:99";
                this.grd01.Cols["BEG_HHMM8"].EditMask = "99:99";
                this.grd01.Cols["END_HHMM8"].EditMask = "99:99";
                this.grd01.Cols["BEG_HHMM9"].EditMask = "99:99";
                this.grd01.Cols["END_HHMM9"].EditMask = "99:99";
                this.grd01.Cols["BEG_HHMM10"].EditMask = "99:99";
                this.grd01.Cols["END_HHMM10"].EditMask = "99:99";
                
                DataSet ds = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_WORK_DIV"));

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0],"WORK_DIV1");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV2");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV3");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV4");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV5");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV6");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV7");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV8");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV9");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV10");


                this.grd01.Cols.Frozen = 10;

                #endregion

                #region grd02
                // 그리드내 팝업버튼 cs 설정
                CellStyle cs = this.grd02.Styles.Add("btnpopup");
                cs.BackColor = _BtnEmpnoBackColor;
                cs.Border.Style = _BtnEmpnoBorderStyle;
           
                this.grd02.AllowEditing = true;
                this.grd02.Initialize();
                this.grd02.AllowSorting = AllowSortingEnum.None;
                this.grd02.CurrentContextMenu.Items[0].Visible = false;
                this.grd02.CurrentContextMenu.Items[1].Visible = false;
                this.grd02.CurrentContextMenu.Items[2].Visible = false;

                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 20, "", "CHK");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "행삭제", "REMOVE", "ROW_REMOVE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "실출근", "ATTEN_TIME", "ATTEND2");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "실퇴근", "QUITT_TIME", "QUITT2");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "소속Line", "LINECD", "LINE3");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "성명", "NAME_KOR", "NAME_KOR");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "사번", "EMPNO", "EMPNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "출근", "TM_START", "ATTEND");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "퇴근", "TM_CLOSE", "QUITT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "근무구분", "SHIFT_DIV","DIVIDE");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "작업라인1", "WORK_LINECD1", "WORK_LINE_1");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "작업1", "WORK_DIV1", "WORK_DIV_1");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM1", "BEGIN");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM1", "CLOSE");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "작업라인2", "WORK_LINECD2", "WORK_LINE_2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "작업2", "WORK_DIV2", "WORK_DIV_2");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM2", "BEGIN");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM2", "CLOSE");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "작업라인3", "WORK_LINECD3", "WORK_LINE_3");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "작업3", "WORK_DIV3", "WORK_DIV_3");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM3", "BEGIN");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM3", "CLOSE");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "작업라인4", "WORK_LINECD4", "WORK_LINE_4");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "작업4", "WORK_DIV4", "WORK_DIV_4");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM4", "BEGIN");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM4", "CLOSE");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "작업라인5", "WORK_LINECD5", "WORK_LINE_5");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "작업5", "WORK_DIV5", "WORK_DIV_5");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM5", "BEGIN");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM5", "CLOSE");
                                     
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "작업라인6", "WORK_LINECD6", "WORK_LINE_6");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "작업6", "WORK_DIV6", "WORK_DIV_6");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM6", "BEGIN");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM6", "CLOSE");
                                     
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "작업라인7", "WORK_LINECD7", "WORK_LINE_7");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "작업7", "WORK_DIV7", "WORK_DIV_7");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM7", "BEGIN");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM7", "CLOSE");
                                     
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "작업라인8", "WORK_LINECD8", "WORK_LINE_8");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "작업8", "WORK_DIV8", "WORK_DIV_8");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM8", "BEGIN");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM8", "CLOSE");
                                     
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "작업라인9", "WORK_LINECD9", "WORK_LINE_9");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "작업9", "WORK_DIV9", "WORK_DIV_9");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM9", "BEGIN");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM9", "CLOSE");
                                     
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "작업라인10", "WORK_LINECD10", "WORK_LINE_10");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "작업10", "WORK_DIV10", "WORK_DIV_10");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "시작", "BEG_HHMM10", "BEGIN");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 040, "종료", "END_HHMM10", "CLOSE");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV1");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV2");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV3");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV4");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV5");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV6");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV7");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV8");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV9");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, ds.Tables[0], "WORK_DIV10");
                
                this.grd02.Cols["LINECD"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd02.Cols["WORK_LINECD1"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd02.Cols["WORK_LINECD2"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd02.Cols["WORK_LINECD3"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd02.Cols["WORK_LINECD4"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd02.Cols["WORK_LINECD5"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd02.Cols["WORK_LINECD6"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd02.Cols["WORK_LINECD7"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd02.Cols["WORK_LINECD8"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd02.Cols["WORK_LINECD9"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd02.Cols["WORK_LINECD10"].TextAlign = TextAlignEnum.CenterCenter;

                this.grd02.Cols["BEG_HHMM1"].EditMask = "99:99";
                this.grd02.Cols["END_HHMM1"].EditMask = "99:99";
                this.grd02.Cols["BEG_HHMM2"].EditMask = "99:99";
                this.grd02.Cols["END_HHMM2"].EditMask = "99:99";
                this.grd02.Cols["BEG_HHMM3"].EditMask = "99:99";
                this.grd02.Cols["END_HHMM3"].EditMask = "99:99";
                this.grd02.Cols["BEG_HHMM4"].EditMask = "99:99";
                this.grd02.Cols["END_HHMM4"].EditMask = "99:99";
                this.grd02.Cols["BEG_HHMM5"].EditMask = "99:99";
                this.grd02.Cols["END_HHMM5"].EditMask = "99:99";
                this.grd02.Cols["BEG_HHMM6"].EditMask = "99:99";
                this.grd02.Cols["END_HHMM6"].EditMask = "99:99";
                this.grd02.Cols["BEG_HHMM7"].EditMask = "99:99";
                this.grd02.Cols["END_HHMM7"].EditMask = "99:99";
                this.grd02.Cols["BEG_HHMM8"].EditMask = "99:99";
                this.grd02.Cols["END_HHMM8"].EditMask = "99:99";
                this.grd02.Cols["BEG_HHMM9"].EditMask = "99:99";
                this.grd02.Cols["END_HHMM9"].EditMask = "99:99";
                this.grd02.Cols["BEG_HHMM10"].EditMask = "99:99";
                this.grd02.Cols["END_HHMM10"].EditMask = "99:99";

                this.grd02.Cols.Frozen = 10;

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");

                #endregion


                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_WORK_LINENM2, this.lbl01_DAY_NGT_DIV, this.lbl01_WORKDATE2);
                
                //this.dtp01_WORKDATE.SetValue("3000-07-16");
                //this.cdx01_LINECD.SetValue("AD0110");
                //this.cdx02_LINECD.SetValue("AD0110");
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
                DataSet set = this.grd02.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "WORK_DATE", "WORK_LINECD", "LINECD", "SHIFT", "EMPNO", "WORK_LINECD1",
                    "WORK_DIV1", "BEG_HHMM1", "END_HHMM1", "WORK_LINECD2", "WORK_DIV2", "BEG_HHMM2", "END_HHMM2", "WORK_LINECD3", "WORK_DIV3", "BEG_HHMM3", "END_HHMM3",
                    "WORK_LINECD4", "WORK_DIV4", "BEG_HHMM4", "END_HHMM4",
                    "WORK_LINECD5", "WORK_DIV5", "BEG_HHMM5", "END_HHMM5",
                    "WORK_LINECD6", "WORK_DIV6", "BEG_HHMM6", "END_HHMM6",
                    "WORK_LINECD7", "WORK_DIV7", "BEG_HHMM7", "END_HHMM7",
                    "WORK_LINECD8", "WORK_DIV8", "BEG_HHMM8", "END_HHMM8",
                    "WORK_LINECD9", "WORK_DIV9", "BEG_HHMM9", "END_HHMM9",
                    "WORK_LINECD10", "WORK_DIV10", "BEG_HHMM10", "END_HHMM10", "TOTAL_MM", "TOTAL_HH");

                if (!IsSaveValid(set)) return;

                foreach (DataRow row in set.Tables[0].Rows)
                {
                    row["CORCD"] = this.UserInfo.CorporationCode;
                    row["BIZCD"] = this.cbo01_BIZCD.GetValue().ToString();
                    row["WORK_DATE"] = this.WORKDATE;
                    row["SHIFT"] = this.cbo01_SHIFT.GetValue();
                }

                this.BeforeInvokeServer(true);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_B"), set);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("정상적으로 공수일지가 저장되었습니다.");
                MsgCodeBox.Show("CD00-0071");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                AfterInvokeServer();
            }
        }

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            this.cdx02_LINECD.Initialize();
            this.rbtn01_CUR_DOWN_MM21021.Checked = true;
            this.grd01.InitializeDataSource();
            this.grd02.InitializeDataSource();
            CORCD = "";
            BIZCD = "";
            WORKDATE = "";
            WORKTIME = null;
            SHIFT = "";
            LINECD = "";
            this.SetControlLock(false); //마감관련 컨트롤들 초기화
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.cdx01_LINECD.GetValue().ToString()))
                {
                    //MsgCodeBox.Show("PM05-0006");
                    MsgCodeBox.Show("PD00-0065");//라인코드를 입력하세요
                    return;
                }

                HEParameterSet paramSet = new HEParameterSet();

                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());
                paramSet.Add("WORK_DATE", this.dtp01_WORKDATE.GetDateText());
                paramSet.Add("SHIFT", this.cbo01_SHIFT.GetValue());


                


                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(paramSet);                
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet, "OUT_CURSOR", "OUT_CURSOR1");
                
                this.AfterInvokeServer();

                this.grd01.InitializeDataSource();
                CORCD = "";
                BIZCD = "";
                WORKDATE = "";
                WORKTIME = null;
                SHIFT = "";
                LINECD = "";
                //BtnReset_Click(null, null);

                this.grd01.SetValue(source.Tables[0]);

                CORCD = this.UserInfo.CorporationCode;
                BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                WORKDATE = this.dtp01_WORKDATE.GetDateText().ToString();
                SHIFT = this.cbo01_SHIFT.GetValue().ToString();
                LINECD = this.cdx01_LINECD.GetValue().ToString();

                WORKTIME = source.Tables[1];

                

                this.cdx02_LINECD_ValueChanged(null, null);
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

        #region [ 유효성 검사 ]

        private bool IsSaveValid(DataSet set)
        {
            System.Text.StringBuilder stbr = new System.Text.StringBuilder();
            string msg = string.Empty;

            if (set.Tables[0].Rows.Count == 0)
            {
                //MsgBox.Show("저장하실 공수일지가 없습니다.");
                MsgCodeBox.Show("CD00-0042");
                return false;
            }

            if (string.IsNullOrEmpty(this.cdx01_LINECD.GetValue().ToString()))
            {
                //MsgBox.Show("작업라인 정보가 존재하지 않습니다.");
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_WORK_LINENM2.Text); //{0} 가(이) 입력되지 않았습니다.
                return false;
            }
            
            HEParameterSet paramWorkTime = new HEParameterSet();
            paramWorkTime.Add("CORCD", this.UserInfo.CorporationCode);
            paramWorkTime.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            paramWorkTime.Add("OPR_DATE", this.dtp01_WORKDATE.GetDateText());
            paramWorkTime.Add("SHIFT", this.cbo01_SHIFT.GetValue());
            paramWorkTime.Add("LANG_SET", this.UserInfo.Language);
            DataSet ds = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_WORKTIME"), paramWorkTime);

            string message = string.Empty;
            DateTime dtBEG_TIME = new DateTime();

            if (ds.Tables[0].Rows.Count > 0)
            {
                string beg_time = ds.Tables[0].Rows[0]["BEG_TIME"].ToString();
                dtBEG_TIME = ChgDateTime(DateTime.Parse(ds.Tables[0].Rows[0]["BEG_TIME"].ToString()));
            }

            foreach (DataRow row in set.Tables[0].Rows)
            {
                string colNameWorkDiv = string.Empty;
                string colNameWorkDiv2 = string.Empty;
                string colNameWorkDiv3 = string.Empty;

                int idx = 0;
                int idx2 = 0;
                int intRowCnt = 0;
                int endCnt = 0;

                DateTime dtBEG_HHMM = new DateTime();
                DateTime dtEND_HHMM = new DateTime();

                DateTime dtEND_HHMM2 = new DateTime();

                for (int j = set.Tables[0].Columns.IndexOf("BEG_HHMM1"); j <= set.Tables[0].Columns.IndexOf("END_HHMM10"); j++)
                {
                    string rowCnt = set.Tables[1].Rows[intRowCnt]["GRIDSEQ"].ToString();

                    string colName = set.Tables[0].Columns[j].ColumnName.Substring(0, 8);

                    if (colName.Equals("BEG_HHMM"))
                    {
                        //근무시간 체크로직
                        if (set.Tables[0].Columns.IndexOf("BEG_HHMM1") == j)
                            idx = 1;
                        else
                            idx++;

                        if (idx < 11 && idx > 0)
                        {
                            if (!string.IsNullOrEmpty(row["BEG_HHMM" + idx.ToString()].ToString()) && row["BEG_HHMM" + idx.ToString()].ToString().Trim().Length > 4)
                            {
                                dtBEG_HHMM = ChgDateTime(DateTime.Parse(row["BEG_HHMM" + idx.ToString()].ToString()));
                                dtEND_HHMM = ChgDateTime(DateTime.Parse(row["END_HHMM" + idx.ToString()].ToString()));

                                idx2 = idx;
                                endCnt = 0;

                                if (DateTime.Compare(dtBEG_HHMM, dtEND_HHMM) == 0 || DateTime.Compare(dtBEG_HHMM, dtEND_HHMM) > 0)
                                {
                                    //message = string.Format("{0}행 {1}의 시작시간이 종료시간보다 큰 시간이거나 또는 동일한 시간 값을 입력할 수 없습니다.", rowCnt, "작업" + idx.ToString());
                                    //MsgBox.Show(message);                                    
                                    MsgCodeBox.ShowFormat("PD00-0090", rowCnt, this.GetLabel("WORK") + idx.ToString());
                                    return false;
                                }

                                for (int k = j; k >= set.Tables[0].Columns.IndexOf("END_HHMM1"); k--)
                                {
                                    //안씀...
                                    //colNameWorkDiv = set.Tables[0].Columns[j - 1].ColumnName.Replace("WORK_DIV", "작업");
                                    

                                    if (idx2 > 0)
                                    {
                                        string colName2 = set.Tables[0].Columns[k].ColumnName.Substring(0, 8);

                                        if (idx2 > 1)
                                            idx2--;

                                        if (!string.IsNullOrEmpty(row["END_HHMM" + idx2.ToString()].ToString()) && row["END_HHMM" + idx2.ToString()].ToString().Trim().Length > 4)
                                        {
                                            if (endCnt < 1)
                                                dtEND_HHMM2 = ChgDateTime(DateTime.Parse(row["END_HHMM" + idx2.ToString()].ToString()));
                                            endCnt++;
                                        }

                                        if (DateTime.Compare(dtEND_HHMM2, dtBEG_HHMM) > 0 && endCnt > 0)
                                        {
                                            //MsgBox.Show("종료가 어떻게 시작보다 더크니");
                                            //message = string.Format("{0}행 {1}의 종료시간은 {2}의 시작시간보다 큰 시간을 입력할 수 없습니다.", rowCnt, "작업" + idx2.ToString(), "작업" + idx.ToString());
                                            //MsgBox.Show(message);
                                            MsgCodeBox.ShowFormat("PD00-0091", rowCnt, this.GetLabel("WORK") + idx2.ToString(), this.GetLabel("WORK") + idx.ToString());
                                            return false;
                                        }

                                        if (DateTime.Compare(dtBEG_TIME, dtBEG_HHMM) > 0)
                                        {
                                            //MsgBox.Show("어떻게 근무시간이 더크니");
                                            //message = string.Format("{0}행 {1}의 시작시간은 근무시간보다 작은시간을 입력할 수 없습니다.", rowCnt, "작업" + idx2.ToString());
                                            //MsgBox.Show(message);
                                            MsgCodeBox.ShowFormat("PD00-0092", rowCnt, this.GetLabel("WORK") + idx2.ToString());
                                            return false;
                                        }

                                        if (DateTime.Compare(dtBEG_TIME, dtEND_HHMM) > 0)
                                        {
                                            //MsgBox.Show("어떻게 근무시간이 더크니");
                                            //message = string.Format("{0}행 {1}의 시작시간은 근무시간보다 작은시간을 입력할 수 없습니다.", rowCnt, "작업" + idx2.ToString());
                                            //MsgBox.Show(message);
                                            MsgCodeBox.ShowFormat("PD00-0092", rowCnt, this.GetLabel("WORK") + idx2.ToString());
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                intRowCnt++;
            }

            //마감여부 체크 2017-11-08
            if (this.IsLock())
            {
                //마감완료된 건입니다. 변경이 불가합니다.
                MsgCodeBox.Show("PD00-0087");
                return false;
            }
            //if (MsgBox.Show("입력하신 공수일지를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK) 
            if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;
            return true;
        }

        private DateTime ChgDateTime(DateTime dt)
        {
            int intYear = dt.Year;
            int intMonth = dt.Month;
            int intDay = dt.Day;
            int intHour = dt.Hour;
            int intMinute = dt.Minute;
            int intNextDay = dt.AddDays(1).Day;

            if (dt.Hour < 6 && dt.Hour >= 0)
                dt = dt.AddDays(1);
            
            return dt;
        }

        private bool IsAddValid()
        {
            for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
            {
                if (this.grd02.GetValue(i, "CHK").Equals("Y"))
                {
                    if (this.grd01.FindRow(this.grd02.GetValue(i, "EMPNO"), this.grd01.Rows.Fixed, this.grd01.Cols["EMPNO"].Index, false) != -1)
                    {
                        //MsgBox.Show("이미 등록된 작업자입니다.");
                        MsgCodeBox.Show("PD00-0093");
                        return false;
                    }
                }
            }

            //if (MsgBox.Show("선택하신 작업자를 등록하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("PD00-0094", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return false;
            }
            return true;
        }

        private bool IsClearValid()
        {
            if (this.grd01.Selection.c1 < this.grd01.Cols["H07"].Index || this.grd01.Selection.c2 > this.grd01.Cols["H06"].Index)
            {
                //MsgBox.Show("작업시간 영역을 선택해주세요!");
                MsgCodeBox.Show("PD00-0095");
                return false;
            }
            for (int i = this.grd01.Selection.r1; i <= this.grd01.Selection.r2; i++)
            {
                for (int j = this.grd01.Selection.c1; j <= this.grd01.Selection.c2; j++)
                {
                    try
                    {
                        Convert.ToInt32(grd01.GetValue(i, j));
                    }
                    catch (Exception)
                    {
                        //MsgBox.Show("타라인 지원작업에 대한 정보는 수정할 수 없습니다.");
                        MsgCodeBox.Show("PD00-0096");
                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsDeleteValid(HEParameterSet set)
        {
            try
            {
                if (this.GetByteCount(set["EMPNO"].ToString()) == 0)
                {
                    //MsgBox.Show("삭제할 대상이 없습니다.");
                    MsgCodeBox.Show("COM-00023"); //삭제할 대상 Data가 없습니다.
                    return false;
                }
                 
                //마감여부 체크 2017-11-08
                if (this.IsLock())
                {
                    MsgCodeBox.Show("PD00-0087"); //마감완료된 건입니다. 변경이 불가합니다.
                    return false;
                }
                //if (MsgBox.Show("선택하신 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        #region [ 기타 이벤트 정의 ]

        private void Button_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            try
            {
                string corcd = string.Empty;
                string bizcd = string.Empty;
                string work_date = string.Empty;
                string empno = string.Empty;
                int row = this.grd02.Row;
                int col = this.grd02.Col;

                if (Convert.ToInt32(bt.Name) >= this.grd02.Rows.Fixed && this.grd02.Col >= this.grd02.Cols.Fixed)
                {
                    corcd = this.UserInfo.CorporationCode;
                    bizcd = this.cbo01_BIZCD.GetValue().ToString();
                    work_date = this.dtp01_WORKDATE.GetDateText().ToString();
                    empno = this.grd02.GetValue(Convert.ToInt32(bt.Name), "EMPNO").ToString();

                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", corcd);
                    set.Add("BIZCD", bizcd);
                    set.Add("WORK_DATE", work_date);
                    set.Add("EMPNO", empno);

                    if (!IsDeleteValid(set)) return;

                    this.BeforeInvokeServer(true);
                    _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), set);
                    this.AfterInvokeServer();

                    this.BtnQuery_Click(null, null);

                    MsgCodeBox.Show("CD00-0072"); //삭제되었습니다.
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                AfterInvokeServer();
            }
        }

        private void btn01_ADD_Click(object sender, EventArgs e)
        {
            if (!IsAddValid()) return;

            int startindex = -1;
            int endindex = -1;
            int total_mm = 0;

            DataTable source = (DataTable)this.grd01.DataSource;

            DataRow row = null;
            for (int j = this.grd02.Rows.Fixed; j < this.grd02.Rows.Count; j++)
            {
                total_mm = 0;
                if (this.grd02.GetValue(j, "CHK").Equals("Y"))
                {
                    //울산공장 16시 30분까지 근무시간으로 인한 추가 반영 로직
                    if (!(this.grd02.GetValue(j, "TM_CLOSE").ToString().Substring(3, 2).Equals("00")))
                        endindex++;

                    row = source.NewRow();
                    row["CORCD"] = this.UserInfo.CorporationCode;
                    row["BIZCD"] = this.cbo01_BIZCD.GetValue().ToString();
                    row["WORK_DATE"] = this.WORKDATE;
                    row["ATTEN_TIME"] = this.grd02.GetValue(j, "ATTEN_TIME");
                    row["NAME_KOR"] = this.grd02.GetValue(j, "NAME_KOR");
                    row["WORK_LINECD"] = this.LINECD;
                    row["LINECD"] = this.grd02.GetValue(j, "LINECD");
                    row["SHIFT"] = this.SHIFT;
                    row["EMPNO"] = this.grd02.GetValue(j, "EMPNO");
                    row["PLAN_TM"] = this.grd02.GetValue(j, "TM_START").ToString() + "~" + this.grd02.GetValue(j, "TM_CLOSE").ToString();

                    row["TOTAL_MM"] = total_mm;
                    row["TOTAL_HH"] = Math.Round(total_mm / 60d, 2);

                    row["BEG_HHMM1"] = this.grd02.GetValue(j, "TM_START");
                    row["END_HHMM1"] = this.grd02.GetValue(j, "TM_CLOSE");

                    source.Rows.Add(row);

                    this.grd01.Rows[this.grd01.Rows.Count - 1][0] = "N";
                }
            }
        }

        private void cdx02_LINECD_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.cdx01_LINECD.GetValue().ToString()))
                {
                    if (!string.IsNullOrEmpty(this.cdx02_LINECD.GetValue().ToString()))
                    {
                        MsgCodeBox.Show("PD00-0097");
                    }
                    //MsgBox.Show("조회 후 소속라인을 입력해주세요!");
                    this.grd02.InitializeDataSource();
                    this.cdx02_LINECD.Initialize();

                    return;
                }

                if (this.grd01.DataSource == null)
                {
                    HEParameterSet paramSet1 = new HEParameterSet();

                    paramSet1.Add("CORCD", this.UserInfo.CorporationCode);
                    paramSet1.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                    paramSet1.Add("LINECD", this.cdx01_LINECD.GetValue());
                    paramSet1.Add("WORK_DATE", this.dtp01_WORKDATE.GetDateText());
                    paramSet1.Add("SHIFT", this.cbo01_SHIFT.GetValue());

                    //DataSet source2 = _WSCOM.Inquery(paramSet1);
                    DataSet source2 = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet1, "OUT_CURSOR", "OUT_CURSOR1");


                    this.grd01.SetValue(source2.Tables[0]);

                    CORCD = this.UserInfo.CorporationCode;
                    BIZCD = this.UserInfo.BusinessCode;
                    //WORKDATE = this.dtp01_WORKDATE.GetValue().ToString();
                    //SHIFT = this.cbo01_SHIFT.GetValue().ToString();
                    LINECD = this.cdx01_LINECD.GetValue().ToString();

                    WORKTIME = source2.Tables[1];

                }
                
                WORKDATE = this.dtp01_WORKDATE.GetDateText().ToString();
                SHIFT = this.cbo01_SHIFT.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("LINECD", this.cdx02_LINECD.GetValue());
                paramSet.Add("WORKDATE", this.WORKDATE);
                paramSet.Add("SHIFT", this.SHIFT);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.GetWorkers(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GETWORKERS"), paramSet);
                this.AfterInvokeServer();

                this.grd02.InitializeDataSource();
                this.grd02.SetValue(source.Tables[0]);

                //source.Tables[0].AcceptChanges();   // 조회상태로 변경

                // 조회 후 데이터 존재시 첫행 바인딩
                if (source.Tables[0].Rows.Count > 0)
                {
                    for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                    {
                        // 상세보기 팝업 버튼
                        this.grd02.SetCellStyle(i, this.grd02.Cols["REMOVE"].Index, this.grd02.Styles["btnpopup"]);
                    }

                    this.grd02.Row = this.grd02.Rows.Fixed;
                    this.grd02.Col = 1;
                    //grd02_MouseClick(this.grd02, null);
                    this.grd02.Focus();
                }

                grd02ColorDisplay();

                this.LockStatusCheck(); //마감여부 확인 및 마감시 처리 로직 제한 2017-11-08
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

        private void btn01_Clear_Click(object sender, EventArgs e)
        {
            if (!IsClearValid()) return;

            for (int i = this.grd01.Selection.r1; i <= this.grd01.Selection.r2; i++)
            {
                for (int j = this.grd01.Selection.c1; j <= this.grd01.Selection.c2; j++)
                {
                    this.grd01[i, j] = System.DBNull.Value;
                }
            }
        }

        private void 전체선택_MenuItem_Click(object sender, EventArgs e)
        {
            for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
            {
                this.grd02.SetValue(i, "CHK", true);
            }
        }

        private void 선택해제_MenuItem_Click(object sender, EventArgs e)
        {
            for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
            {
                this.grd02.SetValue(i, "CHK", false);
            }
        }

        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cdx01_LINECD.SetValue("");
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            this.dtp01_WORKDATE_ValueChanged(null, null); //사업장 변경시 그리드 초기화 2017-11-08
        }

        private void grd02_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                int row = e.Row;
                int col = e.Col;
                try
                {
                    if (string.IsNullOrEmpty(this.cdx01_LINECD.GetValue().ToString()))
                    {
                        this.cdx02_LINECD.Initialize();
                        return;
                    }

                    string strTM_START = this.grd02.Rows[e.Row][this.grd02.Cols["TM_START"].Index].ToString();
                    string strTM_CLOSE = this.grd02.Rows[e.Row][this.grd02.Cols["TM_CLOSE"].Index].ToString();

                    string colName = this.grd02.Cols[e.Col].Name.Substring(0, 8);

                    int idx = 0;
                    int begCnt = 0;
                    int endCnt = 0;

                    DateTime dtBEG_HHMM = new DateTime();
                    DateTime dtEND_HHMM = new DateTime();

                    if (colName.Equals("WORK_DIV"))
                    {
                        this.grd02.Rows[e.Row][e.Col - 1] = this.cdx01_LINECD.GetValue();

                        endCnt = 0;
                        begCnt = 0;
                        for (int j = this.grd02.Cols.IndexOf("WORK_DIV1"); j <= this.grd02.Cols.IndexOf("END_HHMM10"); j++)
                        {
                            //근무시간 체크로직
                            if (this.grd02.Cols.IndexOf("WORK_DIV1") == j)
                                idx = 1;
                            else
                                idx++;

                            if (idx < 11)
                            {
                                int intBEG_HHMM = this.grd02.Cols["BEG_HHMM" + idx.ToString()].Index;
                                int intEND_HHMM = this.grd02.Cols["END_HHMM" + idx.ToString()].Index;

                                if (!string.IsNullOrEmpty(this.grd02.Rows[e.Row]["BEG_HHMM" + idx.ToString()].ToString()) && intBEG_HHMM > e.Col + 2 && this.grd02.Rows[e.Row]["BEG_HHMM" + idx.ToString()].ToString().Trim().Length > 4)
                                {
                                    if (endCnt < 1)
                                        dtEND_HHMM = ChgDateTime(DateTime.Parse(this.grd02.Rows[e.Row]["BEG_HHMM" + idx.ToString()].ToString()));
                                    endCnt++;
                                }

                                if (!string.IsNullOrEmpty(this.grd02.Rows[e.Row]["END_HHMM" + idx.ToString()].ToString()) && intEND_HHMM < e.Col && this.grd02.Rows[e.Row]["END_HHMM" + idx.ToString()].ToString().Trim().Length > 4)
                                {
                                    dtBEG_HHMM = ChgDateTime(DateTime.Parse(this.grd02.Rows[e.Row]["END_HHMM" + idx.ToString()].ToString()));
                                    begCnt++;
                                }
                            }
                        }

                        DateTime TM_START = ChgDateTime(DateTime.Parse(strTM_START));
                        DateTime TM_CLOSE = ChgDateTime(DateTime.Parse(strTM_CLOSE));

                        if (begCnt == 0)
                            this.grd02.SetValue(e.Row, this.grd02.Cols[e.Col + 1].Index, strTM_START);
                        else
                            this.grd02.SetValue(e.Row, this.grd02.Cols[e.Col + 1].Index, dtBEG_HHMM.ToString("HH:mm"));

                        if (endCnt == 0 && DateTime.Compare(TM_CLOSE, dtEND_HHMM) > 0)
                            this.grd02.SetValue(e.Row, this.grd02.Cols[e.Col + 2].Index, strTM_CLOSE);
                        else
                            this.grd02.SetValue(e.Row, this.grd02.Cols[e.Col + 2].Index, dtEND_HHMM.ToString("HH:mm"));

                        if (DateTime.Compare(dtBEG_HHMM, TM_CLOSE) > 0)
                            this.grd02.SetValue(e.Row, this.grd02.Cols[e.Col + 2].Index, dtBEG_HHMM.ToString("HH:mm"));

                        if (string.IsNullOrEmpty(this.grd02.GetValue(e.Row, this.grd02.Cols[e.Col].Index).ToString()))
                        {
                            this.grd02.SetValue(e.Row, this.grd02.Cols[e.Col - 1].Index, string.Empty);
                            this.grd02.SetValue(e.Row, this.grd02.Cols[e.Col].Index, string.Empty);
                            this.grd02.SetValue(e.Row, this.grd02.Cols[e.Col + 1].Index, string.Empty);
                            this.grd02.SetValue(e.Row, this.grd02.Cols[e.Col + 2].Index, string.Empty);
                        }
                    }

                    if (colName.Equals("BEG_HHMM"))
                    {
                        if (this.grd02.GetValue(e.Row, this.grd02.Cols[e.Col].Index).ToString().Trim().Equals(":"))
                        {
                            this.grd02.SetValue(e.Row, this.grd02.Cols[e.Col].Index, string.Empty);
                        }
                    }

                    if (colName.Equals("END_HHMM"))
                    {
                        if (this.grd02.GetValue(e.Row, this.grd02.Cols[e.Col].Index).ToString().Trim().Equals(":"))
                        {
                            this.grd02.SetValue(e.Row, this.grd02.Cols[e.Col].Index, string.Empty);
                        }
                    }

                    grd02ColorDisplay();
                }
                catch (FaultException<ExceptionDetail> ex)
                {
                    MsgBox.Show(ex.ToString());
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

        private void grd02_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this._isDoubleClick = true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
        }

        private void rbtn01_CUR_RIGHT_Click(object sender, EventArgs e)
        {
            this.grd02.KeyActionEnter = KeyActionEnum.MoveAcross;
        }

        private void rbtn01_CUR_DOWN_Click(object sender, EventArgs e)
        {
            this.grd02.KeyActionEnter = KeyActionEnum.MoveDown;
        }

        private void grd02ColorDisplay()
        {
            string strLinecd = this.cdx01_LINECD.GetValue().ToString();

            if (!string.IsNullOrEmpty(strLinecd))
            {
                for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                {
                    this.grd02.Rows[i].StyleNew.Clear();

                    for (int j = this.grd02.Cols.IndexOf("WORK_LINECD1"); j <= grd02.Cols.IndexOf("WORK_LINECD4"); j++)
                    {
                        if (j == this.grd02.Cols.IndexOf("WORK_LINECD1") || j == this.grd02.Cols.IndexOf("WORK_LINECD2") || j == this.grd02.Cols.IndexOf("WORK_LINECD3") || j == this.grd02.Cols.IndexOf("WORK_LINECD4"))
                            if (!string.IsNullOrEmpty(this.grd02.Rows[i][j].ToString()))
                                if (this.grd02.Rows[i][this.grd02.Cols.IndexOf("LINECD")].ToString() != this.grd02.Rows[i][j].ToString())
                                    this.grd02.GetCellRange(i, j, i, j).StyleNew.BackColor = Color.OrangeRed;
                    }
                }
            }
        }

        private void grd02_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 46)
                {
                    int row = grd02.Row;
                    int col = grd02.Col;

                    this.grd02.SetValue(row, 0, "U");
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// [ 그리드 마우스 오버 이벤트 ]
        /// </summary>
        private void grd02_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (sender.Equals(grd02))
                {
                    if (grd.MouseRow >= grd.Rows.Fixed && grd.MouseRow < grd.Rows.Count)
                    {
                        if (grd.MouseCol >= grd.Cols.Fixed && grd.MouseCol < grd.Cols.Count)
                        {
                            if (grd.Cols.Count > 0 && grd.Cols[grd.MouseCol].Name.Equals("REMOVE"))
                            {
                                this.Cursor = Cursors.Hand;
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// [ 그리드 마우스 클릭 이벤트 ]
        /// </summary>
        private void grd02_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (pnlLOCK.Visible) return; //현재 데이터 LOCK상태가 Y이면 행삭제 불가. 2017-11-08

                AxFlexGrid grd = (AxFlexGrid)sender;
                if (sender.Equals(grd02))
                {
                    if (grd.SelectedRowIndex >= grd.Rows.Fixed)
                    {
                        if (grd02.MouseRow >= grd02.Rows.Fixed && grd02.MouseCol == grd02.Cols["REMOVE"].Index)
                        {
                            string corcd = string.Empty;
                            string bizcd = string.Empty;
                            string work_date = string.Empty;
                            string empno = string.Empty;
                            int row = this.grd02.Row;
                            int col = this.grd02.Col;

                            if (row >= this.grd02.Rows.Fixed && this.grd02.Col >= this.grd02.Cols.Fixed)
                            {
                                corcd = this.UserInfo.CorporationCode;
                                bizcd = this.cbo01_BIZCD.GetValue().ToString();
                                work_date = this.dtp01_WORKDATE.GetDateText().ToString();
                                empno = this.grd02.GetValue(row, "EMPNO").ToString();

                                HEParameterSet set = new HEParameterSet();
                                set.Add("CORCD", corcd);
                                set.Add("BIZCD", bizcd);
                                set.Add("WORK_DATE", work_date);
                                set.Add("EMPNO", empno);

                                if (!IsDeleteValid(set)) return;

                                this.BeforeInvokeServer(true);
                                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), set);
                                this.AfterInvokeServer();

                                this.BtnQuery_Click(null, null);

                                MsgCodeBox.Show("CD00-0072");
                            }
                        }
                    }
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

        //주야 변경시 그리드 둘 다 초기화 2017-11-08
        private void cbo01_SHIFT_SelectedValueChanged(object sender, EventArgs e)
        {
            this.dtp01_WORKDATE_ValueChanged(null, null);
        }

        //작업라인 변경시 그리드 둘 다 초기화 2017-11-08
        private void cdx01_LINECD_ValueChanged(object sender, EventArgs e)
        {
            this.dtp01_WORKDATE_ValueChanged(null, null);
        }

        //근무일자 변경시 그리드 둘 다 초기화 2017-11-08
        private void dtp01_WORKDATE_ValueChanged(object sender, EventArgs e)
        {
            this.grd01.InitializeDataSource();
            this.grd02.InitializeDataSource();
            this.SetControlLock(false);
        }
        
        #endregion

        #region [ 사용자 정의 메서드 ]
        /// <summary>
        /// 마감여부 확인 및 컨트롤 Disable 처리
        /// </summary>
        private void LockStatusCheck()
        {
            try
            {
                bool isLock = this.IsLock();
                if (isLock)
                {
                    this.SetControlLock(true);
                }
                else
                {
                    this.SetControlLock(false);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }
        
        /// <summary>
        /// bizcd, 날짜 기준으로 마감여부 조회
        /// </summary>
        /// <returns>true:마감, false:마감전</returns>
        private bool IsLock()
        {
            HEParameterSet paramSet2 = new HEParameterSet();

            paramSet2.Add("CORCD", this.UserInfo.CorporationCode);
            paramSet2.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            paramSet2.Add("WORK_DATE", this.dtp01_WORKDATE.GetDateText());

            DataSet dsLock = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_LOCK_STA"), paramSet2, "OUT_CURSOR");
            if (dsLock.Tables[0].Rows.Count > 0 && dsLock.Tables[0].Rows[0]["LOCK_STA"].ToString().Equals("Y"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 마감메시지, 각정 처리 버튼 활성/비활성 처리
        /// </summary>
        /// <param name="islock"></param>
        private void SetControlLock(bool islock)
        {
            //true;
            this.pnlLOCK.Visible = islock;           

            //false;
            this.grd02.AllowEditing = !islock;
            this.GetCommonButton(COMMONBUTTONTYPE.SAVE).Enabled = !islock;
        }

        #endregion

    }
}
