using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ax.DEV.Utility.Library;
using HE.Framework.ServiceModel;

using System.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using HE.Framework.Core;
using HE.Framework.Core.Report;
using System.Diagnostics;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// 배송용 TRUCK 마스터
    /// </summary>
    public partial class WM20480 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private const int IDX_CHECK_COLUMN = 10;//2019.04.16

        public WM20480()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            base.UI_Shown(e);

            try
            {

                #region grd01
                this.grd01.AllowEditing = true;
                this.grd01.Initialize();                
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 24, "Select", "CHK", "CHK_SELECT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "Truck Code", "TRKNO", "TRKNO");
                this.grd01.Cols["TRKNO"].Style.BackColor = Color.LightGray;
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "Truck Plate No.", "CAR_PLATE_NO", "CARPLATE_NO");
                this.grd01.Cols["CAR_PLATE_NO"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "Truck Name", "TRKNM", "TRKNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "Driver Name", "TRK_DRIVER_NAME", "TRK_DRIVER_NAME");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "Tel No.", "TRK_DRIVER_TEL", "TRK_DRIVER_TEL");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "Begin", "BEG_DATE", "BEG_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "End", "END_DATE", "END_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 320, "Truck Specification", "TRKSPEC", "TRKSPEC");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "INSERT_DATE", "INSERT_DATE", "INSERT_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 50, "OURS", "OUR_OWN", "OUR_OWN");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "OUR_OWN");  
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");                         //2019.04.16
                //전체 선택 체크박스.                                                                   //2019.04.16
                C1.Win.C1FlexGrid.CellStyle cs = this.grd01.Styles.Add("Boolean");                     //2019.04.16
                cs.DataType = typeof(Boolean);                                                         //2019.04.16
                cs.ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.CenterCenter;                         //2019.04.16
                this.grd01.SetCellStyle(0, this.grd01.Cols["CHK"].Index, cs);

                this.grd01.Cols["BEG_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "BEG_DATE");
                this.grd01.Cols["END_DATE"].Format = "yyyy-MM-dd";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "END_DATE");
                #endregion
                                
                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #region [공용버튼]
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            base.BtnQuery_Click(sender, e);

            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.UserInfo.BusinessCode);
                paramSet.Add("TRKNO", txt01_TRKNO.Text);
                paramSet.Add("PLATENO", txt01_CARPLATENO.Text);
                paramSet.Add("TRK_DRIVER_NAME", txt01_DRIVER.Text);

                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20480.INQUERY", paramSet, "OUT_CURSOR");
                if (null != source && null != source.Tables[0])
                {
                    this.grd01.SetValue(source);
                }

                //source.Tables[0].WriteXml(@"D:\WM20480.xml", XmlWriteMode.WriteSchema);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            base.BtnSave_Click(sender, e);

            try
            {
                DataSet sourceIU = this.grd01.GetValue(AxFlexGrid.FActionType.Save
                                                        , "CORCD"
                                                        , "BIZCD"
                                                        , "TRKNO"
                                                        , "CAR_PLATE_NO"
                                                        , "BEG_DATE"
                                                        , "END_DATE"
                                                        , "INSERT_DATE"
                                                        , "UPDATE_ID"
                                                        , "TRKNM"
                                                        , "TRKSPEC"
                                                        , "TRK_DRIVER_NAME"
                                                        , "TRK_DRIVER_TEL"
                                                        , "OUR_OWN"
                                                    );

                DataSet sourceD = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                                                        "CORCD"
                                                      , "BIZCD"
                                                      , "TRKNO"
                                                    );

                if (sourceIU.Tables[0].Rows.Count > 0)
                {
                    if (!IsSaveValid(sourceIU)) return;

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_WM20480.SAVE", sourceIU);

                    this.AfterInvokeServer();
                }

                if (sourceD.Tables[0].Rows.Count > 0)
                {
                    if (!IsDeleteValid(sourceD)) return;

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_WM20480.REMOVE", sourceD);

                    this.AfterInvokeServer();
                }

                BtnQuery_Click(null, null);

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

        protected override void BtnPrint_Click(object sender, EventArgs e)
        {
            base.BtnPrint_Click(sender, e);

            try
            {
                HERexReport report = new HERexReport(this.UserInfo.UserID, this.UserInfo.UserName, true);
                report.ReportName = @"RxRpt/WM20480";

                DataSet dsRpt = new DataSet();// ((DataSet)this.grd01.DataSource).Copy();
                DataTable dtGrd01 = (DataTable)this.grd01.DataSource;

                DataTable dtRpt = new DataTable("DATA");
                dtRpt = dtGrd01.Clone();

                foreach (DataRow row in dtGrd01.Select("", "TRK_SORT"))
                {
                    string s_check = row["CHK"].ToString().Trim().ToUpper();
                    if (s_check.Equals("1") || s_check.Equals("true", StringComparison.CurrentCultureIgnoreCase))
                    {
                        dtRpt.ImportRow(row);
                    }
                }

                dtRpt.DefaultView.Sort = "TRK_SORT";
                dtRpt = dtRpt.DefaultView.ToTable(true);

                dsRpt.Tables.Add(dtRpt);

                // Main section(메인리포트 파라미터 셋)
                HERexSection main_section = new HERexSection();
                main_section.ReportParameter.Add("RPT_TITLE", "The Contents of WareHouse");
                main_section.ReportParameter.Add("EMP_NO", this.UserInfo.EmpNo);
                main_section.ReportParameter.Add("EMP_NAME", this.UserInfo.UserName);
                report.Sections.Add("MAIN", main_section);

                HERexSection xml_section = new HERexSection(dsRpt, new HEParameterSet());
                report.Sections.Add("XML1", xml_section);//레포트파일의 커넥션이름과동일해야함.
                AxRexpertReportViewer.ShowReport(report);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
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
                    this.grd01.SetValue(i, "UPDATE_ID", this.UserInfo.UserID);
                    this.grd01.SetValue(i, "BEG_DATE", DateTime.Now.ToShortDateString());
                    this.grd01.SetValue(i, "END_DATE", Convert.ToDateTime("2099-12-31").ToShortDateString());
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
                    //C1.Win.C1FlexGrid.CheckEnum e_all_check = this.grd01.GetCellCheck(0, IDX_CHECK_COLUMN);
                    //C1.Win.C1FlexGrid.CheckEnum e_sin_check = this.grd01.GetCellCheck(this.grd01.MouseRow, IDX_CHECK_COLUMN);
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

                for (int i = 1; i < this.grd01.Rows.Count; i++)
                {
                    string CAR_PLATE_NO = this.grd01.GetValue(i, "CAR_PLATE_NO").ToString().ToUpper();

                    if (this.GetByteCount(CAR_PLATE_NO) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 {LOC_NO}가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i.ToString(), this.grd01.Cols["CAR_PLATE_NO"].Caption.ToString());
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
