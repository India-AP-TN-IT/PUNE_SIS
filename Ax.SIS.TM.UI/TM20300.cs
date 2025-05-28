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


namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class TM20300 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private const string _IntFormat = "###,###,###,###,##0";

        private const int IDX_CHECK_COLUMN = 1;//2019.04.16

        public TM20300()
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


                this.cdx01_PROCCD.HEPopupHelper = new TM20300P1();
                this.cdx01_PROCCD.NameParameterName = "PROCNM";
                this.cdx01_PROCCD.CodeParameterName = "PROCCD";
                this.cdx01_PROCCD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_PROCCD.HEUserParameterSetValue("BIZCD", this.UserInfo.BusinessCode);

                this.cdx01_LINECD.HEPopupHelper = new Ax.SIS.CM.UI.CM30030P1(this.GetLabel("LINECD")); //new PM21310P1();
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.UserInfo.BusinessCode);
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");
                                                          

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 180, "LINE", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "LINE", "LINENM", "LINENM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 180, "STATION", "PROCCD", "PROCCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "STATION", "PROCNM", "PROCNM");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "T/Counter", "PLAN_CNT", "PLAN_CNT");
                this.grd01.Cols["PLAN_CNT"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 120, "C/Counter", "CUR_CNT", "CUR_CNT");


                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");
                

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
                set.Add("LINECD", cdx01_LINECD.GetValue());
                set.Add("PROCCD", cdx01_PROCCD.GetValue());
               
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_TM20300.INQUERY", set, "OUT_CURSOR");

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
                                                      , "LINECD"
                                                      , "PROCCD"
                                                      , "PLAN_CNT"
                                                      , "UPDATE_ID"
                                                      
                                                    );

                DataSet sourceD = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                                                        "CORCD"
                                                      , "BIZCD"
                                                      , "LINECD"
                                                      , "PROCCD"
                                                    );

                if (sourceIU.Tables[0].Rows.Count > 0)
                {
                    

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_TM20300.DATA_SAVE", sourceIU);

                    this.AfterInvokeServer();
                }

                if (sourceD.Tables[0].Rows.Count > 0)
                {

                    this.BeforeInvokeServer(true);

                    _WSCOM.ExecuteNonQueryTx("APG_TM20300.DATA_REMOVE", sourceD);

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
                    this.grd01.SetValue(i, "PROCCD", cdx01_PROCCD.GetValue());
                    this.grd01.SetValue(i, "LINECD", cdx01_LINECD.GetValue());
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
            string station = cdx01_PROCCD.GetValue().ToString();
            string line = cdx01_LINECD.GetValue().ToString();
           
            if(string.IsNullOrEmpty(bizcd))
            {
                args.Cancel = true;
                MsgBox.Show("Business Code is mandatory for input!!");
                return;
            }
            else if (string.IsNullOrEmpty(station))
            {
                args.Cancel = true;
                MsgBox.Show("Station Code is mandatory for input!!");
                return;
            }
            else if (string.IsNullOrEmpty(line))
            {
                args.Cancel = true;
                MsgBox.Show("Line Code is mandatory for input!!");
                return;
            }
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx01_PROCCD.HEPopupHelper = new TM20300P1();
            this.cdx01_PROCCD.NameParameterName = "PROCNM";
            this.cdx01_PROCCD.CodeParameterName = "PROCCD";
            this.cdx01_PROCCD.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
            this.cdx01_PROCCD.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());

            this.cdx01_LINECD.HEPopupHelper = new Ax.SIS.CM.UI.CM30030P1(this.GetLabel("LINECD")); //new PM21310P1();
            this.cdx01_LINECD.CodeParameterName = "LINECD";
            this.cdx01_LINECD.NameParameterName = "LINENM";
            this.cdx01_LINECD.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());
            this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
            this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "");
            this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
            this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
            this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");

        }



    }
}
