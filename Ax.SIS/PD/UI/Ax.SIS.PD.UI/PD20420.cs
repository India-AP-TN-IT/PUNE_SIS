#region ▶ Description & History
/* 
 * 프로그램명 : PD20420 고압사출 성형 조건 변경 관리
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
using Excel = Microsoft.Office.Interop.Excel;
using Ax.SIS.PD.UI.Properties;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
//using Microsoft.Office.Interop.Excel;


namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>고압사출 성형 변경 관리</b>    
    /// </summary>
    public partial class PD20420 : AxCommonBaseControl
    {
        //private IPD20420 _WSCOM;
        private AxClientProxy _WSCOM;
        private string PACKAGE_NAME = "APG_PD20420";
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private bool _isLoadCompleted = false;
        private int _MaxRow = 0;
        private bool isDoubleClick = false;

        public PD20420()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IPD20420>("PM00", "PD20420.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
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
                DataSet source = _WSCOM.MultipleExecuteDataSet(string.Format("{0}.{1}", "APG_COMMON", "INQUERY_BIZCD"), paramList);

                source.Tables[0].DefaultView.RowFilter = "BIZCD IN ('1001', '1002')"; //울산, 아산만
                DataTable dtSource = source.Tables[0].DefaultView.ToTable();

                this.cbo01_BIZCD.DataBind(dtSource, false);

                this.cbo01_MASTER_ITEM.DataBind("QF");
                this.cbo01_SUB_ITEM.DataBind("QG");

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                //DataTable source = _WSCOM_ERM.INQUERY_COMBO_CARTYPE(set).Tables[0];

                this.cdx01_MOLDNO.HEPopupHelper = new PD20420P1();
                this.cdx01_MOLDNO.PopupTitle = this.GetLabel("MOLDNO");
                this.cdx01_MOLDNO.CodeParameterName = "MOLDNO";
                this.cdx01_MOLDNO.NameParameterName = "MOLDNM";
                this.cdx01_MOLDNO.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_MOLDNO.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_MOLDNO.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);

                this.grd01.Initialize();
                this.grd01.AllowEditing = true;
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.SelectionMode = SelectionModeEnum.Cell;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "사업장코드", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "금형번호", "MOLDNO", "MOLDNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차종", "VINNM", "VIN");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "금형명", "MOLDNM", "MOLDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "대항목", "MASTER_ITEM", "MASTER_ITEM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "조건항목", "SUB_ITEM", "SUB_ITEM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "값", "ITEM_VALUE", "ITEM_VALUE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "사유", "ITEM_REASON", "REASON");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "변경 값", "CHANGE_VALUE", "CHANGE_VALUE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 180, "변경사유", "CHANGE_REASON", "AMDREASON");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.L, 080, "출력", "CHK", "PRINT");
                this.grd01.AddHiddenColumn("SEQ");
                this.grd01.AddHiddenColumn("STATUS");
                this.grd01.AddHiddenColumn("MASTER_ITEMNM");
                this.grd01.AddHiddenColumn("SUB_ITEMNM");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetCorCD().Tables[0], "CORCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], "BIZCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "QF", "MASTER_ITEM");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "QG", "SUB_ITEM");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");

                this.grd02.Initialize();
                this.grd02.AllowEditing = true;
                this.grd02.AllowSorting = AllowSortingEnum.None;
                this.grd02.SelectionMode = SelectionModeEnum.Cell;

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "법인코드", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "사업장코드", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "금형번호", "MOLDNO", "MOLDNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "차종", "VINNM", "VIN");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 200, "금형명", "MOLDNM", "MOLDNM");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "출력", "CHK", "PRINT");

                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");
                this.grd02.Cols["CHK"].StyleNew.BackColor = Color.LightYellow;

                this.grd02.CurrentContextMenu.Items[0].Visible = false;
                this.grd02.CurrentContextMenu.Items[1].Visible = false;
                this.grd02.CurrentContextMenu.Items[2].Visible = false;
                this.grd02.CurrentContextMenu.Items[3].Visible = false;

                CellStyle cs;
                cs = this.grd01.Styles.Add("csYellow");
                cs.BackColor = Color.LightYellow;//Color.FromArgb(255, 166, 166);
                //cs.ForeColor = Color.Black;
                cs = this.grd01.Styles.Add("csTrans");
                cs.BackColor = Color.Transparent;

                this.grd01.RowInserted += new AxFlexGrid.FAlterRowInsertEventHandler(grd01_RowInserted);

                this.grd01.CurrentContextMenu.Items[1].Visible = false;

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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save,
                    "CORCD", "BIZCD", "MOLDNO", "MASTER_ITEM", "SUB_ITEM",
                    "ITEM_VALUE", "ITEM_REASON", "CHANGE_VALUE", "CHANGE_REASON", "UPDATE_ID", "SEQ", "STATUS", "LANG_SET");

                for (int i = 0; i < source.Tables[1].Rows.Count; i++)
                {
                    DataRow seq = source.Tables[1].Rows[i];
                    source.Tables[0].Rows[i]["SEQ"] = seq["GRIDSEQ"];
                    source.Tables[0].Rows[i]["STATUS"] = this.grd01.Rows[Convert.ToInt32(seq["GRIDSEQ"])][0];
                    source.Tables[0].Rows[i]["UPDATE_ID"] = this.UserInfo.UserID;
                    source.Tables[0].Rows[i]["LANG_SET"] = this.UserInfo.Language;
                }                

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source, this.cbo01_BIZCD.GetValue().ToString());
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer(); 

                this.BtnQuery_Click(null, null);

                //정상적으로 저장되었습니다.
                MsgCodeBox.Show("CD00-0009");
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                if (ex.Message.ToString().Split('|').Length > 1)
                {
                    MessageBox.Show(ex.Message.ToString().Split('|')[1]);
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }

        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //MsgBox.Show("빈 폴더를 선택해 주세요!!");
                MsgCodeBox.Show("CD00-0119"); //빈 폴더를 선택해 주세요!! //@@@ 
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                if (fbd.ShowDialog() != DialogResult.OK) return;

                this.BeforeInvokeServer(true);

                string filename = "";
                byte[] file = null;
                string filefullname = "";

                filename = "RptPressInjection.xlsx";
                file = Resources.RptPressInjection;
                filefullname = string.Format(@"{0}\{1}", fbd.SelectedPath, filename);

                if (File.Exists(filefullname))
                    File.Delete(filefullname);

                int ArraySize = file.GetUpperBound(0);

                FileStream stream = new FileStream(filefullname, FileMode.OpenOrCreate, FileAccess.Write);
                stream.Write(file, 0, ArraySize + 1);
                stream.Close();

                this.SaveExcelDetail(filefullname);

                this.AfterInvokeServer();

                //MsgBox.Show("선택하신 정보가 출력 완료 되었습니다.");
                MsgCodeBox.Show("CD00-0101");//출력되었습니다.
                Process.Start(fbd.SelectedPath);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        //protected override void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataSet source = this.grd01.GetValue(HEFlexGrid.FActionType.Remove,
        //            "CORCD", "BIZCD", "YYYY", "CHK_SEQ", "PLT_NO");

        //        //foreach (DataRow dr in source.Tables[0].Rows)
        //        //{
        //        //    dr["YYYY"] = this.dte01_YYYY.GetValue();
        //        //}

        //        if (!IsDeleteValid(source)) return;

        //        this.BeforeInvokeServer(true);
        //        //_WSCOM.Remove(source, this.cbo01_BIZCD.GetValue().ToString());
        //        _WSCOM.ExecuteNonQueryTx("PKG_PD20420.REMOVE", source);

        //        this.AfterInvokeServer();

        //        this.BtnQuery_Click(null, null);

        //        //메세지 코드 처리
        //        MsgCodeBox.Show("CD00-0010");
                
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        this.AfterInvokeServer();
        //    }
        //}

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
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet, this.cbo01_BIZCD.GetValue().ToString());
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet, "OUT_CURSOR");
                this.grd01.SetValue(source.Tables[0]);

                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "QG", "SUB_ITEM");

                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    //this.grd01.Cols["MOLDNO"].StyleNew.BackColor = Color.Transparent;
                    //this.grd01.Cols["MASTER_ITEM"].StyleNew.BackColor = Color.Transparent;
                    //this.grd01.Cols["SUB_ITEM"].StyleNew.BackColor = Color.Transparent;
                    //this.grd01.Cols["ITEM_VALUE"].StyleNew.BackColor = Color.Transparent;
                    //this.grd01.Cols["ITEM_REASON"].StyleNew.BackColor = Color.Transparent;
                    grd01.Rows[i].StyleNew.Clear();
                }

                this.grd01.Cols["CHANGE_VALUE"].StyleNew.BackColor = Color.LightYellow;
                this.grd01.Cols["CHANGE_REASON"].StyleNew.BackColor = Color.LightYellow;
                this.grd01.Cols["CHK"].StyleNew.BackColor = Color.LightYellow;

                DetailQuery();

                //ShowDataCount(source);
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

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                if (GetByteCount(this.cbo01_BIZCD.GetValue().ToString()) == 0)
                {
                    //메세지 코드 처리
                    //MsgCodeBox.Show("PD00-0040");
                    //MsgBox.Show("사업장 정보가 선택되지 않았습니다.");
                    MsgCodeBox.ShowFormat("CD00-0080", this.lbl01_BIZNM2.Text); //{0}가(이) 선택되지 않았습니다. //@@@

                    //this.grd01.Rows.Remove(args.RowIndex);
                    this.BtnQuery_Click(null, null);
                    return;
                }

                for (int i = 0; i < args.RowCount; i++)
                {
                    //신규행 추가시 기본 값 설정
                    this.grd01.SetValue(args.RowIndex + i, "CORCD", this.UserInfo.CorporationCode);
                    this.grd01.SetValue(args.RowIndex + i, "BIZCD", this.cbo01_BIZCD.GetValue());
                    this.grd01.SetValue(args.RowIndex + i, "CHK", " ");

                    this.grd01.SetCellStyle(args.RowIndex + i, this.grd01.Cols["MOLDNO"].Index, "csYellow");
                    this.grd01.SetCellStyle(args.RowIndex + i, this.grd01.Cols["MASTER_ITEM"].Index, "csYellow");
                    this.grd01.SetCellStyle(args.RowIndex + i, this.grd01.Cols["SUB_ITEM"].Index, "csYellow");
                    this.grd01.SetCellStyle(args.RowIndex + i, this.grd01.Cols["ITEM_VALUE"].Index, "csYellow");
                    this.grd01.SetCellStyle(args.RowIndex + i, this.grd01.Cols["ITEM_REASON"].Index, "csYellow");
                    this.grd01.SetCellStyle(args.RowIndex + i, this.grd01.Cols["CHANGE_VALUE"].Index, "csTrans");
                    this.grd01.SetCellStyle(args.RowIndex + i, this.grd01.Cols["CHANGE_REASON"].Index, "csTrans");
                    this.grd01.SetCellStyle(args.RowIndex + i, this.grd01.Cols["CHK"].Index, "csTrans");
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_isLoadCompleted == true)
                {
                    //BtnQuery_Click(null, null);

                    //string strEventName = "";
                    //strEventName = ((ComboBox)(sender)).Name;

                    //if (GetByteCount(strEventName) > 0)
                    //{
                    //    BtnQuery_Click(null, null);
                    //}
                }

                //this.cdx01_MOLDNO.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        
        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.isDoubleClick = true;

                int tmpCol = this.grd01.Col;
                int tmpRow = this.grd01.SelectedRowIndex;

                this.cdx01_MOLDNO.Initialize();

                if (this.grd01.Row > 0
                    && this.grd01.Selection.TopRow == this.grd01.Selection.BottomRow
                    && this.grd01.Selection.LeftCol == this.grd01.Selection.RightCol
                    )
                {
                    if (this.grd01.SelectedRowIndex < grd01.Rows.Fixed || !this.grd01.GetValue(this.grd01.SelectedRowIndex, 0).ToString().Equals("N"))
                    {
                        return;
                    }

                    C1.Win.C1FlexGrid.Row _row = this.grd01.Rows[this.grd01.Row];

                    if (this.grd01.Cols[this.grd01.Col].Name.Equals("MOLDNO"))
                    {
                        this.grd01.Select(0, 0);

                        PD20420P1 PD20420P1 = new PD20420P1();
                        PD20420P1.BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                        PD20420P1.MOLDNO = _row["MOLDNO"].ToString();
                        PD20420P1.MOLDNM = _row["MOLDNM"].ToString();

                        PopupHelper helper = new PopupHelper(PD20420P1, this.cdx01_MOLDNO.PopupTitle);
                        helper.ShowDialog();
                        object data = helper.SelectedValue;
                        if (data != null)
                        {
                            DataRow selectedPopupValue = (DataRow)data;
                            this.grd01.SetValue(tmpRow, "MOLDNO", selectedPopupValue["MOLDNO"].ToString());
                            this.grd01.SetValue(tmpRow, "MOLDNM", selectedPopupValue["MOLDNM"].ToString());
                            this.grd01.SetValue(tmpRow, "VINNM", selectedPopupValue["VINNM"].ToString());
                        }

                        this.grd01.Select(tmpRow, tmpCol);
                    }
                }

                this.isDoubleClick = false;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            //try
            //{
            //    int col = this.grd01.ColSel;
            //    int row = this.grd01.SelectedRowIndex;

            //    if (row < this.grd01.Rows.Fixed)
            //        return;

            //    if (col == this.grd01.Cols["CHK_INNER_1"].Index)
            //    {
            //        //PopupHelper helper = new PopupHelper(new SD20031(), "품번 조회");
            //        PopupHelper helper = new PopupHelper(new PD20420P1(), "금형 조회");
            //        helper.FixedPopupSize();
            //        helper.ShowDialog(false);

            //        if (helper.SelectedValue == null) return;
            //        DataRow data = (DataRow)helper.SelectedValue;

            //        this.grd01.SetValue(row, "CHK_INNER_1", data["MOLDNO"].ToString());
            //        this.grd01.SetValue(row, "CHK_INNER_2", data["MOLDNM"].ToString());
            //        this.grd01.SetValue(row, "CHK_INNER_3", data["VINNM"].ToString());
            //    }
            //}
            //catch (FaultException<ExceptionDetail> ex)
            //{
            //    MsgBox.Show(ex.ToString());
            //}
        }

        private void grd01_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                int tmpCol = this.grd01.Col;
                int tmpRow = this.grd01.SelectedRowIndex;

                if (this.grd01.Cols[e.Col].Name == "SUB_ITEM" && this.grd01.Rows[tmpRow]["MASTER_ITEM"].ToString().Length == 0)
                {
                    //gBox.Show("대항목을 먼저 선택해 주세요");//@@@
                    MsgCodeBox.ShowFormat("CD00-0080", this.grd01.Cols["MASTER_ITEM"].Caption); //{0}가(이) 선택되지 않았습니다. //@@@
                    //this.grd01.SetColumnType(HEFlexGrid.FCellType.ComboBox, "QG", "SUB_ITEM");
                    this.grd01.SetValue(tmpRow, "SUB_ITEM", "");
                }

                if (!this.isDoubleClick)
                {
                    this.cdx01_MOLDNO.Initialize();
                                               
                    if (this.grd01.Cols[e.Col].Name == "MOLDNO")
                    {
                        this.cdx01_MOLDNO.SetValue(this.grd01.GetValue(e.Row, "MOLDNO"));
                        if (!string.IsNullOrEmpty(this.grd01.GetValue(e.Row, "MOLDNO").ToString()) && string.IsNullOrEmpty(this.cdx01_MOLDNO.GetText()))
                        {
                            this.grd01.SetValue(tmpRow, "MOLDNO", string.Empty);
                            this.grd01.SetValue(tmpRow, "MOLDNM", string.Empty);
                            this.grd01.SetValue(tmpRow, "VINNM", string.Empty);
                            
                            //MsgBox.Show("정확한 금형번호를 넣어주세요");
                            MsgCodeBox.Show("COM-00304"); //입력된값이 정확하지가 않습니다. 입력한 값을 확인해 주시기 바랍니다. //@@@
                            return;
                        }

                        HEParameterSet set = new HEParameterSet();
                        set.Add("CORCD", this.UserInfo.CorporationCode);
                        set.Add("BIZCD", this.grd01.GetValue(tmpRow, "BIZCD").ToString());
                        set.Add("MOLDNO", this.grd01.GetValue(tmpRow, "MOLDNO").ToString());
                        set.Add("MOLDNM", string.Empty);
                        set.Add("LANG_SET", this.UserInfo.Language);

                        DataTable dt = cdx01_MOLDNO.HEPopupHelper.GetDataSource(set);

                        if (dt.Rows.Count > 0)
                        {
                            DataRow selectedPopupValue = dt.Rows[0];

                            this.grd01.SetValue(tmpRow, "MOLDNO", selectedPopupValue["MOLDNO"]);
                            this.grd01.SetValue(tmpRow, "MOLDNM", selectedPopupValue["MOLDNM"]);
                            this.grd01.SetValue(tmpRow, "VINNM", selectedPopupValue["VINNM"]);
                        }

                        this.grd01.Select(tmpRow, tmpCol);
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_BeforeEdit(object sender, RowColEventArgs e)
        {
            try
            {
                AxFlexGrid grd = (AxFlexGrid)sender;
                if (sender.Equals(grd01))
                {
                    // 값 수정 불가
                    if (e.Col == grd.Cols["MOLDNO"].Index || e.Col == grd.Cols["MASTER_ITEM"].Index || e.Col == grd.Cols["SUB_ITEM"].Index
                         || e.Col == grd.Cols["ITEM_VALUE"].Index || e.Col == grd.Cols["ITEM_REASON"].Index)
                    {
                        if (grd.GetValue(e.Row, 0).ToString().Equals("N"))
                        {
                            e.Cancel = false;
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }

                    // 값 수정 불가
                    if (e.Col == grd.Cols["CHANGE_VALUE"].Index || e.Col == grd.Cols["CHANGE_REASON"].Index)
                    {
                        if (grd.GetValue(e.Row, 0).ToString().Equals("N"))
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            e.Cancel = false;
                        }
                    }

                    // 값 수정 불가
                    if (e.Col == grd.Cols["CHK"].Index || e.Col == grd.Cols["CHK"].Index)
                    {
                        if (grd.GetValue(e.Row, 0).ToString().Equals("N"))
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            e.Cancel = false;
                        }
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void cbo01_MASTER_ITEM_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.cbo01_SUB_ITEM.DataBind("QG");

                HEParameterSet param = new HEParameterSet();
                param.Add("OBJECT_ID", this.cbo01_MASTER_ITEM.GetValue().ToString());
                param.Add("LANG_SET", UserInfo.Language);

                System.Collections.Generic.List<HEParameterSet> paramList = new System.Collections.Generic.List<HEParameterSet> { param };
                DataSet source = _WSCOM.MultipleExecuteDataSet(string.Format("{0}.{1}", "APG_PD20420", "INQUERY_TYPE_CODE"), paramList);

                if (source.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = this.GetTypeCode("QG").Tables[0];
                    dt.DefaultView.RowFilter = "GROUPCD = '" + source.Tables[0].Rows[0]["GROUPCD"].ToString() + "'"; // 해당 그룹에 포함되는 항목만
                    DataTable dt2 = dt.DefaultView.ToTable();
                    this.cbo01_SUB_ITEM.DataBind(dt2);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_SetupEditor(object sender, RowColEventArgs e)
        {
            try
            {
                int tmpCol = this.grd01.Col;
                int tmpRow = this.grd01.SelectedRowIndex;

                AxFlexGrid grd = (AxFlexGrid)sender;
                if (e.Row < grd.Rows.Fixed || e.Col < grd.Cols.Fixed)
                    return;

                if (sender.Equals(grd01))
                {
                    if (e.Col == grd.Cols["MASTER_ITEM"].Index)
                    {
                        this.grd01.SetValue(e.Row, "SUB_ITEM", "");
                    }

                    if (e.Col == grd.Cols["SUB_ITEM"].Index)
                    {
                        HEParameterSet param = new HEParameterSet();
                        param.Add("OBJECT_ID", this.grd01.Rows[tmpRow]["MASTER_ITEM"].ToString());
                        param.Add("LANG_SET", UserInfo.Language);

                        System.Collections.Generic.List<HEParameterSet> paramList = new System.Collections.Generic.List<HEParameterSet> { param };
                        DataSet source = _WSCOM.MultipleExecuteDataSet(string.Format("{0}.{1}", "APG_PD20420", "INQUERY_TYPE_CODE"), paramList);

                        DataTable dt = this.GetTypeCode("QG").Tables[0];

                        ComboBox cbo = grd01.Editor as ComboBox;

                        if (source.Tables[0].Rows.Count > 0)
                        {
                            if (cbo.Items.Count - 1 == dt.Rows.Count)
                            {
                                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                                {
                                    DataRow dr = dt.Rows[i];
                                    if (!dr["GROUPCD"].ToString().Equals(source.Tables[0].Rows[0]["GROUPCD"].ToString()))
                                    {
                                        cbo.Items.RemoveAt(i + 1);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void chk01_CHECK_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                    this.grd02.SetValue(i, "CHK", this.chk01_ALL_CHK.GetValue().Equals("Y") ? "True" : "False");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        //엑셀 파일 내용 채우기
        private void SaveExcelDetail(string file_path)
        {

            Microsoft.Office.Interop.Excel.Global global = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                global = new Excel.Global();

                object missing = System.Reflection.Missing.Value;
                workbook = global.Application.Workbooks.Open(file_path, missing, missing,
                                                      missing, missing, missing, missing, missing, missing,
                                                      missing, missing, missing, missing, missing, missing);
                worksheet = (Excel.Worksheet)workbook.Sheets["사출 성형조건 항목"]; //@@@ ???

                int rowIdx = 0;
                int[] intMoldno = new int[1];
                string MOLDNO = "";

                if (strMoldno().Length == 0)
                {
                    //MsgBox.Show("출력할 정보가 존재하지 않습니다.");
                    MsgCodeBox.Show("COM-00807"); //출력 또는 내보낼 데이터가 없습니다. //@@@
                    return;
                }

                DataSet ds = PrintQuery(strMoldno());

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string oldBiz = cbo01_BIZCD.GetValue().ToString();
                    cbo01_BIZCD.SetValue(ds.Tables[0].Rows[i]["BIZCD"].ToString());
                    string bizName = cbo01_BIZCD.GetText();
                    cbo01_BIZCD.SetValue(oldBiz);

                    if (MOLDNO.Equals(""))
                    {
                        MOLDNO = ds.Tables[0].Rows[i]["MOLDNO"].ToString();

                        worksheet = ((Excel.Worksheet)workbook.Worksheets[1]);
                        worksheet.Copy(Type.Missing, After: workbook.Sheets[workbook.Sheets.Count]);
                        worksheet = ((Excel.Worksheet)workbook.Sheets[workbook.Sheets.Count]);
                        worksheet.Name = ds.Tables[0].Rows[i]["MOLDNO"].ToString();


                        worksheet.get_Range("C4:C4", Missing.Value).Value = this.GetLabel("SAUP") + " : " + bizName;  //"사업장 : " + bizName;          //사업장 //@@@
                        worksheet.get_Range("C5:C5", Missing.Value).Value = this.GetLabel("MOLDNO") + " : " + ds.Tables[0].Rows[i]["MOLDNO"].ToString(); //"금형번호 : " + ds.Tables[0].Rows[i]["MOLDNO"].ToString();      //금형번호 //@@@
                        worksheet.get_Range("C6:C6", Missing.Value).Value = this.GetLabel("MOLDNM") + " : " + ds.Tables[0].Rows[i]["MOLDNM"].ToString(); //"금형명 : " + ds.Tables[0].Rows[i]["MOLDNM"].ToString();        //금형명 //@@@
                        worksheet.get_Range("F6:F6", Missing.Value).Value = this.GetLabel("PRINT_TIME") + " : " + DateTime.Now.ToString("yyyy-MM-dd"); //"출력일시 : " + DateTime.Now.ToString("yyyy-MM-dd");              //출력일시 //@@@
                        rowIdx = 0;
                    }

                    if (!ds.Tables[0].Rows[i]["MOLDNO"].Equals(MOLDNO))
                    {
                        worksheet = ((Excel.Worksheet)workbook.Worksheets[1]);
                        worksheet.Copy(Type.Missing, After: workbook.Sheets[workbook.Sheets.Count]);
                        worksheet = ((Excel.Worksheet)workbook.Sheets[workbook.Sheets.Count]);
                        worksheet.Name = ds.Tables[0].Rows[i]["MOLDNO"].ToString();

                        MOLDNO = ds.Tables[0].Rows[i]["MOLDNO"].ToString();

                        worksheet.get_Range("C4:C4", Missing.Value).Value = this.GetLabel("SAUP") + " : " + bizName; //"사업장 : " + bizName;         //사업장 //@@@
                        worksheet.get_Range("C5:C5", Missing.Value).Value = this.GetLabel("MOLDNO") + " : " + ds.Tables[0].Rows[i]["MOLDNO"].ToString(); //"금형번호 : " + ds.Tables[0].Rows[i]["MOLDNO"].ToString();      //금형번호 //@@@
                        worksheet.get_Range("C6:C6", Missing.Value).Value = this.GetLabel("MOLDNM") + " : " + ds.Tables[0].Rows[i]["MOLDNM"].ToString(); //"금형명 : " + ds.Tables[0].Rows[i]["MOLDNM"].ToString();        //금형명 //@@@
                        worksheet.get_Range("F6:F6", Missing.Value).Value = this.GetLabel("PRINT_TIME") + " : " + DateTime.Now.ToString("yyyy-MM-dd"); //"출력일시 : " + DateTime.Now.ToString("yyyy-MM-dd");              //출력일시 //@@@
                        rowIdx = 0;
                    }

                    Excel.Range range = worksheet.get_Range(string.Format("{0}:{0}", (rowIdx + 9).ToString(), Type.Missing));
                    range.EntireRow.Insert(Type.Missing);

                    worksheet.get_Range("C" + (rowIdx + 9).ToString() + ":C" + (rowIdx + 9).ToString(), Missing.Value).Value = rowIdx + 1;
                    worksheet.get_Range("D" + (rowIdx + 9).ToString() + ":D" + (rowIdx + 9).ToString(), Missing.Value).Value = ds.Tables[0].Rows[i]["MASTER_ITEMNM"].ToString();
                    worksheet.get_Range("E" + (rowIdx + 9).ToString() + ":E" + (rowIdx + 9).ToString(), Missing.Value).Value = ds.Tables[0].Rows[i]["SUB_ITEMNM"].ToString();
                    worksheet.get_Range("F" + (rowIdx + 9).ToString() + ":F" + (rowIdx + 9).ToString(), Missing.Value).Value = ds.Tables[0].Rows[i]["ITEM_VALUE"].ToString();

                    rowIdx++;
                }


                if (workbook.Sheets.Count > 1)
                {
                    global.Application.DisplayAlerts = false;
                    ((Excel.Worksheet)workbook.Sheets[1]).Delete();
                    global.Application.DisplayAlerts = true;
                    worksheet = ((Excel.Worksheet)workbook.Sheets[1]);
                    worksheet.Select();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(System.Reflection.MethodBase.GetCurrentMethod().Name + ex.ToString());
            }
            finally
            {
                if (worksheet != null)
                    worksheet = null;

                if (workbook != null)
                    workbook.Close(true, Type.Missing, Type.Missing);

                workbook = null;

                if (global.Application != null)
                {
                    Process[] pProcess;
                    pProcess = System.Diagnostics.Process.GetProcessesByName("Excel");
                    pProcess[0].Kill();
                }
            }
        }

        //하단 그리드 쿼리
        private void DetailQuery()
        {
            DataSet source = new DataSet();
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("MOLDNO", this.txt01_MOLDNO.GetValue().ToString());
                paramSet.Add("MASTER_ITEM", this.cbo01_MASTER_ITEM.GetValue());
                paramSet.Add("SUB_ITEM", this.cbo01_SUB_ITEM.GetValue().ToString());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_DETAIL"), paramSet, "OUT_CURSOR");

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

        //출력 쿼리
        private DataSet PrintQuery(string arrMoldno)
        {
            DataSet source = new DataSet();
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                paramSet.Add("MOLDNO", arrMoldno);
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_PRINT_MOLD"), paramSet, "OUT_CURSOR");
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

            return source;
        }

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

            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.Message);
                return false;
            }

            return true;
        }

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //메세지 코드 처리
                    //MsgBox.Show("저장할 정보가 존재하지 않습니다.");@@@
                    //MsgCodeBox.Show("PM00-0066");
                    MsgCodeBox.Show("CD00-0042"); //저장할 데이터가 존재하지 않습니다. //@@@
                    return false;
                }

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    DataRow row = source.Tables[0].Rows[i];
                    DataRow seq = source.Tables[1].Rows[i];

                    if (this.Nvl(row["CORCD"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 법인코드 정보가 입력되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.grd01.Cols["CORCD"].Caption); //{0}번째 행에 {1} 정보가 입력되지 않았습니다. //@@@
                        return false;
                    }

                    if (this.Nvl(row["BIZCD"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 사업장코드 정보가 입력되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.grd01.Cols["BIZCD"].Caption); //{0}번째 행에 {1} 정보가 입력되지 않았습니다. //@@@
                        return false;
                    }

                    if (this.Nvl(row["MOLDNO"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 금형번호 정보가 입력되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.grd01.Cols["MOLDNO"].Caption); //{0}번째 행에 {1} 정보가 입력되지 않았습니다. //@@@
                        return false;
                    }

                    if (this.Nvl(row["MASTER_ITEM"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 대항목 정보가 입력되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.grd01.Cols["MASTER_ITEM"].Caption); //{0}번째 행에 {1} 정보가 입력되지 않았습니다. //@@@
                        return false;
                    }

                    if (this.Nvl(row["SUB_ITEM"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{0}행의 조건항목 정보가 입력되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.grd01.Cols["SUB_ITEM"].Caption); //{0}번째 행에 {1} 정보가 입력되지 않았습니다. //@@@
                        return false;
                    }

                    if (this.Nvl(row["ITEM_REASON"], "").ToString().Length == 0 && this.grd01.Rows[Convert.ToInt32(seq["GRIDSEQ"])][0].ToString().Equals("N"))
                    {
                        //MsgBox.Show(String.Format("{0}행의 사유 정보가 입력되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.grd01.Cols["ITEM_REASON"].Caption); //{0}번째 행에 {1} 정보가 입력되지 않았습니다. //@@@
                        return false;
                    }

                    if (this.Nvl(row["CHANGE_REASON"], "").ToString().Length == 0 && !this.grd01.Rows[Convert.ToInt32(seq["GRIDSEQ"])][0].ToString().Equals("N"))
                    {
                        //MsgBox.Show(String.Format("{0}행의 변경사유 정보가 입력되지 않았습니다.", seq["GRIDSEQ"]));
                        MsgCodeBox.ShowFormat("CD00-0091", seq["GRIDSEQ"], this.grd01.Cols["CHANGE_REASON"].Caption); //{0}번째 행에 {1} 정보가 입력되지 않았습니다. //@@@
                        return false;
                    }
                }

                //if (MsgBox.Show("입력하신 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK) //저장하시겠습니까? //@@@
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
                    //메세지 코드 처리
                    MsgCodeBox.Show("CD00-0041"); //삭제할 데이터가 존재하지 않습니다.
                    
                    return false;
                }

                //if (MsgBox.Show("선택하신 완제품 적재대를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("CD00-0018", MessageBoxButtons.OKCancel) != DialogResult.OK) //데이터를 삭제하시겠습니까?
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

        #region [ 사용자 함수 ]

        //선택된 금형번호
        private string strMoldno()
        {
            string moldno = string.Empty;

            for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
            {
                if (this.grd02.Rows[i]["CHK"].ToString().Equals("True"))
                {
                    moldno += this.grd02.Rows[i]["MOLDNO"].ToString() + ",";
                }
            }

            if (moldno.Length > 0)
                moldno = moldno.Substring(0, moldno.Length - 1);

            return moldno;
        }

        #endregion


    }
}
