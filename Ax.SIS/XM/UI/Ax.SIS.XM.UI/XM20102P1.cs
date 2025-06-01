#region ▶ Description & History
/* 
 * 프로그램명 : 그리드 다국어 등록 팝업
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-04      배명희      프로그램 아이디 변경(XM70020 -> XM20102P1)
 *				                            웹서비스 호출(DB) 로직 변경, 다국어 처리, 시스템코드 적용(콤보)
 *				2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거       
 *				2014-12-17      배명희     그리드 다국어 처리 방식 변경 (XD1410사용하지 않고 XD1420사용)
 * 
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
    /// 그리드 다국어 등록 팝업
    /// </summary>
    public partial class XM20102P1 : AxCommonPopupControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM20102";
        private string _Menuid;
        private string _Gridname;
        private string _Headcount;

        public XM20102P1(string menuid, string gridname, string headcount)
        {
            InitializeComponent();

            _WSCOM = new AxClientProxy();
            _Menuid = menuid;
            _Gridname = gridname;
            _Headcount = headcount;
        }

        #region [ 초기화 작업 ]

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                DataTable source1 = this.GetDataSourceSchema("CODE", "CODENAME").Tables[0];
                DataTable source4 = this.GetDataSourceSchema("CODE", "CODENAME").Tables[0];
                source1.Rows.Add("L", "Left");
                source1.Rows.Add("C", "Center");
                source1.Rows.Add("R", "Right");
                source4.Rows.Add("System.String", "String");
                source4.Rows.Add("System.Boolean", "Bool");
                source4.Rows.Add("System.DateTime", "Date");
                source4.Rows.Add("System.Decimal", "Decimal");
                source4.Rows.Add("System.Int32", "Int");

                this.grd01.Initialize();
                //this.grd01.Cols.RemoveRange(1, this.grd01.Cols.Count - 1);
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 070, "_컬럼인덱스", "COLUMNINDEX", "COLUMNINDEX");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 060, "_넓이", "COLUMNWIDTH", "COLUMNWIDTH");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 060, "_정렬", "COLUMNALIGN", "COLUMNALIGN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 060, "_숨김", "HIDDEN", "HIDDEN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 080, "_데이터타입", "DATATYPE", "DATATYPE");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 100, "_포맷", "FORMAT", "FORMAT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 060, "_고정", "FROZENCOLUMN", "FROZENCOLUMN");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "_헤더1", "HEADERCODE1", "HEADERCODE1");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "_헤더2", "HEADERCODE2", "HEADERCODE2");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 130, "_헤더3", "HEADERCODE3", "HEADERCODE3");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 060, "_읽기전용", "ENABLED", "ENABLED");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 060, "_COLOR", "COLOR", "COLOR");

                this.grd01.SetColumnType_Original(AxFlexGrid.FCellType.ComboBox, source1, "COLUMNALIGN", false);
                this.grd01.SetColumnType_Original(AxFlexGrid.FCellType.ComboBox, source4, "DATATYPE", false);
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "HIDDEN");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "FROZENCOLUMN");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Check, "ENABLED");
                this.grd01.SetColumnType(AxFlexGrid.FCellType.Decimal, "COLUMNWIDTH");

                this.grd01.RowInserted += new AxFlexGrid.FAlterRowInsertEventHandler(grd01_RowInserted);

                this.txt01_GRIDNAME.SetValue(_Gridname);
                this.txt01_HEADERCOUNT.SetValue(_Headcount);
                this.txt01_GRIDNAME.SetReadOnly(true);
                this.txt01_HEADERCOUNT.SetReadOnly(true);
                this.btn01_Inquery_Click(null, null);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }
        #endregion

        #region [버튼 클릭 이벤트]

        private void btn01_Inquery_Click(object sender, EventArgs e)
        {
            try
            {
                HEParameterSet set = new HEParameterSet();
                set.Add("MENUID", _Menuid);
                set.Add("GRIDNAME", this.txt01_GRIDNAME.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.XD1410_INQUERY(set);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1410_INQUERY"), set);
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

        private void btn03_Save_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = grd01.GetValue(AxFlexGrid.FActionType.Save,
                    "MENUID", "GRIDNAME", "COLUMNINDEX", "COLUMNWIDTH", "COLUMNALIGN", "HIDDEN", "DATATYPE",
                    "FORMAT", "FROZENCOLUMN", "HEADERCODE1", "HEADERCODE2", "HEADERCODE3", "ENABLED", "COLOR");

                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["MENUID"] = _Menuid;
                    rows["GRIDNAME"] = this.txt01_GRIDNAME.GetValue();
                }

                if (!IsSaveValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.XD1410_SAVE(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1410_SAVE"), source);
                this.AfterInvokeServer();

                this.btn01_Inquery_Click(null, null);
                //MsgBox.Show("입력하신 그리드 컬럼 정보가 저장되었습니다.");//
                MsgCodeBox.Show("XM00-0068");
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

        private void btn03_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet source = grd01.GetValue(AxFlexGrid.FActionType.Remove, "MENUID", "GRIDNAME", "COLUMNINDEX");
                foreach (DataRow rows in source.Tables[0].Rows)
                {
                    rows["MENUID"] = _Menuid;
                    rows["GRIDNAME"] = this.txt01_GRIDNAME.GetValue();
                }

                if (!IsDeleteValid(source)) return;

                this.BeforeInvokeServer(true);
                //_WSCOM.XD1410_REMOVE(source);
                _WSCOM.ExecuteNonQueryTx(string.Format("{0}.{1}", PAKAGE_NAME, "AXD1410_REMOVE"), source);
                this.AfterInvokeServer();

                this.btn01_Inquery_Click(null, null);
                //MsgBox.Show("선택하신 그리드 컬럼 정보가 삭제되었습니다.");//XM00-0069
                MsgCodeBox.Show("XM00-0069");//
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

        private void btn01_CLOSE_Click(object sender, EventArgs e)
        {
            //if (MsgBox.Show("그리드 컬럼정보 입력 프로그램을 닫으시겠니까?", "주의",
            if (MsgCodeBox.Show("XM00-0070",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
                this.ParentForm.Close();
        }

        #endregion

        #region [유효성 체크]

        private bool IsSaveValid(DataSet source)
        {
            try
            {
                if (source.Tables[0].Rows.Count == 0)
                {
                    //MsgBox.Show("저장할 그리드 컬럼 정보가 존재하지 않습니다.");//XM00-0071
                    MsgCodeBox.Show("XM00-0071");//
                    return false;
                }

                for (int i = 0; i < source.Tables[0].Rows.Count; i++)
                {
                    string COLUMNINDEX = this.Nvl(source.Tables[0].Rows[i]["COLUMNINDEX"], "").ToString();
                    string COLUMNWIDTH = this.Nvl(source.Tables[0].Rows[i]["COLUMNWIDTH"], "").ToString();
                    string FORMAT = this.Nvl(source.Tables[0].Rows[i]["FORMAT"], "").ToString();
                    string HEADERCODE1 = this.Nvl(source.Tables[0].Rows[i]["HEADERCODE1"], "").ToString();
                    string HEADERCODE2 = this.Nvl(source.Tables[0].Rows[i]["HEADERCODE2"], "").ToString();
                    string HEADERCODE3 = this.Nvl(source.Tables[0].Rows[i]["HEADERCODE3"], "").ToString();
                    string COLOR = this.Nvl(source.Tables[0].Rows[i]["COLOR"], "").ToString();

                    string DATATYPE = this.Nvl(source.Tables[0].Rows[i]["DATATYPE"], "").ToString();
                    string COLUMNALIGN = this.Nvl(source.Tables[0].Rows[i]["COLUMNALIGN"], "").ToString();

                    if (this.GetByteCount(COLUMNINDEX) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 컬럼인덱스가 입력되지 않았습니다.");//XM00-0044
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd01.Cols["COLUMNINDEX"].Caption);//
                        return false;
                    }

                    if (this.GetByteCount(COLUMNWIDTH) == 0)
                        source.Tables[0].Rows[i]["COLUMNWIDTH"] = 0;

                    if (this.GetByteCount(COLUMNWIDTH) == 0)
                        source.Tables[0].Rows[i]["DATATYPE"] = "System.String";

                    if (this.GetByteCount(COLUMNWIDTH) == 0)
                        source.Tables[0].Rows[i]["COLUMNALIGN"] = "L";

                    if (this.GetByteCount(FORMAT) > 0 && this.GetByteCount(FORMAT) > 30)
                    {
                        //MsgBox.Show(i + " 번째 행에 포맷은 30byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd01.Cols["FORMAT"].Caption, 30);
                        return false;
                    }

                    if (this.GetByteCount(HEADERCODE1) > 0 && this.GetByteCount(HEADERCODE1) > 30)
                    {
                        //MsgBox.Show(i + " 번째 행에 컬럼헤더1은 30byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd01.Cols["HEADERCODE1"].Caption, 30);
                        return false;
                    }

                    if (this.GetByteCount(HEADERCODE2) > 0 && this.GetByteCount(HEADERCODE2) > 30)
                    {
                        //MsgBox.Show(i + " 번째 행에 컬럼헤더2은 30byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd01.Cols["HEADERCODE2"].Caption, 30);
                        return false;
                    }

                    if (this.GetByteCount(HEADERCODE3) == 0)
                    {
                        //MsgBox.Show(i + " 번째 행에 컬럼헤더3이 입력되지 않았습니다.");
                        MsgCodeBox.ShowFormat("XM00-0044", i, this.grd01.Cols["HEADERCODE3"].Caption);//
                        return false;
                    }

                    if (this.GetByteCount(COLOR) > 0 && this.GetByteCount(COLOR) > 30)
                    {
                        //MsgBox.Show(i + " 번째 행에 색상은 30byte 이상 입력할 수 없습니다.");
                        MsgCodeBox.ShowFormat("XM00-0045", i, this.grd01.Cols["COLOR"].Caption, 30);
                        return false;
                    }
                }

                for (int i = this.grd01.Rows.Fixed; i < this.grd01.Rows.Count; i++)
                {
                    string COLUMNINDEX1 = this.grd01.GetValue(i, "COLUMNINDEX").ToString();
                    for (int j = i + 1; j < this.grd01.Rows.Count; j++)
                    {
                        string COLUMNINDEX2 = this.grd01.GetValue(j, "COLUMNINDEX").ToString();
                        if (COLUMNINDEX1.Equals(COLUMNINDEX2))
                        {
                            //
                            //MsgBox.Show("중복된 컬럼인덱스가 존재합니다.\r\n\r\n중복된 컬럼인덱스는 입력할 수 없습니다.");
                            MsgCodeBox.Show("XM00-0072");
                            return false;
                        }
                    }
                }
                //if (MsgBox.Show("입력하신 그리드 컬럼 정보를 저장하시겠습니까?", "주의", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0073", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
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
                    //MsgBox.Show("삭제할 그리드 컬럼 정보를 선택하지 않았습니다.");
                    MsgBox.Show("XM00-0074");
                    return false;
                }

                //if (MsgBox.Show("선택하신 그리드 컬럼 정보를 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) != DialogResult.OK)
                if (MsgCodeBox.Show("XM00-0075", MessageBoxButtons.OKCancel) != DialogResult.OK)
                    return false;

                return true;
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }

            return false;
        }

        #endregion

        #region [컨트롤 이벤트]

        private void grd01_RowInserted(object sender, AxFlexGrid.FAlterEventRow args)
        {
            try
            {
                for (int i = args.RowIndex; i < args.RowIndex + args.RowCount; i++)
                {
                    this.grd01.SetValue(i, "COLUMNWIDTH", 60);
                    this.grd01.SetValue(i, "COLUMNALIGN", "L");
                    this.grd01.SetValue(i, "HIDDEN", 0);
                    this.grd01.SetValue(i, "DATATYPE", "System.String");
                    this.grd01.SetValue(i, "FROZENCOLUMN", 0);
                    this.grd01.SetValue(i, "ENABLED", 0);
                }
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}
