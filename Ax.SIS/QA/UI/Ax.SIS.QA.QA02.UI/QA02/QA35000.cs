using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using C1.Win.C1FlexGrid;
using HE.Framework.ServiceModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.ComponentModel;

namespace Ax.SIS.QA.QA02.UI
{
    public partial class QA35000 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;

        public QA35000()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();            
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {                

                this.grd01.Initialize(2,2);
                this.grd01.AutoClipboard = true;
                this.grd01.AllowEditing = false;
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.AllowResizing = AllowResizingEnum.Columns;
                this.grd01.SelectionMode = SelectionModeEnum.Cell;
                this.grd01.AllowMerging = AllowMergingEnum.RestrictRows;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "Defect Type", "TYPE","");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "Division", "DIV", "");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "Target\r\n PPM", "THIS_TAR_PPM", "");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "Actual\r\nPPM", "THIS_ACT_PPM", "");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "Actual\r\nQty", "THIS_ACT_QTY", "");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "Defect\r\nQty", "THIS_DEF_QTY", "");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "Target\r\nPPM", "PREV_TAR_PPM", "");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "Actual\r\nPPM", "PREV_ACT_PPM", "");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "Actual\r\nQty", "PREV_ACT_QTY", "");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "Defect\r\nQty", "PREV_DEF_QTY", "");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "THIS_TAR_PPM");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "THIS_ACT_PPM");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "THIS_ACT_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "THIS_DEF_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PREV_TAR_PPM");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "PREV_ACT_PPM");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PREV_ACT_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PREV_DEF_QTY");


                this.grd01.Cols["THIS_TAR_PPM"].Format = "###,###,###,##0.0  ";
                this.grd01.Cols["THIS_ACT_PPM"].Format = "###,###,###,##0.0  ";
                this.grd01.Cols["THIS_ACT_QTY"].Format = "###,###,###,##0  ";
                this.grd01.Cols["THIS_DEF_QTY"].Format = "###,###,###,##0  ";

                this.grd01.Cols["PREV_TAR_PPM"].Format = "###,###,###,##0.0  ";
                this.grd01.Cols["PREV_ACT_PPM"].Format = "###,###,###,##0.0  ";
                this.grd01.Cols["PREV_ACT_QTY"].Format = "###,###,###,##0  ";
                this.grd01.Cols["PREV_DEF_QTY"].Format = "###,###,###,##0  ";

                this.grd01.Cols["THIS_ACT_PPM"].StyleDisplay.BackColor = Color.FromArgb(188, 214, 238);
                this.grd01.Cols["PREV_ACT_PPM"].StyleDisplay.BackColor = Color.FromArgb(197, 224, 178);

                for (int i = 0; i < this.grd01.Cols.Count; i++)
                {
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;
                }

                this.grd01.AddMerge(0, 1, "TYPE", "TYPE");
                this.grd01.AddMerge(0, 1, "DIV", "DIV");

                this.grd01.AddMerge(0, 0, "THIS_TAR_PPM", "THIS_DEF_QTY");
                this.grd01.SetHeadTitle(0, "THIS_TAR_PPM", "This Month Report");//this.GetLabel("DAY_RSLT"));

                this.grd01.AddMerge(0, 0, "PREV_TAR_PPM", "PREV_DEF_QTY");
                this.grd01.SetHeadTitle(0, "PREV_TAR_PPM", "Previous Month Report");//this.GetLabel("DAY_RSLT"));


                GridDesignSetting(this.grd01, this.grd01.Cols[this.grd01.Cols.Count-1].Name);//첫번째 그리드 디자인                

                this.dte01_STD_DATE.SetValue(DateTime.Now);

                this.BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #region [ 공통 버튼에 대한 이벤트 정의 ]
 
        /// <summary>
        /// 조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                //if (DateTime.Now.Hour < 6)
                //    this.dte01_STD_DATE.SetValue(DateTime.Now.AddDays(-1));

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);                                
                paramSet.Add("YYYYMM", this.dte01_STD_DATE.Value.ToString("yyyy-MM"));
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", "APG_QA35000", "INQUERY"), paramSet, "OUT_CURSOR");
                               
                
                grd01.SetValue(source.Tables[0]);                
                                
                SetGridDataRowsDesign(this.grd01);

                //this.grd01.AllowMergingFixed = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
                //this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictRows;
                                
                //this.grd01.Cols["TYPE"].AllowMerging = true;
                //this.grd01.Cols["DIV"].AllowMerging = true;

                this.grd01.AddMerge(2, 4, 1, 1);
                this.grd01.AddMerge(5, 7, 1, 1);
                this.grd01.AddMerge(8, 8, 1, 2);
                this.grd01.AddMerge(9, 9, 1, 2);
                this.grd01.GetCellRange(4, this.grd01.Cols["DIV"].Index, 4, this.grd01.Cols["PREV_DEF_QTY"].Index).StyleNew.BackColor = Color.FromArgb(255, 218, 101);
                this.grd01.GetCellRange(7, this.grd01.Cols["DIV"].Index, 7, this.grd01.Cols["PREV_DEF_QTY"].Index).StyleNew.BackColor = Color.FromArgb(255, 218, 101);
                grd01_Resize(grd01, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {                
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                //this.AfterInvokeServer();
            }
        }

        #endregion

        #region [ 이벤트 함수 ]

        private void grd01_Resize(object sender, EventArgs e)
        {
            AxFlexGrid grd = (AxFlexGrid)sender;
            try
            {
                if (grd.GetValue() == null)
                {
                    return;
                }
                if (grd.Cols.Count > 1) colWidthChange(grd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 

        #endregion

        #region [ 함수 ]

        private void colWidthChange(AxFlexGrid grd)
        {
            int Cols = grd.Cols["PREV_DEF_QTY"].Index - grd.Cols["DIV"].Index;
            if (Cols >= 1)
            {

                int scrollWidth = 0;
                if (grd.ScrollBarsVisible.Equals(ScrollBars.Vertical))
                {
                    scrollWidth = 17;
                }

                Decimal gridWidth = (decimal.Parse(grd.Width.ToString()) - 1 - grd.Cols["TYPE"].Width - grd.Cols["DIV"].Width) / Cols;


                string[] colsWidth = UserInfo.Language.Equals("PL") ? gridWidth.ToString().Split(',') : gridWidth.ToString().Split('.');
                decimal restWidth = 0;
                if (colsWidth.Length > 1)
                {
                    restWidth = Math.Round(decimal.Parse(UserInfo.Language.Equals("PL") ? "0," : "0." + colsWidth[1]) * Cols) - grd.Margin.Right + 1 - scrollWidth;
                }


                for (int i = grd.Cols["THIS_TAR_PPM"].Index; i <= grd.Cols["PREV_DEF_QTY"].Index; i++)
                {
                    if (i == grd.Cols["PREV_DEF_QTY"].Index)
                        grd.Cols[i].Width = int.Parse(colsWidth[0]) + int.Parse(restWidth.ToString());
                    else
                        grd.Cols[i].Width = int.Parse(colsWidth[0]);// +((int.Parse(colsWidth[0]) + int.Parse(restWidth.ToString())) / Cols);
                }


                grd.Refresh();
            }
        }
        private void GridDesignSetting(AxFlexGrid grd, string lastColumn)
        {
            grd.Cols[0].Visible = false;
            grd.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

            grd.Rows[0].Height = 78;
            grd.Rows[1].Height = 78;
            grd.Rows.DefaultSize = 78;

            grd.BackColor = Color.White;
            grd.ForeColor = Color.Black;
            grd.Styles.Alternate.ForeColor = Color.Black;
            grd.Styles.Alternate.BackColor = Color.White;
            


            grd.Rows[0].StyleNew.ForeColor = Color.Black;
            grd.Rows[1].StyleNew.ForeColor = Color.Black;
            grd.GetCellRange(0, 0).StyleNew.ForeColor = Color.Black; // no컬럼의 0번재는 안먹히네..그래서 추가
            grd.GetCellRange(0, 1).StyleNew.ForeColor = Color.Black; // no컬럼의 0번재는 안먹히네..그래서 추가

            for (int i = 0; i < 2; i++)
            {
                grd.GetCellRange(i, grd.Cols["TYPE"].Index, i, grd.Cols["THIS_DEF_QTY"].Index).StyleNew.BackColor = Color.FromArgb(146, 208, 80);                
                grd.GetCellRange(i, grd.Cols["PREV_TAR_PPM"].Index, i, grd.Cols[lastColumn].Index).StyleNew.BackColor = Color.FromArgb(216, 216, 216);              
                grd.GetCellRange(i, grd.Cols["TYPE"].Index, i, grd01.Cols["DIV"].Index).StyleNew.Font = new System.Drawing.Font("맑은고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            }

            grd.Styles.Normal.Border.Color = Color.Gray;
            grd.Rows[0].StyleFixedDisplay.Border.Color = Color.Gray;
            grd.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
        }

        private void SetGridDataRowsDesign(AxFlexGrid grd)
        {
            //int idx = 0;

            //for (int i = grd.Rows.Fixed; i < grd.Rows.Count; i++)
            //{
            //    idx++;
            //    grd01.Rows[i]["NO"] = idx;

            //    grd.GetCellRange(i, grd.Cols["NO"].Index, i, grd01.Cols["LINENM"].Index).StyleNew.BackColor = Color.LightBlue;
            //    grd01.Rows[i].StyleNew.Font = new System.Drawing.Font("맑은고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            //    grd.Rows[i].Height = 54;
            //}
        }
        #endregion

    }
}
