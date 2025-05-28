#region ▶ Description & History
/* 
 * 프로그램명 : PD40400 완성차LOT추적 전송자료 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
 *				
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Drawing;

using C1.Win.C1FlexGrid;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 제품별 작업내역 추적
    /// </summary>
    public partial class PD40400 : AxCommonBaseControl
    {
        //private IPD40400 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        //private IPDCOMMON_MES _WSCOM_MES;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40400";
        public PD40400()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<IPD40400>("PD", "PD40400_N.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            //_WSCOM_MES = ClientFactory.CreateChannel<IPDCOMMON_MES>("PD", "PDCOMMON_MES.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //if (this.UserInfo.BusinessCode == "5220")
                //{
                //    _WSCOM = ClientFactory.CreateChannel<IPD40400>("PD", "PD40400.svc", "CustomBinding");
                //}
                //else
                //{
                //    _WSCOM = ClientFactory.CreateChannel<IPD40400>("PD", "PD40400_N.svc", "CustomBinding");
                //}
                this.heDockingTab1.LinkBody  = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd02.AllowEditing = false;
                this.grd02.Initialize(2,2);
                this.grd02.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;
                
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "ORDER DATE", "YMD", "ORDER_DAY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 90, "CAR BODY", "BODY", "BODY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "OBJECT", "OBJECT_CNT", "OBJECT_CNT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "CURRENT", "CURRENT_CNT", "CURRENT_CNT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "DIFF", "DIFF", "DIFF");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "PART NO", "BPFR_PARTNO", "BPFR_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "ALC", "BPFR_ALCCD", "BPFR_ALCCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "BPFR_CNT", "BPFR_CNT");
                this.grd02.Cols[8].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "PART NO", "BPRR_PARTNO", "BPRR_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "ALC", "BPRR_ALCCD", "BPRR_ALCCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "BPRR_CNT", "BPRR_CNT");
                this.grd02.Cols[11].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "PART NO", "DTFL_PARTNO", "DTFL_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "ALC", "DTFL_ALCCD", "DTFL_ALCCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "DTFL_CNT", "DTFL_CNT");
                this.grd02.Cols[14].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "PART NO", "DTFR_PARTNO", "DTFR_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "ALC", "DTFR_ALCCD", "DTFR_ALCCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "DTFR_CNT", "DTFR_CNT");
                this.grd02.Cols[17].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "PART NO", "DTRL_PARTNO", "DTRL_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "ALC", "DTRL_ALCCD", "DTRL_ALCCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "DTRL_CNT", "DTRL_CNT");
                this.grd02.Cols[20].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "PART NO", "DTRR_PARTNO", "DTRR_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "ALC", "DTRR_ALCCD", "DTRR_ALCCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "DTRR_CNT", "DTRR_CNT");
                this.grd02.Cols[23].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "PWDW FL", "PWFL_PARTNO", "PWFL_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "PWFL_CNT", "PWFL_CNT");
                this.grd02.Cols[25].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "PWDW FR", "PWFR_PARTNO", "PWFR_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "PWFR_CNT", "PWFR_CNT");
                this.grd02.Cols[27].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "PWDW RL", "PWRL_PARTNO", "PWRL_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "PWRL_CNT", "PWRL_CNT");
                this.grd02.Cols[29].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "PWDW RR", "PWRR_PARTNO", "PWRR_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "PWRR_CNT", "PWRR_CNT");
                this.grd02.Cols[31].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "IHDL FL", "IHFL_PARTNO", "IHFL_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "IHFL_CNT", "IHFL_CNT");
                this.grd02.Cols[33].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "IHDL FR", "IHFR_PARTNO", "IHFR_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "IHFR_CNT", "IHFR_CNT");
                this.grd02.Cols[35].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "IHDL RL", "IHRL_PARTNO", "IHRL_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "IHRL_CNT", "IHRL_CNT");
                this.grd02.Cols[37].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "IHDL RR", "IHRR_PARTNO", "IHRR_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "IHRR_CNT", "IHRR_CNT");
                this.grd02.Cols[39].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "FOGLED F/LH", "LPFL_PARTNO", "LPFL_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "LPFL_CNT", "LPFL_CNT");
                this.grd02.Cols[41].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "FOGLED F/RH", "LPFR_PARTNO", "LPFR_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "LPFR_CNT", "LPFR_CNT");
                this.grd02.Cols[43].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "FOGLED R/LH", "LPRL_PARTNO", "LPRL_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "LPRL_CNT", "LPRL_CNT");
                this.grd02.Cols[45].Visible = false;

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "FOGLED R/RH", "LPRR_PARTNO", "LPRR_PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "STATUS", "LPRR_CNT", "LPRR_CNT");
                this.grd02.Cols[47].Visible = false;


                CellStyle csNoTrans = grd02.Styles.Add("NO-TRANS");
                csNoTrans.BackColor = Color.Orange;

                CellStyle csNoPartno = grd02.Styles.Add("NO-PARTNO");
                csNoPartno.BackColor = Color.LightYellow;

                CellStyle csNormal = grd02.Styles.Add("NORMAL");
                csNormal.BackColor = Color.White;

                #region [그리드 Merge & 컬럼 설정]

                for (int i = 0; i < grd02.Cols.Count; i++)
                    this.grd02[1, i] = this.grd02.Cols[i].Caption;

                this.grd02.AddMerge(0, 1, "YMD", "YMD");
                this.grd02.AddMerge(0, 1, "BODY", "BODY");
                this.grd02.AddMerge(0, 1, "OBJECT_CNT", "OBJECT_CNT");
                this.grd02.AddMerge(0, 1, "CURRENT_CNT", "CURRENT_CNT");
                this.grd02.AddMerge(0, 1, "DIFF", "DIFF");

                this.grd02.AddMerge(0, 0, "BPFR_PARTNO", "BPFR_CNT");
                this.grd02.SetHeadTitle(0, "BPFR_PARTNO", "BUMPER FRONT");

                this.grd02.AddMerge(0, 0, "BPRR_PARTNO", "BPRR_CNT");
                this.grd02.SetHeadTitle(0, "BPRR_PARTNO", "BUMPER REAR");

                this.grd02.AddMerge(0, 0, "DTFL_PARTNO", "DTFL_CNT");
                this.grd02.SetHeadTitle(0, "DTFL_PARTNO", "DTRIM F/LH");

                this.grd02.AddMerge(0, 0, "DTFR_PARTNO", "DTFR_CNT");
                this.grd02.SetHeadTitle(0, "DTFR_PARTNO", "DTRIM F/RH");

                this.grd02.AddMerge(0, 0, "DTRL_PARTNO", "DTRL_CNT");
                this.grd02.SetHeadTitle(0, "DTRL_PARTNO", "DTRIM R/LH");

                this.grd02.AddMerge(0, 0, "DTRR_PARTNO", "DTRR_CNT");
                this.grd02.SetHeadTitle(0, "DTRR_PARTNO", "DTRIM R/RH");

                this.grd02.AddMerge(0, 1, "PWFL_PARTNO", "PWFL_PARTNO");
                this.grd02.AddMerge(0, 1, "PWFR_PARTNO", "PWFR_PARTNO");
                this.grd02.AddMerge(0, 1, "PWRL_PARTNO", "PWRL_PARTNO");
                this.grd02.AddMerge(0, 1, "PWRR_PARTNO", "PWRR_PARTNO");

                this.grd02.AddMerge(0, 1, "IHFL_PARTNO", "IHFL_PARTNO");
                this.grd02.AddMerge(0, 1, "IHFR_PARTNO", "IHFR_PARTNO");
                this.grd02.AddMerge(0, 1, "IHRL_PARTNO", "IHRL_PARTNO");
                this.grd02.AddMerge(0, 1, "IHRR_PARTNO", "IHRR_PARTNO");

                this.grd02.AddMerge(0, 1, "LPFL_PARTNO", "LPFL_PARTNO");
                this.grd02.AddMerge(0, 1, "LPFR_PARTNO", "LPFR_PARTNO");

                this.grd02.AddMerge(0, 1, "LPRL_PARTNO", "LPRL_PARTNO");
                this.grd02.AddMerge(0, 1, "LPRR_PARTNO", "LPRR_PARTNO");

                //this.grd02.AddMerge(0, 0, "PWFL_PARTNO", "PWFL_CNT");
                //this.grd02.SetHeadTitle(0, "PWFL_PARTNO", "PWDW F/LH");
                
                //this.grd02.AddMerge(0, 0, "PWFR_PARTNO", "PWFR_CNT");
                //this.grd02.SetHeadTitle(0, "PWFR_PARTNO", "PWDW F/RH");

                //this.grd02.AddMerge(0, 0, "PWRL_PARTNO", "PWRL_CNT");
                //this.grd02.SetHeadTitle(0, "PWRL_PARTNO", "PWDW R/LH");

                //this.grd02.AddMerge(0, 0, "PWRR_PARTNO", "PWRR_CNT");
                //this.grd02.SetHeadTitle(0, "PWRR_PARTNO", "PWDW R/RH");

                //this.grd02.AddMerge(0, 0, "IHFL_PARTNO", "IHFL_CNT");
                //this.grd02.SetHeadTitle(0, "IHFL_PARTNO", "IHDL F/LH");

                //this.grd02.AddMerge(0, 0, "IHFR_PARTNO", "IHFR_CNT");
                //this.grd02.SetHeadTitle(0, "IHFR_PARTNO", "IHDL F/LH");

                //this.grd02.AddMerge(0, 0, "IHRL_PARTNO", "IHRL_CNT");
                //this.grd02.SetHeadTitle(0, "IHRL_PARTNO", "IHDL R/LH");

                //this.grd02.AddMerge(0, 0, "IHRR_PARTNO", "IHRR_CNT");
                //this.grd02.SetHeadTitle(0, "IHRR_PARTNO", "IHDL R/RH");

                //this.grd02.AddMerge(0, 0, "LPFL_PARTNO", "LPFL_CNT");
                //this.grd02.SetHeadTitle(0, "LPFL_PARTNO", "LPDL F/LH");

                //this.grd02.AddMerge(0, 0, "LPFR_PARTNO", "LPFR_CNT");
                //this.grd02.SetHeadTitle(0, "LPFR_PARTNO", "LPDL F/LH");

                #endregion

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.dtp01_SDATE.SetValue(DateTime.Now);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ HMC LOT추적 ASCII ]
        //ASCII 코드
        const string EOT = "\x04";
        const string GS = "\x1D";
        const string RS = "\x1E";
        #endregion

        #region [ 사용자 정의 메서드 ]

        private string ParseBase64(string src)
        {
           

            System.Text.Encoding enc = System.Text.Encoding.Default;
            byte[] arr = Convert.FromBase64String(src);
            string ret = enc.GetString(arr);
            ret = ret.Replace(EOT, "<EOT>");
            ret = ret.Replace(GS, "<GS>");
            ret = ret.Replace(RS, "<RS>");
            return ret;
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("YMD", this.dtp01_SDATE.GetDateText().ToString().Replace("-",""));
                set.Add("CUSTCD", "KMI");
                set.Add("CUST_PLANT", "1");
                set.Add("CUST_LINE", "1");
                set.Add("VID", this.txt01_BODYNO.Text);

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");
                DataTable dt = source.Tables[0];

                this.grd02.SetValue(dt);

                this.AfterInvokeServer();

                string strStyle = "";

                for (int inx = 2; inx < grd02.Rows.Count; inx++)
                {
                     grd02.Rows[inx].StyleNew.Clear();

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "BPFR_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["BPFR_PARTNO"].Index, strStyle);
                     grd02.SetCellStyle(inx, grd02.Cols["BPFR_ALCCD"].Index, strStyle);
                     grd02.Cols[grd02.Cols["BPFR_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;
                     grd02.Cols[grd02.Cols["BPFR_ALCCD"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "BPRR_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["BPRR_PARTNO"].Index, strStyle);
                     grd02.SetCellStyle(inx, grd02.Cols["BPRR_ALCCD"].Index, strStyle);
                     grd02.Cols[grd02.Cols["BPRR_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;
                     grd02.Cols[grd02.Cols["BPRR_ALCCD"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "DTFL_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["DTFL_PARTNO"].Index, strStyle);
                     grd02.SetCellStyle(inx, grd02.Cols["DTFL_ALCCD"].Index, strStyle);
                     grd02.Cols[grd02.Cols["DTFL_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;
                     grd02.Cols[grd02.Cols["DTFL_ALCCD"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "DTFR_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["DTFR_PARTNO"].Index, strStyle);
                     grd02.SetCellStyle(inx, grd02.Cols["DTFR_ALCCD"].Index, strStyle);
                     grd02.Cols[grd02.Cols["DTFR_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;
                     grd02.Cols[grd02.Cols["DTFR_ALCCD"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "DTRL_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["DTRL_PARTNO"].Index, strStyle);
                     grd02.SetCellStyle(inx, grd02.Cols["DTRL_ALCCD"].Index, strStyle);
                     grd02.Cols[grd02.Cols["DTRL_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;
                     grd02.Cols[grd02.Cols["DTRL_ALCCD"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "DTRR_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["DTRR_PARTNO"].Index, strStyle);
                     grd02.SetCellStyle(inx, grd02.Cols["DTRR_ALCCD"].Index, strStyle);
                     grd02.Cols[grd02.Cols["DTRR_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;
                     grd02.Cols[grd02.Cols["DTRR_ALCCD"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "PWFL_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["PWFL_PARTNO"].Index, strStyle);
                     grd02.Cols[grd02.Cols["PWFL_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "PWFR_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["PWFR_PARTNO"].Index, strStyle);
                     grd02.Cols[grd02.Cols["PWFR_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "PWRL_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["PWRL_PARTNO"].Index, strStyle);
                     grd02.Cols[grd02.Cols["PWRL_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "PWRR_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["PWRR_PARTNO"].Index, strStyle);
                     grd02.Cols[grd02.Cols["PWRR_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "IHFL_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["IHFL_PARTNO"].Index, strStyle);
                     grd02.Cols[grd02.Cols["IHFL_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "IHFR_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["IHFR_PARTNO"].Index, strStyle);
                     grd02.Cols[grd02.Cols["IHFR_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "IHRL_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["IHRL_PARTNO"].Index, strStyle);
                     grd02.Cols[grd02.Cols["IHRL_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "IHRR_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["IHRR_PARTNO"].Index, strStyle);
                     grd02.Cols[grd02.Cols["IHRR_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "LPFL_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["LPFL_PARTNO"].Index, strStyle);
                     grd02.Cols[grd02.Cols["LPFL_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "LPFR_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["LPFR_PARTNO"].Index, strStyle);
                     grd02.Cols[grd02.Cols["LPFR_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "LPRL_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["LPRL_PARTNO"].Index, strStyle);
                     grd02.Cols[grd02.Cols["LPRL_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;

                     strStyle = GetGridColStyle(grd02.GetValue(inx, "LPRR_CNT").ToString());
                     grd02.SetCellStyle(inx, grd02.Cols["LPRR_PARTNO"].Index, strStyle);
                     grd02.Cols[grd02.Cols["LPRR_PARTNO"].Index].TextAlign = TextAlignEnum.LeftCenter;

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

        private void grd02_DoubleClick(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region [ 함수 정의 ]

        private string GetGridColStyle(string strStatus)
        {
            if (strStatus == "X")
            {
                return "NO-PARTNO";
            }
            else if (strStatus == "N")
            {
                return "NO-TRANS";
            }
            else
            {
                return "NORMAL";
            }
        }

        #endregion

        private void axButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                if (MsgBox.Show("Do you want to process for omission data?(" + this.dtp01_SDATE.GetDateText().ToString() + ")", "Question", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    /*
                     IN_CORCD VARCHAR2,
    IN_BIZCD VARCHAR2,
    IN_YMD VARCHAR2,
    IN_CUSTCD IN VARCHAR2,
    IN_CUST_PLANT IN VARCHAR2,
    IN_CUST_LINE IN VARCHAR2
                     */
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", bizcd);
                    set.Add("YMD", this.dtp01_SDATE.GetDateText().ToString().Replace("-", ""));
                    set.Add("CUSTCD", "KMI");
                    set.Add("CUST_PLANT", "1");
                    set.Add("CUST_LINE", "1");
                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.INQUERY(bizcd, set);
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_OM_LOTT_PROCESS_START"), set);
                    BtnQuery_Click(null, null);
                }
            }catch(Exception eLog)
            {
                this.AfterInvokeServer();
                MsgBox.Show(eLog.ToString());
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }
    }
}
