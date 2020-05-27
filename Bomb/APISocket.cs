using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Bomb.Log;


namespace APISocket
{


    public delegate void APIEvenHandle(object sender, APISocksEventArgs e);

    /// <summary>通訊專用事件資料物件。</summary>
    public class APISocksEventArgs
    {
        public string msg;
        public APISocks.SocketStatus status;

    }

    public class APISocks : IDisposable
    {
        // 0: not init
        // 1: Server
        // 2: Client
        private int MySocksType = 0;

        public Socket socket = null;
        List<Socket> Connected_Sockets = new List<Socket>();

        TcpListener TcpListener;
        private Thread g_thrAutoListenThread;

        string IP;
        int Port;

        public bool ServerStop = false;

        bool StopRecive = false;
        public bool StopConnect = false;
        public SocketStatus m_Status = SocketStatus.DisConnected;

        private Thread ReciveThread;

        private Thread ConnectThread = null;
        bool isConnecting = false;


        public event APIEvenHandle Receiving;
        public event APIEvenHandle Sending;
        public event APIEvenHandle StatusChange;

        public enum SocketStatus
        {

            /// <summary>已連線。</summary>
            Connected,

            /// <summary>段線。</summary>
            DisConnected,

        }



        public APISocks()
        {
        }

        public void initServer(string IP, int port)
        {
            try
            {

                MySocksType = 2;


                Port = port;

                m_Status = SocketStatus.DisConnected;

                //TcpListener = new TcpListener(IPAddress.Parse(IP), port);
                //TcpListener.Start();

                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);



                socket.Bind(new IPEndPoint(IPAddress.Parse(IP), port));

                socket.Listen(10);

                g_thrAutoListenThread = new Thread(StartListen);
                g_thrAutoListenThread.Name = "Server listen!";
                g_thrAutoListenThread.Start();

                Logger.Bomb.Info("Server Start Listen!");

            }
            catch (Exception ex)
            {
                Logger.Bomb.Error(ex.ToString());
            }

        }


        public void StartListen()
        {
            try
            {
                Socket cls_client = null;

                while (!ServerStop)
                {
                    cls_client = socket.Accept();

                    Connected_Sockets.Add(cls_client);

                    ParameterizedThreadStart thrServerRecive;
                    thrServerRecive = new ParameterizedThreadStart(ServerReciver);
                    Thread thr1 = new Thread(thrServerRecive);
                    thr1.Start(cls_client);

                    byte[] byteArray;

                    byteArray = System.Text.Encoding.Default.GetBytes("Hi");

                    cls_client.Send(byteArray);
                    CheckConnectSocket();

                    APISocksEventArgs mye = new APISocksEventArgs();
                    mye.msg = "";
                    mye.status = SocketStatus.Connected;
                    if (StatusChange != null)
                        StatusChange(this, mye);

                    Logger.Bomb.Info("Client Connect");
                }
            }
            catch (Exception ex)
            {
                Logger.Bomb.Error(ex.ToString());

            }
        }

        private void ServerReciver(object obj)
        {
            Socket clsSocket = (Socket)obj;
            try
            {


                byte[] data = new byte[100];
                int length = 0;
                string str;

                while (true)
                {

                    length = clsSocket.Receive(data);

                    if (length != 0)
                    {
                        str = System.Text.Encoding.Default.GetString(data);

                        str = str.Substring(0, length);

                        APISocksEventArgs mye = new APISocksEventArgs();
                        mye.msg = str;
                        if (Receiving != null)
                            Receiving(this, mye);

                        Logger.Bomb.Info("Recive :" + str);

                    }
                    else
                        break;
                }

                APISocksEventArgs mye2 = new APISocksEventArgs();
                mye2.msg = "";
                mye2.status = SocketStatus.DisConnected;
                if (StatusChange != null)
                    StatusChange(this, mye2);

                clsSocket.Disconnect(true);
                clsSocket.Close();
                CheckConnectSocket();
            }
            catch (Exception ex)
            {
                APISocksEventArgs mye2 = new APISocksEventArgs();
                mye2.msg = "";
                mye2.status = SocketStatus.DisConnected;
                if (StatusChange != null)
                    StatusChange(this, mye2);

                CheckConnectSocket();
            }


        }



