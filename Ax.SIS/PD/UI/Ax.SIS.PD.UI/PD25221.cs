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

namespace Ax.SIS.PD.UI
{
    /// <summary>
    /// <b>UI 화면을 정의하는 사용자 정의 클래스</b>        
    /// </summary>
    public partial class PD25221 : AxCommonBaseControl
    {
        //private IPM24120 _WSCOM;
        private string PACKAGE_NAME = "APG_PD25221";
        private AxClientProxy _WSCOM;

        public PD25221()
        {
            InitializeComponent();
            //_WSCOM = ClientFactory.CreateChannel<IPM24120>("PM04", "PM24120.svc", "CustomBinding");
            _WSCOM = new AxClientProxy();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                //if (this.UserInfo.IsAdmin.Equals("Y"))
                //    this.cbo01_BIZCD.SetReadOnly(false);
                //else
                //    this.cbo01_BIZCD.SetReadOnly(true);

                this.cbo01_SHIFT.DataBind("EI", true);

                this.grd01.AllowEditing = true;
                this.grd01.Initialize();

                this.grd01.AddHiddenColumn("BIZCD");
                this.grd01.AddHiddenColumn("NON_OPRCD");
                this.grd01.AddHiddenColumn("NON_OPRNO");

                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 080, "LINE", "LINECD", "LINECD");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 090, "DATE", "OCCUR_DATE", "OCCUR_DATE");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 080, "SHIFT", "SHIFT", "SHIFT");
                
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 200, "NON_OPRCD", "NON_OPRNM", "NON_OPRCD");                
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 110, "BEG_HHMM", "BEG_HHMM", "BEG_TIME");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 110, "END_HHMM", "END_HHMM", "END_TIME");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 160, "PERSON", "PERSON", "PERSON");

                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 350, "REMARK", "REMARK", "REMARK");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 350, "VENDOR", "VENDOR", "VENDOR");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 70, "LOCK_STA", "LOCK_STA", "LOCK_STA");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 160, "SAP_IF_TIME", "ZDATE_PO");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 160, "Z_PERSON", "Z_PERSON", "Z_PERSON");


                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "OCCUR_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "EI", "SHIFT");
                this.grd01.Cols["BEG_HHMM"].EditMask = "99:99";
                this.grd01.Cols["END_HHMM"].EditMask = "99:99";
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PERSON");
                this.grd01.Cols["Z_PERSON"].Format = "###,###,##0.##";

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


                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_LINECD, this.lbl01_OCCUR_DATE, this.lbl01_SHIFT);

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
                paramSet.Add("OCCUR_DATE", this.dtp01_OCCUR_DATE.GetValue());
                paramSet.Add("SHIFT", this.cbo01_SHIFT.GetValue());                
                paramSet.Add("LANG_SET", this.UserInfo.Language);
                
                if (!IsQueryValid(paramSet)) return;

                this.BeforeInvokeServer(true);
                
                using (AxClientProxy proxy = new AxClientProxy())
                {
                    DataSet source = proxy.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), paramSet);
                    this.grd01.SetValue(source.Tables[0]);                    
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

        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.Save, 
                                                "CORCD", 
                                                "BIZCD",
                                                "NON_OPRNO", 
                                                "OCCUR_DATE", 
                                                "LINECD",
                                                "NON_OPRCD", 
                                                "BEG_HHMM", 
                                                "END_HHMM", 
                                                "PERSON", 
                                                "SHIFT", 
                                                "REMARK",
                                                "VENDOR",
                                                "USERID");            

                foreach (DataRow dr in set.Tables[0].Rows)
                {
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                    dr["USERID"] = this.UserInfo.UserID;
                }

                if (!IsSaveValid(set)) return;

                AxClientProxy proxy = new AxClientProxy();

                this.BeforeInvokeServer();


                proxy.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SAVE"), set);
                
                                                
                this.AfterInvokeServer();

                BtnQuery_Click(null, null);

                //MsgBox.Show("저장되었습니다.");
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


        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DataSet set = this.grd01.GetValue(AxFlexGrid.FActionType.Remove,
                                                "CORCD",
                                                "BIZCD",
                                                "NON_OPRNO",
                                                "OCCUR_DATE",
                                                "LINECD"
                                                );

                foreach (DataRow dr in set.Tables[0].Rows)
                {
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                }

                if (!IsRemoveValid(set)) return;

                AxClientProxy proxy = new AxClientProxy();

                this.BeforeInvokeServer();


                proxy.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "REMOVE"), set);


                this.AfterInvokeServer();

                BtnQuery_Click(null, null);

                //삭제되었습니다.
                MsgCodeBox.Show("CD00-0072");
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

        private bool IsSaveValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count <= 0)
            {
                MsgCodeBox.Show("CD00-0042"); //저장할 데이터가 존재하지 않습니다.
                return false;
            }

            for (int i = 0; i < source.Tables[0].Rows.Count; i++ )
            {
                DataRow dr = source.Tables[0].Rows[i];
                                
                //시작시간
                if (dr["NON_OPRCD"].ToString().Length <= 0)
                {
                    //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0091", source.Tables[1].Rows[i][0], this.grd01.Cols["NON_OPRNM"].Caption);
                    return false;
                }

                //시작시간
                if (dr["BEG_HHMM"].ToString().Length <= 0)
                {
                    //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0091", source.Tables[1].Rows[i][0], this.grd01.Cols["BEG_HHMM"].Caption);
                    return false;
                }

                if (dr["BEG_HHMM"].ToString().Length != 5 || dr["BEG_HHMM"].ToString().IndexOf(":") < 0)
                {
                    //{0} 이(가) 잘못되었습니다.
                    MsgCodeBox.ShowFormat("CD00-0099", this.grd01.Cols["BEG_HHMM"].Caption); 
                    return false;
                }

                //종료시간
                if (dr["END_HHMM"].ToString().Length <= 0)
                {
                    //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0091", source.Tables[1].Rows[i][0], this.grd01.Cols["END_HHMM"].Caption);
                    return false;
                }

                if (dr["END_HHMM"].ToString().Length != 5 || dr["END_HHMM"].ToString().IndexOf(":") < 0)
                {
                    //{0} 이(가) 잘못되었습니다.
                    MsgCodeBox.ShowFormat("CD00-0099", this.grd01.Cols["END_HHMM"].Caption);
                    return false;
                }

                //인원
                if (dr["PERSON"].ToString().Length <= 0)
                {
                    //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0091", source.Tables[1].Rows[i][0], this.grd01.Cols["PERSON"].Caption);
                    return false;
                }

                //인원 MAX 100
                if (Convert.ToDecimal(dr["PERSON"].ToString()) > 100)
                {
                    MsgBox.Show("Person qyt is limited by 100.");
                    return false;
                }

            }

            //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }


        private bool IsRemoveValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count <= 0)
            {
                MsgCodeBox.Show("CD00-0041"); //삭제할 데이터가 존재하지 않습니다.
                return false;
            }


            //if (MsgBox.Show("삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            if (MsgCodeBox.Show("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }


        private bool IsQueryValid(HEParameterSet set)
        {
            if (set["BIZCD"].ToString().Trim().Length == 0)
            {
                //MsgBox.Show("라인을 선택해주세요!");
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_BIZNM2.Text);
                return false;
            }

            if (set["LINECD"].ToString().Trim().Length == 0)
            {
                //MsgBox.Show("라인을 선택해주세요!");
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_LINECD.Text);
                return false;
            }


            if (set["OCCUR_DATE"].ToString().Trim().Length == 0)
            {
                //MsgBox.Show("라인을 선택해주세요!");
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_OCCUR_DATE.Text);
                return false;
            }

            if (set["SHIFT"].ToString().Trim().Length == 0)
            {
                //MsgBox.Show("라인을 선택해주세요!");
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_SHIFT.Text);
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
              
        private void grd01_RowInserting(object sender, AxFlexGrid.FAlterEventRow args)
        {
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", this.UserInfo.CorporationCode);
            paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());
            paramSet.Add("OCCUR_DATE", this.dtp01_OCCUR_DATE.GetValue());
            paramSet.Add("SHIFT", this.cbo01_SHIFT.GetValue());
            paramSet.Add("LANG_SET", this.UserInfo.Language);


            if (!this.IsQueryValid(paramSet))
                args.Cancel = true;

        }

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                
                for (int i = 0; i < args.RowCount; i++)
                {
                    //신규행 추가시 기본 값 설정
                    this.grd01.SetValue(args.RowIndex + i, this.grd01.Cols["BIZCD"].Index, this.cbo01_BIZCD.GetValue());
                    this.grd01.SetValue(args.RowIndex + i, this.grd01.Cols["OCCUR_DATE"].Index, this.dtp01_OCCUR_DATE.GetValue());
                    this.grd01.SetValue(args.RowIndex + i, this.grd01.Cols["SHIFT"].Index, this.cbo01_SHIFT.GetValue());
                    this.grd01.SetValue(args.RowIndex + i, this.grd01.Cols["LINECD"].Index, this.cdx01_LINECD.GetValue());
                    
                    this.grd01.Rows[args.RowIndex + i].StyleNew.BackColor = Color.Bisque;
                    this.grd01.Row = args.RowIndex + i;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int r = this.grd01.MouseRow;
            int c = this.grd01.MouseCol;

            if (r < this.grd01.Rows.Fixed || r >= this.grd01.Rows.Count) return;

            if (this.grd01.Cols[c].Name != "NON_OPRNM") return;


            PopupHelper helper = null;
            PD25220P1 popup = new PD25220P1();
            AxCodeBox cdx = new AxCodeBox();
            
            cdx.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
            cdx.HEUserParameterSetValue("BIZCD", this.grd01.GetValue(r, "BIZCD"));
            cdx.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
            popup.CodeBox = cdx;
            helper = new PopupHelper(popup, this.grd01.Cols["NON_OPRNM"].Caption);
            helper.ShowDialog();

            DataRow row = (DataRow)helper.SelectedData;
            if (row != null)
            {
                this.grd01.SetValue(r, "NON_OPRCD", row["NON_OPRCD"].ToString());
                this.grd01.SetValue(r, "NON_OPRNM", row["NON_OPRCD"].ToString() + " : " + row["NON_OPRNM"].ToString());
            }


        }
        
        
        #endregion

        private void grd01_AfterEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            try
            {
                if (e.Col == grd01.Cols["BEG_HHMM"].Index || e.Col == grd01.Cols["END_HHMM"].Index)
                {
                    string s_work_date = Convert.ToString(grd01.GetValue(e.Row, "OCCUR_DATE"));
                    string s_shift = Convert.ToString(grd01.GetValue(e.Row, "SHIFT"));
                    string s_begin_time = Convert.ToString(grd01.GetValue(e.Row, "BEG_HHMM"));
                    string s_end_time = Convert.ToString(grd01.GetValue(e.Row, "END_HHMM"));
                    string s_day_end = "23:59";

                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                    set.Add("WORK_DATE", s_work_date);
                    set.Add("SHIFT", s_shift);
                    set.Add("LINECD", grd01.GetValue(grd01.SelectedRowIndex, "LINECD"));

                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", "APG_PD25312", "INQUERY_SHIFT"), set, "OUT_CURSOR");

                    if (null != source && source.Tables[0].Rows.Count != 0)
                    {
                        if (e.Col == grd01.Cols["BEG_HHMM"].Index)
                        {
                            string s_saved_begin = Convert.ToString(source.Tables[0].Rows[0]["BEG_TIME"]);
                            if (string.Compare(s_begin_time, s_day_end, false) > 0)
                            {
                                MessageBox.Show("Begin-time cannot be higher than 23:59");
                                grd01.SetValue(e.Row, "BEG_HHMM", s_saved_begin);
                            }
                            if (s_shift == "EI2")
                            {
                                s_saved_begin = Convert.ToDateTime(s_work_date + " " + s_saved_begin).ToString("yyyy-MM-dd HH:mm:ss");
                                string s_saved_end = Convert.ToString(source.Tables[0].Rows[0]["END_TIME"]);
                                if (string.Compare(s_saved_end,s_begin_time, false) > 0)
                                {
                                    s_begin_time = Convert.ToDateTime(s_work_date + " " + s_begin_time).AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                                }
                                else
                                {
                                    s_begin_time = Convert.ToDateTime(s_work_date + " " + s_begin_time).ToString("yyyy-MM-dd HH:mm:ss");
                                }
                            }
                            if (string.Compare(s_saved_begin, s_begin_time, false) > 0)
                            {
                                MessageBox.Show("Begin-time have to be greater than or equal to " + s_saved_begin);
                                grd01.SetValue(e.Row, "BEG_HHMM", Convert.ToString(source.Tables[0].Rows[0]["BEG_TIME"]));
                            }
                        }
                        else if (e.Col == grd01.Cols["END_HHMM"].Index)
                        {
                            string s_saved_end = Convert.ToString(source.Tables[0].Rows[0]["END_TIME"]);
                            if (string.Compare(s_end_time, s_day_end, false) > 0)
                            {
                                MessageBox.Show("Begin-time cannot be higher than 23:59");
                                grd01.SetValue(e.Row, "END_HHMM", s_saved_end);
                            }
                            if (s_shift == "EI2")
                            {
                                s_saved_end = Convert.ToDateTime(s_work_date + " " + s_saved_end).AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                                string s_saved_begin = Convert.ToString(source.Tables[0].Rows[0]["BEG_TIME"]);
                                if (string.Compare(s_end_time, s_saved_begin, false) > 0)
                                {
                                    s_end_time = Convert.ToDateTime(s_work_date + " " + s_end_time).ToString("yyyy-MM-dd HH:mm:ss");
                                }
                                else
                                {
                                    s_end_time = Convert.ToDateTime(s_work_date + " " + s_end_time).AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                                }
                            }
                            if (string.Compare(s_end_time, s_saved_end, false) > 0)
                            {
                                MessageBox.Show("End-time have to be lesser than or equal to " + s_saved_end);
                                grd01.SetValue(e.Row, "END_HHMM", Convert.ToString(source.Tables[0].Rows[0]["END_TIME"]));
                            }
                        }
                    }
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
}
