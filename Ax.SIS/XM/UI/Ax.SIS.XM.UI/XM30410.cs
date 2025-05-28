#region ▶ Description & History
/* 
 * 프로그램명 : 사용자별 권한 현황
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2014-07-02      배명희      프로그램 아이디 변경(XM60030 -> XM30410)
 *                                          웹서비스 호출(DB) 로직 변경, 다국어 처리, 시스템코드 적용(콤보)
 *              2014-07-22      배명희     Ax.SIS.XM.IF 참조 제거     
 *              2014-12-17      배명희     그리드 다국어 처리 방식 변경 (XD1410사용하지 않고 XD1420사용)
*/
#endregion
using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;



using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using Ax.DEV.Utility.Library;
using HE.Framework.ServiceModel;

namespace Ax.SIS.XM.UI
{
    public partial class XM30410 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string PAKAGE_NAME = "APG_XM30410";
        private string apply_language = "Y";
        public XM30410()
        {
            InitializeComponent();
            this.axDockingTab1.LinkPanel = this.panel2;            
            this.axDockingTab1.LinkBody = this.panel4;
            _WSCOM = new AxClientProxy();
        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                HEParameterSet paramSet_Category = new HEParameterSet();
                DataSet source_Category = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", "APG_XM20410", "INQUERY_CATEGORY"), paramSet_Category);
                cbo01_CATEGORY.DataBind(source_Category.Tables[0], true, "ALL"); //조회                

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;                
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 270, "Subject", "TITLE", "SUBJECT");
                this.grd01.AddColumn(false, true, AxFlexGrid.FtextAlign.C, 68, "Doc No.", "DOC_NO", "DOCCD");
                this.grd01.AddHiddenColumn("CORCD");
                this.grd01.AddHiddenColumn("APPLY_LANGUAGE");
                this.grd01.ExtendLastCol = false;

                this.grd02.AllowEditing = false;
                this.grd02.Initialize();
                this.grd02.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;
                
                this.grd03.AllowEditing = false;
                this.grd03.Initialize();
                this.grd03.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.SingleColumn;

                this.btn01_SEARCH_Click(null, null);
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #region [공통 버튼 이벤트]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.grd03.Cols.RemoveRange(this.grd03.Cols.Fixed, this.grd03.Cols.Count - 1);
                grd03.GridColumns.Clear();

                this.grd02.Cols.RemoveRange(this.grd02.Cols.Fixed, this.grd02.Cols.Count - 1);
                grd02.GridColumns.Clear();
                //grd02.Initialize();

                if (!IsProcessValid(panel5.Controls)) return;


                String query = txt01_QUERY.GetValue().ToString();
                if (this.Controls.Find("ctr_CORCD", true).Length != 0 && this.Controls.Find("ctr_CORCD", true)[0] != null)
                {
                    //query = query.Replace(":IN_CORCD", "'" + ((IAxControl)this.Controls.Find("ctr_CORCD", true)[0]).GetValue().ToString() + "'");
                }
                else
                {
                    query = query.Replace(":IN_CORCD", "'" + this.UserInfo.CorporationCode + "'");
                }

                if (this.Controls.Find("ctr_LANG_SET", true).Length != 0 && this.Controls.Find("ctr_LANG_SET", true)[0] != null)
                {
                }
                else
                {
                    query = query.Replace(":IN_LANG_SET", "'" + this.UserInfo.Language + "'");
                }

                HEParameterSet paramSet = new HEParameterSet();

                for (int i = 0; i < panel5.Controls.Count; i++)
                {
                    Control ctr = panel5.Controls[i];
                    if (ctr.Tag != null) continue;

                    Control ctl = ctr.Controls[1].Controls[0];
                    if (query.IndexOf(":IN_" + ctl.Name.Substring(4)) >= 0)
                    {
                        paramSet.Add(ctl.Name.Substring(4), ((IAxControl)ctl).GetValue().ToString());
                    }
                }
                
