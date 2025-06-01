
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
    /// <b>일/월별 검수단가 현황</b>
    /// - 작 성 자 : 장상휘<br />
    /// - 작 성 일 : 2010-06-01 오후 1:34:13<br />
    /// </summary>
    public partial class PD30250 : AxCommonBaseControl
    {
        //private ISD30230 _WSCOM;        
        private AxClientProxy _WSCOM_N;
        
        public PD30250()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
            //_WSCOM  = ClientFactory.CreateChannel<ISD30230>("SD02", "SD30230.svc", "CustomBinding");
            
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody  = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;
                
                #region -- 콤보 상자 설정 --
                                
                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_JOB_TYPE.DataBind("A1");                
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                
                #endregion

                #region [그리드1]

                this.grd01.AllowEditing = false;                
                this.grd01.Initialize();
                this.grd01.AllowEditing = true;
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 030, "선택", "CHK", "CHK");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "계획일자", "PLAN_DATE", "PLAN_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "납기일자", "DELI_DATE", "DELI_DATE03");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "작업지시번호", "WORK_ORDNO", "WORK_ORDNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "판매오더번호", "ORDNO", "ORDNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "순번", "SEQNO", "SEQ_NO");
                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "작업유형", "JOB_TYPENM", "JOBTYPETITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "품번", "PARTNO", "PARTNO3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 260, "품명", "PARTNM", "PARTNONM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "계획수량", "PLAN_QTY", "PLAN_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "납품수량", "RSLT_QTY", "RSLT_QTY");

                this.grd01.AddHiddenColumn("JOB_TYPE");
                this.grd01.AddHiddenColumn("BARCODE");
                //this.grd01.AddHiddenColumn("VINCD");

                this.grd01.Cols["PLAN_QTY"].Format = "###,###,###,###,###,##0";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PLAN_QTY");
                this.grd01.Cols["RSLT_QTY"].Format = "###,###,###,###,###,###";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "RSLT_QTY");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");
                #endregion

                this.dte01_BIZ_PLAN_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
                this.dte01_BIZ_PLAN_EDATE.SetMMFromEnd();

                this.dte01_DELI_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
                this.dte01_DELI_EDATE.SetMMFromEnd();

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(); //new PM20015P1();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                //this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dte01_STD_DATE.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", this.UserInfo.PlantDiv); //2013.03.20 공장구분 추가(배명희)   
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = new DataSet();
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());
                paramSet.Add("PLAN_SDATE", this.dte01_BIZ_PLAN_SDATE.GetDateText());
                paramSet.Add("PLAN_EDATE", this.dte01_BIZ_PLAN_EDATE.GetDateText());
                paramSet.Add("DELI_SDATE", this.dte01_DELI_SDATE.GetDateText());
                paramSet.Add("DELI_EDATE", this.dte01_DELI_EDATE.GetDateText());
                paramSet.Add("ORDNO", this.txt01_ORDNO.GetValue());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                paramSet.Add("JOB_TYPE", this.cbo01_JOB_TYPE.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                
                this.BeforeInvokeServer(true);
                source = _WSCOM_N.ExecuteDataSet("APG_PD30250.INQUERY", paramSet);
                this.grd01.SetValue(source.Tables[0]);
                this.AfterInvokeServer();
                   
                   
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
            try
            {

                DataSet source = AxFlexGrid.GetDataSourceSchema("PLAN_DATE", "WORK_ORDNO", "ORDNO", "SEQNO",
                                                                "JOB_TYPE", "JOB_TYPENM", "PARTNO", "PARTNM",
                                                                "PLAN_QTY", "RSLT_QTY", "BARCODE", "LINECD");
                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    string chk = this.grd01.GetValue(i, "CHK").ToString();
                    if (chk != "Y") continue;

                    source.Tables[0].Rows.Add(this.grd01.GetValue(i, "PLAN_DATE"),
                                              this.grd01.GetValue(i, "WORK_ORDNO"),
                                              this.grd01.GetValue(i, "ORDNO"),
                                              this.grd01.GetValue(i, "SEQNO"),
                                              this.grd01.GetValue(i, "JOB_TYPE"),
                                              this.grd01.GetValue(i, "JOB_TYPENM"),
                                              this.grd01.GetValue(i, "PARTNO"),
                                              this.grd01.GetValue(i, "PARTNM"),
                                              this.grd01.GetValue(i, "PLAN_QTY"),
                                              this.grd01.GetValue(i, "RSLT_QTY"),
                                              this.grd01.GetValue(i, "BARCODE"),
                                              this.grd01.GetValue(i, "LINECD"));

                    //source.Tables[0].Rows.Add(this.grd01.GetValue(i, "ORD_DATE"),
                    //                          this.grd01.GetValue(i, "PLAN_DATE"),
                    //                          this.grd01.GetValue(i, "ORDNO"),
                    //                          this.grd01.GetValue(i, "SEQNO"),
                    //                          this.grd01.GetValue(i, "JOB_TYPE"),
                    //                          this.grd01.GetValue(i, "JOB_TYPENM"),
                    //                          this.grd01.GetValue(i, "PARTNO"),
                    //                          this.grd01.GetValue(i, "PARTNM"),
                    //                          this.grd01.GetValue(i, "ORD_QTY"),
                    //                          this.grd01.GetValue(i, "RSLT_QTY"),
                    //                          this.grd01.GetValue(i, "BARCODE"),
                    //                          this.grd01.GetValue(i, "LINECD"));
                }

                if (!IsPrintValid(source))
                    return;


                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);

                report.ReportName = "RxRpt/PD30250";

                HERexSection mainSection = new HERexSection();
                mainSection.ReportParameter.Add("BIZ", this.UserInfo.BusinessCode);
                mainSection.ReportParameter.Add("EMPNO", this.UserInfo.EmpNo);
                mainSection.ReportParameter.Add("EMPNAME", this.UserInfo.UserName);
                report.Sections.Add("MAIN", mainSection);
                HERexSection xmlSection = new HERexSection(source, new HEParameterSet());
                report.Sections.Add("XML1", xmlSection);
                AxRexpertReportViewer.ShowReport(report);

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
        #region [ 유효성 체크 정의 ]

        private bool IsPrintValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count <= 0)
                {
                    //출력할 대상 Data가 없습니다.
                    MsgCodeBox.Show("COM-00022");
                    return false;
                }


                //출력 하시겠습니까?
                if (MsgCodeBox.Show("CD00-0085", MessageBoxButtons.OKCancel) != DialogResult.OK)
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



        #endregion
    }
}
