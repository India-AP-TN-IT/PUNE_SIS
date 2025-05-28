#region ▶ Description & History
/* 
 * 프로그램명 : PD40160 서열 출고 정보
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
*/
#endregion
using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 서열 출고 처리 조회
    /// </summary>
    public partial class PD40160 : AxCommonBaseControl
    {
        //private IPD40160 _WSCOM;
        //private IPDCOMMON_MES _WSCOM_MES;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40160";
        public PD40160()
        {
            InitializeComponent();

            //_WSCOM  = ClientFactory.CreateChannel<IPD40160>("PD", "PD40160_N.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize(2, 2);
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;
                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 48, "SEQ", "LSEQ", "SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "BODY", "BODY", "BODY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "TIME", "TIME", "TIME");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 88, "ORDER NO", "ORDNO", "ORDERNO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "상태", "STATUS", "STATUS");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 60, "YMD", "YMD_ONLY", "YMD_ONLY");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "DTFL_B", "BSEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "DTFL", "ALC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKFL", "PROCESS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "FL_LOTNO", "LOTNO");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "DTFR_B", "BSEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "DTFR", "ALC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKFR", "PROCESS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "FR_LOTNO", "LOTNO");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "DTRL_B", "BSEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "DTRL", "ALC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKRL", "PROCESS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "RL_LOTNO", "LOTNO");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "DTRR_B", "BSEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "DTRR", "ALC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKRR", "PROCESS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "RR_LOTNO", "LOTNO");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "LH PLT", "LH_PLT", "LH_PLT");   //20190523
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "RH PLT", "RH_PLT", "RH_PLT");   //20190523

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "BPFRT_B", "BSEQ");           //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "BPFRT", "ALC");           //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKBF", "PROCESS");      //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "BF_LOTNO", "LOTNO");   //20190523
                                                                                                                //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "BPRR_B", "BSEQ");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "BPRR", "ALC");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKBR", "PROCESS");      //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "BR_LOTNO", "LOTNO");   //20190523
                                                                                                                //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "TGATE_B", "BSEQ");           //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "TGATE", "ALC");           //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKTG", "PROCESS");      //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "TG_LOTNO", "LOTNO");   //20190523
                                                                                                                //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "GDFL_B", "BSEQ");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "GDFL", "ALC");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKGFL", "PROCESS");     //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "GFL_LOTNO", "LOTNO");  //20190523
                                                                                                                //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "GDFR_B", "BSEQ");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "GDFR", "ALC");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKGFR", "PROCESS");     //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "GFR_LOTNO", "LOTNO");  //20190523
                                                                                                                //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "GDRL_B", "BSEQ");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "GDRL", "ALC");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKGRL", "PROCESS");     //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "GRL_LOTNO", "LOTNO");  //20190523
                                                                                                                //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "GDRR_B", "BSEQ");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "GDRR", "ALC");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKGRR", "PROCESS");     //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "GRR_LOTNO", "LOTNO");  //20190523

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "SSLH_B", "BSEQ");           //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "SSLH", "ALC");           //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKSL", "PROCESS");      //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "SL_LOTNO", "LOTNO");   //20190523
                //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "SSRH_B", "BSEQ");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "SSRH", "ALC");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKSR", "PROCESS");      //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "SR_LOTNO", "LOTNO");   //20190523

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "SPOILER_B", "BSEQ");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "SPOILER", "ALC");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKSPOILER", "PROCESS");      //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "SPOILER_LOTNO", "LOTNO");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "RRACKLH_B", "BSEQ");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "RRACKLH", "ALC");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKRRACKLH", "PROCESS");      //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "RRACKLH_LOTNO", "LOTNO");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "RRACKRH_B", "BSEQ");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "RRACKRH", "ALC");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKRRACKRH", "PROCESS");      //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "RRACKRH_LOTNO", "LOTNO");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 36, "BSEQ", "RGRILL_B", "BSEQ");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 32, "ALC", "RGRILL", "ALC");            //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 64, "처리", "CHKRGRILL", "PROCESS");      //20190523
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "Lot No", "RGRILL_LOTNO", "LOTNO");

                #region [그리드 Merge & 컬럼 설정]

                for (int i = 0; i < grd01.Cols.Count; i++)
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;

                this.grd01.AddMerge(0, 1, "LSEQ", "LSEQ");
                this.grd01.AddMerge(0, 1, "BODY", "BODY");
                this.grd01.AddMerge(0, 1, "TIME", "TIME");
                this.grd01.AddMerge(0, 1, "ORDNO", "ORDNO");
                this.grd01.AddMerge(0, 1, "STATUS", "STATUS");

                this.grd01.AddMerge(0, 0, "DTFL_B", "FL_LOTNO");
                this.grd01.SetHeadTitle(0, "DTFL_B", "DOOR TRIM F/L");

                this.grd01.AddMerge(0, 0, "DTFR_B", "FR_LOTNO");
                this.grd01.SetHeadTitle(0, "DTFR_B", "DOOR TRIM F/R");

                this.grd01.AddMerge(0, 0, "DTRL_B", "RL_LOTNO");
                this.grd01.SetHeadTitle(0, "DTRL_B", "DOOR TRIM R/L");

                this.grd01.AddMerge(0, 0, "DTRR_B", "RR_LOTNO");
                this.grd01.SetHeadTitle(0, "DTRR_B", "DOOR TRIM R/R");

                this.grd01.AddMerge(0, 0, "LH_PLT", "RH_PLT");
                this.grd01.SetHeadTitle(0, "LH_PLT", "PALLET");

                this.grd01.AddMerge(0, 0, "BPFRT_B", "BF_LOTNO");
                this.grd01.SetHeadTitle(0, "BPFRT_B", "BP / FRT");

                this.grd01.AddMerge(0, 0, "BPRR_B", "BR_LOTNO");
                this.grd01.SetHeadTitle(0, "BPRR_B", "BP / RR");

                this.grd01.AddMerge(0, 0, "TGATE_B", "TG_LOTNO");
                this.grd01.SetHeadTitle(0, "TGATE_B", "T /GATE");

                this.grd01.AddMerge(0, 0, "GDFL_B", "GFL_LOTNO");
                this.grd01.SetHeadTitle(0, "GDFL_B", "D/GARNISH / FL");

                this.grd01.AddMerge(0, 0, "GDFR_B", "GFR_LOTNO");
                this.grd01.SetHeadTitle(0, "GDFR_B", "D/GARNISH / FR");

                this.grd01.AddMerge(0, 0, "GDRL_B", "GRL_LOTNO");
                this.grd01.SetHeadTitle(0, "GDRL_B", "D/GARNISH / RL");

                this.grd01.AddMerge(0, 0, "GDRR_B", "GRR_LOTNO");
                this.grd01.SetHeadTitle(0, "GDRR_B", "D/GARNISH / RR");

                this.grd01.AddMerge(0, 0, "SSLH_B", "SL_LOTNO");
                this.grd01.SetHeadTitle(0, "SSLH_B", "SSIDE / LH");

                this.grd01.AddMerge(0, 0, "SSRH_B", "SR_LOTNO");
                this.grd01.SetHeadTitle(0, "SSRH_B", "SSIDE / RH");
                //
                this.grd01.AddMerge(0, 0, "SPOILER_B", "SPOILER_LOTNO");
                this.grd01.SetHeadTitle(0, "SPOILER_B", "SPOILER");

                this.grd01.AddMerge(0, 0, "RRACKLH_B", "RRACKLH_LOTNO");
                this.grd01.SetHeadTitle(0, "RRACKLH_B", "R/RACK LH");

                this.grd01.AddMerge(0, 0, "RRACKRH_B", "RRACKRH_LOTNO");
                this.grd01.SetHeadTitle(0, "RRACKRH_B", "R/RACK RH");

                this.grd01.AddMerge(0, 0, "RGRILL_B", "RGRILL_LOTNO");
                this.grd01.SetHeadTitle(0, "RGRILL_B", "R/GRILL");


                this.grd01.Cols["DTFL_B"].StyleNew.BackColor = Color.PapayaWhip;
                this.grd01.Cols["DTFL"].StyleNew.BackColor = Color.PapayaWhip;
                this.grd01.Cols["CHKFL"].StyleNew.BackColor = Color.PapayaWhip;
                this.grd01.Cols["FL_LOTNO"].StyleNew.BackColor = Color.PapayaWhip;

                this.grd01.Cols["DTFR_B"].StyleNew.BackColor = Color.PapayaWhip;
                this.grd01.Cols["DTFR"].StyleNew.BackColor = Color.PapayaWhip;
                this.grd01.Cols["CHKFR"].StyleNew.BackColor = Color.PapayaWhip;
                this.grd01.Cols["FR_LOTNO"].StyleNew.BackColor = Color.PapayaWhip;

                this.grd01.Cols["DTRL_B"].StyleNew.BackColor = Color.PapayaWhip;
                this.grd01.Cols["DTRL"].StyleNew.BackColor = Color.PapayaWhip;
                this.grd01.Cols["CHKRL"].StyleNew.BackColor = Color.PapayaWhip;
                this.grd01.Cols["RL_LOTNO"].StyleNew.BackColor = Color.PapayaWhip;

                this.grd01.Cols["DTRR_B"].StyleNew.BackColor = Color.PapayaWhip;
                this.grd01.Cols["DTRR"].StyleNew.BackColor = Color.PapayaWhip;
                this.grd01.Cols["CHKRR"].StyleNew.BackColor = Color.PapayaWhip;
                this.grd01.Cols["RR_LOTNO"].StyleNew.BackColor = Color.PapayaWhip;

                this.grd01.Cols["BPFRT_B"].StyleNew.BackColor = Color.LightCyan;
                this.grd01.Cols["BPFRT"].StyleNew.BackColor = Color.LightCyan;
                this.grd01.Cols["CHKBF"].StyleNew.BackColor = Color.LightCyan;
                this.grd01.Cols["BF_LOTNO"].StyleNew.BackColor = Color.LightCyan;

                this.grd01.Cols["BPRR_B"].StyleNew.BackColor = Color.LightCyan;
                this.grd01.Cols["BPRR"].StyleNew.BackColor = Color.LightCyan;
                this.grd01.Cols["CHKBR"].StyleNew.BackColor = Color.LightCyan;
                this.grd01.Cols["BR_LOTNO"].StyleNew.BackColor = Color.LightCyan;

                this.grd01.Cols["TGATE_B"].StyleNew.BackColor = Color.LavenderBlush;
                this.grd01.Cols["TGATE"].StyleNew.BackColor = Color.LavenderBlush;
                this.grd01.Cols["CHKTG"].StyleNew.BackColor = Color.LavenderBlush;
                this.grd01.Cols["TG_LOTNO"].StyleNew.BackColor = Color.LavenderBlush;

                this.grd01.Cols["GDFL_B"].StyleNew.BackColor = Color.Gainsboro;
                this.grd01.Cols["GDFL"].StyleNew.BackColor = Color.Gainsboro;
                this.grd01.Cols["CHKGFL"].StyleNew.BackColor = Color.Gainsboro;
                this.grd01.Cols["GFL_LOTNO"].StyleNew.BackColor = Color.Gainsboro;

                this.grd01.Cols["GDFR_B"].StyleNew.BackColor = Color.Gainsboro;
                this.grd01.Cols["GDFR"].StyleNew.BackColor = Color.Gainsboro;
                this.grd01.Cols["CHKGFR"].StyleNew.BackColor = Color.Gainsboro;
                this.grd01.Cols["GFR_LOTNO"].StyleNew.BackColor = Color.Gainsboro;

                this.grd01.Cols["GDRL_B"].StyleNew.BackColor = Color.Gainsboro;
                this.grd01.Cols["GDRL"].StyleNew.BackColor = Color.Gainsboro;
                this.grd01.Cols["CHKGRL"].StyleNew.BackColor = Color.Gainsboro;
                this.grd01.Cols["GRL_LOTNO"].StyleNew.BackColor = Color.Gainsboro;

                this.grd01.Cols["GDRR_B"].StyleNew.BackColor = Color.Gainsboro;
                this.grd01.Cols["GDRR"].StyleNew.BackColor = Color.Gainsboro;
                this.grd01.Cols["CHKGRR"].StyleNew.BackColor = Color.Gainsboro;
                this.grd01.Cols["GRR_LOTNO"].StyleNew.BackColor = Color.Gainsboro;

                this.grd01.Cols["SSLH_B"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["SSLH"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["CHKSL"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["SL_LOTNO"].StyleNew.BackColor = Color.Beige;

                this.grd01.Cols["SSRH_B"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["SSRH"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["CHKSR"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["SR_LOTNO"].StyleNew.BackColor = Color.Beige;

                this.grd01.Cols["SPOILER_B"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["SPOILER"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["CHKSPOILER"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["SPOILER_LOTNO"].StyleNew.BackColor = Color.Beige;

                this.grd01.Cols["RRACKLH_B"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["RRACKLH"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["CHKRRACKLH"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["RRACKLH_LOTNO"].StyleNew.BackColor = Color.Beige;

                this.grd01.Cols["RRACKRH_B"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["RRACKRH"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["CHKRRACKRH"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["RRACKRH_LOTNO"].StyleNew.BackColor = Color.Beige;

                this.grd01.Cols["RGRILL_B"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["RGRILL"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["CHKRGRILL"].StyleNew.BackColor = Color.Beige;
                this.grd01.Cols["RGRILL_LOTNO"].StyleNew.BackColor = Color.Beige;

                grd01.Cols.Frozen = 3;
                grd01.Cols["LSEQ"].StyleNew.BackColor = Color.White;
                grd01.Cols["BODY"].StyleNew.BackColor = Color.White;
                grd01.Cols["TIME"].StyleNew.BackColor = Color.White;
                #endregion

                this.grd02.AllowEditing = false;
                this.grd02.Initialize(2, 2);//this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 115, "구분", "TITLE", "DIVISION");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "F/LH", "FLH", "FLH");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "F/RH", "FRH", "FRH");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "R/LH", "RLH", "RLH");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "R/RH", "RRH", "RRH");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "BP/FRT", "BPFRT", "BPFRT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "BP/RR", "BPRR", "BPRR");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "T/GATE", "TGATE", "TGATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "F/LH", "GDFL", "GDFL");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "F/RH", "GDFR", "GDFR");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "R/LH", "GDRL", "GDRL");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "R/RH", "GDRR", "GDRR");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "SS/LH", "SSLH", "SSLH");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "SS/RH", "SSRH", "SSRH");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "SPOILER", "SPOILER", "SPOILER");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "RRACKLH", "RRACKLH", "RRACKLH");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "RRACKLH", "RRACKRH", "RRACKRH");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 050, "RGRILL", "RGRILL", "RGRILL");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "FLH");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "FRH");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "RLH");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "RRH");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "BPFRT");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "BPRR");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "TGATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "GDFL");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "GDFR");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "GDRL");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "GDRR");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "SSLH");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "SSRH");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "SPOILER");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "RRACKLH");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "RRACKRH");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "RGRILL");

                this.grd02.Cols[0].Visible = false;

                this.grd03.AllowEditing = false;
                this.grd03.Initialize(1, 1);//this.grd02.Initialize();
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd03.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "CAR MODEL", "VINCD", "VINCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 115, "TYPE", "TYPE", "TYPE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "WORK ORD. NO.", "ORDNO", "ORDNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "TRIM", "CODE", "CODE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "TOTAL", "COUNT", "COUNT");

                this.grd03.SetColumnType(AxFlexGrid.FCellType.Int, "COUNT");

                #region [그리드 Merge & 컬럼 설정]

                for (int i = 0; i < grd02.Cols.Count; i++)
                    this.grd02[1, i] = this.grd02.Cols[i].Caption;

                this.grd02.AddMerge(0, 1, "TITLE", "TITLE");

                this.grd02.AddMerge(0, 0, "FLH", "RRH");
                this.grd02.SetHeadTitle(0, "FLH", "DOOR TRIM");

                this.grd02.AddMerge(0, 0, "BPFRT", "BPRR");
                this.grd02.SetHeadTitle(0, "BPFRT", "BUMPER");

                this.grd02.AddMerge(0, 1, "TGATE", "TGATE");
                //this.grd02.SetHeadTitle(0, "FLH", "DOOR TRIM");

                this.grd02.AddMerge(0, 0, "GDFL", "GDRR");
                this.grd02.SetHeadTitle(0, "GDFL", "DOOR GARNISH");

                this.grd02.AddMerge(0, 0, "SSLH", "SSRH");
                this.grd02.SetHeadTitle(0, "SSLH", "SSIDE");
                this.grd02.SetHeadTitle(0, "SPOILER", "SPOILER");
                this.grd02.SetHeadTitle(0, "RRACKLH", "RRACKLH");
                this.grd02.SetHeadTitle(0, "RRACKRH", "RRACKRH");
                this.grd02.SetHeadTitle(0, "RGRILL", "RGRILL");
                #endregion

                #region [바인딩 정보 생성]

                DataTable source1 = new DataTable();
                source1.Columns.Add("CODE");
                source1.Columns.Add("VALUE");
                source1.Rows.Add("1", "1 " + this.GetLabel("PLANT"));   //1 공장
                source1.Rows.Add("2", "2 " + this.GetLabel("PLANT"));   //2 공장
                source1.Rows.Add("3", "3 " + this.GetLabel("PLANT"));   //3 공장
                source1.Rows.Add("4", "4 " + this.GetLabel("PLANT"));   //4 공장
                source1.Rows.Add("5", "5 " + this.GetLabel("PLANT"));   //5 공장
                source1.Rows.Add("7", "7 " + this.GetLabel("PLANT"));   //7 공장

                DataTable source2 = new DataTable();
                source2.Columns.Add("CODE");
                source2.Columns.Add("VALUE");
                source2.Rows.Add("1", "1 " + this.GetLabel("LINE"));   //1 라인
                source2.Rows.Add("2", "2 " + this.GetLabel("LINE"));   //2 라인

                #endregion

                this.cbo01_PLANT.DataBind(source1, false);
                this.cbo01_LINE.DataBind(source2, false);
                this.cbo04_PLANT.DataBind(source1, false);
                this.cbo04_LINE.DataBind(source2, false);

                this.txt01_YMD.Visible = false;


                string UTime;
                this.txt01_CTS.Text = GetCTS(out UTime);
                this.lbl01_CTSUT.Text = "Update Time: " + UTime;
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
                if (tabControl1.SelectedIndex == 0)
                {
                    this.txt01_YMD.Visible = string.IsNullOrEmpty(this.txt01_BODY_NO.GetValue().ToString()) ? false : true;
                    string bizcd = this.UserInfo.BusinessCode;

                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.UserInfo.BusinessCode);
                    set.Add("YMD", this.dtp01_YMD.GetDateText().ToString().Replace("-", ""));
                    set.Add("PLANT", this.cbo01_PLANT.GetValue());
                    set.Add("LINE", this.cbo01_LINE.GetValue());
                    set.Add("PLT_YN", chk01_PALLET_SEQ_YN.Checked ? "Y" : "N");
                    set.Add("LANG_SET", this.UserInfo.Language);
                    set.Add("BODY_NO", this.txt01_BODY_NO.GetValue());
                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(bizcd, set);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");
                    set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.UserInfo.BusinessCode);
                    set.Add("YMD", this.dtp01_YMD.GetDateText().ToString().Replace("-", ""));
                    set.Add("PLANT", this.cbo01_PLANT.GetValue());
                    set.Add("LINE", this.cbo01_LINE.GetValue());
                    set.Add("LANG_SET", this.UserInfo.Language);
                    DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SUM_INFO"), set, "OUT_CURSOR");

                    set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.UserInfo.BusinessCode);
                    set.Add("YMD", this.dtp01_YMD.GetDateText().ToString().Replace("-", ""));
                    set.Add("PLANT", this.cbo01_PLANT.GetValue());
                    set.Add("LINE", this.cbo01_LINE.GetValue());
                    DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COUNT_INFO"), set, "OUT_CURSOR");
                    this.AfterInvokeServer();

                    this.grd01.SetValue(source.Tables[0]);
                    this.grd02.SetValue(source1.Tables[0]);

                    this.grd02.Rows[2].StyleNew.ForeColor = Color.Red;
                    this.grd02.Rows[3].StyleNew.ForeColor = Color.Blue;
                    this.grd02.Rows[4].StyleNew.ForeColor = Color.Blue;
                    this.grd02.Rows[5].StyleNew.ForeColor = Color.Blue;

                    this.txt01_YMD.SetValue(source.Tables[0].Rows[0]["YMD"].ToString());

                    Lbl_SP2I_Count.Text = "0";
                    Lbl_QY_Count.Text = "0";
                    Lbl_KY_Count.Text = "0";
                    Lbl_AY_Count.Text = "0";
                    foreach (DataRow dr in source2.Tables[0].Rows)
                    {
                        if (dr["VINCD"].ToString().Contains("SP2I"))
                        {
                            Lbl_SP2I_Count.Text = dr["VINCD"].ToString().Replace("SP2I", "");
                        }
                        else if (dr["VINCD"].ToString().Contains("QY"))
                        {
                            Lbl_QY_Count.Text = dr["VINCD"].ToString().Replace("QY", "");
                        }
                        else if (dr["VINCD"].ToString().Contains("KY"))
                        {
                            Lbl_KY_Count.Text = dr["VINCD"].ToString().Replace("KY", "");
                        }
                        else if (dr["VINCD"].ToString().Contains("AY"))
                        {
                            Lbl_AY_Count.Text = dr["VINCD"].ToString().Replace("AY", "");
                        }
                    }
                }
                else if(tabControl1.SelectedIndex == 1)
                {
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.UserInfo.BusinessCode);
                    set.Add("SYMD", this.dtp04_SYMD.GetDateText().ToString().Replace("-", ""));
                    set.Add("EYMD", this.dtp04_EYMD.GetDateText().ToString().Replace("-", ""));
                    set.Add("PLANT", this.cbo01_PLANT.GetValue());
                    set.Add("LINE", this.cbo01_LINE.GetValue());

                    this.BeforeInvokeServer(true);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_ORDNO_DETAIL"), set, "OUT_CURSOR");

                    this.AfterInvokeServer();

                    this.grd03.SetValue(source.Tables[0]);

                    this.MergeCols("VINCD", "TYPE", "CODE");
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

        #region [기타 이벤트]
        private string Disp2DBarcode(string ymd, string bseq, string item, string bseq_code ="")
        {
            
            pictureBox2.BackgroundImage = null;
            string code = "";
            if(string.IsNullOrEmpty(bseq_code))
            {
                code = string.Format("<[BK]>@<[SIS]>@C{0}@B{1}@UKMI@P{2}@L{3}@Y{4}@I{5}@S{6}", UserInfo.CorporationCode, UserInfo.BusinessCode
                , cbo01_PLANT.GetValue().ToString(), cbo04_LINE.GetValue().ToString()
                , ymd.Replace("-", ""), item, Convert.ToInt32(bseq));
            }
            else
            {
                code = bseq_code;
            }
             
            
            pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Bitmap bt = new DataMatrix.net.DmtxImageEncoder().EncodeImage(code);
            pictureBox2.BackgroundImage = bt;
            return code;
        }
        private void grd01_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;
                int col = this.grd01.ColSel;
                if (row < this.grd01.Rows.Fixed) return;

#region 공통 ALC Visible
                //if ((col == this.grd01.Cols["DTFL"].Index ||
                //      col == this.grd01.Cols["DTFR"].Index ||
                //      col == this.grd01.Cols["DTRL"].Index ||
                //      col == this.grd01.Cols["DTRR"].Index ||
                //      col == this.grd01.Cols["BPFRT"].Index ||
                //      col == this.grd01.Cols["BPRR"].Index ||
                //      col == this.grd01.Cols["TGATE"].Index ||
                //      col == this.grd01.Cols["GDFL"].Index ||
                //      col == this.grd01.Cols["GDFR"].Index ||
                //      col == this.grd01.Cols["GDRL"].Index ||
                //      col == this.grd01.Cols["GDRR"].Index ))
                //{

                //    string bizcd = this.UserInfo.BusinessCode;
                //    string alccd = this.grd01.GetValue(row, col).ToString().Trim();
                //    string vid = this.grd01.GetValue(row, "VID").ToString().Trim();
                //    string install_pos = this.grd01.Cols[col].Name.Substring(2, 2);

                //    if (alccd.Length == 0) return;

                //    HEParameterSet set = new HEParameterSet();
                //    set.Add("CORCD", this.UserInfo.CorporationCode);
                //    set.Add("BIZCD", bizcd);
                //    set.Add("ALCCD", alccd);
                //    set.Add("VID", vid);
                //    set.Add("INSTALL_POS", install_pos);

                //    this.BeforeInvokeServer(true);
                //    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_COMMON_ALC"), set, "OUT_CURSOR");
                //    //DataSet source = _WSCOM.INQUERY_COMMON_ALC(bizcd, set);
                //    this.AfterInvokeServer();

                //    if (source.Tables[0].Rows.Count == 1)
                //    {
                //        //MsgBox.Show(string.Format("'{0}', '{1}'의 공통 ALC 정보가 없습니다!! ", install_pos, alccd));
                //        MsgCodeBox.ShowFormat("PD00-0027", install_pos, alccd);
                //        return;
                //    }

                //    lbl05_ALCCD.Text = "";
                //    lbl05_VID.Text = "";

                //    lbl05_ALCCD.Text = alccd;
                //    lbl05_VID.Text = vid;

                //    this.lst05_COMMON_ALC.Items.Clear();

                //    foreach (DataRow rows in source.Tables[0].Rows)
                //    {
                //        lst05_COMMON_ALC.Items.Add(rows["ALCCD"].ToString().Trim());
                //    }

                //    pnAlcInfo.Visible = true;
                //}
#endregion

                //LOT NO 상세 조회

                if ((col == this.grd01.Cols["FL_LOTNO"].Index ||
                      col == this.grd01.Cols["FR_LOTNO"].Index ||
                      col == this.grd01.Cols["RL_LOTNO"].Index ||
                      col == this.grd01.Cols["RR_LOTNO"].Index ||
                      col == this.grd01.Cols["BF_LOTNO"].Index ||
                      col == this.grd01.Cols["BR_LOTNO"].Index ||
                      col == this.grd01.Cols["TG_LOTNO"].Index ||
                      col == this.grd01.Cols["GFL_LOTNO"].Index ||
                      col == this.grd01.Cols["GFR_LOTNO"].Index ||
                      col == this.grd01.Cols["GRL_LOTNO"].Index ||
                      col == this.grd01.Cols["GRR_LOTNO"].Index || 
                      col == this.grd01.Cols["SL_LOTNO"].Index ||
                      col == this.grd01.Cols["SR_LOTNO"].Index ||
                      col == this.grd01.Cols["SPOILER_LOTNO"].Index ||
                      col == this.grd01.Cols["RRACKLH_LOTNO"].Index ||
                      col == this.grd01.Cols["RRACKRH_LOTNO"].Index ||
                      col == this.grd01.Cols["RGRILL_LOTNO"].Index))
                {
                    string lotno = this.grd01.GetValue(row, col).ToString();

                    if (lotno.Length == 0) return;

                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.UserInfo.BusinessCode);
                    set.Add("LOTNO", lotno);

                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY_DETAIL(bizcd, set);
                    DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DETAIL"), set, "OUT_CURSOR");
                    this.AfterInvokeServer();

                    if (source.Tables[0].Rows.Count == 0)
                    {
                        //MsgBox.Show(string.Format("Lot No ({0}) 제품 정보가 없습니다!! ", lotno));
                        MsgCodeBox.ShowFormat("PD00-0028", lotno);
                        return;
                    }

                    DataRow dr = source.Tables[0].Rows[0];

                    lbl03_LOTNO.Text = "";
                    lbl03_ALCCD.Text = "";
                    lbl03_PARTNO.Text = "";
                    lbl03_RSLT_DATE.Text = "";
                    lbl03_RSLT_DATE.Text = "";
                    lbl03_PROD_TIME.Text = "";
                    lbl03_PROD_DATE.Text = "";
                    lbl03_IN_READ_DATE.Text = "";
                    lbl03_IN_READ_TIME.Text = "";
                    lbl03_OUT_READ_DATE.Text = "";
                    lbl03_OUT_READ_TIME.Text = "";
                    lbl03_CUST_PLANT.Text = "";
                    lbl03_CUST_LINE.Text = "";
                    lbl03_ALC_SEQ.Text = "";
                    lbl03_DELI_DATE.Text = "";
                    lbl03_DELI_PLTNO.Text = "";
                    lbl03_CARNO.Text = "";

                   

                    lbl03_LOTNO.Text = dr["LOTNO"].ToString();
                    lbl03_ALCCD.Text = dr["ALCCD"].ToString();
                    lbl03_PARTNO.Text = dr["PARTNO"].ToString();
                    lbl03_RSLT_DATE.Text = DateTime.Parse(dr["RSLT_DATE"].ToString()).GetDateTimeFormats()[0];// dr["RSLT_DATE"].ToString();
                    lbl03_RSLT_DATE.Text = DateTime.Parse(dr["RSLT_DATE"].ToString()).GetDateTimeFormats()[0];// dr["RSLT_DATE"].ToString();
                    lbl03_PROD_TIME.Text = dr["PROD_TIME"].ToString().Length == 0 ? "" : dr["PROD_TIME"].ToString().Insert(4, ":").Insert(2, ":");
                    lbl03_PROD_DATE.Text = DateTime.Parse(dr["PROD_DATE"].ToString()).GetDateTimeFormats()[0]; //dr["PROD_DATE"].ToString();
                    lbl03_IN_READ_DATE.Text = DateTime.Parse(dr["IN_READ_DATE"].ToString()).GetDateTimeFormats()[0]; //dr["IN_READ_DATE"].ToString();
                    lbl03_IN_READ_TIME.Text = dr["IN_READ_TIME"].ToString().Length == 0 ? "" : dr["IN_READ_TIME"].ToString().Insert(4, ":").Insert(2, ":");
                    lbl03_OUT_READ_DATE.Text = DateTime.Parse(dr["OUT_READ_DATE"].ToString()).GetDateTimeFormats()[0]; //dr["OUT_READ_DATE"].ToString();
                    lbl03_OUT_READ_TIME.Text = dr["OUT_READ_TIME"].ToString().Length == 0 ? "" : dr["OUT_READ_TIME"].ToString().Insert(4, ":").Insert(2, ":");
                    lbl03_CUST_PLANT.Text = dr["CUST_PLANT"].ToString();
                    lbl03_CUST_LINE.Text = dr["CUST_LINE"].ToString();
                    lbl03_ALC_SEQ.Text = dr["ALC_SEQ"].ToString();
                    lbl03_DELI_DATE.Text = DateTime.Parse(dr["DELI_DATE"].ToString()).GetDateTimeFormats()[0]; //dr["DELI_DATE"].ToString();
                    lbl03_DELI_PLTNO.Text = dr["DELI_PLTNO"].ToString();
                    lbl03_CARNO.Text = dr["CARNO"].ToString();

                    pnLotInfo.Visible = true;


                    
                }
                else if ((col == this.grd01.Cols["BPFRT_B"].Index ||
                     col == this.grd01.Cols["BPRR_B"].Index ||
                     col == this.grd01.Cols["TGATE_B"].Index ||
                     col == this.grd01.Cols["GDFL_B"].Index ||
                     col == this.grd01.Cols["GDFR_B"].Index ||
                     col == this.grd01.Cols["GDRL_B"].Index ||
                     col == this.grd01.Cols["GDRR_B"].Index ||
                     col == this.grd01.Cols["SSLH_B"].Index ||
                     col == this.grd01.Cols["SSRH_B"].Index ||
                     col == this.grd01.Cols["DTFL_B"].Index ||
                     col == this.grd01.Cols["DTFR_B"].Index ||
                     col == this.grd01.Cols["DTRL_B"].Index ||
                     col == this.grd01.Cols["DTRR_B"].Index ||
                     col == this.grd01.Cols["SPOILER_B"].Index ||
                    col == this.grd01.Cols["RRACKLH_B"].Index ||
                    col == this.grd01.Cols["RRACKRH_B"].Index ||
                    col == this.grd01.Cols["RGRILL_B"].Index))
                {
                    label6.Text = "";
                    pictureBox2.BackgroundImage = null;
                    Txt_Bucket.Text = grd01.GetValue(row, col).ToString();
                    Lbl_PGN.Text = GetPGN(grd01.Cols[col].Name);
                    PNL_BUCKET.Visible =true;
                    PNL_BUCKET.BringToFront();
                    Lbl_YMD.Text = this.grd01.GetValue(row, "YMD_ONLY").ToString(); 
                    Lbl_Body.Text = this.grd01.GetValue(row, "BODY").ToString();
                    Lbl_SEQ.Text = this.grd01.GetValue(row, "LSEQ").ToString();
                    Txt_QTY.Text =  GetLoadQTY();
                    
                    string bseq_code = GetBSEQ_CODE(Lbl_YMD.Text, Lbl_SEQ.Text, Lbl_PGN.Text);
                    if(string.IsNullOrEmpty(bseq_code) == false)
                    {
                        Disp2DBarcode(Lbl_YMD.Text, Txt_Bucket.Text, Lbl_PGN.Text, bseq_code);
                        label6.Text = bseq_code;
                    }
                    
                    
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }
        private string GetPGN(string colNM)
        {
            string ret = "";
            switch(colNM)
            {
                case "BPFRT_B":
                    ret = "Q036";
                    break;
                case "BPRR_B":
                    ret = "Q034";
                    break;
                case "TGATE_B":
                    ret = "Q030";
                    break;
                case "GDFL_B":
                    ret = "Q027";
                    break;
                case "GDFR_B":
                    ret = "Q026";
                    break;
                case "GDRL_B":
                    ret = "Q025";
                    break;
                case "GDRR_B":
                    ret = "Q024";
                    break;
                case "SSLH_B":
                    ret = "P401";
                    break;
                case "SSRH_B":
                    ret = "P402";
                    break;
                case "DTFL_B":
                    ret = "Q094";
                    break;
                case "DTFR_B":
                    ret = "Q093";
                    break;
                case "DTRL_B":
                    ret = "Q088";
                    break;
                case "DTRR_B":
                    ret = "Q087";
                    break;
                case "SPOILER_B":
                    ret = "Q033";
                    break;
                case "RRACKRH_B":
                    ret = "Q031";
                    break;
                case "RRACKLH_B":
                    ret = "Q032";
                    break;
                case "RGRILL_B":
                    ret = "P684";
                    break;
            }
            return ret;
        }
        private void btn02_CLS_Click(object sender, EventArgs e)
        {
            try
            {
                pnLotInfo.Visible = false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn04_CLS_Click(object sender, EventArgs e)
        {
            try
            {
                pnAlcInfo.Visible = false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        private void btn01_SET_BODY_TALHA_Click(object sender, EventArgs e)
        {
            if (this.grd01.Row < this.grd01.Rows.Fixed || this.grd01.Row >= this.grd01.Rows.Count) return;
            try
            {
                if (string.IsNullOrEmpty(grd01.GetValue(this.grd01.Row, "LSEQ").ToString()))
                {
                    //MsgBox.Show("선택된 정보가 없습니다.");
                    MsgCodeBox.Show("CD00-0122"); //선택한 데이터가 없습니다.
                    return;
                }
                //string msg = string.Format("선택된 서열번호 : {0}\n서열번호의 바디탈하가 맞습니까?", grd01.GetValue(this.grd01.Row, "LSEQ").ToString());
                //if (MsgBox.Show(msg, "질문", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                if (MsgCodeBox.ShowFormat("PD00-0048", System.Windows.Forms.MessageBoxButtons.YesNo, grd01.GetValue(this.grd01.Row, "LSEQ").ToString()) == System.Windows.Forms.DialogResult.Yes)
                {
                    HEParameterSet set1 = new HEParameterSet();
                    set1.Add("YMD", this.dtp01_YMD.GetDateText().ToString().Replace("-", ""));
                    set1.Add("PLANT", this.cbo01_PLANT.GetValue());
                    set1.Add("LINE", this.cbo01_LINE.GetValue());
                    set1.Add("SEQ", grd01.GetValue(this.grd01.Row, "LSEQ").ToString());
                    set1.Add("LANG_SET", this.UserInfo.Language);

                    this.BeforeInvokeServer(true);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_BODY_TALHA"), set1);


                    this.AfterInvokeServer();

                    this.BtnQuery_Click(null, null);

                    //MsgBox.Show("바디탈하 처리완료");
                    MsgCodeBox.Show("CD00-0013"); //정상적으로 처리되었습니다. @@@
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        private void MergeCols(params string[] ColName)
        {
            for (int k = 0; k < ColName.Length; k++)
            {
                AxFlexGrid grd;
                int iS;
                int iE;
                if (ColName.Length == 1)
                {
                    grd = this.grd03;
                    iS = 2;//Start Row Index
                    iE = 0; //Start Row Index - 1
                }
                else
                {
                    grd = this.grd03;
                    iS = 1;//Start Row Index
                    iE = -1; //Start Row Index - 1
                }
                string sCurType = "";
                string sPreType = "";
                for (int i = iS; i < grd.Rows.Count; i++)
                {
                    iE++;
                    sCurType = Convert.ToString(grd.Rows[i][ColName[k]]);

                    if (sCurType != sPreType && sPreType != "")
                    {
                        grd.AddMerge(iS, iE, ColName[k], ColName[k]);
                        iS = iE + 1;

                    }
                    sPreType = sCurType;
                }
                if (grd.Rows.Count > iS) grd.AddMerge(iS, iE + 1, ColName[k], ColName[k]);
            }
        }

        private string GetCTS(out string UTime)
        {
            string CTS = "";
            UTime = "Error";
            try
            {
                HEParameterSet set = new HEParameterSet();

                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);

                this.BeforeInvokeServer(true);
                DataSet ds = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_CTS"), set, "OUT_CURSOR");
                this.AfterInvokeServer();

                CTS = ds.Tables[0].Rows[0]["CTS"].ToString();

                UTime = ds.Tables[0].Rows[0]["UPDATE_TIME"].ToString();

            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
            }
            return CTS;

        }
        private string GetLoadQTY()
        {
            
            
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("ITEM", Lbl_PGN.Text);
                set.Add("VINCD", "A3SP2I");
            DataTable dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_PGN_DATA"), set, "OUT_CURSOR").Tables[0];
            if(dt.Rows.Count>0)
            {
                return dt.Rows[0]["LOAD_QTY"].ToString();
            }
            return "0";
        }
        
        private string GetBSEQ_CODE(string ymd, string seq, string item)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.UserInfo.BusinessCode);
            set.Add("YMD", ymd.Replace("-",""));
            set.Add("SEQNO", seq);
            set.Add("ITEM", item);
            DataTable dt = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_BSEQ_CODE"), set, "OUT_CURSOR").Tables[0];
            if(dt.Rows.Count>0)
            {
                return dt.Rows[0]["BSEQ_2DCODE"].ToString();
            }
            return "";
            
        }
        
        private void btn01_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PLANT", this.cbo01_PLANT.GetValue());
                set.Add("LINE", this.cbo01_LINE.GetValue());
                set.Add("CTS", this.txt01_CTS.GetValue());


                if (!(string.IsNullOrEmpty(this.txt01_CTS.Text)))
                {
                    this.BeforeInvokeServer(true);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE_CTS"), set);
                    MsgBox.Show("Updated Successfully");
                }
                else
                {
                    MsgBox.Show("Value cannot be Null");
                }

                this.AfterInvokeServer();
            }
            catch(Exception ex)
            {
                MsgBox.Show(ex.ToString());
                this.AfterInvokeServer();
            }
        }

        private void axButton1_Click(object sender, EventArgs e)
        {
            PNL_BUCKET.Visible = false;
        }

        private void axButton2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Txt_QTY.Text))
            {
                MsgBox.Show("Value cannot be Null");
                return;
            }
            if (Txt_PWD.Text != DateTime.Now.ToString("MMdd"))
            {
                MsgBox.Show("Wrong Password!!");
                return;
            }
            if (string.IsNullOrEmpty(Txt_Bucket.Text))
            {
                MsgBox.Show("Wrong Bucket!!");
                return;
            }
            if (MsgBox.Show("Do you want to make force-Bucket code?", "Question", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                string seq = Lbl_SEQ.Text;
                int lqty = Convert.ToInt32(Txt_QTY.Text);
                string barcode = Disp2DBarcode(Lbl_YMD.Text, Txt_Bucket.Text, Lbl_PGN.Text);
                label6.Text = barcode;
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("YMD", Lbl_YMD.Text.Replace("-", ""));
                set.Add("PLANT", this.cbo01_PLANT.GetValue());
                set.Add("LINE", this.cbo01_LINE.GetValue());
                set.Add("ITEM", Lbl_PGN.Text);
                set.Add("LOAD_QTY", Txt_QTY.Text);
                set.Add("SEQNO", Lbl_SEQ.Text);
                set.Add("BSEQ_2DCODE", barcode);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_FORCE_BSEQ"), set);
            }
        }

        private void axButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Bucket.Text))
            {
                MsgBox.Show("Wrong Bucket!!");
                return;
            }
            if (Txt_PWD.Text != DateTime.Now.ToString("MMdd"))
            {
                MsgBox.Show("Wrong Password!!");
                return;
            }
            if (MsgBox.Show("Do you want to make force-Bucket reset for Bucket?", "Question", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                string seq = Lbl_SEQ.Text;
                int lqty = Convert.ToInt32(Txt_QTY.Text);
                string barcode = Disp2DBarcode(Lbl_YMD.Text, Txt_Bucket.Text, Lbl_PGN.Text);
                label6.Text = barcode;
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("CUSTCD", "KMI");
                set.Add("PLANT", this.cbo01_PLANT.GetValue());
                set.Add("LINE", this.cbo01_LINE.GetValue());

                set.Add("ST_DATE", Lbl_YMD.Text.Replace("-", ""));
                set.Add("ED_DATE", "99981231");

                set.Add("ST_SEQNO", Lbl_SEQ.Text);
                set.Add("ED_SEQNO", "9999");
                set.Add("SEQNO", Lbl_SEQ.Text);
                set.Add("START_BSEQ", Txt_Bucket.Text);
                set.Add("ITEM", Lbl_PGN.Text);

                _WSCOM_N.ExecuteNonQueryTx("APG_ALC_PRINT.SET_FORCE_BUCKET", set);
                PNL_BUCKET.Visible = false;
                BtnQuery_Click(null, null);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_QYI_Click(object sender, EventArgs e)
        {

        }
    }
}
