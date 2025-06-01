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

namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class TM21000 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _DB;

        #region [ 초기화 작업 정의 ]

        public TM21000()
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

                

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "TOOL No.", "EQNO", "EQNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "TOOL Name", "EQNM", "EQNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "Maker", "MAKER", "MAKER");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "Capacity", "CAPA", "CAPA");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "LEAST COUNT", "LCOUNT", "LCOUNT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 210, "A/CRITERIA", "ACRITERIA", "ACRITERIA");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "CALIBRATION DONE AT", "CALIB_PLACE", "CALIB_PLACE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 95, "C/DAYS", "FREQ_DAYS", "FREQ_DAYS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "Last C/DATE", "LAST_CALIB_DATE", "LAST_CALIB_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "Next C/DATE", "RE_CALIB_DATE", "RE_CALIB_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "SCOPE", "SCOPE", "SCOPE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "CERTIFICATE NUMBER", "LAST_CERT_NO", "LAST_CERT_NO");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "UPDATE_DATE", "UPDATE_DATE", "UPDATE_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "LAST_CALIB_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "RE_CALIB_DATE");

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "EQNO", "EQNM", "MAKER", "CAPA", "LCOUNT", "ACRITERIA", "CALIB_PLACE", "FREQ_DAYS"
                                , "LAST_CALIB_DATE", "SCOPE", "LAST_CERT_NO", "UPDATE_ID", "UPDATE_DATE");

                DataSet ds_del = grd01.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD", "EQNO");
                if (ds_del.Tables.Count > 0 && ds_del.Tables[0].Rows.Count > 0)
                {
                    _DB.ExecuteNonQueryTx("APG_TM21000.DEL_DATA", ds_del);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                    {
                        ds.Tables[0].Rows[row]["CORCD"] = cbo01_CORCD.GetValue().ToString();
                        ds.Tables[0].Rows[row]["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                        ds.Tables[0].Rows[row]["UPDATE_ID"] = UserInfo.UserID;
                    }
                    _DB.ExecuteNonQueryTx("APG_TM21000.SAVE", ds);

                }
                BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                
            }
            finally
            {
               
            }
        }
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                HEParameterSet param = new HEParameterSet();

                param.Add("CORCD", cbo01_CORCD.GetValue());
                param.Add("BIZCD", cbo01_BIZCD.GetValue());
                param.Add("EQNO", txt_GRP.GetValue());
                param.Add("EQNM", txt_PID.GetValue());
                DataSet ds = _DB.ExecuteDataSet("APG_TM21000.INQUERY", param);

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







    }
}

