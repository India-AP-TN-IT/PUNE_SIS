#region ▶ Description & History
/* 
 * 프로그램명 : C1FlexGrid 클래스를 상속받아 구현된 그리드입니다.
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-15      배명희      SelectedDataRowMultiLang 프로퍼티 추가(다국어 적용된 그리드의 경우, 기존의 SelectedDataRow 메서드 대체함.)
 *              2014-08-27      배명희      HEFlexGrid_ValidateEdit         이벤트 추가
 *                                                                          (dbnull값을 가지고 있는 셀에 edit모드로 들어갔지만 편집없이 나오면 ""값으로 반환되면서 
 *                                                                          CellChange 이벤트가 발생하여 행flag가 "U"로 변경되는 문제 해결하기 위해)
 *                                          HEFlexGrid_AfterSort            이벤트 추가
 *                                                                          값 편집 중에 Sorting하면, 데이터는 정렬되는데 행flag는 변경되지 않아 
 *                                                                          저장시에 엉뚱한 데이터 추출되는 문제 해결하기 위해, 
 *                                                                          AllowEditing=true인 그리드인 경우 Sort가 일어나면 RowState를 체크하여 행flag를 다시 찍어줌.
 *                                          Insert_ToolStripMenuItem_Click  이벤트 수정
 *                                                                          Sorting중인 경우, "행추가"하면 행flag가 엉뚱한 곳에 찍히거나 안찍히거나 함. 
 *                                                                          RowState에 따라 행flag 찍어주는 로직 넣음.
 *              2014-08-29      배명희     contextmenu, message, 합계스타일등의 텍스트 다국어 처리함.(resource파일사용)
 *              2015-04-20      김민재     SetValue() 후 DateTime이 있을 경우 this[i, 0] = i를 this[i, 0] = i - grid.Rows.Fixed + 1로 변경
 *              2015-04-20      김민재     Initialize 작업 시 기존 Cols.Count == 0 이면 Cols.Count의 값을 1을 조건없이 Cols.Count = 1로 변경
 *
 * 
 */
#endregion
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using System.Collections;
using System.Collections.Generic;
using Ax.DEV.Utility.Library;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Drawing.Drawing2D;

namespace Ax.DEV.Utility.Controls
{
    /// <summary>
    /// C1FlexGrid 클래스를 상속받아 구현된 그리드입니다.
    /// </summary>
    public class AxFlexGrid : C1FlexGrid, IAxControl
    {
        public const string FLAG_N = "N";
        public const string FLAG_U = "U";
        public const string FLAG_D = "D";

        private int _StartRowIndex;
        private int _StartColIndex;
        private int _ColumnCount;
        private bool _PopMenuVisible;
        private bool _EnabledActionFlag;
        private bool _LastRowAdd;
        private ContextMenuStrip _ContextPopMenu;
        private SaveFileDialog _SaveFileDialog;
        private AxFlexGridColumnDictionary _GridColumns;
        private C1.Win.C1Input.DropDownCalendar _DdCalendar = null;


        private bool _customMergeMode = false;

        //private Dictionary<int, string> _dateFormat = null;
        private AxFlexGridColumnDictionary _dateFormat;
        // Header Merge Option (기본값 : True)
        protected bool _allowHeaderMerging = false;

        #region Description: Event define

        /// <summary>
        /// 그리드 행 추가 이벤트 핸들러에 대한 대리자입니다.
        /// </summary>
        public delegate void FAlterRowInsertEventHandler(object sender, FAlterEventRow args);

        /// <summary>
        /// 그리드 행이 추가되기 전 실행되는 이벤트 핸들러입니다.
        /// </summary>
        public event FAlterRowInsertEventHandler RowInserting;

        /// <summary>
        /// 그리드 행이 추가된 후 실행되는 이벤트 핸들러입니다.
        /// </summary>
        public event FAlterRowInsertEventHandler RowInserted;

        /// <summary>
        /// 그리드 행이 삭제되기 전 실행되는 이벤트 핸들러입니다.
        /// </summary>
        public event FAlterRowInsertEventHandler RowDeleting;

        /// <summary>
        /// 그리드 행이 삭제된 후 실행되는 이벤트 핸들러입니다.
        /// </summary>
        public event FAlterRowInsertEventHandler RowDeleted;

        /// <summary>
        /// 그리드 행에 대한 작업을 취소한 후 발생되는 이벤트 핸들러입니다.
        /// </summary>
        public event FAlterRowInsertEventHandler RowCanceled;

        /// <summary>
        /// 그리드 행이 추가되기 전 실행되는 이벤트입니다.
        /// </summary>
        public void OnRowInserting(object sender, FAlterEventRow e)
        {
            if (this.RowInserting != null)
                this.RowInserting(sender, e);
        }

        /// <summary>
        /// 그리드 행이 추가된 후 실행되는 이벤트입니다.
        /// </summary>
        public void OnRowInserted(object sender, FAlterEventRow e)
        {
            if (this.RowInserted != null)
                this.RowInserted(sender, e);
        }

        /// <summary>
        /// 그리드 행이 삭제되기 전 실행되는 이벤트입니다.
        /// </summary>
        public void OnRowDeleting(object sender, FAlterEventRow e)
        {
            if (this.RowDeleting != null)
                this.RowDeleting(sender, e);
        }

        /// <summary>
        /// 그리드 행이 삭제된 후 실행되는 이벤트입니다.
        /// </summary>
        public void OnRowDeleted(object sender, FAlterEventRow e)
        {
            if (this.RowDeleted != null)
                this.RowDeleted(sender, e);
        }

        /// <summary>
        /// 그리드 행에 대한 작업을 취소한 후 발생되는 이벤트입니다.
        /// </summary>
        public void OnRowCanceled(object sender, FAlterEventRow e)
        {
            if (this.RowCanceled != null)
                this.RowCanceled(sender, e);
        }

        #endregion

        public AxFlexGrid()
            : base()
        {
            _StartRowIndex = 1;
            _StartColIndex = 1;
            _PopMenuVisible = true;
            _EnabledActionFlag = true;
            _LastRowAdd = false;
            _ColumnCount = 0;
            _GridColumns = new AxFlexGridColumnDictionary();
            //_dateFormat = new Dictionary<int, string>();
            _dateFormat = new AxFlexGridColumnDictionary();
            //is.FlexGrid_AfterEdit            
        }

        /// <summary>
        /// AutoSizeCols 가 전체 레코드를 대상으로 하므로 속도가 너무 느려서 최대 100로우만 보고 오토사이트 하도록 성능 개선함 -- 2019-08-24 김건우 수정
        /// </summary>
        public override void AutoSizeCols()
        {
            int row = this.Rows.Count - 1;
            base.AutoSizeCols(0, 0, (row >= 100 ? 100 : row), this.Cols.Count - 1, 10, C1.Win.C1FlexGrid.AutoSizeFlags.None);
        }

        public void SetLanguageCustomFormat()
        {
        }

        #region IHEControl 멤버

