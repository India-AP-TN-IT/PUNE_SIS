#region ▶ Description & History
/* 
 * 프로그램명 : 정전개 리스트 현황
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 배명희
 * 최종수정일 : 2013-12-05
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2013-12-05	    배명희		#001 [자재원단위전송], [생산원단위전송]버튼 클릭시 로그테이블(XD1520)에 로그 남김
 *				                                 (Ax.SIS.FX.COMMON.IF 프로젝트 참조 추가함.)
 *				2014-07-10      배명희      #002 Ax.SIS.FX.COMMON.IF 참조 제거(기존 로그 등록 로직은 통합ws사용)
 * 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;

using HE.Framework.ServiceModel;

namespace Ax.SIS.BM.BM00.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>
    /// - 작 성 자 : 이태호<br />
    /// - 작 성 일 : 2010-08-21 오후 4:12:57<br />
    /// - 주요 변경 사항
    ///     1) 2010-08-21 오후 4:12:57   이태호 : 최초 클래스 생성<br />
    /// </summary>
    public partial class BM30510 : AxCommonBaseControl
    {
        //private IBM30510 _WSCOM;
        private AxClientProxy _WSCOM_N;

        public BM30510()
        {
            InitializeComponent();
            _WSCOM_N = new AxClientProxy();
            //_WSCOM = ClientFactory.CreateChannel<IBM30510>("BM00", "BM30510.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                //this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N")); 2015-04-27 사업장 비활성화 처리 로직 주석 처리 배명희(김도연과장님 요청)

                txt01_PARTNO.SetValid(40, AxTextBox.TextType.UAlphabet);

                this.cdx01_VINCD.HEPopupHelper = new Ax.SIS.CM.UI.CM30010P1("A3", true, true, this.cdx01_VINCD);

                cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1();
                cdx01_VENDCD.PopupTitle = this.GetLabel("VEND_INFO");// "업체정보"; 
                cdx01_VENDCD.CodeParameterName = "VENDCD";
                cdx01_VENDCD.NameParameterName = "VENDNM";
                cdx01_VENDCD.HEUserParameterSetValue("CORCD", UserInfo.CorporationCode);
                cdx01_VENDCD.HEUserParameterSetValue("LANG_SET", UserInfo.Language);

                this.cdx02_LINECD.HEPopupHelper = new Ax.SIS.CM.UI.CM30030P1(this.GetLabel("LINECD")); //new PM21310P1();
                this.cdx02_LINECD.CodeParameterName = "LINECD";
                this.cdx02_LINECD.NameParameterName = "LINENM";
                this.cdx02_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx02_LINECD.HEUserParameterSetValue("BIZCD", this.UserInfo.BusinessCode);
                this.cdx02_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx02_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx02_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx02_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx02_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

                this.grd01.Initialize();
                this.grd01.AllowEditing = false;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "Corporation", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "Business", "BIZCD","BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "P/NO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "P/NAME", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 30, "Rev", "REVISION", "REVISION");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 40, "CAR", "VINCD", "VINCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 50, "ITEM", "ITEMCD", "PRDT_DIV");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 40, "TYPE", "PRDT_DIV", "PRDT_DIV");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 40, "MIP", "MIPV_DIV", "MIPV_DIV");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "EO", "MCONO", "MCONO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "S/DATE", "EO_BEG_DATE", "EO_APP_DATE");
                this.grd01.Cols["EO_BEG_DATE"].Format = "yyyy-MM-dd";

                this.grd02.Initialize();
                this.grd02.AllowEditing = false;
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 30, "SEQ", "POS_SEQ", "POS_SEQ");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 65, "LEVEL", "LEV", "LEV");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Parent P/NO", "PPNO", "PPNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "Parent Part Name", "PPNM", "PPNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Child P/NO", "CPNO", "CPNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "Child Part Name", "CPNM", "CPNM");
              
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "Unit", "MEINS", "UNIT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "Usage", "USAGE", "USAGE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "A/Usage", "ACM_USG", "ACM_USG");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "EO", "MCONO", "MCONO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 80, "S/DATE", "EO_BEG_DATE", "EO_APP_DATE");
                this.grd02.Cols["EO_BEG_DATE"].Format = "yyyy-MM-dd";



                this.grd05.Initialize();
                this.grd05.AllowEditing = false;
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 65, "CAR", "VINCD", "VINCD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Parent P/NO", "PPNO", "PPNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "Child P/NO", "CPNO", "CPNO");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Child Part Name", "CPNM", "CPNM");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 50, "Unit", "MEINS", "UNIT");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "Usage", "USAGE", "USAGE");

                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "LINE", "LINECD", "LINECD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "LINE", "LINENM", "LINENM");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "VENDOR", "VENDCD", "VENDCD");
                this.grd05.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "VENDOR", "VENDNM", "VENDNM");

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
                if (tabControl1.SelectedIndex == 0)
                {
                    if (string.IsNullOrEmpty(txt01_PARTNO.GetValue().ToString()) && string.IsNullOrEmpty(cdx01_VINCD.GetValue().ToString()))
                    {
                        MsgBox.Show("You have to select the Car or Part Number");
                        return;
                    }
                    HEParameterSet paramSet = new HEParameterSet();

                    paramSet.Add("LANG_SET", this.UserInfo.Language);
                    paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                    paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                    paramSet.Add("STD_DATE", this.dtp01_APP_DATE.GetDateText());
                    paramSet.Add("VINCD", this.cdx01_VINCD.GetValue());
                    paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                    paramSet.Add("PRDT_DIV", radioButton1.Checked ? "A0A" : "A0S");


                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.Inquery(paramSet);
                    DataSet source = null;
                    if (RD_TOP_DOWN.Checked)
                    {
                        source = _WSCOM_N.ExecuteDataSet("APG_BM30510.INQUERY_TD", paramSet);
                    }
                    else
                    {
                        source = _WSCOM_N.ExecuteDataSet("APG_BM30510.INQUERY_WU", paramSet);
                    }
                    this.AfterInvokeServer();

                    this.grd01.SetValue(source.Tables[0]);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    if (string.IsNullOrEmpty(cdx02_LINECD.GetValue().ToString()) && string.IsNullOrEmpty(cdx01_VENDCD.GetValue().ToString()))
                    {
                        MsgBox.Show("You have to select the Line or Vendor");
                        return;
                    }
                    HEParameterSet paramSet = new HEParameterSet();

                    paramSet.Add("LANG_SET", this.UserInfo.Language);
                    paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                    paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                    paramSet.Add("STD_DATE", this.dtp01_APP_DATE.GetDateText());
                    paramSet.Add("VINCD", this.cdx01_VINCD.GetValue());
                    paramSet.Add("PARTNO", this.txt01_PARTNO.GetValue());
                    paramSet.Add("LINECD",cdx02_LINECD.GetValue());
                    paramSet.Add("VENDCD",cdx01_VENDCD.GetValue());
                    paramSet.Add("PRDT_DIV", RD_TOP_DOWN.Checked ? "A" : "M");

                    this.BeforeInvokeServer(true);
                    //DataSet source = _WSCOM.Inquery(paramSet);
                    DataSet source = _WSCOM_N.ExecuteDataSet("APG_BM30510.INQUERY_LEVEL_MAT", paramSet);
                    this.AfterInvokeServer();

                    this.grd05.SetValue(source.Tables[0]);
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

        private void BM30510_Load(object sender, EventArgs e)
        {
        }

        private void btn01_CHECK_BOM_Click(object sender, EventArgs e)
        {

        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button != MouseButtons.Left) return;

                if (this.grd01.Row < this.grd01.Rows.Fixed) return;

          
                HEParameterSet set = new HEParameterSet();

                set.Add("LANG_SET",this.UserInfo.Language);
                set.Add("CORCD", this.grd01.SelectedDataRow["CORCD"].Equals(System.DBNull.Value) ? "" : this.grd01.SelectedDataRow["CORCD"]);
                set.Add("BIZCD", this.grd01.SelectedDataRow["BIZCD"].Equals(System.DBNull.Value) ? "" : this.grd01.SelectedDataRow["BIZCD"]);               
                set.Add("PARTNO", this.grd01.SelectedDataRow["PARTNO"].Equals(System.DBNull.Value) ? "" : this.grd01.SelectedDataRow["PARTNO"]);
                set.Add("REVISION", this.grd01.SelectedDataRow["REVISION"]);
                this.BeforeInvokeServer();
                DataSet source = null;
                if (RD_TOP_DOWN.Checked)
                {
                    source = _WSCOM_N.ExecuteDataSet("APG_BM30510.INQUERY_TD_DETAIL", set);
                }
                else
                {
                    source = _WSCOM_N.ExecuteDataSet("APG_BM30510.INQUERY_WU_DETAIL", set);
                
                }
                this.AfterInvokeServer();

                this.grd02.SetValue(source.Tables[0]);
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




    }
}
