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
using System.Data.OleDb;
using System.Text;
using Ax.SIS.CM.UI;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class ZPD20050 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;


        public ZPD20050()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {

                this.cdx01_LINECD.HEPopupHelper = new CM30030P1(this.GetLabel("LINECD"));//new PD20043P1();
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", this.UserInfo.PlantDiv); //2013.03.20 공장구분 추가(배명희)
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "");

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(true);

                this.cbo01_CORCD.DataBind_CORCD();
                this.cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                this.cbo01_CORCD.SetReadOnly(true);

                #region [그리드1]

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.Initialize(2, 2);
                this.grd01.AllowSorting = AllowSortingEnum.None;
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "Part Number", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "Part Description", "PARTNM", "PARTNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 210, "LINE", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 210, "LINE", "LINENM", "LINENM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 210, "INSPEC_DATE", "INSPEC_DATE", "INSPEC_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "PROD/QTY", "PROD_QTY", "PROD_QTY");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "NG/QTY", "CNT_SKP", "CNT_SKP");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "SET/QTY", "CNT_INI", "CNT_INI");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 70, "FML/QTY", "CNT_SMP", "CNT_SMP");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 90, "TOTAL/NG", "CNT_TOT", "CNT_TOT");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 95, "NG/RATE(%)", "NG_RATE", "NG_RATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 95, "SCRAP/QTY", "SCR_TOT", "SCR_TOT");

                for (int i = 0; i < grd01.Cols.Count; i++)
                {
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;
                }
                this.grd01.AddMerge(0, 1, "CORCD", "CORCD");
                this.grd01.AddMerge(0, 1, "BIZCD", "BIZCD");
                this.grd01.AddMerge(0, 0, "PARTNO", "PARTNM");
                this.grd01.SetHeadTitle(0, "PARTNO", "PART");
                this.grd01.AddMerge(0, 1, "LINENM", "LINENM");
                this.grd01.AddMerge(0, 1, "INSPEC_DATE", "INSPEC_DATE");
                this.grd01.AddMerge(0, 1, "PROD_QTY", "PROD_QTY");

                this.grd01.AddMerge(0, 0, "CNT_SKP", "NG_RATE");
                this.grd01.SetHeadTitle(0, "CNT_SKP", "INSPECTION - NG");
                this.grd01.AddMerge(0, 1, "SCR_TOT", "SCR_TOT");
                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd02.AllowSorting = AllowSortingEnum.None;
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "LOT", "LOTNO", "LOTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "P/Date", "PDATE", "PDATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "S/Date", "SCR_DATE", "SCR_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "STATUS", "STATUS", "STATUS");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "CHK_FNL", "CHK_FNL", "CHK_FNL");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 110, "LOCATION", "LOCNM", "LOCNM");




                this.grd03.AllowEditing = false;
                this.grd03.Initialize();
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd03.AllowSorting = AllowSortingEnum.None;
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "LOT", "LOTNO", "LOTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 160, "P/Date", "PDATE", "PDATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 70, "STATUS", "TY", "TY");
     


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
                DataSet source = null;
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("YMD", dtp01_BEG_DATE.GetDateText());
                set.Add("LINECD", cdx01_LINECD.GetValue());
                set.Add("PARTNO", Txt_PartNo.Text);

                this.BeforeInvokeServer(true);

                source = _WSCOM.ExecuteDataSet("ZPG_ZPD20050.INQUERY_HEAD", set, "OUT_CURSOR");

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
                DataSet sourceIU = null;
                sourceIU = this.grd01.GetValue(AxFlexGrid.FActionType.Save
                                                              , "CORCD"
                                                              , "BIZCD"
                                                              
                                                              , "PARTNO"
                                                              ,"TIT01"
                                                              , "TIT02"
                                                              , "TIT03"
                                                              , "TIT04"
                                                              , "TIT05"
                                                              , "TIT06"
                                                              , "TIT07"
                                                              , "SPC01"
                                                              , "SPC02"
                                                              , "SPC03"
                                                              , "SPC04"
                                                              , "SPC05"
                                                              , "SPC06"
                                                              , "SPC07"
                                                            );
                

                if (sourceIU.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow rows in sourceIU.Tables[0].Rows)
                    {
                        rows["CORCD"] = UserInfo.CorporationCode;
                        rows["BIZCD"] = UserInfo.BusinessCode;
                    }

                    if (!IsSaveValid(sourceIU)) return;

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_PD20050.SAVE", sourceIU);

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

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(grd01.Row >=0)
            {
                string linecd = grd01.GetValue(grd01.Row, "LINECD").ToString();
                string corcd = grd01.GetValue(grd01.Row, "CORCD").ToString();
                string bizcd = grd01.GetValue(grd01.Row, "BIZCD").ToString();
                string ymd = grd01.GetValue(grd01.Row, "INSPEC_DATE").ToString();
                string partno  = grd01.GetValue(grd01.Row, "PARTNO").ToString();



                HEParameterSet set = new HEParameterSet();
                DataSet source = null;
                set.Add("CORCD", corcd);
                set.Add("BIZCD", bizcd);
                set.Add("YMD", ymd);
                set.Add("LINECD", linecd);
                set.Add("PARTNO", partno);

                if (tabControl1.SelectedIndex == 0)
                {
                    source = _WSCOM.ExecuteDataSet("ZPG_ZPD20050.INQUERY_DET_NG", set, "OUT_CURSOR");



                    this.grd03.SetValue(source.Tables[0]);
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    source = _WSCOM.ExecuteDataSet("ZPG_ZPD20050.INQUERY_DET_SCR", set, "OUT_CURSOR");

                 

                    this.grd02.SetValue(source.Tables[0]);
                }
            }
        }

        


    }
}
