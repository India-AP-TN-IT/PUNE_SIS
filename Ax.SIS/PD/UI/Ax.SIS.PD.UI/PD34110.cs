#region ▶ Description & History
/* 
 * 프로그램명 : PD34110 자동 창고 현재고 조회
 * 설      명 : 
 * 최초작성자 : 진승모
 * 최초작성일 : 2014-10-07 
 * 최종수정자 : 진승모
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			  작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              2014-10-07    진승모     다국어 적용   
 *              2017-07~09    배명희     SIS 이관
 *              
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>자동 창고 현재고 조회</b>
    /// - 작 성 자 : 김선환<br />
    /// - 작 성 일 : 2010-06-25 오후 5:04:26<br />
    /// </summary>
    public partial class PD34110 : AxCommonBaseControl
    {
        //private IPM34110 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD34110";

        public PD34110()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPM34110>("PM04", "PM34110.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();	
        }

        #region [ 초기화 작업 정의 ]

        private void PD34110_Load(object sender, EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkPanel = this.panel1;
                this.heDockingTab1.LinkBody = this.panel2;

                this.panel3.Hide();

                this.groupBox1.Hide();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "차종", "VINCD", "VIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "ALC", "ALCCD", "ALC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "품번", "PARTNO", "PARTNOTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 060, "수량", "CNT", "QTY");

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "차종", "VINCD", "VIN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "ALC", "ALCCD", "ALC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "품번", "PARTNO", "PARTNOTITLE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "창고수량", "BAS_INV_QTY", "STK_INV_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "미투입수량", "MINUS_QTY", "MINUS_QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "실예상수량", "EXPQTY", "EXPQTY");

                //조회시간 : yyyy-MM-dd HH:mm:ss
                this.lbl01_S_DATE.SetValue(string.Format(this.GetLabel("S_DATE"), DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));

                this.cbo01_SAUP.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_SAUP.SetValue(this.UserInfo.BusinessCode);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_SAUP.GetValue().ToString());
                paramSet.Add("STD_DATE", this.dtp01_STD_DATE.GetDateText().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                if (this.chk01_PD34110_OPTION.Checked == true)
                {
                    //DataSet source = _WSCOM.Inquery02(paramSet);
                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY02"), paramSet);
                    this.grd02.SetValue(source.Tables[0]);
                    ShowDataCount(source);

                    this.panel2.Hide();
                    this.panel3.Show();
                    this.heDockingTab1.LinkBody = this.panel3;
                }
                if (this.chk01_PD34110_OPTION.Checked == false)
                {
                    //DataSet source = _WSCOM.Inquery01(paramSet);
                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY01"), paramSet);
                    this.grd01.SetValue(source.Tables[0]);
                    ShowDataCount(source);

                    this.panel3.Hide();
                    this.panel2.Show();
                    this.heDockingTab1.LinkBody = this.panel2;
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
                this.grd01.InitializeDataSource();
                this.grd02.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void chk01_OPTION_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.chk01_PD34110_OPTION.Checked == true)
                {
                    this.groupBox1.Show();
                    this.heDockingTab1.LinkBody = this.panel3;
                    this.panel2.Hide();
                    this.panel3.Show();
                }

                if (this.chk01_PD34110_OPTION.Checked == false)
                {
                    this.groupBox1.Hide();
                    this.heDockingTab1.LinkBody = this.panel2;
                    this.panel3.Hide();
                    this.panel2.Show();
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
