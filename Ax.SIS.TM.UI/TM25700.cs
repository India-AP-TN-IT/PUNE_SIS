#region ▶ Description & History
/* 
 * 프로그램명 : PD40520 금형투입이력 조회
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
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;

namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class TM25700 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _DB;

        #region [ 초기화 작업 정의 ]

        public TM25700()
        {
            InitializeComponent();

            _DB = new AxClientProxy();
            
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //CORCD
                cbo01_CORCD.DataBind_CORCD();
                cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                cbo01_CORCD.SetReadOnly(true);
                //BIZCD
                cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;

                this.cdx01_DOCCD.HEPopupHelper = new Ax.SIS.TM.UI.TM20500_DLG("DOCCD", "Doc No.", "Doc Name", "", "");
                this.cdx01_DOCCD.PopupTitle = "Document";
                this.cdx01_DOCCD.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                this.cdx01_DOCCD.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                this.cdx01_DOCCD.CodeParameterName = "CD";
                this.cdx01_DOCCD.NameParameterName = "NM";
                this.cdx01_DOCCD.HEPopupHelper.Initialize_Helper(cdx01_DOCCD);



                this.cdx_LOCCD.HEPopupHelper = new Ax.SIS.TM.UI.TM20500_DLG("LOCCD", "Location No.", "Location Name", "", "");
                this.cdx_LOCCD.PopupTitle = "Location";
                this.cdx_LOCCD.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                this.cdx_LOCCD.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                this.cdx_LOCCD.CodeParameterName = "CD";
                this.cdx_LOCCD.NameParameterName = "NM";
                this.cdx_LOCCD.HEPopupHelper.Initialize_Helper(cdx_LOCCD);

                


                this.cdx_GRPCD.HEPopupHelper = new Ax.SIS.TM.UI.TM20500_DLG("GRPCD", "GROUP No.", "GROUP Name", "", "");
                this.cdx_GRPCD.PopupTitle = "Group";
                this.cdx_GRPCD.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                this.cdx_GRPCD.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                this.cdx_GRPCD.CodeParameterName = "CD";
                this.cdx_GRPCD.NameParameterName = "NM";
                this.cdx_GRPCD.HEPopupHelper.Initialize_Helper(cdx_GRPCD);

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "C/DATE", "CHK_DATE_CVT", "CHK_DATE_CVT");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "DOCUMENT", "DOCNM", "DOCNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "LOCATION", "LOCNM", "LOCNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "GROUP", "GRPNM", "GRPNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "COUNT", "CNT", "CNT");
                
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "C/CHK_DATE", "CHK_DATE", "CHK_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "PUBCD", "PUBCD", "PUBCD");
                

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CORCD", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "C/COUNT", "CHK_SEQ", "CHK_SEQ");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "C/TIME", "CHK_TIME", "CHK_TIME");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "C/CD", "CHKCD", "CHKCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "C/DESC", "CHKNM", "CHKNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "METHOD", "METHOD", "METHOD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "VALUE", "VAL", "VAL");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "WHO", "WHO", "WHO");  


                this.grd03.AllowEditing = false;
                this.grd03.Initialize();
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CORCD", "CORCD", "CORCD");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "BIZCD", "BIZCD", "BIZCD");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "DOCUMENT", "DOCNM", "DOCNM");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "LOCATION", "LOCNM", "LOCNM");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "GROUP", "GRPNM", "GRPNM");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "C/CHK_DATE", "CHK_DATE", "CHK_DATE");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "PUBCD", "PUBCD", "PUBCD");

                this.grd04.AllowEditing = false;
                this.grd04.Initialize();
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "C/CD", "CHKCD", "CHKCD");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "C/DESC", "CHKNM", "CHKNM");
                this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "METHOD", "METHOD", "METHOD");


                for (int col = 0; col < 31; col++)
                {
                    string d = col.ToString().PadLeft(2, '0');
                    this.grd04.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 49, "D" + d, "D" + d, "D" + d);
                }
                
                
                
                
                
                

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]
        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            base.BtnPrint_Click(sender, e);

            try
            {
                if(tabControl1.SelectedIndex ==1)
                {   //Month
                    int row = grd03.Row;
                    int col = grd03.Col;
                    if (row < this.grd03.Rows.Fixed) return;
                    HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                    //report.ReportName = "RxRpt/ZSD02500_Temp";
                    report.ReportName = "RPT/TM25700_MON2";

                    HEParameterSet param = new HEParameterSet();

                    param.Add("CORCD", cbo01_CORCD.GetValue());
                    param.Add("BIZCD", cbo01_BIZCD.GetValue());
                    param.Add("PUBCD", grd03.GetValue(row, "PUBCD"));
                    param.Add("DATE", grd03.GetValue(row, "CHK_DATE"));
                    DataSet ds = _DB.ExecuteDataSet("APG_TM25700.GET_PRT_HIST_DET_MON", param);
                   //ds.WriteXml(@"D:\A\a.xml",XmlWriteMode.WriteSchema);

                    ds.Tables[0].TableName = "DATA";
                    HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());
                    report.Sections.Add("MAIN", xmlSection);

                    AxRexpertReportViewer.ShowReport(report);

                    ds.Clear();
                    
                }
                if (tabControl1.SelectedIndex == 0)
                {   //DAILY
                    int row = grd01.Row;
                    int col = grd01.Col;
                    if (row < this.grd01.Rows.Fixed) return;
                    HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                    //report.ReportName = "RxRpt/ZSD02500_Temp";
                    report.ReportName = "RPT/TM25700_Dailychk";
                    DateTime RTime = Convert.ToDateTime(grd01.GetValue(row, "CHK_DATE"));
                    string date = RTime.ToString("yyyy-MM-dd");
                    //MessageBox.Show(date);
                    HEParameterSet param = new HEParameterSet();

                    param.Add("CORCD", cbo01_CORCD.GetValue());
                    param.Add("BIZCD", cbo01_BIZCD.GetValue());
                    param.Add("PUBCD", grd01.GetValue(row, "PUBCD"));
                    param.Add("DATE", date);
                    DataSet ds = _DB.ExecuteDataSet("APG_TM25700.GET_PRT_HIST_DET_DLY", param);
                   // MessageBox.Show("test");
                
                    //ds.WriteXml(@"D:\A\a.xml",XmlWriteMode.WriteSchema);

                    ds.Tables[0].TableName = "DATA";
                    HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());
                    report.Sections.Add("MAIN", xmlSection);

                    AxRexpertReportViewer.ShowReport(report);

                    ds.Clear();

                }
            }
            catch (Exception eLog)
            {
                MessageBox.Show(eLog.Message); 
            }
        }
        
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                

                if (tabControl1.SelectedIndex == 0)
                {
                    HEParameterSet param = new HEParameterSet();

                    param.Add("CORCD", cbo01_CORCD.GetValue());
                    param.Add("BIZCD", cbo01_BIZCD.GetValue());
                    param.Add("DOCCD", cdx01_DOCCD.GetValue());
                    param.Add("LOCCD", cdx_LOCCD.GetValue());
                    param.Add("GRPCD", cdx_GRPCD.GetValue());
                    param.Add("ST_DATE", axDateEdit1.GetDateText());
                    param.Add("ED_DATE", axDateEdit2.GetDateText());
                    DataSet ds = _DB.ExecuteDataSet("APG_TM25700.GET_HIST_HEADER", param);
                    grd01.SetValue(ds);
                }
                else if(tabControl1.SelectedIndex == 1)
                {
                    HEParameterSet param = new HEParameterSet();

                    param.Add("CORCD", cbo01_CORCD.GetValue());
                    param.Add("BIZCD", cbo01_BIZCD.GetValue());
                    param.Add("DOCCD", cdx01_DOCCD.GetValue());
                    param.Add("LOCCD", cdx_LOCCD.GetValue());
                    param.Add("GRPCD", cdx_GRPCD.GetValue());
                    param.Add("DATE", axDateEdit3.GetDateText());
                    DataSet ds = _DB.ExecuteDataSet("APG_TM25700.GET_HIST_HEADER_MON", param);
                    grd03.SetValue(ds);
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
               
            }
            finally
            {
            }
        }
        
        #endregion

        private void DispDetDaily(string corcd, string bizcd, string pubcd, string date)
        {
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", corcd);
            paramSet.Add("BIZCD", bizcd);
            paramSet.Add("PUBCD", pubcd);
            paramSet.Add("DATE", date);
            DataSet ds = _DB.ExecuteDataSet("APG_TM25700.GET_HIST_DET", paramSet, "OUT_CURSOR");
            grd02.SetValue(ds);
        }

        private void DispDetMon(string corcd, string bizcd, string pubcd, string date)
        {
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", corcd);
            paramSet.Add("BIZCD", bizcd);
            paramSet.Add("PUBCD", pubcd);
            paramSet.Add("DATE", date);
            DataSet ds = _DB.ExecuteDataSet("APG_TM25700.GET_HIST_DET_MON", paramSet, "OUT_CURSOR");
            grd04.SetValue(ds);
        }
       
        
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = grd01.Row;
            int col = grd01.Col;
            if (row < this.grd01.Rows.Fixed) return;
            string corcd = grd01.GetValue(row, "CORCD").ToString();
            string bizcd = grd01.GetValue(row, "BIZCD").ToString();
            string pubcd = grd01.GetValue(row, "PUBCD").ToString();
            string date = grd01.GetValue(row, "CHK_DATE").ToString();
            DispDetDaily(corcd, bizcd, pubcd, date);
            
        }

        private void grd03_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = grd03.Row;
            int col = grd03.Col;
            if (row < this.grd03.Rows.Fixed) return;
            string corcd = grd03.GetValue(row, "CORCD").ToString();
            string bizcd = grd03.GetValue(row, "BIZCD").ToString();
            string pubcd = grd03.GetValue(row, "PUBCD").ToString();
            string date = grd03.GetValue(row, "CHK_DATE").ToString();
            DispDetMon(corcd, bizcd, pubcd, date);
        }






    }
}

