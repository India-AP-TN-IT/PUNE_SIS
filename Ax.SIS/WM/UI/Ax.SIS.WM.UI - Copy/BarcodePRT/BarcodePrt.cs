using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ax.SIS.WM.UI.BarcodePRT
{
    public class BarcodePrt
    {
        private bool m_bInit = true;
        private System.Net.Sockets.Socket m_TCP = null;
        private bool m_InnerConnected = false;
        private Encoding m_Encode = Encoding.ASCII;
        private string m_IpOrComPort = "";
        private int m_PortOrBaud = 0;
        public bool IsConnected
        {
            get { return m_InnerConnected; }
        }
        public void Write(string data)
        {
            if (m_InnerConnected == false)
            {
                throw new Exception("Printer Connection Error");
            }
            try
            {

                
                try
                {
                    m_TCP.Send(m_Encode.GetBytes(data));
                }
                catch (Exception innerSoeck)
                {
                    Close();
                    string error = "";
                    OpenDevice(m_IpOrComPort, m_PortOrBaud, out error);
                }
                

            }
            catch (Exception eLog)
            {

            }
        }
        public void Close()
        {
            m_TCP.Close();
        }
        public bool OpenDevice(string ip, int port, out string errMsg)
        {
            m_IpOrComPort = ip;
            m_PortOrBaud = port;
            
            errMsg = "";
            try
            {



                m_TCP = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
                m_TCP.SetSocketOption(System.Net.Sockets.SocketOptionLevel.Socket, System.Net.Sockets.SocketOptionName.DontLinger, false);

                var result = m_TCP.BeginConnect(ip, port, null, null);

                var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(1));


                m_InnerConnected = success;
                return success;
            }
            catch (Exception ex)
            {
                errMsg = "[" + ip + "][" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]" + ex.Message;
                return false;
            }
            finally
            {
                if (m_bInit)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(thAutoReply);
                    m_bInit = false;
                }
            }
        }
        private void thAutoReply(object arg)
        {

            try
            {
                do
                {
                    string errMsg = "";
                    try
                    {


                        if (m_TCP != null && m_TCP.Connected)
                        {
                            Write("TEST");
                        }
                        else if (m_TCP == null || (m_TCP != null && m_TCP.Connected == false))
                        {
                            System.Diagnostics.Debug.WriteLine("[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]Barcode Printer is Disconnected(" + m_IpOrComPort + ":" + m_PortOrBaud + ")");
                            m_InnerConnected = false;
                        }
                    }
                    catch (Exception innerEX)
                    {
                        System.Diagnostics.Debug.WriteLine("[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "/INNER]" + innerEX.Message.ToString());
                        m_InnerConnected = false;
                    }

                    if (m_InnerConnected == false)
                    {
                        OpenDevice(m_IpOrComPort, m_PortOrBaud, out errMsg);
                    }
                    System.Threading.Thread.Sleep(10000);
                } while (true);
            }
            catch (Exception eLog)
            {

                System.Diagnostics.Debug.WriteLine("[" + System.Reflection.MethodBase.GetCurrentMethod().Name + "]" + eLog.Message.ToString());
            }
            finally
            {

            }
        }

        public void Header(int xPos = 0, int yPos = 0)
        {
            Write("^XA\n");
            Write("^LH" + xPos.ToString() + "," + yPos.ToString() + "\n");
        }

        public void Body(string data)
        {
            Write(data);
        }

        public void Footer()
        {
            Write("^PQ" + "1" + "^FS");
            Write("^XZ");
        }


        
    }
}
