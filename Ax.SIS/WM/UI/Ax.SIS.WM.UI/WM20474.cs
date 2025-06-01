#region ▶ Description & History
/* 
 * 프로그램명 : 공정 마스터 등록
 * 설      명 : 공정마스터와 라인공정을 관리한다.
 * 최초작성자 : 이명희
 * 최초작성일 : 2015-01-07
 * 최종수정자 : 김민재
 * 최종수정일 : 2015-02-10
 * 수정  내용 : 공정순서(PROC_SEQ) 추가
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-01-07      이명희      최초 클래스 생성
 *				2015-02-10      김민재      공정순서(PROC_SEQ) 추가
*/
#endregion

using System;
using System.Collections.Generic;
using System.Data;

using System.IO;
using System.IO.Ports;
using System.Linq;
using System.ServiceModel;
using TheOne.ServiceModel;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using System.Drawing;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using Ax.SIS.CM.UI;
using HE.Framework.Core;
using HE.Framework.Core.Report;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.WM.UI
{
    /// <summary>
    /// 반제품 부품식별표 발행
    /// </summary>
    public partial class WM20474 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private DateTime _tmpDELI_DATE;
        private bool _isSelectedIndexChangedDirectly = true;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;

        private const string _IntFormat = "###,###,###,###,##0";

        public WM20474()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
            //this.grd_LINECD = new AxComboList();
        }

        #region [ 초기화 작업 정의 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;

                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(true);
                this.cdx01_VENDCD.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1(this.cdx01_VENDCD);
                this.cdx01_VENDCD.PopupTitle = this.GetLabel("VENDCD");// "업체 코드";
                this.cbo01_DOM_IMP_DIV.DataBind("EK", true);

                this._tmpDELI_DATE = Convert.ToDateTime(this.dte01_SDATE.GetValue());

                HEParameterSet paramSet_OUT_DIV = new HEParameterSet();
                paramSet_OUT_DIV.Add("CORCD", _CORCD);
                paramSet_OUT_DIV.Add("BIZCD", _BIZCD);
                paramSet_OUT_DIV.Add("LANG_SET", _LANG_SET);
                DataSet combo_source_OUT_DIV = _WSCOM.ExecuteDataSet("APG_WM20474.INQUERY_OUT_DIV", paramSet_OUT_DIV);                

                #region[grd01]

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                //this.grd01.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;

                //this.grd01.AllowEditing = true;
                //this.grd01.AutoClipboard = true;
                //this.grd01.AllowDragging = AllowDraggingEnum.None;
                //this.grd01.Initialize();
                //this.grd01.AllowSorting = AllowSortingEnum.None;

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "품번", "PARTNO", "PARTNO");
                this.grd01.Cols["PARTNO"].Style.BackColor = Color.FromArgb(208, 253, 248);
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "품명", "PARTNM", "PARTNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "업체", "VENDCD", "VENDCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "업체명", "VENDNM", "VENDNM");

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "내수/수입", "DOM_IMP_DIV", "DOM_IMP_DIV");

                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "기준일자", "STD_DATE", "STD_DATE");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "LOTNO", "LOTNO", "LOTNO");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "일련번호", "SEQNO", "SEQNO");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "수량", "QTY", "QTY");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "재고상태", "INV_STATUS", "INV_STATUS");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "적재위치", "LOCATION_NO", "LOCATION_NO");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "작업일자", "WORK_DATE", "WORK_DATE");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "작업시간", "WORK_TIME", "WORK_TIME");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "작업자", "USER_ID", "USER_ID");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "출하지시서 번호", "SLIP_NO", "SLIP_NO");
                //this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "내수 구분", "DOM_IMP_DIV", "DOM_IMP_DIV");

                //this.grd01.Cols["QTY"].Format = _IntFormat;
                //this.grd01.Cols["STD_DATE"].Format = "yyyy-MM-dd";
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "STD_DATE");
                //this.grd01.Cols["WORK_DATE"].Format = "yyyy-MM-dd";
                //this.grd01.SetColumnType(AxFlexGrid.FCellType.Date, "WORK_DATE");

                //this.BtnQuery_Click(null, null);    

                #endregion

                #region [grd02]

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                //this.grd02.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;

                //this.grd02.AllowEditing = true;
                //this.grd02.AutoClipboard = true;
                //this.grd02.AllowDragging = AllowDraggingEnum.None;
                //this.grd02.Initialize();
                //this.grd02.AllowSorting = AllowSortingEnum.None;

                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd02.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "품번", "PARTNO", "PARTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "업체", "VENDCD", "VENDCD");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "업체명", "VENDNM", "VENDNM");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "내수/수입", "DOM_IMP_DIV", "DOM_IMP_DIV");

                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "기준일자", "STD_DATE", "STD_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "LOTNO", "LOTNO", "LOTNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "일련번호", "SEQNO", "SEQNO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "수량", "QTY", "QTY");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "재고상태", "INV_STATUS", "INV_STATUS");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "적재위치", "LOCATION_NO", "LOCATION_NO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "작업일자", "WORK_DATE", "WORK_DATE");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "작업시간", "WORK_TIME", "WORK_TIME");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "작업자", "USER_ID", "USER_ID");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "출하지시서 번호", "SLIP_NO", "SLIP_NO");
                this.grd02.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "내수 구분", "DOM_IMP_DIV", "DOM_IMP_DIV");

                this.grd02.Cols["QTY"].Format = _IntFormat;
                this.grd02.Cols["STD_DATE"].Format = "yyyy-MM-dd";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "STD_DATE");
                this.grd02.Cols["WORK_DATE"].Format = "yyyy-MM-dd";
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Date, "WORK_DATE");

                #endregion

                #region [grd03]

                this.grd03.AllowEditing = false;
                this.grd03.Initialize();
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
                this.grd03.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.None;

                //this.grd03.AllowEditing = true;
                //this.grd03.AutoClipboard = true;
                //this.grd03.AllowDragging = AllowDraggingEnum.None;
                //this.grd03.Initialize();
                //this.grd03.AllowSorting = AllowSortingEnum.None;

                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "법인", "CORCD", "CORCD");
                this.grd03.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 70, "사업장", "BIZCD", "BIZCD");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "업체", "VENDCD", "VENDCD");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 120, "업체명", "VENDNM", "VENDNM");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 130, "품번", "PARTNO", "PARTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 220, "품명", "PARTNM", "PARTNM");

                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "기준일자", "STD_DATE", "STD_DATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 150, "LOTNO", "LOTNO", "LOTNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "일련번호", "SEQNO", "SEQNO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.R, 80, "수량", "QTY", "QTY");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "재고상태", "INV_STATUS", "INV_STATUS");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "적재위치", "LOCATION_NO", "LOCATION_NO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "작업일자", "WORK_DATE", "WORK_DATE");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 80, "작업시간", "WORK_TIME", "WORK_TIME");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 100, "작업자", "USER_ID", "USER_ID");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "출하지시서 번호", "SLIP_NO", "SLIP_NO");
                this.grd03.AddColumn(true, true, AxFlexGrid.FtextAlign.C, 100, "내수 구분", "DOM_IMP_DIV", "DOM_IMP_DIV");

                this.grd03.Cols["QTY"].Format = _IntFormat;
                this.grd03.Cols["STD_DATE"].Format = "yyyy-MM-dd";
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Date, "STD_DATE");
                this.grd03.Cols["WORK_DATE"].Format = "yyyy-MM-dd";
                this.grd03.SetColumnType(AxFlexGrid.FCellType.Date, "WORK_DATE");

                for (int i = 0; i < this.grd03.Cols.Count; i++)
                    this.grd03.Cols[i].AllowMerging = true;

                //this.BtnQuery_Click(null, null);  

                #endregion

                //this.grd01.CurrentContextMenu.Items[0].Visible = false;
                //this.grd01.CurrentContextMenu.Items[1].Visible = false;
                //this.grd01.CurrentContextMenu.Items[2].Visible = false;
                //this.grd01.CurrentContextMenu.Items[3].Visible = false;
              
                this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
                this.dte01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));

                this.SetRequired(this.lbl01_BIZNM);

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
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0: this.Inquery_Partno(); break;
                    case 1: this.Inquery_All(); break;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }


        private void Inquery_Partno()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                paramSet.Add("DOM_IMP_DIV", this.cbo01_DOM_IMP_DIV.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.GetValue());
                paramSet.Add("EDATE", this.dte01_EDATE.GetValue());
                paramSet.Add("PARTNO", this.txt01_PARTNO1.GetValue());
                paramSet.Add("LOTNO", this.txt01_LOTNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);
               
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20474.INQUERY_PARTNO", paramSet);
                this.AfterInvokeServer();

                this.grd01.SetValue(source.Tables[0]);
                this.ShowDataCount(source);
                
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

        private void Inquery_All()
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                paramSet.Add("DOM_IMP_DIV", this.cbo01_DOM_IMP_DIV.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.GetValue());
                paramSet.Add("EDATE", this.dte01_EDATE.GetValue());
                paramSet.Add("PARTNO", this.txt01_PARTNO1.GetValue());
                paramSet.Add("LOTNO", this.txt01_LOTNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20474.INQUERY_ALL", paramSet);

                this.grd03.MergedRanges.Clear();
                this.grd03.SetValue(source);
                this.grd03.Subtotal(AggregateEnum.Sum, 0, this.grd03.Cols["PARTNO"].Index, this.grd03.Cols["QTY"].Index);
                
                CellStyle cs;
                cs = this.grd03.Styles[CellStyleEnum.Subtotal0];
                cs.BackColor = Color.FromArgb(208, 253, 248);
                cs.ForeColor = Color.Black;
                cs.Font = new Font(Font, FontStyle.Bold);

                ShowDataCount(source);

                this.AfterInvokeServer();

            //this.grd03.MergedRanges.Clear();
            //this.AfterInvokeServer();

            //this.grd03.SetValue(source.Tables[0]);
            //this.grd03.MergedRanges.Clear();
            //this.ShowDataCount(source);
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        this.grd01.InitializeDataSource();
                        this.grd02.InitializeDataSource();

                        this.txt01_PARTNO1.Initialize();
                        this.cdx01_VENDCD.Initialize();                        
                        this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
                        this.dte01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd"));                        
                        break;
                    case 1:
                        this.grd03.InitializeDataSource();

                        this.txt01_PARTNO1.Initialize();
                        this.cdx01_VENDCD.Initialize();      
                        this.dte01_SDATE.SetValue(DateTime.Now.ToString("yyyy-MM-01"));
                        this.dte01_EDATE.SetValue(DateTime.Now.ToString("yyyy-MM-dd")); 

                        break;
                    default:
                        break;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 유효성 검사 ]

        private bool IsProcMasterSaveValid(DataSet source)
        {
            try
            {
                //DataRow row = source.Tables[0].Rows[0];

                //string strProcCD = row["PROCCD"].ToString();    //공정코드
                //string strProcNM = row["PROCNM"].ToString();    //공정명

                //if (this.GetByteCount(strProcCD) == 0)
                //{
                //    MsgCodeBox.ShowFormat("CD00-0080", lbl03_PROCCD.GetValue());
                //    return false;
                //}

                //if (this.GetByteCount(strProcCD) > 6)
                //{
                //    MsgCodeBox.ShowFormat("CD00-0081", lbl03_PROCCD.GetValue(), "6");
                //    return false;
                //}

                //if (this.GetByteCount(strProcNM) == 0)
                //{
                //    //MsgCodeBox.ShowFormat("CD00-0080", lbl02_PROCNM.GetValue());
                //    return false;
                //}

                //if (this.GetByteCount(strProcNM) > 200)
                //{
                //    MsgCodeBox.ShowFormat("CD00-0081", lbl02_PROCNM.GetValue(), "200");
                //    return false;
                //}

                //if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel, ImageKinds.Question) != DialogResult.OK)
                //    return false;

                //return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsProcMasterDeleteValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count == 0)
            {
                //MsgBox.Show("삭제할 데이터가 없습니다.");
                MsgCodeBox.Show("CD00-0041");
                return false;
            }

            HEParameterSet paramSet = null;
            foreach (DataRow row in source.Tables[0].Rows)
            {
                paramSet = new HEParameterSet();
                foreach (DataColumn col in source.Tables[0].Columns)
                {
                    paramSet.Add(col.ColumnName, row[col]);
                }

                DataSet ds = _WSCOM.ExecuteDataSet("APG_WM20474.CHECK_REMOVE_PROC", paramSet);
                if (ds.Tables[0].Rows.Count > 0)
                    return false;
            }

            //if (MsgBox.Show("선택하신 용기정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK) return false;
            if (MsgCodeBox.Show("CD00-0018", MessageBoxButtons.OKCancel, ImageKinds.Question) != DialogResult.OK)
                return false;
            return true;
        }

        private bool IsSaveValid(DataRow set)
        {
            if (set["STOCK_QTY"].ToString().Length == 0)
            {
                //공정순서 값은 0보다 커야합니다.
                //MsgCodeBox.ShowFormat("BM00-014", this.lbl02_PROC_SEQ.Text);
                return false;
            }

            //if (set["LINECD"].ToString().Length == 0)
            //{
            //    //MsgBox.Show("공정을 선택해주세요!");
            //    //MsgCodeBox.ShowFormat("CD00-0080", lbl01_LINECD.GetValue());
            //    return false;
            //}

            //if (set["PROCCD"].ToString().Length == 0)
            //{
            //    //MsgBox.Show("공정을 선택해주세요!");
            //    //MsgCodeBox.ShowFormat("CD00-0080", lbl01_PROCCD.GetValue());
            //    return false;
            //}

            //if (set["REMARK"].ToString().Length > 500)
            //{
            //    //MsgBox.Show("용기를 선택해주세요!");
            //    //MsgCodeBox.ShowFormat("CD00-0081", lbl01_REMARK.GetValue(), "500");
            //    return false;
            //}

            ////if(MsgBox.Show("입력하신 공정 용기정보를 저장하시겠습니까?","주의",MessageBoxButtons.OKCancel) != DialogResult.OK)
            //if (MsgCodeBox.Show("CD00-0017", MessageBoxButtons.OKCancel, ImageKinds.Question) != DialogResult.OK)
            //    return false;
            return true;
        }

        private bool IsRemoveValid(HEParameterSet set)
        {
            if (set["LINECD"].ToString().Length == 0)
            {
                //MsgBox.Show("공정을 선택해주세요!");
                //MsgCodeBox.ShowFormat("CD00-0080", lbl01_LINECD.GetValue());
                return false;
            }

            if (set["PROCCD"].ToString().Length == 0)
            {
                //MsgBox.Show("공정을 선택해주세요!");
                //MsgCodeBox.ShowFormat("CD00-0080", lbl01_PROCCD.GetValue());
                return false;
            }

            //if (MsgBox.Show("선택하신 공정 용기정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //if (MsgCodeBox.Show("CD00-0018", MessageBoxButtons.OKCancel, ImageKinds.Question) != DialogResult.OK)
            //    return false;

            return true;
        }

        #endregion

        #region [ 기타 이벤트 정의 ]


        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                if (row < 0)
                {
                    return;
                }

                string PARTNO = this.grd01.GetValue(row, "PARTNO").ToString();
                this.Inquery_Detail(PARTNO);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        //this.lbl01_LOTNO.Visible = false;
                        //this.txt01_LOTNO.Visible = false;
                        this.chk01_MERGE.Visible = false;   
                        break;
                    case 1:
                        //this.lbl01_LOTNO.Visible = true;
                        //this.txt01_LOTNO.Visible = true; 
                        this.chk01_MERGE.Visible = true;   
                        break;
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        private void Inquery_Detail(string PARTNO) //aa
        {
            try
            {
                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", this.UserInfo.CorporationCode);
                paramSet.Add("BIZCD", this.cbo01_BIZCD.GetValue());
                paramSet.Add("VENDCD", this.cdx01_VENDCD.GetValue());
                paramSet.Add("SDATE", this.dte01_SDATE.GetValue());
                paramSet.Add("EDATE", this.dte01_EDATE.GetValue());
                paramSet.Add("PARTNO", PARTNO);
                paramSet.Add("LOTNO", this.txt01_LOTNO.GetValue());
                paramSet.Add("LANG_SET", this.UserInfo.Language);

                //this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.ExecuteDataSet("APG_WM20474.INQUERY_PARTNO_DETAIL", paramSet);
                //this.AfterInvokeServer();
                //this.grd02.SetValue(source.Tables[0]);
                //this.ShowDataCount(source);

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("APG_WM20474.INQUERY_PARTNO_DETAIL", paramSet);
                this.AfterInvokeServer();
                this.grd02.SetValue(source.Tables[0]);
                //this.grd02.Subtotal(AggregateEnum.Sum, 0, this.grd02.Cols["PARTNO"].Index, this.grd02.Cols["QTY"].Index);

                //CellStyle cs;
                //cs = this.grd02.Styles[CellStyleEnum.Subtotal0];
                //cs.BackColor = Color.FromArgb(208, 253, 248);
                //cs.ForeColor = Color.Black;
                //cs.Font = new Font(Font, FontStyle.Bold);

                ShowDataCount(source);

                this.AfterInvokeServer();

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

        private void chk01_GRID_MERGE_CheckedChanged(object sender, EventArgs e)
        {
            this.grd03.AllowMerging = (this.chk01_MERGE.Checked == true) ?
                C1.Win.C1FlexGrid.AllowMergingEnum.RestrictAll :
                C1.Win.C1FlexGrid.AllowMergingEnum.None;
        }
    }
}
