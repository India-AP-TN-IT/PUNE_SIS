#region ▶ Description & History
/* 
 * 프로그램명 : 출하 실적 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2014-07-23      배명희     cdx01_LINECD 연결 팝업 변경 (CM20020P1 -> CM30030P1)
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
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

using System.Drawing;
using C1.Win.C1FlexGrid;


//using TheOne.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>
    /// - 작 성 자 : 이태호<br />
    /// - 작 성 일 : 2010-07-09 오전 8:55:56<br />
    /// - 주요 변경 사항
    ///     1) 2010-07-09 오전 8:55:56   이태호 : 최초 클래스 생성<br />
    ///     2) 2010-09-29 정명국 : 출하실적 저장시 MERGE INTO 방식으로 변경 및 누락 필드 처리<br/>
    ///                            조회시 라인코드 추가 및 입력값 확인 로직 추가<br/>
    ///                            POP실적 반영 적용<br/>
    /// </summary>
    public partial class PD22210 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD22210";

        public PD22210()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
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

                this.grd01.Initialize(2, 2);
                this.grd01.CurrentContextMenu.Items[0].Visible = false;
                this.grd01.CurrentContextMenu.Items[1].Visible = false;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "위치", "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 50, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "PART NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 60, "저장\n공간", "DELI_STR_LOC", "STR_LOC_LINE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 30, "출고일자", "DELI_DATE", "OUT_DATE");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "계획합", "PLAN_SUM", "PLAN_SUM"); //계획합 컬럼 추가
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "실적합", "RSLT_SUM", "RSLT_SUM"); //실적합 컬럼 추가

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "P-1", "P01");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "R-1", "R01");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "조정1", "A01");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "P-2", "P02");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "R-2", "R02");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "조정2", "A02");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "P-3", "P03");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "R-3", "R03");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "조정3", "A03");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "P-4", "P04");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "R-4", "R04");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 40, "조정4", "A04");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "P-5", "P05");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "R-5", "R05");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "조정5", "A05");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "P-6", "P06");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "R-6", "R06");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "조정6", "A06");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "P-7", "P07");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "R-7", "R07");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "조정7", "A07");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "P-8", "P08");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "R-8", "R08");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "조정8", "A08");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "P-9", "P09");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 30, "R-9", "R09");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "조정9", "A09");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "P-10", "P10");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "R-10", "R10");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "조정10", "A10");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "1차", "QTY01", "QTY01");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "2차", "QTY02", "QTY02");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "3차", "QTY03", "QTY03");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "4차", "QTY04", "QTY04");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "5차", "QTY05", "QTY05");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "6차", "QTY06", "QTY06");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "7차", "QTY07", "QTY07");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "8차", "QTY08", "QTY08");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "9차", "QTY09", "QTY09");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "10차", "QTY10", "QTY10");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 30, "TOT_QTY01", "TOT_QTY01");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 30, "TOT_QTY02", "TOT_QTY02");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 30, "TOT_QTY03", "TOT_QTY03");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 30, "TOT_QTY04", "TOT_QTY04");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 30, "TOT_QTY05", "TOT_QTY05");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 30, "TOT_QTY06", "TOT_QTY06");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 30, "TOT_QTY07", "TOT_QTY07");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 30, "TOT_QTY08", "TOT_QTY08");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 30, "TOT_QTY09", "TOT_QTY09");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 30, "TOT_QTY10", "TOT_QTY10");

                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("BIZCD");
                this.grd01.AddHiddenColumn("LINECD");
                this.grd01.AddHiddenColumn("STD_DATE");
                this.grd01.AddHiddenColumn("DELI_DATE");
                this.grd01.AddHiddenColumn("JOB_TYPE");
                this.grd01.AddHiddenColumn("DELI_STR_LOC");
                this.grd01.AddHiddenColumn("INV_STATUS");

                this.grd01.Cols["PLAN_SUM"].Format = "#,###,###,###,###,###,###";
                this.grd01.Cols["RSLT_SUM"].Format = "#,###,###,###,###,###,###";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PLAN_SUM"); //계획합
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RSLT_SUM"); //실적합

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "P01");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "R01");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "A01");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "P02");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "R02");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "A02");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "P03");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "R03");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "A03");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "P04");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "R04");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "A04");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "P05");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "R05");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "A05");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "P06");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "R06");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "A06");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "P07");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "R07");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "A07");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "P08");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "R08");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "A08");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "P09");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "R09");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "A09");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "P10");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "R10");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "A10");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY01");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY02");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY03");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY04");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY05");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY06");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY07");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY08");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY09");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "QTY10");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_QTY01");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_QTY02");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_QTY03");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_QTY04");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_QTY05");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_QTY06");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_QTY07");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_QTY08");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_QTY09");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "TOT_QTY10");
                

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(); // frm;
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0A");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dtp01_STD_DATE.GetDateText());
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                CellStyle cs;
                cs = this.grd01.Styles.Add("csTotal");   //총계행 기본 스타일(보라색)
                cs.BackColor = Color.FromArgb(204, 204, 255);
                cs.ForeColor = Color.Black;

                cs = this.grd01.Styles.Add("csSubtotal0");  //0레벨 소계행 [계] 컬럼 스타일(보라색 배경)
                cs.BackColor = Color.FromArgb(245, 222, 179);
                cs.ForeColor = Color.Black;


                for (int i = 0; i < grd01.Cols.Count; i++)
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;

                for (int i = 3; i < grd01.Cols.Count - 1; i++)
                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, grd01.Cols[i].Name);

                this.grd01.AddMerge(0, 1, "INSTALL_POS", "INSTALL_POS");
                this.grd01.AddMerge(0, 1, "ALCCD", "ALCCD");
                this.grd01.AddMerge(0, 1, "PARTNO", "PARTNO");
                this.grd01.AddMerge(0, 1, "DELI_STR_LOC", "DELI_STR_LOC");

                this.grd01.AddMerge(0, 1, "PLAN_SUM", "PLAN_SUM");//계획합
                this.grd01.AddMerge(0, 1, "RSLT_SUM", "RSLT_SUM");//실적합

                for (int i = 1; i <= 10; i++)
                {
                    this.grd01.AddMerge(0, 1, "P" + i.ToString("00"), "P" + i.ToString("00"));
                    this.grd01.AddMerge(0, 1, "R" + i.ToString("00"), "R" + i.ToString("00"));
                    this.grd01.AddMerge(0, 1, "A" + i.ToString("00"), "A" + i.ToString("00"));
                }

                this.grd01.AddMerge(0, 0, "QTY01", "QTY10");
                this.grd01.SetHeadTitle(0, "QTY01", this.GetLabel("SHIP_PLAN_RSLT"));

                this.grd01.SetHeadTitle(0, "A01", this.GetLabel("ADJ") + "1");
                this.grd01.SetHeadTitle(0, "A02", this.GetLabel("ADJ") + "2");
                this.grd01.SetHeadTitle(0, "A03", this.GetLabel("ADJ") + "3");
                this.grd01.SetHeadTitle(0, "A04", this.GetLabel("ADJ") + "4");
                this.grd01.SetHeadTitle(0, "A05", this.GetLabel("ADJ") + "5");
                this.grd01.SetHeadTitle(0, "A06", this.GetLabel("ADJ") + "6");
                this.grd01.SetHeadTitle(0, "A07", this.GetLabel("ADJ") + "7");
                this.grd01.SetHeadTitle(0, "A08", this.GetLabel("ADJ") + "8");
                this.grd01.SetHeadTitle(0, "A09", this.GetLabel("ADJ") + "9");
                this.grd01.SetHeadTitle(0, "A10", this.GetLabel("ADJ") + "10");
                

                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_STD_DATE, this.lbl01_LINE);
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


                DataSet set = this.GetDataSourceSchema("CORCD", "BIZCD", "STD_DATE", "DELI_DATE", "SHIP_CNT", "PARTNO", "JOB_TYPE",
                                "DELI_STR_LOC", "INV_STATUS", "SHIP_PLAN_QTY", "SHIP_RSLT_QTY", "CHNG_QTY", "LINECD", "ALCCD");
                DataRow addrow = null;
                DataRow tmprow = null;

                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    tmprow = ((DataRowView)this.grd01.Rows[i].DataSource).Row;

                    //if (tmprow.RowState == DataRowState.Modified)
                    //{
                    for (int j = 1; j <= 10; j++)
                    {
                        //if (!tmprow["R" + j.ToString("00"), DataRowVersion.Original].Equals(tmprow["R" + j.ToString("00"), DataRowVersion.Current]))
                        //{
                        addrow = set.Tables[0].NewRow();
                        addrow["CORCD"] = tmprow["CORCD"];
                        addrow["BIZCD"] = tmprow["BIZCD"];
                        addrow["STD_DATE"] = tmprow["STD_DATE"];
                        addrow["DELI_DATE"] = tmprow["STD_DATE"];
                        addrow["SHIP_CNT"] = j;
                        addrow["PARTNO"] = tmprow["PARTNO"];
                        addrow["JOB_TYPE"] = tmprow["JOB_TYPE"];
                        addrow["DELI_STR_LOC"] = tmprow["DELI_STR_LOC"];
                        addrow["INV_STATUS"] = "" ;
                        addrow["SHIP_PLAN_QTY"] = tmprow["P" + j.ToString("00")];
                        addrow["SHIP_RSLT_QTY"] = tmprow["R" + j.ToString("00")];
                        addrow["CHNG_QTY"] = tmprow["A" + j.ToString("00")];
                        addrow["LINECD"] = tmprow["LINECD"];
                        addrow["ALCCD"] = tmprow["ALCCD"];
                        set.Tables[0].Rows.Add(addrow);
                        //}
                    }
                    //}
                }

                if (!IsSaveValid(set)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(set);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), set);
                this.AfterInvokeServer();
                this.BtnQuery_Click(null, null);
                //MsgBox.Show("정상적으로 출하실적이 저장되었습니다.");
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

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());
                paramSet.Add("STD_DATE", this.dtp01_STD_DATE.GetDateText());

                if (!IsQueryValid(paramSet)) return;

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(paramSet);
                using (AxClientProxy proxy = new AxClientProxy())
                {

                    DataSet source = proxy.ExecuteDataSet("APG_PD22210.INQUERY", paramSet);
                    this.grd01.SetValue(source.Tables[0]);
                    ShowDataCount(source);
                }

                for (int i = this.grd01.Cols["TOT_QTY01"].Index; i <= this.grd01.Cols["TOT_QTY10"].Index; i++)
                {
                    string strCols = "QTY" + this.grd01.Cols[i].Name.Substring(7, 2);

                    if (this.grd01.Rows.Fixed < this.grd01.Rows.Count)
                    {
                        if (Convert.ToDecimal(this.grd01.Rows[this.grd01.Rows.Fixed][i].ToString()) > 0)
                            this.grd01.GetCellRange(this.grd01.Rows.Fixed - 1, this.grd01.Cols[strCols].Index).StyleNew.BackColor = Color.OrangeRed;
                        else
                            this.grd01.GetCellRange(this.grd01.Rows.Fixed - 1, this.grd01.Cols[strCols].Index).StyleNew.BackColor = Color.LightGreen;
                    }
                    else
                        this.grd01.GetCellRange(this.grd01.Rows.Fixed - 1, this.grd01.Cols[strCols].Index).StyleNew.BackColor = Color.FromArgb(240, 240, 240);
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.BeforeInvokeServer(true);
                dtp01_STD_DATE.SetValue(DateTime.Now.Date);

                this.cdx01_LINECD.SetValue("");
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());

                DataTable clear = new DataTable();
                this.grd01.SetValue(clear);

                for (int i = this.grd01.Cols["QTY01"].Index; i <= this.grd01.Cols["QTY10"].Index; i++)
                {
                    this.grd01.GetCellRange(this.grd01.Rows.Fixed - 1, i).StyleNew.BackColor = Color.FromArgb(240, 240, 240);
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

        #region [ 유효성 검사 ]
        private bool IsSaveValid(DataSet set)
        {
            //if (MsgBox.Show("입력하신 출하실적을 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }

        private bool IsQueryValid(HEParameterSet paramSet)
        {
            if (paramSet["LINECD"].ToString().Trim().Length == 0)
            {
                //MsgBox.Show("라인을 선택해주세요!");
                MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("LINECD"));
                return false;
            }
            return true;
        }
        #endregion


        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cdx01_LINECD.SetValue("");
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
        }
    }
}
