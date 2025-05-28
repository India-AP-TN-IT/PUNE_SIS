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
    public partial class PD25312 : AxCommonBaseControl
    {
        //private IPM24120 _WSCOM;
        private string PACKAGE_NAME = "APG_PD25312";
        private AxClientProxy _WSCOM;

        public PD25312()
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
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 090, "DATE", "WORK_DATE", "WORK_DATE");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 080, "LINE", "WORK_LINECD", "LINECD");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.L, 160, "LINE NAME", "LINENM", "LINENM");  
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 080, "SHIFT", "SHIFT", "SHIFT");
                this.grd01.AddColumn(true, false, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 080, "RSLT_QTY", "RSLT_QTY", "RSLT_QTY");
                this.grd01.AddColumn(true, false, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 080, "SEQ", "WORK_SEQ");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 110, "BEG_HHMM", "BEG_HHMM", "BEG_TIME");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 110, "END_HHMM", "END_HHMM", "END_TIME");
                this.grd01.AddColumn(false, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 160, "PERSON", "PERSON", "PERSON");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 70, "LOCK_STA", "LOCK_STA", "LOCK_STA");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.C, 160, "SAP_IF_TIME", "ZDATE_PO");
                this.grd01.AddColumn(true, true, DEV.Utility.Controls.AxFlexGrid.FtextAlign.R, 160, "Z_PERSON", "Z_PERSON", "Z_PERSON");
                this.grd01.AddHiddenColumn("COLOR");

                this.grd01.AllowMerging = AllowMergingEnum.RestrictAll;
                this.grd01.Cols["BIZCD"].AllowMerging = true;
                this.grd01.Cols["WORK_DATE"].AllowMerging = true;                
                this.grd01.Cols["WORK_LINECD"].AllowMerging = true;
                this.grd01.Cols["LINENM"].AllowMerging = true;
                this.grd01.Cols["SHIFT"].AllowMerging = true;
                this.grd01.Cols["RSLT_QTY"].AllowMerging = true;
                

                this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "RSLT_QTY");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "WORK_DATE");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.ComboBox, "EI", "SHIFT");
                this.grd01.Cols["BEG_HHMM"].EditMask = "99:99";
                this.grd01.Cols["END_HHMM"].EditMask = "99:99";
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Int, "PERSON");

                //this.grd01.Cols["BEG_HHMM"].StyleDisplay.BackColor = Color.LightYellow;
                //this.grd01.Cols["END_HHMM"].StyleDisplay.BackColor = Color.LightYellow;
                //this.grd01.Cols["PERSON"].StyleDisplay.BackColor = Color.LightYellow;
                CellStyle cs = this.grd01.Styles.Add("csEditable");
                cs.BackColor = Color.LightYellow;

                CellStyle csCheck = this.grd01.Styles.Add("csCheckPerson");
                csCheck.BackColor = Color.Red;
                
                this.grd01.Cols["PERSON"].Format = "###,###,##0.###";
                this.grd01.Cols["RSLT_QTY"].Format = "#,###,###,###,###,###,##0";
                this.grd01.Cols["Z_PERSON"].Format = "###,###,##0.##";

                this.grd01.CurrentContextMenu.Items[0].Visible = false; //기존의 행추가는 사용안함.
                
                //행추가 Context Menu 추가 
                //   - 클릭한 행의 아래에 신규 행을 추가해주기 위해(SEQ가 더 큰 숫자로 채번이 될 것이기 때문에 아래쪽에 빈행이 생기는 것이 흐름상 어색하지 않음)
                string title = this.GetLabel("ROW_ADD");
                ToolStripMenuItem insertItem = new ToolStripMenuItem(title == "" ? "Add Row" : title); 
                insertItem.Click += new EventHandler(insertItem_Click);
                this.grd01.CurrentContextMenu.Items.Insert(0, insertItem);


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

                this.SetRequired(this.lbl01_BIZNM2, this.lbl01_WORK_DATE);

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
                paramSet.Add("WORK_DATE_FROM", this.dtp01_WORKDATE_BEG.GetValue());
                paramSet.Add("WORK_DATE_TO", this.dtp01_WORKDATE_END.GetValue());
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


                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    this.grd01.Rows[i].StyleNew.Clear();
                    if (this.grd01.GetValue(i, "LOCK_STA").ToString().Equals("N"))
                    {
                        this.grd01.SetCellStyle(i, this.grd01.Cols["BEG_HHMM"].Index, "csEditable");
                        this.grd01.SetCellStyle(i, this.grd01.Cols["END_HHMM"].Index, "csEditable");
                        this.grd01.SetCellStyle(i, this.grd01.Cols["PERSON"].Index, "csEditable");
                    }
                    //LOCK이 N이라도 다시 풀었을 경우가 생기므로 색상을 입힌다.
                    if (this.grd01.GetValue(i, "COLOR").ToString().Equals("R"))
                    {
                        this.grd01.SetCellStyle(i, this.grd01.Cols["PERSON"].Index, "csCheckPerson");
                        this.grd01.SetCellStyle(i, this.grd01.Cols["Z_PERSON"].Index, "csCheckPerson");
                    }
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
                                                "WORK_DATE", 
                                                "WORK_LINECD",
                                                "WORK_SEQ", 
                                                "BEG_HHMM", 
                                                "END_HHMM", 
                                                "PERSON", 
                                                "SHIFT",
                                                "LOCK_STA");            

                foreach (DataRow dr in set.Tables[0].Rows)
                {
                    dr["CORCD"] = this.UserInfo.CorporationCode;                  
                }

                if (!IsSaveValid(set)) return;

                set.Tables[0].Columns.Remove("LOCK_STA"); //마감 여부 확인 후, 불필요한 컬럼 삭제.

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
                                                "WORK_DATE",
                                                "WORK_LINECD",
                                                "WORK_SEQ",
                                                "LOCK_STA");

                foreach (DataRow dr in set.Tables[0].Rows)
                {
                    dr["CORCD"] = this.UserInfo.CorporationCode;
                }

                if (!IsRemoveValid(set)) return;

                set.Tables[0].Columns.Remove("LOCK_STA"); //마감 여부 확인 후, 불필요한 컬럼 삭제.

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
                if (dr["BEG_HHMM"].ToString().Length <= 0)
                {
                    //{0}번째 행에 {1} 정보가 입력되지 않았습니다.
                    MsgCodeBox.ShowFormat("CD00-0091", source.Tables[1].Rows[i][0], this.grd01.Cols["BEG_HHMM"].Caption);
                    return false;
                }

                if (dr["BEG_HHMM"].ToString().Trim().Length != 5 || dr["BEG_HHMM"].ToString().IndexOf(":") < 0)
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

                if (dr["END_HHMM"].ToString().Trim().Length != 5 || dr["END_HHMM"].ToString().IndexOf(":") < 0)
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

                //인원
                if (Convert.ToDecimal(dr["PERSON"].ToString()) < 0)
                {
                    MsgCodeBox.ShowFormat("CD00-0090", this.GetLabel("PERSON"));
                    return false;
                }

                //인원 MAX 100
                if (Convert.ToDecimal(dr["PERSON"].ToString()) > 100)
                {                    
                    MsgBox.Show("Person qyt is limited by 100.");
                    return false;
                }

                //마감여부 체크 추가함.
                if (dr["LOCK_STA"].ToString().Length > 0 && dr["LOCK_STA"].ToString().Equals("Y"))
                {
                    //마감완료된 건입니다. 변경이 불가합니다.
                    MsgCodeBox.Show("MSG-00001");
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

            for (int i = 0; i < source.Tables[0].Rows.Count; i++)
            {
                DataRow dr = source.Tables[0].Rows[i];

               
                //마감여부 체크 추가함.
                if (dr["LOCK_STA"].ToString().Length > 0 && dr["LOCK_STA"].ToString().Equals("Y"))
                {
                    //마감완료된 건입니다. 변경이 불가합니다.
                    MsgCodeBox.Show("MSG-00001");
                    return false;
                }

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

            //if (set["LINECD"].ToString().Trim().Length == 0)
            //{
            //    //MsgBox.Show("라인을 선택해주세요!");
            //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_LINECD.Text);
            //    return false;
            //}


            if (set["WORK_DATE_FROM"].ToString().Trim().Length == 0)
            {                
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_WORK_DATE.Text);
                return false;
            }

            if (set["WORK_DATE_TO"].ToString().Trim().Length == 0)
            {
                MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_WORK_DATE.Text);
                return false;
            }

            //if (set["SHIFT"].ToString().Trim().Length == 0)
            //{
            //    //MsgBox.Show("라인을 선택해주세요!");
            //    MsgCodeBox.ShowFormat("CD00-0079", this.lbl01_SHIFT.Text);
            //    return false;
            //}

            return true;
        }

        #endregion

        #region [ 기타 이벤트 정의 ]
 
        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            this.cdx01_LINECD.SetValue("");
            this.cdx01_LINECD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue());
        }

        //--마감여부 확인하여, 마감된 일자의 데이터는 삭제 불가.
        private void grd01_RowDeleting(object sender, AxFlexGrid.FAlterEventRow args)
        {
            for (int i = this.grd01.Selection.r1; i <= this.grd01.Selection.r2; i++)
            {
                if (this.grd01.GetValue(i, "LOCK_STA").ToString().Equals("Y"))
                {
                    MsgCodeBox.Show("MSG-00001");//마감완료된 건입니다. 변경이 불가합니다.
                    args.Cancel = true;
                    return;
                }
            }
        }

        //context menu 실적 추가 클릭시, 선택한 행의 계획 데이터를 그대로 복사하여 아래쪽에 1행 추가함.
        private void insertItem_Click(object sender, EventArgs e)
        {

            int index = this.grd01.Selection.r1;
            int newRowIdx = index + this.grd01.Rows.Fixed;
            if (this.grd01.DataSource == null)
                this.grd01.InitializeDataSource();


            DataTable source = (DataTable)this.grd01.DataSource;
            string lockYN = "N";
            //마감여부 확인.
            if (source.Rows.Count > 0)
                lockYN = this.grd01.GetValue(newRowIdx - 1, "LOCK_STA").ToString();
            else
            {
                return;
            }

            if (lockYN == "Y")
            {
                MsgCodeBox.Show("MSG-00001");//마감완료된 건은 변경할수 없음.
                return;
            }

            //마감아닌 경우에만 행추가함. 
            source.Rows.InsertAt(source.NewRow(), index);

            this.grd01[newRowIdx, 0] = AxFlexGrid.FLAG_N; //신규행이라고 표시

            //복사원본 데이터 복사 처리.
            this.grd01[newRowIdx, this.grd01.Cols["BIZCD"].Index] = this.grd01[newRowIdx - 1, this.grd01.Cols["BIZCD"].Index];
            this.grd01[newRowIdx, this.grd01.Cols["WORK_DATE"].Index] = this.grd01[newRowIdx - 1, this.grd01.Cols["WORK_DATE"].Index];
            this.grd01[newRowIdx, this.grd01.Cols["WORK_LINECD"].Index] = this.grd01[newRowIdx - 1, this.grd01.Cols["WORK_LINECD"].Index];
            this.grd01[newRowIdx, this.grd01.Cols["LINENM"].Index] = this.grd01[newRowIdx - 1, this.grd01.Cols["LINENM"].Index];
            this.grd01[newRowIdx, this.grd01.Cols["SHIFT"].Index] = this.grd01[newRowIdx - 1, this.grd01.Cols["SHIFT"].Index];
            this.grd01[newRowIdx, this.grd01.Cols["RSLT_QTY"].Index] = this.grd01[newRowIdx - 1, this.grd01.Cols["RSLT_QTY"].Index];
            this.grd01[newRowIdx, this.grd01.Cols["LOCK_STA"].Index] = this.grd01[newRowIdx - 1, this.grd01.Cols["LOCK_STA"].Index];

            //시작시간, 종료시간, 인원 배경색 변경 - 노랗게
            this.grd01.SetCellStyle(newRowIdx, this.grd01.Cols["PERSON"].Index, "csEditable");
            this.grd01.SetCellStyle(newRowIdx, this.grd01.Cols["BEG_HHMM"].Index, "csEditable");
            this.grd01.SetCellStyle(newRowIdx, this.grd01.Cols["END_HHMM"].Index, "csEditable");

            //방금 추가된 행 선택.
            this.grd01.Row = newRowIdx;
        }

        #region -기존 행추가 이벤트는 사용안함. -

        /*
        private void grd01_RowInserting(object sender, AxFlexGrid.FAlterEventRow args)
        {
            HEParameterSet paramSet = new HEParameterSet();
            paramSet.Add("CORCD", this.UserInfo.CorporationCode);
            paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
            paramSet.Add("LINECD", this.cdx01_LINECD.GetValue());
            paramSet.Add("WORK_DATE_FROM", this.dtp01_WORKDATE_BEG.GetValue());
            paramSet.Add("WORK_DATE_TO", this.dtp01_WORKDATE_END.GetValue());
            paramSet.Add("SHIFT", this.cbo01_SHIFT.GetValue());
            paramSet.Add("LANG_SET", this.UserInfo.Language);


            if (!this.IsQueryValid(paramSet))
                args.Cancel = true;
        }

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                string work_date = this.grd01.GetValue(args.RowIndex-1, "WORK_DATE").ToString();
                string shift = this.grd01.GetValue(args.RowIndex-1, "SHIFT").ToString();
                string work_linecd = this.grd01.GetValue(args.RowIndex-1, "WORK_LINECD").ToString();
                
                for (int i = 0; i < args.RowCount; i++)
                {
                    //신규행 추가시 기본 값 설정
                    this.grd01.SetValue(args.RowIndex + i, this.grd01.Cols["BIZCD"].Index, this.cbo01_BIZCD.GetValue());
                    this.grd01.SetValue(args.RowIndex + i, this.grd01.Cols["WORK_DATE"].Index, work_date);
                    this.grd01.SetValue(args.RowIndex + i, this.grd01.Cols["SHIFT"].Index, shift);
                    this.grd01.SetValue(args.RowIndex + i, this.grd01.Cols["WORK_LINECD"].Index, work_linecd);
                    
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
        */
        #endregion


        //--마감여부 확인하여, 마감된 일자의 데이터는 수정 불가.
        private void grd01_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            int col = e.Col;
            int row = e.Row;
            string status = this.grd01.GetValue(row, "LOCK_STA").ToString();
            if (status == "Y")//마감되었으면 변경 불가.
                e.Cancel = true;
        }
        
        #endregion

        private void grd01_AfterEdit(object sender, RowColEventArgs e)
        {
            try
            {
                if (e.Col == grd01.Cols["BEG_HHMM"].Index || e.Col == grd01.Cols["END_HHMM"].Index)
                {
                    string s_work_date = Convert.ToString(grd01.GetValue(e.Row, "WORK_DATE"));
                    string s_work_center = Convert.ToString(grd01.GetValue(e.Row, "WORK_LINECD"));
                    string s_shift = Convert.ToString(grd01.GetValue(e.Row, "SHIFT"));
                    string s_begin_time = Convert.ToString(grd01.GetValue(e.Row, "BEG_HHMM"));
                    string s_end_time = Convert.ToString(grd01.GetValue(e.Row, "END_HHMM"));

                    HEParameterSet set = new HEParameterSet();
                    set.Add("CORCD", this.UserInfo.CorporationCode);
                    set.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                    set.Add("WORK_DATE", s_work_date);
                    set.Add("SHIFT", s_shift);
                    set.Add("LINECD", grd01.GetValue(grd01.SelectedRowIndex, "WORK_LINECD"));

                    DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY_SHIFT"), set, "OUT_CURSOR");

                    if (null != source && source.Tables[0].Rows.Count != 0)
                    {
                        string s_saved_begin = Convert.ToString(source.Tables[0].Rows[0]["BEG_TIME"]);
                        string s_saved_end = Convert.ToString(source.Tables[0].Rows[0]["END_TIME"]);

                        string s_prev_end = string.Empty;
                        string s_next_begin = string.Empty;

                        if (e.Row == grd01.Rows.Fixed)
                        {
                            s_prev_end = s_saved_begin;
                            s_next_begin = s_saved_end;
                        }
                        else if (e.Row == (grd01.Rows.Count - 1))
                        {
                            s_next_begin = s_saved_end;
                        }
                        else
                        {
                            string s_prev_linecd = Convert.ToString(grd01.GetValue(e.Row - 1, "WORK_LINECD"));
                            string s_prev_shift = Convert.ToString(grd01.GetValue(e.Row - 1, "SHIFT"));
                            if (string.Compare(s_work_center, s_prev_linecd, false) == 0
                                && string.Compare(s_shift, s_prev_shift, false) == 0
                                )
                            {
                                s_prev_end = Convert.ToString(grd01.GetValue(e.Row - 1, "END_HHMM"));
                                if (string.IsNullOrEmpty(s_prev_end)) s_prev_end = s_saved_begin;
                            }
                            else
                            {
                                s_prev_end = s_saved_end;
                            }

                            string s_next_linecd = Convert.ToString(grd01.GetValue(e.Row + 1, "WORK_LINECD"));
                            string s_next_shift = Convert.ToString(grd01.GetValue(e.Row + 1, "SHIFT"));

                            if (string.Compare(s_work_center, s_next_linecd, false) == 0
                                && string.Compare(s_shift, s_next_shift, false) == 0
                                )
                            {
                                s_next_begin = Convert.ToString(grd01.GetValue(e.Row + 1, "BEG_HHMM"));
                                if (string.IsNullOrEmpty(s_next_begin)) s_next_begin = s_saved_end;
                            }
                            else
                            {
                                s_next_begin = s_saved_end;
                            }
                        }

                        if (e.Col == grd01.Cols["BEG_HHMM"].Index)
                        {
                            if (string.Compare(s_begin_time, s_prev_end, false) >= 0
                                && string.Compare(s_begin_time, s_saved_begin, false) >= 0
                                )
                            {
                            }
                            else
                            {
                                MessageBox.Show("Begin-time have to be greater or equal than " + s_prev_end);
                                grd01.SetValue(e.Row, "BEG_HHMM", s_prev_end);
                            }
                        }
                        else if (e.Col == grd01.Cols["END_HHMM"].Index)
                        {
                            if (string.Compare(s_next_begin, s_end_time, false) >= 0
                                && string.Compare(s_saved_end, s_end_time, false) >= 0
                                )
                            {
                            }
                            else
                            {
                                MessageBox.Show("End-time have to be less or equal than " + s_saved_end);
                                grd01.SetValue(e.Row, "END_HHMM", s_saved_end);
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