        public void CheckConnectSocket()
        {
            try
            {
                int i;
                for (i = 0; i < Connected_Sockets.Count; i++)
                {
                    try
                    {
                        if (Connected_Sockets[i].Connected == false)
                        {

                            Connected_Sockets[i].Close();
                            Connected_Sockets.RemoveAt(i);
                            i--;
                        }
                    }
                    catch
                    {

                    }

                }
            }
            catch
            {
            }

        }





        public void InitClient(string ip, int port)
        {
            try
            {
                if (MySocksType == 0)
                    MySocksType = 1;

                IP = ip;
                Port = port;

                StopConnect = false;

                m_Status = SocketStatus.DisConnected;

                Connect();

            }
            catch (Exception ex)
            {
                Logger.Bomb.Error(ex.ToString());
            }


        }

        public void Reciver()
        {
            try
            {
                byte[] data = new byte[100];
                string str;
                int length;
                bool needReconnect = false;


                while (true)
                {


                    length = socket.Receive(data);

                    if (length != 0)
                    {
                        str = System.Text.Encoding.Default.GetString(data);

                        str = str.Substring(0, length);

                        APISocksEventArgs mye = new APISocksEventArgs();
                        mye.msg = str;
                        if (Receiving != null)
                            Receiving(this, mye);

                        Logger.socket.Info("Recive :" + str);
                    }
                    else
                    {
                        needReconnect = true;
                        break;
                    }
                    if (StopRecive)
                        break;

                    if (socket.Connected == false)
                    {

                        break;
                    }

                }

                if (socket.Connected == false || needReconnect)
                {
                    StopRecive = true;

                    socket.Disconnect(true);

                    m_Status = SocketStatus.DisConnected;
                    APISocksEventArgs mye = new APISocksEventArgs();
                    mye.msg = "";
                    mye.status = SocketStatus.DisConnected;
                    if (StatusChange != null)
                        StatusChange(this, mye);

                    Connect();
                }

            }
            catch (Exception ex)
            {
                Logger.Bomb.Error(ex.ToString());

                StopRecive = true;

                m_Status = SocketStatus.DisConnected;
                APISocksEventArgs mye = new APISocksEventArgs();
                mye.msg = "";
                mye.status = SocketStatus.DisConnected;
                if (StatusChange != null)
                    StatusChange(this, mye);

                Connect();

            }

        }

        public void Send(string str)
        {
            if (MySocksType == 1)
                ClientSend(str);
            if (MySocksType == 2)
                ServertSend(str);


        }

        public void Send(byte[] data)
        {
            if (MySocksType == 1)
                ClientSend(data);
           
           


        }

        public void ServertSend(string str)
        {

            try
            {
                byte[] byteArray;
                bool SendOK = false;

                byteArray = System.Text.Encoding.Default.GetBytes(str);
                int i = 0;
                for (i = 0; i < Connected_Sockets.Count; i++)
                {
                    try
                    {
                        // if (Connected_Sockets[i].Connected)
                        {
                            Connected_Sockets[i].Send(byteArray);
                            SendOK = true;
                        }

                    }
                    catch
                    {
                    }

                }


                if (SendOK)
                {
                    Logger.socket.Info("Send :" + str);
                    APISocksEventArgs mye = new APISocksEventArgs();
                    mye.msg = str;

                    if (Sending != null)
                    {
                        Sending(this, mye);
                    }
                }




            }
            catch (Exception ex)
            {
                //Logger.socket.Error(ex.ToString());

                //m_Status = SocketStatus.DisConnected;

                //MyEventArgs mye = new MyEventArgs();
                //mye.msg = "";
                //mye.status = SocketStatus.DisConnected;
                //if (StatusChange != null)
                //    StatusChange(this, mye);



            }


        }



