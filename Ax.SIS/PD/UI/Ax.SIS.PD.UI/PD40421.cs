#region ▶ Description & History
/* 
 * 프로그램명 : PD40421 ASSY-SUB자재 LOT추적 조회
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
    /// Assy - Sub자재 LOT 추적조회
    /// </summary>
    public partial class PD40421 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private string PACKAGE_NAME = "APG_PD40421";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        public PD40421()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize(2, 2);
                this.grd01.EnabledActionFlag = false;
                this.grd01.AllowFreezing = AllowFreezingEnum.Columns;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "PROD_DATE", "PROD_DATE"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차종", "VIN", "VIN");                 //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "라인코드", "LINECD", "LINECD"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "라인명", "LINENM", "LINENM"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "장착위치", "POSTITLE", "POSTITLE"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "LOT NO", "LOTNO", "LOTNO"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "ALC", "ALCCD", "ALC"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "제품 P/NO", "ASSY_PNO", "ASSY_PNO"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "PART NAME", "PARTNM", "PARTNM"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "외작 PARTNO", "SUBCON_PNO", "SUBCON_PNO"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "PART NAME", "SUBCON_PNM", "PARTNM"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "LOT NO", "LOTNOTITLE", "LOTNO"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "PARTNO_DATE", "PROD_DATE"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "업체코드", "VENDCD", "VENDCD"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "업체명", "VENDNM", "VENDNM"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "SUB PART NO", "MPNO", "MPNO"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "PART NAME", "SUB_PNM", "PARTNM"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "LOT NO", "LOTNO_TITLE_1", "LOTNO"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "생산일자", "MPNO_DATE", "PROD_DATE"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "업체명1", "SUB_VENDNM1", "SUB_VENDNM1"); //@@@
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "업체명2", "SUB_VENDNM2", "SUB_VENDNM2"); //@@@
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PARTNO_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "MPNO_DATE");


                for (int i = this.grd01.Cols.Fixed; i <= this.grd01.Cols["PARTNM"].Index; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                for (int i = 0; i < grd01.Cols.Count; i++)
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;

                this.grd01.AddMerge(0, 0, "PROD_DATE", "PARTNM");
                this.grd01.SetHeadTitle(0, "PROD_DATE", this.GetLabel("ASSYPNO"));// "완제품"); //@@@

                this.grd01.AddMerge(0, 0, "SUBCON_PNO", "VENDNM");
                this.grd01.SetHeadTitle(0, "SUBCON_PNO", this.GetLabel("MATRIAL"));// "자재"); //@@@

                this.grd01.AddMerge(0, 0, "MPNO", "SUB_VENDNM2");
                this.grd01.SetHeadTitle(0, "MPNO", this.GetLabel("SUB_MAT"));// "SUB 자재"); //@@@

                this.grd01.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;
                //this.grd01.Cols.Frozen = this.grd01.Cols["PARTNM"].Index;


                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));

                this.dtp01_START.SetValue(DateTime.Now);
                this.dtp01_END.SetValue(DateTime.Now);

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PRDT_DIV", "A0A");
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set);
                //DataSet source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set);

                //this.cbl01_LINECD.DataBind(source1.Tables[0], "LINECD", "LINENM", "라인코드;라인명", "C;L"); //@@@
                this.cbl01_LINECD.DataBind(source1.Tables[0], "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L"); //@@@

                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_PROD_DATE);

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
                set.Add("YMD_START", String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(this.dtp01_START.GetValue())));//this.dtp01_START.GetValue().ToString().Replace("-",""));
                set.Add("YMD_END", String.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(this.dtp01_END.GetValue())));//this.dtp01_END.GetValue().ToString().Replace("-",""));                
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("ASSY_LOTNO", this.txt_LOTNO.GetValue());
                set.Add("MAT_LOTNO", this.txt_MAT_LOTNO.GetValue());
                set.Add("MAT_PARTNO", this.txt_MAT_PARTNO.GetValue());
                set.Add("MPNO_LOTNO", this.txt_MPNO_LOTNO.GetValue());
                set.Add("MPNO", this.txt_MPNO.GetValue());
                set.Add("LANG_SET", this.UserInfo.Language);
                                
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

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

        #region [ 유효성 체크 ]

        private bool IsSearchValid()
        {
            try
            {
                if (this.GetByteCount(cbo01_BIZCD.GetValue().ToString()) == 0)
                {
                    //MsgBox.Show("사업장을 선택해주세요.");
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("BIZCD"));
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

        private void cbl01_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("PRDT_DIV", "");
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set);
                //DataSet source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set);

                //this.cbl01_LINECD.DataBind(source1.Tables[0], "라인코드;라인명", "C;L");
                this.cbl01_LINECD.DataBind(source1.Tables[0],GetLabel("LINECD")+";"+GetLabel("LINENM"), "C;L");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
