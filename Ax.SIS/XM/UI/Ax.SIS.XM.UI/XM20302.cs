#region ▶ Description & History
/* 
 * 프로그램명 : 유형코드관리
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-07      배명희      프로그램 아이디 변경(XM20010 -> XM20302)
 *                                          웹서비스 호출(DB) 로직 변경, 다국어 처리, 공통컨트롤로 전환
 *              2014-07-14      배명희      상단의 유형코드 그리드 "CLASS명"(CLASS_NM) 항목 추가 및 조회, 저장 로직에 추가.
 *              2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거        
 *              2014-12-17      배명희     그리드 다국어 처리 방식 변경 (XD1410사용하지 않고 XD1420사용)
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.Core;
using HE.Framework.ServiceModel;
using TheOne.Windows.Forms;

namespace Ax.SIS.XM.UI
{
    /// <summary>
    /// <b>유형코드 관리</b>    
    /// </summary>
    public partial class XM20302 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM20302";
        private string PAKAGE_NAME_XM20101 = "APG_XM20101";
        public XM20302()
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
        }

        #region [초기화 작업에 대한 정의]
        
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                DataTable dtLangset = this.getLanguageCode();               

                this.txt02_CLASS_ID.ReadOnly = true;

                this.grd01.Initialize();
                this.grd02.Initialize();

                this.grd01.PopMenuVisible = true;
                this.grd02.PopMenuVisible = true;
               
                //this.grd01.Cols.RemoveRange(1, this.grd01.Cols.Count - 1);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 060, "_클래스ID", "CLASS_ID", "CLASS_ID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "_CLASS_명", "CLASS_NM", "CLASS_NM");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "_테이블 ID", "TABLE_ID", "TABLE_ID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "_컬럼 ID", "COLUMN_ID", "COLUMN_ID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "_관리자 사번", "MGR_EMPNO", "MGR_EMPNO");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "_시스템 사용 유무", "SYSTEM_USER_YN", "SYSTEM_USER_YN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "_비고", "REMARK", "REMARK");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "_최초등록일시", "INSERT_DATE", "INSERT_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 070, "_최초등록자", "INSERT_ID", "INSERT_ID");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "_최종등록일시", "UPDATE_DATE", "UPDATE_DATE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "_최종등록자", "UPDATE_ID", "UPDATE_ID");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "SYSTEM_USER_YN");

                //this.grd02.Cols.RemoveRange(1, this.grd02.Cols.Count - 1);
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "_TYPE CODE", "TYPECD", "TYPECD");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 120, "_항목", "OBJECT_NM", "OBJECT_NM");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "_그룹코드", "GROUPCD", "GROUPCD");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 060, "_기본값", "COMBO_VALUE", "COMBO_VALUE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.R, 060, "_정렬순서", "SORT_SEQ", "SORT_SEQ");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 080, "_적용유무", "USE_YN", "USE_YN");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 250, "_비고", "REMARK", "REMARK");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "_최초등록일시", "INSERT_DATE", "INSERT_DATE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 070, "_최초등록자", "INSERT_ID", "INSERT_ID");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "_최종등록일시", "UPDATE_DATE", "UPDATE_DATE");
                this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "_최종등록자", "UPDATE_ID", "UPDATE_ID");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Check, "USE_YN");
                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, "SORT_SEQ");
                this.grd02.Cols["SORT_SEQ"].Format = "#####.##";

                this.cbo02_LANGUAGE.DataBind(dtLangset, false);                

                this.txt01_CLASS_ID.SetValid(AxTextBox.TextType.UAlphabet);
                this.txt01_COLUMN_ID.SetValid(AxTextBox.TextType.UAlphabet);
                this.txt01_COLUMN_ID.SetValid(AxTextBox.TextType.UAlphabet);                

                this.BtnQuery_Click(null, null);
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
                DataSet source = grd01.GetValue(AxFlexGrid.FActionType.Save, 
                    "CLASS_ID", "MGR_EMPNO", "SYSTEM_USER_YN", "TABLE_ID", "COLUMN_ID","REMARK", "CLASS_NM", "LANG_SET");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["MGR_EMPNO"] = this.UserInfo.EmpNo;
                    rows["LANG_SET"] = this.UserInfo.Language;
                }
                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Save(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show("정상적으로 유형코드가 저장되었습니다.");
                MsgCodeBox.Show("XM00-0090");
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
                DataSet source = grd01.GetValue(AxFlexGrid.FActionType.Remove, "CLASS_ID");

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Remove(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE"), source);
                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);
                //MsgBox.Show("정상적으로 유형코드가 삭제되었습니다.");
                MsgCodeBox.Show("XM00-0091");
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

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.BtnReset_Click(null, null);

                string CORCD            = this.UserInfo.CorporationCode;
                string CLASS_ID         = this.txt01_CLASS_ID.GetValue().ToString();
                string TABLE_ID         = this.txt01_TABLE_ID.GetValue().ToString();
                string COLUMN_ID        = this.txt01_COLUMN_ID.GetValue().ToString();
                string SYSTEM_USER_YN   = this.chk01_SYSTEM_USE.GetValue().ToString();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD",           CORCD);
                paramSet.Add("CLASS_ID",        CLASS_ID);
                paramSet.Add("TABLE_ID",        TABLE_ID);
                paramSet.Add("COLUMN_ID",       COLUMN_ID);
                paramSet.Add("SYSTEM_USER_YN",  SYSTEM_USER_YN);
                paramSet.Add("LANG_SET",        this.UserInfo.Language);
                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.Inquery(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);
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

        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt02_CLASS_ID.Initialize();
                this.cbo02_LANGUAGE.SetValue(this.UserInfo.Language);
                this.grd02.InitializeDataSource();
                this.btn02_REMOVE.SetReadOnly(true);
                this.btn02_REORDER.SetReadOnly(true);
                this.btn02_SAVE.SetReadOnly(true);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [사용자 정의 메서드에 대한 정의]

        private void Querry_Detail(string CLASS_ID)
        {
            try
            {
                grd02.InitializeDataSource();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CLASS_ID", CLASS_ID);
                paramSet.Add("LANG_SET", this.cbo02_LANGUAGE.GetValue());

                this.BeforeInvokeServer(true);

                //DataSet source = _WSCOM.Inquery_Detail(paramSet);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL"), paramSet);

                this.grd02.SetValue(source.Tables[0]);

                this.btn02_REMOVE.SetReadOnly(false);
                this.btn02_REORDER.SetReadOnly(false);
                this.btn02_SAVE.SetReadOnly(false);
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

        private DataTable getLanguageCode()
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("LANG_SET", this.UserInfo.Language);

                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME_XM20101, "INQUERY_LANG_SET"), set);

                return source.Tables[0];
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return null;
        }

        #endregion

        #region [기타 컨트롤 이벤트 정의]

        private void grd01_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                int row = this.grd01.SelectedRowIndex;

                if (row < this.grd01.Rows.Fixed) return;

                string CLASS_ID = this.grd01[row, "CLASS_ID"].ToString();

                this.txt02_CLASS_ID.SetValue(CLASS_ID);

                this.Querry_Detail(CLASS_ID);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void btn02_SAVE_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = grd02.GetValue(AxFlexGrid.FActionType.Save,
                    "OBJECT_ID", "CLASS_ID", "TYPECD", "GROUPCD", "COMBO_VALUE", "SORT_SEQ", "USE_YN", "REMARK", "LANG_SET", "OBJECT_NM","EMPNO");//#001

                string CLASS_ID = this.txt02_CLASS_ID.GetValue().ToString();

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["CLASS_ID"] = this.txt02_CLASS_ID.GetValue().ToString();
                    rows["OBJECT_ID"] = string.Format("{0}{1}",this.txt02_CLASS_ID.GetValue(), rows["TYPECD"]);
                    rows["LANG_SET"] = this.cbo02_LANGUAGE.GetValue();
                    rows["EMPNO"] = this.UserInfo.EmpNo;
                }

                if (!IsSaveDetailValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Save_Detail(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_DETAIL"), source);
                this.AfterInvokeServer();

                this.Querry_Detail(CLASS_ID);

                //MsgBox.Show("정상적으로 유형상세코드가 저장되었습니다.");
                MsgCodeBox.Show("XM00-0092");
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

        private void btn02_REMOVE_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = grd02.GetValue(AxFlexGrid.FActionType.Remove, "OBJECT_ID", "TYPECD");

                string CLASS_ID = this.txt02_CLASS_ID.GetValue().ToString();

                foreach (DataRow rows in source.Tables[0].Rows)
                    rows["OBJECT_ID"] = string.Format("{0}{1}", this.txt02_CLASS_ID.GetValue(), rows["TYPECD"]);

                source.Tables[0].Columns.Remove("TYPECD");

                if (!IsDeleteDetailValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.Remove_Detail(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "REMOVE_DETAIL"), source);
                this.AfterInvokeServer();
                this.Querry_Detail(CLASS_ID);

                //MsgBox.Show("정상적으로 유형상세코드가 삭제되었습니다.");
                MsgCodeBox.Show("XM00-0093");
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

        private void btn02_REORDER_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsReorderValid()) return;
                string CLASS_ID = this.txt02_CLASS_ID.GetValue().ToString();

                DataSet source = this.GetDataSourceSchema("CLASS_ID", "EMPNO");     //#001
                source.Tables[0].Rows.Add(CLASS_ID, this.UserInfo.EmpNo);           //#001

                this.BeforeInvokeServer(true);
                //_WSCOM.Save_Reorder(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "SAVE_REORDER"), source);
                this.AfterInvokeServer();

                this.Querry_Detail(CLASS_ID);
                //MsgBox.Show("정상적으로 상세유형코드의 정렬순서가 재조정됐습니다.");
                MsgCodeBox.Show("XM00-0094");
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

        private void cbo02_LANGUAGE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.txt02_CLASS_ID.GetValue().ToString().Length == 0) return;

            this.Querry_Detail(this.txt02_CLASS_ID.GetValue().ToString());
        }
        
        #endregion

        #region [유효성 검사]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 유형코드가 존재하지 않습니다.");
                    MsgCodeBox.Show("XM00-0095");
                    return false;
                }

                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {

                    string CLASS_ID         = this.grd01.GetValue(i, "CLASS_ID").ToString();
                    string COLUMN_ID        = this.grd01.GetValue(i, "COLUMN_ID").ToString();

                    if (this.GetByteCount(CLASS_ID) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 클래스ID가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd01.Cols["CLASS_ID"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(CLASS_ID) > 5)
                    {
                        //MsgBox.Show(i + " 번째 행에 클래스ID는 2byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd01.Cols["CLASS_ID"].Caption, 2);
                        return false;
                    }

                    if (this.GetByteCount(COLUMN_ID) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 컬럼ID가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd01.Cols["COLUMN_ID"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(COLUMN_ID) > 20)
                    {
                        //MsgBox.Show(i + " 번째 행에 컬럼ID는 20byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd01.Cols["COLUMN_ID"].Caption, 20);
                        return false;
                    }
                }

                //if (MsgBox.Show("입력하신 유형코드를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0096", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
                    //MsgBox.Show("삭제할 유형코드가 존재하지 않습니다.");
                    MsgCodeBox.Show("XM00-0097");
                    return false;
                }

                //if (MsgBox.Show("선택하신 유형코드를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0098", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsSaveDetailValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 유형상세코드가 존재하지 않습니다.");
                    MsgCodeBox.Show("XM00-0099");
                    return false;
                }

                for (int i = this.grd02.Rows.Fixed; i < this.grd02.Rows.Count; i++)
                {
                    string TYPECD = this.grd02.GetValue(i, "TYPECD").ToString();

                    if (this.GetByteCount(TYPECD) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 코드가 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd02.Cols["TYPECD"].Caption);
                        return false;
                    }

                    if (this.GetByteCount(TYPECD) > 8)
                    {

                        //MsgBox.Show(i + " 번째 행에 코드는 8byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd02.Cols["TYPECD"].Caption, 8);
                        return false;
                    }
                }

                //if (MsgBox.Show("입력하신 유형상세코드를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0100", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsDeleteDetailValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("삭제할 유형상세코드가 존재하지 않습니다.");
                    MsgCodeBox.Show("XM00-0101");
                    return false;
                }

                //if (MsgBox.Show("선택하신 유형상세코드를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0102", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        private bool IsReorderValid()
        {
            try
            {
                if (this.txt02_CLASS_ID.GetValue().ToString().Length == 0)
                {
                    //MsgBox.Show("정렬순서를 재조정할 유형코드가 선택되지 않았습니다.");
                    MsgCodeBox.Show("XM00-0103");
                    return false;
                }

                //if (MsgBox.Show("해당 유형코드의 상세유형코드 정렬순서를 재조정하게 됩니다. \n\n계속하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0104", MessageBoxButtons.OKCancel) != DialogResult.OK)
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

    }
}
