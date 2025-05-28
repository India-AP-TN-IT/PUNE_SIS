using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;

namespace Ax.SIS.WM.UI
{
    /// <summary>
  
    /// </summary>
    public partial class WM20443P1 : AxCommonPopupControl, IAxPopupHelper
    {
        private AxClientProxy _WSCOM;

        public WM20443P1()
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
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO", "PARTNO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "PART NAME", "PARTNM", "PARTNM");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 080, "VENDCD", "VENDCD", "VENDCD");
                    this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 060, "VINCD", "VINCD", "VIN");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "VIN NAME", "VINNM", "VINNM");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "ITEM NAME", "ITEMNM", "ITEMNM");

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
            return _WSCOM.ExecuteDataSet("APG_WM20443.INQUIRY_PARTNO", set).Tables[0];
        }

        #endregion

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.CodeBox.HEUserParameterGetValue("BIZCD"));
                set.Add("PARTNO", this.txt01_PARTNO.GetValue());
                set.Add("PARTNM", this.txt01_PARTNM.GetValue());
                set.Add("VINCD", this.CodeBox.HEUserParameterGetValue("VINCD"));
                set.Add("ITEMCD", this.CodeBox.HEUserParameterGetValue("ITEMCD"));
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
