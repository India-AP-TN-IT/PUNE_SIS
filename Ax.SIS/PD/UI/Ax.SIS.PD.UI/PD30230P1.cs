using System;
using System.Data;
using System.ServiceModel;

using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>완제품 LOTNO 조회</b>
    /// - 작 성 자 : 장상휘<br />
    /// - 작 성 일 : 2010-06-01 오후 1:34:13<br />
    /// </summary>
    public partial class PD30230P1 : AxCommonPopupControl
    {
        private AxClientProxy _WSCOM;
        

        private const string _REAL_UMES = "MES_ULSAN";
        private const string _REAL_AMES = "MES_ASAN";
        private string _LOTNO;

        public PD30230P1(string LOTNO)
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
            _LOTNO = LOTNO;
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "LOTNO",        "LOTNO", "LOTNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 070, "ALC코드",      "ALCCD", "ALCTITLE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 110, "품번",         "PARTNO", "PARTNOTITLE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 060, "작업라인",     "LINECD", "WORK_LINENM2");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "라벨출력일시", "PROD_DATETIME", "TAGDATETIME"); 
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "입고각인일시", "INRD_DATETIME", "INDATETIME");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "출고각인일시", "OTRD_DATETIME", "OTRD_DATETIME");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 090, "납품적용일자", "DELI_DATE", "APPLYDATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "고객공장",     "CUST_PLANT","CUST_PLANT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "고객라인",     "CUST_LINE","CUST_LINE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 060, "서열순번",     "ALC_SEQ", "ALC_SEQ2"); 
                
                this.cbo01_CORCD.DataBind(this.GetCorCD().Tables[0]);
                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);

                this.cbo01_CORCD.SetReadOnly(true);

                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);

                this.txt01_LOTNO.SetValid(AxTextBox.TextType.UAlphabet);

                string std = this.UserInfo.BusinessCode;

                if(_LOTNO.Length > 0)
                {
                    this.txt01_LOTNO.SetValue(_LOTNO);
                    this.btn01_Query_Click(null, null);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private bool IsQueryValid()
        {
            try
            {
                if (this.txt01_LOTNO.ByteCount == 0)
                {
                    
                    //{0} 가(이) 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_LOTNO.Text);
                    return false;
                }


                if (this.txt01_LOTNO.ByteCount < 5)
                {
                    //SD00-0009 {0}은(는) {1} Byte 이상 입력하세요.
                    MsgCodeBox.ShowFormat("CD00-0121", this.lbl01_LOTNO.Text, "5");
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private void btn01_Query_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsQueryValid()) return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("LOTNO", this.txt01_LOTNO.GetValue());
                
                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("ASP_SD_SELECT_MES2010_01", paramSet);
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
    }
}