        /// <summary>
        /// 그리드 헤더부분에 병합기능 사용유무를 가져오거나 설정합니다.
        /// </summary>
        public bool AllowHeaderMerging
        {
            get { return _allowHeaderMerging; }
            set
            {
                _allowHeaderMerging = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 그리드에 바인딩 된 데이타소스를 반환합니다.
        /// </summary>
        public object GetValue()
        {
            return this.DataSource;
        }

        /// <summary>
        /// 그리드에 바인딩 할 데이타소스를 설정합니다.
        /// </summary>
        public void SetValue(object value)
        {
            this.SetValue((DataTable)value);
        }

        /// <summary>
        /// 그리드에 바인딩 할 데이타소스를 설정합니다.
        /// </summary>
        public void SetValue(DataSet value)
        {
            this.SetValue(value.Tables[0]);
        }

        /// <summary>
        /// 그리드에 바인딩 할 데이타소스를 설정합니다.
        /// </summary>
        public void SetValue(DataTable value)
        {
            _IsPainting = true;

            this.DataSource = value.Copy();
            this.Row = -1;

            if (this.Cols.Count != 0)
                _ColumnCount = this.Cols.Count - 1;

            this.Cols.Count = _ColumnCount + 1;

            for (int i = _StartRowIndex; i < this.Rows.Count; i++)
                this[i, 0] = i - this.Rows.Fixed + 1;

            _IsPainting = false;


            //국가별 날짜표시를 위해 DateTime 정보 표시
            AxFlexGrid grid = this;
            this.AfterSort -= new SortColEventHandler(HEFlexGrid_AfterSort);

            foreach (C1.Win.C1FlexGrid.Column col in grid.Cols)
            {
                if (col.DataType != null && col.DataType.Name.Equals("DateTime"))
                {
                    for (int i = grid.Rows.Fixed; i < grid.Rows.Count; i++)
                    {
                        if (grid.Cols[col.Name][i] != null && !string.IsNullOrEmpty(grid.Cols[col.Name][i].ToString()))
                        {
                            DateTime dt = new DateTime();
                            string strDate = string.Empty;
                            if (grid.Cols[col.Name].Format.Equals("dd-MM") ||
                                grid.Cols[col.Name].Format.Equals("dd/MM") ||
                                grid.Cols[col.Name].Format.Equals("d. M"))
                            {
                                string[] str = grid.Cols[col.Name][i].ToString().Split('-');
                                strDate = str[1] + "-" + str[0];

                                if (DateTime.TryParse(strDate, out dt))
                                    grid.Cols[col.Name][i] = DateTime.Parse(strDate).ToString(grid.Cols[col.Name].Format);
                            }
                            else
                            {
                                if (DateTime.TryParse(grid.Cols[col.Name][i].ToString(), out dt))
                                    grid.Cols[col.Name][i] = DateTime.Parse(grid.Cols[col.Name][i].ToString()).ToString(grid.Cols[col.Name].Format);
                                else
                                {
                                    grid.Cols[col.Name][i] = grid.Cols[col.Name][i].ToString();
                                }
                            }
                            //if (DateTime.TryParse(grid.Cols[col.Name][i].ToString(), out dt))
                            //    grid.Cols[col.Name][i] = DateTime.Parse(grid.Cols[col.Name][i].ToString()).ToString(grid.Cols[col.Name].Format);
                            this[i, 0] = i - grid.Rows.Fixed + 1;
                        }

                    }
                }
            }
            this.AfterSort += new SortColEventHandler(HEFlexGrid_AfterSort);
        }

        /// <summary>
        /// 그리드에 바인딩 할 데이타소스를 설정합니다.
        /// 순번 데이터가 자동으로 입력되어 적용유무 파라메타 추가 (2016.12.19 이재한)
        /// 그리드 설정에서 아래 소스 추가해서 정상동작 함.
        /// this.grd11.RemoveColumn(0);
        /// this.grd11.Cols.Fixed = 0;
        /// </summary>
        public void SetValue(DataTable value, bool no_yn)
        {
            _IsPainting = true;

            // 사용자 모드 병합 활성화 후 머지레인지 초기화 ( executeMerge 사용시에만 )
            if (this._customMergeMode)
            {
                this.BeginUpdate();

                for (int i = this.Rows.Count - 1; i >= this.Rows.Fixed; i--)
                {
                    for (int j = this.Cols.Count - 1; j >= this.Cols.Fixed; j--)
                    {
                        CellRange cr = this.GetMergedRange(i, j);
                        this.MergedRanges.Remove(cr);
                    }
                }

                this.EndUpdate();
            }

            this.DataSource = value.Copy();
            this.Row = -1;

            if (this.Cols.Count != 0)
                _ColumnCount = this.Cols.Count - 1;

            this.Cols.Count = _ColumnCount + 1;

            if (no_yn)
            {
                for (int i = _StartRowIndex; i < this.Rows.Count; i++)
                    this[i, 0] = i - this.Rows.Fixed + 1;
            }

            _IsPainting = false;


            //국가별 날짜표시를 위해 DateTime 정보 표시
            //HEFlexGrid grid = this;

            //this.AfterSort -= new SortColEventHandler(HEFlexGrid_AfterSort);

            //foreach (C1.Win.C1FlexGrid.Column col in grid.Cols)
            //{
            //    if (col.DataType != null && col.DataType.Name.Equals("DateTime"))
            //    {
            //        for (int i = grid.Rows.Fixed; i < grid.Rows.Count; i++)
            //        {
            //            if (grid.Cols[col.Name][i] != null && !string.IsNullOrEmpty(grid.Cols[col.Name][i].ToString()))
            //            {
            //                grid.Cols[col.Name][i] = DateTime.Parse(grid.Cols[col.Name][i].ToString()).ToString(grid.Cols[col.Name].Format);
            //                this[i, 0] = i;                            
            //            }

            //        }
            //    }
            //}
            //this.AfterSort += new SortColEventHandler(HEFlexGrid_AfterSort);
        }

        /// <summary>
        /// 지정된 FActionType 으로 데이타소스를 가공 후 반환합니다.
        /// </summary>
        public DataSet GetValue(FActionType type)
        {
            DataTable source = ((DataTable)this.GetValue()).Clone();
            string[] colName = new string[source.Columns.Count];
            for (int i = 0; i < source.Columns.Count; i++)
                colName[i] = source.Columns[i].ColumnName;

            return this.GetValue(type, colName);
        }

        /// <summary>
        /// 지정된 FActionType 과 파라메터로 받은 컬럼(들)명으로 데이타소스를 가공 후 반환합니다.
        /// </summary>
        public DataSet GetValue(FActionType type, params string[] parameters)
        {
            DataTable source_seq = new DataTable();
            source_seq.Columns.Add("GRIDSEQ", typeof(string));

            DataTable source = new DataTable(this.Name);
            for (int i = 0; i < parameters.Length; i++)
            {
                if (this.Cols[parameters[i]] != null)
                {
                    source.Columns.Add(parameters[i]);
                    if (this.Cols[parameters[i]].DataType != null)
                        source.Columns[parameters[i]].DataType = this.Cols[parameters[i]].DataType;
                    if (this.Cols[parameters[i]].DataType == typeof(DateTime))
                        source.Columns[parameters[i]].DataType = typeof(string);
                    if (this.Cols[parameters[i]].DataType == typeof(byte[]))
                        source.Columns[parameters[i]].DataType = typeof(byte[]);
                    if (this.Cols[parameters[i]].DataType == typeof(bool)) //bool 타입 가져올 시 Y/N 형태로 오기 때문에 강제로 bool을 string으로 전환
                        source.Columns[parameters[i]].DataType = typeof(string);
                    //2015-02-25 decimal을 string으로 변경
                    if (this.Cols[parameters[i]].DataType == typeof(decimal))
                        source.Columns[parameters[i]].DataType = typeof(string);
                }
            }

            int columnCount = source.Columns.Count;
            string flag = "";
            switch (type)
            {
                case FActionType.Save:
                    for (int i = _StartRowIndex; i < this.Rows.Count; i++)
                    {
                        flag = AxStaticCommon.Nvl(this[i, 0], "").ToString();
                        if (flag.Equals(FLAG_N) || flag.Equals(FLAG_U))
                        {
                            object[] column_values = new object[columnCount];
                            for (int j = 0; j < source.Columns.Count; j++)
                                //2015-02-25 int 및 decimal을의 값을 표준형식으로 변경
                                //column_values[j] = this.GetValue(i, source.Columns[j].ColumnName);
                                column_values[j] = this.GetDBValue(i, source.Columns[j].ColumnName);

                            source.Rows.Add(column_values);
                            source_seq.Rows.Add(i - this.Rows.Fixed + 1);
                        }
                    }
                    break;
                case FActionType.Remove:
                    for (int i = _StartRowIndex; i < this.Rows.Count; i++)
                    {
                        flag = AxStaticCommon.Nvl(this[i, 0], "").ToString();
                        if (flag.Equals(FLAG_D))
                        {
                            object[] column_values = new object[columnCount];
                            for (int j = 0; j < source.Columns.Count; j++)
                                //2015-02-25 int 및 decimal을의 값을 표준형식으로 변경
                                //column_values[j] = this.GetValue(i, source.Columns[j].ColumnName);
                                column_values[j] = this.GetDBValue(i, source.Columns[j].ColumnName);

                            source.Rows.Add(column_values);
                            source_seq.Rows.Add(i - this.Rows.Fixed + 1);
                        }
                    }
                    break;
                case FActionType.All:
                    for (int i = _StartRowIndex; i < this.Rows.Count; i++)
                    {
                        object[] column_values = new object[columnCount];
                        for (int j = 0; j < source.Columns.Count; j++)
                            //2015-02-25 int 및 decimal을의 값을 표준형식으로 변경
                            //column_values[j] = this.GetValue(i, source.Columns[j].ColumnName);
                            column_values[j] = this.GetDBValue(i, source.Columns[j].ColumnName);

                        source.Rows.Add(column_values);
                        source_seq.Rows.Add(i - this.Rows.Fixed + 1);
                    }
                    break;
            }

            for (int i = 0; i < parameters.Length; i++)
            {
                string name = parameters[i];
                bool column_exists = false;

                for (int j = 0; j < source.Columns.Count; j++)
                    if (name.Equals(source.Columns[j].ColumnName))
                    {
                        column_exists = true;
                        break;
                    }

                if (!column_exists)
                    source.Columns.Add(name);
            }

            DataSet set = new DataSet();
            set.Tables.Add(source);
            set.Tables.Add(source_seq);

            return set;
        }

        /// <summary>
        /// 그리드의 상태를 초기화합니다.
        /// 해당 메서드의 경우는 보통 UI_Shown(EventArgs) 에 위치하게 됩니다.
        /// </summary>
        public void Initialize()
        {
            int rowCount = 1;
            int rowFixed = 1;

            this.Initialize(rowCount, rowFixed, true);
        }

        /// <summary>
        /// 그리드의 상태를 초기화합니다.
        /// rowCount 는 초기 그리드에 설정되는 행의 수이고, rowFixed 는 그리드 헤더 행의 수입니다.
        /// </summary>
        public void Initialize(int rowCount, int rowFixed)
        {
            this.Initialize(rowCount, rowFixed, true);
        }

        /// <summary>
        /// 그리드의 상태를 초기화합니다.
        /// 자체적으로 지원하는 스타일의 적용유무에 대한 지정값을 인자로 받습니다.
        /// </summary>
        public void Initialize(bool style)
        {
            this.Initialize(1, 1, style);
        }

        /// <summary>
        /// 그리드의 상태를 초기화합니다.
        /// rowCount = 초기 행 수, rowFixed = 헤더 행 수, bool style = 스타일 적용유무
        /// </summary>
        public void Initialize(int rowCount, int rowFixed, bool style)
        {

            this.Rows.Count = rowCount;
            this.Rows.Fixed = rowFixed;

            //2015-04-20 Cols.Count의 Default Value = 10 이므로 초기화 시 1로 변경
            if (this.Cols.Count == 0)
                this.Cols.Count = 1;
            //this.Cols.Count = 1;

            this.Cols.Fixed = 1;
            this.ColumnInfo = "10,1,0,0,0,80,Columns:0{Width:25;}\t";

            for (int i = 0; i < this.Rows.Fixed; i++)
                this.Rows[i].Height = 30;


            this.VisualStyle = VisualStyle.Custom;
            this.AllowSorting = AllowSortingEnum.SingleColumn;
            this.AutoGenerateColumns = false;
            this.AutoClipboard = true;
            this.KeyActionEnter = KeyActionEnum.MoveAcross;
            this.KeyActionTab = KeyActionEnum.MoveAcross;
            this.SelectionMode = SelectionModeEnum.RowRange;
            this.DrawMode = DrawModeEnum.OwnerDraw;
            this.OwnerDrawCell += new OwnerDrawCellEventHandler(HEFlexGrid_OwnerDrawCell);

            this.Styles.Normal.Border.Color = Color.FromArgb(192, 202, 214);
            this.Styles.Fixed.BackColor = Color.FromArgb(240, 240, 240);
            this.Styles.Frozen.BackColor = Color.FromArgb(204, 255, 255);

            if (style)
                this.Styles.Alternate.BackColor = Color.FromArgb(244, 251, 255);

            //--사용자정의 하이라트 스타일 사용시 기존 하이라이트 스타일은 사용하지 않도록 함.
            if (_useCustomHightlight)
                this.HighLight = HighLightEnum.Never;
            else
                this.HighLight = HighLightEnum.Always;

            #region Description Sum row styles
            CellStyle cs1C = this.Styles.Add("SumLevel1C");
            cs1C.BackColor = Color.FromArgb(208, 253, 248);
            CellStyle cs1R = this.Styles.Add("SumLevel1R");
            cs1R.BackColor = Color.FromArgb(208, 253, 248);
            cs1R.ForeColor = Color.FromArgb(0, 0, 255);
            CellStyle cs2C = this.Styles.Add("SumLevel2C");
            cs2C.BackColor = Color.FromArgb(193, 238, 233);
            CellStyle cs2R = this.Styles.Add("SumLevel2R");
            cs2R.BackColor = Color.FromArgb(193, 238, 233);
            cs2R.ForeColor = Color.FromArgb(0, 0, 255);
            CellStyle cs3C = this.Styles.Add("SumLevel3C");
            cs3C.BackColor = Color.FromArgb(178, 223, 218);
            CellStyle cs3R = this.Styles.Add("SumLevel3R");
            cs3R.BackColor = Color.FromArgb(178, 223, 218);
            cs3R.ForeColor = Color.FromArgb(0, 0, 255);
            CellStyle cs4C = this.Styles.Add("SumLevel4C");
            cs4C.BackColor = Color.FromArgb(163, 208, 203);
            CellStyle cs4R = this.Styles.Add("SumLevel4R");
            cs4R.BackColor = Color.FromArgb(163, 208, 203);
            cs4R.ForeColor = Color.FromArgb(0, 0, 255);
            CellStyle cs5C = this.Styles.Add("SumLevel5C");
            cs5C.BackColor = Color.FromArgb(148, 193, 188);
            CellStyle cs5R = this.Styles.Add("SumLevel5R");
            cs5R.BackColor = Color.FromArgb(148, 193, 188);
            cs5R.ForeColor = Color.FromArgb(0, 0, 255);
            CellStyle cs6C = this.Styles.Add("SumLevel6C");
            cs6C.BackColor = Color.FromArgb(135, 178, 173);
            CellStyle cs6R = this.Styles.Add("SumLevel6R");
            cs6R.BackColor = Color.FromArgb(135, 178, 173);
            cs6R.ForeColor = Color.FromArgb(0, 0, 255);
            CellStyle cs7C = this.Styles.Add("SumLevel7C");
            cs7C.BackColor = Color.FromArgb(120, 163, 158);
            CellStyle cs7R = this.Styles.Add("SumLevel7R");
            cs7R.BackColor = Color.FromArgb(120, 163, 158);
            cs7R.ForeColor = Color.FromArgb(0, 0, 255);
            CellStyle cs8C = this.Styles.Add("SumLevel8C");
            cs8C.BackColor = Color.FromArgb(105, 148, 143);
            CellStyle cs8R = this.Styles.Add("SumLevel8R");
            cs8R.BackColor = Color.FromArgb(105, 148, 143);
            cs8R.ForeColor = Color.FromArgb(0, 0, 255);
            CellStyle csOR = this.Styles.Add("oddRow");
            csOR.BackColor = Color.FromArgb(255, 255, 255);
            CellStyle csER = this.Styles.Add("evenRow");
            csER.BackColor = Color.FromArgb(244, 251, 255);
            #endregion

            CellStyle s = this.Styles.Add("Selected");
            s.BackColor = Color.DarkOrchid;
            s.ForeColor = Color.White;
            //s.Font = new Font(this.Font, FontStyle.Bold);

            _SaveFileDialog = new SaveFileDialog();
            _ContextPopMenu = new ContextMenuStrip();
            _StartRowIndex = this.Rows.Fixed;
            _StartColIndex = this.Cols.Fixed;

            this.Cols[0].Width = 40;
            this.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            this.Cols[0].TextAlignFixed = TextAlignEnum.CenterCenter;

            if (!this.DesignMode)
                this.ConextMenuSetting();
        }

        #region  - 사용자 정의 highlight -

        private bool _useCustomHightlight = true;
        [Browsable(true)]
        public bool UseCustomHighlight
        {
            set
            {
                _useCustomHightlight = value;
                if (_useCustomHightlight)
                    this.HighLight = HighLightEnum.Never;
                else
                    this.HighLight = HighLightEnum.Always;
            }
            get { return _useCustomHightlight; }
        }

        SolidBrush mybrush = new SolidBrush(SystemColors.Highlight);
        SolidBrush mybrush2 = new SolidBrush(Color.FromArgb(192, 202, 214));//this.Styles.Normal.Border.Color 색상임

        private void HEFlexGrid_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            if (e.Row < this.Rows.Fixed || e.Col < this.Cols.Fixed)
                return;

            //기존 highlight 스타일 사용하는 경우. 기존 소스 그대로 적용.
            if (!_useCustomHightlight)
            {
                if (e.Row == this.Selection.r1 && e.Col == this.Selection.c1 && this.Styles.Contains("Selected"))
                    e.Style = this.Styles["Selected"];
                return;
            }

            //커스텀 Highlight 스타일 사용시.
            CellStyle cs = this.GetCellStyle(e.Row, e.Col);
            CellStyle csRow = this.Rows[e.Row].StyleDisplay;
            CellStyle csCol = this.Cols[e.Col].StyleDisplay;
            Color clr;
            if (cs != null) //그리드 해당셀에 설정된 배경색이 있는 경우.
            {
                clr = cs.BackColor;
                mybrush = new SolidBrush(Color.FromArgb(128, clr)); //해당 배경색 조금 연하게.
            }
            else if (csCol != null)
            {
                //Column 스타일 지정한 경우, 해당 스타일 색깔 연하게 표시.(row스타일보다 우선임.)
                clr = csCol.BackColor;
                mybrush = new SolidBrush(Color.FromArgb(128, clr));
            }
            else if (csRow != null)
            {
                //Row 스타일 지정한 경우, 해당 스타일 색깔 연하게 표시.
                clr = csRow.BackColor;
                mybrush = new SolidBrush(Color.FromArgb(128, clr));
            }
            else
            {
                //그외.. 스타일이 없으면 디폴트로 기존 highlight 스타일에 지정된 색 많이 연하게.
                clr = this.Styles.Highlight.BackColor;
                mybrush = new SolidBrush(Color.FromArgb(96, clr));
            }


            //해당 셀 배경색 입힐 영역 사각형.
            Rectangle rec = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Size.Width - 1, e.Bounds.Size.Height - 1);
            Rectangle rec2 = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Size.Width, e.Bounds.Size.Height);

