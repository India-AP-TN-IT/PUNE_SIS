using System;
using System.Data;
using System.ServiceModel;

using System.Drawing;
using HE.Framework.Core;
using TheOne.ServiceModel;
using TheOne.Windows.Forms;
using Ax.DEV.Utility.Controls;
using System.Windows.Forms;
using HE.Framework.ServiceModel;
using Ax.DEV.Utility.Library;
using HE.Framework.Core.Report;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;


namespace Ax.SIS.TM.UI
{
    /// <summary>
    /// Location 마스터
    /// </summary>
    public partial class TM26100 : AxCommonBaseControl
    {
        private AxClientProxy _WSCOM;
        private string _CORCD;
        private string _BIZCD;
        private string _LANG_SET;
        private const string _IntFormat = "###,###,###,###,##0";

        private const int COUNT_OF_FILES = 5;//2019.04.16
        public struct fileST
        {
            public byte[] file;
            public string ext;
        }
        private Dictionary<string, fileST> m_dicFiles = new Dictionary<string, fileST>();
        public TM26100()
        {
            InitializeComponent();
            _WSCOM = new AxClientProxy();
        }
        private void ResetFiles()
        {
            m_dicFiles = new Dictionary<string, fileST>();
            for(int i=0;i<COUNT_OF_FILES;i++)
            {
                fileST fileData = new fileST();
                fileData.file = null;
                fileData.ext = "";
                m_dicFiles.Add("CON_FILE" + (i + 1).ToString().PadLeft(2, '0'), fileData);
            }
            DispDownBtn();

        }

        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                Txt_Status.SetValue("S");
                //CORCD
                cbo01_CORCD.DataBind_CORCD();
                cbo01_CORCD.SetValue(this.UserInfo.CorporationCode);
                cbo01_CORCD.SetReadOnly(true);
                //BIZCD
                cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode);
                cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                cbo01_BIZCD.DropDownStyle = ComboBoxStyle.DropDownList;

                _CORCD = this.UserInfo.CorporationCode;
                _BIZCD = this.UserInfo.BusinessCode;
                _LANG_SET = this.UserInfo.Language;

                ResetFiles();
                DispDownBtn();

