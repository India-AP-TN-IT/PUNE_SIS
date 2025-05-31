#region ▶ Description & History
/* 
 * 프로그램명 : PD60060 사출수지 창고재고 초기화
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
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;

using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    public partial class PD60060 : AxCommonBaseControl
    {
        //private IPD60060 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD60060";

        #region [ 초기화 작업 정의 ]

        public PD60060()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<IPD60060>("PD", "PD60060.svc", "CustomBinding");
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {                

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
             
                this.grd01.AllowMerging = AllowMergingEnum.FixedOnly;
                this.grd01.EnabledActionFlag = false;
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 60, "차종코드", "VINCD", "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "RACK 번호", "LODTBL_NO", "LODTBL_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 160, "수지 PART NAME", "PARTNM", "MIXER_PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "수지품번", "PARTNO", "RESIN_PNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "재고량", "STOCK_COUNT", "STOCK_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "STOCK_COUNT");

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LANG_SET", this.UserInfo.Language);

                //DataSet source1 = _WSCOM.INQUERY_VINCD(bizcd, set);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_VINCD"), set, "OUT_CURSOR");

                //this.cbl01_VinCD.DataBind(source1.Tables[0], "차종코드;명칭", "C;L");            
                this.cbl01_VinCD.DataBind(source1.Tables[0], GetLabel("VINCD")+";"+GetLabel("INSPEC_POSNM"), "C;L");            

                this.SetRequired(lbl01_BIZCD,lbl01_VINCD);

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
                getQuery();
            }
            catch (Exception ex)
            {
            }
        }

        protected override void BtnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                //if (MessageBox.Show("창고재고 초기화 하시겠습니까?","질문", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
                if (MsgCodeBox.ShowFormat("PD00-0023", MessageBoxButtons.OKCancel) != DialogResult.OK) return;

                DataSet source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "VINCD", "LANG_SET");

                DataRow dr = source.Tables[0].NewRow();

                dr["CORCD"] = this.UserInfo.CorporationCode;
                dr["BIZCD"] = this.cbo01_BIZCD.GetValue().ToString();
                dr["VINCD"] = cbl01_VinCD.GetValue().ToString();
                dr["LANG_SET"] = this.UserInfo.Language;

                source.Tables[0].Rows.Add(dr);

                this.BeforeInvokeServer(true);
                //_WSCOM.PROCESS(this.UserInfo.BusinessCode, source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "PROCESS"), source);

             
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("수지 상태값이 초기화되었습니다.");             
                MsgCodeBox.Show("PD00-0024");
                
            }
            catch (Exception ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }
        
        #endregion

        #region [ 사용자 정의 메서드 ]
        
        private void getQuery()
        {
            try
            {
                string bizcd = this.cbo01_BIZCD.GetValue().ToString();
                string vincd=cbl01_VinCD.GetValue().ToString();

                if (!IsSaveValid(bizcd, vincd)) return;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("VINCD", vincd);
                set.Add("LANG_SET", this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");
                this.grd01.SetValue(source);
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

        #region [ 유효성 체크 ]

        private  bool IsSaveValid(string bizcd,string vidcd)
        {
            if (bizcd.Length == 0)
            {
                //MsgBox.Show("사업장을 선택하십시오");
                MsgCodeBox.ShowFormat("PD00-0001", GetLabel("BIZCD"));
                return false;
            }
            else if (vidcd.Length == 0)
            {
                //MsgBox.Show("차종을 선택하십시오");
                MsgCodeBox.ShowFormat("PD00-0001", GetLabel("VINCD"));
                return false;
            }
            return true;

        }

        #endregion
    }
}
