using System;
using System.IO;
using System.Data;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.Collections;
using System.Windows.Forms;
using System.ServiceProcess;

namespace Ax.MailSenderService
{
    /// <summary>
    /// MailSender Service Program (SIS.AXD6000 Table Using)
    /// </summary>
    public partial class Service : ServiceBase
    {
        private JISDbAccessor _JISDbAccessor;
        private string _SMTP_IP;
        private string _SMTP_ID;
        private string _SMTP_PWD;

        public Service()
        {
            InitializeComponent();

            this._Timer.Interval = 5000;

            this._Timer.Interval = double.Parse(ConfigurationManager.AppSettings["INTERVAL"].ToString());
            string _connectString = ConfigurationManager.AppSettings["DB"];
            _JISDbAccessor = new JISDbAccessor(_connectString);
            _SMTP_IP = ConfigurationManager.AppSettings["SMTP_SERVER"];
            _SMTP_ID = ConfigurationManager.AppSettings["SMTP_ID"];
            _SMTP_PWD = ConfigurationManager.AppSettings["SMTP_PWD"];
        }

        private void _Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                _Timer.Enabled = false;

                this.Mail_Send();

                _Timer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Mail_Send()
        {
            try
            {
                #region [전송 매서드 모음]

                DataSet source = this.Inquery_Send_Mail_List();

                if (source == null || source.Tables[0].Rows.Count == 0) return;

                foreach (DataRow row in source.Tables[0].Rows)
                    if (!Begin_Mail_Send(row)) continue;

                #endregion
            }
            catch (Exception ex)
            {
                this.TextFilesLog("Error : mail send", ex.ToString());
            }
        }

        private DataSet Inquery_Send_Mail_List()
        {
            try
            {
                string commandBody = ConfigurationManager.AppSettings["PACKAGE_INQUERY"]; //"APG_XM_SENDMAIL.INQUERY";

                SqlParameters parameter_Body = new SqlParameters();
                parameter_Body.Add("OUT$OUT_CURSOR", null);

                _JISDbAccessor.CommandClear();
                _JISDbAccessor.Attach(CommandType.StoredProcedure, commandBody, parameter_Body);
                return _JISDbAccessor.ExecuteDataSet();
            }
            catch (Exception ex)
            {
                TextFilesLog("Error : get mail list", ex.ToString());
                return null;
            }
        }

