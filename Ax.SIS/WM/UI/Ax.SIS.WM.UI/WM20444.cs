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

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class WM20444 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private const string _IntFormat = "###,###,###,###,##0";
        private string PKG_NAME = "MES.PKG_WM_IT_DEVICEMANAGEMENT.";

        private const int IDX_CHECK_COLUMN = 1;

        public WM20444()
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

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 24, "선택", "CHK", "CHK");//ADDED, 2019.04.16
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 140, "MAC ADDRESS", "MAC", "MAC");
                this.grd01.Cols["MAC"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "DEVICE NAME", "DEVICENM", "DEVICENM");
                //this.grd01.Cols["DEVICENM"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 100, "MANAGER", "MANAGER", "MANAGER");
                //this.grd01.Cols["MANAGER"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "POSITION", "POSITION", "POSITION");
                //this.grd01.Cols["POSITION"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "CHARSING YN", "CHARSING_YN", "CHARSING_YN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "CHARSING DATE", "CHARSING_DATE", "CHARSING_DATE");

                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "DAYAFTER", "DAYAFTER", "DAYAFTER");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");                           //2019.04.16
                //전체 선택 체크박스.                                                                   //2019.04.16
                C1.Win.C1FlexGrid.CellStyle cs = this.grd01.Styles.Add("Boolean");                     //2019.04.16
                cs.DataType = typeof(Boolean);                                                         //2019.04.16
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;                         //2019.04.16
                this.grd01.SetCellStyle(0, this.grd01.Cols["CHK"].Index, cs);                          //2019.04.16

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "CHARSING_DATE");
                
                DataTable combo_source_SLOT_YN = new DataTable();
                combo_source_SLOT_YN.Columns.Add("CODE");
                combo_source_SLOT_YN.Columns.Add("NAME");
                combo_source_SLOT_YN.Rows.Add("Y", "YES");
                combo_source_SLOT_YN.Rows.Add("N", "NO");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_SLOT_YN, "CHARSING_YN");

                this.cbo01_CHYN.DataBind(combo_source_SLOT_YN, true);
                this.cbo01_CHYN.DropDownStyle = ComboBoxStyle.DropDownList;

                HEParameterSet set = new HEParameterSet();
                set.Add("OBJID", "UY");
                set.Add("LANG", _LANG_SET);
                DataTable dtPOSITION = _WSCOM.ExecuteDataSet(PKG_NAME + "INQUERY_AXD0411", set, "OUT_CURSOR").Tables[0];

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, dtPOSITION, "POSITION");

                this.cbo01_POSITION.DataBind(dtPOSITION, true);
                this.cbo01_POSITION.DropDownStyle = ComboBoxStyle.DropDownList;
                #endregion              
                
                this.cbo01_POSITION.SelectedIndexChanged += new System.EventHandler(this.BtnQuery_Click);
                this.cbo01_CHYN.SelectedIndexChanged += new System.EventHandler(this.BtnQuery_Click);

                this.BtnQuery_Click(null, null);
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

                this.txt01_MAC.Value = this.txt01_MAC.GetValue().ToString().ToUpper();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("MAC", this.txt01_MAC.GetValue());
                set.Add("DEVICENM", this.txt01_DEVICENM.GetValue());
                set.Add("MANAGER", this.txt01_MANAGER.GetValue());
                set.Add("POSITION", this.cbo01_POSITION.GetValue());
                set.Add("CHARSING_YN", this.cbo01_CHYN.GetValue());
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet(PKG_NAME + "INQUERY", set, "OUT_CURSOR");

                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    string sDay = Convert.ToString(source.Tables[0].Rows[i]["DAYAFTER"]);

                    if (sDay == "Y") this.grd01.Rows[i+1].StyleNew.BackColor = Color.Red;
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet sourceIU = this.grd01.GetValue(AxFlexGrid.FActionType.Save
                                                      , "CORCD"
                                                      , "BIZCD"
                                                      , "MAC"
                                                      , "DEVICENM"
                                                      , "MANAGER"
                                                      , "POSITION"
                                                    );

                DataSet sourceD = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                                                        "CORCD"
                                                      , "BIZCD"
                                                      , "MAC"
                                                    );

                if (sourceIU.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rows in sourceIU.Tables[0].Rows)
                    {
                        rows["MAC"] = Convert.ToString(rows["MAC"]).ToUpper();
                    }

                    if (!IsSaveValid(sourceIU)) return;

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx(PKG_NAME + "SAVE_WMSDEVICE", sourceIU);

                    this.AfterInvokeServer();
                }

                if (sourceD.Tables[0].Rows.Count > 0)
                {
                    if (!IsDeleteValid(sourceD)) return;

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx(PKG_NAME + "REMOVE_WMSDEVICE", sourceD);

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
                    this.grd01.SetValue(i, "CORCD", this.UserInfo.CorporationCode);
                    this.grd01.SetValue(i, "BIZCD", this.UserInfo.BusinessCode);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_MouseClick(object sender, MouseEventArgs e)
        {
            //Trace.WriteLine(this.grd01.MouseCol.ToString());
            if (this.grd01.MouseCol == IDX_CHECK_COLUMN)
            {
                if (this.grd01.MouseRow == 0)
                {
                    string s_value = this.grd01.GetValue(0, "CHK").ToString();
                    for (int j_cnt = this.grd01.Rows.Fixed; j_cnt < this.grd01.Rows.Count; j_cnt++)
                    {
                        this.grd01.SetValue(j_cnt, "CHK", s_value == "Y" ? "1" : "0");
                    }
                }
                else
                {
                    string s_all_check = this.grd01.GetValue(0, "CHK").ToString();
                    string s_single = this.grd01.GetValue(this.grd01.MouseRow, "CHK").ToString();
                    if (s_single != "Y" && s_all_check == "Y") this.grd01.SetValue(0, "CHK", "0");
                }
            }
        }
        #endregion

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

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    string LOCNO = source.Tables[0].Rows[i]["MAC"].ToString().ToUpper();

                    if (this.GetByteCount(LOCNO) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {LOC_NO}가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i.ToString(), this.grd01.Cols[2].Caption.ToString());
                        return false;
                    }
                }



                //저장하시겠습니까?
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

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


                if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }
        #endregion

        private void txt01_Query_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnQuery_Click(null, null);
            }
        }

    }
}
