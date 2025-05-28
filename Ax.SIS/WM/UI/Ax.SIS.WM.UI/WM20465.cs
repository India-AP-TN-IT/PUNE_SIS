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
using C1.Win.C1FlexGrid;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class WM20465 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private const string _IntFormat = "###,###,###,###,##0";

        private const int IDX_CHECK_COLUMN = 1;//2019.04.16

        public WM20465()
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

                #region [그리드1]
                
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "P/DIV", "PRDT_DIV", "PRDT_DIV");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "Part Prefix Code", "PART_PAT", "PART_PAT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 220, "Part Description", "PARTDESC", "PARTDESC");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "S/QTY", "STUFF_QTY", "STUFF_QTY");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "S/COLS", "STUFF_COL", "STUFF_COL");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "S/ROWS", "STUFF_ROW", "STUFF_ROW");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 110, "BOX TYPE", "BOX_TYPE", "BOX_TYPE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "LINE", "SFG_TYPE", "SFG_TYPE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 120, "PLANT", "CUST_PLANT", "CUST_PLANT");
         

                DataTable combo_source_BOX_TYPE = new DataTable();
                combo_source_BOX_TYPE.Columns.Add("CODE");
                combo_source_BOX_TYPE.Columns.Add("NAME");
                combo_source_BOX_TYPE.Rows.Add("BIN", "BIN");
                combo_source_BOX_TYPE.Rows.Add("TROLLEY", "TROLLEY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_BOX_TYPE, "BOX_TYPE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "W5", "SFG_TYPE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "A0", "PRDT_DIV");


                this.grd02.AllowEditing = true;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AllowSorting = AllowSortingEnum.None;
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd02.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 100, "P/DIV", "PRDT_DIV", "PRDT_DIV");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "Part Prefix Code", "PART_PAT", "PART_PAT");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 220, "Part Description", "PARTDESC", "PARTDESC");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "S/QTY", "STUFF_QTY", "STUFF_QTY");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "S/COLS", "STUFF_COL", "STUFF_COL");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "S/ROWS", "STUFF_ROW", "STUFF_ROW");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 110, "BOX TYPE", "BOX_TYPE", "BOX_TYPE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "PLANT", "CUST_PLANT", "CUST_PLANT");

                DataTable combo_source_PLANT = new DataTable();
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                combo_source_PLANT = _WSCOM.ExecuteDataSetTx("APG_WM20461.PLANT", set).Tables[0];
                
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_PLANT, "CUST_PLANT",true, false);
                this.grd02.SetColumnType(AxFlexGrid.FCellType.ComboBox, combo_source_BOX_TYPE, "BOX_TYPE");
               
                #endregion
                
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

                HEParameterSet set = new HEParameterSet();
                DataSet source = null;
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PART_PAT", this.axTextBox1.GetValue());
                set.Add("PARTDESC", this.txt01_PGNDESC.GetValue());
                set.Add("PRDT_DIV", PRDT_DIV());

                this.BeforeInvokeServer(true);

                source = _WSCOM.ExecuteDataSet("APG_WM20461.INQUERY", set, "OUT_CURSOR");

                this.AfterInvokeServer();
                if (tabControl1.SelectedIndex == 0)
                {
                    this.grd01.SetValue(source.Tables[0]);
                }
                else if(tabControl1.SelectedIndex == 1)
                {
                    this.grd02.SetValue(source.Tables[0]);
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
        private string PRDT_DIV()
        {
            if(tabControl1.SelectedIndex == 0)
            {
                return "A0S";
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                return "A0A";
            }
            return "A0S";
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet sourceIU = null;
                DataSet sourceD = null;
                if(tabControl1.SelectedIndex == 0)
                {
                    sourceIU = this.grd01.GetValue(AxFlexGrid.FActionType.Save
                                                              , "CORCD"
                                                              , "BIZCD"
                                                              , "PRDT_DIV"
                                                              , "PART_PAT"
                                                              , "PARTDESC"
                                                              , "STUFF_QTY"
                                                              , "STUFF_COL"
                                                              , "STUFF_ROW"
                                                              , "BOX_TYPE"
                                                              , "SFG_TYPE"
                                                              , "CUST_PLANT"
                                                            );

                    sourceD = this.grd01.GetValue(AxFlexGrid.FActionType.Remove
                                                          , "CORCD"
                                                          , "BIZCD"
                                                          , "PART_PAT"
                                                          , "CUST_PLANT"
                                                       );
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    sourceIU = this.grd02.GetValue(AxFlexGrid.FActionType.Save
                                                              , "CORCD"
                                                              , "BIZCD"
                                                              , "PRDT_DIV"
                                                              , "PART_PAT"
                                                              , "PARTDESC"
                                                              , "STUFF_QTY"
                                                              , "STUFF_COL"
                                                              , "STUFF_ROW"
                                                              , "BOX_TYPE"
                                                              , "SFG_TYPE"
                                                              , "CUST_PLANT"
                                                            );

                    sourceD = this.grd02.GetValue(AxFlexGrid.FActionType.Remove
                                                          , "CORCD"
                                                          , "BIZCD"
                                                          , "PART_PAT"
                                                          , "CUST_PLANT"
                                                       );
                }
                

                if (sourceIU.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rows in sourceIU.Tables[0].Rows)
                    {
                        rows["PART_PAT"] = Convert.ToString(rows["PART_PAT"]).ToUpper();
                        rows["CORCD"] =UserInfo.CorporationCode;
                        rows["BIZCD"] =UserInfo.BusinessCode;
                        rows["PRDT_DIV"] = PRDT_DIV();
                        if(tabControl1.SelectedIndex==1)
                        {
                            if(string.IsNullOrEmpty(rows["CUST_PLANT"].ToString()))
                            {
                                MsgBox.Show("Customer Plant has to be assigned!!", "Error", MessageBoxButtons.OK);
                                return;
                            }
                        }
                    }

                    if (!IsSaveValid(sourceIU)) return;

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_WM20461.DATA_SAVE", sourceIU);

                    this.AfterInvokeServer();
                }

                if (sourceD.Tables[0].Rows.Count > 0)
                {
                    if (!IsDeleteValid(sourceD)) return;

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_WM20461.DATA_REMOVE", sourceD);

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
        private void grd_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;

                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                {
                    grd.SetValue(i, "CORCD", this.UserInfo.CorporationCode);
                    grd.SetValue(i, "BIZCD", this.UserInfo.BusinessCode);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
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
