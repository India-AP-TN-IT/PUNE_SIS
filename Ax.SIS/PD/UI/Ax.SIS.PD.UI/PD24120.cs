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

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>        
    /// </summary>
    public partial class PD24120 : AxCommonBaseControl
    {
        //private IPM24120 _WSCOM;
        private string PACKAGE_NAME = "APG_PD24120";
        public PD24120()
        {
            InitializeComponent();
            //_WSCOM = ClientFactory.CreateChannel<IPM24120>("PM04", "PM24120.svc", "CustomBinding");
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                if (this.UserInfo.IsAdmin.Equals("Y"))
                    this.cbo01_BIZCD.SetReadOnly(false);
                else
                    this.cbo01_BIZCD.SetReadOnly(true);

                //this.grd01.AllowEditing = true;              
                //this.grd01.Initialize();

                //this.grd01.CurrentContextMenu.Items[0].Visible = false;
                //this.grd01.CurrentContextMenu.Items[1].Visible = false;
                //this.grd01.CurrentContextMenu.Items[2].Visible = false;

                this.grd01.Initialize();
                this.grd01.AllowEditing = true;

                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 060, "LINE", "LINECD");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 100, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 110, "PARTNO", "PARTNO", "PARTNO");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 060, "ALC", "ALCCD", "ALCCD");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 080, "LOTNO", "LOTNO");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 100, "생산일자", "PROD_DATE", "PROD_DATE");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 120, "실입고일자", "IN_READ_DATE", "IN_READ_DATE");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 120, "실입고시간", "IN_READ_TIME", "IN_READ_TIME");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 050, "선택", "CHK", "CHK");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "사유코드", "DEL_TYPECD", "DEL_TYPECD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "비고", "REMARK", "REMARK");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "저장위치", "STR_LOC", "STR_LOC");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "CHK");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "Q4", "DEL_TYPECD", true);
                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("BIZCD");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetStrLoc(), "STR_LOC");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "IN_READ_DATE");


                this.cdx01_LINECD.HEPopupHelper = new CM30030P1();
                this.cdx01_LINECD.PopupTitle = this.GetLabel("LINECD");
                this.cdx01_LINECD.CodeParameterName = "LINECD";
                this.cdx01_LINECD.NameParameterName = "LINENM";
                this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0A");
                this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");
                this.cdx01_LINECD.HEUserParameterSetValue("PLANT_DIV", "");
                this.cdx01_LINECD.HEUserParameterSetValue("LINECD_DIV", "AD4");
                //this.cdx01_LINECD.HEPopupHelper = new CM20020P1();
                //this.cdx01_LINECD.PopupTitle = "라인코드";
                //this.cdx01_LINECD.CodeParameterName = "LINECD";
                //this.cdx01_LINECD.NameParameterName = "LINENM";
                //this.cdx01_LINECD.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                //this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                //this.cdx01_LINECD.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                //this.cdx01_LINECD.HEUserParameterSetValue("PRDT_DIV", "A0A");
                //this.cdx01_LINECD.HEUserParameterSetValue("DATE", "");

                this.cdx01_STR_LOC.HEPopupHelper = new CM30040P1(); //new PM20015P1();
                this.cdx01_STR_LOC.PopupTitle = this.GetLabel("STR_LOC");
                this.cdx01_STR_LOC.CodeParameterName = "STR_LOC";
                this.cdx01_STR_LOC.NameParameterName = "STR_LOCNM";
                this.cdx01_STR_LOC.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                this.cdx01_STR_LOC.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
                this.cdx01_STR_LOC.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                

                this.cbo01_INSTALL_POS.DataBind("A7", true);
                this.rdo01_PD24120_RDO1.Checked = true;
                this.chk01_SAP_YN.Checked = false;    //SAP 폐기처리

                this.SetRequired(this.lbl01_BIZNM, this.lbl01_LINECD);
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
                paramSet.Add("INSTALL_POS", this.cbo01_INSTALL_POS.GetValue());
                paramSet.Add("LOTNO", this.txt01_LOTNO.GetValue());
                paramSet.Add("ALCCD", this.txt01_ALCCD.GetValue());
                paramSet.Add("USERID", this.UserInfo.UserID);
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                paramSet.Add("STR_LOC", this.cdx01_STR_LOC.GetValue());
                if (!IsQueryValid(paramSet)) return;

                this.BeforeInvokeServer(true);

                //사업장에 따라 저장위치 다르므로, 조회시 그리드 콤보 다시 바인딩함.
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, this.GetStrLoc(), "STR_LOC");

                using (AxClientProxy proxy = new AxClientProxy())
                {
                    DataSet source = proxy.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_MES2011"), paramSet);
                    this.grd01.SetValue(source.Tables[0]);
                    this.grd01.setAlternateRowStyle("ALCCD");
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

        protected override void BtnProcess_Click(object sender, EventArgs e)
        {
            try
            {
               

                DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "BIZCD", "LOTNO", "PROD_DATE", "EMPNO",
                    "OPT","DEL_DATE","PARTNO","DEL_TYPECD","DEL_TYPENM", "ALCCD","INSTALL_POS", "LINECD", "REMARK", "STR_LOC", "SAP_SCRAP");
                
                string option = this.rdo01_PD24120_RDO1.Checked ? "STOCK" : "RSLT";
                string option_SAP = this.chk01_SAP_YN.Checked ? "SAP" : "SIS";    //SAP 폐기처리

                foreach (DataRow dr in set.Tables[0].Rows)
                {
                    dr["EMPNO"] = this.UserInfo.EmpNo;
                    dr["OPT"] = option;
                    dr["SAP_SCRAP"] = option_SAP;    //SAP 폐기처리
                }

                DataSet ds = set.Clone();
                

                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    bool bIsCheckd = bool.Parse(this.grd01[i, "CHK"].ToString());
                    if (bIsCheckd)
                    {
                      
                        DataRow newRow = ds.Tables[0].NewRow();
                        newRow["CORCD"] = this.grd01[i, "CORCD"];
                        newRow["BIZCD"] = this.grd01[i, "BIZCD"];
                        newRow["LOTNO"] = this.grd01[i, "LOTNO"];
                        newRow["PROD_DATE"] = this.grd01[i, "PROD_DATE"];
                        newRow["EMPNO"] = this.UserInfo.EmpNo;
                        newRow["OPT"] = option;
                        newRow["SAP_SCRAP"] = option_SAP;    //SAP 폐기처리
                        newRow["PARTNO"] = this.grd01[i, "PARTNO"];                        
                        newRow["DEL_TYPECD"] = this.grd01.GetValue(i,"DEL_TYPECD"); //([i, "DEL_TYPECD"];
                        newRow["DEL_TYPENM"] = this.grd01.GetText(i, "DEL_TYPECD");
                        newRow["ALCCD"] = this.grd01[i, "ALCCD"];
                        newRow["INSTALL_POS"] = "A7" + this.grd01[i, "INSTALL_POS"];
                        newRow["LINECD"] = this.grd01[i, "LINECD"];
                        newRow["REMARK"] = this.grd01[i, "REMARK"];
                        newRow["STR_LOC"] = this.grd01[i, "STR_LOC"];

                        ds.Tables[0].Rows.Add(newRow);
                    }
                }

                DataTable dtMES = new DataTable();
                dtMES.TableName = "MES2013";
                dtMES.Columns.Add("CORCD");
                dtMES.Columns.Add("BIZCD");
                dtMES.Columns.Add("LOTNO");
                dtMES.Columns.Add("PROD_DATE");
                dtMES.Columns.Add("EMPNO");
                dtMES.Columns.Add("OPT");
                dtMES.Columns.Add("SAP_SCRAP");      //SAP 폐기처리
                dtMES.Columns.Add("DEL_DATE");
                dtMES.Columns.Add("PARTNO");
                dtMES.Columns.Add("DEL_TYPECD");
                dtMES.Columns.Add("DEL_TYPENM");
                dtMES.Columns.Add("REMARK");
                dtMES.Columns.Add("STR_LOC");
                dtMES.Columns.Add("LANG_SET");
                DataRow drMES = null;

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    drMES = dtMES.NewRow();
                    drMES["CORCD"] = row["CORCD"];
                    drMES["BIZCD"] = row["BIZCD"];
                    drMES["LOTNO"] = row["LOTNO"];
                    drMES["PROD_DATE"] = row["PROD_DATE"];
                    drMES["EMPNO"] = row["EMPNO"];
                    drMES["OPT"] = row["OPT"];
                    drMES["SAP_SCRAP"] = row["SAP_SCRAP"];    //SAP 폐기처리
                    drMES["DEL_DATE"] = row["DEL_DATE"];
                    drMES["PARTNO"] = row["PARTNO"];
                    drMES["DEL_TYPECD"] = row["DEL_TYPECD"];
                    drMES["DEL_TYPENM"] = row["DEL_TYPENM"];
                    drMES["REMARK"] = row["REMARK"];
                    drMES["STR_LOC"] = row["STR_LOC"];
                    drMES["LANG_SET"] = this.UserInfo.Language;
                    dtMES.Rows.Add(drMES);
                }

                DataSet set2 = new DataSet();
                set2.Tables.Add(dtMES);

                DataSet ds1 = new DataSet();
                ds1.Tables.Add(dtMES.Copy());

                if (!IsProcessValid(ds1)) return;

                AxClientProxy proxy = new AxClientProxy();

                this.BeforeInvokeServer();
                

                proxy.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "PROCESS"), ds1);
                
                #region "기존코드"
                //if (cbo01_BIZCD.GetValue().Equals("5210"))
                //{
                //    DataSet ds1 = new DataSet();
                //    ds1.Tables.Add(dtMES.Copy());

                //    DataSet ds2 = new DataSet();
                //    ds2.Tables.Add(dtPM4030.Copy());

                //    if (this.rdo01_PM24120_RDO2.Checked)
                //    {
                //        proxy.MultipleExecuteNonQueryTx(new string[] { "PKG_PM24120.PROCESS", "PKG_PM24120.SAVE" },
                //                                        new DataSet[] { ds1, ds2 });
                //    }
                //    else
                //    {
                //        proxy.ExecuteNonQueryTx("PKG_PM24120.PROCESS", ds1);
                //    }
                //    _WSCOM.Process(set2, this.cbo01_BIZCD.GetValue().ToString());
                //}
                //else
                //{
                //    _WSCOM.Process(set2, this.cbo01_BIZCD.GetValue().ToString());
                //} 
                #endregion
                                
                this.AfterInvokeServer();

                BtnQuery_Click(null, null);

                //MsgBox.Show("LOTNO별 창고 재고를 정리가 정상적으로 처리 되었습니다.");
                MsgCodeBox.Show("CD00-0013");
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

        private bool IsProcessValid(DataSet souce)
        {
            if (souce.Tables[0].Rows.Count <= 0)
            {
                MsgCodeBox.Show("COM-00021"); //처리할 대상 데이터가 없습니다.
                return false;
            }
            //if (MsgBox.Show("LOTNO별 창고 재고를 정리하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("PD00-0081", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }

        private bool IsQueryValid(HEParameterSet set)
        {
            if (set["BIZCD"].ToString().Trim().Length == 0)
            {
                //MsgBox.Show("라인을 선택해주세요!");
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM.Text);
                return false;
            }

            if (set["LINECD"].ToString().Trim().Length == 0)
            {
                //MsgBox.Show("라인을 선택해주세요!");
                MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("LINECD"));
                return false;
            }

            return true;
        }

        #endregion

        #region [ 기타 이벤트 정의 ]

        private void cdx01_LINECD_ButtonClickAfter(object sender, EventArgs args)
        {
            try
            {
                //라인코드 선택시 연관된 저장위치 자동 셋팅함. 현재 주석처리함. 차후 연동해달라는 요구사항 발생시 주석해제하면 됨.
                //if (this.cdx01_LINECD.SelectedPopupValue != null)
                //{
                //    if (this.cdx01_LINECD.SelectedPopupValue["STR_LOC"].ToString() != "")
                //    {
                //        this.cdx01_STR_LOC.SetValue(this.cdx01_LINECD.SelectedPopupValue["STR_LOC"].ToString());
                //    }
                //}
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //저장위치
        private void cdx01_STR_LOC_ButtonClickBefore(object sender, EventArgs args)
        {
            try
            {
                this.cdx01_STR_LOC.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }


        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cdx01_LINECD.SetValue("");
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
            this.cdx01_STR_LOC.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());

        }

        #endregion

        #region [ 사용자 정의 메서드 ]
        /// <summary>
        /// 저장위치 목록 조회(콤보상자용)
        /// </summary>
        /// <returns></returns>
        private DataTable GetStrLoc()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                set.Add("STR_LOC", string.Empty);
                set.Add("STR_LOCNM", string.Empty);
                set.Add("LANG_SET", this.UserInfo.Language);

                using (AxClientProxy proxy = new AxClientProxy())
                {
                    DataSet source = proxy.ExecuteDataSet("APG_CM30040.INQUERY", set);
                    source.Tables[0].Columns["STR_LOC"].SetOrdinal(0);
                    source.Tables[0].Columns["STR_LOCNM"].SetOrdinal(1);
                    return source.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
