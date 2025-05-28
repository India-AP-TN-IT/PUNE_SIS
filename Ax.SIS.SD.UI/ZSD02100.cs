#region ▶ Description & History
/* 
 * 프로그램명 : PD40520 금형투입이력 조회
 * 설      명 : 
 * 최초작성자 : 
 * 최초작성일 : 
 * 수정  내용 :
 *  
 * 
 *				날짜			작성자		이슈
 *				---------------------------------------------------------------------------------------------
 *				2017-07~09    배명희     SIS 이관
 *				
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
using System.IO;
using System.Text;

namespace Ax.SIS.SD.UI
{

    public partial class ZSD02100 : AxCommonBaseControl
    {
        //private IPD40520 _WSCOM;
        private AxClientProxy _WSCOM_N;
        private string PACKAGE_NAME = "ZPG_ZSD02100";
        private string m_CerFile = "";
        #region [ 초기화 작업 정의 ]

        public ZSD02100()
        {
            InitializeComponent();

            _WSCOM_N = new AxClientProxy();

        }
        private void DispPlantCD()
        {
            DataSet source_BIZCD = this.GetTypeCode("U9");
            if (this.cbo01_BIZCD.GetValue().ToString() == "3001")
            {
                source_BIZCD.Tables[0].DefaultView.RowFilter = "GROUPCD = '" + this.cbo01_BIZCD.GetValue() + "'";
            }
            else
            {
                source_BIZCD.Tables[0].DefaultView.RowFilter = "GROUPCD = '" + this.cbo01_BIZCD.GetValue() + "'";
            }
            DataTable dtPlant_Div = source_BIZCD.Tables[0].DefaultView.ToTable().Copy();

            this.cbo01_PLANT_DIV.DataBindCodeName(dtPlant_Div, false, true);


        }
        protected override void UI_Shown(EventArgs e)
        {
            try
            {
                this.cbo01_BIZCD.DataBind_BIZCD(this.UserInfo.CorporationCode, false);
                this.cbo01_BIZCD.SetValue(this.UserInfo.BusinessCode);
                this.cbo01_BIZCD.SetReadOnly(this.UserInfo.IsAdmin.Equals("N"));
                DispPlantCD();
                BtnQuery_Click(null, null);

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
                byte[] img = ImageToByteArray(pictureBox1.Image);
                string bizcd = cbo01_BIZCD.GetValue().ToString();
                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("PLANT", cbo01_PLANT_DIV.GetValue());
                set.Add("GSTNO", Txt_GST.GetValue());
                set.Add("COMNM", Txt_COMNM_F.GetValue());
                set.Add("COMNM_SHORT", Txt_COMNM_S.GetValue());
                set.Add("COMADDR", Txt_COMADDR.GetValue());
                set.Add("ZIPCD", Txt_ZIP.GetValue());
                set.Add("AREACD", Txt_AREACD.GetValue());
                set.Add("PANNO", Txt_PAN.GetValue());
                set.Add("PORTAL_ID", Txt_PID.GetValue());
                set.Add("PORTAL_PWD", Txt_PPWD.GetValue());
                set.Add("KMI_VENDCD", Txt_KMI_VCD.GetValue());
                set.Add("CIN", Txt_CIN.GetValue());
                set.Add("CER_PWD", axTextBox1.GetValue());
                set.Add("CLOB$CER_PIC", GetBytesToString(img));
                set.Add("CLOB$CER_FILE", m_CerFile);
                set.Add("WEB_ADDR", axTextBox2.GetValue());
                set.Add("DIS_ADDR", Txt_Disaddr.GetValue());
                this.BeforeInvokeServer(true);

                _WSCOM_N.ExecuteNonQueryTx(string.Format("{0}.{1}", PACKAGE_NAME, "SET_COM_INFO"), set);


                this.AfterInvokeServer();

                this.BtnQuery_Click(null, null);

                //MsgBox.Show(" 저장되었습니다.");
                MsgCodeBox.Show("CD00-0071");
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                this.AfterInvokeServer();
                MsgBox.Show(ex.Message);
            }
            finally
            {
                this.AfterInvokeServer();
            }
        }
        private void InitCtl()
        {
            Txt_GST.SetValue("");
            Txt_COMNM_F.SetValue("");
            Txt_COMNM_S.SetValue("");
            Txt_COMADDR.SetValue("");
            Txt_ZIP.SetValue("");
            Txt_AREACD.SetValue("");
            Txt_PAN.SetValue("");
            Txt_PID.SetValue("");
            Txt_PPWD.SetValue("");
            Txt_KMI_VCD.SetValue("");
            Txt_CIN.SetValue("");
            axTextBox1.SetValue("");
            LoadPic("");
            m_CerFile = null;
            axTextBox2.SetValue("");
            Txt_Disaddr.SetValue("");
        }
        protected override void BtnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string bizcd = cbo01_BIZCD.GetValue().ToString();

                HEParameterSet set = new HEParameterSet();
                set.Add("CORCD", this.UserInfo.CorporationCode);
                set.Add("BIZCD", bizcd);
                set.Add("PLANT", cbo01_PLANT_DIV.GetValue());

                this.BeforeInvokeServer(true);
                //DataSet source = _WSCOM.INQUERY(bizcd, set);
                DataSet source = _WSCOM_N.ExecuteDataSet(string.Format("{0}.{1}", PACKAGE_NAME, "GET_COM_INFO"), set, "OUT_CURSOR");
                if (source.Tables[0].Rows.Count > 0)
                {
                    Txt_GST.SetValue(source.Tables[0].Rows[0]["GSTNO"].ToString());
                    Txt_COMNM_F.SetValue(source.Tables[0].Rows[0]["COMNM"].ToString());
                    Txt_COMNM_S.SetValue(source.Tables[0].Rows[0]["COMNM_SHORT"].ToString());
                    Txt_COMADDR.SetValue(source.Tables[0].Rows[0]["COMADDR"].ToString());
                    Txt_ZIP.SetValue(source.Tables[0].Rows[0]["ZIPCD"].ToString());
                    Txt_AREACD.SetValue(source.Tables[0].Rows[0]["AREACD"].ToString());
                    Txt_PAN.SetValue(source.Tables[0].Rows[0]["PANNO"].ToString());
                    Txt_PID.SetValue(source.Tables[0].Rows[0]["PORTAL_ID"].ToString());
                    Txt_PPWD.SetValue(source.Tables[0].Rows[0]["PORTAL_PWD"].ToString());
                    Txt_KMI_VCD.SetValue(source.Tables[0].Rows[0]["KMI_VENDCD"].ToString());
                    Txt_CIN.SetValue(source.Tables[0].Rows[0]["CIN"].ToString());
                    axTextBox1.SetValue(source.Tables[0].Rows[0]["CER_PWD"].ToString());
                    LoadPic(source.Tables[0].Rows[0]["CER_PIC"]);
                    m_CerFile = source.Tables[0].Rows[0]["CER_FILE"].ToString();
                    axTextBox2.SetValue(source.Tables[0].Rows[0]["WEB_ADDR"].ToString());
                    Txt_Disaddr.SetValue(source.Tables[0].Rows[0]["DIS_ADDR"].ToString());
                    if (string.IsNullOrEmpty(m_CerFile))
                    {
                        button3.Visible = false;
                    }
                    else
                    {
                        button3.Visible = true;
                    }

                }
                else
                {
                    InitCtl();
                }
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
        public static byte[] HexStringToBytes(string s)
        {
            const string HEX_CHARS = "0123456789ABCDEF";

            if (s.Length == 0)
                return new byte[0];

            if ((s.Length + 1) % 3 != 0)
                throw new FormatException();

            byte[] bytes = new byte[(s.Length + 1) / 3];

            int state = 0; // 0 = expect first digit, 1 = expect second digit, 2 = expect hyphen
            int currentByte = 0;
            int x;
            int value = 0;

            foreach (char c in s)
            {
                switch (state)
                {
                    case 0:
                        x = HEX_CHARS.IndexOf(Char.ToUpperInvariant(c));
                        if (x == -1)
                            throw new FormatException();
                        value = x << 4;
                        state = 1;
                        break;
                    case 1:
                        x = HEX_CHARS.IndexOf(Char.ToUpperInvariant(c));
                        if (x == -1)
                            throw new FormatException();
                        bytes[currentByte++] = (byte)(value + x);
                        state = 2;
                        break;
                    case 2:
                        if (c != '-')
                            throw new FormatException();
                        state = 0;
                        break;
                }
            }

            return bytes;
        }
        private string GetBytesToString(byte[] bytes)
        {
            if (bytes == null)
            { return ""; }
            return BitConverter.ToString(bytes);
        }
        private byte[] GetstringToByte(string byString)
        {
            return HexStringToBytes(byString);
        }
        #endregion
        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            if (imageIn != null)
            {
                using (var ms = new MemoryStream())
                {
                    imageIn.Save(ms, imageIn.RawFormat);
                    return ms.ToArray();
                }
            }
            return null;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "PNG File (*.PNG)|*.PNG";

                DialogResult result = ofd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = System.Drawing.Image.FromFile(ofd.FileName);


                }
            }
            catch (Exception eLog)
            {

            }
            finally
            {
            }
        }

        private void LoadPic(object strData)
        {
            byte[] data = GetstringToByte(strData.ToString());
            if (data != null && data.Length > 0)
            {
                using (Stream stream = new MemoryStream(data))
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = System.Drawing.Image.FromStream(stream);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "pfx File (*.pfx)|*.pfx";

                DialogResult result = ofd.ShowDialog();
                using (FileStream sr = new FileStream(ofd.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    int length = Convert.ToInt32(sr.Length);
                    byte[] data = new byte[length];
                    sr.Read(data, 0, length);
                    m_CerFile = GetBytesToString(data);
                }

            }
            catch (Exception eLog)
            {

            }
            finally
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_CerFile.ToString()) == false)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "pfx File (*.pfx)|*.pfx";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream sr = File.Create(dlg.FileName))
                    {
                        byte[] data = GetstringToByte(m_CerFile);
                        sr.Write(data, 0, data.Length);
                        sr.Flush();
                    }
                }
            }
        }

        private void cbo01_BIZCD_SelectedValueChanged(object sender, EventArgs e)
        {
            DispPlantCD();
        }

    }
}

