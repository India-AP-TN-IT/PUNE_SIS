using System.Text;
using System.Data;
using System.Windows.Forms;
using Ax.DEV.Utility.Library;
using C1.Win.C1List;
using System.Drawing;

namespace Ax.DEV.Utility.Controls
{
    /// <summary>
    /// C1Combo 클래스를 상속받아 구현된 콤보박스입니다.
    /// </summary>
    public class AxComboList : C1Combo, IAxControl
    {
        private Color _oldColor;

        public AxComboList()
            : base()
        {
            _oldColor = this.EditorBackColor;
            this.Enter += new System.EventHandler(AxComboList_Enter);
            this.Leave += new System.EventHandler(AxComboList_Leave);
        }

        void AxComboList_Leave(object sender, System.EventArgs e)
        {
            this.EditorBackColor = _oldColor;
        }

        void AxComboList_Enter(object sender, System.EventArgs e)
        {
            _oldColor = this.BackColor;
            if (!this.ReadOnly)
                this.EditorBackColor = Color.FromArgb(254, 240, 158);
        }
        #region IHEControl 멤버

        /// <summary>
        /// 선택된 값을 반환합니다. 
        /// 단 선택된 값이 없거나 null 일 경우에는 공백을 반환합니다.
        /// </summary>
        public object GetValue()
        {
            if (this.SelectedValue is System.DBNull) return "";
            return AxStaticCommon.Nvl(this.SelectedValue, "");
        }

        public void SetValue(object value)
        {
            this.SelectedValue = AxStaticCommon.Nvl(value, "").ToString();
        }

        /// <summary>
        /// 선택된 인덱스를 0으로 설정하나 회사코드, 사업장코드의 경우에는 초기화하지 않습니다.
        /// </summary>
        public void Initialize()
        {
            this.SetValue("");
            this.Text = "";
        }

        #endregion

        /// <summary>
        /// 바인딩 된 데이타 소스를 클리어시킵니다.
        /// </summary>
        public void InitializeDataSource()
        {
            if (this.DataSource != null)
                ((DataTable)this.DataSource).Clear();
        }

        /// <summary>
        /// 선택된 값이 있을 경우 그에 해당하는 텍스트를 반환합니다.
        /// 단 선택된 값이 없을 경우 공백을 반환합니다.
        /// </summary>
        public string GetValue(string column)
        {
            return this.GetValue(this.WillChangeToIndex, column);
        }

        /// <summary>
        /// 선택된 값이 있을 경우 그에 해당하는 텍스트를 반환합니다.
        /// 단 선택된 값이 없을 경우 공백을 반환합니다.
        /// </summary>
        public string GetValue(int row, string column)
        {
            return AxStaticCommon.Nvl(this.GetItemText(row, column), "").ToString();
        }

        /// <summary>
        /// 선택된 값이 있을 경우 그에 해당하는 텍스트를 반환합니다.
        /// 단 선택된 값이 없을 경우 공백을 반환합니다.
        /// </summary>
        public string GetText()
        {
            if (this.SelectedValue is System.DBNull) return "";
            return AxStaticCommon.Nvl(this.Text, "").ToString();
        }

        public bool IsEmpty
        {
            get { return this.GetValue().ToString().Length == 0 ? true : false; }
        }

        /// <summary>
        /// 선택된 값의 크기를 바이트로 반환합니다.
        /// </summary>
        public int ByteCount
        {
            get { return Encoding.Default.GetByteCount(AxStaticCommon.Nvl(this.GetValue(), "").ToString()); }
        }

        /// <summary>
        /// 콤보박스에 데이타소스를 바인딩합니다.
        /// </summary>
        public void DataBind(DataTable source, string header, string align)
        {
            this.DataBind(source, "", "", header, align);
        }

