using System;
using System.Drawing;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.ServiceModel;
using System.Collections.Generic;

namespace Ax.SIS.SD.UI
{
    
    public partial class ZSD02500_EtcDelDLG : AxCommonPopupControl
    {
        private AxClientProxy _WSCOM_N;
        private string m_CORCD;
        private string m_BIZCD;
        private string m_CUSTCD;
        private string m_DEL_DATE;
        private bool m_Selected = false;
        public ZSD02500_EtcDelDLG(string corcd, string bizcd, string custcd, string deli_date)
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
            m_DEL_DATE = deli_date;
            m_CORCD = corcd;
            m_BIZCD = bizcd;
            m_CUSTCD = custcd;
            m_Selected = false;
        }

        public bool Selected
        {
            get { return m_Selected; }
        }
        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                if (!IsCreated)
                {
                    this.grd01.Initialize();
                    this.grd01.AllowEditing = true;
                    this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 40, "C", "CHK");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "ORDER NO.", "ORDERNO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "PO NO.", "PONO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "PART NO.", "PARTNO");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 350, "PART NAME", "PARTNM");
                    this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "QTY", "QTY");
                    this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");
                    IsCreated = true;
                    axDateEdit1.Value = new DateTime(Convert.ToInt32(m_DEL_DATE.Substring(0, 4)), Convert.ToInt32(m_DEL_DATE.Substring(5, 2)), Convert.ToInt32(m_DEL_DATE.Substring(8, 2)));

                    InitLoad();
                }

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region IHEPopupHelper 멤버
        private DataTable m_SelectedDT = null;
        public DataTable SelectedDT
        {
            get { return this.m_SelectedDT; }
        }

        public void Initialize_Helper(object sender)
        {
            this.CodeBox = (AxCodeBox)sender;
        }
        private void InitLoad()
        {
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", m_CORCD);
            paramSet.Add("BIZCD", m_BIZCD);
            paramSet.Add("CUSTCD", m_CUSTCD);
            paramSet.Add("DELI_DATE", m_DEL_DATE);
            paramSet.Add("ORDERNO", "");
            paramSet.Add("PARTNO", "");
            DataTable dt = GetDataSource(paramSet);
            grd01.SetValue(dt);
        }
        public DataTable GetDataSource(HEParameterSet set)
        {       
            
            return _WSCOM_N.ExecuteDataSet("ZPG_ZSD02500_DLG.GET_ETC_DELI", set, "OUT_CURSOR").Tables[0];
        }

        #endregion

        #region [ 기타 이벤트 정의 ]
        /*
        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.grd01.SelectedRowIndex < this.grd01.Rows.Fixed) return;

                this.SelectedData = this.grd01.SelectedDataRow;
                ((Form)this.Parent).Close();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        */
        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", m_CORCD);
                paramSet.Add("BIZCD", m_BIZCD);
                paramSet.Add("CUSTCD", m_CUSTCD);
                paramSet.Add("DELI_DATE", axDateEdit1.GetDateText());
                paramSet.Add("ORDERNO", txt01_ORDERNO.GetValue());
                paramSet.Add("PARTNO", txt01_PARTNO.GetValue());
                DataTable dt = GetDataSource(paramSet);
                grd01.SetValue(dt);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
        private DataTable SelectedData()
        {
            
            DataSet ds = this.grd01.GetValue(AxFlexGrid.FActionType.All,
                                            "CHK"
                                            , "ORDERNO"
                                            , "PONO"
                                            , "PARTNO"
                                            , "PARTNM"
                                            , "QTY"
                                            );
            DataTable dt = new DataTable();
            dt = ds.Tables[0].Clone();
            for(int row=0;row<ds.Tables[0].Rows.Count;row++)
            {
                if (ds.Tables[0].Rows[row]["CHK"].ToString() == "Y")
                {
                    dt.ImportRow(ds.Tables[0].Rows[row]);
                }
            }

            return dt;
        }
        private void axButton1_Click(object sender, EventArgs e)
        {
            m_SelectedDT = SelectedData();
            m_Selected = true;
            ((Form)this.Parent).Close();
        }

        private void axButton2_Click(object sender, EventArgs e)
        {
            for(int row=1;row<grd01.Rows.Count;row++)
            {
                if(grd01.GetValue(row,"CHK").ToString() == "N")
                {
                    grd01.SetValue(row,"CHK", "1");
                }
            }
        }

        private void axButton3_Click(object sender, EventArgs e)
        {
            for (int row = 1; row < grd01.Rows.Count; row++)
            {
                if (grd01.GetValue(row, "CHK").ToString() == "Y")
                {
                    grd01.SetValue(row, "CHK", "0");
                }
            }
        }

    }
}
