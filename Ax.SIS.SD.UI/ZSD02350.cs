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
    
    public partial class ZSD02350 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;

        public ZSD02350()
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

                #region TabPage - 1st
                this.grd08.AllowEditing = false;
                this.grd08.Initialize();
                this.grd08.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 48, "CORCD", "CORCD", "CORCD");
                this.grd08.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd08.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 50, "MOVE", "MTYPE", "MTYPE");
                this.grd08.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "DESC", "NM", "NM");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "JAN", "AMT_01", "AMT_01");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "FEB", "AMT_02", "AMT_02");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "MAR", "AMT_03", "AMT_03");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "APR", "AMT_04", "AMT_04");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "MAY", "AMT_05", "AMT_05");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "JUN", "AMT_06", "AMT_06");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "JUL", "AMT_07", "AMT_07");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "AUG", "AMT_08", "AMT_08");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "SEP", "AMT_09", "AMT_09");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "OCT", "AMT_10", "AMT_10");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "NOV", "AMT_11", "AMT_11");
                this.grd08.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 80, "DEC", "AMT_12", "AMT_12");

                this.grd08.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT_01");
                this.grd08.Cols["AMT_01"].Format = "###,###,###,##0.##";
                this.grd08.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT_02");
                this.grd08.Cols["AMT_02"].Format = "###,###,###,##0.##";
                this.grd08.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT_03");
                this.grd08.Cols["AMT_03"].Format = "###,###,###,##0.##";
                this.grd08.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT_04");
                this.grd08.Cols["AMT_04"].Format = "###,###,###,##0.##";
                this.grd08.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT_05");
                this.grd08.Cols["AMT_05"].Format = "###,###,###,##0.##";
                this.grd08.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT_06");
                this.grd08.Cols["AMT_06"].Format = "###,###,###,##0.##";
                this.grd08.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT_07");
                this.grd08.Cols["AMT_07"].Format = "###,###,###,##0.##";
                this.grd08.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT_08");
                this.grd08.Cols["AMT_08"].Format = "###,###,###,##0.##";
                this.grd08.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT_09");
                this.grd08.Cols["AMT_09"].Format = "###,###,###,##0.##";
                this.grd08.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT_10");
                this.grd08.Cols["AMT_10"].Format = "###,###,###,##0.##";
                this.grd08.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT_11");
                this.grd08.Cols["AMT_11"].Format = "###,###,###,##0.##";
                this.grd08.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT_12");
                this.grd08.Cols["AMT_12"].Format = "###,###,###,##0.##";

                this.grd09.AllowEditing = false;
                this.grd09.Initialize();

                this.grd09.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd09.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "Part No", "PARTNO", "PARTNO");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 250, "Part Name", "PARTNM", "PARTNM");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "AMT", "AMT", "AMT");
                this.grd09.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 50, "%", "RATE", "RATE");

                this.grd09.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT");
                this.grd09.Cols["AMT"].Format = "###,###,###,##0.##";


                this.grd10.AllowEditing = true;
                this.grd10.Initialize();
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "S/DATE", "ST_DATE", "ST_DATE");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 110, "D/NOTE", "DNO", "DNO");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 70, "LOC", "STR_LOC", "STR_LOC");
                this.grd10.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 310, "REASON", "REASON", "REASON");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 60, "QTY", "QTY", "QTY");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 45, "UOM", "UOM", "UOM");
                this.grd10.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "AMT", "AMT", "AMT");
                this.grd10.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 90, "PARTNO", "PARTNO", "PARTNO");
                this.grd10.AddColumn(true, false, AxFlexGrid.FtextAlign.R, 90, "MTYPE", "MTYPE", "MTYPE");

                this.grd10.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd10.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");


                this.grd10.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd10.Cols["QTY"].Format = "###,###,###,##0.##";
                this.grd10.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT");
                this.grd10.Cols["AMT"].Format = "###,###,###,##0.##";
                #endregion

                #region TabPage - 2nd
                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.CurrentContextMenu.Items.RemoveAt(0);
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 50, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 180, "Part No", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 250, "Part Name", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 45, "CAR", "VINCD", "VINCD");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 50, "P/TYPE", "PRDT", "PRDT");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 50, "MIP", "MIPV", "MIPV");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 120, "Movement Type", "MTYPE_NM", "MTYPE_NM");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 90, "QTY", "QTY", "QTY");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 50, "UNIT", "UOM", "UOM");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 110, "AMT", "AMT", "AMT");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 290, "REASON", "REASON", "REASON");

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd01.Cols["QTY"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT");
                this.grd01.Cols["AMT"].Format = "###,###,###,##0.##";

                #endregion

                DispLimit();


                
                axDateEdit1.SetValue(DateTime.Now.AddMonths(-1));

                this.SetRequired(lbl01_CORCD, lbl01_BIZCD);

                if (this.UserInfo.IsAdmin.Equals("N"))
                {
                    this.tabControl1.TabPages.Remove(this.tabPage3);
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
        #endregion
        private string GetTY()
        {
            if(radioButton1.Checked)
            {
                return "A";
            }
            else if(radioButton2.Checked)
            {
                return "FG";
            }
            else if(radioButton3.Checked)
            {
                return "SFG";
            }
            else if(radioButton4.Checked)
            {
                return "MAT";
            }
            else if(radioButton5.Checked)
            {
                return "GOD";
            }
            return "";
        }
        #region [공통 버튼에 대한 이벤트 정의]
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            //base.BtnQuery_Click(sender, e);
            try
            {

                if (tabControl1.SelectedIndex == 0)
                {
                    grd09.InitializeDataSource();
                    grd10.InitializeDataSource();
                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", cbo01_CORCD.GetValue());
                    set.Add("BIZCD", cbo01_BIZCD.GetValue());
                    set.Add("SDATE", axDateEdit1.GetDateText());
                    set.Add("TY", GetTY());
                    DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02350.INQUERY_SD_SCRAPDAM", set, "OUT_CURSOR");
                    grd08.SetValue(source);
                }
                else if (tabControl1.SelectedIndex == 1)
                {

                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", cbo01_CORCD.GetValue());
                    paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                    paramSet.Add("YM", axDateEdit1.GetDateText());
                    paramSet.Add("LIMIT", axTextBox1.GetValue());
                    paramSet.Add("PARTNO", axTextBox4.GetValue());
                    paramSet.Add("MTYPE", "");
                    paramSet.Add("TY", GetTY());
                    DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02350.INQUERY_SD_CLOSE", paramSet, "OUT_CURSOR");
                    if (null != source && null != source.Tables[0])
                    {
                        this.grd01.SetValue(source);
                    }
                }
                else if (tabControl1.SelectedIndex == 2)
                {
                    HEParameterSet paramSet = new HEParameterSet();
                    paramSet.Add("CORCD", cbo01_CORCD.GetValue());
                    paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                    DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02350.INQUERY_SETTING", paramSet, "OUT_CURSOR");
                    if (null != source && null != source.Tables[0] && source.Tables[0].Rows.Count>0)
                    {
                        axTextBox5.SetValue(source.Tables[0].Rows[0]["ALLOW_LIMIT"].ToString());
                        axTextBox3.SetValue(source.Tables[0].Rows[0]["EMAIL"].ToString());
                    }
                    else
                    {
                        axTextBox5.SetValue("");
                        axTextBox3.SetValue("");
                    }
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


        #endregion

        private void axButton1_Click(object sender, EventArgs e)
        {
            axButton1.Enabled = false;
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", cbo01_CORCD.GetValue());
            paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
            paramSet.Add("YM", axDateEdit1.GetDateText());
            paramSet.Add("LIMIT", axTextBox1.GetValue());

            _WSCOM_N.ExecuteNonQueryTx("ZPG_ZSD02350.SEND_MAIL", paramSet);
        }
        private string m_ymd = "";
        private string m_ty = "";
        private void grd08_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = this.grd08.SelectedRowIndex;
            if (row < 1)
            {
                return;
            }
            string yy = axDateEdit1.GetDateText().Substring(0, 4);
            string ty = grd08.GetValue(row, "MTYPE").ToString();
            string[] colname = grd08.Cols[grd08.Col].Name.Split('_');
            if (colname.Length > 1 && colname[0] == "AMT")
            {
                m_ymd = yy + "-" + colname[1];
                m_ty = ty;
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("SDATE", m_ymd);
                set.Add("MTYPE", m_ty);
                set.Add("TY", GetTY());
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02350.INQUERY_SD_SCRAPDAM_D1", set, "OUT_CURSOR");
                grd09.SetValue(source);
            }

        }

        private void grd09_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = this.grd09.SelectedRowIndex;
            if (row < 1)
            {
                return;
            }
            string partno = grd09.GetValue(row, "PARTNO").ToString();

            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", cbo01_BIZCD.GetValue());
            set.Add("SDATE", m_ymd);
            set.Add("MTYPE", m_ty);
            set.Add("PARTNO", partno);
            set.Add("TY", GetTY());
            //DataSet source = _WSCOM.INQUERY(bizcd, set);
            DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02350.INQUERY_SD_SCRAPDAM_D2", set, "OUT_CURSOR");
            grd10.SetValue(source);
        }

        private void axButton2_Click(object sender, EventArgs e)
        {
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", cbo01_CORCD.GetValue());
            paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
            paramSet.Add("LIMIT",axTextBox5.GetValue());
            paramSet.Add("MAIL", axTextBox3.GetValue());
            paramSet.Add("UPDATE_ID", UserInfo.UserID);

            _WSCOM_N.ExecuteNonQueryTx("ZPG_ZSD02350.SET_SETTING_DATA", paramSet);
            MsgBox.Show("Data was saved!");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 2)
            {
                BtnQuery_Click(null, null);
            }
        }
        private void DispLimit()
        {
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", cbo01_CORCD.GetValue());
            paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
            DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02350.INQUERY_SETTING", paramSet, "OUT_CURSOR");
            if (null != source && null != source.Tables[0] && source.Tables[0].Rows.Count > 0)
            {
                axTextBox1.SetValue(source.Tables[0].Rows[0]["ALLOW_LIMIT"].ToString());
            }
            else
            {
                axTextBox1.SetValue("100000");
            }
        }

        private void axButton3_Click(object sender, EventArgs e)
        {
            DataSet source = this.grd10.GetValue(AxFlexGrid.FActionType.All, "CORCD", "BIZCD", "STR_LOC", "PARTNO", "DNO", "MTYPE", "REASON");

            _WSCOM_N.ExecuteNonQueryTx(string.Format("ZPG_ZSD02350.SAVE_SCRAP_D2"), source);

            MsgBox.Show("Data was saved!");
        }
    }
}
