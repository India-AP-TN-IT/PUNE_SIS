
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
    public partial class PD30240 : AxCommonBaseControl
    {
        //private ISD30230 _WSCOM;        
        private AxClientProxy _WSCOM_N;
        
        public PD30240()
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

                DataTable dtCustPlant = new DataTable();
                dtCustPlant.Columns.Add("VALUE");
                dtCustPlant.Columns.Add("TEXT");
                dtCustPlant.Rows.Add("1", "1" + this.GetLabel("PLANT")); //공장
                dtCustPlant.Rows.Add("2", "2" + this.GetLabel("PLANT"));
                dtCustPlant.Rows.Add("3", "3" + this.GetLabel("PLANT"));
                dtCustPlant.Rows.Add("4", "4" + this.GetLabel("PLANT"));
                dtCustPlant.Rows.Add("5", "5" + this.GetLabel("PLANT"));
                dtCustPlant.Rows.Add("7", "7" + this.GetLabel("PLANT"));

                DataTable dtCustLine = new DataTable();
                dtCustLine.Columns.Add("VALUE");
                dtCustLine.Columns.Add("TEXT");
                dtCustLine.Rows.Add("1", "1" + this.GetLabel("LINE")); //라인
                dtCustLine.Rows.Add("2", "2" + this.GetLabel("LINE"));

                //DataTable dtOutType = this.GetTypeCode("C5").Tables[0].Copy();
                DataTable dtOutType = new DataTable();
                dtOutType.Columns.Add("VALUE");
                dtOutType.Columns.Add("TEXT");
                dtOutType.Rows.Add("I0", "I0");
                dtOutType.Rows.Add("I1", "I1");
                dtOutType.Rows.Add("O1", "O1");
                dtOutType.Rows.Add("O3", "O3");
                dtOutType.Rows.Add("O4", "O4");
                dtOutType.Rows.Add("O5", "O5");
                dtOutType.Rows.Add("O6", "O6");
                dtOutType.Rows.Add("O9", "O9");
                dtOutType.Rows.Add("OA", "OA");
                dtOutType.Rows.Add("OE", "OE");
                dtOutType.Rows.Add("R3", "R3");
                dtOutType.Rows.Add("X", "X");
                /*I0,I1,O1,O3,O4,O5,O6,OA,OE,X*/

                DataSet source = new DataSet();
                source.Tables.Add(dtOutType);// 출고유형
                source.Tables.Add(dtCustPlant); // 고객공장
                source.Tables.Add(dtCustLine); // 고객라인
                


                this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);
                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_INV_STATUS.DataBind(source.Tables[0]);
                this.cbo01_CUST_PLANT.DataBind(source.Tables[1]);
                this.cbo01_CUST_LINE.DataBind(source.Tables[2]);

                this.cbo01_CORCD.SetReadOnly(true);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                #endregion

                #region [그리드1]

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "출고일자",      "DELI_DATE",          "OUT_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "고객공장",      "CUST_PLANT",         "CUST_PLANT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "고객라인",      "CUST_LINE",          "CUST_LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "출고유형코드",   "INV_STATUS",         "OUT_TYPE_CD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "출고유형",      "INVSTATUS",          "USGETYP");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "차종", "VINCD", "VIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "ALC코드",       "ALCCD",             "E_ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "장착위치",      "INSTALL_POS",        "POSTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "품번",          "PARTNO",            "PARTNOTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "LOTNO",        "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "출고각인일시",   "OUT_READ_DATETIME", "OTRD_DATETIME");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A7", "INSTALL_POS");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "DELI_DATE");

                #endregion

                #region [그리드2]

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "출고전표헤더",   "DELI_NOTENO",       "OUT_BILL_HD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "출고전표세부",   "DELI_NOTE_LINE",    "OUT_BILL_DT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "LOTNO",        "LOTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 150, "출고각인일시",   "OUT_READ_DATETIME", "OTRD_DATETIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "차종",          "VINCD",             "VIN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "ALC코드",       "ALCCD",             "E_ALCCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "장착위치",      "INSTALL_POS",        "POSTITLE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번",          "PARTNO",            "PARTNOTITLE");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A3", "VINCD");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A7", "INSTALL_POS");

                #endregion
                
                #region [출고상태]

                StringBuilder builder = new StringBuilder();
                builder.AppendLine(this.GetLabel("PD30240_ETCOUT_1"));// "O3  - 결품추가";
                builder.AppendLine(this.GetLabel("PD30240_ETCOUT_2"));// "O4  - 추가파견";
                builder.AppendLine(this.GetLabel("PD30240_ETCOUT_3"));// "O5  - 기타출고(유상)";
                builder.AppendLine(this.GetLabel("PD30240_ETCOUT_4"));// "OA  - 기타출고(무상)";
                this.lbl01_ETCOUT_PD30240.Value = builder.ToString();
                
                #endregion

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
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.GetDateText());
                paramSet.Add("EDATE", this.dte01_EDATE.GetDateText());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        paramSet.Add("INV_STATUS", this.cbo01_INV_STATUS.GetValue());
                        paramSet.Add("CUST_PLANT", this.cbo01_CUST_PLANT.GetValue());
                        paramSet.Add("CUST_LINE",  this.cbo01_CUST_LINE.GetValue());
                        source = _WSCOM_N.ExecuteDataSet("APG_PD30240.INQUERY_0", paramSet);
                        this.grd01.SetValue(source.Tables[0]);
                        this.AfterInvokeServer();
                        break;
                    case 1:
                        source = _WSCOM_N.ExecuteDataSet("APG_PD30240.INQUERY_1", paramSet);
                        this.grd02.SetValue(source.Tables[0]);
                        this.AfterInvokeServer();
                        break;
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbo01_INV_STATUS.SetReadOnly(this.tabControl1.SelectedIndex == 1);
            this.cbo01_CUST_PLANT.SetReadOnly(this.tabControl1.SelectedIndex == 1);
            this.cbo01_CUST_LINE.SetReadOnly(this.tabControl1.SelectedIndex  == 1);
        }

        #endregion
    }
}
