using System.Text;
using System.Data;
using System.Windows.Forms;
using Ax.DEV.Utility.Library;


namespace Ax.DEV.Utility.Controls
{
    /// <summary>
    /// ComboBox 클래스를 상속받아 구현된 콤보박스입니다.
    /// </summary>
    public class AxComboBox : ComboBox, IAxControl
    {
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
            if (this.Name.ToUpper().IndexOf("BIZCD") == -1 && this.Name.ToUpper().IndexOf("CORCD") == -1)
                if (this.Items.Count != 0) this.SelectedIndex = 0;            
        }

        #endregion

        public AxComboBox()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

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
        /// 참고로 데이타소스 첫번째 행에 비어있는 데이타를 추가합니다.
        /// </summary>
        public void DataBind(DataTable source)
        {
            this.DataBind(source, true);
        }

        /// <summary>
        /// 콤보박스에 데이타소스를 바인딩합니다.
        /// 참고로 데이타소스 첫번째 행에 비어있는 데이타를 추가할지 말지를 선택할 수 있습니다. 
        /// </summary>
        public void DataBind(DataTable source, bool isEmptyRow)
        {
            //DataTable source_copy = source.Copy();

            //if (isEmptyRow)
            //    source_copy.Rows.InsertAt(source_copy.NewRow(), 0);

            //this.DisplayMember = source_copy.Columns[1].ColumnName;
            //this.ValueMember = source_copy.Columns[0].ColumnName;
            //this.DataSource = source_copy;

            DataBind(source, isEmptyRow, "");
        }

        public void DataBind(DataTable source, bool isEmptyRow, string defaultText)
        {
            DataTable source_copy = source.Copy();

            
            if (isEmptyRow)
            {
                DataRow row = source_copy.NewRow();
                if (!string.IsNullOrEmpty(defaultText))
                    row[1] = defaultText;
                source_copy.Rows.InsertAt(row, 0);
            }

            this.DisplayMember = source_copy.Columns[1].ColumnName;
            this.ValueMember = source_copy.Columns[0].ColumnName;
            this.DataSource = source_copy;
        }
        

        /// <summary>
        /// 지정된 클래스ID에 따른 유형코드를 콤보박스에 바인딩합니다.
        /// 참고로 데이타소스 첫번째 행에 비어있는 데이타를 추가합니다.
        /// </summary>
        public void DataBind(string classID)
        {
            this.DataBind(classID, true);
        }

        /// <summary>
        /// 지정된 클래스ID에 따른 유형코드를 콤보박스에 바인딩합니다.
        /// 참고로 데이타소스 첫번째 행에 비어있는 데이타를 추가할지 말지를 선택할 수 있습니다. 
        /// </summary>
        public void DataBind(string classID, bool isEmptyRow)
        {
            //DataTable source = HEStaticCommon.GetTypeCode(classID).Tables[0];
            this.DataBind(classID, isEmptyRow, "");
        }

        public void DataBind(string classID, bool isEmptyRow, string defaultText)
        {
            DataTable source = AxStaticCommon.GetTypeCode(classID).Tables[0];
            this.DataBind(source, isEmptyRow, defaultText);
        }


        /// <summary>
        /// 지정된 클래스ID에 따른 유형코드를 콤보박스에 바인딩합니다.
        /// 참고로 데이타소스 첫번째 행에 비어있는 데이타를 추가할지 말지를 선택할 수 있습니다. 
        /// 2014.05.21 배명희추가(김도연과장님요청)
        /// </summary>
        public void DataBind(string classID, string groupCD, bool isEmptyRow)
        {
            DataTable source = AxStaticCommon.GetTypeCode(classID).Tables[0];

            source.DefaultView.RowFilter = "GROUPCD LIKE '" + groupCD + "%'";

            this.DataBind(source.DefaultView.ToTable().Copy(), isEmptyRow);
        }

        /// <summary>
        /// 입력받은 데이타 소스를 내부적으로 코드명을 재설정(코드:코드명) 후 바인딩합니다.
        /// </summary>
        public void DataBindCodeName(DataTable source, bool isTypeCode)
        {
            this.DataBindCodeName(source, true, isTypeCode);
        }

