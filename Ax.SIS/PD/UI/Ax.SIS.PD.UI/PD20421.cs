#region ▶ Description & History
/* 
 * 프로그램명 : PD20421 고압사출 성형 조건 변경 현황
 * 설     명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 최종수정자 : 
 * 최종수정일 : 
 * 수정  내용 : 
 * 
 *				날짜			    작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09      배명희         SIS 이관
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
using C1.Win.C1FlexGrid;
using System.Drawing;

using Ax.SIS.PD.UI.Properties;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
//using Microsoft.Office.Interop.Excel;


namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>고압사출 성형 변경 현황</b>    
    /// </summary>
    public partial class PD20421 : AxCommonBaseControl
    {
        //private IPD20421 _WSCOM;
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD20420";
        private string PACKAGE_NAME_COMMON = "APG_COMMON";        
        private bool _isLoadCompleted = false;

        public PD20421()
        {
            InitializeComponent();
            //_WSCOM = ClientFactory.CreateChannel<IPD20421>("PM00", "PD20421.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                HEParameterSet param = new HEParameterSet();
                param.Add("CORCD", UserInfo.CorporationCode);
                param.Add("LANG_SET", UserInfo.Language);

                System.Collections.Generic.List<HEParameterSet> paramList = new System.Collections.Generic.List<HEParameterSet> { param };
                DataSet source = _WSCOM.MultipleExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_COMMON, "INQUERY_BIZCD"), paramList);

                source.Tables[0].DefaultView.RowFilter = "BIZCD IN ('1001', '1002')"; //울산, 아산만
                DataTable dtSource = source.Tables[0].DefaultView.ToTable();

                this.cbo01_BIZCD.DataBind(dtSource, false);

                this.cbo01_MASTER_ITEM.DataBind("QF");
                this.cbo01_SUB_ITEM.DataBind("QG");

                this.grd01.Initialize();
                this.grd01.AllowEditing = true;
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.SelectionMode = SelectionModeEnum.Cell;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "금형번호", "MOLDNO", "MOLDNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차종", "VINNM", "VIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "금형명", "MOLDNM", "MOLDNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "대항목", "MASTER_ITEM", "MASTER_ITEM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "조건항목", "SUB_ITEM", "SUB_ITEM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "값", "ITEM_VALUE", "ITEM_VALUE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "사유", "ITEM_REASON", "REASON");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "변경 값", "CHANGE_VALUE", "CHANGE_VALUE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "변경사유", "CHANGE_REASON", "AMDREASON");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "변경일자", "STD_DATE", "CHANGE_DATE");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetCorCD().Tables[0], "CORCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], "BIZCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "QF", "MASTER_ITEM");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "QG", "SUB_ITEM");

                this.grd01.CurrentContextMenu.Items[0].Visible = false;
                this.grd01.CurrentContextMenu.Items[1].Visible = false;
                this.grd01.CurrentContextMenu.Items[2].Visible = false;
                this.grd01.CurrentContextMenu.Items[3].Visible = false;

                this.SetRequired(this.lbl01_BIZNM2);

                _isLoadCompleted = true;
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
                if (!IsQueryValid())
                    return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("MOLDNO", this.txt01_MOLDNO.GetValue().ToString());
                paramSet.Add("MASTER_ITEM", this.cbo01_MASTER_ITEM.GetValue());
                paramSet.Add("SUB_ITEM", this.cbo01_SUB_ITEM.GetValue().ToString());
                paramSet.Add("BEG_DATE", this.dtp01_BEG_DATE.GetDateText().ToString());
                paramSet.Add("END_DATE", this.dtp01_END_EDATE.GetDateText().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet, this.cbo01_BIZCD.GetValue().ToString());
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PD20421"), paramSet, "OUT_CURSOR");
                this.grd01.SetValue(source.Tables[0]);

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
            finally
            {
                this.AfterInvokeServer();
            }
        }

        #endregion

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        #endregion

        #region [ 유효성 검사 ]

        private bool IsQueryValid()
        {
            try
            {

                //if (this.cbo01_BIZCD.IsEmpty)
                //{
                //    MsgCodeBox.ShowFormat("MM00-0001", lbl01_BIZNM.GetValue());   //{0}를(을) 입력해주세요.
                //    this.cbo01_BIZCD.Focus();
                //    return false;
                //}

                //if (this.cbo01_SUB_ITEM.IsEmpty)
                //{
                //    MsgCodeBox.ShowFormat("MM00-0001", lbl01_SUB_ITEM.GetValue());   //{0}를(을) 입력해주세요.
                //    this.cbo01_SUB_ITEM.Focus();
                //    return false;
                //}

                //if (this.cbl01_VINCD.IsEmpty)
                //{
                //    MsgCodeBox.ShowFormat("MM00-0001", lbl01_VIN.GetValue());   //{0}를(을) 입력해주세요.
                //    this.cbo01_TYPE.Focus();
                //    return false;
                //}

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        #endregion
    }
}
