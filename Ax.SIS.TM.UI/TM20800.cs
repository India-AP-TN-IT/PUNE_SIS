#region ▶ Description & History
/* 
 * 프로그램명 : PD40520 금형투입이력 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
 *				
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
using HE.Framework.Core.Report;

namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// 수지 Grade 관리
    /// </summary>
    public partial class TM20800 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _DB;

        #region [ 초기화 작업 정의 ]

        public TM20800()
        {
            InitializeComponent();

            _DB = new AxClientProxy();
            
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

                

                this.grd01.AllowEditing = true;
                this.grd01.Initialize(2, 2);    // 2 Header Rows
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 80, "BIZCD", "BIZCD", "BIZCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "PAGER/GRP", "GRPID", "GRPID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "PAGER/ID", "PID", "PID");
                
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "LOCATION", "LOCATION", "LOCATION");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "GROUP", "B01", "B01");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "DESC", "D01", "D01");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "GROUP", "B02", "B02");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "DESC", "D02", "D02");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "GROUP", "B03", "B03");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "DESC", "D03", "D03");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "GROUP", "B04", "B04");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "DESC", "D04", "D04");

                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 80, "GROUP", "B05", "B05");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "DESC", "D05", "D05");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 250, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");


                //<<Merge Grid Head
                for (int i = 0; i < grd01.Cols.Count; i++)
                {
                    this.grd01[1, i] = this.grd01.Cols[i].Caption;
                }
                this.grd01.AddMerge(0, 1, "GRPID", "GRPID");
                this.grd01.AddMerge(0, 1, "PID", "PID");
                this.grd01.AddMerge(0, 1, "LOCATION", "LOCATION");

                this.grd01.AddMerge(0, 0, "B01", "D01");
                this.grd01.SetHeadTitle(0, "B01", "Button#1");

                this.grd01.AddMerge(0, 0, "B02", "D02");
                this.grd01.SetHeadTitle(0, "B02", "Button#2");

                this.grd01.AddMerge(0, 0, "B03", "D03");
                this.grd01.SetHeadTitle(0, "B03", "Button#3");

                this.grd01.AddMerge(0, 0, "B04", "D04");
                this.grd01.SetHeadTitle(0, "B04", "Button#4");

                this.grd01.AddMerge(0, 0, "B05", "D05");
                this.grd01.SetHeadTitle(0, "B05", "Button#5");
                //>>

                
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
                DataSet ds = grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "GRPID", "PID", "LOCATION", "B01", "D01", "B02", "D02", "B03", "D03", "B04", "D04", "B05", "D05","UPDATE_ID");

                DataSet ds_del = grd01.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "BIZCD", "GRPID", "PID");
                if (ds_del.Tables.Count > 0 && ds_del.Tables[0].Rows.Count > 0)
                {
                    _DB.ExecuteNonQueryTx("APG_TM20800.DEL_DATA", ds_del);
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                    {
                        ds.Tables[0].Rows[row]["CORCD"] = cbo01_CORCD.GetValue().ToString();
                        ds.Tables[0].Rows[row]["BIZCD"] = cbo01_BIZCD.GetValue().ToString();
                        ds.Tables[0].Rows[row]["UPDATE_ID"] = UserInfo.UserID;
                    }
                    _DB.ExecuteNonQueryTx("APG_TM20800.SAVE", ds);

                }
                BtnQuery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                
            }
            finally
            {
               
            }
        }
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                HEParameterSet param = new HEParameterSet();

                param.Add("CORCD", cbo01_CORCD.GetValue());
                param.Add("BIZCD", cbo01_BIZCD.GetValue());
                param.Add("GRPID", txt_GRP.GetValue());
                param.Add("PID", txt_PID.GetValue());
                param.Add("LOCATION", txt_Loc.GetValue());
                DataSet ds = _DB.ExecuteDataSet("APG_TM20800.INQUERY", param);

                grd01.SetValue(ds);

            }
            catch (FaultException<ExceptionDetail> ex)
            {
               
            }
            finally
            {
            }
        }
        
        #endregion
        private void DlgCodeHelp(string colName, int row, string findStr)
        {
            
            HEParameterSet paramSet = new HEParameterSet();
            DataTable dt = new DataTable();
         

            paramSet = new HEParameterSet();
            paramSet.Add("CORCD", cbo01_CORCD.GetValue());
            paramSet.Add("BIZCD", cbo01_BIZCD.GetValue());
            paramSet.Add("TY", "GRPCD");
            paramSet.Add("CD", findStr);
            paramSet.Add("NM", "");
            dt = _DB.ExecuteDataSet("APG_TM20500.INQUERY_DLG", paramSet, "OUT_CURSOR").Tables[0];

            string cdTitle = "";
            string nmTitle = "";
            string nm = "";
            string popupTitle = "";
            switch(colName)
            {
                case "B01":
                    popupTitle = "Group";
                    nmTitle = "G/Name";
                    cdTitle = "G/NO.";
                    nm = "D01";
                    break;
                case "B02":
                    popupTitle = "Group";
                    nmTitle = "G/Name";
                    cdTitle = "G/NO.";
                    nm = "D02";
                    break;
                case "B03":
                    popupTitle = "Group";
                    nmTitle = "G/Name";
                    cdTitle = "G/NO.";
                    nm = "D03";
                    break;
                case "B04":
                    popupTitle = "Group";
                    nmTitle = "G/Name";
                    cdTitle = "G/NO.";
                    nm = "D04";
                    break;
                case "B05":
                    popupTitle = "Group";
                    nmTitle = "G/Name";
                    cdTitle = "G/NO.";
                    nm = "D05";
                    break;
            }
            if (string.IsNullOrEmpty(findStr))
            {
                grd01.SetValue(row, 0, "U");
                grd01.SetValue(row, colName, "");
                grd01.SetValue(row, nm, "");
            }
            if (dt.Rows.Count > 1)
            {
                PopupHelper helper = null;
                TM20500_DLG dlg = new TM20500_DLG("GRPCD", cdTitle, nmTitle, findStr, "");

                
                dlg.HEUserParameterSetValue("CORCD", cbo01_CORCD.GetValue());
                dlg.HEUserParameterSetValue("BIZCD", cbo01_BIZCD.GetValue());

                helper = new PopupHelper(dlg, popupTitle);
                helper.ShowDialog();
                DataRow slectedRow = (DataRow)helper.SelectedData;
                if (slectedRow != null)
                {
                    grd01.SetValue(grd01.Row, 0, "U");
                    grd01.SetValue(grd01.Row, colName, slectedRow["CD"]);
                    grd01.SetValue(grd01.Row, nm, slectedRow["NM"]);
                }
            }
            else if(dt.Rows.Count==1)
            {
                grd01.SetValue(row, 0, "U");
                grd01.SetValue(row, colName, dt.Rows[0]["CD"]);
                grd01.SetValue(row, nm, dt.Rows[0]["NM"]);
            }
            else
            {
                grd01.SetValue(row, 0, "U");
                grd01.SetValue(row, colName, "");
                grd01.SetValue(row, nm, "");
            }
        }
        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {

                int row = e.Row;
                int col = e.Col;
                if (row < this.grd01.Rows.Fixed) return;
                string colName = grd01.Cols[col].UserData.ToString();

                if (colName == "B01" || colName == "B02" || colName == "B03" || colName == "B04" || colName == "B05")
                {
                    grd01.FinishEditing(true);
                    string findStr = grd01.GetValue(e.Row, e.Col).ToString();
                    
                    DlgCodeHelp(colName, row, findStr);
                }
            }
            catch(Exception eLog)
            {
                MsgBox.Show(eLog.Message, "Error");
            }
            finally
            {

            }

        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = grd01.Row;
            int col = grd01.Col;
            if (row < this.grd01.Rows.Fixed) return;
            string colName = grd01.Cols[col].UserData.ToString();
            if (grd01.AllowEditing)
            {
                if (colName == "D01" || colName == "D02" || colName == "D03" || colName == "D04" || colName == "D05")
                {
                    string colnm = "";
                    switch (colName)
                    {
                        case "D01":
                            colnm = "B01";
                            break;
                        case "D02":
                            colnm = "B02";
                            break;
                        case "D03":
                            colnm = "B03";
                            break;
                        case "D04":
                            colnm = "B04";
                            break;
                        case "D05":
                            colnm = "B05";
                            break;
                    }
                    string findStr = grd01.GetValue(row, colnm).ToString();
                    DlgCodeHelp(colnm, row, findStr);
                }
            }
        }






    }
}

