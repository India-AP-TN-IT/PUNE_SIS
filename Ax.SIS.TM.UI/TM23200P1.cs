using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;

namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// <b>Part No 헬퍼(입고/출고)</b>
    /// - 작 성 자 : 이현범<br />
    /// - 작 성 일 : 2015-02-09<br />
    /// </summary>
    public partial class TM23200P1 : AxCommonPopupControl, IAxPopupHelper
    {
        private AxClientProxy _WSCOM;

        public TM23200P1()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                if (!this.IsCreated)
                {
                    #region [ grd01 ]

                    this.grd01.AllowEditing = false;
                    this.grd01.Initialize();
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "_PART NO", "PARTNO", "PARTNO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "_PART NAME", "PARTNM", "PARTNM");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 080, "_VENDCD", "VENDCD", "VENDCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "Vendor", "VENDNM", "VENDNM");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "_VINCD", "VINCD", "VINCD");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "Car", "VINNM", "VINNM");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Mat Type", "MAT_TYPE", "MAT_TYPE");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 060, "_단위", "UNIT", "UNIT");

                    this.grd01.CurrentContextMenu.Items[0].Visible = false;
                    //this.grd01.CurrentContextMenu.Items[1].Visible = false;
                    //this.grd01.CurrentContextMenu.Items[2].Visible = false;
                    //this.grd01.CurrentContextMenu.Items[3].Visible = false;

                    #endregion

                    this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);

                    this.IsCreated = true;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            this.txt01_PARTNO.SetValue(this.CodeBox.GetValue());
            this.txt01_PARTNM.SetValue(this.CodeBox.GetText());

            this.btn01_Inquery_Click(null, null);
        }

        #endregion

        #region IHEPopupHelper 멤버

        public object SelectedValue
        {
            get
            {
                return this.SelectedData;
            }
        }

        public void Initialize_Helper(object sender)
        {
            this.CodeBox = (AxCodeBox)sender;
        }

        public DataTable GetDataSource(HEParameterSet set)
        {
            return _WSCOM.ExecuteDataSet("APG_WM20520.INQUIRY_COMBO_PARTNO", set).Tables[0];
        }

        #endregion

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD"));
                //set.Add("VENDORCD", this.CodeBox.HEUserParameterGetValue("VENDORCD"));
                set.Add("PARTNO", this.txt01_PARTNO.GetValue());
                set.Add("PRDT_DIV", this.CodeBox.HEUserParameterGetValue("PRDT_DIV"));
                set.Add("PARTNM", this.txt01_PARTNM.GetValue());
                set.Add("APP_DATE", this.CodeBox.HEUserParameterGetValue("APP_DATE"));
                set.Add("LANG_SET", this.CodeBox.HEUserParameterGetValue("LANG_SET"));

                this.BeforeInvokeServer(true);

                DataTable table = this.GetDataSource(set);
                this.grd01.SetValue(table);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (this.grd01.Row < this.grd01.Rows.Fixed) return;

                this.SelectedData = this.grd01.SelectedDataRow;
                ((Form)this.Parent).Close();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
    }
}
