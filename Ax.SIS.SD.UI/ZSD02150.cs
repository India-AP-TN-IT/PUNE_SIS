using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Ax.DEV.Utility.Library;
using System.ServiceModel;
using TheOne.Windows.Forms;
using HE.Framework.ServiceModel;
using HE.Framework.Core;
using Ax.DEV.Utility.Controls;

namespace Ax.SIS.SD.UI
{
    /// <summary>
    /// <b> 협력 업체를 조회하는 클래스</b>
    /// - 작 성 일 : 2019-06-27<br/>
    /// - 주요 변경 사항<br/>
    ///     1) 2019-06-27 : 최초 클래스 생성.<br/>
    /// </summary>
    public partial class ZSD02150 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;

        public ZSD02150()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();
        }

        #region [초기화 작업 정의]
        protected override void UI_Shown(EventArgs e)
        {
            base.UI_Shown(e);
            try
            {
                // 법인
                cbo01_CORCD.DataBind_CORCD();
                cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                cbo01_CORCD.SetReadOnly(true);


                #region grd01
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 180, "SIS Program", "PGMID", "PGMID");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 150, "Excel Column", "EX_COL", "EX_COL");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 150, "Table Column", "TB_COL", "TB_COL");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 300, "REMARK", "REMARK", "REMARK");
                #endregion



                this.SetRequired(lbl01_CORCD);
            }
            catch (FaultException<ExceptionDetail> except)
            {
                MsgBox.Show(except.ToString());
            }
            finally
            {
            }
        }
        #endregion

        #region [공통 버튼에 대한 이벤트 정의]
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {

            try
            {


                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", cbo01_CORCD.GetValue());
                paramSet.Add("PGMID", Txt_PROGID.GetValue());
                paramSet.Add("EX_COL", Txt_EXCOL.GetValue());
                paramSet.Add("TB_COL", Txt_TBCOL.GetValue());

                DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02150.INQUERY", paramSet, "OUT_CURSOR");
                this.grd01.SetValue(source);
            }
            catch (FaultException<ExceptionDetail> except)
            {
                MsgBox.Show(except.ToString());
            }
            finally
            {
            }
        }
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "PGMID", "EX_COL", "TB_COL", "REMARK", "UPDATE_ID");
                DataSet delSR = this.grd01.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "PGMID", "TB_COL");
                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    source.Tables[0].Rows[i]["CORCD"] = UserInfo.CorporationCode;
                    source.Tables[0].Rows[i]["UPDATE_ID"] = UserInfo.UserID;
                }
                this.BeforeInvokeServer(true);
                if (source.Tables[0].Rows.Count > 0)
                {
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", "ZPG_ZSD02150", "SAVE"), source);
                }
                if (delSR.Tables[0].Rows.Count > 0)
                {
                    _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", "ZPG_ZSD02150", "DEL_DATA"), delSR);
                }


                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            base.BtnReset_Click(sender, e);
            Txt_EXCOL.SetValue("");
            Txt_TBCOL.SetValue("");
            Txt_PROGID.SetValue("");
        }


        #endregion

    }
}
