#region ▶ Description & History
/* 
 * 프로그램명 : PD40420 HMC완성차-SUB자재 LOT추적 조회
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


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 계측 유형 관리 - 사출 SPC
    /// </summary>
    public partial class PD40420 : AxCommonBaseControl
    {
        //private IPD40420 _WSCOM;
        private AxClientProxy _WSCOM_N;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private string PACKAGE_NAME = "APG_PD40420";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        public PD40420()
        {
            InitializeComponent();
            //_WSCOM = ClientFactory.CreateChannel<IPD40420>("PD", "PD40420.svc", "CustomBinding");            
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                HEParameterSet param = new HEParameterSet();
                param.Add("GROUPCD", "SD052");//고객라인 

                //SIS컨버전에 따른 SD0011테이블이 없어짐..
                //일단 소스에서 데이터 생성처리함.. 2017-07-06 배명희(오세민대리님확인OK)
                //System.Collections.Generic.List<HEParameterSet> paramList = new System.Collections.Generic.List<HEParameterSet> { param };
                //DataSet source = _WSCOM_N.MultipleExecuteDataSet(string.Format("{0}.{1}", "APG_PD40420", "INQUERY_CODE"), paramList);
                DataSet source = AxFlexGrid.GetDataSourceSchema("CD", "CDNM", "MAPPINGCD", "OPTIONCD");
                source.Tables[0].Rows.Add("1", "1", DBNull.Value, DBNull.Value);
                source.Tables[0].Rows.Add("2", "2", DBNull.Value, DBNull.Value);

                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize(2, 2);
                this.grd01.EnabledActionFlag = false;
                this.grd01.AllowFreezing = AllowFreezingEnum.Columns;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "오더일자", "YMD", "ORDER_DAY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차종코드", "VINCD", "VINCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "공장", "PLANT", "PLANT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "라인", "LINE", "LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 040, "순번", "LSEQ", "SEQ_NO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "BODY NO", "VID", "BODYNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "위치", "POS", "POS");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "LOT NO", "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "당사생산일자", "PROD_DATE", "PROD_DATE2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "외작 PARTNO", "MAT_PARTNO", "SUBCON_PNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "PART NAME", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "LOT NO", "MAT_LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "PARTNO_DATE", "PROD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "업체코드", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "업체명", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "SUB PART NO", "MPNO", "MPNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "PART NAME", "MPNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "LOT NO", "MPNO_LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "MPNO_DATE", "PROD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "업체명1", "VENDNM1", "SUB_VENDNM1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "업체명2", "VENDNM2", "SUB_VENDNM2");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PARTNO_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "MPNO_DATE");

                #region [바인딩 정보 생성]

                DataTable source1 = new DataTable();
                source1.Columns.Add("CODE");
                source1.Columns.Add("VALUE");
                source1.Rows.Add("1", "1 " + GetLabel("PLANT"));
                source1.Rows.Add("2", "2 " + GetLabel("PLANT"));
                source1.Rows.Add("3", "3 " + GetLabel("PLANT"));
                source1.Rows.Add("4", "4 " + GetLabel("PLANT"));
                source1.Rows.Add("5", "5 " + GetLabel("PLANT"));
                source1.Rows.Add("6", "6 " + GetLabel("PLANT"));
                source1.Rows.Add("7", "7 " + GetLabel("PLANT"));

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("PRDT_DIV", "");

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);
                DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2);
                //DataSet source2 = _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST();

                this.cbl01_INSTALL_POS.DataBind(source2.Tables[0], this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");   //타입코드;타입명

                this.cbo01_LINE.DataBind(source.Tables[0]);

                this.chk01_USE_YN4.Checked = false;

                #endregion

                #region [그리드 Merge & 컬럼 설정]


                //MERGE
                for (int i = this.grd01.Cols.Fixed; i <= this.grd01.Cols["PROD_DATE"].Index; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                for (int i = 0; i < grd01.Cols.Count; i++)
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;

                this.grd01.AddMerge(0, 0, "YMD", "PROD_DATE");
                //this.grd01.SetHeadTitle(0, "YMD", "완제품");
                this.grd01.SetHeadTitle(0, "YMD", GetLabel("ASSYPNO"));

                this.grd01.AddMerge(0, 0, "MAT_PARTNO", "VENDNM");
                //this.grd01.SetHeadTitle(0, "MAT_PARTNO", "자재");
                this.grd01.SetHeadTitle(0, "MAT_PARTNO", GetLabel("MATRIAL"));

                this.grd01.AddMerge(0, 0, "MPNO", "VENDNM2");
                //this.grd01.SetHeadTitle(0, "MPNO", "SUB 자재");
                this.grd01.SetHeadTitle(0, "MPNO", GetLabel("SUB_MAT"));

                this.grd01.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd01.Cols["YMD"].TextAlign = TextAlignEnum.CenterTop;
                this.grd01.Cols["VINCD"].TextAlign = TextAlignEnum.CenterTop;
                this.grd01.Cols["PLANT"].TextAlign = TextAlignEnum.CenterTop;
                this.grd01.Cols["LINE"].TextAlign = TextAlignEnum.CenterTop;
                this.grd01.Cols["LSEQ"].TextAlign = TextAlignEnum.CenterTop;
                this.grd01.Cols["VID"].TextAlign = TextAlignEnum.CenterTop;



                this.grd01.Cols.Frozen = this.grd01.Cols["PROD_DATE"].Index;


                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.dtp01_START.SetValue(DateTime.Now);
                this.dtp01_END.SetValue(DateTime.Now);
                this.dte01_PROD_DATE.SetValue(DateTime.Now);

                this.cbo02_PLANT.DataBind(source1, false);

                this.SetRequired(this.lbl01_BIZCD, this.lbl01_CUST_ORDER, this.lb01_CUST_PLANT);
                #endregion


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
                if (!IsSearchValid()) return;

                string bizcd = this.cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("YMD_START", String.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.dtp01_START.GetValue())));//this.dtp01_START.GetValue().ToString().Replace("-",""));
                set.Add("YMD_END", String.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.dtp01_END.GetValue())));//this.dtp01_END.GetValue().ToString().Replace("-",""));
                set.Add("PLANT", this.cbo02_PLANT.GetValue());

                set.Add("VID", this.txt_BODYNO.GetValue());


                set.Add("LOTNO", this.txt_LOTNO.GetValue());
                set.Add("MAT_LOTNO", this.txt_MAT_LOTNO.GetValue());
                set.Add("MAT_PARTNO", this.txt_MAT_PARTNO.GetValue());
                set.Add("MPNO_LOTNO", this.txt_MPNO_LOTNO.GetValue());
                set.Add("MPNO", this.txt_MPNO.GetValue());
                set.Add("LINECD", this.cbo01_LINE.GetValue());
                set.Add("VINCD", this.cbl01_VINCD.GetValue());
                set.Add("INSTALL_POS", this.cbl01_INSTALL_POS.GetValue());
                set.Add("ALCCD", this.txt01_ALCCD.GetValue());
                if(chk01_USE_YN4.Checked == true)
                    set.Add("PROD_DATE", this.dte01_PROD_DATE.GetDateText());
                else
                    set.Add("PROD_DATE", string.Empty);
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.INQUERY(bizcd, String.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.dtp01_START.GetValue())), String.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.dtp01_END.GetValue())), set);

                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                this.AfterInvokeServer();



                //this.grd01.AddMerge(0, 0, "YMD", "PROD_DATE");
                //this.grd01.SetHeadTitle(0, "YMD", "완제품");

                //this.grd01.AddMerge(0, 0, "MAT_PARTNO", "VENDNM");
                //this.grd01.SetHeadTitle(0, "MAT_PARTNO", "자재");

                //this.grd01.AddMerge(0, 0, "MPNO", "VENDNM2");
                //this.grd01.SetHeadTitle(0, "MPNO", "SUB 자재");

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

        #region [유효성 검사]

        private bool IsSearchValid()
        {
            try
            {
                if (this.GetByteCount(cbo01_BIZCD.GetValue().ToString()) == 0)
                {
                    //MsgBox.Show("사업장을 선택해주세요.");
                    MsgCodeBox.Show("PD00-0102");
                    return false;
                }

                if (this.GetByteCount(dtp01_START.GetDateText().ToString()) == 0)
                {
                    //MsgBox.Show("고객오더 시작 일자를 입력해주세요.");
                    MsgCodeBox.Show("PD00-0103");
                    return false;
                }

                if (this.GetByteCount(dtp01_END.GetDateText().ToString()) == 0)
                {
                    //MsgBox.Show("고객오더 마지막 일자를 입력해주세요.");
                    MsgCodeBox.Show("PD00-0104");
                    return false;
                }

                if (this.GetByteCount(cbo02_PLANT.GetValue().ToString()) == 0)
                {
                    //MsgBox.Show("고객공장을 선택해주세요.");
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("CUST_PLANT"));
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

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void cbl01_VINCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set1 = new HEParameterSet();
                set1.Add("LANG_SET", this.UserInfo.Language);
                set1.Add("CORCD", this.UserInfo.CorporationCode);
                set1.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_CARTYPE"), set1).Tables[0];
                //DataTable source = _WSCOM_ERM.INQUERY_COMBO_CARTYPE(set1).Tables[0];
                this.cbl01_VINCD.DataBind(source, "TYPECD", "TYPECD", this.GetLabel("VINCD") + ";" + this.GetLabel("VINNM"), "C;L");  //차종코드;차종명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