                //System.Text.RegularExpressions.Regex cntStr = new System.Text.RegularExpressions.Regex(":IN_");
                //int count = int.Parse(cntStr.Matches(query.ToUpper(), 0).Count.ToString());

                //if (paramSet.Items.Count != count)
                //{
                //    MsgBox.Show("Parameter Count is not equal with Query's Parameter");
                //    return;
                //}

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("$SQL$BEGIN OPEN :OUT_CURSOR FOR " + query + ";  END;", paramSet);
                this.AfterInvokeServer();

                //동적 생성
                if (source.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < source.Tables[0].Columns.Count; i++)
                    {
                        string name = source.Tables[0].Columns[i].ColumnName;
                        this.grd02.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, (apply_language.Equals("Y")) ? string.IsNullOrEmpty(this.GetLabel(name)) ? name : this.GetLabel(name) : name, name);

                        if (source.Tables[0].Columns[i].DataType == typeof(decimal) || source.Tables[0].Columns[i].DataType == typeof(int)
                            || source.Tables[0].Columns[i].DataType == typeof(float) || source.Tables[0].Columns[i].DataType == typeof(double)
                            || source.Tables[0].Columns[i].DataType == typeof(long))
                        {
                            if (source.Tables[0].Columns[i].DataType == typeof(int))
                            {
                                this.grd02.SetColumnType(AxFlexGrid.FCellType.Int, name);
                                this.grd02.Cols[name].Format = "#,##0";
                                this.grd02.Cols[name].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter;
                            }
                            else
                            {
                                this.grd02.SetColumnType(AxFlexGrid.FCellType.Decimal, name);
                                this.grd02.Cols[name].Format = "#,##0.#####";
                                this.grd02.Cols[name].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter;
                            }
                        }
                    }

                }
                this.grd02.SetValue(source.Tables[0]);
                this.grd02.AutoSizeCols();
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
            SearchInit();
            InputInit();        
        }

        private void InputInit()
        {
            this.grd02.Cols.RemoveRange(this.grd02.Cols.Fixed, this.grd02.Cols.Count - 1);
            grd02.GridColumns.Clear();
            this.grd02.InitializeDataSource();

            this.grd03.Cols.RemoveRange(this.grd03.Cols.Fixed, this.grd03.Cols.Count - 1);
            grd03.GridColumns.Clear();
            this.grd03.InitializeDataSource();

            panel5.Controls.Clear();
            panel5.Refresh();
            txt01_QUERY.Initialize();
        }

        private void SearchInit()
        {
            txt01_TITLE.Initialize();
            grd03.InitializeDataSource();
            this.grd01.InitializeDataSource();
        }

        #endregion

        #region [컨트롤 이벤트]

        private void btn01_SEARCH_Click(object sender, EventArgs e)
        {
            try
            {
                InputInit();

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("TITLE", this.txt01_TITLE.GetValue());
                paramSet.Add("GROUPID", this.Name);
                paramSet.Add("CATEGORY", this.cbo01_CATEGORY.GetValue());

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY"), paramSet);
                this.AfterInvokeServer();

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


        private void grd01_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                int row = this.grd01.MouseRow;
                int col = this.grd01.MouseCol;
                if (this.grd01.Row > 0
                    && this.grd01.Selection.TopRow == this.grd01.Selection.BottomRow
                    && this.grd01.Selection.LeftCol == this.grd01.Selection.RightCol
                    )
                {
                    if (grd01.MouseRow < grd01.Rows.Fixed || col < 0)
                    {
                        return;
                    }


                    string CORCD = this.grd01.GetValue(row, "CORCD").ToString();
                    string DOC_NO = this.grd01.GetValue(row, "DOC_NO").ToString();
                    apply_language = this.grd01.GetValue(row, "APPLY_LANGUAGE").ToString();             
                    this.Inquery_Detail(CORCD, DOC_NO);
                }

                
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        private void grd02_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                int row = this.grd02.MouseRow;
                int col = this.grd02.MouseCol;
                if (this.grd02.Row > 0
                    && this.grd02.Selection.TopRow == this.grd02.Selection.BottomRow
                    && this.grd02.Selection.LeftCol == this.grd02.Selection.RightCol
                    )
                {
                    if (grd02.MouseRow < grd02.Rows.Fixed || col < 0 || grd03.Visible == false)
                    {
                        return;
                    }

                    this.Inquery_SUB_Detail(grd02.MouseRow);
                }


            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #endregion

        #region [사용자 정의 메서드]
        private bool IsNumeric(string value)
        {
            foreach (char _char in value)
            {
                if (!Char.IsNumber(_char))
                    return false;
            }
            return true;
        }

        private bool IsProcessValid(ControlCollection ctrlist)
        {
            if(string.IsNullOrEmpty(txt01_QUERY.GetValue().ToString()))
            {
                MsgBox.Show("Please select one of subjets.");
                return false;
            }
            for (int i = 0; i < ctrlist.Count; i++)
            {
                Control ctr = ctrlist[i];
                if (ctr.Tag != null) continue;

                
                if(((IAxControl)ctr.Controls[0].Controls[0]).GetValue().ToString().Equals("1"))
                {
                    if (this.GetByteCount(((IAxControl)ctr.Controls[1].Controls[0]).GetValue().ToString()) == 0)
                    {
                        MsgCodeBox.ShowFormat("CD00-0082", ((AxLabel)ctr.Controls[2].Controls[0]).GetValue());
                        return false;
                    }  
                }
            }

            return true;
        }

        private void Inquery_Detail(string CORCD, string DOC_NO)
        {
            try
            {
                panel5.SuspendLayout();
                InputInit();                

                HEParameterSet paramSet = new HEParameterSet();
                paramSet.Add("CORCD", CORCD);
                paramSet.Add("DOC_NO", DOC_NO);
                DataSet source = _WSCOM.ExecuteDataSet(string.Format("{0}.{1}", PAKAGE_NAME, "INQUERY_DETAIL"), paramSet);                

                if (source != null)
                {
                    foreach (DataRow dr in source.Tables[0].Rows)
                    {

                        Panel panel = new Panel();
                        panel.Dock = DockStyle.Top;
                        panel.Height = 21;

                        string name = dr["PARAM_NM"].ToString();
                        string type = dr["PARAM_TYPE"].ToString();
                        string SORT_SEQ = dr["SORT_SEQ"].ToString();
                        string IS_VALIDATION = dr["IS_VALIDATION"].ToString();
                        string COMM_CODE = dr["COMM_CODE"].ToString();
                        string LANG_CODE = dr["LANG_CODE"].ToString();
                        string DEFAULT_DATA = dr["DEFAULT_DATA"].ToString();

                        txt01_QUERY.SetValue(dr["SCRIPT_QUERY"].ToString());
                        txt02_QUERY.SetValue(dr["SUB_QUERY"].ToString());
                        txt01_LINK_COLUMN.SetValue(dr["LINK_COLUMN"].ToString());
                        if (string.IsNullOrEmpty(txt01_LINK_COLUMN.GetValue().ToString()))
                        {
                            grd03.Visible = false;
                            axSplitter1.Visible = false;
                        }
                        else
                        {
                            grd03.Visible = true;
                            axSplitter1.Visible = true;
                        }

                        if (!string.IsNullOrEmpty(name))
                        {

                           

                            Control Hctr = new Control();
                            AxLabel ctr_label = new AxLabel();
                            AxLabel ctr_valid = new AxLabel();

                            if (type.Equals("CORCD"))
                            {
                                AxComboBox ctr = new AxComboBox();
                                //ctr.DataBind_BIZCD(UserInfo.CorporationCode, true);
                                Hctr = ctr;
                            }
                            else if (type.Equals("BIZCD"))
                            {
                                AxComboBox ctr = new AxComboBox();
                                //ctr.DataBind_BIZCD(UserInfo.CorporationCode, true);
                                Hctr = ctr;
                            }                        
                            else if (type.Equals("TEXT"))
                            {
                                AxTextBox ctr = new AxTextBox();
                                Hctr = ctr;
                            }
                            else if (type.Equals("DATE"))
                            {
                                AxDateEdit ctr = new AxDateEdit();
                                ctr.Format = DateTimePickerFormat.Custom;
                                ctr.CustomFormat = "yyyy-MM-dd";
                                Hctr = ctr;
                            }
                            else if (type.Equals("MONTH"))
                            {
                                AxDateEdit ctr = new AxDateEdit();
                                ctr.Format = DateTimePickerFormat.Custom;
                                ctr.CustomFormat = "yyyy-MM";
                                Hctr = ctr;
                            }
                            else if (type.Equals("YEAR"))
                            {
                                AxDateEdit ctr = new AxDateEdit();
                                ctr.Format = DateTimePickerFormat.Custom;
                                ctr.CustomFormat = "yyyy";
                                Hctr = ctr;
                            }
                            else if (type.Equals("CODEBOX")|| type.Equals("VENDCD") || type.Equals("CUSTCD") || type.Equals("PARTNO"))
                            {
                                AxCodeBox ctr = new AxCodeBox();

                                ctr.Visible = true;                                
                                
                                ctr.Size = new System.Drawing.Size(204, 21);
                                ctr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                                ctr.CodeParameterName = "CODE";
                                ctr.CodeTextBoxReadOnly = false;
                                ctr.CodeTextBoxWidth = 80;
                                ctr.CodeTextBoxVisible = false;
                                ctr.HEPopupHelper = null;
                                ctr.Location = new System.Drawing.Point(3, 132);
                                ctr.NameParameterName = "NAME";
                                ctr.NameTextBoxReadOnly = false;
                                ctr.NameTextBoxVisible = true;
                                ctr.PopupButtonReadOnly = false;
                                ctr.PopupTitle = "";
                                ctr.PrefixCode = "";
                                ctr.Tag = null;
                                if (type.Equals("CODEBOX"))
                                {
                                    ctr.HEPopupHelper = new Ax.SIS.CM.UI.CM30010P1(COMM_CODE, true, false, ctr);
                                }
                                else if (type.Equals("VENDCD"))
                                {
                                    ctr.HEPopupHelper = new Ax.SIS.CM.UI.CM20017P1();
                                    ctr.PopupTitle = "Vendor";
                                    ctr.CodeParameterName = "VENDCD";
                                    ctr.NameParameterName = "VENDNM";
                                    ctr.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                                    ctr.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                                    //ctr.HEUserParameterSetValue("PURC_TYPE", "AMD");
                                    ctr.HEPopupHelper.Initialize_Helper(ctr);
                                }
                                else if (type.Equals("CUSTCD"))
                                {
                                    ctr.HEPopupHelper = new Ax.SIS.CM.UI.CM22022P1();
                                    ctr.CodeParameterName = "CUSTCD";
                                    ctr.NameParameterName = "CUSTNM";
                                    ctr.HEUserParameterSetValue("CORCD", this.UserInfo.CorporationCode);
                                    ctr.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                                }
                                else if (type.Equals("PARTNO"))
                                {
                                    ctr.HEPopupHelper = new XM30410P1();
                                    ctr.PopupTitle = "Part No.";//"외작 Part No";
                                    ctr.CodeParameterName = "PARTNO";
                                    ctr.NameParameterName = "PARTNM";                                    
                                    ctr.HEUserParameterSetValue("LANG_SET", this.UserInfo.Language);
                                }

                                
                                Hctr = ctr;

                                //groupBox1.Controls.Add(Hctr);
                                //return;
                            }
                            else if (type.Equals("CODE_COMBO"))
                            {
                                AxComboBox ctr = new AxComboBox();
                                ctr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                                ctr.FormattingEnabled = true;
                                ctr.Location = new System.Drawing.Point(811, 42);
                                ctr.Size = new System.Drawing.Size(121, 20);
                                if (IS_VALIDATION.ToString().Equals("1")) ctr.DataBindCodeName(COMM_CODE, false);
                                else ctr.DataBindCodeName(COMM_CODE, true);
                                Hctr = ctr;
                            }
                            else if (type.Equals("USER_COMBO"))
                            {
                                AxComboBox ctr = new AxComboBox();
                                ctr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                                ctr.FormattingEnabled = true;
                                ctr.Location = new System.Drawing.Point(811, 42);
                                ctr.Size = new System.Drawing.Size(121, 20);

                                string[] commonTypeSource = COMM_CODE.Split(',');

                                DataSet query = AxFlexGrid.GetDataSourceSchema
                                (
                                    "CODE", "VALUE"
                                );

                                for (int i = 0; i < commonTypeSource.Length; i++)
                                {
                                    query.Tables[0].Rows.Add(commonTypeSource[i], commonTypeSource[i]);
                                }
                                if (IS_VALIDATION.ToString().Equals("1"))
                                    ctr.DataBind(query.Tables[0], false, "");
                                else
                                    ctr.DataBind(query.Tables[0], true, "");
                                Hctr = ctr;
                            }

                            ctr_label.Dock = DockStyle.Fill;
                            Hctr.Dock = DockStyle.Left;
                            ctr_valid.Dock = DockStyle.Fill;
                            ctr_valid.Visible = false;

                            if (IS_VALIDATION.ToString().Equals("1")) this.SetRequired(ctr_label);
                            ctr_valid.SetValue(IS_VALIDATION);

                            string text = string.Empty;
                            if (apply_language.Equals("Y")) text = string.IsNullOrEmpty(this.GetLabel(LANG_CODE)) ? LANG_CODE : this.GetLabel(LANG_CODE);
                            else text = LANG_CODE;

                            ctr_label.Name = "lbl01_" + name;
                            ctr_label.SetValue(text); //다국어
                            ctr_valid.Name = "lbl02_" + name;
                            Hctr.Name = "ctr_" + name;

                            
                            
                            Hctr.Width = 202;

                            Panel left = new Panel();
                            left.Dock = DockStyle.Left;
                            left.Width = 100;

                            Panel center = new Panel();
                            //center.BorderStyle = BorderStyle.FixedSingle;
                            center.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
                            center.Dock = DockStyle.Fill;

                            Panel right = new Panel();
                            right.Dock = DockStyle.Left;
                            right.Width = 0;
                            right.Visible = true;


                            left.Controls.Add(ctr_label);
                            center.Controls.Add(Hctr);
                            right.Controls.Add(ctr_valid);

                            panel.Controls.Add(right);
                            panel.Controls.Add(center);
                            panel.Controls.Add(left);

                            //panel.BorderStyle = BorderStyle.FixedSingle;                        

                            Panel dump = new Panel();
                            dump.Dock = DockStyle.Top;
                            dump.Height = 3;
                            dump.Tag = "dump";

                            panel5.Controls.Add(dump);
                            panel5.Controls.Add(panel);
                            panel5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);

                            if (type.Equals("CORCD") && string.IsNullOrEmpty(DEFAULT_DATA))
                            {
                                ((AxComboBox)Hctr).DataBind_CORCD(false);
                                ((IAxControl)Hctr).SetValue(UserInfo.CorporationCode);
                                ((AxComboBox)Hctr).SelectedIndexChanged += new EventHandler(XM30410_SelectedIndexChanged);
                            }
                            else if (type.Equals("BIZCD") && string.IsNullOrEmpty(DEFAULT_DATA))
                            {
                                ((AxComboBox)Hctr).DataBind_BIZCD(UserInfo.CorporationCode, true);
                                ((IAxControl)Hctr).SetValue(UserInfo.BusinessCode);
                            }
                            else if (type.Equals("DATE") || type.Equals("MONTH") || type.Equals("YEAR")) ((IAxControl)Hctr).SetValue(DateTime.Now);
                            else if ((type.Equals("CODE_COMBO") || type.Equals("CODE_COMBO")) && COMM_CODE.Equals("U9"))
                                ((IAxControl)Hctr).SetValue(UserInfo.PlantDiv);
                            else ((IAxControl)Hctr).SetValue(DEFAULT_DATA);
                        }
                        else
                        {
                            BtnQuery_Click(null, null);
                        }
                    }
                }
                
            }
            catch (FaultException<ExceptionDetail> ex)
            {                
                MsgBox.Show(ex.ToString());
            }
            finally
            {
                panel5.ResumeLayout();
            }
        }

        private void Inquery_SUB_Detail(int rows)
        {
            try
            {
                this.grd03.Cols.RemoveRange(this.grd03.Cols.Fixed, this.grd03.Cols.Count - 1);
                grd03.GridColumns.Clear();
                
                String query = txt02_QUERY.GetValue().ToString();
                String link_column = txt01_LINK_COLUMN.GetValue().ToString();


                if (query.IndexOf(":IN_LANG_SET") >= 0 && link_column.IndexOf("LANG_SET") < 0)
                {
                    if (this.Controls.Find("ctr_LANG_SET", true).Length != 0 && this.Controls.Find("ctr_LANG_SET", true)[0] != null)
                    {
                        query = query.Replace(":IN_LANG_SET", "'" + ((IAxControl)this.Controls.Find("ctr_LANG_SET", true)[0]).GetValue().ToString() + "'");
                    }
                    else
                    {
                        query = query.Replace(":IN_LANG_SET", "'" + this.UserInfo.Language + "'");
                    }
                }

                HEParameterSet paramSet = new HEParameterSet();
                for(int i =0; i< link_column.Split(',').Length; i++)
                {
                    if (query.IndexOf(":IN_" + link_column.Split(',')[i].Trim()) >= 0)
                    {
                        if(this.grd02.Cols.Contains(link_column.Split(',')[i].Trim()))
                            paramSet.Add(link_column.Split(',')[i].Trim(), this.grd02.GetValue(rows, link_column.Split(',')[i].Trim()));
                    }
                }
                

                this.BeforeInvokeServer(true);
                DataSet source = _WSCOM.ExecuteDataSet("$SQL$BEGIN OPEN :OUT_CURSOR FOR " + query + ";  END;", paramSet);
                this.AfterInvokeServer();

                //동적 생성
                if (source.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < source.Tables[0].Columns.Count; i++)
                    {
                        string name = source.Tables[0].Columns[i].ColumnName;
                        this.grd03.AddColumn(false, true, AxFlexGrid.FtextAlign.L, 70, (apply_language.Equals("Y"))?string.IsNullOrEmpty(this.GetLabel(name))? name : this.GetLabel(name):name, name);

                        if (source.Tables[0].Columns[i].DataType == typeof(decimal) || source.Tables[0].Columns[i].DataType == typeof(int)
                            || source.Tables[0].Columns[i].DataType == typeof(float) || source.Tables[0].Columns[i].DataType == typeof(double)
                            || source.Tables[0].Columns[i].DataType == typeof(long))
                        {
                            this.grd03.SetColumnType(AxFlexGrid.FCellType.Decimal,  name);
                            this.grd03.Cols[name].Format = "#,##0.#####";
                            this.grd03.Cols[name].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter;
                        }
                    }

                }
                this.grd03.SetValue(source.Tables[0]);
                this.grd03.AutoSizeCols();
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

        void XM30410_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Controls.Find("ctr_BIZCD", true).Length != 0 && this.Controls.Find("ctr_BIZCD", true)[0] != null)
            {
                ((AxComboBox)this.Controls.Find("ctr_BIZCD", true)[0]).DataBind_BIZCD(UserInfo.CorporationCode, true);
            }
        }


        #endregion


        
    }
}
