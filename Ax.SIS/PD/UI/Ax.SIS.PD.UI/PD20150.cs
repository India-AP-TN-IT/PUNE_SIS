#region ▶ Description & History
/* 
* 프로그램명 : PD20150 차종별 통전 검사 항목 관리
* 설     명 : 
* 최초작성자 : 
* 최초작성일 : 
* 수정  내용 :
*  
* 
*				날짜			 작성자		이슈
*				---------------------------------------------------------------------------------------------
*				2017-07~09   배명희      SIS 이관
*				2019-04~29   KIM.JB      Modified for India Anantapur			
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

namespace Ax.SIS.PD.UI
{

    /// <summary>
    /// 차종별 통전 검사 항목 관리 
    /// </summary>
    public partial class PD20150 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "APG_PD20150";
        private string PACKAGE_NAME_ERM = "APG_PDCOMMON_ERM";

        private AxComboList grd_VINCD;
        private AxComboList grd_ITEMCD;
        private AxComboList grd_ET_GRPCD;
        private AxComboList grd_ET_DTLCD;

        #region [ 초기화 작업 정의 ]

        public PD20150()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();

            this.grd_VINCD = new AxComboList();
            this.grd_ITEMCD  = new AxComboList();
            this.grd_ET_GRPCD = new AxComboList();
            this.grd_ET_DTLCD = new AxComboList();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.grd_VINCD.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_VINCD_BeforeOpen);
                this.grd_ITEMCD.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_ITEMCD_BeforeOpen);
                this.grd_ET_GRPCD.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_ET_GRPCD_BeforeOpen);
                this.grd_ET_GRPCD.SelectedValueChanged += new EventHandler(grd_ET_GRPCD_SelectedValueChanged);
                this.grd_ET_DTLCD.BeforeOpen += new System.ComponentModel.CancelEventHandler(grd_ET_DTLCD_BeforeOpen);
                this.grd_ET_DTLCD.SelectedValueChanged += new EventHandler(grd_ET_DTLCD_SelectedValueChanged);

                this.grd01.Initialize();

                this.grd01.AddColumn(true, false, AxFlexGrid.FtextAlign.C, 60, "법인코드", "CORCD", "CORCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "차종코드", "VINCD", "VINCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 70, "품목코드", "ITEMCD", "ITEMCD");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "통전그룹코드", "ET_GRPCD", "ET_GRP_CD");   //읽기전용 해제 (2013.10.30) : 읽기 전용상태에서는 CTRL+V시 값이 안들어감. 대신 사용자 입력을 SetupEditor 이벤트에서 막음.
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 160, "통전그룹명", "ET_GRPNM", "ET_GRP_CDNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "통전상세코드", "ET_DTLCD", "ET_DTLCD");   //읽기전용 해제 (2013.10.30) : 읽기 전용상태에서는 CTRL+V시 값이 안들어감. 대신 사용자 입력을 SetupEditor 이벤트에서 막음.
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "통전상세명", "ET_DTLNM", "ET_DTLNM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 100, "통전항목번호", "ET_POS", "ET_POS");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 200, "통전항목명(한글)", "ET_DESC", "ET_DESC");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 120, "통전검사순서", "ET_SEQ", "ET_SEQ");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 140, "전류하한값(mA)", "ET_CURRENT_MIN", "ET_CURRENT_MIN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 140, "전류상한값(mA)", "ET_CURRENT_MAX", "ET_CURRENT_MAX");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "설비PLC", "MC_ADDR", "MC_ADDR");

                this.grd01.Cols["VINCD"].Editor = this.grd_VINCD;
                this.grd01.Cols["ITEMCD"].Editor = this.grd_ITEMCD;
                this.grd01.Cols["ET_GRPNM"].Editor = this.grd_ET_GRPCD;
                this.grd01.Cols["ET_DTLNM"].Editor = this.grd_ET_DTLCD;

                this.grd01.Cols["ET_CURRENT_MIN"].Format = "###,###,###,##0.00";
                this.grd01.Cols["ET_CURRENT_MAX"].Format = "###,###,###,##0.00";

                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("OBJECTCD", "VINCD");
                set.Add("LANG_SET", this.UserInfo.Language);
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_OBJECT"), set).Tables[0];

                this.cbl01_VINCD.DataBind(source, "TYPECD", "OBJECT_NM", this.GetLabel("VINCD") + ";" + this.GetLabel("VINNM"), "C;L"); //차종코드;차종명

                set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", this.UserInfo.BusinessCode);
                set.Add("OBJECTCD", "ITEMCD");
                set.Add("LANG_SET", this.UserInfo.Language);
                source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_OBJECT"), set).Tables[0];
                this.cbl01_ITEMCD.DataBind(source, "TYPECD", "OBJECT_NM", this.GetLabel("ITEMCD") + ";" + this.GetLabel("ITEMNM"), "C;L"); //차종코드;차종명

                this.SetRequired(lbl01_VEHICLE);
                this.SetRequired(lbl01_ITEM);
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

                if (this.cbl01_VINCD.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("차종을 선택하세요");
                    //차종이(가) 선택되지 않았습니다.
                    MsgCodeBox.ShowFormat("PD00-0001", this.GetLabel("VEHICLE"));
                    return;
                }

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("VINCD", this.cbl01_VINCD.GetValue());
                set.Add("ITEMCD", this.cbl01_ITEMCD.GetValue());

                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "INQUERY"), set, "OUT_CURSOR");

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
                string bizcd = this.UserInfo.BusinessCode;
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Save, "CORCD", "VINCD", "ITEMCD", "ET_POS", "ET_GRPCD", "ET_DTLCD", "ET_SEQ", "ET_DESC", "ET_CURRENT_MIN", "ET_CURRENT_MAX", "BIZCD", "EMPNO", "MC_ADDR");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["BIZCD"] = this.UserInfo.BusinessCode;
                    rows["EMPNO"] = this.UserInfo.EmpNo;
                }

                if (!this.IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_SAVE"), source);

                this.AfterInvokeServer();
                
                this.BtnQuery_Click(null, null);
                //MsgBox.Show("입력하신 차종별 통전 검사항목을 저장하였습니다.");
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

        protected override void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;
                DataSet source = this.grd01.GetValue(AxFlexGrid.FActionType.Remove, "CORCD", "VINCD", "ITEMCD", "ET_POS", "BIZCD");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["BIZCD"] = this.UserInfo.BusinessCode;
                }

                if (!this.IsRemoveValid(source)) return;

                this.BeforeInvokeServer(true);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "DATA_REMOVE"), source);

                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                //MsgBox.Show("입력하신 차종별 통전 검사항목을 삭제하였습니다.");
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

        #region [ 기타 컨트롤에 대한 이벤트 정의 ]

        void grd_VINCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set1 = new HEParameterSet();
                set1.Add("CORCD", this.UserInfo.CorporationCode);
                set1.Add("BIZCD", this.UserInfo.BusinessCode);
                set1.Add("OBJECTCD", "VINCD");
                set1.Add("LANG_SET", this.UserInfo.Language);
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_OBJECT"), set1).Tables[0];
                this.grd_VINCD.DataBind(source, "TYPECD", "TYPECD", this.GetLabel("VINCD") + ";" + this.GetLabel("VINNM"), "C;L");  //차종코드;차종명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_ITEMCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set1 = new HEParameterSet();
                set1.Add("CORCD", this.UserInfo.CorporationCode);
                set1.Add("BIZCD", this.UserInfo.BusinessCode);
                set1.Add("OBJECTCD", "ITEMCD");
                set1.Add("LANG_SET", this.UserInfo.Language);
                DataTable source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME_ERM, "INQUERY_COMBO_OBJECT"), set1).Tables[0];
                this.grd_ITEMCD.DataBind(source, "TYPECD", "TYPECD", this.GetLabel("ITEMCD") + ";" + this.GetLabel("ITEMNM"), "C;L");  //차종코드;차종명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_ET_GRPCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);

                this.grd_ET_GRPCD.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "APG_PDCOMMON_MES", "INQUERY_COMBO_ETGROUP"), set).Tables[0], this.GetLabel("GROUP_CD") + ";" + this.GetLabel("ET_GRP_CDNM"), "C;L");  //그룹코드;통전그룹명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_ET_GRPCD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                this.grd01.SetValue(row, "ET_GRPCD", this.grd_ET_GRPCD.GetValue("ET_GRPCD"));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_ET_DTLCD_BeforeOpen(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                string bizcd = this.UserInfo.BusinessCode;

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("ET_GRPCD", this.grd01.GetValue(row, "ET_GRPCD"));

                this.grd_ET_DTLCD.DataBind(_WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", "APG_PDCOMMON_MES", "INQUERY_COMBO_ETDETAIL"), set).Tables[0], this.GetLabel("DETAIL_CODE") + ";" + this.GetLabel("ET_DTLNM"), "C;L"); //상세코드;통전상세명
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        void grd_ET_DTLCD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                this.grd01.SetValue(row, "ET_DTLCD", this.grd_ET_DTLCD.GetValue("ET_DTLCD"));
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                    this.grd01.SetValue(i, "CORCD", this.UserInfo.CorporationCode);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }
        
        private void grd01_SetupEditor(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {
            //통전그룹코드, 통전상세코드는 사용자가 편집할수 없도록 함.
            if (e.Col == this.grd01.Cols["ET_GRPCD"].Index ||
                e.Col == this.grd01.Cols["ET_DTLCD"].Index)
            {
                TextBox txt = (TextBox)this.grd01.Editor;
                txt.Enabled = false;
            }
            
            //텍스트 입력인 다른 항목들인 (통전항목번호, 통전항목명, 통전검사순서, 전류하한값, 전류상한값) 경우에는 편집 허용.
            if (e.Col == this.grd01.Cols["ET_POS"].Index ||
                e.Col == this.grd01.Cols["ET_DESC"].Index ||
                e.Col == this.grd01.Cols["ET_SEQ"].Index ||
                e.Col == this.grd01.Cols["ET_CURRENT_MIN"].Index ||
                e.Col == this.grd01.Cols["ET_CURRENT_MAX"].Index)
            {
                TextBox txt = (TextBox)this.grd01.Editor;
                txt.Enabled = true;
            }

        }
        
        #endregion

        #region [ 유효성 검사 ]

        private bool IsSaveValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count == 0)
            {
                //MsgBox.Show("저장할 차종별 통전검사 정보가 없습니다.");
                //저장할 데이터가 존재하지 않습니다.
                MsgCodeBox.Show("CD00-0042");
                return false;
            }

            for (int i = 0; i < source.Tables[0].Rows.Count; i++)
            {
                DataRow row = source.Tables[0].Rows[i];
                DataRow seq = source.Tables[1].Rows[i];

                if (this.Nvl(row["VINCD"], "").ToString().Length == 0)
                {
                    //MsgBox.Show(String.Format("{0}행의 {차종}이 선택되지 않았습니다.", seq["GRIDSEQ"]));
                    MsgCodeBox.ShowFormat("PD00-0007", seq["GRIDSEQ"], this.grd01.Cols["VINCD"].Caption.ToString());
                    return false;
                }

                if (this.Nvl(row["ITEMCD"], "").ToString().Length == 0)
                {
                    //MsgBox.Show(String.Format("{0}행의 {차종}이 선택되지 않았습니다.", seq["GRIDSEQ"]));
                    MsgCodeBox.ShowFormat("PD00-0007", seq["GRIDSEQ"], this.grd01.Cols["ITEMCD"].Caption.ToString());
                    return false;
                }

                if (this.Nvl(row["ET_GRPCD"], "").ToString().Length == 0)
                {
                    //MsgBox.Show(String.Format("{0}행의 {통전검사 그룹}이 선택되지 않았습니다.", seq["GRIDSEQ"]));
                    MsgCodeBox.ShowFormat("PD00-0007", seq["GRIDSEQ"], this.grd01.Cols["ET_GRPNM"].Caption.ToString());
                    return false;
                }

                if (this.Nvl(row["ET_DTLCD"], "").ToString().Length == 0)
                {
                    //MsgBox.Show(String.Format("{0}행의 {통전검사 상세항목}이 선택되지 않았습니다.", seq["GRIDSEQ"]));
                    MsgCodeBox.ShowFormat("PD00-0007", seq["GRIDSEQ"], this.grd01.Cols["ET_DTLNM"].Caption.ToString());
                    return false;
                }

                if (this.Nvl(row["ET_POS"], "").ToString().Length == 0)
                {
                    //MsgBox.Show(String.Format("{0}행의 {통전항목번호}가 선택되지 않았습니다.", seq["GRIDSEQ"]));
                    MsgCodeBox.ShowFormat("PD00-0007", seq["GRIDSEQ"], this.grd01.Cols["ET_POS"].Caption.ToString());
                    return false;
                }
            }

            //if (MsgBox.Show("입력하신 차종별 통전검사 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //저장하시겠습니까?
            if (MsgCodeBox.ShowFormat("CD00-0076", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }

        private bool IsRemoveValid(DataSet source)
        {
            if (source.Tables[0].Rows.Count == 0)
            {
                //MsgBox.Show("삭제할 차종별 통전검사 정보를 선택하세요.");
                //삭제할 데이터가 존재하지 않습니다.
                MsgCodeBox.Show("CD00-0041");
                return false;
            }

            //if (MsgBox.Show("선택하신 차종별 통전검사 정보를 삭제하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
            //삭제하시겠습니까?
            if (MsgCodeBox.ShowFormat("CD00-0077", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return false;

            return true;
        }

        #endregion
      
    }
}