            //해당셀이 선택된 영역에 포함되는 경우(selection), 해당 row 배경색 색칠해준다.(모드에 따라 색칠해줄 영역이 다름.)
            if (this.Styles.Contains("Selected"))
            {
                if ((this.SelectionMode == SelectionModeEnum.ListBox && this.Rows[e.Row].Selected)
                    || ((this.SelectionMode == SelectionModeEnum.Row || this.SelectionMode == SelectionModeEnum.RowRange) && e.Row >= this.Selection.r1 && e.Row <= this.Selection.r2)
                    || ((this.SelectionMode == SelectionModeEnum.Cell || this.SelectionMode == SelectionModeEnum.CellRange || this.SelectionMode == SelectionModeEnum.Default) && e.Row >= this.Selection.r1 && e.Row <= this.Selection.r2 && e.Col >= this.Selection.c1 && e.Col <= this.Selection.c2)
                    || ((this.SelectionMode == SelectionModeEnum.Column || this.SelectionMode == SelectionModeEnum.ColumnRange) && e.Col >= this.Selection.c1 && e.Col <= this.Selection.c2)
                    )
                {
                    if (e.Col == this.Selection.c1 && e.Row == this.Selection.r1)
                    {
                        e.Style = this.Styles["Selected"]; //포커스 있는 셀은 "Selected"스타일 적용함.
                    }
                    else
                    {
                        //그 외 셀

                        e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;
                        e.Graphics.FillRectangle(mybrush2, rec2);   //border
                        e.Graphics.FillRectangle(mybrush, rec);     //back color

                        e.DrawCell(DrawCellFlags.Content);
                        e.Handled = true;
                    }

                }
            }

        }

        #endregion

        #endregion


        /// <summary>
        /// 그리드에 선택된 영역의 r1 인덱스를 가져옵니다.
        /// </summary>
        public int SelectedRowIndex
        {
            get { return this.Selection.r1; }
        }

        /// <summary>
        /// 그리드의 현재 행으 수를 가져옵니다.    
        /// </summary>
        public int CurrentRowCount
        {
            get { return this.Rows.Count; }
        }

        /// <summary>
        /// 그리드에 지정된 컨텍스트 메뉴를 가져옵니다.
        /// </summary>
        public ContextMenuStrip CurrentContextMenu
        {
            get { return _ContextPopMenu; }
        }

        /// <summary>
        /// 그리드에 지정된 컨텍스트 메뉴의 숨김여부를 가져오거나 설정합니다.
        /// </summary>
        public bool PopMenuVisible
        {
            get { return _PopMenuVisible; }
            set { _PopMenuVisible = value; }
        }

        /// <summary>
        /// 그리드에 행추가, 삭제, 취소 등의 작업을 할 때 
        /// 해당 작업에 대한 액션의 실행여부를 가져오거나 설정합니다.
        /// </summary>
        public bool EnabledActionFlag
        {
            get { return _EnabledActionFlag; }
            set { _EnabledActionFlag = value; }
        }

        public bool LastRowAdd
        {
            get { return _LastRowAdd; }
            set { _LastRowAdd = value; }
        }

        /// <summary>
        /// 그리드의 헤더컬럼을 HEFlexGridColumnDictionary 타입으로 가져옵니다.
        /// </summary>
        public AxFlexGridColumnDictionary GridColumns
        {
            get { return _GridColumns; }
        }

        public AxFlexGridColumnDictionary DataFormat
        {
            get { return _dateFormat; }
        }

        /// <summary>
        /// 인수로 받은 컬럼명(들)을 기준으로 해서 신규 DataSet을 반환합니다.
        /// </summary>
        public static DataSet GetDataSourceSchema(params string[] parameters)
        {
            return AxStaticCommon.GetDataSourceSchema(parameters);
        }

        /// <summary>
        /// 그리드에 신규로 행을 추가합니다.
        /// 참고로 해당 행은 그리드의 맨 아래에 위치합니다.
        /// </summary>
        public void AddRow()
        {
            DataTable source = (DataTable)this.DataSource;
            source.Rows.Add(source.NewRow());
            this[source.Rows.Count, 0] = FLAG_N;
        }

        /// <summary>
        /// 그리드에서 선택된 행에 대한 정보를 DataRow 타입으로 반환합니다.
        /// </summary>
        public DataRow SelectedDataRow
        {
            get
            {
                ArrayList values = new ArrayList();
                DataTable source = new DataTable();
                for (int i = 1; i <= this.GridColumns.Count; i++)
                {
                    source.Columns.Add(this.GridColumns[i]);
                    values.Add(this[this.Row, this.GridColumns[i]]);
                }
                source.Rows.Add(values.ToArray());

                return source.Rows[0];
            }
        }

        /// <summary>
        /// 그리드에서 선택된 행에 대한 정보를 DataRow 타입으로 반환합니다.(다국어적용한 그리드인 경우)
        /// </summary>
        public DataRow SelectedDataRowMultiLang
        {
            get
            {
                ArrayList values = new ArrayList();
                DataTable source = new DataTable();
                for (int i = this.Cols.Fixed; i < this.Cols.Count; i++)
                {
                    source.Columns.Add(this.Cols[i].Name);
                    values.Add(this.GetValue(this.Row, this.Cols[i].Name));
                }
                source.Rows.Add(values.ToArray());

                return source.Rows[0];
            }
        }

        /// <summary>
        /// 그리드에 바인딩 된 데이타소스를 초기화합니다.
        /// </summary>
        public void InitializeDataSource()
        {
            //this.DataFormat.Clear();
            //this.GridColumns.Clear();
            DataTable source = new DataTable();
            for (int i = _StartColIndex; i < this.Cols.Count; i++)
            {
                if (!source.Columns.Contains(this.Cols[i].Name))
                {
                    source.Columns.Add(this.Cols[i].Name);
                    if (this.Cols[i].DataType == typeof(byte[]))
                        source.Columns[this.Cols[i].Name].DataType = typeof(byte[]);
                }
            }

            this.SetValue(source);
        }

        //★★####### 인사모듈 관련하여 추가한 형식(배명희) [2013-11-01] #######★★
        /// <summary>
        /// 그리드에 바인딩 된 데이타소스를 초기화합니다.
        /// DataType 반영하여 initialize함.
        /// </summary>
        public void InitializeDataSourceDataType()
        {
            DataTable source = new DataTable();
            for (int i = _StartColIndex; i < this.Cols.Count; i++)
            {
                source.Columns.Add(this.Cols[i].Name);
                if (this.Cols[i].DataType == typeof(byte[]))
                    source.Columns[this.Cols[i].Name].DataType = typeof(byte[]);
                // datetime 경우 포멧이 정상적으로 적용되지 않아 따로 타입 지정 (2014-10-01 배명희,이재한)
                else if (this.Cols[i].DataType == typeof(DateTime))
                {
                    source.Columns[this.Cols[i].Name].DataType = typeof(string);
                }
                else
                {
                    if (this.Cols[i].DataType != null)
                    {
                        source.Columns[this.Cols[i].Name].DataType = this.Cols[i].DataType;
                    }
                }
            }

            this.SetValue(source);
        }

        /// <summary>
        /// 인사에서 필요한 ContextMenu에 "전체행삭제","전체행취소" 기능 추가합니다.
        /// </summary>
        public void AddConextMenuSetting()
        {
            if (this.DesignMode) return;

            _IsPainting = true;

            //다국어 적용 2014-08-29
            //ToolStripMenuItem deleteAllItem = new ToolStripMenuItem("전체 행 삭제");
            //ToolStripMenuItem cancelAllItem = new ToolStripMenuItem("전체 행 취소");
            ToolStripMenuItem deleteAllItem = new ToolStripMenuItem(Ax.DEV.Utility.Resources.Default.ALL_ROW_DELETE);
            ToolStripMenuItem cancelAllItem = new ToolStripMenuItem(Ax.DEV.Utility.Resources.Default.ALL_ROW_CANCEL);

            deleteAllItem.Click += new EventHandler(DeleteAll_ToolStripMenuItem_Click);
            cancelAllItem.Click += new EventHandler(CancelAll_ToolStripMenuItem_Click);

            if (this.AllowEditing || !_PopMenuVisible)
            {
                _ContextPopMenu.Items.Insert(3, cancelAllItem);
                _ContextPopMenu.Items.Insert(3, deleteAllItem);
                _ContextPopMenu.Items.Insert(3, new ToolStripSeparator());


                _ContextPopMenu.Size = new Size(153, 165);
            }

            _IsPainting = false;
        }


