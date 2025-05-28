#region ▶ Description & History
/* 
 * 프로그램명 : PD33120 실사 생산실적 수정 내역 조회
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
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using Ax.SIS.CM.UI;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>제품 입출고 조회</b>
    /// - 작 성 자 : 배명희<br />
    /// - 작 성 일 : 2018-06-08 오전 09:24:12<br />
    /// </summary>
    public partial class PD33120 : AxCommonBaseControl
    {
        //private IPD33110 _WSCOM;
        private AxClientProxy _WSCOM;
		private string PACKAGE_NAME = "APG_PD33120";

        public PD33120()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD33110>("PM03", "PD33120.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();		
        }

        #region [ 초기화 작업 정의 ]

        private void PD33110_Load(object sender, EventArgs e)
        {
            try
            {
                this.axDockingTab1.LinkPanel = this.panel1;
                this.axDockingTab1.LinkBody = this.panel2;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
            }
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd01.AllowEditing = false;
                this.grd01.Initialize(2,2);
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "사업장", "BIZCD", "BIZNM2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "기준일자", "RSLT_DATE", "STD_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "PART NO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "PART NAME", "PARTNM" );
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 060, "ALC", "ALCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "LINE", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "업무유형", "JOB_TYPE", "JOB_TYPE");
                
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "입고", "QTY_I0", "IN_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "O1", "QTY_O1", "O1");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 190, "O2", "QTY_O2", "O2");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 110, "O3", "QTY_O3", "O3");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 110, "O4", "QTY_O4", "O4");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "O5", "QTY_O5", "O5");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "O6", "QTY_O6", "O6");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 160, "O9", "QTY_O9", "O9");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "OA", "QTY_OA", "OA");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 140, "OE", "QTY_OE", "OE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 090, "M1", "QTY_M1", "M1");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "RSLT_DATE");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY_I0");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY_O1");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY_O2");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY_O3");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY_O4");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY_O5");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY_O6");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY_O9");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY_OA");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY_OE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY_M1");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], "BIZCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A1", "JOB_TYPE");

                //-- 그리드 멀티헤더 설정
                DataSet source = this.GetTypeCode("C5"); //POP 작업유형                
                this.grd01.AddMerge(0, 1, "BIZCD", "BIZCD");
                this.grd01.AddMerge(0, 1, "RSLT_DATE", "RSLT_DATE");
                this.grd01.AddMerge(0, 1, "PARTNO", "PARTNO");
                this.grd01.AddMerge(0, 1, "PARTNM", "PARTNM");
                this.grd01.AddMerge(0, 1, "ALCCD", "ALCCD");
                this.grd01.AddMerge(0, 1, "LINECD", "LINECD");
                this.grd01.AddMerge(0, 1, "JOB_TYPE", "JOB_TYPE");
                this.grd01.AddMerge(0, 0, "QTY_O1", "QTY_M1");

                this.grd01.SetHeadTitle(0, "QTY_I0", this.GetLabel("RCV"));
                this.grd01.SetHeadTitle(0, "QTY_O1", this.GetLabel("OUT"));

                for (int i = this.grd01.Cols["QTY_I0"].Index; i <= this.grd01.Cols["QTY_M1"].Index; i++)
                {
                    string code = this.grd01.Cols[i].Name.Replace("QTY_","");
                    DataRow[] drs = source.Tables[0].Select("TYPECD='" + code + "'");
                    if (drs.Length > 0)
                    {
                        this.grd01.SetHeadTitle(1, i, code + "(" + drs[0]["OBJECT_NM"].ToString() + ")");
                    }                
                }


                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_JOB_TYPE.DataBind("A1", true);

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(); // new PM20015P1();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.UserInfo.BusinessCode);
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", this.dtp01_BEG_DATE.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                this.txt01_ALCCD.SetValid(AxTextBox.TextType.UAlphabet);
                this.txt01_PARTNO.SetValid(AxTextBox.TextType.UAlphabet);

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
                paramSet.Add("BEG_DATE", this.dtp01_BEG_DATE.GetValue().ToString());
                paramSet.Add("END_DATE", this.dtp01_END_DATE.GetValue().ToString());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue().ToString());
                paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue().ToString());
                paramSet.Add("ALCCD", this.txt01_ALCCD.GetValue().ToString());
                paramSet.Add("JOB_TYPE", this.cbo01_JOB_TYPE.GetValue().ToString().Equals(string.Empty)? string.Empty : this.cbo01_JOB_TYPE.GetValue().ToString().Substring(2));     //TYPECD를 조건으로 넘기기.           
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);
                
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            this.grd01.InitializeDataSource();
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]


        #endregion

        #region [ 유효성 검사 ]

        private bool IsQueryValid()
        {
            try
            {

                if (this.GetByteCount(this.cbo01_BIZCD.GetValue().ToString()) <= 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM2.Text);
                    return false;
                }


                DateTime t1 = DateTime.Parse(dtp01_BEG_DATE.GetValue().ToString());
                DateTime t2 = DateTime.Parse(dtp01_END_DATE.GetValue().ToString());

                TimeSpan t3 = t2 - t1;

                if (t3.Days < 0)
                {
                    //MsgBox.Show("날짜 지정이 올바르지 않습니다.");
                    MsgCodeBox.Show("PD00-0080");
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

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.UserInfo.BusinessCode);
        }

        #region [ 사용자 정의 메서드 ]
        
        
        
        #endregion

    }
}
