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
          
namespace Ax.SIS.BM.BM00.UI
{
    /// <summary>
    /// <b> 협력 업체를 조회하는 클래스</b>
    /// - 작 성 일 : 2019-06-27<br/>
    /// - 주요 변경 사항<br/>
    ///     1) 2019-06-27 : 최초 클래스 생성.<br/>
    /// </summary>
    public partial class BM30301 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;

        public BM30301()
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
                //사업장
                cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;

                #region grd01
                //this.grd01.PopMenuVisible = false;
                this.grd01.AllowEditing = true;
                //this.grd01.AllowAddNew = false;
                //this.grd01.AllowDelete = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 100, "Vendor Code", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 300, "Vendor Name", "VENDNM", "VENDNM");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 100, "Telephone", "REP_TELNO", "TELNO");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 100, "FAX", "REP_FAXNO", "FAXNO");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 160, "E-Mail", "REP_EMAIL", "EMAIL");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 100, "ZIP CODE", "ZIPCD", "ZIPCD");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 640, "Address", "ADDR", "ADDRESS");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 150, "Distance", "DISTA", "DISTA");//
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 150, "GST NO", "STCD3", "STCD3");//사업자코드
                #endregion

                txt01_VENDCD.Initialize();
                txt01_VENDNM.Initialize();

                this.SetRequired(lbl01_CORCD, lbl01_BIZCD);
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
            //base.BtnQuery_Click(sender, e);
            try
            {
                if (IsQueryValid()) return;

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", UserInfo.CorporationCode);
                paramSet.Add("BIZCD", UserInfo.BusinessCode);

                paramSet.Add("VENDCD", txt01_VENDCD.Text);
                paramSet.Add("VENDNM", txt01_VENDNM.Text);
                paramSet.Add("DELETE_YN", "");

                DataSet source = _WSCOM_N.ExecuteDataSet("APG_BM30301.INQUERY", paramSet, "OUT_CURSOR");
                if (null != source && null != source.Tables[0])
                {
                    this.grd01.SetValue(source);
                }
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
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "VENDCD", "ADDR","DISTA");

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    source.Tables[0].Rows[i]["CORCD"] = UserInfo.CorporationCode;
                    source.Tables[0].Rows[i]["BIZCD"] = bizcd;
                }
                this.BeforeInvokeServer(true);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", "APG_BM30301", "SET_ADDR"), source);


                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show(" 저장되었습니다.");
                MsgCodeBox.Show("CD00-0071");
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
        }


        #endregion

        #region [유효성 검사]
        private bool IsQueryValid()
        {
            bool ret_process = false;

            do
            {
                if (cbo01_CORCD.ByteCount == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_CORCD.Text); // this.GetLabel("LINECD"));
                    ret_process = true;
                    break;
                }

                if (cbo01_BIZCD.ByteCount == 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZCD.Text); // this.GetLabel("LINECD"));
                    ret_process = true;
                    break;
                }
            } while (false);

            return ret_process;
        }
        #endregion
    }
}
