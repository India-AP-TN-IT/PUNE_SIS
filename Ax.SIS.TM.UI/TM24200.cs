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
using System.Diagnostics;
using Ax.SIS.CM.UI;

namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class TM24200 : AxCommonBaseControl
    {
        private int m_cellLength = 0;
        private bool m_celldel = false;
        private AxClientProxy _WSCOM;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private const string _IntFormat = "###,###,###,###,##0";

        private const int IDX_CHECK_COLUMN = 1;//2019.04.16

        public TM24200()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
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

                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;


                                                                
                #region [grd01] [Search Condition]

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;


                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 180, "DIVISION", "DIV", "DIV");
               
               
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "T/CODE", "TYCD", "TYCD");
                this.grd01.Cols["TYCD"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 280, "T/NAME", "TYNM", "TYNM");
                this.grd01.Cols["TYNM"].Style.BackColor = Color.FromArgb(208, 253, 248);

                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");



                #endregion              
                

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        #region [공통버튼]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

               

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("DIV", "01");
                set.Add("TYCD", this.axTextBox1.GetValue());
                set.Add("TYNM", this.axTextBox2.GetValue());
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_TM24200.INQUERY", set, "OUT_CURSOR");

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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet sourceIU = this.grd01.GetValue(AxFlexGrid.FActionType.Save
                                                      , "CORCD"
                                                      , "BIZCD"
                                                      , "DIV"
                                                      , "TYCD"
                                                      , "TYNM"
                                                      , "UPDATE_ID"
                                                      
                                                    );

                DataSet sourceD = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                                                        "CORCD"
                                                      , "BIZCD"
                                                      , "DIV"
                                                      , "TYCD"
                                                    );

                if (sourceIU.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rows in sourceIU.Tables[0].Rows)
                    {
                        rows["TYCD"] = Convert.ToString(rows["TYCD"]).ToUpper();
                    }


                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_TM24200.DATA_SAVE", sourceIU);

                    this.AfterInvokeServer();
                }

                if (sourceD.Tables[0].Rows.Count > 0)
                {

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_TM24200.DATA_REMOVE", sourceD);

                    this.AfterInvokeServer();
                }


                this.BtnQuery_Click(null, null);

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

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                
                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                {
                    this.grd01.SetValue(i, "CORCD", cbo01_CORCD.GetValue());
                    this.grd01.SetValue(i, "BIZCD", cbo01_BIZCD.GetValue());
                    this.grd01.SetValue(i, "UPDATE_ID", this.UserInfo.UserID);
                    this.grd01.SetValue(i, "DIV", "01");
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

       
        #endregion


        private void grd01_RowInserting(object sender, AxFlexGrid.FAlterEventRow args)
        {
            string bizcd = cbo01_BIZCD.GetValue().ToString();
            if(string.IsNullOrEmpty(bizcd))
            {
                args.Cancel = true;
                MsgBox.Show("Business Code is mandatory for input!!");
                return;
            }
        }

        private void grd01_KeyPressEdit(object sender, C1.Win.C1FlexGrid.KeyPressEditEventArgs e)
        {
            if (grd01.Cols[e.Col].Name == "TYCD")
            {
                if (m_cellLength > 0 && m_celldel == true)
                {
                    e.Handled = false;
                    m_celldel = false;
                    return;
                }
                else if (m_cellLength < 4)
                {
                    char[] compchar = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

                    for (int i = 0; i < compchar.Length; i++)
                    {
                        if (compchar[i].ToString() == e.KeyChar.ToString().ToUpper())
                        {

                            m_cellLength++;
                            e.Handled = false;
                            return;
                        }
                    }
                    m_cellLength++;
                    e.Handled = true;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void grd01_StartEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            if (m_cellLength > 0 && grd01.Cols[e.Col].Name == "TYCD")
            {
                m_cellLength = 0;
            }
        }

        private void grd01_KeyDownEdit(object sender, C1.Win.C1FlexGrid.KeyEditEventArgs e)
        {
            if (grd01.Cols[e.Col].Name == "TYCD")
            {
                m_celldel = false;
                char keychar = (char)e.KeyCode;
                if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
                {
                    if (grd01.GetValue(e.Row, "TYCD").ToString().Length > 0)
                    {
                        m_cellLength = 0;
                    }

                    if (m_cellLength > 0)
                    {
                        m_cellLength--;
                    }
                    else
                    {
                        m_cellLength = 0;
                    }
                    m_celldel = true;
                }
            }
        }
    }
}
