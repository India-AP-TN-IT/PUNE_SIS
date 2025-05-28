using System;
using System.Data;
using System.ServiceModel;

using System.Drawing;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using Ax.DEV.Utility.Library;
using HE.Framework.Core.Report;
using System.Diagnostics;


namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class TM24390 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private const string _IntFormat = "###,###,###,###,##0";

        private const int IDX_CHECK_COLUMN = 1;//2019.04.16

        public TM24390()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
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

                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;


                cdx01_VENDCD.HEPopupHelper = new TM24005();
                cdx01_VENDCD.PopupTitle = this.GetLabel("VEND_INFO");// "업체정보"; 
                cdx01_VENDCD.CodeParameterName = "CD";
                cdx01_VENDCD.NameParameterName = "NM";
                cdx01_VENDCD.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                cdx01_VENDCD.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
                cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", UserInfo.Language);
                                                                
                #region [grd01] [Search Condition]

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

               this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "Asset No", "ASNO", "ASNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 280, "Asset Description", "ASNM", "ASNM");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 280, "Last Location", "CUR_LOCCD", "CUR_LOCCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "Supplier", "CUR_VENDNM", "CUR_VENDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 190, "Last T/Date", "LAST_DATE", "LAST_DATE");



                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "DIV", "DIV", "DIV");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "TYCD", "TYCD", "TYCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "WEB_ADDR", "WEB_ADDR", "WEB_ADDR");

                dtp01_ST_DATE.SetValue(DateTime.Now.AddMonths(-2));
                dtp01_ED_DATE.SetValue(DateTime.Now);


                this.grd02.AllowEditing = false;
                this.grd02.Initialize();

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 190, "Transaction Date", "TR_DATE", "TR_DATE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 90, "DIV.", "TY", "TY");

                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 280, "Supplier", "VENDNM", "VENDNM");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "LOCATION", "LOCCD", "LOCCD");

                #endregion              
                

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #region [공통버튼]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("ASNO", this.axTextBox1.GetValue());
                set.Add("ASNM", this.axTextBox2.GetValue());
                set.Add("ST_DATE", dtp01_ST_DATE.GetDateText());
                set.Add("ED_DATE", dtp01_ED_DATE.GetDateText());

                set.Add("VENDCD", cdx01_VENDCD.GetValue());
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_TM24390.INQUERY", set, "OUT_CURSOR");

                this.AfterInvokeServer();

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

        #endregion

        

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.grd02.InitializeDataSource();
            if (grd01.Row > grd01.Rows.Fixed)
            {
                int row = grd01.Row;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("ASNO", grd01.GetValue(row, "ASNO"));
                set.Add("ST_DATE", dtp01_ST_DATE.GetDateText());
                set.Add("ED_DATE", dtp01_ED_DATE.GetDateText());

                DataSet source = _WSCOM.ExecuteDataSet("APG_TM24390.INQUERY_DET", set, "OUT_CURSOR");


                this.grd02.SetValue(source.Tables[0]);
            }
        }



    }
}