        /// <summary>
        /// 콤보박스에 데이타소스를 바인딩합니다.
        /// </summary>
        public void DataBind(DataTable source, string code, string text, string header, string align)
        {
            code = code.Length == 0 ? source.Columns[0].ColumnName : code;
            text = text.Length == 0 ? source.Columns[1].ColumnName : text;

            string[] headerList = header.Split(';');
            string[] alignList  = align.Split(';');

            //데이터 등록 모드 Add Item
            this.DataMode = DataModeEnum.Normal;

            //보조 Row 속성
            this.AlternatingRows = true;

            //색상
            this.EvenRowStyle.BackColor = Color.White;
            this.EvenRowStyle.ForeColor = Color.Black;

            this.OddRowStyle.BackColor = Color.FromArgb(244, 251, 255);
            this.OddRowStyle.ForeColor = Color.Black;

            //Item 높이
            this.ItemHeight = 20;

            //스크롤 바
            this.HScrollBar.Style = ScrollBarStyleEnum.Automatic;
            this.VScrollBar.Style = ScrollBarStyleEnum.Always;
            this.VScrollBar.Width = 18;

            //마지막 Column 확장
            this.Splits[0].ExtendRightColumn = true;

            //데이터 조회 및 등록
            this.ClearItems();
            this.ClearFields();

            //데이터 있으면 등록
            if (source != null)
            {
                this.DataSource = source.Copy();
                if (this.Columns.Count == 0)
                {
                    DataTable temp = (DataTable)this.DataSource;
                    for (int i = 0; i < temp.Columns.Count; i++)
                    {
                        C1DataColumn column = new C1DataColumn();
                        column.DataField = temp.Columns[i].ColumnName;
                        this.Columns.Add(column);
                    }
                }

                //Add Item 이후 Column이 'Column 0', 'Column 1' ... 형식으로 생성 됨
                //헤더 및 폭 지정
                this.DropDownWidth = 0;
                for (int i = 0; i < source.Columns.Count; i++)
                {
                    //해더 Caption
                    this.Columns[i].Caption = headerList[i];

                    //Column 폭 - 자동
                    this.Splits[0].DisplayColumns[i].AutoSize();

                    //콤보 폭이 작게 나오는 것에 대한 임의 크기 조정
                    this.Splits[0].DisplayColumns[i].Width += 10;

                    this.DropDownWidth += this.Splits[0].DisplayColumns[i].Width;

                    //해더 정렬
                    this.Splits[0].DisplayColumns[i].HeadingStyle.HorizontalAlignment = AlignHorzEnum.Center;
                    this.Splits[0].DisplayColumns[i].HeadingStyle.VerticalAlignment = AlignVertEnum.Center;

                    //Border
                    this.Splits[0].DisplayColumns[i].Style.Borders.BorderType = BorderTypeEnum.Raised;
                    this.Splits[0].DisplayColumns[i].Style.Borders.Color = Color.Gray;

                    //데이터 정렬
                    if (align != "")
                    {
                        switch (alignList[i])
                        {
                            case "L": this.Splits[0].DisplayColumns[i].Style.HorizontalAlignment = AlignHorzEnum.Near;    break;
                            case "C": this.Splits[0].DisplayColumns[i].Style.HorizontalAlignment = AlignHorzEnum.Center;  break;
                            case "R": this.Splits[0].DisplayColumns[i].Style.HorizontalAlignment = AlignHorzEnum.Far;     break;
                            default:  this.Splits[0].DisplayColumns[i].Style.HorizontalAlignment = AlignHorzEnum.General; break;
                        }
                    }
                    else
                        this.Splits[0].DisplayColumns[i].Style.HorizontalAlignment = AlignHorzEnum.General;

                    this.Splits[0].DisplayColumns[i].Style.VerticalAlignment = AlignVertEnum.Center;

                } // for

                //Drop Down 폭 최종 설정 (22:스크롤바 크기)
                if (this.DropDownWidth < this.Width + this.VScrollBar.Width + 5)
                {
                    //마지막 컬럼의 폭을 넓혀 줌
                    this.Splits[0].DisplayColumns[this.Columns.Count - 1].Width += this.Width - this.DropDownWidth;

                    //폭 설정  - 수정: 콤보 오른쪽 데이터가 짤리는 경우가 생겨서 폭을 5에서 20으로 늘림!
                    this.DropDownWidth = this.Width + this.VScrollBar.Width + 20;
                }
                else
                    this.DropDownWidth += this.VScrollBar.Width + 5;

                //Drop down Row 수 설정 - 최대 25개 넘지 않도록 함
                if (source.Rows.Count >= 15)
                    this.MaxDropDownItems = 15;
                else if (source.Rows.Count <= 5)
                    this.MaxDropDownItems = 5;
                else
                    this.MaxDropDownItems = (short)source.Rows.Count;

            }

            //리스트 선택 시 출력 값 설정
            this.DisplayMember = text;

            //리스트 선택 시 선택 값 설정
            this.ValueMember = code;

            //Row Tracking
            this.RowTracking = true;
            this.Row = 0;
            this.Row = -1;

            ////데이터가 있는 경우 찾음
            //if (this.Text != "")
            //{
            //    int i = this.FindString(this.Text, 0, text);
            //    this.SelectedIndex = i;
            //}

            this.Initialize();
        }

        /// <summary>
        /// 입력받은 클래스ID를 내부적으로 코드명을 재설정(코드:코드명) 후 바인딩합니다.
        /// </summary>
        public void DataBind(string classID)
        {
            DataTable source = AxStaticCommon.GetTypeCode(classID).Tables[0];

            source.Columns.Remove("TYPECD");
            source.Columns.Remove("GROUPCD");

            this.DataBind(source, "코드;코드명", "C;L");
        }

        /// <summary>
        /// 회사코드를 바인딩합니다.
        /// 참고로 데이타소스 첫번째 행에 비어있는 데이타를 추가할지 말지를 선택할 수 있습니다.
        /// </summary>
        public void DataBind_CORCD()
        {
            DataTable source = AxStaticCommon.GetCorCD().Tables[0];

            this.DataBind(source, "법인코드;법인명", "C;L");
        }

        /// <summary>
        /// 사업자코드를 바인딩합니다.
        /// 참고로 데이타소스 첫번째 행에 비어있는 데이타를 추가할지 말지를 선택할 수 있습니다.
        /// </summary>
        public void DataBind_BIZCD(string corcd)
        {
            DataTable source = AxStaticCommon.GetBizCD(corcd).Tables[0];
            string bizcd = StaticUserInfoContext._MP_BusinessCode; 
            this.DataBind(source, "사업장코드;사업장명", "C;L");

            if (bizcd.Length > 0)
                this.SetValue(bizcd);
        }

        public void SetReadOnly(bool read)
        {
            this.Enabled = !read;
        }
    }
}
