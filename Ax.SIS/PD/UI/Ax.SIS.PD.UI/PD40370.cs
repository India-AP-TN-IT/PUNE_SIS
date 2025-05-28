#region ▶ Description & History
/* 
 * 프로그램명 : PD40370 수정이력 조회/등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;


using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// 수정 이력 조회
    /// </summary>
    public partial class PD40370 : AxCommonBaseControl
    {
        //private IPD40370 _WSCOM;
        //private IPDCOMMON_ERM _WSCOM_ERM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD40370";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        public PD40370()
        {
            InitializeComponent();
              
            //_WSCOM_ERM = ClientFactory.CreateChannel<IPDCOMMON_ERM>("PD", "PDCOMMON_ERM.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                #region Tab 1
                this.heDockingTab1.LinkBody = this.panel3;
                this.heDockingTab1.LinkPanel = this.panel2;

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "라인코드", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "Lot No", "LOTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "ALC", "ALC");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 120, "P/NO", "PARTNO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "장착위치", "INSTALL_POS", "POSTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "수정등록일", "INSPEC_DATE", "REGREWORK_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "불량유형", "DEFCD", "DEFCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "불량유형", "DEFNM", "DEF_TYPE");

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "불량장소", "DEFPOSCD", "DEFPOSCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "불량장소", "DEFPOSNM", "DEF_PLACE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "Result Date", "RESULT_DATE", "RESULT_DATE");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 120, "조치유형", "REWORK_CD", "REWORK_CD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "조치유형", "REWORK_NM", "TYPEACTION");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 140, "수정작업일", "REWORK_DATE", "INSPEC_DATE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 080, "조치자", "EMPNM", "MGRT_EMPNM");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 200, "귀책구분", "WHO", "WHO");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 200, "귀책구분", "WHO_REL", "RESPONSTITLE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 180, "수정완료여부", "JOB_STATUS", "JOB_STATUS");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 180, "수정완료여부", "JOB_CD", "JOB_CD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 200, "SEQ", "INSPEC_SEQ", "INSPEC_SEQ");
                
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "INSPEC_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "RESULT_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "REWORK_DATE");
                for (int i = 0; i <= this.grd01.Cols["INSTALL_POS"].Index; i++)
                    this.grd01.Cols[i].AllowMerging = true;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("PRDT_DIV", "");
                set.Add("LANG_SET", this.UserInfo.Language);
                DataSet source1 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_LINELIST"), set);
                //DataSet source1 = _WSCOM_ERM.INQUERY_COMBO_LINELIST(set);

                this.cbl01_LINECD.DataBind(source1.Tables[0], "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");  //라인코드;라인명
                this.cbo02_LINECD.DataBind(source1.Tables[0], "LINECD", "LINENM", this.GetLabel("LINECD") + ";" + this.GetLabel("LINENM"), "C;L");   //라인코드;라인명

                HEParameterSet set2 = new HEParameterSet();
                set2.Add("LANG_SET", this.UserInfo.Language);
                DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_POSINFOLIST"), set2);
                //DataSet source2 = _WSCOM_ERM.INQUERY_COMBO_POSINFOLIST();

                this.cbl01_INSTALL_POS.DataBind(source2.Tables[0], "TYPECD", "OBJECT_NM", this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");    //타입코드;타입명                

                DataTable source3 = new DataTable();
                source3.Columns.Add("CODE");
                source3.Columns.Add("NAME");

                source3.Rows.Add("OK", this.GetLabel("MODIFY_COMP"));   //수정완료
                source3.Rows.Add("NG", this.GetLabel("MODIFY_WAIT"));    //수정대기

                this.cbo01_JOB_STATUS.DataBind(source3);
                axComboBox1.DataBind(source3);
                this.cbl01_INSTALL_POS.DataBind(source2.Tables[0], "TYPECD", "OBJECT_NM", this.GetLabel("TYPE_CD") + ";" + this.GetLabel("TYPE_NM"), "C;L");   //타입코드;타입명 


                
                set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("LANG_SET", this.UserInfo.Language);
                //DataSet source5 = _WSCOM.LoadCombo_DefectProcCode(this.UserInfo.BusinessCode,set);
                DataSet source5 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "LoadCombo_DefectProcCode"), set, "OUT_CURSOR");


                cbo02_DEF_PLACE.DataBind(source5.Tables[0], "DEFPOSCD", "DEFPOSNM", this.GetLabel("DEFPOSCD2") + ";" + this.GetLabel("DEFPOSNM2"), "C;L");  //불량부위코드;불량부위

                set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);
                //DataSet source6 = _WSCOM.LoadCombo_A0AFixCode(this.UserInfo.BusinessCode, set);
                DataSet source6 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "LoadCombo_A0AFixCode"), set, "OUT_CURSOR");

                cbo02_TYPEACTION.DataBind(source6.Tables[0], "OBJECT_ID", "OBJECT_NM", this.GetLabel("MODIFY_CD") + ";" + this.GetLabel("MODIFY_REASON"), "C;L");   //수정코드;수정사유
                cbl01_Jochi.DataBind(source6.Tables[0], "OBJECT_ID", "OBJECT_NM", this.GetLabel("MODIFY_CD") + ";" + this.GetLabel("MODIFY_REASON"), "C;L");  //수정코드;수정사유

                set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);
                //DataSet source7 = _WSCOM.LoadCombo_RespGubun(this.UserInfo.BusinessCode, set);
                DataSet source7 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "LoadCombo_RespGubun"), set, "OUT_CURSOR");
                cob02_RESPONSTITLE.DataBind(source7.Tables[0], "RESPCODE", "RESPNAME", this.GetLabel("AMPM_DIVCD") + ";" + this.GetLabel("DIV_NM"), "C;L"); //구분코드;구분명


                cbo02_DEF_TYPE_MouseClick(null, null);

                this.SetRequired(lbl06_LINE, lbl07_LOTNO, lbl08_INSPEC_DATE);
                #endregion

                #region Tab 2

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd02.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll;
                         
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "Corporation Code", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.L, 100, "Business Code", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "Inspect Date", "INSPEC_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 090, "Result Date", "PROD_DATE", "PROD_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 140, "PART NO.", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 300, "PART NAME", "PARTNM", "PARTNM");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 060, "UNIT", "UNIT", "UNIT");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 080, "QTY", "QTY", "QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "WHOSE FAULT", "WHO_DESC", "WHO_DESC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 070, "S/LOC", "STR_LOC", "STR_LOC");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 080, "STATUS", "JOB_STATUS");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "INSPEC_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "PROD_DATE");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, "QTY");
                #endregion

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
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("INSTALL_POS", this.cbl01_INSTALL_POS.GetValue());
                set.Add("REWORK_CD", this.cbl01_Jochi.GetValue());
                set.Add("JOB_STATUS", this.cbo01_JOB_STATUS.GetValue());
                set.Add("INSPEC_SDATE", this.dtp01_INSPEC_SDATE.GetDateText());
                set.Add("INSPEC_EDATE", this.dtp01_INSPEC_EDATE.GetDateText());
                set.Add("LANG_SET", this.UserInfo.Language);
                set.Add("LOTNO", axTextBox2.GetValue());
                this.BeforeInvokeServer(true);;
                //DataSet source = _WSCOM.INQUERY(bizcd, set);                
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

                this.grd01.SetValue(source);

                set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("LINECD", this.cbl01_LINECD.GetValue());
                set.Add("INSTALL_POS", this.cbl01_INSTALL_POS.GetValue());
                set.Add("INSPEC_SDATE", this.dtp01_INSPEC_SDATE.GetDateText());
                set.Add("INSPEC_EDATE", this.dtp01_INSPEC_EDATE.GetDateText());
                set.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);             
                DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_MAT"), set, "OUT_CURSOR");

                this.grd02.SetValue(source2);
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

        #region [ 기타 이벤트 정의 ]

        private void cbo02_DEF_TYPE_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            HEParameterSet set = new HEParameterSet();
            set.Add("CORCD", this.UserInfo.CorporationCode);
            set.Add("BIZCD", this.UserInfo.BusinessCode);
            set.Add("LINECD", cbo02_LINECD.GetValue().ToString());
            set.Add("LANG_SET", this.UserInfo.Language);

            //DataSet source2 = _WSCOM.LoadCombo_DefList(this.UserInfo.BusinessCode, set);
            DataSet source2 = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "LoadCombo_DefList"), set, "OUT_CURSOR");

            this.cbo02_DEF_TYPE.DataBind(source2.Tables[0], "DEFCD", "DEFNM", this.GetLabel("DEFCD") + ";" + this.GetLabel("DEFNM"), "C;L"); 
        }

        

        private void txt_LOTNO_TITLE_ValueChanged(object sender, EventArgs e)
        {
            if (txt_LOTNO_TITLE.TextLength == 9)
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("LOTNO", txt_LOTNO_TITLE.Text.Trim());

                //DataSet source = _WSCOM.INQUERY_LOTNODATA(this.UserInfo.BusinessCode, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_LOTNODATA"), set, "OUT_CURSOR");

                if (source.Tables[0].Rows.Count > 0)
                {
                    txt_ALC.SetValue(source.Tables[0].Rows[0]["ALCCD"].ToString());
                    txt_PartNo.SetValue(source.Tables[0].Rows[0]["PARTNO"].ToString());
                    txt_InstallPos.SetValue(source.Tables[0].Rows[0]["INSTALL_POS"].ToString());
                }
                else
                {
                    //MsgBox.Show("해당되는 LOTNO가 없습니다.\r\n다시 확인하여 주시기 바랍니다.");
                    //LOTNO가 없습니다.
                    MsgCodeBox.Show("PD00-0029");
                    txt_LOTNO_TITLE.SetValue("");
                }
            }
            else if (txt_LOTNO_TITLE.TextLength <9)
            {
                txt_ALC.SetValue("");
                txt_PartNo.SetValue("");
                txt_InstallPos.SetValue("");
            }
        }

        
        #endregion

        //2014.02.10 - MES1090 작업표준서 MESCODE 전송
        //private bool DN_MESCODE(string bizcd)
        //{
        //    string msg = "";
        //    try
        //    {
                
                
        //        msg = _WSCOM_ERM.SyncMESIF("MES2104", bizcd).Tables[0].Rows[0][0].ToString();

        //        if (!msg.StartsWith("OK"))
        //        {
        //            if (bizcd.Equals("5210"))
        //            {
        //                this.AfterInvokeServer();
        //                //MsgBox.Show("울산사업장 MESCODE 전송에 실패하였습니다.");
        //                MsgCodeBox.Show("PD00-0004");
        //                return false;
        //            }
        //            else if (bizcd.Equals("5220"))
        //            {
        //                this.AfterInvokeServer();
        //                //MsgBox.Show("아산사업장 MESCODE 전송에 실패하였습니다.");
        //                MsgCodeBox.Show("PD00-0005");
        //                return false;

        //            }
        //            else
        //            {
        //                this.AfterInvokeServer();
        //                MsgBox.Show(msg);
        //                return false;
        //            }
        //        }

        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        this.AfterInvokeServer();
        //        MsgBox.Show(ex.ToString());
        //    }
        //    return true;
        //}

        #region [ 사용자 정의 메서드 ]

        private void ctlReset()
        {
            cbo02_LINECD.SelectedIndex = -1;
            txt_LOTNO_TITLE.SetValue("");
            cbo02_DEF_TYPE.SelectedIndex = -1;
            cbo02_DEF_PLACE.SelectedIndex = -1;
            cbo02_TYPEACTION.SelectedIndex = -1;
            
            cob02_RESPONSTITLE.SelectedIndex = -1;
            txt_ALC.SetValue("");
            txt_PartNo.SetValue("");
            txt_InstallPos.SetValue("");
            axTextBox1.SetValue("");
            axComboBox1.SelectedIndex = -1;
        }

        #endregion

        #region [ 유효성 체크 ]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 수정이력 정보가 없습니다.");
                    //저장할 데이터가 존재하지 않습니다.
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                }                

                if (cbo02_LINECD.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show(String.Format("라인이 선택되지 않았습니다."));
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("LINE"));
                    return false;
                }

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    DataRow row = source.Tables[0].Rows[i];
                    
                    if (this.Nvl(row["LOTNO"], "").ToString().Length == 0)
                    {
                        //MsgBox.Show(String.Format("{LOTNO}가 선택되지 않았습니다."));
                        MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("LOTNO"));
                        return false;
                    }

                     
                }

                //if (MsgBox.Show("입력하신 수정이력 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

        #endregion

        private void btn01_save_Click(object sender, EventArgs e)
        {
            try
            {
                
                DataSet source;

                source = AxFlexGrid.GetDataSourceSchema("CORCD", "BIZCD", "LOTNO", "INSPEC_SEQ", "INSPEC_DATE", "INSPEC_TIME", "PROCCD", "EMPNO_INSPEC", "DEFCD", "DEFPOSCD",
                                 "REWORK_CD", "REWORK_DESC", "REWORK_DATE", "REWORK_TIME", "EMPNO_REWORK", "JOB_STATUS", "WHO_REL");

                DataRow dr = source.Tables[0].NewRow();

                dr["CORCD"] = this.UserInfo.CorporationCode;
                dr["BIZCD"] = this.UserInfo.BusinessCode;
                dr["LOTNO"] = txt_LOTNO_TITLE.GetValue().ToString();
                dr["INSPEC_SEQ"] = axTextBox1.GetValue().ToString();
                dr["INSPEC_DATE"] = DateTime.Now.ToString("yyyy-MM-dd");
                dr["INSPEC_TIME"] = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                dr["PROCCD"] = "";
                dr["EMPNO_INSPEC"] = this.UserInfo.EmpNo;
                dr["DEFCD"] = cbo02_DEF_TYPE.GetValue().ToString();
                dr["DEFPOSCD"] = cbo02_DEF_PLACE.GetValue().ToString();
                dr["REWORK_CD"] = cbo02_TYPEACTION.GetValue().ToString();
                dr["REWORK_DESC"] = cbo02_TYPEACTION.Text;
                dr["REWORK_DATE"] = dtp01_EDITWORK.GetDateText().ToString();
                dr["REWORK_TIME"] = DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                dr["EMPNO_REWORK"] = this.UserInfo.EmpNo;
                dr["JOB_STATUS"] = axComboBox1.GetValue();
                dr["WHO_REL"] = cob02_RESPONSTITLE.GetValue().ToString();

                source.Tables[0].Rows.Add(dr);

                if (!this.IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATASAVE"), source);
                //_WSCOM.SAVE(this.UserInfo.BusinessCode, source);

                //###bool isSyncOK = this.DN_MESCODE(this.UserInfo.BusinessCode);

                this.AfterInvokeServer();
                
                //MsgBox.Show("성공적으로 저장하였습니다");
                //저장되었습니다.
                MsgCodeBox.Show("CD00-0071");
                this.BtnQuery_Click(null, null);

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

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string linecd = grd01.GetValue(grd01.SelectedRowIndex, "LINECD").ToString();
            string lotno =  grd01.GetValue(grd01.SelectedRowIndex, "LOTNO").ToString();
            string workDate =  grd01.GetValue(grd01.SelectedRowIndex, "REWORK_DATE").ToString();
            string DEFCD =  grd01.GetValue(grd01.SelectedRowIndex, "DEFCD").ToString();
            string REWORK_CD = grd01.GetValue(grd01.SelectedRowIndex, "REWORK_CD").ToString();
            string WHO = grd01.GetValue(grd01.SelectedRowIndex, "WHO").ToString();
            string DEFPOSCD = grd01.GetValue(grd01.SelectedRowIndex, "DEFPOSCD").ToString();
            string INS_SEQ = grd01.GetValue(grd01.SelectedRowIndex, "INSPEC_SEQ").ToString();
            string JOB_STATUS = grd01.GetValue(grd01.SelectedRowIndex, "JOB_CD").ToString();
            if(workDate.Length>=10)
            {
                dtp01_EDITWORK.SetValue(new DateTime(Convert.ToInt32(workDate.Substring(0, 4)), Convert.ToInt32(workDate.Substring(5, 2)), Convert.ToInt32(workDate.Substring(8, 2))));
            }
            cbo02_LINECD.SetValue(linecd);
            txt_LOTNO_TITLE.SetValue(lotno);
            cbo02_DEF_TYPE.SetValue(DEFCD);
            cbo02_TYPEACTION.SetValue(REWORK_CD);
            cob02_RESPONSTITLE.SetValue(WHO);
            cbo02_DEF_PLACE.SetValue(DEFPOSCD);
            axTextBox1.SetValue(INS_SEQ);
            axComboBox1.SetValue(JOB_STATUS);

            
        }

        
    }
}
