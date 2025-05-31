#region ▶ Description & History
/* 
 * 프로그램명 : PD70030 창고간 이동 실적 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-10-26      김성우     신규개발
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
using System.Drawing;

using System.Windows.Forms;
using C1.Win.C1FlexGrid;

using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;

namespace Ax.SIS.PD.UI
{

    public partial class PD70030 : AxCommonBaseControl
    {
        
        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_PD70030";

        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        #region [ 초기화 작업 정의 ]

        public PD70030()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.dte01_PLAN_BEG_DATE.SetValue(System.DateTime.Now.AddDays(-1));
                this.dte01_PLAN_END_DATE.SetMMFromStart();

                #region [  grd01  ]

                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AllowEditing = true;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 085, "일자", "RSLT_DATE", "DD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "작업유형", "JOB_TYPE", "WORKTYPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "라인", "LINECD", "LINE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "품번", "PARTNO", "PARTNOTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "작업지시번호", "WORK_ORDNO", "WORK_ORDNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "판매오더번호", "ORDNO", "SALE_ORDNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "판매오더순번", "SEQNO", "SALE_SEQNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "저장위치", "STR_LOC", "STR_LOC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "오더구분", "ORD_TYPE", "ORD_GBN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 040, "ALC", "ALCCD", "ALC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "입출고구분", "ENFOR_DIV", "INOUT_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "실적수량", "SUM_QTY", "RSLT_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 070, "변경수량", "CHNG_QTY", "CHANGE_QTY");
                
                
                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("BIZCD");

                this.grd01.Cols["SUM_QTY"].DataType = typeof(decimal);
                this.grd01.Cols["CHNG_QTY"].DataType = typeof(decimal);

                this.grd01.Cols["SUM_QTY"].Format = "#,###,###,###,###,###,##0";
                this.grd01.Cols["CHNG_QTY"].Format = "#,###,###,###,###,###,##0";


                this.grd01.Cols["SUM_QTY"].Style.BackColor = Color.Beige;
                this.grd01.Cols["CHNG_QTY"].Style.BackColor = Color.LightPink;

                #endregion

                this.SetRequired(lbl01_BIZNM2, lbl01_SEARCH_DAY);
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                cbl01_LINECD.Text = "";
                txt01_STR_LOC.Text = "";
                txt01_PARTNO_PARTNM.Text = "";
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsQueryValid())
                    return;
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("BEG_DATE", this.dte01_PLAN_BEG_DATE.GetDateText());
                paramSet.Add("END_DATE", this.dte01_PLAN_END_DATE.GetDateText());
                paramSet.Add("LINECD", this.cbl01_LINECD.GetValue());
                paramSet.Add("PARTNO", this.txt01_PARTNO_PARTNM.GetValue());
                paramSet.Add("STR_LOC", this.txt01_STR_LOC.GetValue());

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                this.AfterInvokeServer();

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

        #region [ 사용자 정의 메서드 ]


        
        #endregion

        #region [ 유효성 검사 ]
        
        private bool IsQueryValid()
        {
            try
            {
                
                if (this.cbo01_BIZCD.ByteCount == 0)
                {
                    //MsgBox.Show("{0} 가(이) 입력되지 않았습니다.", 사업장코드);
                    MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("BIZCD"));
                    return false;
                }
                
                if(this.dte01_PLAN_BEG_DATE.Value.AddDays(-1) > this.dte01_PLAN_END_DATE.Value)
                {
                    //MsgBox.Show("시작일자 {0}은 종료일자 {1}보다 작아야 합니다.", );
                    MsgCodeBox.ShowFormat("PD00-0053", this.dte01_PLAN_BEG_DATE.Value, this.dte01_PLAN_END_DATE.Value);
                    return false;
                }
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        private void cbl01_LINECD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            set.Add("PRDT_DIV", "");
            set.Add("LANG_SET", this.UserInfo.Language);
            DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set);
            //DataSet source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set);

            this.cbl01_LINECD.DataBind(source1.Tables[0], this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");  //라인코드;라인명
        }


        
        #endregion       

    }
}