        private void DeleteAll_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.Selection.r1 < 0) return;

                int index = this.Rows.Fixed; //this.Selection.r1;
                int count = this.Rows.Count - this.Rows.Fixed; //this.Selection.r2 - this.Selection.r1 + 1;

                if (index < _StartRowIndex) return;
                if (count < 1) count = 1;

                FAlterEventRow args = new FAlterEventRow(index, count);
                OnRowDeleting(this, args);

                //★★★##################### 인사 모듈 적용시 추가사항
                //취소true로 넘어온 경우 다음 로직 넘어가지 않도록함.( ..ed 이벤트 발생하지 않음)
                if (args.Cancel)
                    return;

                for (int i = count + index - 1; i >= index; i--)
                    if (this[i, 0].ToString().Equals(FLAG_N))
                        this.Rows.Remove(i);
                    else
                        this[i, 0] = FLAG_D;

                OnRowDeleted(this, args);
            }
            catch (Exception ex)
            {
            }
        }

        private void CancelAll_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (this.Selection.r1 < 0) return;

            int index = this.Rows.Fixed;
            int count = this.Rows.Count - this.Rows.Fixed;// this.Selection.r2 - this.Selection.r1 + 1;

            if (index < _StartRowIndex) return;
            if (count < 1) count = 1;

            for (int i = count + index - 1; i >= index; i--)
                switch (this[i, 0].ToString())
                {
                    case FLAG_N:
                        this.Rows.Remove(i);
                        break;
                    case FLAG_U:
                        ((DataTable)this.DataSource).Rows[i - _StartRowIndex].RejectChanges();
                        this[i, 0] = i - _StartRowIndex + 1;
                        break;
                    case FLAG_D:
                        this[i, 0] = i - _StartRowIndex + 1;
                        break;
                }

            OnRowCanceled(this, new FAlterEventRow(index, count));
        }


        //★★####### 인사모듈 관련하여 추가한 형식(배명희) [2013-11-01] #######★★

        private void ConextMenuSetting()
        {
            _IsPainting = true;
            this.AfterSort += new SortColEventHandler(HEFlexGrid_AfterSort);
            this.AfterEdit += new RowColEventHandler(this.FlexGrid_AfterEdit);
            this.CellChanged += new RowColEventHandler(this.FlexGrid_CellChanged);
            this.ChangeEdit += new System.EventHandler(this.FlexGrid_ChangeEdit);
            this.ValidateEdit += new ValidateEditEventHandler(HEFlexGrid_ValidateEdit);

            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FlexGrid_MouseClick);
            _SaveFileDialog.FileOk += new CancelEventHandler(FileDialog_FileOk);

            //다국어 적용 2014-08-29
            //ToolStripMenuItem insertItem = new ToolStripMenuItem("행 추가");
            //ToolStripMenuItem deleteItem = new ToolStripMenuItem("행 삭제");
            //ToolStripMenuItem cancelItem = new ToolStripMenuItem("행 취소");
            //ToolStripMenuItem excel_Item = new ToolStripMenuItem("엑셀 내보내기");
            //ToolStripMenuItem files_Item = new ToolStripMenuItem("엑셀 바로보기");
            ToolStripMenuItem insertItem = new ToolStripMenuItem(Ax.DEV.Utility.Resources.Default.ROW_ADD);
            ToolStripMenuItem deleteItem = new ToolStripMenuItem(Ax.DEV.Utility.Resources.Default.ROW_DELETE);
            ToolStripMenuItem cancelItem = new ToolStripMenuItem(Ax.DEV.Utility.Resources.Default.ROW_CANCEL);
            ToolStripMenuItem excel_Item = new ToolStripMenuItem(Ax.DEV.Utility.Resources.Default.EXCEL_EXPORT);
            ToolStripMenuItem files_Item = new ToolStripMenuItem(Ax.DEV.Utility.Resources.Default.EXCEL_OPEN);

            insertItem.Click += new EventHandler(Insert_ToolStripMenuItem_Click);
            deleteItem.Click += new EventHandler(Delete_ToolStripMenuItem_Click);
            cancelItem.Click += new EventHandler(Cancel_ToolStripMenuItem_Click);
            excel_Item.Click += new EventHandler(Excel_ToolStripMenuItem_Click);
            files_Item.Click += new EventHandler(File_ToolStripMenuItem_Click);

            if (this.AllowEditing || !_PopMenuVisible)
            {
                _ContextPopMenu.Items.AddRange(new ToolStripItem[] {
                    insertItem, deleteItem, cancelItem, new ToolStripSeparator(), excel_Item, files_Item});
                _ContextPopMenu.Size = new Size(153, 120);
            }
            else
            {
                _ContextPopMenu.Items.AddRange(new ToolStripItem[] { excel_Item, files_Item });
                _ContextPopMenu.Size = new Size(153, 120);
            }

            _IsPainting = false;
        }

        //2014-08-27
        //편집모드 들어갔다가 값 변경 않고 편집모드 종료하는 경우,
        //해당 셀의 DataSource에 "" 값이 반영되게 되는데,  기존값이 DBNull이었던 경우 
        //  CellChanged이벤트에 의해서 행번호컬럼에 "U"플래그가 찍히게 된다.
        //그래서 그런 경우에는 편집 취소가 적용되도록 함.(U로 변경되지 않도록)
        private void HEFlexGrid_ValidateEdit(object sender, ValidateEditEventArgs e)
        {
            if (this.Editor is TextBox)
            {
                if (this.Editor.Text.Length <= 0)
                {
                    DataRowView drv = (DataRowView)this.Rows[e.Row].DataSource;
                    if (drv.Row.ItemArray.Length > 0 && drv[this.Cols[e.Col].Name] == DBNull.Value)
                    {
                        this.FinishEditing(true);//Finishes editing current cell and takes the grid out of edit mode. (cancel the edits and revert the cell to its original value.)
                    }
                }
            }
            else if (this.Editor is ComboBox)
            {
                //2014-10-08(배명희)
                //this.ComboBoxEditor.SelectedItem가 null인 케이스 있어서 조건 추가함.
                //(콤보목록을 띄운 후, 값 선택하지 않고 다른 셀을 클릭하여 콤보상자를 닫히게 한경우에)
                if (this.ComboBoxEditor.SelectedItem != null && this.ComboBoxEditor.SelectedItem.ToString() == "")
                {
                    DataRowView drv = (DataRowView)this.Rows[e.Row].DataSource;
                    if (drv[this.Cols[e.Col].Name] == DBNull.Value)
                    {
                        this.FinishEditing(true);
                    }
                }
            }
        }

        //2014-08-27
        //그리드 소팅 후 "U"/"N" 플래그 다시 찍어주기.
        //소팅은 DataView기능, "U"/"N" 플래그는 그리드에 그려놓은 것
        //소팅한다고 자동으로 플래그가 같이 정렬되지 않음.
        private void HEFlexGrid_AfterSort(object sender, SortColEventArgs e)
        {
            if (this.AllowEditing)
            {
                for (int i = this.Rows.Fixed; i < this.Rows.Count; i++)
                {
                    DataRowView drv = ((DataRowView)this.Rows[i].DataSource);

                    if (drv.Row.RowState == DataRowState.Modified)
                        this[i, 0] = FLAG_U;
                    else if (drv.Row.RowState == DataRowState.Added)
                        this[i, 0] = FLAG_N;
                    else
                        this[i, 0] = i - _StartRowIndex + 1;

                }
            }
        }

        private void FlexGrid_AfterEdit(object sender, RowColEventArgs e)
        {
            if (this.RowSel < 0) return;
            int col = this.ColSel;
            if (this.Cols[col].DataType == typeof(DateTime))
            {
                string value = AxStaticCommon.Nvl(this[this.RowSel, col], "").ToString();
                if (value.Length == 0) return;


                System.Globalization.DateTimeFormatInfo format = System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat;
                //switch (this.Cols[col].Format)
                switch (this._dateFormat[col].ToString())
                {
                    //국가 포멧에 맞는 형태로 변경하는 로직 필요


                    //case "d":
                    //    DateTime dt = HEStaticCommon.GetFromDateTime(value);
                    //    this[this.RowSel, col] = dt.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern);                        
                    //    break;
                    case "yyyy-MM-dd":


                        this[this.RowSel, col] = DateTime.Parse(value).GetDateTimeFormats()[0]; //.ToString("yyyy-MM-dd"); //value.Substring(0, 10);
                        break;
                    case "yyyy-MM":
                        //Thread.CurrentThread.CurrentCulture.DateTimeFormat.YearMonthPattern = Thread.CurrentThread.CurrentCulture.DateTimeFormat.YearMonthPattern.Replace("MMMM", "M").Replace(" ", Thread.CurrentThread.CurrentCulture.DateTimeFormat.DateSeparator);
                        //this[this.RowSel, col] = DateTime.Parse(value).ToString(Thread.CurrentThread.CurrentCulture.DateTimeFormat.YearMonthPattern);
                        this[this.RowSel, col] = DateTime.Parse(value).ToString(format.ShortDatePattern.Replace("d.", "").Replace(".dd", "").Replace("dd.", "").Replace("-dd", "").Replace("dd-", "").Replace("/dd", "").Replace("dd/", "").Replace("/d", ""));
                        break;
                    case "dd/MM/yyyy":
                        DateTime dt0 = AxStaticCommon.GetFromDateTime(value);
                        this[this.RowSel, col] = dt0.ToString("dd/MM/yyyy");
                        break;
                    case "yyyy-MM-dd HH:mm":
                        DateTime dt1 = AxStaticCommon.GetFromDateTime(value);
                        this[this.RowSel, col] = dt1.ToString("yyyy-MM-dd HH:mm");
                        break;
                    case "dd/MM/yyyy HH/mm":
                        DateTime dt3 = AxStaticCommon.GetFromDateTime(value);
                        this[this.RowSel, col] = dt3.ToString("dd/MM/yyyy HH/mm");
                        break;
                    case "yyyy-MM-dd HH:mm:ss":
                        DateTime dt2 = AxStaticCommon.GetFromDateTime(value);
                        this[this.RowSel, col] = dt2.ToString("yyyy-MM-dd HH:mm:ss");
                        break;
                    case "dd/MM/yyyy HH/mm/ss":
                        DateTime dt4 = AxStaticCommon.GetFromDateTime(value);
                        this[this.RowSel, col] = dt4.ToString("dd/MM/yyyy HH/mm/ss");
                        break;
                    case "HH:mm":
                        DateTime dt5 = AxStaticCommon.GetFromDateTime(value);
                        this[this.RowSel, col] = dt5.ToString("HH:mm");
                        break;
                    case "HH/mm":
                        DateTime dt6 = AxStaticCommon.GetFromDateTime(value);
                        this[this.RowSel, col] = dt6.ToString("HH/mm");
                        break;

                    case "yyyy년 MM월": //★★####### 인사모듈 관련하여 추가한 형식(배명희) [2013-10-04] #######★★
                        DateTime dt7 = AxStaticCommon.GetFromDateTime(value);
                        this[this.RowSel, col] = dt7.ToString("yyyyMM");
                        break;
                    case "yyyy년 MM월 dd일": //★★####### 인사모듈 관련하여 추가한 형식(배명희) [2013-10-04] #######★★
                        DateTime dt8 = AxStaticCommon.GetFromDateTime(value);
                        this[this.RowSel, col] = dt8.ToString("yyyyMMdd");
                        break;
                    case "yyyy년": //★★####### 인사모듈 관련하여 추가한 형식(배명희) [2013-10-04] #######★★
                        DateTime dt9 = AxStaticCommon.GetFromDateTime(value);
                        this[this.RowSel, col] = dt9.ToString("yyyy");
                        break;
                    case "yyyyMMdd": //★★####### 인사모듈 관련하여 추가한 형식(배명희) [2013-10-10] #######★★
                        DateTime dt10 = AxStaticCommon.GetFromDateTime(value);
                        this[this.RowSel, col] = dt10.ToString("yyyyMMdd");
                        break;
                    case "yyyyMM": //★★####### 인사모듈 관련하여 추가한 형식(배명희) [2013-10-22] #######★★
                        DateTime dt11 = AxStaticCommon.GetFromDateTime(value);
                        this[this.RowSel, col] = dt11.ToString("yyyyMM");
                        break;
                    default:
                        DateTime dt = AxStaticCommon.GetFromDateTime(value);
                        this[this.RowSel, col] = dt.ToString(System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern);
                        break;
                }
            }
            if (this.Cols[col].Style.DataType == typeof(int) ||
                this.Cols[col].Style.DataType == typeof(decimal))
            {
                if (AxStaticCommon.Nvl(this[this.RowSel, col], "").ToString().Length == 0)
                    this[this.RowSel, col] = "0";
            }
        }

        private bool _IsPainting = false;
        private void FlexGrid_CellChanged(object sender, RowColEventArgs e)
        {
            if (!_EnabledActionFlag) return;

            if (e.Row >= _StartRowIndex && e.Col >= _StartColIndex && !_IsPainting)
                if (!AxStaticCommon.Nvl(this[e.Row, 0], "").ToString().Equals(FLAG_N) &&
                    !AxStaticCommon.Nvl(this[e.Row, 0], "").ToString().Equals(FLAG_D))
                    this[e.Row, 0] = FLAG_U;
        }

        private void FlexGrid_ChangeEdit(object sender, EventArgs e)
        {
            if (!_EnabledActionFlag) return;

            if (this.Row >= _StartRowIndex && this.Col >= _StartColIndex && !_IsPainting)
                if (!AxStaticCommon.Nvl(this[this.Row, 0], "").ToString().Equals(FLAG_N) &&
                    !AxStaticCommon.Nvl(this[this.Row, 0], "").ToString().Equals(FLAG_D))
                    this[this.Row, 0] = FLAG_U;
        }

        private void FlexGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int x = Control.MousePosition.X;
                int y = Control.MousePosition.Y;

                _ContextPopMenu.Show(x, y);
            }
        }

        private void Insert_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int index = this.Selection.r1;
            int count = this.Selection.r2 - this.Selection.r1 + 1;

            if (index < 0) index = _StartRowIndex;
            if (count < 1) count = 1;

            if (this.DataSource == null)
                this.InitializeDataSource();

            FAlterEventRow args = new FAlterEventRow(index, count);
            OnRowInserting(this, args);

            //★★★##################### 인사 모듈 적용시 추가사항
            //취소true로 넘어온 경우 다음 로직 넘어가지 않도록함.( ..ed 이벤트 발생하지 않음)
            if (args.Cancel)
                return;

            DataTable source = (DataTable)this.DataSource;
            for (int i = index; i < index + count; i++)
            {
                source.Rows.InsertAt(source.NewRow(), i - _StartRowIndex);

                //현재 소팅 처리중이 아닌 경우, 행추가하면서 바로 "N"표시 //2014-08-27
                if (this.SortColumn == null)
                {
                    this[i, 0] = FLAG_N;
                }
            }

            ////2014-08-27
            //현재 소팅 처리중인 경우 행추가만 완료하고, 전체 데이터 loop돌면서 "신규행"인 경우에 "N"표시
            //소팅 처리중인 경우 신규행 추가되는 순간 바로 정렬되어 행위치가 바뀜. 추가하려던 행이 아닌 다른곳에 신규행이 위치함.
            //그러므로, "N"표시가 신규행이 아니라 다른곳에 찍힘.
            if (this.SortColumn != null)
            {
                for (int i = this.Rows.Fixed; i < this.Rows.Count; i++)
                {
                    DataRowView drv = ((DataRowView)this.Rows[i].DataSource);
                    if (drv.Row.RowState == DataRowState.Added)
                        this[i, 0] = FLAG_N;

                }
            }
            OnRowInserted(this, args);

        }

        private void Delete_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Selection.r1 < 0) return;

                int index = this.Selection.r1;
                int count = this.Selection.r2 - this.Selection.r1 + 1;

                if (index < _StartRowIndex) return;
                if (count < 1) count = 1;

                FAlterEventRow args = new FAlterEventRow(index, count);
                OnRowDeleting(this, args);

                //★★★##################### 인사 모듈 적용시 추가사항
                //취소true로 넘어온 경우 다음 로직 넘어가지 않도록함.( ..ed 이벤트 발생하지 않음)
                if (args.Cancel)
                    return;

                for (int i = index + count - 1; i >= index; i--)
                    if (this[i, 0].ToString().Equals(FLAG_N))
                        this.Rows.Remove(i);
                    else
                        this[i, 0] = FLAG_D;

                OnRowDeleted(this, args);
            }
            catch (Exception ex)
            {
            }
        }

        private void Cancel_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Selection.r1 < 0) return;

            int index = this.Selection.r1;
            int count = this.Selection.r2 - this.Selection.r1 + 1;

            if (index < _StartRowIndex) return;
            if (count < 1) count = 1;

            for (int i = index + count - 1; i >= index; i--)
                switch (this[i, 0].ToString())
                {
                    case FLAG_N:
                        this.Rows.Remove(i);
                        break;
                    case FLAG_U:
                        ((DataTable)this.DataSource).Rows[i - _StartRowIndex].RejectChanges();
                        this[i, 0] = i - _StartRowIndex + 1;
                        break;
                    case FLAG_D:
                        this[i, 0] = i - _StartRowIndex + 1;
                        break;
                }

            OnRowCanceled(this, new FAlterEventRow(index, count));
        }

        private void Excel_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //다국어 적용 2014-08-29
            //_SaveFileDialog.Title = "엑셀 내보내기";
            _SaveFileDialog.Title = Ax.DEV.Utility.Resources.Default.EXCEL_EXPORT;
            _SaveFileDialog.OverwritePrompt = true;
            _SaveFileDialog.AddExtension = true;
            _SaveFileDialog.CheckPathExists = true;
            _SaveFileDialog.DefaultExt = "xlsx";                                        //기본 확장자 xlsx로 변경. 
            _SaveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*"; //기본 확장자 xlsx로 변경.
            _SaveFileDialog.ShowDialog();
        }

        private void File_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string temp_path = @"C:\Temp";
                if (!Directory.Exists(temp_path))
                    Directory.CreateDirectory(temp_path);

                string temp_file = String.Format(@"{0}\{1}.xlsx", temp_path, Guid.NewGuid().ToString());                                    //엑셀바로보기시  office 2007 포맷으로~!!
                FileFlags flags = FileFlags.IncludeFixedCells | FileFlags.AsDisplayed | FileFlags.IncludeMergedRanges | FileFlags.OpenXml;  //엑셀바로보기시  office 2007 포맷으로~!!

                this.SaveExcel(temp_file, flags);
                Thread.Sleep(2000);

                Process.Start(temp_file);
            }
            catch (Exception ex)
            {

            }
        }

        private void FileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string fileName1 = _SaveFileDialog.FileName;
            FileFlags flags;
            if (fileName1.ToUpper().EndsWith("XLS")) //확장자에 따라 옵션 다르게 함. 
                flags = FileFlags.IncludeFixedCells | FileFlags.AsDisplayed | FileFlags.IncludeMergedRanges;                        //office 2003 포맷
            else
                flags = FileFlags.IncludeFixedCells | FileFlags.AsDisplayed | FileFlags.IncludeMergedRanges | FileFlags.OpenXml;    //office 2007 포맷

            this.SaveExcel(fileName1, flags);

            //다국어 적용 2014-08-29
            //MessageBox.Show("스프레드 정보를 모두 엑셀 내보내었습니다.");
            MessageBox.Show(Ax.DEV.Utility.Resources.Default.MSG01);
        }

        /// <summary>
        /// 그리드에 인수로 넘겨진 컬럼명에 해당하는 숨겨진 컬럼을 추가합니다.
        /// </summary>
        public void AddHiddenColumn(string name)
        {
            this.AddColumn(true, false, FtextAlign.L, 0, "", name);
        }


        /// <summary>
        /// 그리드에 신규컬럼에 대한 정보를 추가합니다. 
        /// 해당 메서드는 대부분 UI_Shown(EventArgs) 메서드 안에서 사용됩니다.
        /// </summary>
        /// <param name="read">읽기 전용</param>
        /// <param name="visible">컬럼 표시</param>
        /// <param name="align">컬럼 정렬 방향</param>
        /// <param name="width">컬럼 넓이</param>
        /// <param name="caption">컬럼 명칭</param>
        /// <param name="name">컬럼ID</param>
        public void AddColumn(bool read, bool visible, FtextAlign align, int width, string caption, string name)
        {
            //Column column = this.Cols.Add();          
            //column.Caption = caption;
            //column.Name = name;            
            //column.Width = width;
            //column.Visible = visible;
            //column.AllowEditing = !read;
            //column.TextAlign = TextAlignEnum.LeftCenter;
            //column.TextAlignFixed = TextAlignEnum.CenterCenter;
            //switch (align)
            //{
            //    case FtextAlign.C: column.TextAlign = TextAlignEnum.CenterCenter; break;
            //    case FtextAlign.R: column.TextAlign = TextAlignEnum.RightCenter; break;
            //}
            //_ColumnCount++;
            //_GridColumns.Add(_ColumnCount, name);                

            AddColumnLang(read, visible, align, width, caption, name, "");
        }

        public void AddColumnLang(bool read, bool visible, FtextAlign align, int width, string caption, string name, string langCode)
        {
            Column column = this.Cols.Add();
            column.UserData = langCode;
            column.Caption = caption;
            column.Name = name;
            column.Width = width;
            column.Visible = visible;
            column.AllowEditing = !read;
            column.TextAlign = TextAlignEnum.LeftCenter;
            column.TextAlignFixed = TextAlignEnum.CenterCenter;
            switch (align)
            {
                case FtextAlign.C: column.TextAlign = TextAlignEnum.CenterCenter; break;
                case FtextAlign.R: column.TextAlign = TextAlignEnum.RightCenter; break;
            }

            _ColumnCount++;

            if (_GridColumns.ContainsKey(_ColumnCount)) _GridColumns.Remove(_ColumnCount);
            _GridColumns.Add(_ColumnCount, name);
            //_dateFormat = new AxFlexGridColumnDictionary();

            if (_dateFormat.ContainsKey(_ColumnCount)) _dateFormat.Remove(_ColumnCount);
            _dateFormat.Add(_ColumnCount, name);
        }

        //Ax.DEV.Utility.Libary.HEControlExtension으로 이동
        //public void AddColumn(bool read, bool visible, FtextAlign align, int width, string caption, string name, string langCodeName )
        //{

        //}


        /*
         * Grid 의 Cols 의 Count 를 0으로 설정하지 않으면 문제가 발생함
         * Cols 의 Index 값으로 HEFlexGridColumnDictionary 의 key 값을 찾을 방법이 없음
        */
        /// <summary>
        /// 그리드에 선택한 컬럼을 삭제합니다. (Cols.Count 의 값을 0으로 설정해야 사용 가능합니다)
        /// </summary>
        /// <param name="key">HEFlexGridColumnDictionary 의 Key, ColumnCollection 의 Index</param>
        public void RemoveColumn(int index)
        {
            _ColumnCount--;
            _GridColumns.Remove(index);
            _dateFormat.Remove(index);

            this.Cols.Remove(index);
        }

        /// <summary>
        /// 넘겨진 인수에 해당하는 영역에 대해 병합합니다.
        /// 해당 메서드는 병합할 컬럼에 대해 인덱스를 인수로 받습니다.
        /// </summary>
        public void AddMerge(int r1, int r2, int c1, int c2)
        {
            string cname1 = _GridColumns[c1];
            string cname2 = _GridColumns[c2];
            this.AddMerge(r1, r2, cname1, cname2);
        }

        /// <summary>
        /// 넘겨진 인수에 해당하는 영역에 대해 병합합니다.
        /// 해당 메서드는 병합할 컬럼에 대해 컬럼명을 인수로 받습니다.
        /// </summary>
        public void AddMerge(int r1, int r2, string c1_name, string c2_name)
        {
            if (this.AllowMerging != AllowMergingEnum.Custom)
            {
                this.AllowMerging = AllowMergingEnum.Custom;
                this.MergedRanges.Add(this.GetCellRange(0, 0, this.Rows.Fixed - 1, 0));
            }

            this.MergedRanges.Add(this.GetCellRange(r1, this.Cols[c1_name].Index, r2, this.Cols[c2_name].Index));
        }

        /// <summary>
        /// 그리드에 추가된 컬럼의 헤더명을 설정합니다.
        /// 해당 메서드는 보통 헤더 행이나 컬럼에 대해 병합 작업 후 사용하는 것이 일반적입니다.
        /// </summary>
        public void SetHeadTitle(int row, int col, string title)
        {
            string col_name = _GridColumns[col];
            this.SetHeadTitle(row, col_name, title);
        }

        /// <summary>
        /// 그리드에 추가된 컬럼의 헤더명을 설정합니다.
        /// 해당 메서드는 보통 헤더 행이나 컬럼에 대해 병합 작업 후 사용하는 것이 일반적입니다.
        /// </summary>
        public void SetHeadTitle(int row, string col_name, string title)
        {
            this[row, this.Cols[col_name].Index] = title;
        }

        /// <summary>
        /// 그리드에 추가된 컬럼의 헤더명을 설정합니다.
        /// 해당 메서드는 보통 헤더 행이나 컬럼에 대해 병합 작업 후 사용하는 것이 일반적입니다.
        /// </summary>
        public void SetHeadTitle(int r1, int r2, int c1, int c2, string title)
        {
            for (int r = r1; r <= r2; r++)
                for (int c = c1; c <= c2; c++)
                {
                    this.SetHeadTitle(r, _GridColumns[c], title);
                    this.Cols[c].AllowMerging = true;
                }
        }

        /// <summary>
        /// 그리드에 추가된 컬럼의 헤더명을 설정합니다.
        /// 해당 메서드는 보통 헤더 행이나 컬럼에 대해 병합 작업 후 사용하는 것이 일반적입니다.
        /// </summary>
        public void SetHeadTitle(int r1, int r2, string col_name1, string col_name2, string title)
        {
            for (int r = r1; r <= r2; r++)
                for (int c = this.Cols[col_name1].Index; c <= this.Cols[col_name2].Index; c++)
                {
                    this.SetHeadTitle(r, this.Cols[c].Name, title);
                    this.Cols[c].AllowMerging = true;
                }
        }

        /// <summary>
        /// 그리드에 설정된 컬럼에 대한 타입을 설정합니다.
        /// </summary>
        public void SetColumnType(FCellType type, string name)
        {
            this.SetColumnType(type, new DataTable(), name);
        }

        /// <summary>
        /// 그리드에 설정된 컬럼에 대한 타입을 설정합니다.
        /// 해당 메서드는 유형코드의 클래스ID로 컬럼을 바인딩하며, FCellType 이 ComboBox 가 대부분입니다.
        /// </summary>
        public void SetColumnType(FCellType type, string classID, string name)
        {
            DataTable source = AxStaticCommon.GetTypeCode(classID).Tables[0];
            this.SetColumnType(type, source, name);
        }

        /// <summary>
        /// 그리드에 설정된 컬럼에 대한 타입을 설정합니다.
        /// 해당 메서드는 유형코드의 클래스ID로 컬럼을 바인딩하며, FCellType 이 ComboBox 가 대부분입니다.
        /// </summary>
        public void SetColumnType(FCellType type, string classID, string name, string groupcd)
        {
            DataTable source = AxStaticCommon.GetTypeCode(classID).Tables[0];
            source.DefaultView.RowFilter = "GROUPCD='" + groupcd + "' ";
            this.SetColumnType(type, source.DefaultView.ToTable(), name);
        }


        /// <summary>
        /// 그리드에 설정된 컬럼에 대한 타입을 설정합니다.
        /// 해당 메서드는 유형코드의 클래스ID로 컬럼을 바인딩하며, FCellType 이 ComboBox 가 대부분입니다.
        /// 참고로 useCodeAndName 플래그를 true 로 설정할 경우 코드명은 '코드:코드명' 형태로 자동변환되어 나타납니다.
        /// </summary>
        public void SetColumnType(FCellType type, string classID, string name, bool useCodeAndName)
        {
            DataTable source = AxStaticCommon.GetTypeCode(classID).Tables[0];
            if (useCodeAndName)
                foreach (DataRow row in source.Rows)
                    row[1] = row[0].ToString().Substring(2) + ":" + row[1].ToString();
            this.SetColumnType(type, source, name);
        }

        /// <summary>
        /// 그리드에 설정된 컬럼에 대한 타입을 설정합니다.
        /// </summary>
        public void SetColumnType(FCellType type, DataTable source, string name, bool useCodeAndName)
        {
            this.SetColumnType(type, source, name, useCodeAndName, true);
        }

        /// <summary>
        /// 그리드에 설정된 컬럼에 대한 타입을 설정합니다.
        /// </summary>
        public void SetColumnType(FCellType type, DataTable source, string name, bool useCodeAndName, bool isTypeCode)
        {
            if (useCodeAndName)
            {
                DataTable source_copy = source.Copy();
                foreach (DataRow row in source_copy.Rows)
                    if (isTypeCode)
                        row[1] = row[0].ToString().Substring(2) + ":" + row[1].ToString();
                    else
                        row[1] = row[0].ToString() + ":" + row[1].ToString();
                this.SetColumnType(type, source_copy, name);
                return;
            }

            this.SetColumnType(type, source, name);
        }



        /// <summary>
        /// 그리드에 설정된 컬럼에 대한 타입을 설정합니다.
        /// </summary>
        /// 
        public void SetColumnType_Original(FCellType type, DataTable source, string name, bool isempty)
        {
            TextAlignEnum beforTextAlign = this.Cols[name].TextAlign;

            switch (type)
            {
                case FCellType.ComboBox:
                    DataTable source_copy = source.Copy();
                    Dictionary<string, string> combomap = new Dictionary<string, string>();
                    if (isempty)
                        source_copy.Rows.InsertAt(source_copy.NewRow(), 0);
                    for (int i = 0; i < source_copy.Rows.Count; i++)
                        combomap.Add(source_copy.Rows[i][0].ToString(), source_copy.Rows[i][1].ToString());
                    this.Cols[name].DataMap = combomap;
                    this.Cols[name].TextAlign = this.Cols[name].TextAlign;
                    break;
                case FCellType.Check:
                    this.Cols[name].DataType = typeof(bool);
                    this.Cols[name].ImageAlign = ImageAlignEnum.CenterCenter;
                    break;
                case FCellType.Date:
                    string srcFormat = this.Cols[name].Format;
                    if (string.IsNullOrEmpty(srcFormat)) srcFormat = "yyyy-MM-dd";

                    this.Cols[name].DataType = typeof(DateTime);
                    //this.Cols[name].Format = StaticHeUserInfoContext.Language.Equals("KO") ? "yyyy-MM-dd" : "dd/MM/yyyy";                    
                    //this.Cols[name].Format = srcFormat;
                    System.Globalization.DateTimeFormatInfo format = System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat;

                    switch (srcFormat)
                    {
                        case "yyyy-MM-dd":
                            this._dateFormat[this.Cols[name].Index] = srcFormat;
                            this.Cols[name].Format = format.ShortDatePattern;
                            break;
                        case "yyyy-MM":
                            this._dateFormat[this.Cols[name].Index] = srcFormat;
                            this.Cols[name].Format = format.ShortDatePattern.Replace("d.", "").Replace(".dd", "").Replace("dd.", "").Replace("-dd", "").Replace("dd-", "").Replace("/dd", "").Replace("dd/", "").Replace("d/", ""); //format.ShortDatePattern.Replace("d.", "").Replace(".dd", "").Replace("dd.", "").Replace("-dd", "").Replace("dd-", "").Replace("/dd", "").Replace("dd/", "");
                            break;
                        case "MM-dd":
                            this._dateFormat[this.Cols[name].Index] = srcFormat;
                            this.Cols[name].Format = format.ShortDatePattern.Replace(". yyyy", "").Replace(".yyyy", "").Replace("yyyy.", "").Replace("-yyyy", "").Replace("yyyy-", "").Replace("/yyyy", "").Replace("yyyy/", "");
                            if (StaticUserInfoContext.Language.Equals("PL"))
                            {
                                this.Cols[name].Format = "dd-MM";
                            }
                            //else if (!StaticHeUserInfoContext.Language.Equals("KO") || !StaticHeUserInfoContext.Language.Equals("ZH") || !StaticHeUserInfoContext.Language.Equals("EN"))
                            //{
                            //    this.Cols[name].Format = "dd-MM";
                            //}
                            else
                            {
                                this.Cols[name].Format = format.ShortDatePattern.Replace(". yyyy", "").Replace(".yyyy", "").Replace("yyyy.", "").Replace("-yyyy", "").Replace("yyyy-", "").Replace("/yyyy", "").Replace("yyyy/", "");
                            }

                            break;
                        case "yyyy-MM-dd HH:mm:ss":
                            this.Cols[name].Format = format.ShortDatePattern + " " + format.ShortTimePattern;
                            //this.Cols[name].Format = srcFormat; //화면에서 설정한대로 포맷을 주도록 함. 2017-10-10 (관련화면 : PD20320)
                            this._dateFormat[this.Cols[name].Index] = this.Cols[name].Format;
                            break;
                        case "yyyy-MM-dd HH:mm":
                            this.Cols[name].Format = format.ShortDatePattern + " " + format.ShortTimePattern;
                            this._dateFormat[this.Cols[name].Index] = this.Cols[name].Format;
                            break;
                        case "yyyy-MM-dd HH":
                            this.Cols[name].Format = format.ShortDatePattern + " " + format.ShortTimePattern;
                            this._dateFormat[this.Cols[name].Index] = this.Cols[name].Format;
                            break;
                        default:
                            this.Cols[name].Format = format.ShortDatePattern;
                            this._dateFormat[this.Cols[name].Index] = this.Cols[name].Format;
                            break;
                    }

                    this.Cols[name].ImageAlign = ImageAlignEnum.CenterCenter;
                    this.Cols[name].Editor = _DdCalendar;


                    //if (StaticHeUserInfoContext.Language.Equals("EN"))
                    //    if (this.Cols[name].DataType == typeof(DateTime))
                    //    {
                    //        switch (this.Cols[name].Format.ToUpper())
                    //        {
                    //            case "YYYY-MM":
                    //                this.Cols[name].Format = "MM/yyyy";
                    //                break;
                    //            case "YYYY-MM-DD HH:MM":
                    //                this.Cols[name].Format = "dd/MM/yyyy HH/mm";
                    //                break;
                    //            case "YYYY-MM-DD HH:MM:SS":
                    //                this.Cols[name].Format = "dd/MM/yyyy HH/mm/ss";
                    //                break;
                    //            case "HH:MM":
                    //                this.Cols[name].Format = "HH/mm";
                    //                break;
                    //            default:
                    //                this.Cols[name].Format = "dd/MM/yyyy";
                    //                break;
                    //        }
                    //    }
                    break;
                case FCellType.Int:
                    this.Cols[name].DataType = typeof(decimal);
                    this.Cols[name].Format = "###,###,###,###,###,###,###,###,###";
                    this.Cols[name].TextAlign = TextAlignEnum.RightCenter;

                    //if (StaticHeUserInfoContext.Language.Equals("EN"))
                    //    this.Cols[name].Format = "###.###.###.###.###.###.###.###.###";
                    break;
                case FCellType.Decimal:
                    this.Cols[name].DataType = typeof(decimal);
                    this.Cols[name].Format = "###,###,###,###,###,###,###,###.###";
                    this.Cols[name].TextAlign = TextAlignEnum.RightCenter;
                    //if (StaticHeUserInfoContext.Language.Equals("EN"))
                    //    this.Cols[name].Format = "###.###.###.###.###.###.###.###.###";
                    break;
                default:
                    this.Cols[name].DataType = typeof(string);
                    break;

            }
            this.Cols[name].TextAlign = beforTextAlign;
        }


        private Dictionary<int, string> _originalFormat = new Dictionary<int, string>();
        public IDictionary<int, string> OriginalFormat
        {
            get;
            set;
        }

        /// <summary>
        /// 그리드에 설정된 컬럼에 대한 타입을 설정합니다.
        /// </summary>
        public void SetColumnType(FCellType type, DataTable source, string name)
        {
            this.SetColumnType_Original(type, source, name, true);
        }

        /// <summary>
        /// 인수로 넘겨진 행의 인덱스와 컬럼명에 해당하는 셀의 값을 가져옵니다.
        /// </summary>
        public object GetValue(int row, string name)
        {
            int col = this.Cols[name].Index;
            return this.GetValue(row, col);
        }

        /// <summary>
        /// 인수로 넘겨진 행의 인덱스와 컬럼의 인덱스에 해당하는 셀의 값을 가져옵니다.
        /// </summary>
        public object GetValue(int row, int col)
        {
            if (col < 0) return null;

            object value = AxStaticCommon.Nvl(this.GetData(row, col), "");
            if (this.Cols[col].Style.DataType == typeof(bool))
                value = (value.ToString().ToUpper().Equals("TRUE") ||
                         value.ToString().ToUpper().Equals("1")) ? "Y" : "N";

            if (this.Cols[col].Style.DataType == typeof(DateTime))
                //switch (this.Cols[col].Style.Format)
                if (!(value == null || string.IsNullOrEmpty(value.ToString())))
                {
                    switch (this._dateFormat[col].ToString())
                    {
                        case "yyyy-MM-dd":

                            DateTime dt = AxStaticCommon.GetFromDateTime(value);
                            value = dt.ToString("yyyy-MM-dd");

                            //value = value.ToString().Replace("--", "");

                            //if (value.ToString().Length > 10)
                            //    value = value.ToString().Substring(0, 10);

                            //switch (value.ToString().Length)
                            //{
                            //    case 10:
                            //        value = value.ToString().Substring(0, 10);
                            //        break;
                            //    case 08:
                            //        value = String.Format("{0}-{1}-{2}",
                            //            value.ToString().Substring(0, 4),
                            //            value.ToString().Substring(4, 2),
                            //            value.ToString().Substring(6, 2));
                            //        break;
                            //    default:
                            //        value = "";
                            //        break;
                            //}
                            break;
                        case "yyyy-MM":
                            DateTime dt00 = AxStaticCommon.GetFromDateTime(value);
                            value = dt00.ToString("yyyy-MM");
                            break;
                        case "dd/MM/yyyy":
                            value = value.ToString().Replace("//", "");

                            DateTime dt0 = AxStaticCommon.GetFromDateTime(value);
                            value = dt0.ToString("yyyy-MM-dd");
                            break;
                        case "yyyy-MM-dd HH:mm:ss":
                            value = value.ToString().Replace("-", "").Replace(" ", "").Replace(":", "");
                            break;
                        case "dd/MM/yyyy HH/mm/ss":
                            DateTime dt1 = AxStaticCommon.GetFromDateTime(value);
                            value = dt1.ToString("yyyyMMddHHmmss");
                            break;
                        case "yyyy-MM-dd HH:mm":
                            value = value.ToString().Replace("-", "").Replace(" ", "").Replace(":", "");
                            break;
                        case "dd/MM/yyyy HH/mm":
                            DateTime dt2 = AxStaticCommon.GetFromDateTime(value);
                            value = dt2.ToString("yyyyMMddHHmm");
                            break;
                        case "HH:mm:ss":
                            value = value.ToString().Replace(":", "");
                            break;
                        case "HH:mm":
                            value = value.ToString().Replace(":", "");
                            break;
                        case "HH/mm/ss":
                            value = value.ToString().Replace("/", "");
                            break;
                        case "HH/mm":
                            value = value.ToString().Replace("/", "");
                            break;
                        case "yyyy년 MM월": //★★####### 인사모듈 관련하여 추가한 형식(배명희) [2013-10-04] #######★★
                            string yyyymm = value.ToString().Replace(" ", "").Replace("년", "").Replace("월", "").Replace("-", "").Substring(0, 6);
                            value = yyyymm.Substring(0, 4) + "-" + yyyymm.Substring(4, 2);
                            break;
                        case "yyyy년 MM월 dd일": //★★####### 인사모듈 관련하여 추가한 형식(배명희) [2013-10-04] #######★★
                            string yyyymmdd = value.ToString().Replace(" ", "-").Replace("년", "").Replace("월", "").Replace("일", "").Replace("-", "").Substring(0, 8);
                            value = yyyymmdd.Substring(0, 4) + "-" + yyyymmdd.Substring(4, 2) + "-" + yyyymmdd.Substring(6, 2);
                            break;
                        case "yyyy년": //★★####### 인사모듈 관련하여 추가한 형식(배명희) [2013-10-04] #######★★
                            string yyyy = value.ToString().Replace(" ", "").Replace("년", "").Substring(0, 4);
                            value = yyyy;
                            break;
                        case "yyyyMMdd": //★★####### 인사모듈 관련하여 추가한 형식(배명희) [2013-10-10] #######★★
                            value = value.ToString().Replace("-", "").Length >= 8 ? value.ToString().Replace("-", "").Substring(0, 8) : value.ToString().Replace("-", "");
                            break;
                        case "yyyyMM": //★★####### 인사모듈 관련하여 추가한 형식(배명희) [2013-10-22] #######★★
                            value = value.ToString().Replace("-", "").Length >= 6 ? value.ToString().Replace("-", "").Substring(0, 6) : value.ToString().Replace("-", "");
                            break;
                    }
                }

            if (this.Cols[col].Style.DataType == typeof(int) ||
                this.Cols[col].Style.DataType == typeof(decimal))
            {
                if (value.ToString().Length == 0) value = "0";
                else
                {
                    //value = value.ToString().Replace(",", "");
                    //System.Globalization.NumberFormatInfo format = System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat;                    
                    //value = value.ToString().Replace(format.NumberGroupSeparator,"").Replace(format.NumberDecimalSeparator,".");
                }
            }

            return value;
        }

        public object GetDBValue(int row, string name)
        {
            int col = this.Cols[name].Index;
            return this.GetDBValue(row, col);
        }

        /// <summary>
        /// Date타입
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public object GetDBValue(int row, int col)
        {
            object value = this.GetValue(row, col);

            if (this.Cols[col].Style.DataType == typeof(int) ||
                this.Cols[col].Style.DataType == typeof(decimal))
            {
                System.Globalization.NumberFormatInfo format = System.Threading.Thread.CurrentThread.CurrentUICulture.NumberFormat;
                value = value.ToString().Replace(format.NumberGroupSeparator, "").Replace(format.NumberDecimalSeparator, ".");
            }

            //test중...2018-03-28 bmh (pd30010화면참고) 편집가능 그리드에서 날짜 입력후, 저장하기 위해 GetValue하면 MM/dd/yyyy형태의 데이터가 yyyy-MM-dd형태로 return 되도록 하기 위해.
            if (this.Cols[col].Style.DataType == typeof(DateTime))
            {
                DateTime dt0 = AxStaticCommon.GetFromDateTime(value);
                string strFormat = "yyyy-MM-dd";

                if (_dateFormat[col].IndexOf("ss") >= 0)
                    strFormat += " HH:mm:ss";
                else if (_dateFormat[col].IndexOf("mm") >= 0)
                    strFormat += " HH:mm";

                if (!String.IsNullOrEmpty(value.ToString()))
                    value = DateTime.Parse(value.ToString()).ToString(strFormat);
            }

            return value;
        }
        /// <summary>
        /// 인수로 넘겨진 행의 인덱스와 컬럼명에 해당하는 셀의 텍스터를 가져옵니다.
        /// </summary>
        public string GetText(int row, string name)
        {
            string code = this.GetValue(row, name).ToString();
            if (this.Cols[name].DataMap != null)
                return ((Dictionary<string, string>)this.Cols[name].DataMap)[code];

            return "";
        }

        /// <summary>
        /// 행의 인덱스와 컬럼명에 해당하는 셀에 인수로 넘겨진 값을 설정합니다.
        /// </summary>
        public void SetValue(int row, string name, object value)
        {
            this.SetData(row, name, value);
        }

        /// <summary>
        /// 행의 인덱스와 컬럼의 인덱스에 해당하는 셀에 인수로 넘겨진 값을 설정합니다.
        /// </summary>
        public void SetValue(int row, int col, object value)
        {
            this.SetData(row, col, value);
        }

        /// <summary>
        /// FlexGrid Cell의 텍스트 정렬을 나타내는 정의 타입입니다.
        /// </summary>
        public enum FtextAlign { L, C, R }

        /// <summary>
        /// FlexGrid의 행추가 및 삭제에 대한 이벤트 인자입니다.
        /// </summary>
        public class FAlterEventRow : EventArgs
        {
            private int _RowIndex;
            private int _RowCount;
            private bool _Checked;
            private bool _Cancel;

            /// <summary>
            /// 이벤트 발생 취소
            /// </summary>
            public bool Cancel
            {
                get { return _Cancel; }
                set { _Cancel = value; }

            }

            /// <summary>
            /// 이벤트가 발생된 행의 인덱스를 가져옵니다.
            /// </summary>
            public int RowIndex
            {
                get { return _RowIndex; }
            }

            /// <summary>
            /// 이벤트가 발생되어 영향받은 행의 개수를 가져옵니다.
            /// </summary>
            public int RowCount
            {
                get { return _RowCount; }
            }

            /// <summary>
            /// 이벤트가 발생된 행의 체크유무를 가져옵니다.
            /// </summary>
            public bool Checked
            {
                get { return _Checked; }
                set { _Checked = value; }
            }

            public FAlterEventRow(int rowIndex, int rowCount)
            {
                _RowIndex = rowIndex;
                _RowCount = rowCount;
                _Checked = true;
                _Cancel = false;
            }
        }

        /// <summary>
        /// FlexGrid의 행추가 및 삭제에 대한 정의 타입니다.
        /// </summary>
        public enum FActionType { Save, Remove, All }

        /// <summary>
        /// FlexGrid의 Cell Type에 대한 정의입니다.
        /// </summary>
        public enum FCellType { ComboBox, Check, Date, Int, Decimal }

        /// <summary>
        /// FlexGrid의 합계서식 적용에 대한 정의입니다.
        /// </summary>
        public enum eSumStyle { RowColMode, RowOnlyMode, ColOnlyMode };

        /// <summary>
        /// 합계 행의 서식을 설정합니다.
        /// </summary>
        public void setSumStyle(int iSumLevel, int iMergeTo)
        {
            setSumStyle(iSumLevel, iMergeTo, eSumStyle.RowColMode, null);
        }

        /// <summary>
        /// 합계 행의 서식을 설정합니다.
        /// </summary>
        public void setSumStyle(int iSumLevel, int iMergeTo, eSumStyle sumStyle)
        {
            setSumStyle(iSumLevel, iMergeTo, sumStyle, null);
        }

        /// <summary>
        /// 합계 행의 서식을 설정합니다.
        /// </summary>
        public void setSumStyle(int iSumLevel, int iMergeTo, eSumStyle sumStyle, string[] exSumLable)
        {
            if (this.Rows.Count == this.Rows.Fixed)
                return;

            this.AllowMerging = AllowMergingEnum.Custom;
            int iColsLength = iSumLevel - 1;
            //다국어 적용
            //string[] sSumLable = { "계", "소계", "중계", "합계", "총계" };
            //Sum, Sub Tatal, Mid Total, Total, Grand Total
            string[] sSumLable = { "Sum", "Sub Total", "Mid Total", "Total", "Grand Total" };
            //string[] sSumLable = { Resources.Default.SUM, Resources.Default.SUBTOTAL, Resources.Default.INTERMEDIATE_TOTAL, Resources.Default.TOTAL, Resources.Default.GRAND_TOTAL };
            String[] preTitle = new String[sumStyle == eSumStyle.ColOnlyMode ? iSumLevel : iColsLength];
            int[] prePos = new int[sumStyle == eSumStyle.ColOnlyMode ? iSumLevel : iColsLength];

            if (exSumLable != null && exSumLable.Length > 1)
            {
                sSumLable = exSumLable;
            }

            this.AllowMerging = AllowMergingEnum.Custom;
            for (int i = this.Cols.Fixed; i < this.Cols.Count; i++)
            {
                this.Cols[i].AllowMerging = true;
            }
            for (int i = this.Rows.Fixed; i < this.Rows.Count; i++)
            {
                this.Rows[i].AllowMerging = true;
            }

            for (int i = 0; i < preTitle.Length; i++)
            {
                preTitle[i] = this.GetData(this.Rows.Fixed, i + this.Cols.Fixed).ToString();
                prePos[i] = this.Rows.Fixed;
            }

            CellRange cr = new CellRange();
            bool isCategorized = false;

            for (int i = this.Rows.Fixed; i < this.Rows.Count; i++)
            {
                this.Rows[i].AllowMerging = true;

                if (sumStyle == eSumStyle.RowColMode || sumStyle == eSumStyle.ColOnlyMode)
                {
                    for (int j = 0; j < preTitle.Length; j++)
                    {
                        if (preTitle[j] != this.GetData(i, j + this.Cols.Fixed).ToString())
                        {
                            isCategorized = false;
                            cr = this.GetCellRange(prePos[j], j + this.Cols.Fixed, i - 1, j + this.Cols.Fixed);

                            for (int k = 0; k < iSumLevel; k++)
                            {
                                if (preTitle[j].Equals(sSumLable[k]))
                                {
                                    isCategorized = true;
                                    this.Cols[k].TextAlign = TextAlignEnum.LeftCenter; //합계머지 부분은 left정렬
                                    break;
                                }
                            }
                            if (!isCategorized)
                            {
                                cr.Style = this.Styles["SumLevel" + (iSumLevel - (j + this.Cols.Fixed) + (sumStyle == eSumStyle.ColOnlyMode ? 1 : 0)).ToString() + "C"];
                            }

                            this.MergedRanges.Add(cr);
                            preTitle[j] = this.GetData(i, j + this.Cols.Fixed).ToString();
                            prePos[j] = i;
                        }
                    }
                }

                if (sumStyle == eSumStyle.RowColMode)
                {
                    for (int k = 0; k < iSumLevel; k++)
                    {
                        if (this.GetData(i, iSumLevel - (k + 1) + this.Cols.Fixed).ToString().Equals(sSumLable[k]))
                        {
                            cr = this.GetCellRange(i, iSumLevel - (k + 1) + this.Cols.Fixed, i, this.Cols.Count - this.Cols.Fixed);
                            cr.Style = this.Styles["SumLevel" + (k + 1).ToString() + "R"];
                            this.AddMerge(i, i, iSumLevel - (k + 1) + this.Cols.Fixed, iMergeTo);
                            break;
                        }
                    }
                }
                else if (sumStyle == eSumStyle.RowOnlyMode)
                {
                    for (int k = 0; k < iSumLevel; k++)
                    {
                        if (this.GetData(i, iSumLevel - (k + 1) + this.Cols.Fixed).ToString().Equals(sSumLable[k]))
                        {
                            cr = this.GetCellRange(i, this.Cols.Fixed, i, this.Cols.Count - this.Cols.Fixed);
                            cr.Style = this.Styles["SumLevel" + (k + 1).ToString() + "R"];
                            break;
                        }
                    }
                }
            }

            if (sumStyle == eSumStyle.ColOnlyMode)
            {
                for (int j = 0; j < preTitle.Length; j++)
                {
                    cr = this.GetCellRange(prePos[j], j + this.Cols.Fixed, this.Rows.Count - this.Rows.Fixed, j + this.Cols.Fixed);
                    cr.Style = this.Styles["SumLevel" + (iSumLevel - (j + this.Cols.Fixed) + (sumStyle == eSumStyle.ColOnlyMode ? 1 : 0)).ToString() + "C"];
                    this.MergedRanges.Add(cr);
                }
            }
        }

        /// <summary>
        /// 수정되는 행의 스타일을 지정합니다.
        /// </summary>
        public void setAlternateRowStyle(int iColIndex)
        {
            if (this.Rows.Count == this.Rows.Fixed)
                return;

            String preTitle = (this.GetData(this.Rows.Fixed, iColIndex) != null ? this.GetData(this.Rows.Fixed, iColIndex).ToString() : "");
            int prePos = (this.Rows.Fixed > this.Rows.Frozen ? this.Rows.Fixed : this.Rows.Frozen);
            bool isEvenRow = false;

            CellRange cr = new CellRange();

            for (int i = prePos; i < this.Rows.Count; i++)
            {
                if (preTitle != (this.GetData(i, iColIndex) != null ? this.GetData(i, iColIndex).ToString() : ""))
                {
                    cr = this.GetCellRange(prePos, this.Cols.Fixed, i - 1, this.Cols.Count - this.Cols.Fixed);
                    if (isEvenRow)
                    {
                        cr.Style = this.Styles["evenRow"];
                    }
                    else
                    {
                        cr.Style = this.Styles["oddRow"];
                    }
                    preTitle = (this.GetData(i, iColIndex) != null ? this.GetData(i, iColIndex).ToString() : "");
                    prePos = i;
                    isEvenRow = !isEvenRow;
                }
            }

            if (cr.r2 != this.Rows.Count)
            {
                cr = this.GetCellRange(prePos, this.Cols.Fixed, this.Rows.Count - 1, this.Cols.Count - this.Cols.Fixed);
                if (isEvenRow)
                {
                    cr.Style = this.Styles["evenRow"];
                }
                else
                {
                    cr.Style = this.Styles["oddRow"];
                }
            }
        }

        /// <summary>
        /// 수정되는 행의 스타일을 지정합니다.
        /// </summary>
        public void setAlternateRowStyle(String sColName)
        {
            if (this.Rows.Count <= this.Rows.Fixed + 1)
                return;

            String preTitle = (this.GetData(this.Rows.Fixed, sColName) != null ? this.GetData(this.Rows.Fixed, sColName).ToString() : "");
            int prePos = this.Rows.Fixed + this.Rows.Frozen;
            bool isEvenRow = false;

            CellRange cr = new CellRange();

            for (int i = prePos; i < this.Rows.Count; i++)
            {
                if (preTitle != (this.GetData(i, sColName) != null ? this.GetData(i, sColName).ToString() : ""))
                {
                    cr = this.GetCellRange(prePos, this.Cols.Fixed, i - 1, this.Cols.Count - this.Cols.Fixed);
                    if (isEvenRow)
                    {
                        cr.Style = this.Styles["evenRow"];
                    }
                    else
                    {
                        cr.Style = this.Styles["oddRow"];
                    }
                    preTitle = (this.GetData(i, sColName) != null ? this.GetData(i, sColName).ToString() : "");
                    prePos = i;
                    isEvenRow = !isEvenRow;
                }
            }

            if (cr.r2 != this.Rows.Count)
            {

                cr = this.GetCellRange(prePos, this.Cols.Fixed, this.Rows.Count - 1, this.Cols.Count - this.Cols.Fixed);
                if (isEvenRow)
                {
                    cr.Style = this.Styles["evenRow"];
                }
                else
                {
                    cr.Style = this.Styles["oddRow"];
                }
            }
        }

        /// <summary>
        /// 인수로 지정된 컬럼위치에 정렬형태를 설정합니다.
        /// </summary>
        public void ActivateColumnSort()
        {
            this.AllowSorting = AllowSortingEnum.SingleColumn;
            for (int i = this.Cols.Fixed; i < this.Cols.Count - this.Cols.Fixed; i++)
            {
                if (!this.Cols[i].Name.Equals(""))
                    this.Cols[i].AllowSorting = true;
            }
        }

        /// <summary>
        /// 인수로 지정된 컬럼위치에 정렬형태를 설정합니다.
        /// </summary>
        public void ActivateColumnSort(AllowSortingEnum eSortType)
        {
            this.AllowSorting = eSortType;
            for (int i = this.Cols.Fixed; i < this.Cols.Count - this.Cols.Fixed; i++)
            {
                if (!this.Cols[i].Name.Equals(""))
                    this.Cols[i].AllowSorting = true;
            }
        }

        /// <summary>
        /// 인수로 지정된 컬럼위치에 정렬형태를 설정합니다.
        /// </summary>
        public void ActivateColumnSort(string[] sCol, AllowSortingEnum eSortType)
        {
            this.AllowSorting = eSortType;
            for (int i = 0; i < sCol.Length; i++)
            {
                this.Cols[sCol[i]].AllowSorting = true;
            }
        }

        /// <summary>
        /// 인수로 지정된 컬럼위치에 정렬형태를 설정합니다.
        /// </summary>
        public void ActivateColumnSort(int[] sColIndex, AllowSortingEnum eSortType)
        {
            this.AllowSorting = eSortType;
            for (int i = 0; i < sColIndex.Length; i++)
            {
                this.Cols[sColIndex[i]].AllowSorting = true;
            }
        }

        private string IsNull(object obj)
        {
            return (obj == null ? string.Empty : obj.ToString());
        }

        /// <summary>
        /// Merge 로직에 대한 재정의 메서드입니다.
        /// </summary>
        public override CellRange GetMergedRange(int row, int col, bool clip)
        {
            // Fixed Header Row 일 경우 Header 머지 Range 산출
            if (_allowHeaderMerging && row < Rows.Fixed && row >= 0 && col >= 0)
            {
                int _currentColPosition, _currentRowPosition, _colMergeLength, _rowMergeLength;

                // 가로 Merge Range 산출
                _currentColPosition = col; _colMergeLength = 0;
                while (_currentColPosition + 1 < Cols.Count && this.IsNull(this[row, _currentColPosition]) == this.IsNull(this[row, _currentColPosition + 1]))
                {
                    _currentColPosition++; _colMergeLength++;
                };

                // 세로 Merge Range 산출
                _currentRowPosition = row; _rowMergeLength = 0;
                while (_currentRowPosition - 1 >= 0 && this.IsNull(this[_currentRowPosition, col]) == this.IsNull(this[_currentRowPosition - 1, col]))
                {
                    _currentRowPosition--; _rowMergeLength++;
                };


                // 가로 & 세로 Merge 대상이면 Range 반환 하고 종료
                if (_colMergeLength != 0 && _rowMergeLength != 0)
                    return base.GetCellRange(row, col, row - _rowMergeLength, col + _colMergeLength); // 임의의 CellRange 반환

                // 가로 Merge 대상이면 Range 반환 하고 종료 
                if (_colMergeLength != 0)
                    return base.GetCellRange(row, col, row, col + _colMergeLength); // 임의의 CellRange 반환

                // 세로 Merge 대상이면 Range 반환 하고 종료 
                if (_rowMergeLength != 0)
                {
                    return base.GetCellRange(row, col, row - _rowMergeLength, col); // 임의의 CellRange 반환
                }
            }

            // Fixed Header Row의 Merge 대상이 아니거나 데이터 Row 의 경우 (Base 의 원래 함수 호출)
            return base.GetMergedRange(row, col, clip);
        }
    }
}