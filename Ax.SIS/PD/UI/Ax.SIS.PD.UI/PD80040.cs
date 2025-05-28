using System;
using System.Data;
using System.ServiceModel;

using System.Drawing;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using Ax.DEV.Utility.Library;
using HE.Framework.Core.Report;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class PD80040 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private const string _IntFormat = "###,###,###,###,##0";

        public PD80040()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;
                                                                
                #region [ grd01 ]

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);

                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "USERID", "USERID", "USERID");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 80, "ORD_SEQ", "ORD_SEQ", "ORDER SEQ");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "CLIENT_ID", "CLIENT_ID", "CLIENT_ID");
                this.grd01.Cols["CLIENT_ID"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "PC_IP", "PC_IP", "PC_IP");
                this.grd01.Cols["PC_IP"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "PC_NM", "PC_NM", "PC_NM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "SCREEN_ID", "SCREEN_ID", "SCREEN_ID");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "LINECD", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "PROGRAM_ID", "PROGRAM_ID", "PROGRAM_ID");
                
                #endregion

                DataSet dsMTY = AxFlexGrid.GetDataSourceSchema("CODE", "NAME");
                dsMTY.Tables[0].Rows.Add("Y", "Y");
                dsMTY.Tables[0].Rows.Add("N", "N");
                this.cbo01_MAPYN.DataBind(dsMTY.Tables[0]);

                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #region [공통버튼]
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            txt01_CLIENT_ID.Text = "";
            txt01_PC_IP.Text = "";
            cbo01_MAPYN.Initialize();

            this.BtnQuery_Click(null, null);
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {

            DataSet sourceIU = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                                                    "CORCD"
                                                  , "BIZCD"
                                                  , "CLIENT_ID"
                                                  , "PC_IP"
                                                  , "USERID"
                                                );

            DataSet sourceD = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                                                    "CORCD"
                                                  , "BIZCD"
                                                  , "CLIENT_ID"
                                                  , "USERID"
                                                );


            if (sourceIU.Tables[0].Rows.Count + sourceD.Tables[0].Rows.Count > 0)
            {
                //저장하시겠습니까?
                DialogResult dr = MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    if (sourceIU.Tables[0].Rows.Count > 0)
                    {
                        if (!IsSaveValid(sourceIU)) return;
                    }

                    if (sourceD.Tables[0].Rows.Count > 0)
                    {
                        if (!IsDeleteValid(sourceD)) return;
                    }

                    this.SAVE(sourceIU, sourceD);
                }
                else if (dr == DialogResult.Cancel)
                {
                    return;
                }
            }

            this.INQUERY();

        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet sourceIU = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                                                        "CORCD"
                                                      , "BIZCD"
                                                      , "CLIENT_ID"
                                                      , "PC_IP"
                                                      , "USERID"
                                                    );

                DataSet sourceD = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                                                        "CORCD"
                                                      , "BIZCD"
                                                      , "CLIENT_ID"
                                                      , "USERID"
                                                    );


                if (sourceIU.Tables[0].Rows.Count + sourceD.Tables[0].Rows.Count == 0) return;
                
                this.SAVE(sourceIU, sourceD);

                this.INQUERY();

                //저장되었습니다.
                MsgCodeBox.Show("CD00-0071");
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

        #region [컨트롤 이벤트]
        private void INQUERY()
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("CLIENT_ID", this.txt01_CLIENT_ID.GetValue());
                set.Add("PC_IP", this.txt01_PC_IP.GetValue());
                set.Add("ASSIGNYN", this.cbo01_MAPYN.GetValue());
                set.Add("USERID", this.UserInfo.UserID);

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_PD80040.INQUERY", set, "OUT_CURSOR");

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

        private void SAVE(DataSet sourceIU, DataSet sourceD)
        {
            if (sourceIU.Tables[0].Rows.Count > 0)
            {
                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx("APG_PD80040.DATA_SAVE", sourceIU);

                this.AfterInvokeServer();
            }

            if (sourceD.Tables[0].Rows.Count > 0)
            {
                this.BeforeInvokeServer(true);

                _WSCOM.ExecuteNonQueryTx("APG_PD80040.DATA_REMOVE", sourceD);

                this.AfterInvokeServer();
            }
        }
        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }

                //저장하시겠습니까?
                //if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDeleteValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //저장할 데이터가 존재하지 않습니다..
                    MsgCodeBox.Show("CD00-0041");
                    return false;
                }


                //if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }
        #endregion

        private void txt01_PC_IP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.BtnQuery_Click(null, null);
            }

            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)) || e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }
        private void cbo01_MAPYN_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BtnQuery_Click(null, null);
        }

    }
}
