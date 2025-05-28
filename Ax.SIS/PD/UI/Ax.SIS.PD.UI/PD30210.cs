#region ▶ Description & History
/* 
 * 프로그램명 : [PD30210] 종합 납품관리(서열출고,고객생산실적)
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2014-10-21    진승모     다국어 적용
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
using System.Text;


namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>종합수주관리현황 조회 프로그램</b>
    /// - 작 성 자 : 장상휘<br />
    /// - 작 성 일 : 2010-06-01 오후 1:34:13<br />
    /// </summary>
    public partial class PD30210 : AxCommonBaseControl
    {
        //private IPD30210 _WSCOM;
        //private ISD20010 _WSCOM2;
        private AxClientProxy _WSCOM_N;
		private string PAKAGE_NAME = "APG_PD30210";
		//private string PAKAGE_NAME2 = "PKG_SD20010";

        public PD30210()
        {
            InitializeComponent();

            //_WSCOM  = ClientFactory.CreateChannel<IPD30210>("SD02", "PD30210.svc", "CustomBinding");
            //_WSCOM2 = ClientFactory.CreateChannel<ISD20010>("SD00", "SD20010.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }
        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            this.heDockingTab1.LinkBody  = this.panel3;
            this.heDockingTab1.LinkPanel = this.panel1;

            //DataSet set = this.GetDataSourceSchema("GROUPCD");
            //set.Tables[0].Rows.Add("SD051"); // 고객공장
            //set.Tables[0].Rows.Add("SD024"); // 고객라인
            //DataSet source = _WSCOM2.Inquery_CodeList(set);

            #region -- 콤보 상자 설정 --
            DataTable dtCustPlant = new DataTable();
            dtCustPlant.Columns.Add("VALUE");
            dtCustPlant.Columns.Add("TEXT");            
            dtCustPlant.Rows.Add("1", "1" + this.GetLabel("PLANT")); //공장
            //dtCustPlant.Rows.Add("2", "2" + this.GetLabel("PLANT"));
            //dtCustPlant.Rows.Add("3", "3" + this.GetLabel("PLANT"));
            //dtCustPlant.Rows.Add("4", "4" + this.GetLabel("PLANT"));
            //dtCustPlant.Rows.Add("5", "5" + this.GetLabel("PLANT"));
            //dtCustPlant.Rows.Add("7", "7" + this.GetLabel("PLANT"));

            DataTable dtCustLine = new DataTable();
            dtCustLine.Columns.Add("VALUE");
            dtCustLine.Columns.Add("TEXT");            
            dtCustLine.Rows.Add("1", "1" + this.GetLabel("LINE")); //라인
            //dtCustLine.Rows.Add("2", "2" + this.GetLabel("LINE")); 

            DataTable dtItem = new DataTable();
            dtItem.Columns.Add("VALUE");
            dtItem.Columns.Add("TEXT");            
            //dtItem.Rows.Add("D", "D/T");
            //dtItem.Rows.Add("S", "SEAT");
            dtItem.Rows.Add("DT", "D/TRIM");
            dtItem.Rows.Add("DG", "D/Garnish");
            dtItem.Rows.Add("BP", "Bumper");
            dtItem.Rows.Add("TG", "T/Gate");

            DataSet source = new DataSet();
            source.Tables.Add(dtCustPlant);
            source.Tables.Add(dtCustLine);
            source.Tables.Add(dtItem);

            this.cbo01_CUST_LINE.DataBind(source.Tables[1]);
            this.cbo01_CUST_PLANT.DataBind(source.Tables[0]);

            this.cbo01_ITEM.DataBind(source.Tables[2], false);
            //this.cbo01_ITEM.SetValue("D"); //기본값은 D/T
            this.cbo01_ITEM.SetValue("DT");//기본값 DoorTrim

            this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
            this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);

            this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
            this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
            this.cbo01_CORCD.SetReadOnly(true);


            #endregion

            this.cdx01_VINCD.HEPopupHelper = new CM30010P1("A3", true, false, this.cdx01_VINCD);

            #region -- tab 0 : 서열세부(ALC) 그리드 (grd01) -- 

            this.grd01.AllowEditing = false;
            this.grd01.Initialize(false);

            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "년월일", "YMD", "YMD");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "공장", "PLANT", "PLANT");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "라인", "LINE", "LINE");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "라인 SEQ", "LSEQ", "LSEQ");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 050, "차수", "ORD", "CHASU");//2019.06.19 false
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "공장 SEQ", "TSEQ", "TSEQ");//2019.06.19 false
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 090, "차대번호", "VID", "VID");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "시간", "TIME", "TIME");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "차수", "CHASU", "CHASU");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "YMDHM", "YMDHM", "YMDHM");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "납품완료유무", "NAPCHK", "NAPCHK");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 065, "DTFL CHK", "DTFL_CHK", "CHKFL");//2019.06.19 CHKFL -> DTFL_CHK
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 065, "DTFR CHK", "DTFR_CHK", "CHKFR");//2019.06.19 CHKFR -> DTFR_CHK
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 065, "DTRL CHK", "DTRL_CHK", "CHKRL");//2019.06.19 CHKRL -> DTRL_CHK
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 065, "DTRR CHK", "DTRR_CHK", "CHKRR");//2019.06.19 CHKRR -> DTRR_CHK
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 065, "D/GFL CHK", "DGFL_CHK", "CHKDGFL");//2019.06.19 ADD DOOR-GARNISH
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 065, "D/GFR CHK", "DGFR_CHK", "CHKDGFR");//2019.06.19 ADD DOOR-GARNISH
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 065, "D/GRL CHK", "DGRL_CHK", "CHKDGRL");//2019.06.19 ADD DOOR-GARNISH
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 065, "D/GRR CHK", "DGRR_CHK", "CHKDGRR");//2019.06.19 ADD DOOR-GARNISH
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 075, "BP FRT CHK", "BPF_CHK", "CHKBPF");//2019.06.19 ADD BUMPER
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 075, "BP RR CHK", "BPR_CHK", "CHKBPR");//2019.06.19 ADD BUMPER
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 075, "T/G CHK", "TG_CHK", "CHKTG");//2019.06.19 ADD TAIL-GATE
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "POP전송확인", "TRANCHK", "TRANCHK");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 050, "DT FL", "DTFL", "DTFL");//2019.06.19 false
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 050, "DT FR", "DTFR", "DTFR");//2019.06.19 false
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 050, "DT RL", "DTRL", "DTRL");//2019.06.19 false
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 050, "DT RR", "DTRR", "DTRR");//2019.06.19 false
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "FL 각인 LOT NO", "DTFL_LOTNO", "FL_LOTNO");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "FL PART NO", "DTFL_PARTNO", "FL_PARTNO");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "FR 각인 LOT NO", "DTFR_LOTNO", "FR_LOTNO");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "FR PART NO", "DTFR_PARTNO", "FR_PARTNO");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "RL 각인 LOT NO", "DTRL_LOTNO", "RL_LOTNO");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "RL PART NO", "DTRL_PARTNO", "RL_PARTNO");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "RR 각인 LOT NO", "DTRR_LOTNO", "RR_LOTNO");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "RR PART NO", "DTRR_PARTNO", "RR_PARTNO");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 140, "FL Scanned LOT NO", "DGFL_LOTNO", "DGFL_LOTNO");//2019.06.19 aDD
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "FL PART NO", "DGFL_PARTNO", "DGFL_PARTNO");//2019.06.19 aDD
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 140, "FR Scanned LOT NO", "DGFR_LOTNO", "DGFR_LOTNO");//2019.06.19 aDD
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "FR PART NO", "DGFR_PARTNO", "DGFR_PARTNO");//2019.06.19 aDD
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 140, "RL Scanned LOT NO", "DGRL_LOTNO", "DGRL_LOTNO");//2019.06.19 aDD
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "RL PART NO", "DGRL_PARTNO", "DGRL_PARTNO");//2019.06.19 aDD
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 140, "RR Scanned LOT NO", "DGRR_LOTNO", "DGRR_LOTNO");//2019.06.19 aDD
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "RR PART NO", "DGRR_PARTNO", "DGRR_PARTNO");//2019.06.19 aDD
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 140, "FRT Scanned LOT NO", "BPF_LOTNO", "BPF_LOTNO");//2019.06.19 aDD
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "FRT PART NO", "BPF_PARTNO", "BPF_PARTNO");//2019.06.19 aDD
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 140, "REAR Scanned LOT NO", "BPR_LOTNO", "BPR_LOTNO");//2019.06.19 aDD
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "REAR PART NO", "BPR_PARTNO", "BPR_PARTNO");//2019.06.19 aDD
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 140, "T/G Scanned LOT NO", "TG_LOTNO", "TG_LOTNO");//2019.06.19 aDD
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 150, "T/G PART NO", "TG_PARTNO", "TG_PARTNO");//2019.06.19 aDD
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "ORDER NO", "ORDNO", "ORDERNO");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 070, "스펙번호", "SPEC", "SPECNO");//2019.06.19 false
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 140, "운전석위치", "DRV", "DRV");//2019.06.19 false
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "샤시", "CHASSI", "CHASSI");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "시트코드", "ALCSE", "ALCSE");//2019.06.19 false
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "도어트림", "ALCDT", "ALCDT");//2019.06.19 false
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "사업장", "SAUP", "BIZNM2");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "헤드라인", "HDL", "HDL");//2019.06.19 false
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "수신일자", "WKDATE", "WKDATE");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 070, "팩키지", "PKG", "PKG");//2019.06.19 false
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "STATUS", "STATUS", "STATUS");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "상태시간", "STATIME", "STATIME");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "TB서열 확인 FL", "OUTFL", "OUTFL");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "TB서열 확인 FR", "OUTFR", "OUTFR");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "TB서열 확인 RL", "OUTRL", "OUTRL");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "TB서열 확인 RR", "OUTRR", "OUTRR");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "MODEL", "MODEL", "MODEL");
            this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "차종코드", "VINCD", "VIN");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 120, "FL PROD DATE", "DTFL_SCAN_DATE", "FL_SCAN_DATE");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 120, "FR PROD DATE", "DTFR_SCAN_DATE", "FR_SCAN_DATE");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 120, "RL PROD DATE", "DTRL_SCAN_DATE", "RL_SCAN_DATE");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 120, "RR PROD DATE", "DTRR_SCAN_DATE", "RR_SCAN_DATE");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 120, "FL PROD DATE", "DGFL_SCAN_DATE", "DGFL_SCAN_DATE");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 120, "FR PROD DATE", "DGFR_SCAN_DATE", "DGFR_SCAN_DATE");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 120, "RL PROD DATE", "DGRL_SCAN_DATE", "DGRL_SCAN_DATE");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 120, "RR PROD DATE", "DGRR_SCAN_DATE", "DGRR_SCAN_DATE");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 120, "FRT PROD DATE", "BPF_SCAN_DATE", "BPF_SCAN_DATE");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 120, "REAR PROD DATE", "BPR_SCAN_DATE", "BPR_SCAN_DATE");
            this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 120, "T/G PROD DATE", "TG_SCAN_DATE", "TG_SCAN_DATE");
            //틀고정 박덕찬 장상휘 20101220
            this.grd01.Cols.Frozen = this.grd01.Cols["LSEQ"].Index;
            this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "YMD");

            //컬럼 병합
            //this.grd01.AllowMerging = AllowMergingEnum.Free;
            //this.grd01.Cols["YMD"].AllowMerging   = true;
            //this.grd01.Cols["PLANT"].AllowMerging = true;
            //this.grd01.Cols["LINE"].AllowMerging  = true;

            #endregion

            #region -- tab 1 : 월집계(ALC) 그리드 (grd02) --

            this.grd02.AllowEditing = false;
            this.grd02.Initialize(false);

            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "공장", "PLANT", "PLANT");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "차종", "VINCD", "VIN");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "총실적", "QTY_TT", "QTY_TT");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "01일 실적", "QTY_01", "QTY_01");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "02일 실적", "QTY_02", "QTY_02");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "03일 실적", "QTY_03", "QTY_03");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "04일 실적", "QTY_04", "QTY_04");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "05일 실적", "QTY_05", "QTY_05");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "06일 실적", "QTY_06", "QTY_06");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "07일 실적", "QTY_07", "QTY_07");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "08일 실적", "QTY_08", "QTY_08");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "09일 실적", "QTY_09", "QTY_09");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "10일 실적", "QTY_10", "QTY_10");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "11일 실적", "QTY_11", "QTY_11");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "12일 실적", "QTY_12", "QTY_12");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "13일 실적", "QTY_13", "QTY_13");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "14일 실적", "QTY_14", "QTY_14");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "15일 실적", "QTY_15", "QTY_15");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "16일 실적", "QTY_16", "QTY_16");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "17일 실적", "QTY_17", "QTY_17");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "18일 실적", "QTY_18", "QTY_18");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "19일 실적", "QTY_19", "QTY_19");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "20일 실적", "QTY_20", "QTY_20");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "21일 실적", "QTY_21", "QTY_21");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "22일 실적", "QTY_22", "QTY_22");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "23일 실적", "QTY_23", "QTY_23");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "24일 실적", "QTY_24", "QTY_24");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "25일 실적", "QTY_25", "QTY_25");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "26일 실적", "QTY_26", "QTY_26");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "27일 실적", "QTY_27", "QTY_27");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "28일 실적", "QTY_28", "QTY_28");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "29일 실적", "QTY_29", "QTY_29");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "30일 실적", "QTY_30", "QTY_30");
            this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "31일 실적", "QTY_31", "QTY_31");

            this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_TT");

            for (int i = 1; i < 32; i++)
            {
                string QTY = string.Format("QTY_{0:D2}", i);
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, QTY);
            }


            //컬럼 병합
            this.grd02.AllowMerging = AllowMergingEnum.Free;
            this.grd02.Cols["PLANT"].AllowMerging = true;
            this.grd02.Cols["VINCD"].AllowMerging = true;
            //틀고정 박덕찬 장상휘 20101220
            this.grd02.Cols.Frozen = this.grd02.Cols["QTY_TT"].Index;
            
            #endregion

            #region -- tab 2 : 월실적(P6) 그리드 (grd03) --

            this.grd03.AllowEditing = false;
            this.grd03.Initialize(false);

            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "고객사공장코드", "CUST_PLANTCD", "CUST_PLANTCD");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "차종", "VINCD", "VIN");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "TYPE CODE", "TYPECD", "TYPECD");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "총실적", "QTY_TT", "QTY_TT");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "01일 실적", "QTY_01", "QTY_01");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "02일 실적", "QTY_02", "QTY_02");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "03일 실적", "QTY_03", "QTY_03");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "04일 실적", "QTY_04", "QTY_04");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "05일 실적", "QTY_05", "QTY_05");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "06일 실적", "QTY_06", "QTY_06");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "07일 실적", "QTY_07", "QTY_07");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "08일 실적", "QTY_08", "QTY_08");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "09일 실적", "QTY_09", "QTY_09");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "10일 실적", "QTY_10", "QTY_10");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "11일 실적", "QTY_11", "QTY_11");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "12일 실적", "QTY_12", "QTY_12");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "13일 실적", "QTY_13", "QTY_13");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "14일 실적", "QTY_14", "QTY_14");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "15일 실적", "QTY_15", "QTY_15");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "16일 실적", "QTY_16", "QTY_16");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "17일 실적", "QTY_17", "QTY_17");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "18일 실적", "QTY_18", "QTY_18");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "19일 실적", "QTY_19", "QTY_19");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "20일 실적", "QTY_20", "QTY_20");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "21일 실적", "QTY_21", "QTY_21");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "22일 실적", "QTY_22", "QTY_22");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "23일 실적", "QTY_23", "QTY_23");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "24일 실적", "QTY_24", "QTY_24");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "25일 실적", "QTY_25", "QTY_25");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "26일 실적", "QTY_26", "QTY_26");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "27일 실적", "QTY_27", "QTY_27");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "28일 실적", "QTY_28", "QTY_28");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "29일 실적", "QTY_29", "QTY_29");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "30일 실적", "QTY_30", "QTY_30");
            this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "31일 실적", "QTY_31", "QTY_31");

            this.grd03.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A5", "TYPECD");

            this.grd03.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_TT");

            for (int i = 1; i < 32; i++)
            {
                string QTY = string.Format("QTY_{0:D2}", i);
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Int, QTY);
            }

            //컬럼 병합
            this.grd03.AllowMerging = AllowMergingEnum.Free;
            this.grd03.Cols["CUST_PLANTCD"].AllowMerging = true;
            this.grd03.Cols["VINCD"].AllowMerging        = true;
            //틀고정 박덕찬 장상휘 20101220
            this.grd03.Cols.Frozen = this.grd03.Cols["TYPECD"].Index;

            #endregion

            #region -- tab 3 : 일실적(P6) 그리드 (grd04) --

            this.grd04.AllowEditing = false;
            this.grd04.Initialize(false);

            this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "고객사공장코드", "CUST_PLANTCD", "CUST_PLANTCD");
            this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "차종", "VINCD", "VIN");
            this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "TYPE CODE", "TYPECD", "TYPECD");
            this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "전일계획", "PLAN_YDAY", "PLAN_YDAY");
            this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "전일실적수량", "PREVDAY_RSLT_QTY", "PREVDAY_RSLT_QTY");
            this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "금일계획", "PLAN_TDAY", "PLAN_TDAY");

            this.grd04.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A5", "TYPECD");

            this.grd04.SetColumnType(AxFlexGrid.FCellType.Int, "PLAN_YDAY");
            this.grd04.SetColumnType(AxFlexGrid.FCellType.Int, "PREVDAY_RSLT_QTY");
            this.grd04.SetColumnType(AxFlexGrid.FCellType.Int, "PLAN_TDAY");

            //컬럼 병합
            this.grd04.AllowMerging = AllowMergingEnum.Free;
            this.grd04.Cols["CUST_PLANTCD"].AllowMerging = true;
            this.grd04.Cols["VINCD"].AllowMerging = true;

            #endregion

            #region -- tab 4 : 년실적(P6) 그리드 (grd05) --
            
            this.grd05.AllowEditing = false;
            this.grd05.Initialize(false);

            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "고객사공장코드", "CUST_PLANTCD", "CUST_PLANTCD");
            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "차종", "VINCD", "VIN");
            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "TYPE CODE", "TYPECD", "TYPECD");
            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "총실적", "QTY_TT", "QTY_TT");
            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "01월 실적", "QTY_01", "QTY_M_01");
            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "02월 실적", "QTY_02", "QTY_M_02");
            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "03월 실적", "QTY_03", "QTY_M_03");
            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "04월 실적", "QTY_04", "QTY_M_04");
            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "05월 실적", "QTY_05", "QTY_M_05");
            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "06월 실적", "QTY_06", "QTY_M_06");
            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "07월 실적", "QTY_07", "QTY_M_07");
            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "08월 실적", "QTY_08", "QTY_M_08");
            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "09월 실적", "QTY_09", "QTY_M_09");
            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "10월 실적", "QTY_10", "QTY_M_10");
            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "11월 실적", "QTY_11", "QTY_M_11");
            this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "12월 실적", "QTY_12", "QTY_M_12");
            

            this.grd05.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A5", "TYPECD");
            this.grd05.SetColumnType(AxFlexGrid.FCellType.Int, "QTY_TT");

            for (int i = 1; i < 13; i++)
            {
                string QTY = string.Format("QTY_{0:D2}", i);
                this.grd05.SetColumnType(AxFlexGrid.FCellType.Int, QTY);
            }

            //컬럼 병합
            this.grd05.AllowMerging = AllowMergingEnum.Free;
            this.grd05.Cols["CUST_PLANTCD"].AllowMerging = true;
            this.grd05.Cols["VINCD"].AllowMerging = true;
            
            this.grd05.Cols.Frozen = this.grd05.Cols["TYPECD"].Index;

            #endregion


            #region -- tab 5 : 출고실적 비교 그리드 (grd06) -- 
            
            this.grd06.AllowEditing = false;
            this.grd06.Initialize(false);

            this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "공장", "CUST_PLANT", "PLANT");
            this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "라인코드", "ARBPL_UP", "LINECD");
            this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "출고유형", "INV_STATUS", "USGETYP");
            this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "GW수량", "GW_QTY", "GW_QTY");
            this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "MES수량", "MES_QTY", "MES_QTY");
            this.grd06.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 100, "수량차이", "DIFF", "DIFF_QTY");


            this.grd06.Cols["GW_QTY"].Format = "#,###,###,###,###,##0";
            this.grd06.Cols["MES_QTY"].Format = "#,###,###,###,###,##0";
            this.grd06.Cols["DIFF"].Format = "#,###,###,###,###,##0";
            this.grd06.SetColumnType(AxFlexGrid.FCellType.Int, "GW_QTY");
            this.grd06.SetColumnType(AxFlexGrid.FCellType.Int, "MES_QTY");
            this.grd06.SetColumnType(AxFlexGrid.FCellType.Int, "DIFF");

            
            
            //차이수량이 0이 아닌것 (GW수량 != MES수량) 배경색 빨강으로...
            CellStyle csRed = this.grd06.Styles.Add("Red");
            csRed.BackColor = Color.Red;
            

            #endregion

            #region -- MES 수량 그리드 (grd07) --

            this.grd07.AllowEditing = false;
            this.grd07.Initialize(false);

            this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 148, "출고유형", "INV_STATUS", "USGETYP");
            this.grd07.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "수량", "QTY", "QTY");
            this.grd07.SetColumnType(AxFlexGrid.FCellType.ComboBox, "C5", "INV_STATUS");
            this.grd07.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
            
            #endregion

            #region -- 게이트웨이 수량 그리드 (grd08) --

            this.grd08.AllowEditing = false;
            this.grd08.Initialize(false);

            this.grd08.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 148, "출고유형", "INV_STATUS", "USGETYP");
            this.grd08.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "수량", "QTY", "QTY");
            this.grd08.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
            this.grd08.SetColumnType(AxFlexGrid.FCellType.ComboBox, "C5", "INV_STATUS");


            #endregion

            this.txt01_TOTAL_OUT_QTY.TextAlign = HorizontalAlignment.Right;
            this.txt01_TOTAL_OUT_QTY.SetReadOnly(true);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine(this.GetLabel("PD30210_RMK_1"));//" Y  - 정    상");
            builder.AppendLine(this.GetLabel("PD30210_RMK_2"));// D  - 오더삭제");
            builder.AppendLine(this.GetLabel("PD30210_RMK_3"));// H  - 파견재고");
            builder.AppendLine(this.GetLabel("PD30210_RMK_4"));// M  - 오더수정");
            builder.AppendLine(this.GetLabel("PD30210_RMK_5"));// X  - 시차결품");
            builder.AppendLine(this.GetLabel("PD30210_RMK_6"));//\" \" - 미 각 인");
            this.lbl01_RMK_PD30210.Value = builder.ToString();

            this.tabControl1_SelectedIndexChanged(null, null);

        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0: this.Inquery_Alc_Detail(); break;
                    case 1: this.Inquery_Alc_Mon(); break;
                    case 2: this.Inquery_Trim_Mon(); break;
                    case 3: this.Inquery_Trim_Day(); break;
                    case 4: this.Inquery_Trim_Year(); break;
                    case 5: this.Inquery_Diff(); break; //출고실적비교
                }

                this.tabControl1_SelectedIndexChanged(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 사용자 정의 method ]

        //TABPAGE 0 : 서열세부(ALC) 조회
        private void Inquery_Alc_Detail()
        {
            try
            {
                string sdate = this.dte01_SDATE.GetDateText().ToString();
                string edate = this.dte01_EDATE.GetDateText().ToString();

                DateTime dt1 = DateTime.ParseExact(sdate, "yyyy-MM-dd", null).AddYears(1);
                DateTime dt2 = DateTime.ParseExact(edate, "yyyy-MM-dd", null);

                if (dt1.CompareTo(dt2) < 0)
                {
                    //MsgBox.Show("기준일자의 시작일과 종료일의 범위는 1년을 넘을 수가 없습니다.");
                    MsgCodeBox.Show("PD00-0101");
                    return;
                }

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("SDATE", this.dte01_SDATE.GetDateText());
                paramSet.Add("EDATE", this.dte01_EDATE.GetDateText());
                paramSet.Add("PLANT", this.cbo01_CUST_PLANT.GetValue());
                paramSet.Add("LINE", this.cbo01_CUST_LINE.GetValue());
                paramSet.Add("VINNO", this.txt01_VINNO.GetValue());
                paramSet.Add("VINCD", this.cdx01_VINCD.GetValue());
                paramSet.Add("CHK", this.chk01_CHK_PD30210.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("SCAN_CHK", this.chk01_SCAN_CHK_PD30210.GetValue());
                paramSet.Add("ITEM_DIV", this.cbo01_ITEM.GetValue() == null ? "D" : this.cbo01_ITEM.GetValue());




                HEParameterSet set = new HEParameterSet();
                set.Add("SDATE", this.dte01_SDATE.GetDateText());
                set.Add("EDATE", this.dte01_EDATE.GetDateText());
                set.Add("VINCD", this.cdx01_VINCD.GetValue());
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());

                set.Add("PLANT", this.cbo01_CUST_PLANT.GetValue());
                set.Add("LINE", this.cbo01_CUST_LINE.GetValue());


                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery_Alc_Detail(paramSet);

                string[] procedures = new string[] { string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_ALC_DETAIL") ,
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_MES"),
                                                    string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_GATEWAY")
                                                    };
                System.Collections.Generic.List<HEParameterSet> paramList = new System.Collections.Generic.List<HEParameterSet> { paramSet, set, set };
                DataSet source = _WSCOM_N.MultipleExecuteDataSet(procedures, paramList);

                this.AfterInvokeServer();

                //
                // 보여줄 그룹을 선택하기 위해서 기본적으로
                // 선택적 필드들을 비활성화한 후 선택된 항목에 대해서만 활성화합니다.
                {
                    //
                    // 칼럼 보이기를 비활성화합니다.
                    this.grd01.Cols["DTFL_CHK"].Visible = false;
                    this.grd01.Cols["DTFR_CHK"].Visible = false;
                    this.grd01.Cols["DTRL_CHK"].Visible = false;
                    this.grd01.Cols["DTRR_CHK"].Visible = false;
                    this.grd01.Cols["DGFL_CHK"].Visible = false;
                    this.grd01.Cols["DGFR_CHK"].Visible = false;
                    this.grd01.Cols["DGRL_CHK"].Visible = false;
                    this.grd01.Cols["DGRR_CHK"].Visible = false;
                    this.grd01.Cols["BPF_CHK"].Visible = false;
                    this.grd01.Cols["BPR_CHK"].Visible = false;
                    this.grd01.Cols["TG_CHK"].Visible  = false;

                    this.grd01.Cols["DTFL_LOTNO"].Visible = false;
                    this.grd01.Cols["DTFR_LOTNO"].Visible = false;
                    this.grd01.Cols["DTRL_LOTNO"].Visible = false;
                    this.grd01.Cols["DTRR_LOTNO"].Visible = false;
                    this.grd01.Cols["DGFL_LOTNO"].Visible = false;
                    this.grd01.Cols["DGFR_LOTNO"].Visible = false;
                    this.grd01.Cols["DGRL_LOTNO"].Visible = false;
                    this.grd01.Cols["DGRR_LOTNO"].Visible = false;
                    this.grd01.Cols["BPF_LOTNO"].Visible = false;
                    this.grd01.Cols["BPR_LOTNO"].Visible = false;
                    this.grd01.Cols["TG_LOTNO"].Visible = false;

                    this.grd01.Cols["DTFL_PARTNO"].Visible = false;
                    this.grd01.Cols["DTFR_PARTNO"].Visible = false;
                    this.grd01.Cols["DTRL_PARTNO"].Visible = false;
                    this.grd01.Cols["DTRR_PARTNO"].Visible = false;
                    this.grd01.Cols["DGFL_PARTNO"].Visible = false;
                    this.grd01.Cols["DGFR_PARTNO"].Visible = false;
                    this.grd01.Cols["DGRL_PARTNO"].Visible = false;
                    this.grd01.Cols["DGRR_PARTNO"].Visible = false;
                    this.grd01.Cols["BPF_PARTNO"].Visible = false;
                    this.grd01.Cols["BPR_PARTNO"].Visible = false;
                    this.grd01.Cols["TG_PARTNO"].Visible = false;

                    this.grd01.Cols["DTFL_SCAN_DATE"].Visible = false;
                    this.grd01.Cols["DTFR_SCAN_DATE"].Visible = false;
                    this.grd01.Cols["DTRL_SCAN_DATE"].Visible = false;
                    this.grd01.Cols["DTRR_SCAN_DATE"].Visible = false;

                    this.grd01.Cols["DGFL_SCAN_DATE"].Visible = false;
                    this.grd01.Cols["DGFR_SCAN_DATE"].Visible = false;
                    this.grd01.Cols["DGRL_SCAN_DATE"].Visible = false;
                    this.grd01.Cols["DGRR_SCAN_DATE"].Visible = false;

                    this.grd01.Cols["BPF_SCAN_DATE"].Visible = false;
                    this.grd01.Cols["BPR_SCAN_DATE"].Visible = false;

                    this.grd01.Cols["TG_SCAN_DATE"].Visible = false;
                }

                //
                // 현재 선택된 항목이 DoorTrim, DoorGarnish, Bumper, TaleGate에 따라서
                // 보여줄 항목을 선택합니다.
                string s_selected = this.cbo01_ITEM.GetValue().ToString();
                if (string.Compare(s_selected, "DT", false) == 0)
                {
                    // DoorTrim
                    this.grd01.Cols["DTFL_CHK"].Visible = true;
                    this.grd01.Cols["DTFR_CHK"].Visible = true;
                    this.grd01.Cols["DTRL_CHK"].Visible = true;
                    this.grd01.Cols["DTRR_CHK"].Visible = true;

                    this.grd01.Cols["DTFL_LOTNO"].Visible = true;
                    this.grd01.Cols["DTFR_LOTNO"].Visible = true;
                    this.grd01.Cols["DTRL_LOTNO"].Visible = true;
                    this.grd01.Cols["DTRR_LOTNO"].Visible = true;

                    this.grd01.Cols["DTFL_PARTNO"].Visible = true;
                    this.grd01.Cols["DTFR_PARTNO"].Visible = true;
                    this.grd01.Cols["DTRL_PARTNO"].Visible = true;
                    this.grd01.Cols["DTRR_PARTNO"].Visible = true;
                }
                else if (string.Compare(s_selected, "DG", false) == 0)
                {
                    //DoorGarnish
                    this.grd01.Cols["DGFL_CHK"].Visible = true;
                    this.grd01.Cols["DGFR_CHK"].Visible = true;
                    this.grd01.Cols["DGRL_CHK"].Visible = true;
                    this.grd01.Cols["DGRR_CHK"].Visible = true;

                    this.grd01.Cols["DGFL_LOTNO"].Visible = true;
                    this.grd01.Cols["DGFR_LOTNO"].Visible = true;
                    this.grd01.Cols["DGRL_LOTNO"].Visible = true;
                    this.grd01.Cols["DGRR_LOTNO"].Visible = true;

                    this.grd01.Cols["DGFL_PARTNO"].Visible = true;
                    this.grd01.Cols["DGFR_PARTNO"].Visible = true;
                    this.grd01.Cols["DGRL_PARTNO"].Visible = true;
                    this.grd01.Cols["DGRR_PARTNO"].Visible = true;
                }
                else if (string.Compare(s_selected, "BP", false) == 0)
                {
                    //Bumper
                    this.grd01.Cols["BPF_CHK"].Visible = true;
                    this.grd01.Cols["BPR_CHK"].Visible = true;

                    this.grd01.Cols["BPF_LOTNO"].Visible = true;
                    this.grd01.Cols["BPR_LOTNO"].Visible = true;

                    this.grd01.Cols["BPF_PARTNO"].Visible = true;
                    this.grd01.Cols["BPR_PARTNO"].Visible = true;
                }
                else if (string.Compare(s_selected, "TG", false) == 0)
                {
                    //TaleGate
                    this.grd01.Cols["TG_CHK"].Visible = true;

                    this.grd01.Cols["TG_LOTNO"].Visible = true;

                    this.grd01.Cols["TG_PARTNO"].Visible = true;
                }
                else
                {
                }

                this.grd01.SetValue(source.Tables[0]);

                if (this.chk01_SCAN_CHK_PD30210.Checked == true)
                {
                    if (string.Compare(s_selected, "DT", false) == 0)
                    {
                        this.grd01.Cols["DTFL_SCAN_DATE"].Visible = true;
                        this.grd01.Cols["DTFR_SCAN_DATE"].Visible = true;
                        this.grd01.Cols["DTRL_SCAN_DATE"].Visible = true;
                        this.grd01.Cols["DTRR_SCAN_DATE"].Visible = true;
                    }
                    else if (string.Compare(s_selected, "DG", false) == 0)
                    {
                        this.grd01.Cols["DGFL_SCAN_DATE"].Visible = true;
                        this.grd01.Cols["DGFR_SCAN_DATE"].Visible = true;
                        this.grd01.Cols["DGRL_SCAN_DATE"].Visible = true;
                        this.grd01.Cols["DGRR_SCAN_DATE"].Visible = true;
                    }
                    else if (string.Compare(s_selected, "BP", false) == 0)
                    {
                        this.grd01.Cols["BPF_SCAN_DATE"].Visible = true;
                        this.grd01.Cols["BPR_SCAN_DATE"].Visible = true;
                    }
                    else if (string.Compare(s_selected, "TG", false) == 0)
                    {
                        this.grd01.Cols["TG_SCAN_DATE"].Visible = true;
                    }
                }

                //
                // 선택한 그룹별로 색상을 변환하는 코드를 다르게 합니다.
                // 1. DoorTrim
                if (string.Compare(s_selected, "DT", false) == 0)
                {
                    //DoorTrim의 경우
                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        bool CHKFL = (source.Tables[0].Rows[i]["DTFL_CHK"].ToString().Equals("N") ||
                                       source.Tables[0].Rows[i]["DTFL_CHK"].ToString().Length == 0);
                        bool CHKFR = (source.Tables[0].Rows[i]["DTFR_CHK"].ToString().Equals("N") ||
                                       source.Tables[0].Rows[i]["DTFR_CHK"].ToString().Length == 0);
                        bool CHKRL = (source.Tables[0].Rows[i]["DTRL_CHK"].ToString().Equals("N") ||
                                       source.Tables[0].Rows[i]["DTRL_CHK"].ToString().Length == 0);
                        bool CHKRR = (source.Tables[0].Rows[i]["DTRR_CHK"].ToString().Equals("N") ||
                                       source.Tables[0].Rows[i]["DTRR_CHK"].ToString().Length == 0);

                        if (CHKFL || CHKFR || CHKRL || CHKRR)
                            this.grd01.Rows[i + this.grd01.Rows.Fixed].StyleNew.BackColor = Color.Red;
                    }
                }
                else if (string.Compare(s_selected, "DG", false) == 0)
                {
                    //DoorGarnish의 경우
                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        bool CHKFL = (source.Tables[0].Rows[i]["DGFL_CHK"].ToString().Equals("N") ||
                                       source.Tables[0].Rows[i]["DGFL_CHK"].ToString().Length == 0);
                        bool CHKFR = (source.Tables[0].Rows[i]["DGFR_CHK"].ToString().Equals("N") ||
                                       source.Tables[0].Rows[i]["DGFR_CHK"].ToString().Length == 0);
                        bool CHKRL = (source.Tables[0].Rows[i]["DGRL_CHK"].ToString().Equals("N") ||
                                       source.Tables[0].Rows[i]["DGRL_CHK"].ToString().Length == 0);
                        bool CHKRR = (source.Tables[0].Rows[i]["DGRR_CHK"].ToString().Equals("N") ||
                                       source.Tables[0].Rows[i]["DGRR_CHK"].ToString().Length == 0);

                        if (CHKFL || CHKFR || CHKRL || CHKRR)
                            this.grd01.Rows[i + this.grd01.Rows.Fixed].StyleNew.BackColor = Color.Red;
                    }
                }
                else if (string.Compare(s_selected, "BP", false) == 0)
                {
                    //Bumper의 경우
                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        bool CHKF = (source.Tables[0].Rows[i]["BPF_CHK"].ToString().Equals("N") ||
                                      source.Tables[0].Rows[i]["BPF_CHK"].ToString().Length == 0);
                        bool CHKR = (source.Tables[0].Rows[i]["BPR_CHK"].ToString().Equals("N") ||
                                      source.Tables[0].Rows[i]["BPR_CHK"].ToString().Length == 0);

                        if (CHKF || CHKR)
                            this.grd01.Rows[i + this.grd01.Rows.Fixed].StyleNew.BackColor = Color.Red;
                    }
                }
                else if (string.Compare(s_selected, "TG", false) == 0)
                {
                    //TaleGate의 경우
                    for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                    {
                        bool CHK = (source.Tables[0].Rows[i]["TG_CHK"].ToString().Equals("N") ||
                                     source.Tables[0].Rows[i]["TG_CHK"].ToString().Length == 0);

                        if (CHK)
                            this.grd01.Rows[i + this.grd01.Rows.Fixed].StyleNew.BackColor = Color.Red;
                    }
                }


                //출고수량 정보
                this.grd07.SetValue(source.Tables[1]);
                this.grd08.SetValue(source.Tables[2]);

                //LOTNO 길이가 9자리인 서연이화 것만 카운트한다. (업체바코드는 9자리아님. )
                int total = 0;

                //
                // 합계 데이터 생성.
                if (string.Compare(s_selected, "DT", false) == 0)
                {
                    // DoorTrim의 경우 합계
                    for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                    {
                        if (this.grd01.GetValue(i, "DTFL_LOTNO").ToString().Length == 9)
                            total++;

                        if (this.grd01.GetValue(i, "DTFR_LOTNO").ToString().Length == 9)
                            total++;

                        if (this.grd01.GetValue(i, "DTRL_LOTNO").ToString().Length == 9)
                            total++;

                        if (this.grd01.GetValue(i, "DTRR_LOTNO").ToString().Length == 9)
                            total++;
                    }
                }
                else if (string.Compare(s_selected, "DG", false) == 0)
                {
                    // DoorTrim의 경우 합계
                    for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                    {
                        if (this.grd01.GetValue(i, "DGFL_LOTNO").ToString().Length == 9)
                            total++;

                        if (this.grd01.GetValue(i, "DGFR_LOTNO").ToString().Length == 9)
                            total++;

                        if (this.grd01.GetValue(i, "DGRL_LOTNO").ToString().Length == 9)
                            total++;

                        if (this.grd01.GetValue(i, "DGRR_LOTNO").ToString().Length == 9)
                            total++;
                    }
                }
                else if (string.Compare(s_selected, "BP", false) == 0)
                {
                    // Bumper의 경우 합계
                    for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                    {
                        if (this.grd01.GetValue(i, "BPF_LOTNO").ToString().Length == 9)
                            total++;

                        if (this.grd01.GetValue(i, "BPR_LOTNO").ToString().Length == 9)
                            total++;
                    }
                }
                else if (string.Compare(s_selected, "TG", false) == 0)
                {
                    // Tail/Gate의 경우 합계
                    for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                    {
                        if (this.grd01.GetValue(i, "TG_LOTNO").ToString().Length == 9)
                            total++;
                    }
                }
                this.txt01_TOTAL_OUT_QTY.SetValue(total.ToString("#,###,###,###,###,##0"));
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

        //TABPAGE 1 : 월집계(ALC) 조회
        private void Inquery_Alc_Mon()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("SDATE",       this.dte01_SDATE.GetDateText());
                paramSet.Add("VINCD",       this.cdx01_VINCD.GetValue());
                paramSet.Add("BIZCD",       this.cbo01_BIZCD.GetValue());
                paramSet.Add("DUKYANG_YN",  this.chk01_DUKYANG_YN_PD30210.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery_Alc_Mon(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_ALC_MON"), paramSet);
                this.AfterInvokeServer();

                this.grd02.SetValue(source.Tables[0]);

                for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                {
                    if (this.grd02.GetValue(i, "VINCD").ToString().Equals(this.GetLabel("STOT")))//"소계"))
                        this.grd02.Rows[i].StyleNew.BackColor = Color.Yellow;

                    if (this.grd02.GetValue(i, "VINCD").ToString().Equals(this.GetLabel("TOTAL")))//"합계"))
                        this.grd02.Rows[i].StyleNew.BackColor = Color.Green;
                }

                this.Month_Setting(this.dte01_SDATE.Value.Year, this.dte01_SDATE.Value.Month);

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

        //TABPAGE 2 : 월실적(P6) 조회
        private void Inquery_Trim_Mon()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("SDATE", this.dte01_SDATE.GetDateText());
                paramSet.Add("VINCD", this.cdx01_VINCD.GetValue());
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery_Trim_Mon(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_TRIM_MON"), paramSet);
                this.AfterInvokeServer();
                this.grd03.SetValue(source.Tables[0]);

                for (int i = this.grd03.Rows.Fixed; i < this.grd03.Rows.Count; i++)
                {
                    if (this.grd03.GetValue(i, "VINCD").ToString().Equals(this.GetLabel("STOT")))//"소계"))
                        this.grd03.Rows[i].StyleNew.BackColor = Color.Yellow;

                    if (this.grd03.GetValue(i, "VINCD").ToString().Equals(this.GetLabel("TOTAL")))//"합계"))
                        this.grd03.Rows[i].StyleNew.BackColor = Color.Green;
                }

                this.Month_Setting(this.dte01_SDATE.Value.Year, this.dte01_SDATE.Value.Month);


              
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

        //TABPAGE 3 : 일실적(P6) 조회
        private void Inquery_Trim_Day()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("SDATE", this.dte01_SDATE.GetDateText());
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("VINCD", this.cdx01_VINCD.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery_Trim_Day(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_TRIM_DAY"), paramSet);
                this.AfterInvokeServer();
                this.grd04.SetValue(source.Tables[0]);

                for (int i = this.grd04.Rows.Fixed; i < this.grd04.Rows.Count; i++)
                {
                    if (this.grd04.GetValue(i, "VINCD").ToString().Equals(this.GetLabel("STOT")))//"소계"))
                        this.grd04.Rows[i].StyleNew.BackColor = Color.Yellow;

                    if (this.grd04.GetValue(i, "VINCD").ToString().Equals(this.GetLabel("TOTAL")))//"합계"))
                        this.grd04.Rows[i].StyleNew.BackColor = Color.Green;
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

        //TABPAGE 4 : 년실적(P6) 조회
        private void Inquery_Trim_Year()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("SDATE", this.dte01_SDATE.GetDateText());
                paramSet.Add("VINCD", this.cdx01_VINCD.GetValue());
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery_Trim_Mon(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_TRIM_YEAR"), paramSet);
                this.AfterInvokeServer();
                this.grd05.SetValue(source.Tables[0]);

                for (int i = this.grd05.Rows.Fixed; i < this.grd05.Rows.Count; i++)
                {
                    if (this.grd05.GetValue(i, "VINCD").ToString().Equals(this.GetLabel("STOT")))//"소계"))
                        this.grd05.Rows[i].StyleNew.BackColor = Color.Yellow;

                    if (this.grd05.GetValue(i, "VINCD").ToString().Equals(this.GetLabel("TOTAL")))//"합계"))
                        this.grd05.Rows[i].StyleNew.BackColor = Color.Green;
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
        
        //월 단위 조회시 그리드 헤더 설정
        private void Month_Setting(int year, int month)
        {
            try
            {
                this.grd02.Cols["QTY_29"].Visible = true;
                this.grd03.Cols["QTY_29"].Visible = true;
                this.grd02.Cols["QTY_30"].Visible = true;
                this.grd03.Cols["QTY_30"].Visible = true;
                this.grd02.Cols["QTY_31"].Visible = true;
                this.grd03.Cols["QTY_31"].Visible = true;

                int day = System.DateTime.DaysInMonth(year, month) + 1;

                for (; day < 32; day++)
                {
                    string col_name = string.Format("QTY_{0}", day);
                    this.grd02.Cols[col_name].Visible = false;
                    this.grd03.Cols[col_name].Visible = false;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }


        //TABPAGE 5 : 출고실적비교 조회
        private void Inquery_Diff()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("SDATE", this.dte01_SDATE.GetDateText());
                paramSet.Add("EDATE", this.dte01_EDATE.GetDateText());
                paramSet.Add("VINCD", this.cdx01_VINCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("PLANT", this.cbo01_CUST_PLANT.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery_Alc_Mon(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DIFF"), paramSet);
                this.AfterInvokeServer();

                this.grd06.SetValue(source.Tables[0]);

                for (int i = this.grd06.Rows.Fixed; i < this.grd06.Rows.Count; i++)
                {
                    
                    string diff = this.grd06.GetValue(i, "DIFF").ToString();
                    if (string.IsNullOrEmpty(diff) || diff == "0")
                        this.grd06.Rows[i].StyleNew.Clear();
                    else
                        this.grd06.SetCellStyle(i, this.grd06.Cols["DIFF"].Index, "Red");                    
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

        #endregion

        #region [ 기타 이벤트 정의 ]
        
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.chk01_DUKYANG_YN_PD30210.Visible = false;
                this.chk01_CHK_PD30210.Visible = false;
                this.chk01_SCAN_CHK_PD30210.Visible = false;
                this.cbo01_ITEM.SetReadOnly(true);

                if (this.tabControl1.SelectedIndex == 0)
                {
                    int cnt = this.grd01.Rows.Count - this.grd01.Rows.Fixed;

                    //this.lbl01_CNT_PD30210.Value = string.Format("{0} 건", cnt);
                    this.lbl01_CNT_PD30210.Value = string.Format("{0} " + this.GetLabel("PIECE"), cnt);

                    this.cbo01_CUST_LINE.SetReadOnly(false);
                    this.cbo01_CUST_PLANT.SetReadOnly(false);
                    this.cdx01_VINCD.SetReadOnly(false);
                    this.dte01_SDATE.SetReadOnly(false);
                    this.dte01_EDATE.SetReadOnly(false);
                    this.txt01_VINNO.SetReadOnly(false);
                    this.cbo01_ITEM.SetReadOnly(false);

                    this.chk01_SCAN_CHK_PD30210.Visible = true;
                    //this.chk01_CHK_PD30210.Visible = true; //2019.06.19
                    

                    this.panel4.Visible = true;
                    this.grp01_MES_QTY.Visible = true;
                    this.grp01_GATEWAY_QTY.Visible = true;

                }
                else if (this.tabControl1.SelectedIndex == 1)
                {
                    //this.lbl01_CNT_PD30210.Value = string.Format("0 건");
                    this.lbl01_CNT_PD30210.Value = string.Format("0 " + this.GetLabel("PIECE"));

                    this.chk01_DUKYANG_YN_PD30210.Visible = true;
                    this.cbo01_CUST_LINE.SetReadOnly(true);
                    this.cbo01_CUST_PLANT.SetReadOnly(true);
                    this.cdx01_VINCD.SetReadOnly(true);
                    this.dte01_SDATE.SetReadOnly(false);
                    this.dte01_EDATE.SetReadOnly(true);
                    this.txt01_VINNO.SetReadOnly(true);                    

                    this.panel4.Visible = false;
                    this.grp01_MES_QTY.Visible = false;
                    this.grp01_GATEWAY_QTY.Visible = false;
                }
                else if (this.tabControl1.SelectedIndex == 2)
                {
                    //this.lbl01_CNT_PD30210.Value = string.Format("0 건");
                    this.lbl01_CNT_PD30210.Value = string.Format("0 " + this.GetLabel("PIECE"));

                    this.cbo01_CUST_LINE.SetReadOnly(true);
                    this.cbo01_CUST_PLANT.SetReadOnly(true);
                    this.cdx01_VINCD.SetReadOnly(true);
                    this.dte01_SDATE.SetReadOnly(false);
                    this.dte01_EDATE.SetReadOnly(true);
                    this.txt01_VINNO.SetReadOnly(true);
                    
                    this.panel4.Visible = false;
                    this.grp01_MES_QTY.Visible = false;
                    this.grp01_GATEWAY_QTY.Visible = false;
                }
                else if (this.tabControl1.SelectedIndex == 3)
                {
                    //this.lbl01_CNT_PD30210.Value = string.Format("0 건");
                    this.lbl01_CNT_PD30210.Value = string.Format("0 " + this.GetLabel("PIECE"));

                    this.cbo01_CUST_LINE.SetReadOnly(true);
                    this.cbo01_CUST_PLANT.SetReadOnly(true);
                    this.cdx01_VINCD.SetReadOnly(false);
                    this.dte01_SDATE.SetReadOnly(false);
                    this.dte01_EDATE.SetReadOnly(true);
                    this.txt01_VINNO.SetReadOnly(true);
                    
                    this.panel4.Visible = false;
                    this.grp01_MES_QTY.Visible = false;
                    this.grp01_GATEWAY_QTY.Visible = false;
                }
                else if (this.tabControl1.SelectedIndex == 4)
                {
                    //this.lbl01_CNT_PD30210.Value = string.Format("0 건");
                    this.lbl01_CNT_PD30210.Value = string.Format("0 " + this.GetLabel("PIECE"));

                    this.cbo01_CUST_LINE.SetReadOnly(true);
                    this.cbo01_CUST_PLANT.SetReadOnly(true);
                    this.cdx01_VINCD.SetReadOnly(true);
                    this.dte01_SDATE.SetReadOnly(false);
                    this.dte01_EDATE.SetReadOnly(true);
                    this.txt01_VINNO.SetReadOnly(true);
                    
                    this.panel4.Visible = false;
                    this.grp01_MES_QTY.Visible = false;
                    this.grp01_GATEWAY_QTY.Visible = false;
                }
                else
                {  //this.lbl01_CNT_PD30210.Value = string.Format("0 건");
                    this.lbl01_CNT_PD30210.Value = string.Format("0 " + this.GetLabel("PIECE"));

                    this.cbo01_CUST_LINE.SetReadOnly(true);
                    this.cbo01_CUST_PLANT.SetReadOnly(false);
                    this.cdx01_VINCD.SetReadOnly(false);
                    this.dte01_SDATE.SetReadOnly(false);
                    this.dte01_EDATE.SetReadOnly(false);
                    this.txt01_VINNO.SetReadOnly(true);
                    
                    this.panel4.Visible = false;
                    this.grp01_MES_QTY.Visible = false;
                    this.grp01_GATEWAY_QTY.Visible = false;                
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //TABPAGE 0 : 서열세부(ALC) 그리드 더블클릭
        private void grd01_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //try
            //{
            //    int col = this.grd01.ColSel;
            //    int row = this.grd01.SelectedRowIndex;

            //    if (col == this.grd01.Cols["DTFL_LOTNO"].Index ||
            //        col == this.grd01.Cols["DTFR_LOTNO"].Index ||
            //        col == this.grd01.Cols["DTRL_LOTNO"].Index ||
            //        col == this.grd01.Cols["DTRR_LOTNO"].Index)
            //    {
            //        string LOTNO = this.grd01.GetValue(row, col).ToString();

            //        if (LOTNO.Length > 0)
            //        {
            //            //PopupHelper helper = new PopupHelper(new SD30231(LOTNO), "완제품 LOTNO 조회(POP) 팝업");
            //            PopupHelper helper = new PopupHelper(new PD30230P1(LOTNO), this.GetLabel("PD30210_MSG1"));
            //            helper.ShowDialog(false);
            //        }
            //    }
            //}
            //catch (FaultException<ExceptionDetail> ex)
            //{
            //    MsgBox.Show(ex.ToString());
            //}
        }

        #endregion
    }
}