        private bool Begin_Mail_Send(DataRow row)
        {
            try
            {
                string rowid = row["ROW_ID"].ToString();
                string From = row["MAIL_FROM"].ToString();
                string To = row["MAIL_TO"].ToString();
                string cc = row["MAIL_CC"].ToString();
                string bcc = row["MAIL_BCC"].ToString();
                string Subject = row["MAIL_SUBJECT"].ToString();
                string Body = row["MAIL_BODY"].ToString();                
                bool ishtml = row["MAIL_HTML_YN"].ToString().ToUpper().Equals("Y");
                string fileName = (row["FILE_NAME"] is DBNull ? string.Empty : row["FILE_NAME"].ToString());
                byte[] fileData = (row["FILE_DATA"] is DBNull ? null : (byte[])row["FILE_DATA"]);

                if (!MailSend(From, To, cc, bcc, Subject, Body, ishtml, fileName, fileData))
                    return false;
                else
                {
                    if (Update_Send_Mail_State(rowid))
                        TextFilesLog("Success : send mail", string.Format("From:{0}\r\nTo:{1}\r\nSubject:{2}", From, To, Subject));
                    else
                        return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                TextFilesLog("Error : create mail data", ex.ToString());
                return false;
            }
        }

        private bool Update_Send_Mail_State(string ROWID)
        {
            try
            {
                string commandBody = ConfigurationManager.AppSettings["PACKAGE_SAVE"]; //"APG_XM_SENDMAIL.SAVE";

                SqlParameters parameter_Body = new SqlParameters();
                parameter_Body.Add("IN_ROW_ID", ROWID);

                _JISDbAccessor.CommandClear();
                _JISDbAccessor.Attach(CommandType.StoredProcedure, commandBody, parameter_Body);
                _JISDbAccessor.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                TextFilesLog("Error : get mail list", ex.ToString());
                return false;
            }
        }

        private bool MailSend(string From, string To, string Subject, string Body, bool html, string fileName, byte[] fileData)
        {
            try
            {
                MailMessage mail = new MailMessage();
                MailAddress maFROM = new MailAddress(From);
                MailAddress maTO = new MailAddress(To);

                mail.From = maFROM;                
                mail.To.Add(maTO);
                mail.Subject = Subject;
                mail.Body = Body;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = html;

                MemoryStream ms = null;

                if (fileData != null && fileData.Length > 0 && !string.IsNullOrEmpty(fileName))
                {
                    ms = new MemoryStream(fileData);
                    ms.Position = 0;
                    mail.Attachments.Add(new Attachment(ms, fileName));
                }

                SmtpClient smtp = new SmtpClient(_SMTP_IP);
                smtp.Send(mail);

                if (ms != null) ms.Close();

                return true;
            }
            catch (Exception ex)
            {
                TextFilesLog("Error : mail send", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// 메일발송 메서드
        /// </summary>
        /// <param name="From">발신자</param>
        /// <param name="To">수신자</param>
        /// <param name="cc">참조</param>
        /// <param name="bcc">숨은참조</param>
        /// <param name="Subject">제목</param>
        /// <param name="Body">내용</param>
        /// <param name="html">HTML 여부(</param>
        /// <returns></returns>
        private bool MailSend(string From, string To, string cc, string bcc, string Subject, string Body, bool html, string fileName, byte[] fileData)
        {
            try
            {
                MailMessage mail = new MailMessage();
                MailAddress maFROM = new MailAddress(From);
                //MailAddress maTO = new MailAddress(To);
                
                mail.From = maFROM;
                //mail.To.Add(To);

                // To 멀티 메일 및 "오세민" <ohsm@seoyoneh.com> 문제를 해결하기 위해 by 2016.05.31 오세민
                if (!string.IsNullOrEmpty(To))
                {
                    foreach (string str in To.Split(',',';'))
                    {
                        mail.To.Add(new MailAddress(str.Trim()));
                    }
                }

                // CC 멀티 메일 및 "오세민" <ohsm@seoyoneh.com> 문제를 해결하기 위해 by 2016.09.08 김건우
                if (!string.IsNullOrEmpty(cc))
                {
                    foreach (string str in cc.Split(',', ';'))
                    {
                        mail.CC.Add(new MailAddress(str.Trim()));
                    }
                }

                //BCC 멀티 메일 및 "오세민" <ohsm@seoyoneh.com> 문제를 해결하기 위해 by 2016.09.08 김건우
                if (!string.IsNullOrEmpty(bcc))
                {
                    foreach (string str in bcc.Split(',', ';'))
                    {
                        mail.Bcc.Add(new MailAddress(str.Trim()));
                    }
                }
                mail.Subject = Subject;
                mail.Body = Body;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = html;

                MemoryStream ms = null;

                if (fileData != null && fileData.Length > 0 && !string.IsNullOrEmpty(fileName))
                {
                    ms = new MemoryStream(fileData);
                    ms.Position = 0;
                    mail.Attachments.Add(new Attachment(ms, fileName));
                }

                SmtpClient smtp = new SmtpClient(_SMTP_IP);
                smtp.Credentials = new System.Net.NetworkCredential(_SMTP_ID, _SMTP_PWD);
                smtp.Send(mail);

                if (ms != null) ms.Close();

                return true;
            }
            catch (Exception ex)
            {
                TextFilesLog("Error : mail send", ex.ToString());
                return false;
            }
        }
        public void TextFilesLog(string div, string message)
        {
            string logDirectory = String.Format(@"C:\Temp\Ax.MailSenderService");
            string logFileName = String.Format(@"{0}\{1:yyyyMMdd}_Mail.log", logDirectory, DateTime.Now);
            if (!Directory.Exists(logDirectory))
                Directory.CreateDirectory(logDirectory);

            string delFileName = "";

            if (Directory.GetFiles(logDirectory, "*.log").Length > 15)
            {
                ArrayList files = new ArrayList();

                foreach (string file in Directory.GetFiles(logDirectory))
                    files.Add(file);

                files.Sort();

                delFileName = files[0].ToString();
            }

            FileStream stream = null;
            StreamWriter writer = null;

            try
            {
                if (File.Exists(delFileName)) File.Delete(delFileName);

                stream = (!File.Exists(logFileName)) ?
                    new FileStream(logFileName, FileMode.Create, FileAccess.Write) :
                    new FileStream(logFileName, FileMode.Append, FileAccess.Write);
                writer = new StreamWriter(stream);
                writer.WriteLine(String.Format("######### {0:yyyy.MM.dd HH:mm:ss.fff} Log #########", DateTime.Now));
                writer.Write("[{0}] : \r\n{1}", div, message);
                writer.WriteLine();
                writer.WriteLine();
                writer.Flush();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (writer != null)
                    writer.Close();

                if (stream != null)
                    stream.Close();
            }
        }


        protected override void OnStart(string[] args)
        {
            try
            {
                _Timer.Enabled = true;
                _Timer.Start();
                _Timer_Elapsed(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        protected override void OnStop()
        {
            try
            {
                _Timer.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