        /// <summary>
        /// 입력받은 클래스ID를 내부적으로 코드명을 재설정(코드:코드명) 후 바인딩합니다.
        /// </summary>
        public void DataBindCodeName(string classID)
        {
            this.DataBindCodeName(classID, true);
        }

        /// <summary>
        /// 입력받은 클래스ID를 내부적으로 코드명을 재설정(코드:코드명) 후 바인딩합니다.
        /// </summary>
        public void DataBindCodeName(string classID, bool isEmptyRow)
        {
            DataTable source = AxStaticCommon.GetTypeCode(classID).Tables[0];
            this.DataBindCodeName(source, isEmptyRow, true);
        }

        /// <summary>
        /// 입력받은 클래스ID를 내부적으로 코드명을 재설정(코드:코드명) 후 바인딩합니다.
        /// </summary>
        public void DataBindCodeName(string classID, string groupCD, bool isEmptyRow)
        {
            DataTable source = AxStaticCommon.GetTypeCode(classID).Tables[0];

            source.DefaultView.RowFilter = "GROUPCD LIKE '" + groupCD + "%'";

            this.DataBindCodeName(source.DefaultView.ToTable().Copy(), isEmptyRow, true);
        }

        /// <summary>
        /// 입력받은 클래스ID를 내부적으로 코드명을 재설정(코드:코드명) 후 바인딩합니다.
        /// 인자 중에 isTypeCode 는 타입코드인가? 아닌가? 를 지정합니다.
        /// </summary>
        public void DataBindCodeName(DataTable source, bool isEmptyRow, bool isTypeCode)
        {
            DataTable source_copy = source.Copy();
            foreach (DataRow row in source_copy.Rows)
                if (isTypeCode)
                {
                    if (row[0].ToString().StartsWith("A3"))
                        row[1] = row[0].ToString().Substring(2);
                    else
                        row[1] = row[0].ToString().Substring(2) + ":" + row[1].ToString();
                }
                else
                {
                    row[1] = row[0].ToString() + ":" + row[1].ToString();
                }

            if (isEmptyRow)
                source_copy.Rows.InsertAt(source_copy.NewRow(), 0);

            this.DisplayMember = source_copy.Columns[1].ColumnName;
            this.ValueMember   = source_copy.Columns[0].ColumnName;
            this.DataSource    = source_copy;
        }

        /// <summary>
        /// 회사코드를 바인딩합니다.
        /// 참고로 데이타소스 첫번째 행에 비어있는 데이타를 추가합니다.
        /// </summary>
        public void DataBind_CORCD()
        {
            this.DataBind_CORCD(true);
        }

        /// <summary>
        /// 회사코드를 바인딩합니다.
        /// 참고로 데이타소스 첫번째 행에 비어있는 데이타를 추가할지 말지를 선택할 수 있습니다.
        /// </summary>
        public void DataBind_CORCD(bool isEmptyRow)
        {
            DataTable source = AxStaticCommon.GetCorCD().Tables[0];
            this.DataBind(source, isEmptyRow);
        }

        /// <summary>
        /// 사업자코드를 바인딩합니다.
        /// 참고로 데이타소스 첫번째 행에 비어있는 데이타를 추가합니다.
        /// </summary>
        public void DataBind_BIZCD(string corcd)
        {
            this.DataBind_BIZCD(corcd, true);
        }

        /// <summary>
        /// 사업자코드를 바인딩합니다.
        /// 참고로 데이타소스 첫번째 행에 비어있는 데이타를 추가할지 말지를 선택할 수 있습니다.
        /// </summary>
        public void DataBind_BIZCD(string corcd, bool isEmptyRow)
        {
            DataTable source = AxStaticCommon.GetBizCD(corcd).Tables[0];
            string bizcd = StaticUserInfoContext._MP_BusinessCode;
            this.DataBind(source, isEmptyRow);
            if (bizcd.Length > 0)
                this.SetValue(bizcd);
        }

        public void SetReadOnly(bool read)
        {
            this.Enabled = !read;
        }
    }
}