        public void ClientSend(string str)
        {
            try
            {
                byte[] byteArray;

                byteArray = System.Text.Encoding.Default.GetBytes(str);

                socket.Send(byteArray);

                Logger.Bomb.Info("Send :" + str);

                APISocksEventArgs mye = new APISocksEventArgs();
                mye.msg = str;

                if (Sending != null)
                {
                    Sending(this, mye);
                }
            }
            catch (Exception ex)
            {
                Logger.Bomb.Error(ex.ToString());

                StopRecive = true;
                m_Status = SocketStatus.DisConnected;

                APISocksEventArgs mye = new APISocksEventArgs();
                mye.msg = "";
                mye.status = SocketStatus.DisConnected;
                if (StatusChange != null)
                    StatusChange(this, mye);

                Connect();

            }
        }

        public void ClientSend(byte[] byteArray)
        {
            try
            {
             

                socket.Send(byteArray);

                string str = "Send byte[], Lenght = " + byteArray.Length;
                Logger.socket.Info(str);

                APISocksEventArgs mye = new APISocksEventArgs();
                mye.msg = str;

                if (Sending != null)
                {
                    Sending(this, mye);
                }
            }
            catch (Exception ex)
            {
                Logger.Bomb.Error(ex.ToString());

                StopRecive = true;
                m_Status = SocketStatus.DisConnected;

                APISocksEventArgs mye = new APISocksEventArgs();
                mye.msg = "";
                mye.status = SocketStatus.DisConnected;
                if (StatusChange != null)
                    StatusChange(this, mye);

                Connect();

            }
        }

        private void Connect()
        {
            if (isConnecting == false)
            {
                isConnecting = true;
                ConnectThread = new Thread(ConnectToServer);
                ConnectThread.IsBackground = true;
                ConnectThread.Name = "Connect " + IP.ToString();
                ConnectThread.Start();
            }
        }



        public void ConnectToServer()
        {

            try
            {

                Logger.Bomb.Info("Connect to " + IP + ":" + Port.ToString());


                while (true)
                {
                    try
                    {
                        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        m_Status = SocketStatus.DisConnected;
                        socket.Connect(IP, Port); // 1.設定 IP:Port 2.連線至伺服器
                        if (socket.Connected)
                        {
                            m_Status = SocketStatus.Connected;


                            APISocksEventArgs mye = new APISocksEventArgs();
                            mye.msg = "";
                            mye.status = SocketStatus.Connected;
                            if (StatusChange != null)
                                StatusChange(this, mye);


                            StopRecive = false;

                            ReciveThread = new Thread(Reciver);
                            ReciveThread.IsBackground = true;
                            ReciveThread.Name = "Client " + IP.ToString();
                            ReciveThread.Start();

                            isConnecting = false;
                            break;
                        }

                        Thread.Sleep(3000);
                    }
                    catch (Exception ex)
                    {

                        StopRecive = true;
                        Thread.Sleep(3000);
                    }

                    if (StopConnect)
                    {
                        isConnecting = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                isConnecting = false;
                Logger.Bomb.Error(ex.ToString());
            }


        }

        public void DisConnect()
        {
            try
            {
                StopConnect = true;

                if (socket.Connected)
                {
                    socket.Disconnect(true);

                }



            }
            catch (Exception ex)
            {
                Logger.Bomb.Error(ex.ToString());
            }

        }

        public void Dispose()
        {
            ServerStop = true;

            socket.Close();


            int i;
            for (i = 0; i < Connected_Sockets.Count; i++)
            {
                if (Connected_Sockets[i].Connected == true)
                {
                    Connected_Sockets[i].Close();

                }


            }



            Thread.Sleep(100);

        }





    }
  
}