                this.grd01.AllowEditing = false;
                this.grd01.Initialize();
                this.grd01.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;

                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "Construction No.", "CONCD", "CONCD");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 280, "Construction Name", "CONNM", "CONNM");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 180, "Construction Place", "CONPLACE", "CONPLACE");
                this.grd01.AddColumn(true, true, AxFlexGrid.FtextAlign.L, 50, "STATUS", "STATUS", "STATUS");

                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "CORCD", "CORCD", "CORCD");
                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "BIZCD", "BIZCD", "BIZCD");


                this.grd01.AddColumn(false, false, AxFlexGrid.FtextAlign.C, 100, "UPDATE_ID", "UPDATE_ID", "UPDATE_ID");

                ReadOnlyMode(true);
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                MsgBox.Show(ex.ToString());
            }
        }

        #region [공통버튼]

        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = this.UserInfo.BusinessCode;

               

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", cbo01_CORCD.GetValue());
                set.Add("BIZCD", cbo01_BIZCD.GetValue());
                set.Add("CONCD", axTextBox4.GetValue());
                set.Add("CONNM", axTextBox5.GetValue());
                set.Add("ST_DATE", axDateEdit3.GetDateText());
               
                this.BeforeInvokeServer(true);

                DataSet source = _WSCOM.ExecuteDataSet("APG_TM26100.GET_DATA", set, "OUT_CURSOR");

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
        protected override void BtnReset_Click(object sender, EventArgs e)
        {
            base.BtnReset_Click(sender, e);
            Txt_CONPLACE.SetValue("");
            Txt_CONNM.SetValue("");
            Txt_CONCD.SetValue("");
            Dat_ST_DATE.SetValue(DateTime.Now);
            Dat_ED_DATE.SetValue(DateTime.Now);
            Txt_Status.SetValue("S");
            ReadOnlyMode(false);
            ResetFiles();
        }
        private void ReadOnlyMode(bool bRead)
        {
            if(bRead)
            {
                Btn_DON_FILE01.Enabled = false;
                Btn_DON_FILE02.Enabled = false;
                Btn_DON_FILE03.Enabled = false;
                Btn_DON_FILE04.Enabled = false;
                Btn_DON_FILE05.Enabled = false;

                Btn_CON_FILE01.Enabled = false;
                Btn_CON_FILE02.Enabled = false;
                Btn_CON_FILE03.Enabled = false;
                Btn_CON_FILE04.Enabled = false;
                Btn_CON_FILE05.Enabled = false;

                Btn_REM_FILE01.Enabled = false;
                Btn_REM_FILE02.Enabled = false;
                Btn_REM_FILE03.Enabled = false;
                Btn_REM_FILE04.Enabled = false;
                Btn_REM_FILE05.Enabled = false;

                Txt_CONNM.ReadOnly = true;
                Txt_CONPLACE.ReadOnly = true;
                Dat_ED_DATE.Enabled = false;
                Dat_ST_DATE.Enabled = false;
            }
            else
            {
                Btn_DON_FILE01.Enabled = true;
                Btn_DON_FILE02.Enabled = true;
                Btn_DON_FILE03.Enabled = true;
                Btn_DON_FILE04.Enabled = true;
                Btn_DON_FILE05.Enabled = true;

                Btn_CON_FILE01.Enabled = true;
                Btn_CON_FILE02.Enabled = true;
                Btn_CON_FILE03.Enabled = true;
                Btn_CON_FILE04.Enabled = true;
                Btn_CON_FILE05.Enabled = true;

                Btn_REM_FILE01.Enabled = true;
                Btn_REM_FILE02.Enabled = true;
                Btn_REM_FILE03.Enabled = true;
                Btn_REM_FILE04.Enabled = true;
                Btn_REM_FILE05.Enabled = true;

                Txt_CONNM.ReadOnly = false;
                Txt_CONPLACE.ReadOnly = false;
                Dat_ED_DATE.Enabled = true;
                Dat_ST_DATE.Enabled = true;
            }
        }
        protected override void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(Txt_Status.GetValue().ToString()!="S")
                {
                    MsgBox.Show("Only Draft Data can be saved!!");
                    return;
                }
                else if(string.IsNullOrEmpty(Txt_CONNM.GetValue().ToString()))
                {
                    MsgBox.Show("Construction Name is mandatory!!");
                    return;
                }
                DataSet source = this.GetDataSourceSchema
                    ("CORCD", "BIZCD", "CONCD", "CONNM", "CONPLACE", "ST_DATE", "ED_DATE", "UPDATE_ID"
                        ,"FILE_EXT01","FILE_EXT02","FILE_EXT03","FILE_EXT04","FILE_EXT05"
                        , "BLOB$CON_FILE01", "BLOB$CON_FILE02", "BLOB$CON_FILE03","BLOB$CON_FILE04","BLOB$CON_FILE05");

                source.Tables[0].Rows.Add(
                    cbo01_CORCD.GetValue(),
                    cbo01_BIZCD.GetValue(),
                    Txt_CONCD.GetValue(),
                    Txt_CONNM.GetValue(),
                    Txt_CONPLACE.GetValue(),
                    Dat_ST_DATE.GetDateText(),
                    Dat_ED_DATE.GetDateText(),
                    this.UserInfo.UserID,

                    
                    m_dicFiles["CON_FILE01"].ext, //FILE01
                    m_dicFiles["CON_FILE02"].ext, //FILE02
                    m_dicFiles["CON_FILE03"].ext, //FILE03
                    m_dicFiles["CON_FILE04"].ext, //FILE04
                    m_dicFiles["CON_FILE05"].ext, //FILE05

                    m_dicFiles["CON_FILE01"].file, //FILE01
                    m_dicFiles["CON_FILE02"].file, //FILE02
                    m_dicFiles["CON_FILE03"].file, //FILE03
                    m_dicFiles["CON_FILE04"].file, //FILE04
                    m_dicFiles["CON_FILE05"].file //FILE05
                    );

                

                this.BeforeInvokeServer(true);

                 _WSCOM.ExecuteNonQueryTx("APG_TM26100.SAVE", source);
                 if (string.IsNullOrEmpty(Txt_CONCD.GetValue().ToString()))
                 {
                     HEParameterSet set = new HEParameterSet();
                     set.Add("CORCD", cbo01_CORCD.GetValue());
                     set.Add("BIZCD", cbo01_BIZCD.GetValue());
                     DataTable dt = _WSCOM.ExecuteDataSetTx("APG_TM26100.GET_LAST_SAVE", set).Tables[0];
                     Txt_CONCD.SetValue(dt.Rows[0]["CONCD"].ToString());
                 }
                this.AfterInvokeServer();


                this.BtnQuery_Click(null, null);

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
        
        #endregion

        private void grd01_DoubleClick(object sender, EventArgs e)
        {
            if(grd01.Rows.Count>grd01.Rows.Fixed)
            {
                string corcd = grd01.GetValue(grd01.Row, "CORCD").ToString();
                string bizcd = grd01.GetValue(grd01.Row, "BIZCD").ToString();
                string concd = grd01.GetValue(grd01.Row, "CONCD").ToString();
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", corcd);
                set.Add("BIZCD", bizcd);
                set.Add("CONCD", concd);

                DataTable dt = _WSCOM.ExecuteDataSet("APG_TM26100.GET_DATA_DET", set, "OUT_CURSOR").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    
                    Txt_CONNM.SetValue(dt.Rows[0]["CONNM"].ToString());
                    Txt_CONCD.SetValue(dt.Rows[0]["CONCD"].ToString());
                    Txt_CONPLACE.SetValue(dt.Rows[0]["CONPLACE"].ToString());
                    Dat_ST_DATE.SetValue(dt.Rows[0]["ST_DATE"].ToString());
                    Dat_ED_DATE.SetValue(dt.Rows[0]["ED_DATE"].ToString());

                    Txt_Status.SetValue(dt.Rows[0]["STATUS"].ToString());
                    if(Txt_Status.GetValue().ToString() == "S")
                    {
                        ReadOnlyMode(false);
                    }
                    else
                    {
                        ReadOnlyMode(true);
                    }
                    for(int i=0;i<COUNT_OF_FILES;i++)
                    {
                        fileST file = new fileST();
                        var conFile = dt.Rows[0]["CON_FILE" + (i + 1).ToString().PadLeft(2, '0')];
                        file.file = conFile != DBNull.Value ? (byte[])conFile : null;
                        file.ext = dt.Rows[0]["FILE_EXT" + (i + 1).ToString().PadLeft(2, '0')].ToString();
                        m_dicFiles["CON_FILE" + (i + 1).ToString().PadLeft(2, '0')] = file;

                        
                    }
                    DispDownBtn();
                    
                }
            }
        }

        private void DispDownBtn()
        {
            Btn_DON_FILE01.Visible = false;
            Btn_DON_FILE02.Visible = false;
            Btn_DON_FILE03.Visible = false;
            Btn_DON_FILE04.Visible = false;
            Btn_DON_FILE05.Visible = false;
            for(int i=0;i<COUNT_OF_FILES;i++)
            {
                string key = "CON_FILE" + (i + 1).ToString().PadLeft(2, '0');
                if(m_dicFiles.ContainsKey(key))
                {
                    if(string.IsNullOrEmpty(m_dicFiles[key].ext) == false)
                    {
                        if (i == 0)
                        {
                            Btn_DON_FILE01.Visible = true;
                        }
                        else if(i==1)
                        {
                            Btn_DON_FILE02.Visible = true;
                        }
                        else if (i == 2)
                        {
                            Btn_DON_FILE03.Visible = true;
                        }
                        else if (i == 3)
                        {
                            Btn_DON_FILE04.Visible = true;
                        }
                        else if (i == 4)
                        {
                            Btn_DON_FILE05.Visible = true;
                        }
                    }
                }
            }
        }

        private void Btn_FileUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_CONNM.GetValue().ToString()))
            {
                MsgBox.Show("Construction Name is mandatory!!");
                return;
            }
            if(sender is Button)
            {
                string name = ((Button)sender).Name;
                OpenFileDialog ofd = new OpenFileDialog();

                //파일 선택 필터
                ofd.Title = "Construction PLAN"; //(작업 표준서) PDF 파일 선택
                ofd.FilterIndex = 0;
                FileStream oFile = null;
                fileST pdfFile = new fileST();
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    //PDF 파일을 읽어서 Grid 등록 처리함
                    oFile = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);

                    pdfFile.file = new byte[oFile.Length];
                    pdfFile.ext = ofd.SafeFileName;
                    oFile.Read(pdfFile.file, 0, Convert.ToInt32(oFile.Length));
                }
                           
                if(name.Contains("FILE01"))
                {
                    m_dicFiles["CON_FILE01"] = pdfFile;
                }
                else if (name.Contains("FILE02"))
                {
                    m_dicFiles["CON_FILE02"] = pdfFile;
                }
                else if (name.Contains("FILE03"))
                {
                    m_dicFiles["CON_FILE03"] = pdfFile;
                }
                else if (name.Contains("FILE04"))
                {
                    m_dicFiles["CON_FILE04"] = pdfFile;
                }
                else if (name.Contains("FILE05"))
                {
                    m_dicFiles["CON_FILE05"] = pdfFile;
                }
                DispDownBtn();
            }
        }

        private void Btn_RemoveClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_CONNM.GetValue().ToString()))
            {
                MsgBox.Show("Construction Name is mandatory!!");
                return;
            }
            if (sender is Button)
            {
                string name = ((Button)sender).Name;
                fileST pdfFile = new fileST();
                pdfFile.ext = "";
                pdfFile.file = null;
                if (name.Contains("FILE01"))
                {
                    m_dicFiles["CON_FILE01"] = pdfFile;
                }
                else if (name.Contains("FILE02"))
                {
                    m_dicFiles["CON_FILE02"] = pdfFile;
                }
                else if (name.Contains("FILE03"))
                {
                    m_dicFiles["CON_FILE03"] = pdfFile;
                }
                else if (name.Contains("FILE04"))
                {
                    m_dicFiles["CON_FILE04"] = pdfFile;
                }
                else if (name.Contains("FILE05"))
                {
                    m_dicFiles["CON_FILE05"] = pdfFile;
                }
                DispDownBtn();
            }
        }

        private void Btn_SaveClick(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    string name = ((Button)sender).Name;
                    byte[] filebyte = null;
                    string fileName = "";
                    if (name.Contains("FILE01"))
                    {


                        filebyte = m_dicFiles["CON_FILE01"].file;
                        fileName = folder.SelectedPath+"\\"+ m_dicFiles["CON_FILE01"].ext;
                        
                    }
                    else if (name.Contains("FILE02"))
                    {
                        filebyte = m_dicFiles["CON_FILE02"].file;
                        fileName = folder.SelectedPath + "\\" + m_dicFiles["CON_FILE02"].ext;
                    }
                    else if (name.Contains("FILE03"))
                    {
                        filebyte = m_dicFiles["CON_FILE03"].file;
                        fileName = folder.SelectedPath + "\\" + m_dicFiles["CON_FILE03"].ext;
                    }
                    else if (name.Contains("FILE04"))
                    {
                        filebyte = m_dicFiles["CON_FILE04"].file;
                        fileName = folder.SelectedPath + "\\" + m_dicFiles["CON_FILE04"].ext;
                    }
                    else if (name.Contains("FILE05"))
                    {
                        filebyte = m_dicFiles["CON_FILE05"].file;
                        fileName = folder.SelectedPath + "\\" + m_dicFiles["CON_FILE05"].ext;
                    }

                    int ArraySize = filebyte.GetUpperBound(0);
                    FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                    stream.Write(filebyte, 0, ArraySize + 1);
                    stream.Close();

                    Process.Start(fileName, null);
                }
            }
        }






    }
}
