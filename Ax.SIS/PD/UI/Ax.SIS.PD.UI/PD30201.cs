#region ▶ Description & History
/* 
 * 프로그램명 : PD30201 조립 작업지시 조회
 * 설      명 : 
 * 최초작성자 : 오세민
 * 최초작성일 : 2011-05-24 
 * 최종수정자 : 진승모
 * 최종수정일 : 2014-10-13
 * 수정  내용 : 
 * 
 *				날짜			  작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2010-05-24	  오세민		최초 개발
 *				2012-12-04    오세민     PK정보에 PARTNO 추가
 *				2014-07-23    배명희     cdx01_LINECD 연결 팝업 변경 (CM20020P1 -> CM30030P1)
 *				2014-10-13    진승모     다국어 적용
 *				2015-01-20    배명희     btnPrint_Click : grd02, grd03 - Border.Color가 기본 설정보다 진하게 출력되도록 로직 추가.
 *				2017-07~09    배명희     SIS 이관
 *				2017-09-19    배명희     PARTNO 기준 조회 체크박스 추가 및 grd05 추가
*/
#endregion
using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 조립 작업지시 조회
    /// </summary>
    public partial class PD30201 : AxCommonBaseControl
    {
        //private IPM31550 _WSCOM;
        //private IPM20036 _WSCOM2;
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD30201";
        private string PACKAGE_NAME2 = "APG_PD20201";
        private DataSet _DSGridHeader;

        public PD30201()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPM31550>("PM01", "PM31550.svc", "CustomBinding");
            //_WSCOM2 = ClientFactory.CreateChannel<IPM20036>("PM00", "PM20036.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        private void PD30201_Load(object sender, EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody = this.panel2;

                this.panel3.Hide();
                this.panel4.Hide();
                this.panel5.Hide();
                this.panel6.Hide(); //PARTNO 기준
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.Cols[0].Visible = false;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 040, "NO", "RN", "NO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "일자", "PLAN_DATE", "PLAN_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 030, "POS", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 070, "구분", "JOB_TYPE", "JOB_TYPE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 040, "DN", "DN", "SHIFT");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 050, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 080, "수량", "PLAN_QTY", "PLAN_QTY");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 005, "", "", "");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "NO", "RN", "NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "일자", "PLAN_DATE", "PLAN_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 030, "POS", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "구분", "JOB_TYPE", "JOB_TYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 040, "DN", "DN", "SHIFT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 050, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "수량", "PLAN_QTY", "PLAN_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "비고", "REMARK", "REMARK");

                this.grd01.AddHiddenColumn("MIPV_DIV");
                this.grd01.AddHiddenColumn("BGCOLOR");
                this.grd01.AddHiddenColumn("MAP_PKT_YN");

                this.grd01.Cols[7].Format = "###,###";
                this.grd01.Cols[15].Format = "###,###";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PLAN_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PLAN_DATE");

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.Cols[0].Visible = false;
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 040, "NO", "RN", "NO");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "일자", "PLAN_DATE", "PLAN_DATE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 030, "POS", "INSTALL_POS", "INSTALL_POS");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 070, "구분", "JOB_TYPE", "JOB_TYPE");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 040, "DN", "DN", "SHIFT");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 050, "ALC", "ALCCD", "ALCCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 080, "수량", "PLAN_QTY", "PLAN_QTY");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "레벨", "LEVCD", "LEVCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 005, "", "", "");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "NO", "RN", "NO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "일자", "PLAN_DATE", "PLAN_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 030, "POS", "INSTALL_POS", "INSTALL_POS");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 070, "구분", "JOB_TYPE", "JOB_TYPE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 040, "DN", "DN", "DN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 050, "ALC", "ALCCD", "ALCCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "수량", "PLAN_QTY", "PLAN_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "레벨", "LEVCD", "LEVCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "비고", "REMARK", "REMARK");
                this.grd02.AddHiddenColumn("BGCOLOR");
                this.grd02.AddHiddenColumn("MAP_PKT_YN");
                this.grd02.AddHiddenColumn("MIPV_DIV");
                this.grd02.Cols[7].Format = "###,###";
                this.grd02.Cols[16].Format = "###,###";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "PLAN_QTY");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "PLAN_DATE");


                this.grd03.AllowEditing = false;
                this.grd03.Initialize();
                this.grd03.Cols[0].Visible = false;


                this.grd04.AllowEditing = false;
                this.grd04.Initialize();
                this.grd04.Cols[0].Visible = false;
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "NO", "RN", "NO");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "일자", "PLAN_DATE", "PLAN_DATE");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 040, "POS", "INSTALL_POS", "INSTALL_POS");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 050, "DN", "DN", "SHIFT");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "수량", "PLAN_QTY", "PLAN_QTY");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "레벨", "LEVCD", "LEVCD");                
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "맵포켓유무", "MAP_PKT_YN", "MAP_PKT_YN");
                //this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "IMPACT PAD", "IMPACT_PAD");
                this.grd04.AddHiddenColumn("BGCOLOR");
                this.grd04.AddHiddenColumn("MAP_PKT_YN");
                this.grd04.AddHiddenColumn("MIPV_DIV");

                this.grd04.Cols[5].Format = "###,###";
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Int, "PLAN_QTY");
                this.grd04.SetColumnType(AxFlexGrid.FCellType.Date, "PLAN_DATE");

                #region partno 기준 그리드 설정

                this.grd05.AllowEditing = false;
                this.grd05.Initialize();
                this.grd05.Cols[0].Visible = false;
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 040, "NO", "RN", "NO");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "일자", "PLAN_DATE", "PLAN_DATE");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 030, "POS", "INSTALL_POS", "INSTALL_POS");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 030, "업무유형", "JOB_TYPE", "JOB_TYPE_LINE");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "TIMECD", "TIMECD", "TIMECD");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 040, "ALC", "ALCCD", "ALCCD");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 110, "PARTNO", "PARTNO", "PARTNO");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 070, "수량", "PLAN_QTY", "PLAN_QTY");
                this.grd05.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 005, "", "", "");

                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "NO", "RN", "NO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "일자", "PLAN_DATE", "PLAN_DATE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 030, "POS", "INSTALL_POS", "INSTALL_POS");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 030, "업무유형", "JOB_TYPE", "JOB_TYPE_LINE");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "TIMECD", "TIMECD", "TIMECD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 040, "ALC", "ALCCD", "ALCCD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PARTNO", "PARTNO", "PARTNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "수량", "PLAN_QTY", "PLAN_QTY");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "비고", "REMARK", "REMARK");
                this.grd05.AddHiddenColumn("BGCOLOR");
                this.grd05.Cols[8].Format = "###,###";
                this.grd05.Cols[17].Format = "###,###";
                this.grd05.SetColumnType(AxFlexGrid.FCellType.Int, "PLAN_QTY");
                this.grd05.SetColumnType(AxFlexGrid.FCellType.Date, "PLAN_DATE");
                #endregion
                //this.grd04.SetColumnType(AxFlexGrid.FCellType.ComboBox, "CD", "IMPACT_PAD");

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_INSTALL_POS.DataBind("A7");
                this.cbo01_SHIFT.DataBind("EI");

                this.cdx01_LINECD.Visible = true;
                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(); // new PM20015P1();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dtp01_BEG_DATE.GetDateText());
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                //this.cdx01_LINECD.HEPopupHelper = new CM20020P1(); // new PM20015P1();
                //this.cdx01_LINECD.PopupTitle = "대표 라인코드";
                //this.cdx01_LINECD.CodeParameterName = "LINECD";
                //this.cdx01_LINECD.NameParameterName = "LINENM";
                //this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                //this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_SAUP.GetValue());
                //this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                //this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dtp01_BEG_DATE.GetValue());

                CellStyle csBGCOLOR = grd01.Styles.Add("BGCOLOR");
                csBGCOLOR.Font = new Font(this.Font, FontStyle.Bold);
                csBGCOLOR.BackColor = Color.LightGray;                

                CellStyle csBGCOLOR2 = grd02.Styles.Add("BGCOLOR");
                csBGCOLOR2.Font = new Font(this.Font, FontStyle.Bold);
                csBGCOLOR2.BackColor = Color.LightGray;

                CellStyle csBGCOLOR3 = grd03.Styles.Add("BGCOLOR");
                csBGCOLOR3.Font = new Font(this.Font, FontStyle.Bold);
                csBGCOLOR3.BackColor = Color.LightGray;

                CellStyle csBGCOLOR4 = grd04.Styles.Add("BGCOLOR");
                csBGCOLOR4.Font = new Font(this.Font, FontStyle.Bold);
                csBGCOLOR4.BackColor = Color.LightGray;

                CellStyle csBGCOLOR5 = grd05.Styles.Add("BGCOLOR");
                csBGCOLOR5.Font = new Font(this.Font, FontStyle.Bold);
                csBGCOLOR5.BackColor = Color.LightGray;

                CellStyle csBGCOLOR6 = grd01.Styles.Add("REMARK");
                csBGCOLOR6.Font = new Font(this.Font, FontStyle.Bold);
                csBGCOLOR6.BackColor = Color.Red;
                
                CellStyle csBGCOLOR7 = grd02.Styles.Add("REMARK");
                csBGCOLOR7.Font = new Font(this.Font, FontStyle.Bold);
                csBGCOLOR7.BackColor = Color.Red;

                CellStyle csBGCOLOR8 = grd05.Styles.Add("REMARK");
                csBGCOLOR8.Font = new Font(this.Font, FontStyle.Bold);
                csBGCOLOR8.BackColor = Color.Red;

                CellStyle cs1 = grd01.Styles.Add("SUM_ROW");
                cs1.BackColor = Color.FromArgb(208, 253, 248);
                cs1.ForeColor = Color.Blue;

                CellStyle cs2 = grd02.Styles.Add("SUM_ROW");
                cs2.BackColor = Color.FromArgb(208, 253, 248);
                cs2.ForeColor = Color.Blue;

                CellStyle cs3 = grd03.Styles.Add("SUM_ROW");
                cs3.BackColor = Color.FromArgb(208, 253, 248);
                cs3.ForeColor = Color.Blue;

                CellStyle cs4 = grd04.Styles.Add("SUM_ROW");
                cs4.BackColor = Color.FromArgb(208, 253, 248);
                cs4.ForeColor = Color.Blue;


                CellStyle cs5 = grd05.Styles.Add("SUM_ROW");
                cs5.BackColor = Color.FromArgb(208, 253, 248);
                cs5.ForeColor = Color.Blue;

                this.cbo01_BIZCD.SelectedIndexChanged += new EventHandler(cbo01_BIZCD_SelectedIndexChanged);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        
        #endregion

        #region [사용자 정의 메서드]
        
        private void DynamicColumn()
        {            
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("LINECD", this.cdx01_LINECD.GetValue().ToString());
                set.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue().ToString());
                //_DSGridHeader = _WSCOM2.GridHeader(set);
                _DSGridHeader = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME2, "GRIDHEADER"), set);

                this.grd03.GridColumns.Clear();
                for (int i = this.grd03.Cols.Count-1; i > 0; i--)
                {
                    this.grd03.Cols.Remove(i);                    
                }

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "NO", "RN", "NO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "일자", "PLAN_DATE", "PLAN_DATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 030, "POS", "INSTALL_POS", "INSTALL_POS");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "구분", "JOB_TYPE", "JOB_TYPE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 020, "DN", "DN", "DN");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 050, "ALC", "ALCCD", "ALCCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "파트넘버", "PARTNO", "PARTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "수량", "PLAN_QTY", "PLAN_QTY");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Date, "PLAN_DATE");
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Int, "PLAN_QTY");
                for (int i = 4; i < _DSGridHeader.Tables[0].Rows.Count; i++)
                {
                    DataRow row = _DSGridHeader.Tables[0].Rows[i];
                    this.grd03.AddColumn(true, true,
                        row["ALIGN"].ToString() == "L" ? AxFlexGrid.FtextAlign.L : (row["ALIGN"].ToString() == "R" ? AxFlexGrid.FtextAlign.R : AxFlexGrid.FtextAlign.C),
                        Convert.ToInt32(row["WIDTH"].ToString()), row["COLUMN_ID"].ToString(), row["COLUMN_ID"].ToString());
                }
                
                this.grd03.AddHiddenColumn("BGCOLOR");
                this.grd03.AddHiddenColumn("MAP_PKT_YN");
                this.grd03.AddHiddenColumn("MIPV_DIV");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }            
        }
        
        private void GridRowBgcolor(AxFlexGrid grd)
        {
            
            for (int i = 1; i < grd.Rows.Count; i++)
            {
                if (grd.GetValue(i, "BGCOLOR").Equals("Y"))
                {
                    grd.Rows[i].Style = grd.Styles["BGCOLOR"];
                }         
            }

            if(grd.Cols.Contains("REMARK"))
            {            
                for (int i = 1; i < grd.Rows.Count; i++)
                {
                    if (!grd.GetValue(i, "REMARK").Equals(" "))
                    {
                        grd.Rows[i].Style = grd.Styles["REMARK"];
                    }
                }
            }
        }

        private void GridRowBgcolorByKeyColor(AxFlexGrid grd)
        {

            for (int i = 1; i < grd.Rows.Count; i++)
            {
                if (grd.GetValue(i, "BGCOLOR").Equals("Y"))
                {
                    grd.Rows[i].Style = grd.Styles["BGCOLOR"];
                }

                //if (grd.GetValue(i, "MAP_PKT_YN").Equals("Y"))
                //{
                //    grd.SetCellStyle(i, 10, grd01.Styles["BGCOLOR"]);
                //    grd.SetCellStyle(i, 21, grd01.Styles["BGCOLOR"]);
                //}
            }

            for (int i = 1; i < grd.Rows.Count; i++)
            {
                if (!grd.GetValue(i, "REMARK").Equals(" "))
                {
                    grd.Rows[i].Style = grd.Styles["REMARK"];
                }
            }
        }
        
        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsQueryValid()) return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("BEG_DATE", this.dtp01_BEG_DATE.GetDateText().ToString());
                paramSet.Add("END_DATE", this.dtp01_END_DATE.GetDateText().ToString());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue().ToString());
                paramSet.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue().ToString());
                paramSet.Add("SHIFT", this.cbo01_SHIFT.GetValue().ToString().Replace("EI",""));
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                
                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);

                if (this.chk01_PD30201_CHK1.Checked == false && this.chk01_PD30201_CHK2.Checked == false && this.chk01_PD30201_CHK3.Checked == false && this.chk01_PD30201_CHK4.Checked == false)
                {
                    this.grd01.SetValue(source.Tables[0]);
                    GridRowBgcolor(this.grd01);
                    ShowDataCount(source);

                    this.panel2.Show();
                    this.panel3.Hide();
                    this.panel4.Hide();
                    this.panel5.Hide();
                    this.panel6.Hide();
                    this.heDockingTab1.LinkBody = this.panel2;
                    if (source.Tables[0].Rows.Count > 1)
                    {
                        grd01.Rows[grd01.Rows.Count - 1].Style = grd01.Styles["SUM_ROW"];
                    }
                }
                else if (this.chk01_PD30201_CHK1.Checked == true) // && this.chk01_OPTION2.Checked == false && this.chk01_OPTION3.Checked == false)
                {
                    this.grd02.SetValue(source.Tables[0]);
                    GridRowBgcolorByKeyColor(this.grd02);
                    ShowDataCount(source);

                    this.panel5.Hide();
                    this.panel6.Hide();
                    this.panel2.Hide();
                    this.panel4.Hide();
                    this.panel3.Show();
                    this.heDockingTab1.LinkBody = this.panel3;
                    if (source.Tables[0].Rows.Count > 1)
                    {
                        grd02.Rows[grd02.Rows.Count - 1].Style = grd02.Styles["SUM_ROW"];
                    }
                }
                else if (this.chk01_PD30201_CHK2.Checked == true)
                {
                    if (this.cbo01_INSTALL_POS.GetValue().ToString() == "")
                    {
                        //MessageBox.Show("장착위치를 선택하세요");
                        MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("POSTITLE"));
                        return;
                    }

                    this.DynamicColumn();

                    DataSet ds = new DataSet();
                    ds = source;

                    int column_length = ds.Tables[0].Columns.Count;

                    for (int i = 4; i < _DSGridHeader.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Columns.Add(_DSGridHeader.Tables[0].Rows[i]["COLUMN_ID"].ToString());
                    }

                    foreach (DataRow rows in ds.Tables[0].Rows)
                    {
                        string[] columns = rows["SPEC"].ToString().Split(';');
                        for (int i = 1; i < columns.Length; i++)
                        {
                            rows[(column_length-1) + i] = columns[i];
                        }
                    }
                    this.grd03.SetValue(ds.Tables[0]);
                    GridRowBgcolor(this.grd03);

                    ShowDataCount(source);

                    this.panel2.Hide();
                    this.panel3.Hide();
                    this.panel5.Hide();
                    this.panel6.Hide();
                    this.panel4.Show();
                    this.heDockingTab1.LinkBody = this.panel4;

                    if (source.Tables[0].Rows.Count > 1)
                    {
                        grd03.Rows[grd03.Rows.Count - 1].Style = grd03.Styles["SUM_ROW"];
                    }
                }
                else if (this.chk01_PD30201_CHK3.Checked == true)
                {
                    DataTable dt = source.Tables[0].Clone();

                    int cnt = 0;
                    int tmpTOT = 0;
                    foreach (DataRow dr in source.Tables[0].Rows)
                    {       
                        //DataRow row = dt.NewRow();
                        //rbk차종은 GL사양은 제외(외주처리)

                        if (!(                            
                              (this.cdx01_LINECD.GetValue().ToString().Equals("RB0110") || this.cdx01_LINECD.GetValue().ToString().Equals("RB0120")) 
                              && dr["LEVCD"].Equals("GL")                                                   
                            )
                           )
                        {
                            if (cnt == 0)
                            {
                                dt.ImportRow(dr);
                                cnt++;
                            }
                            else
                            {
                                if (dt.Rows[cnt - 1]["PLAN_DATE"].ToString() == dr["PLAN_DATE"].ToString()
                                    && dt.Rows[cnt - 1]["INSTALL_POS"].ToString() == dr["INSTALL_POS"].ToString()
                                    && dt.Rows[cnt - 1]["DN"].ToString() == dr["DN"].ToString()
                                    && dt.Rows[cnt - 1]["LEVCD"].ToString() == dr["LEVCD"].ToString()
                                    //&& dt.Rows[cnt - 1]["ETC_COLOR1"].ToString() == dr["ETC_COLOR1"].ToString()
                                    && dt.Rows[cnt - 1]["MAP_PKT_YN"].ToString() == dr["MAP_PKT_YN"].ToString()
                                    //&& dt.Rows[cnt - 1]["MIPV_DIV"].ToString().Equals("A0M")
                                    //&& dt.Rows[cnt - 1]["IMPACT_PAD"].ToString() == dr["IMPACT_PAD"].ToString()
                                    )
                                {
                                    dt.Rows[cnt - 1]["PLAN_QTY"] = Convert.ToInt32(dt.Rows[cnt - 1]["PLAN_QTY"]) + Convert.ToInt32(dr["PLAN_QTY"]);
                                    dt.Rows[cnt - 1]["RN"] = cnt;
                                }
                                else
                                {
                                    dr["RN"] = ++cnt;
                                    dt.ImportRow(dr);
                                }
                            }
                        }
                        else
                        {
                            tmpTOT += Convert.ToInt32(dr["PLAN_QTY"].ToString());
                        }
                        
                    }

                    if (dt.Rows.Count > 0)
                    {
                        dt.Rows[dt.Rows.Count - 1]["RN"] = DBNull.Value;
                        dt.Rows[dt.Rows.Count - 1]["PLAN_DATE"] = this.GetLabel("SUMTOT");
                        dt.Rows[dt.Rows.Count - 1]["PLAN_QTY"] = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["PLAN_QTY"]) - tmpTOT;
                    }


                    this.grd04.SetValue(dt);
                    //GridRowBgcolor(this.grd04);
                    ShowDataCount(source);

                    this.panel5.Show();
                    this.panel2.Hide();
                    this.panel3.Hide();
                    this.panel4.Hide();
                    this.panel6.Hide();
                    this.heDockingTab1.LinkBody = this.panel5;
                    if (source.Tables[0].Rows.Count > 1)
                    {
                        grd04.Rows[grd04.Rows.Count - 1].Style = grd04.Styles["SUM_ROW"];
                    }
                }
                else if (this.chk01_PD30201_CHK4.Checked == true)
                {
                    this.grd05.SetValue(source.Tables[0]);
                    GridRowBgcolor(this.grd05);
                    ShowDataCount(source);

                    this.panel2.Hide();
                    this.panel3.Hide();
                    this.panel4.Hide();
                    this.panel5.Hide();
                    this.panel6.Show();
                    this.heDockingTab1.LinkBody = this.panel6;
                    if (source.Tables[0].Rows.Count > 1)
                    {
                        grd05.Rows[grd05.Rows.Count - 1].Style = grd05.Styles["SUM_ROW"];
                    }
                }
                this.ShowDataCount(source);                
            }
            catch (FaultException<ExceptionDetail> ex)
            {                
                MsgBox.Show(ex.ToString());
            }            
        }
        
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.grd01.InitializeDataSource();
                this.grd02.InitializeDataSource();
                this.grd03.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grd01.Visible)
                {
                    this.grd01.PrintGrid("", C1.Win.C1FlexGrid.PrintGridFlags.FitToPageWidth);

                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                    paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                    paramSet.Add("BEG_DATE", this.dtp01_BEG_DATE.GetDateText().ToString());
                    paramSet.Add("END_DATE", this.dtp01_END_DATE.GetDateText().ToString());
                    paramSet.Add("LINECD", this.cdx01_LINECD.GetValue().ToString());
                    paramSet.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue().ToString());
                    paramSet.Add("SHIFT", this.cbo01_SHIFT.GetValue().ToString());
                    paramSet.Add("LANG_SET", this.UserInfo.Language);

                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.Inquery(paramSet);
                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);

                    #region testdata
                    //DataSet source = AxFlexGrid.GetDataSourceSchema("RN", "PLAN_DATE", "INSTALL_POS", "JOB_TYPE", "DN", "ALCCD", "PLAN_QTY", "LEVCD", "KEY_COL", "ASSY_COLOR", "ETC_COLOR1", "TIMECD", "WORK_SEQ", "SPEC", "BGCOLOR", "PARTNO", "MAP_PKT_YN", "IMPACT_PAD", "MIPV_DIV");
                    //source.Tables[0].Rows.Add("1", "2017-07-03", "FL", "0", "1", "R320", "4", "SP", "RED", "RGD", "TRY", "C01", "18", "", "Y", "82301-F2II0RGD", "", "", "A2M");
                    //source.Tables[0].Rows.Add("2", "2017-07-03", "FL", "0", "1", "R321", "2", "SP", "RED", "RGD", "TRY", "C01", "19", "", "Y", "82301-F2IJ0RGD", "", "", "A2M");
                    //source.Tables[0].Rows.Add("3", "2017-07-03", "FL", "0", "1", "R341", "3", "SP", "RED", "RGD", "TRY", "C01", "20", "", "Y", "82301-F2JD0RGD", "", "", "A2M");
                    //source.Tables[0].Rows.Add("4", "2017-07-03", "FL", "0", "1", "R342", "2", "SP", "RED", "RGD", "TRY", "C01", "21", "", "Y", "82301-F2JE0RGD", "", "", "A2M");
                    //source.Tables[0].Rows.Add("5", "2017-07-03", "FL", "0", "1", "T337", "117", "SP", "TRY", "TRY", "TRY", "C01", "31", "", "Y", "82301-F2IZ0TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("6", "2017-07-03", "FL", "0", "1", "T343", "1", "SP", "TRY", "TRY", "TRY", "C01", "32", "", "Y", "82301-F2JF0TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("7", "2017-07-03", "FL", "0", "1", "T346", "1", "GS", "TRY", "TRY", "TRY", "C01", "33", "", "N", "82301-F2JI0TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("8", "2017-07-03", "FL", "S", "1", "ZP256", "2", "GS", "PKG", "PKG", "PKG", "C01", "38", "", "N", "82305-F2FZ0PKG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("9", "2017-07-03", "FL", "A", "1", "ZT015", "12", "GS", "TRY", "TRY", "TRY", "C01", "39", "", "N", "82305-F2140TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("10", "2017-07-03", "FL", "0", "1", "E034", "38", "GS", "TRY", "UTE", "TRY", "C02", "4", "", "N", "82301-F2330UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("11", "2017-07-03", "FL", "0", "1", "E250", "101", "GS", "TRY", "UTE", "TRY", "C02", "7", "", "N", "82301-F2FT0UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("12", "2017-07-03", "FL", "0", "1", "H250", "25", "GS", "PKGA", "UTH", "PKG", "C02", "11", "", "N", "82301-F2FT0UTH", "", "", "A2M");
                    //source.Tables[0].Rows.Add("13", "2017-07-03", "FL", "0", "1", "T015", "99", "GS", "TRY", "TRY", "TRY", "C02", "16", "", "N", "82301-F2140TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("14", "2017-07-03", "FL", "0", "1", "T054", "28", "GS", "TRY", "TRY", "TRY", "C02", "25", "", "N", "82301-F2530TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("15", "2017-07-03", "FL", "0", "1", "X258", "11", "GS", "XUG", "XUG", "XUG", "C02", "27", "", "N", "82301-F2GB0XUG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("16", "2017-07-03", "FL", "0", "1", "X053", "50", "GS", "XUG", "XUG", "XUG", "C02", "34", "", "N", "82301-F2520XUG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("17", "2017-07-03", "FL", "0", "1", "X065", "1", "GS", "XUG", "XUG", "XUG", "C02", "35", "", "N", "82301-F2640XUG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("18", "2017-07-03", "FL", "0", "1", "X206", "4", "GS", "XUG", "XUG", "XUG", "C02", "36", "", "N", "82301-F2EB0XUG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("19", "2017-07-03", "FL", "0", "2", "9343", "2", "SP", "TRY", "TR9", "TRY", "C03", "1", "", "Y", "82301-F2JF0TR9", "", "", "A2M");
                    //source.Tables[0].Rows.Add("20", "2017-07-03", "FL", "0", "2", "D046", "6", "GS", "XUG", "UTD", "XUG", "C03", "1", "", "N", "82301-F2450UTD", "", "", "A2M");
                    //source.Tables[0].Rows.Add("21", "2017-07-03", "FL", "0", "2", "D034", "2", "GS", "XUG", "UTD", "XUG", "C03", "2", "", "N", "82301-F2330UTD", "", "", "A2M");
                    //source.Tables[0].Rows.Add("22", "2017-07-03", "FL", "0", "2", "E034", "19", "GS", "TRY", "UTE", "TRY", "C03", "4", "", "N", "82301-F2330UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("23", "2017-07-03", "FL", "0", "2", "E046", "29", "GS", "TRY", "UTE", "TRY", "C03", "4", "", "N", "82301-F2450UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("24", "2017-07-03", "FL", "0", "2", "E214", "13", "GS", "TRY", "UTE", "TRY", "C03", "6", "", "N", "82301-F2EJ0UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("25", "2017-07-03", "FL", "0", "2", "E250", "78", "GS", "TRY", "UTE", "TRY", "C03", "7", "", "N", "82301-F2FT0UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("26", "2017-07-03", "FL", "0", "2", "G262", "8", "GS", "XUGA", "UTG", "XUG", "C03", "7", "", "N", "82301-F2GF0UTG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("27", "2017-07-03", "FL", "0", "2", "E262", "3", "GS", "TRY", "UTE", "TRY", "C03", "8", "", "N", "82301-F2GF0UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("28", "2017-07-03", "FL", "0", "2", "H262", "8", "GS", "PKGA", "UTH", "PKG", "C03", "8", "", "N", "82301-F2GF0UTH", "", "", "A2M");
                    //source.Tables[0].Rows.Add("29", "2017-07-03", "FL", "0", "2", "G250", "4", "GS", "XUGA", "UTG", "XUG", "C03", "9", "", "N", "82301-F2FT0UTG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("30", "2017-07-03", "FL", "0", "2", "H250", "64", "GS", "PKGA", "UTH", "PKG", "C03", "11", "", "N", "82301-F2FT0UTH", "", "", "A2M");
                    //source.Tables[0].Rows.Add("31", "2017-07-03", "FL", "0", "2", "P258", "21", "GS", "PKG", "PKG", "PKG", "C03", "11", "", "N", "82301-F2GB0PKG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("32", "2017-07-03", "FL", "0", "2", "P053", "1", "GS", "PKG", "PKG", "PKG", "C03", "13", "", "N", "82301-F2520PKG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("33", "2017-07-03", "FL", "0", "2", "P065", "4", "GS", "PKG", "PKG", "PKG", "C03", "14", "", "N", "82301-F2640PKG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("34", "2017-07-03", "FL", "0", "2", "P098", "1", "GS", "PKG", "PKG", "PKG", "C03", "15", "", "N", "82301-F2970PKG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("35", "2017-07-03", "FL", "0", "2", "T015", "54", "GS", "TRY", "TRY", "TRY", "C03", "16", "", "N", "82301-F2140TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("36", "2017-07-03", "FL", "0", "2", "P280", "4", "GS", "PKG", "PKG", "PKG", "C03", "17", "", "N", "82301-F2GX1PKG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("37", "2017-07-03", "FL", "0", "2", "T065", "20", "GS", "TRY", "TRY", "TRY", "C03", "19", "", "N", "82301-F2640TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("38", "2017-07-03", "FL", "0", "2", "T011", "16", "GS", "TRY", "TRY", "TRY", "C03", "22", "", "N", "82301-F2100TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("39", "2017-07-03", "FL", "0", "2", "T038", "8", "GS", "TRY", "TRY", "TRY", "C03", "24", "", "N", "82301-F2370TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("40", "2017-07-03", "FL", "0", "2", "T098", "3", "GS", "TRY", "TRY", "TRY", "C03", "27", "", "N", "82301-F2970TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("41", "2017-07-03", "FL", "0", "2", "T206", "12", "GS", "TRY", "TRY", "TRY", "C03", "28", "", "N", "82301-F2EB0TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("42", "2017-07-03", "FL", "0", "2", "T258", "17", "GS", "TRY", "TRY", "TRY", "C03", "29", "", "N", "82301-F2GB0TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("43", "2017-07-03", "FL", "0", "2", "T280", "3", "GS", "TRY", "TRY", "TRY", "C03", "30", "", "N", "82301-F2GX1TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("44", "2017-07-03", "FL", "0", "2", "E034", "38", "GS", "TRY", "UTE", "TRY", "C04", "4", "", "N", "82301-F2330UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("45", "2017-07-03", "FL", "0", "2", "E046", "15", "GS", "TRY", "UTE", "TRY", "C04", "4", "", "N", "82301-F2450UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("46", "2017-07-03", "FL", "0", "2", "E250", "38", "GS", "TRY", "UTE", "TRY", "C04", "7", "", "N", "82301-F2FT0UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("47", "2017-07-03", "FL", "0", "2", "H250", "9", "GS", "PKGA", "UTH", "PKG", "C04", "11", "", "N", "82301-F2FT0UTH", "", "", "A2M");
                    //source.Tables[0].Rows.Add("48", "2017-07-03", "FL", "0", "2", "T015", "105", "GS", "TRY", "TRY", "TRY", "C04", "16", "", "N", "82301-F2140TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("49", "2017-07-03", "FL", "0", "2", "T065", "23", "GS", "TRY", "TRY", "TRY", "C04", "19", "", "N", "82301-F2640TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("50", "2017-07-03", "FR", "0", "1", "R320", "4", "SP", "RED", "RGD", "TRY", "C01", "57", "", "Y", "82302-F2II0RGD", "", "", "A2M");
                    //source.Tables[0].Rows.Add("51", "2017-07-03", "FR", "0", "1", "R321", "2", "SP", "RED", "RGD", "TRY", "C01", "58", "", "Y", "82302-F2IJ0RGD", "", "", "A2M");
                    //source.Tables[0].Rows.Add("52", "2017-07-03", "FR", "0", "1", "R341", "3", "SP", "RED", "RGD", "TRY", "C01", "59", "", "Y", "82302-F2JD0RGD", "", "", "A2M");
                    //source.Tables[0].Rows.Add("53", "2017-07-03", "FR", "0", "1", "R342", "2", "SP", "RED", "RGD", "TRY", "C01", "60", "", "Y", "82302-F2JE0RGD", "", "", "A2M");
                    //source.Tables[0].Rows.Add("54", "2017-07-03", "FR", "0", "1", "T337", "123", "SP", "TRY", "TRY", "TRY", "C01", "70", "", "Y", "82302-F2IZ0TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("55", "2017-07-03", "FR", "0", "1", "T343", "1", "SP", "TRY", "TRY", "TRY", "C01", "71", "", "Y", "82302-F2JF0TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("56", "2017-07-03", "FR", "S", "1", "ZT053", "3", "GS", "TRY", "TRY", "TRY", "C01", "76", "", "N", "82306-F2520TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("57", "2017-07-03", "FR", "A", "1", "ZT015", "4", "GS", "TRY", "TRY", "TRY", "C01", "77", "", "N", "82306-F2140TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("58", "2017-07-03", "FR", "0", "1", "E034", "34", "GS", "TRY", "UTE", "TRY", "C02", "43", "", "N", "82302-F2330UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("59", "2017-07-03", "FR", "0", "1", "T015", "103", "GS", "TRY", "TRY", "TRY", "C02", "45", "", "N", "82302-F2140TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("60", "2017-07-03", "FR", "0", "1", "E250", "95", "GS", "TRY", "UTE", "TRY", "C02", "46", "", "N", "82302-F2FT0UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("61", "2017-07-03", "FR", "0", "1", "H250", "31", "GS", "PKGA", "UTH", "PKG", "C02", "50", "", "N", "82302-F2FT0UTH", "", "", "A2M");
                    //source.Tables[0].Rows.Add("62", "2017-07-03", "FR", "0", "1", "X258", "11", "GS", "XUG", "XUG", "XUG", "C02", "56", "", "N", "82302-F2GB0XUG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("63", "2017-07-03", "FR", "0", "1", "T054", "28", "GS", "TRY", "TRY", "TRY", "C02", "64", "", "N", "82302-F2530TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("64", "2017-07-03", "FR", "0", "1", "X053", "49", "GS", "XUG", "XUG", "XUG", "C02", "72", "", "N", "82302-F2520XUG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("65", "2017-07-03", "FR", "0", "1", "X065", "1", "GS", "XUG", "XUG", "XUG", "C02", "73", "", "N", "82302-F2640XUG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("66", "2017-07-03", "FR", "0", "1", "X206", "4", "GS", "XUG", "XUG", "XUG", "C02", "74", "", "N", "82302-F2EB0XUG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("67", "2017-07-03", "FR", "0", "2", "D046", "6", "GS", "XUG", "UTD", "XUG", "C03", "30", "", "N", "82302-F2450UTD", "", "", "A2M");
                    //source.Tables[0].Rows.Add("68", "2017-07-03", "FR", "0", "2", "E046", "32", "GS", "TRY", "UTE", "TRY", "C03", "33", "", "N", "82302-F2450UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("69", "2017-07-03", "FR", "0", "2", "G262", "8", "GS", "XUGA", "UTG", "XUG", "C03", "36", "", "N", "82302-F2GF0UTG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("70", "2017-07-03", "FR", "0", "2", "H262", "7", "GS", "PKGA", "UTH", "PKG", "C03", "37", "", "N", "82302-F2GF0UTH", "", "", "A2M");
                    //source.Tables[0].Rows.Add("71", "2017-07-03", "FR", "0", "2", "9343", "2", "SP", "TRY", "TR9", "TRY", "C03", "40", "", "Y", "82302-F2JF0TR9", "", "", "A2M");
                    //source.Tables[0].Rows.Add("72", "2017-07-03", "FR", "0", "2", "P258", "22", "GS", "PKG", "PKG", "PKG", "C03", "40", "", "N", "82302-F2GB0PKG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("73", "2017-07-03", "FR", "0", "2", "D034", "2", "GS", "XUG", "UTD", "XUG", "C03", "41", "", "N", "82302-F2330UTD", "", "", "A2M");
                    //source.Tables[0].Rows.Add("74", "2017-07-03", "FR", "0", "2", "E034", "20", "GS", "TRY", "UTE", "TRY", "C03", "43", "", "N", "82302-F2330UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("75", "2017-07-03", "FR", "0", "2", "E214", "14", "GS", "TRY", "UTE", "TRY", "C03", "45", "", "N", "82302-F2EJ0UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("76", "2017-07-03", "FR", "0", "2", "T015", "49", "GS", "TRY", "TRY", "TRY", "C03", "45", "", "N", "82302-F2140TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("77", "2017-07-03", "FR", "0", "2", "E250", "78", "GS", "TRY", "UTE", "TRY", "C03", "46", "", "N", "82302-F2FT0UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("78", "2017-07-03", "FR", "0", "2", "E262", "3", "GS", "TRY", "UTE", "TRY", "C03", "47", "", "N", "82302-F2GF0UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("79", "2017-07-03", "FR", "0", "2", "G250", "4", "GS", "XUGA", "UTG", "XUG", "C03", "48", "", "N", "82302-F2FT0UTG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("80", "2017-07-03", "FR", "0", "2", "T065", "20", "GS", "TRY", "TRY", "TRY", "C03", "48", "", "N", "82302-F2640TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("81", "2017-07-03", "FR", "0", "2", "H250", "59", "GS", "PKGA", "UTH", "PKG", "C03", "50", "", "N", "82302-F2FT0UTH", "", "", "A2M");
                    //source.Tables[0].Rows.Add("82", "2017-07-03", "FR", "0", "2", "P053", "1", "GS", "PKG", "PKG", "PKG", "C03", "52", "", "N", "82302-F2520PKG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("83", "2017-07-03", "FR", "0", "2", "P065", "4", "GS", "PKG", "PKG", "PKG", "C03", "53", "", "N", "82302-F2640PKG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("84", "2017-07-03", "FR", "0", "2", "P098", "1", "GS", "PKG", "PKG", "PKG", "C03", "54", "", "N", "82302-F2970PKG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("85", "2017-07-03", "FR", "0", "2", "P280", "4", "GS", "PKG", "PKG", "PKG", "C03", "56", "", "N", "82302-F2GX1PKG", "", "", "A2M");
                    //source.Tables[0].Rows.Add("86", "2017-07-03", "FR", "0", "2", "T011", "17", "GS", "TRY", "TRY", "TRY", "C03", "61", "", "N", "82302-F2100TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("87", "2017-07-03", "FR", "0", "2", "T038", "8", "GS", "TRY", "TRY", "TRY", "C03", "63", "", "N", "82302-F2370TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("88", "2017-07-03", "FR", "0", "2", "T098", "3", "GS", "TRY", "TRY", "TRY", "C03", "66", "", "N", "82302-F2970TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("89", "2017-07-03", "FR", "0", "2", "T206", "12", "GS", "TRY", "TRY", "TRY", "C03", "67", "", "N", "82302-F2EB0TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("90", "2017-07-03", "FR", "0", "2", "T258", "20", "GS", "TRY", "TRY", "TRY", "C03", "68", "", "N", "82302-F2GB0TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("91", "2017-07-03", "FR", "0", "2", "T280", "3", "GS", "TRY", "TRY", "TRY", "C03", "69", "", "N", "82302-F2GX1TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("92", "2017-07-03", "FR", "0", "2", "E046", "20", "GS", "TRY", "UTE", "TRY", "C04", "33", "", "N", "82302-F2450UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("93", "2017-07-03", "FR", "0", "2", "E034", "46", "GS", "TRY", "UTE", "TRY", "C04", "43", "", "N", "82302-F2330UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("94", "2017-07-03", "FR", "0", "2", "T015", "101", "GS", "TRY", "TRY", "TRY", "C04", "45", "", "N", "82302-F2140TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("95", "2017-07-03", "FR", "0", "2", "E250", "33", "GS", "TRY", "UTE", "TRY", "C04", "46", "", "N", "82302-F2FT0UTE", "", "", "A2M");
                    //source.Tables[0].Rows.Add("96", "2017-07-03", "FR", "0", "2", "T065", "23", "GS", "TRY", "TRY", "TRY", "C04", "48", "", "N", "82302-F2640TRY", "", "", "A2M");
                    //source.Tables[0].Rows.Add("97", "2017-07-03", "FR", "0", "2", "H250", "8", "GS", "PKGA", "UTH", "PKG", "C04", "50", "", "N", "82302-F2FT0UTH", "", "", "A2M");
                    //source.Tables[0].Rows.Add("", "", "", "", "", "합계", "2257", "", "", "", "", "", "", "", "", "", "", "", "");
                    #endregion

                    this.AfterInvokeServer();

                    HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                    report.ReportName = "RxRpt/PD40201";  // 리포트ID 경로포함 ( 확장자 .reb 는 제외 )  ** 주의 ** 리포트 파일은 디자인후 속성창의 빌드작업에 포함리소스로 지정하도록 한다.
                    source.Tables[0].TableName = "DATA";
                    //source.Tables[0].WriteXml("c:/temp/PD40201.xml", XmlWriteMode.WriteSchema);
                    /* 
                        * 신규 리포트 또는 리포트 컬럼 변동시 디자인용 컬럼정의 XML 파일은 리포트 호출시 
                        * 하기 코드를 이용하여 직접 생성하여 사용하세요 ( 주의. reb 파일을 먼저 report 하위에 생성후 아래 xml 파일을 생성하세요 )
                        * 넘기고자 하는 DataSet 개체의 이름이 ds 라면
                        * ds.Tables[0].TableName = "DATA";
                        * ds.Tables[0].WriteXml(Server.MapPath("/Report") + "/" + report.ReportName + ".xml", XmlWriteMode.WriteSchema);
                        * 생성된 XML 파일은 추후 디자인 유지보수를 위해 추가 또는 수정시마다 소스제어에 포함시켜 주세요. ( /Report 폴더 아래 )
                        * */

                    // Main Section ( 메인리포트 파라메터셋 )
                    HERexSection mainSection = new HERexSection();
                    mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);
                    mainSection.ReportParameter.Add("EMPNAME", this.UserInfo.UserName);
                    report.Sections.Add("MAIN", mainSection);
                    HERexSection xmlSection = new HERexSection(source, new HEParameterSet());
                    report.Sections.Add("XML1", xmlSection); // 리포트파일의 커넥션 이름과 동일하게 지정하여 섹션에 Add, 커넥션이 여러개일경우 여러개의 커넥션을 지정
                    AxRexpertReportViewer.ShowReport(report);

                    //HE.ERM.PM.PM01.UI.PM01.PM41550 report = new HE.ERM.PM.PM01.UI.PM01.PM41550();
                    //report.SetDataSource(source.Tables[0]);

                    //this.ReportCall(report);
                }
                else if (this.grd02.Visible)
                {
                    //원래 색깔 백업 받고, border 진한 회색으로 변경
                    Color bgColor = this.grd02.Styles.Normal.Border.Color;
                    Color bgFixColor = this.grd02.Styles.Fixed.Border.Color;

                    this.grd02.Styles.Normal.Border.Color = Color.Black;
                    this.grd02.Styles.Fixed.Border.Color = Color.Black;

                    this.grd02.PrintGrid("", C1.Win.C1FlexGrid.PrintGridFlags.FitToPageWidth);

                    //원래 border색으로 돌림.
                    this.grd02.Styles.Normal.Border.Color = bgColor;
                    this.grd02.Styles.Fixed.Border.Color = bgFixColor;
                }
                else if (this.grd03.Visible)
                {
                    //원래 색깔 백업 받고, border 진한 회색으로 변경
                    Color bgColor = this.grd03.Styles.Normal.Border.Color;
                    Color bgFixColor = this.grd03.Styles.Fixed.Border.Color;
                    this.grd03.Styles.Normal.Border.Color = Color.Black;
                    this.grd03.Styles.Fixed.Border.Color = Color.Black;

                    this.grd03.Rows.DefaultSize = 30;

                    this.grd03.PrintParameters.PrintDocument.DefaultPageSettings.Margins.Left = 10;
                    this.grd03.PrintParameters.PrintDocument.DefaultPageSettings.Margins.Top = 100;
                    this.grd03.PrintParameters.PrintDocument.DefaultPageSettings.Margins.Right = 40;
                    this.grd03.PrintParameters.PrintDocument.DefaultPageSettings.Margins.Bottom = 40;

                    this.grd03.PrintParameters.PrintDocument.DefaultPageSettings.Landscape = true;
                    this.grd03.PrintGrid("", PrintGridFlags.ShowPrintDialog | PrintGridFlags.FitToPageWidth);

                    //원래 border색으로 돌림.
                    this.grd03.Styles.Normal.Border.Color = bgColor;
                    this.grd03.Styles.Fixed.Border.Color = bgFixColor;
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

        void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
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

        private void chk01_OPTION_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk01_PD30201_CHK1.CheckState == CheckState.Checked)
            {
                chk01_PD30201_CHK2.CheckState = CheckState.Unchecked;
                chk01_PD30201_CHK3.CheckState = CheckState.Unchecked;
                chk01_PD30201_CHK4.CheckState = CheckState.Unchecked;
            }
        }

        private void chk01_OPTION2_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk01_PD30201_CHK2.CheckState == CheckState.Checked)
            {
                chk01_PD30201_CHK1.CheckState = CheckState.Unchecked;
                chk01_PD30201_CHK3.CheckState = CheckState.Unchecked;
                chk01_PD30201_CHK4.CheckState = CheckState.Unchecked;
            }
        }

        private void chk01_OPTION3_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk01_PD30201_CHK3.CheckState == CheckState.Checked)
            {
                chk01_PD30201_CHK1.CheckState = CheckState.Unchecked;
                chk01_PD30201_CHK2.CheckState = CheckState.Unchecked;
                chk01_PD30201_CHK4.CheckState = CheckState.Unchecked;
            }
        }
        private void chk01_OPTION4_CheckStateChanged(object sender, EventArgs e)
        {
            if (chk01_PD30201_CHK4.CheckState == CheckState.Checked)
            {
                chk01_PD30201_CHK1.CheckState = CheckState.Unchecked;
                chk01_PD30201_CHK2.CheckState = CheckState.Unchecked;
                chk01_PD30201_CHK3.CheckState = CheckState.Unchecked;
            }
        }
        #endregion

        #region [ 유효성 검사 ]

        private bool IsQueryValid()
        {
            try
            {
                if (this.GetByteCount(this.cdx01_LINECD.GetValue().ToString()) == 0)
                {
                    //MsgBox.Show("라인코드를 입력하여 주십시오.");
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("LINECD"));
                    return false;
                }

                DateTime t1 = DateTime.Parse(dtp01_BEG_DATE.GetValue().ToString());
                DateTime t2 = DateTime.Parse(dtp01_END_DATE.GetValue().ToString());

                TimeSpan t3 = t2 - t1;

                if (t3.Days < 0)
                {
                    //MsgBox.Show("날짜 지정이 올바르지 않습니다.");
                    MsgCodeBox.Show("PD00-0080");
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

        #endregion

       
    }
}
