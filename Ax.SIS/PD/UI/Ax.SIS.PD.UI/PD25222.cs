#region ▶ Description & History
/* 
 * 프로그램명 : LOTNO별 창고 재고 정리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *              날짜          작성자     이슈
 *              ---------------------------------------------------------------------------------------------
 *              2014-07-23    배명희     cdx01_LINECD 연결 팝업 변경 (CM20020P1 -> CM30030P1)
 *              2014-10-07    진승모     다국어 적용
 *              2017-07~09    배명희     SIS 이관
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using HE.Framework.ServiceModel;
using System.Drawing;
using C1.Win.C1FlexGrid;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>        
    /// </summary>
    public partial class PD25222 : AxCommonBaseControl
    {        
        private string PACKAGE_NAME = "APG_PD25222";
        public PD25222()
        {
           InitializeComponent();
           
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                this.cbo01_SHIFT.DataBind("EI", true);

                DataSet source = this.GetTypeCode("A0");
                source.Tables[0].DefaultView.RowFilter = "OBJECT_ID <> 'A0M'";
                this.cbo01_PRDT_DIV.DataBind(source.Tables[0].DefaultView.ToTable(), true);
                

                this.grd01.AutoClipboard = true;
                this.grd01.AllowEditing = false;
                this.grd01.AllowDragging = AllowDraggingEnum.None;
                this.grd01.Initialize();
                this.grd01.AllowSorting = AllowSortingEnum.None;

                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 80, "DATE", "OCCUR_DATE", "OCCUR_DATE");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 100, "LINE DIV.", "PRDT_DIVNM", "LINE_INFO1");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 080, "LINE", "LINECD", "LINE_CD");                
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 70, "SHIFT", "SHIFT", "SHIFT");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 200, "NON_OPRCD", "NON_OPRNM", "NON_OPRCD");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 90, "BEG_HHMM", "BEG_HHMM", "BEG_TIME");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 90, "END_HHMM", "END_HHMM", "END_TIME");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 120, "NON_MIN", "NON_MIN", "NON_MIN");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 120, "NON_HOUR", "NON_HOUR", "NON_HOUR");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 160, "PERSON", "PERSON", "PERSON");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 150, "MAN_HOUR", "MAN_HOUR", "MAN_HOUR");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 350, "REMARK", "REMARK", "REMARK");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 110, "LOCK_STA", "LOCK_STA","LOCK_STA");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 160, "SAP_IF_TIME", "ZDATE_PO");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 100, "Z_PERSON", "Z_PERSON", "Z_PERSON");

                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 5, "INSERT DATE", "INSERT_DATE");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 5, "INSERT ID", "INSERT_ID");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 5, "UPDATE DATE", "UPDATE_DATE");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 5, "UPDATE ID", "UPDATE_ID");


                this.grd01.AddHiddenColumn("BIZCD");
                this.grd01.AddHiddenColumn("NON_OPRCD");
                this.grd01.AddHiddenColumn("NON_OPRNO");
                this.grd01.AddHiddenColumn("CNT");
                this.grd01.AddHiddenColumn("COLOR");
                
                this.grd01.AllowMerging = AllowMergingEnum.RestrictAll;
                this.grd01.Cols["OCCUR_DATE"].AllowMerging = true;
                this.grd01.Cols["PRDT_DIVNM"].AllowMerging = true;
                this.grd01.Cols["LINECD"].AllowMerging = true;
                this.grd01.Cols["SHIFT"].AllowMerging = true;
                this.grd01.Cols["NON_OPRNM"].AllowMerging = true;

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "OCCUR_DATE");
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "EI", "SHIFT");
                this.grd01.Cols["BEG_HHMM"].EditMask = "99:99";
                this.grd01.Cols["END_HHMM"].EditMask = "99:99";
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PERSON");                

                this.grd01.Cols["OCCUR_DATE"].TextAlign = TextAlignEnum.CenterTop;

                this.grd01.Cols["NON_MIN"].Format = "###,###,##0.##";
                this.grd01.Cols["NON_HOUR"].Format = "###,###,##0.##";
                this.grd01.Cols["PERSON"].Format = "###,###,##0.##";
                this.grd01.Cols["MAN_HOUR"].Format = "###,###,##0.##";
                this.grd01.Cols["Z_PERSON"].Format = "###,###,##0.##";

                this.grd01.Rows[0].Height = 50;

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(); //new PM20015P1();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");


                this.SetRequired(this.lbl01_BIZNM2);

                this.grd01.InitializeDataSource();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());
                paramSet.Add("BEG_DATE", this.dtp01_WORKDATE_BEG.GetValue());
                paramSet.Add("END_DATE", this.dtp01_WORKDATE_END.GetValue());
                paramSet.Add("SHIFT", this.cbo01_SHIFT.GetValue());
                paramSet.Add("PRDT_DIV", this.cbo01_PRDT_DIV.GetValue());
                
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                
                if (!IsQueryValid(paramSet)) return;

                this.BeforeInvokeServer(true);
                
                using (AxClientProxy proxy = new AxClientProxy())
                {
                    DataSet source = proxy.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SEARCH"), paramSet);
                    //this.grd01.MergedRanges.Clear();
                    this.grd01.SetValue(source.Tables[0]);
                    //string[] sSumLable = new string[] { "Sub Total", "Total" };
                    //this.grd01.setSumStyle(2, 6, AxFlexGrid.eSumStyle.RowColMode, sSumLable);

                    if (grd01.Rows.Count >= grd01.Rows.Fixed)
                    {
                        grd01.Styles.Add("COLOR_W").BackColor = Color.White;
                        grd01.Styles.Add("COLOR_W").ForeColor = Color.Black;

                        grd01.Styles.Add("COLOR_B").BackColor = Color.LightBlue;
                        grd01.Styles.Add("COLOR_B").ForeColor = Color.Red;

                        grd01.Styles.Add("COLOR_G").BackColor = Color.FromArgb(255, 232, 215);
                        grd01.Styles.Add("COLOR_G").ForeColor = Color.Black;

                        grd01.Styles.Add("COLOR_L").BackColor = Color.FromArgb(255, 251, 239);
                        grd01.Styles.Add("COLOR_L").ForeColor = Color.Black;

                        grd01.Styles.Add("COLOR_R").BackColor = Color.Red;                        

                        CellRange cr = new CellRange();

                        for (int i = 1; i < grd01.Rows.Count; i++)
                        {
                            if (grd01.GetValue(i, "CNT").ToString().Equals("1"))
                            {
                                cr = grd01.GetCellRange(i, grd01.Cols.Fixed, i, grd01.Cols.Count - grd01.Cols.Fixed);
                                cr.Style = grd01.Styles["COLOR_L"];
                            }
                            else if (grd01.GetValue(i, "CNT").ToString().Equals("2"))
                            {
                                cr = grd01.GetCellRange(i, grd01.Cols.Fixed, i, grd01.Cols.Count - grd01.Cols.Fixed);
                                cr.Style = grd01.Styles["COLOR_G"];
                            }
                            else if (grd01.GetValue(i, "CNT").ToString().Equals("3"))
                            {
                                cr = grd01.GetCellRange(i, grd01.Cols.Fixed, i, grd01.Cols.Count - grd01.Cols.Fixed);
                                cr.Style = grd01.Styles["COLOR_B"];
                            }
                            else
                            {
                                cr = grd01.GetCellRange(i, grd01.Cols.Fixed, i, grd01.Cols.Count - grd01.Cols.Fixed);
                                cr.Style = grd01.Styles["COLOR_W"];

                                if (this.grd01.GetValue(i, "COLOR").ToString().Equals("R"))
                                {
                                    this.grd01.SetCellStyle(i, this.grd01.Cols["PERSON"].Index, "COLOR_R");
                                    this.grd01.SetCellStyle(i, this.grd01.Cols["Z_PERSON"].Index, "COLOR_R");
                                }
                            }
                        }
                    }


                    ShowDataCount(source);
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
  
        #endregion

        #region [ 유효성 점검 ]

        private bool IsQueryValid(HEParameterSet set)
        {
            if (set["BIZCD"].ToString().Trim().Length == 0)
            {
                //MsgBox.Show("라인을 선택해주세요!");
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM2.Text);
                return false;
            }
           
            return true;
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cdx01_LINECD.SetValue("");
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
        }
        
        #endregion
    }
}
