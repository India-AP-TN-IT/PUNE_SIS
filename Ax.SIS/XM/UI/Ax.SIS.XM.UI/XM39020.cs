#region ▶ Description & History
/* 
 * 프로그램명 : 주요 ITEM 수불 현황 (H.Q)
 * 설      명 : 
 * 최초작성자 :
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 :
 * 
 *				날짜			  작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *              
 * 
 *  
 * 
*/
#endregion
using System;
using System.Data;
using System.Drawing;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;
using System.Windows.Forms;
using Ax.SIS.CM.UI;


namespace Ax.SIS.XM.UI
{

    public partial class XM39020 : AxCommonBaseControl
    {
        //private IXM39020 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_XM39020";

        
        public XM39020()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IXM39020>("PM00", "XM39020.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();		
         
        }

        #region [ 초기화 작업 정의 ]

        private void XM39020_Load(object sender, EventArgs e)
        {
            try
            {
                this.axDockingTab1.LinkPanel = this.panel1;

                this.axDockingTab1.LinkBody = this.panel2;
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
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                DataSet source = this.GetTypeCode("1F");
                source.Tables[0].DefaultView.RowFilter = "OBJECT_ID IN ('1F3000','1F3001','1F3100','1F7920','1F7900')"; //평가클래스, 1F3000 원자재, 1F3001 부자재, 1F3100 상품, 1F7920 완제품, 1F7900 반제품

                this.cbo01_ESTI_CLASS.DataBind(source.Tables[0].DefaultView.ToTable().Copy());

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "기준일자", "STD_DATE", "STD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "제품구분", "ESTI_CLASS", "PRDT_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "품번", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 240, "품명", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "단위", "UNIT", "UNIT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "MES", "MES_QTY", "MES");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "SAP", "SAP_QTY", "EI22060_SAP_RESULT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "차이", "DIFF_QTY", "DIFF_QTY");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "1F", "ESTI_CLASS");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "AQ", "UNIT");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "MES_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "SAP_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "DIFF_QTY");

                this.grd01.Cols["MES_QTY"].Format = "#,###,###,###,##0";
                this.grd01.Cols["SAP_QTY"].Format = "#,###,###,###,##0";
                this.grd01.Cols["DIFF_QTY"].Format = "#,###,###,###,##0";               

                this.grd01.Cols["ESTI_CLASS"].TextAlign = TextAlignEnum.CenterCenter;
                this.grd01.Cols["UNIT"].TextAlign = TextAlignEnum.CenterCenter;

                CellStyle csRed = this.grd01.Styles.Add("csPink");
                csRed.BackColor = Color.Pink;

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
                if (!IsQueryValid()) return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("DATE", this.dte01_DATE.GetValue().ToString());
                paramSet.Add("ESTI_CLASS", this.cbo01_ESTI_CLASS.GetValue().ToString());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                
                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);

                this.grd01.SetValue(source.Tables[0]);
                //this.SetGridStyle(0);

                ShowDataCount(source);
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
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 유효성 검사 ]

        private bool IsQueryValid()
        {
            try
            {
               
                //if (this.GetByteCount(cbo01_ESTI_CLASS.GetValue().ToString())<=0)
                //{
                //    //{0}이 입력되지 않았습니다.
                //    MsgCodeBox.ShowFormat("CD00-0082", this.lbl01_ESTI_CLASS.GetValue());
                //    return false;
                //}

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        //날짜변경시..
        private void dte01_DATE_ValueChanged(object sender, EventArgs e)
        {
           
           
        }

        #endregion
        
        #region [ 사용자 정의 메서드 ]

      

       

        #endregion

    }
}
    