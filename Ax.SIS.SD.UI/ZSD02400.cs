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
    public partial class ZSD02400 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;

        public ZSD02400()
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
                this.grd01.AllowEditing = false;
                //this.grd01.AllowAddNew = false;
                //this.grd01.AllowDelete = false;
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
                #endregion


                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "QTY");
                this.grd01.Cols["QTY"].Format = "###,###,###,##0.##";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "AMT");
                this.grd01.Cols["AMT"].Format = "###,###,###,##0.##";
                axDateEdit1.SetValue(DateTime.Now.AddMonths(-1));

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

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", cbo01_CORCD.GetValue());
                paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
                paramSet.Add("YM", axDateEdit1.GetDateText());
                paramSet.Add("LIMIT", axTextBox1.GetValue());
                paramSet.Add("PARTNO", axTextBox4.GetValue());
                paramSet.Add("MTYPE", axTextBox2.GetValue());
                paramSet.Add("TY", GetTY());
                DataSet source = _WSCOM_N.ExecuteDataSet("ZPG_ZSD02400.INQUERY_SD_CLOSE", paramSet, "OUT_CURSOR");
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


        #endregion

        private void axButton1_Click(object sender, EventArgs e)
        {
            axButton1.Enabled = false;
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", cbo01_CORCD.GetValue());
            paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
            paramSet.Add("YM", axDateEdit1.GetDateText());
            paramSet.Add("LIMIT", axTextBox1.GetValue());

            _WSCOM_N.ExecuteNonQueryTx("ZPG_ZSD02400.SEND_MAIL", paramSet);
        }
    }
}
