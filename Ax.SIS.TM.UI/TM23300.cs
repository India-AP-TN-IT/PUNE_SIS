#region ▶ Description & History
/* 
 * 프로그램명 : PD40520 금형투입이력 조회
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


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using HE.Framework.ServiceModel;
using HE.Framework.Core.Report;
using System.Drawing;
using System.IO;

namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class TM23300 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _DB;

        #region [ 초기화 작업 정의 ]

        public TM23300()
        {
            InitializeComponent();

            _DB = new AxClientProxy();
            
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                //CORCD
                cbo01_CORCD.DataBind_CORCD();
                cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                cbo01_CORCD.SetReadOnly(true);
                //BIZCD
                cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;

                

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                //PARTNO	PARTNM	SPEC	IMG	MAKER	WHEREUSED	RACK	LOC	UOM	MIN	MAX	GRADE


                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "Part No.", "PARTNO", "PARTNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "Part Name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "MAKER", "MAKER", "MAKER");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 50, "Unit", "UOM", "UOM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "QTY", "CUR_QTY", "CUR_QTY");


                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "LOT", "LOTNO", "LOTNO");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "Status", "INV_STATUS", "INV_STATUS");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "Scan Date", "SCAN_DATE", "SCAN_DATE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "Location", "LOC", "LOC");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 90, "QTY", "CUR_QTY", "CUR_QTY");

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

                HEParameterSet param = new HEParameterSet();

                param.Add("CORCD", cbo01_CORCD.GetValue());
                param.Add("BIZCD", cbo01_BIZCD.GetValue());
                param.Add("PARTNO", txt_GRP.GetValue());
                param.Add("PARTNM", txt_PID.GetValue());
                DataSet ds = _DB.ExecuteDataSet("APG_TM23300.INQUERY", param);

                grd01.SetValue(ds);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
               
            }
            finally
            {
            }
        }
        
        #endregion

        private void GetDET(string partno)
        {
            HEParameterSet param = new HEParameterSet();

            param.Add("CORCD", cbo01_CORCD.GetValue());
            param.Add("BIZCD", cbo01_BIZCD.GetValue());
            param.Add("PARTNO", partno);
            DataSet ds = _DB.ExecuteDataSet("APG_TM23300.INQUERY_DET", param);

            grd02.SetValue(ds);

        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = grd01.Row;
            int col = grd01.Col;

            GetDET(grd01.GetValue(row, "PARTNO").ToString());
            
        }








    }
}

