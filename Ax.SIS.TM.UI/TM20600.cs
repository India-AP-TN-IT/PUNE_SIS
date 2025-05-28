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
    public partial class TM20600 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _DB;

        #region [ 초기화 작업 정의 ]

        public TM20600()
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

                this.grd01.AllowEditing = true;
                this.grd01.Initialize(2, 2);    // 2 Header Rows
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "P/CODE", "PUBCD", "PUBCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "ID", "DOCCD", "DOCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "DESC", "DOCNM", "DOCNM");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "ID", "LOCCD", "LOCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "DESC", "LOCNM", "LOCNM");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "ID", "GRPCD", "GRPCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "DESC", "GRPNM", "GRPNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "COMMENT", "COMM", "COMM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "URL", "URL", "URL");
                
                //<<Merge Grid Head
                for (int i = 0; i < grd01.Cols.Count; i++)
                {
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;
                }
                this.grd01.AddMerge(0, 1, "PUBCD", "PUBCD");
                this.grd01.AddMerge(0, 1, "URL", "URL");
                this.grd01.AddMerge(0, 1, "COMM", "COMM");
                this.grd01.AddMerge(0, 0, "DOCCD", "DOCNM");
                this.grd01.SetHeadTitle(0, "DOCCD", "Document");

                this.grd01.AddMerge(0, 0, "LOCCD", "LOCNM");
                this.grd01.SetHeadTitle(0, "LOCCD", "Location");

                this.grd01.AddMerge(0, 0, "GRPCD", "GRPNM");
                this.grd01.SetHeadTitle(0, "GRPCD", "Group");
                //>>

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "DOCCD", "LOCCD", "GRPCD","COMM","URL","UPDATE_ID","PUBCD");

                DataSet ds_del = grd01.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD", "DOCCD", "LOCCD", "GRPCD", "PUBCD");
                if (ds_del.Tables.Count > 0 && ds_del.Tables[0].Rows.Count > 0)
                {
                    _DB.ExecuteNonQueryTx("APG_TM20600.DEL_DATA", ds_del);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                    {
                        ds.Tables[0].Rows[row]["CORCD"] = cbo01_CORCD.GetValue().ToString();
                        ds.Tables[0].Rows[row]["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                        ds.Tables[0].Rows[row]["UPDATE_ID"] = UserInfo.UserID;
                    }
                    _DB.ExecuteNonQueryTx("APG_TM20600.SAVE", ds);

                }
                BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
               
            }
        }
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                HEParameterSet param = new HEParameterSet();

                param.Add("CORCD", cbo01_CORCD.GetValue());
                param.Add("BIZCD", cbo01_BIZCD.GetValue());
                param.Add("DOCCD", cdx01_DOCCD.GetValue());
                param.Add("LOCCD", cdx_LOCCD.GetValue());
                param.Add("GRPCD", cdx_GRPCD.GetValue());
                DataSet ds = _DB.ExecuteDataSet("APG_TM20600.INQUERY", param);

                grd01.SetValue(ds);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
            }
        }
        
        #endregion
        private void DlgCodeHelp(string colName, int row, string findStr)
        {
            
            HEParameterSet paramSet = new HEParameterSet();
            DataTable dt = new DataTable();


            paramSet = new HEParameterSet();
            paramSet.Add("CORCD", cbo01_CORCD.GetValue());
            paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
            paramSet.Add("TY", colName);
            paramSet.Add("CD", findStr);
            paramSet.Add("NM", "");
            dt = _DB.ExecuteDataSet("APG_TM20500.INQUERY_DLG", paramSet, "OUT_CURSOR").Tables[0];

            string cdTitle = "";
            string nmTitle = "";
            string nm = "";
            string popupTitle = "";
            switch(colName)
            {
                case "DOCCD":
                    popupTitle = "Document";
                    nmTitle = "Doc Name";
                    cdTitle = "Doc NO.";
                    nm = "DOCNM";
                    break;
                case "LOCCD":
                    popupTitle = "Location";
                    nmTitle = "Location Name";
                    cdTitle = "Location NO.";
                    nm = "LOCNM";
                    break;
                case "GRPCD":
                    popupTitle = "Group";
                    nmTitle = "G/Name";
                    cdTitle = "G/NO.";
                    nm = "GRPNM";
                    break;
            }
            if (string.IsNullOrEmpty(findStr))
            {
                grd01.SetValue(row, 0, "U");
                grd01.SetValue(row, colName, "");
                grd01.SetValue(row, nm, "");
            }
            if (dt.Rows.Count > 1)
            {
                PopupHelper helper = null;
                TM20500_DLG dlg = new TM20500_DLG(colName, cdTitle, nmTitle, findStr, "");

                
                dlg.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                dlg.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());

                helper = new PopupHelper(dlg, popupTitle);
                helper.ShowDialog();
                DataRow slectedRow = (DataRow)helper.SelectedData;
                if (slectedRow != null)
                {
                    grd01.SetValue(grd01.Row, 0, "U");
                    grd01.SetValue(grd01.Row, colName, slectedRow["CD"]);
                    grd01.SetValue(grd01.Row, nm, slectedRow["NM"]);
                }
            }
            else if(dt.Rows.Count==1)
            {
                grd01.SetValue(row, 0, "U");
                grd01.SetValue(row, colName, dt.Rows[0]["CD"]);
                grd01.SetValue(row, nm, dt.Rows[0]["NM"]);
            }
            else
            {
                grd01.SetValue(row, 0, "U");
                grd01.SetValue(row, colName, "");
                grd01.SetValue(row, nm, "");
            }
        }
        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {

                int row = e.Row;
                int col = e.Col;
                if (row < this.grd01.Rows.Fixed) return;
                string colName = grd01.Cols[col].UserData.ToString();
                
                if (colName == "DOCCD" || colName == "LOCCD" || colName == "GRPCD")
                {
                    grd01.FinishEditing(true);
                    string findStr = grd01.GetValue(e.Row, e.Col).ToString();
                    
                    DlgCodeHelp(colName, row, findStr);
                }
            }
            catch(Exception eLog)
            {
                MsgBox.Show(eLog.Message, "Error");
            }
            finally
            {

            }

        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = grd01.Row;
            int col = grd01.Col;
            if (row < this.grd01.Rows.Fixed) return;
            string colName = grd01.Cols[col].UserData.ToString();
            if (grd01.AllowEditing)
            {
                if (colName == "DOCNM" || colName == "LOCNM" || colName == "GRPNM")
                {
                    string colnm = "";
                    switch (colName)
                    {
                        case "DOCNM":
                            colnm = "DOCCD";
                            break;
                        case "LOCNM":
                            colnm = "LOCCD";
                            break;
                        case "GRPNM":
                            colnm = "GRPCD";
                            break;
                    }
                    string findStr = grd01.GetValue(row, colnm).ToString();
                    DlgCodeHelp(colnm, row, findStr);
                }
            }
            if(colName == "URL")
            {
                
                
            }
        }

        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            base.BtnPrint_Click(sender, e);
            int row = grd01.Row;
            int col = grd01.Col;
            if (row < this.grd01.Rows.Fixed) return;
            HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
            //report.ReportName = "RxRpt/ZSD02500_Temp";
            report.ReportName = "RPT/TM20600";

            HEParameterSet param = new HEParameterSet();

            param.Add("CORCD", cbo01_CORCD.GetValue());
            param.Add("BIZCD", cbo01_BIZCD.GetValue());
            param.Add("PUBCD", grd01.GetValue(row,"PUBCD"));
            DataSet ds = _DB.ExecuteDataSet("APG_TM20600.RPT_DATA", param);
            //ds.WriteXml(@"D:\A\a.xml",XmlWriteMode.WriteSchema);


            ds.Tables[0].TableName = "DATA";
            HERexSection xmlSection = new HERexSection(ds, new HEParameterSet());
            report.Sections.Add("MAIN", xmlSection);

            AxRexpertReportViewer.ShowReport(report, UserInfo);

            ds.Clear();
        }






    }
}

