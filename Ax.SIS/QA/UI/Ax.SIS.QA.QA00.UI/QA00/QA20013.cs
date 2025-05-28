#region ▶ Description & History
/* 
 * 프로그램명 : QA20013 부품별검사코드 설정 등록
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2015-07-23      배명희      통합WCF로 변경 
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

using Ax.SIS.QA.QA09.UI;
using HE.Framework.Core;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Library;
using C1.Win.C1FlexGrid;
using Ax.DEV.Utility.Controls;
using System.Drawing;
using HE.Framework.ServiceModel;

namespace Ax.SIS.QA.QA00.UI
{
    /// <summary>
    /// <b>부품별검사코드 설정 등록</b>
    /// - 작 성 자 : 이대형<br />
    /// - 작 성 일 : 2010-05-10 오후 5:32:34<br />
    /// - 주요 변경 사항
    ///     1) 2010-05-10 오후 5:32:34   이대형 : 최초 클래스 생성<br />
    /// </summary>
    public partial class QA20013 : AxCommonBaseControl
    {
        //private IQA20013 _WSCOM;
        private String _CORCD;
        private String _LANG_SET;

        private AxClientProxy _WSCOM_N;
        private string PAKAGE_NAME = "APG_QA20013";

        #region [ 초기화 작업 정의 ]

        public QA20013()
        {
            InitializeComponent();

            //_WSCOM = ClientFactory.CreateChannel<IQA20013>("QA00", "QA20013.svc", "CustomBinding");
            _WSCOM_N = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.groupBox_main.Text = this.GetLabel("QA20013_MSG1");
                this.groupBox3.Text = this.GetLabel("QA20013_MSG2");

                _CORCD = this.UserInfo.CorporationCode;
                _LANG_SET = this.UserInfo.Language;

                //this._buttonsControl.BtnClose.Visible = true;
                this._buttonsControl.BtnDelete.Visible = false;
                this._buttonsControl.BtnPrint.Visible = false;
                //this._buttonsControl.BtnDownload.Visible = true;
                this._buttonsControl.BtnProcess.Visible = false;
                //this._buttonsControl.BtnQuery.Visible = true;
                //this._buttonsControl.BtnReset.Visible = true;
                //this._buttonsControl.BtnSave.Visible = true;
                this._buttonsControl.BtnUpload.Visible = false;

                this.cbo01_BIZCD.DataBind(this.GetBizCD(this.UserInfo.CorporationCode).Tables[0], false);
                this.cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);

                if (this.UserInfo.IsAdmin == "Y")
                {
                    this.cbo01_BIZCD.Enabled = true;
                }
                else
                {
                    this.cbo01_BIZCD.Enabled = false;
                }

                this.cdx01_VINCD.HEPopupHelper = new QASubWindow();
                this.cdx01_VINCD.PopupTitle = this.GetLabel("VINCD");
                this.cdx01_VINCD.CodeParameterName = "VINCD";
                this.cdx01_VINCD.NameParameterName = "VINCDNM";
                this.cdx01_VINCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_VINCD.SetCodePixedLength();

                this.cdx01_ITEMCD.HEPopupHelper = new QASubWindow();
                this.cdx01_ITEMCD.PopupTitle = this.GetLabel("ITEMCD");
                this.cdx01_ITEMCD.CodeParameterName = "ITEMCD_OF_VINCD";
                this.cdx01_ITEMCD.NameParameterName = "ITEMCD_OF_VINNM";
                this.cdx01_ITEMCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_ITEMCD.HEParameterAdd("VINCD", this.cdx01_VINCD.GetValue().ToString());
                this.cdx01_ITEMCD.HEParameterAdd("LANG_SET", _LANG_SET);

                this.cdx01_INSTALL_POS.HEPopupHelper = new QASubWindow();
                this.cdx01_INSTALL_POS.PopupTitle = this.GetLabel("POSCODE"); //장착위치코드
                this.cdx01_INSTALL_POS.CodeParameterName = "XD_CODE";
                this.cdx01_INSTALL_POS.NameParameterName = "XD_NAME";
                this.cdx01_INSTALL_POS.HEParameterAdd("XD_CLASS", "A7");
                this.cdx01_INSTALL_POS.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_INSTALL_POS.HEParameterAdd("USE_YN", "");
                this.cdx01_INSTALL_POS.HEParameterAdd("GROUPCD", "");

                this.cdx01_INSPECT_CLASSCD.HEPopupHelper = new QASubWindow();
                this.cdx01_INSPECT_CLASSCD.PopupTitle = this.GetLabel("QA_INSPECT_BASECODE"); //"검사코드";
                this.cdx01_INSPECT_CLASSCD.CodeParameterName = "INSPECT_CLASSCD";
                this.cdx01_INSPECT_CLASSCD.NameParameterName = "INSPECT_CLASSNM";
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("CORCD", _CORCD);
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("VINCD", "");
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("ITEMCD", "");
                this.cdx01_INSPECT_CLASSCD.HEParameterAdd("LANG_SET", _LANG_SET);
                this.cdx01_INSPECT_CLASSCD.SetCodePixedLength();
                this.cdx01_INSPECT_CLASSCD.ButtonClickBefore += new AxCodeBox.CButtonClickEventHandler(cdx01_INSPECT_CLASSCD_ButtonClickBefore);

                this.grd01_QA20013.AllowEditing = false;
                this.grd01_QA20013.AllowDragging = AllowDraggingEnum.None;
                this.grd01_QA20013.Initialize();
                this.grd01_QA20013.AllowSorting = AllowSortingEnum.None;

                this.grd01_QA20013.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "법인코드", "CORCD", "CORCD");
                this.grd01_QA20013.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "사업장코드", "BIZCD", "BIZCD");
                this.grd01_QA20013.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 80, "차종", "VINCD", "VIN");
                this.grd01_QA20013.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 80, "차종", "VINTYPE", "VIN");
                this.grd01_QA20013.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 40, "품목코드", "ITEMCD", "ITEMCD");
                this.grd01_QA20013.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 40, "품목코드", "ITEMTYPE", "ITEMCD");
                this.grd01_QA20013.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "품목명", "ITEMNM", "ITEMNM3");
                this.grd01_QA20013.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 50, "장착위치코드", "INSTALL_POS", "POSCODE");
                this.grd01_QA20013.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 140, "장착위치코드", "INSTALL_POSTYPE", "POSCODE");
                this.grd01_QA20013.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 150, "장착위치명", "INSTALL_POSNM", "POSNM");
                this.grd01_QA20013.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 120, "검사코드", "INSPECT_CLASSCD", "QA_INSPECT_BASECODE");
                this.grd01_QA20013.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "자재품번", "PARTNO", "MAT_PARTNO");
                this.grd01_QA20013.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "자재품명", "PARTNM", "MAT_PARTNM");
                this.grd01_QA20013.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 150, "유검사", "CHK", "INSPECT_YN2");
                this.grd01_QA20013.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 90, "업체코드", "VENDCD", "VENDCD");
                this.grd01_QA20013.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "대표업체명", "VENDNM", "MAIN_VENDNN");
                this.grd01_QA20013.Styles.Add("COLOR_B").BackColor = Color.FromArgb(200, 200, 255);
                this.grd01_QA20013.Styles.Add("COLOR_R").BackColor = Color.FromArgb(255, 200, 200);
                this.grd01_QA20013.SelectionMode = SelectionModeEnum.ListBox;

                this.rdo01_QA20013.Checked = false;
                this.rdo02_QA20013.Checked = true;
                this.rdo03_QA20013.Checked = false;

                this.rdo00_ORDER.Checked = true;
                this.rdo01_ORDER.Checked = false;
                this.rdo02_ORDER.Checked = false;

                this.SetRequired(lbl01_BIZNM2, lbl01_VIN);

                this.BtnReset_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [ 공통 버튼에 대한 이벤트 정의 ]

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control ctl in groupBox_main.Controls)
                {
                    if (ctl is IAxControl)
                    {
                        ((IAxControl)ctl).Initialize();
                    }
                }

                this.grd01_QA20013.InitializeDataSource();

                this.grd01_QA20013.SelectionMode = SelectionModeEnum.ListBox;
                
                this.cdx_SETTING();
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsSelectValid()) return;

                string BIZCD = this.cbo01_BIZCD.GetValue().ToString();
                string ITEMCD = this.cdx01_ITEMCD.GetValue().ToString();
                string PARTNO = this.txt01_PARTNO.GetValue().ToString();
                string VINCD = this.cdx01_VINCD.GetValue().ToString();
                string INSTALL_POS = this.cdx01_INSTALL_POS.GetValue().ToString();
                string GUBN = "";
                if (this.rdo01_QA20013.Checked == true)
                {
                    GUBN = "0";
                }
                else if (this.rdo02_QA20013.Checked == true)
                {
                    GUBN = "1";
                }
                else
                {
                    GUBN = "2";
                }

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", _CORCD);
                paramSet.Add("BIZCD", BIZCD);
                paramSet.Add("ITEMCD", ITEMCD);
                paramSet.Add("PARTNO", PARTNO);
                paramSet.Add("VINCD", VINCD);
                paramSet.Add("INSTALL_POS", INSTALL_POS);
                paramSet.Add("GUBN", GUBN);
                paramSet.Add("LANG_SET", _LANG_SET);
                paramSet.Add("PLANT_DIV", this.UserInfo.PlantDiv.Equals("U902") ? this.UserInfo.PlantDiv : string.Empty);

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);

                if (this.rdo01_ORDER.Checked)
                {
                    source.Tables[0].DefaultView.Sort = "PARTNO, VINCD, ITEMCD, VENDNM ";
                }
                else if (this.rdo02_ORDER.Checked)
                {
                    source.Tables[0].DefaultView.Sort = "VENDNM, VINCD, ITEMCD, PARTNO ";
                }
                else
                {
                    source.Tables[0].DefaultView.Sort = "VINCD, ITEMCD, PARTNO, VENDNM ";
                }

                this.AfterInvokeServer();

                this.grd01_QA20013.SetValue(source.Tables[0].DefaultView.ToTable());
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
                DataSet source = this.grd01_QA20013.GetValue(AxFlexGrid.FActionType.Save, 
                    "CORCD", "BIZCD", "PARTNO", "INSPECT_CLASSCD");

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                //_WSCOM.Save(source);
                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);

                this.AfterInvokeServer();

                this.BtnReset_Click(null, null);
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

        #endregion


        #region [ 기타 이벤트 정의 ]

        private void btn01_ALL_UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.GetByteCount(this.cdx01_INSPECT_CLASSCD.GetValue().ToString()) != 0)
                {
                    foreach (Row row in grd01_QA20013.Rows.Selected)
                    {
                        if (!IsALL_CHK_Valid(row.Index)) return;
                        this.grd01_QA20013.SetData(row.Index, "INSPECT_CLASSCD", this.cdx01_INSPECT_CLASSCD.GetValue().ToString());
                        this.grd01_QA20013[row.Index, 0] = "U";
                        CellRange cr = new CellRange();
                        cr = this.grd01_QA20013.GetCellRange(row.Index, this.grd01_QA20013.Cols.Fixed, row.Index, this.grd01_QA20013.Cols.Count - this.grd01_QA20013.Cols.Fixed);
                        cr.Style = this.grd01_QA20013.Styles["COLOR_B"];
                    }
                }
                else
                {
                    //MsgBox.Show("검사코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("QA_INSPECT_BASECODE"));
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn01_ALL_DELETE_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Row row in grd01_QA20013.Rows.Selected)
                {
                    if (!IsALL_CHK_Valid(row.Index)) return;
                    this.grd01_QA20013.SetData(row.Index, "INSPECT_CLASSCD", "");
                    this.grd01_QA20013[row.Index, 0] = "U";
                    CellRange cr = new CellRange();
                    cr = this.grd01_QA20013.GetCellRange(row.Index, this.grd01_QA20013.Cols.Fixed, row.Index, this.grd01_QA20013.Cols.Count - this.grd01_QA20013.Cols.Fixed);
                    cr.Style = this.grd01_QA20013.Styles["COLOR_R"];
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        //검사코드 팝업 사이즈 재조정 - 검사코드 팝업에는 "공장구분"콤보상자 조건이 하나 더 추가되므로 기존 팝업보다 사이즈가 커야함. 기존사이즈는 (615,338)
        void cdx01_INSPECT_CLASSCD_ButtonClickBefore(object sender, EventArgs args)
        {
            AxCommonPopupControl pop = (AxCommonPopupControl)this.cdx01_INSPECT_CLASSCD.HEPopupHelper;
            pop.Width = 770;
            pop.Height = 450;
        }

        private void cdx01_VINCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx01_VINCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx01_ITEMCD_CodeBoxBindingAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cdx01_ITEMCD_ButtonClickAfter(object sender, EventArgs args)
        {
            this.cdx_SETTING();
        }

        private void cbo01_BIZCD_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cdx_SETTING();
        }
        
        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("변경된 데이터가 존재하지 않아 저장할 수 없습니다.");
                    MsgCodeBox.Show("CD00-0042");
                    return false;
                } 
                
                for (int i = 1; i < source.Tables[0].Rows.Count; i++)
                {
                    string BIZCD = source.Tables[0].Rows[i]["BIZCD"].ToString();
                    string PARTNO = source.Tables[0].Rows[i]["PARTNO"].ToString();

                    if (this.GetByteCount(BIZCD) == 0)
                    {
                        //MsgBox.Show("사업장코드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("CD00-0079", this.GetLabel("BIZCD"));
                        return false;
                    }

                    if (this.GetByteCount(PARTNO) == 0)
                    {
                        //MsgBox.Show("자재 품번 데이터가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("MAT_PARTNO"));
                        return false;
                    }
                }
                if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                {
                    return false;
                }
                //if (MsgBox.Show("저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                //    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsALL_CHK_Valid(int ROW)
        {
            try
            {
                if (ROW <= 0)
                {
                    //MsgBox.Show("선택한 그리드 데이터가 없습니다.");
                    MsgCodeBox.Show("QA00-009");
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        private bool IsSelectValid()
        {
            try
            {
                string VINCD = this.cdx01_VINCD.GetValue().ToString();

                if (this.GetByteCount(VINCD) == 0)
                {
                    //MsgBox.Show("차종코드 데이터가 입력되지 않았습니다.");
                    MsgCodeBox.ShowFormat("QA00-001", this.GetLabel("VINCD"));
                    return false;
                }

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
                return false;
            }
        }

        #endregion

        #region [ 사용자 정의 메서드 ]
        
        private void cdx_SETTING()
        {
            try
            {
                this.cdx01_INSPECT_CLASSCD.HEUserParameterSetValue("BIZCD", this.cbo01_BIZCD.GetValue().ToString());
                this.cdx01_INSPECT_CLASSCD.HEUserParameterSetValue("VINCD", this.cdx01_VINCD.GetValue().ToString());
                this.cdx01_INSPECT_CLASSCD.HEUserParameterSetValue("ITEMCD", this.cdx01_ITEMCD.GetValue().ToString());
                this.cdx01_ITEMCD.HEUserParameterSetValue("VINCD", this.cdx01_VINCD.GetValue().ToString());
                this.cdx01_INSTALL_POS.HEUserParameterSetValue("XD_CLASS", "A7");
                this.cdx01_INSTALL_POS.HEUserParameterSetValue("USE_YN", "");
                this.cdx01_INSTALL_POS.HEUserParameterSetValue("GROUPCD", "");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

    }
}
