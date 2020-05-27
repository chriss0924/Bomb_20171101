using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Bomb.Log;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using APISocket;


namespace Bomb
{
    public partial class Bomb : Form
    {
        #region "reference"
        public string strTest = "no bomb";
      
        private byte[] bytes = new byte[1024];

        bool isTestMode = true;
        uint TestModeCount = 0;

        uint BombCount = 0;
        int BombIndex = 0;

        bool isGotBom = false;

        string BLID="123";

        APISocks BombSocks = new APISocks();
    
        #endregion

        

        WebReference.BL_API_BOMB apibomb = new WebReference.BL_API_BOMB();
        public BombInfo m_BombInfo = new BombInfo();


        public Bomb()
        {
            Logger.InitConfig();
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool bReadFileOK = Deserialize<BombInfo>(@"d:\API\Bomb\BombInfo.xml", ref m_BombInfo);

            if (!bReadFileOK)
            {
                MessageBox.Show("Read Config Error!");
               // this.Close();
            }

            BombSocks.Receiving += new APISocket.APIEvenHandle(Reciving);
            BombSocks.StatusChange += new APISocket.APIEvenHandle(StatusChange);
            BombSocks.initServer("127.0.0.1", 5678);
        }

        private void StatusChange(object sender, APISocket.APISocksEventArgs e)
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    if (e.status == APISocket.APISocks.SocketStatus.Connected)
                        PanelACP.BackColor = Color.FromArgb(0, 255, 0);
                    if (e.status == APISocket.APISocks.SocketStatus.DisConnected)
                        PanelACP.BackColor = Color.FromArgb(255, 0, 0);
                }
                ));
            }
            catch (Exception ex)
            {
                Logger.Bomb.Error(ex.ToString());
            }

        }

        private void Reciving(object sender, APISocket.APISocksEventArgs e)
        {
            try
            {
                 this.Invoke(new Action(() =>
                {
                    txtACPRecive.Text = e.msg;
                    //InspectCenter(e.msg);

                }
                ));


                 if (e.msg.Length > 5)
                 {
                     string[] sp = e.msg.Split(',');

                     if (sp.Length >= 1)
                     {
                         if (sp[0] == "GETBOMB")
                         {
                             if (sp.Length == 2)
                             {
                                 BLID = sp[1];
                                 isGotBom = true;
                                 GetBomb(m_BombInfo.Fab, m_BombInfo.EQ, sp[1]);
                             }

                         }
                         else if (sp[0] == "BOMBRESULT")
                         {
                             if (isGotBom)
                             {
                                 //BOMBRESULT,count,Def1X,def1y,.....
                                 if (sp.Length >= 2)
                                 {
                                     int count = int.Parse(sp[1]);
                                     List<BombPoint> bps = new List<BombPoint>();

                                     int i,j;

                                     for ( i = 0; i < count; i++)
                                     {
                                         BombPoint bp = new BombPoint();
                                         bp.X =(int)( float.Parse(sp[2 + i * 2])*(float)m_BombInfo.ResolutionX);
                                         bp.Y = (int)(float.Parse(sp[2 + i * 2 + 1]) * (float)m_BombInfo.ResolutionY);

                                         bps.Add(bp);

                                     }
                                     int match = 0;

                                     double xx, yy;
                                     for (i = 0; i < m_BombInfo.Bombs[BombIndex].Count; i++)
                                     {

                                         for (j = 0; j < bps.Count; j++)
                                         {
                                             xx = m_BombInfo.Bombs[BombIndex][i].X - bps[j].X;
                                             yy = m_BombInfo.Bombs[BombIndex][i].Y - bps[j].Y;

                                             if (Math.Sqrt(xx * xx + yy * yy) < 20)
                                                 match++;


                                         }
                                     }
                                     string result = "NG";

                                     if (match == m_BombInfo.Bombs[BombIndex].Count)
                                         result = "OK";

                                     string xyResult="";

                                     for(i=0;i< bps.Count;i++)
                                     {
                                         var bp = bps[i];

                                         xyResult += GetZone(bp, m_BombInfo.ResolutionX, m_BombInfo.ResolutionY).ToString()
                                                     + "(" + bp.X + "," + bp.Y + ")";

                                         if (i != bps.Count - 1)
                                             xyResult += ";";

                                                

                                     }

                                     
                                     string strBombRep ="OK";
                                     if(!isTestMode)
                                         strBombRep = apibomb.GetBombResult(m_BombInfo.Fab, m_BombInfo.EQ, BLID, "White", xyResult, result);

                                     Logger.socket.Info("Send to Web Service: "+m_BombInfo.Fab+","+m_BombInfo.EQ+","+ BLID+","+ "White"+xyResult +"," +result);

                                     this.Invoke(new Action(() =>
                                     {
                                         textBomSend.Text="Send Bomb Result!";
                                         txtBombRecive.Text = strBombRep;
                                     }
                                     ));

                                 }
                             }
                         }


                     }

                 }
            }
            catch (Exception ex)
            {
                Logger.Bomb.Error(ex.ToString());
            }
        }

        private string GetBomb(string Fab, string EQ, string BLID)
        {
            string Result = "NO";

             try
            {
                
                #region "step1 call bomb API"
                string strRsp = "";

                if (!isTestMode)
                    strRsp = apibomb.GetBombInformation(Fab, EQ, BLID);

                else
                {
                    if (TestModeCount  % 2 == 0)
                        strRsp = "";
                    else
                        strRsp = "BOMB";

                    TestModeCount++;

                }


                 Logger.socket.Info("receive Rsp : " + strRsp);
            

                #endregion

                #region "step2 judge response bomb YES or NO"

                //後續寧波跟廠商會再討論：(1)空字串為無法連線。(2)沒炸彈變成BOMB$NO
                //現階段先照寧波的方式
                if (strRsp == "")  //沒炸彈
                {
                    BombSocks.Send("NOBOMB");

                    this.Invoke(new Action(() =>
                    {
                        txtBombRecive.Text = "No Bomb";
                        //InspectCenter(e.msg);

                    }
                    ));
                    //丟資料，bomb to ACP
                    //SendData(strRsp);
                }
                else  //有炸彈，所以進到判斷比對流程
                {
                    if (m_BombInfo.Bombs.Count != 0)
                    {
                        BombCount ++;
                        BombIndex = (int)(BombCount % (uint)(m_BombInfo.Bombs.Count));


                        if (m_BombInfo.Bombs[BombIndex].Count != 0)
                        {
                            string bombMsg = "BOMB" + "," + m_BombInfo.Bombs[BombIndex].Count.ToString();
                            float xx,yy;

                            foreach (BombPoint bp in m_BombInfo.Bombs[BombIndex])
                            {
                                xx = (float)bp.X/(float)m_BombInfo.ResolutionX;
                                yy = (float)bp.Y/(float)m_BombInfo.ResolutionY;



                                if(xx>1)
                                    xx =1;
                                if(xx<0)
                                    xx=0;
                                if (yy > 1)
                                    yy = 1;
                                if(yy<0)
                                    yy=0;

                                bombMsg+=","+xx.ToString()+
                                         ","+yy.ToString()+
                                         ","+bp.Diameter.ToString()+
                                         ","+bp.GrayDiff.ToString();
                            }

                            BombSocks.Send(bombMsg);

                        }
                        else
                        {
                            Logger.Bomb.Error("No Bomb Point!");
                            MessageBox.Show("No Bomb Point!");
                        }


                    }
                    else
                    {
                        Logger.Bomb.Error("No Bomb Point!");
                        MessageBox.Show("No Bomb Point!");
                    }





                    this.Invoke(new Action(() =>
                    {
                        txtBombRecive.Text = "Got Bomb!";
                        labBombIndex.Text = BombIndex.ToString();

                    }
                    ));
                
                }
                #endregion
            }
            catch (Exception ex)
            {
                Logger.socket.Debug(ex.ToString());
               
            }

             return Result;
        }

        private int GetZone(BombPoint bp,int ResolutionX, int ResolutionY)
        {

            double x = (double)bp.X / (double)ResolutionX;

            double y = (double)bp.Y / (double)ResolutionY;

            int i=1;
            int j=1;

            if (x < 0.33333)
                i = 1;
            else if (x < 0.66666)
                i = 2;
            else
                i = 3;

            if (y < 0.33333)
                j = 0;
            else if (y < 0.66666)
                j = 1;
            else
                j = 2;

            int Zone = 1;
            
            Zone = j * 3 + i;


            return Zone;
        }




        private void btnGenBomb_Click(object sender, EventArgs e)
        {
            try
            {
                
                #region "step1 call bomb API"
                string strRsp = "";
              //  strRsp = apibomb.GetBombInformation(txtFab.Text, txtEquipmentID.Text, txtLotID.Text);
                Logger.socket.Info("receive Rsp : " + strRsp);
                //以下測試
                strRsp = "";

                #endregion

                #region "step2 judge response bomb YES or NO"

                //後續寧波跟廠商會再討論：(1)空字串為無法連線。(2)沒炸彈變成BOMB$NO
                //現階段先照寧波的方式
                if (strRsp == "")  //沒炸彈
                {
                    //label12.Text = "BOMB NO";
                    //label12.ForeColor = System.Drawing.Color.Red;
                    //label12.Visible = true;
                    //Logger.socket.Info("strRsp is : " + strRsp);
                    //strRsp = "BOMB$NO";
                    //丟資料，bomb to ACP
                   // SendData(strRsp);
                }
                else  //有炸彈，所以進到判斷比對流程
                {
                    //label12.Text = "BOMB YES";
                    //label12.ForeColor = System.Drawing.Color.Blue;
                    //label12.Visible = true;
                    //Logger.socket.Info("strRsp is : " + strRsp);

                    #region "step3 bomb YES and call web API"

                    string strBombRep = "";
                    string strZone1 = "";
                    string strZone2 = "";
                    string strMergeZone = "";

                    //座標轉成寧波要的格式，但後續還要再修改
                    //strZone1 = txtZone1.Text + "(" + txtZone1_X.Text + "," + txtZone1_Y.Text + ")";
                    //Logger.socket.Debug("strZone1 is : " + strZone1);
                    //strZone2 = txtZone2.Text + "(" + txtZone2_X.Text + "," + txtZone2_Y.Text + ")";
                    //Logger.socket.Debug("strZone2 is : " + strZone2);

                    //if (txtZone1.Text == "")
                    //{
                    //    strMergeZone = strZone2;
                    //    Logger.socket.Debug("only Zone2 is : " + strMergeZone);
                    //}
                    //else if (txtZone2.Text == "")
                    //{
                    //    strMergeZone = strZone1;
                    //    Logger.socket.Debug("only Zone1 is : " + strMergeZone);
                    //}
                    //else
                    //    strMergeZone = strZone1 + ";" + strZone2;
                    //Logger.socket.Info("MergeZone is : " + strMergeZone);

                    ////send compare result to API
                    //strBombRep = apibomb.GetBombResult(txtFab.Text, txtEquipmentID.Text, txtLotID.Text, txtPicName.Text, strMergeZone, "");
                    //Logger.socket.Info("step3 compare bomb result : " + strBombRep);

                    //if (strBombRep == "NG")
                    //{
                    //    label12.Text = "NG";
                    //    label12.ForeColor = System.Drawing.Color.Red;
                    //    label12.Visible = true;
                    //    Logger.socket.Info("strBombRep is : " + strBombRep);
                    //}
                    //else if (strBombRep == "")
                    //{
                    //    label12.Text = "OK";
                    //    label12.ForeColor = System.Drawing.Color.Blue;
                    //    label12.Visible = true;
                    //    Logger.socket.Info("strBombRep is : " + strBombRep);
                    //}
                    //label12.Update();
                    #endregion
                }
                #endregion
            }
            catch (Exception ex)
            {
                Logger.socket.Debug(ex.ToString());
                throw ex;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            #region "參數"
            
            #endregion

            #region "建立server"
            //MySocket.initServer("127.0.0.1",5566);
            do
            {
                try
                {
                    System.Net.IPAddress theIPAddress;
                    theIPAddress = System.Net.IPAddress.Parse("127.0.0.1");
                    TcpListener myTcpListener = new TcpListener(theIPAddress, 36000);
                    myTcpListener.Start();
                    //SockSender = myTcpListener.AcceptSocket();
                    //if (SockSender.Connected)
                    //{
                    //    int dataLength;
                    //    label4.Text = "Connect OK";
                    //    byte[] myBufferBytes = new byte[1000];
                    //    dataLength = SockSender.Receive(myBufferBytes);
                    //    string strEncode = Encoding.ASCII.GetString(myBufferBytes, 0, dataLength);
                    //    txtFormalFab.Text = strEncode;
                    //}
                }
                catch
                {
                }
            } while (true);

            #endregion

            #region "step1 將資訊傳給web API"
            //廠別 --> 可以設計UI讓使用者填入
            //設備 --> 可以設計UI讓使用者填入
            //BL_ID --> 看哪邊傳給光學並讓光學將ID帶入web API之中
            //string strFormalFab = txtFormalFab.Text;
            //string strFormalEquID = txtFormalEquID.Text;


            #endregion

            #region "step2 判斷要不要出炸彈"
            //no --> 對方目前會回傳空字串
            //yes --> BOMB$YES，這時候走流程三

            #region "step3 API與炸彈兩者結果比對"
            //這邊要得知 1.圖片ID  2.defect座標
            //API要給1~n各defect座標並帶入web API裡面進行比對
            //全部defect與全部炸彈都有命中則會回傳OK，少掉一個則會回傳NG
            #endregion

            #endregion
        }


        public static bool Serialize<T>(string strPath, object clsData)
        {
            bool iStt = true;
            XmlWriterSettings clsXmlSettings = null;
            XmlWriter clsXmlWriter = null;
            XmlSerializer clsXmlSerializer = null;
            XmlSerializerNamespaces clsXmlSerializerNamespaces = null;
            try
            {
                clsXmlSettings = new XmlWriterSettings();
                clsXmlSettings.NewLineHandling = NewLineHandling.None;
                clsXmlSettings.Indent = true;

                using (clsXmlWriter = XmlWriter.Create(strPath, clsXmlSettings))
                {
                    clsXmlSerializer = new XmlSerializer(clsData.GetType());
                    clsXmlSerializerNamespaces = new XmlSerializerNamespaces();
                    clsXmlSerializerNamespaces.Add(string.Empty, string.Empty);
                    clsXmlSerializer.Serialize(clsXmlWriter, clsData, clsXmlSerializerNamespaces);
                    clsXmlWriter.Close();
                }
            }
            catch (Exception ex)
            {
                iStt = false;

                Logger.Bomb.Error("Serialize:" + ex.ToString());
            }
            return iStt;
        }



        /// <summary>反序列化 Xml 文件中的資料轉成物件資料。。</summary>
        /// <typeparam name="T">型別，可能為自訂的 Class or 其他基本型別。</typeparam>
        /// <param name="strPath">檔案路徑。</param>
        /// <param name="clsData">物件資料。</param>
        /// <returns>執行結果狀態碼 XErrorCode 。</returns>
        public static bool Deserialize<T>(string strPath, ref T clsData)
        {
            bool iStt = true;
            object clsTempData = null;
            FileStream clsFileStream = null;
            XmlSerializer clsXmlSerializer = null;
            XmlReader clsXmlReader = null;
            try
            {
                using (clsFileStream = new FileStream(strPath, FileMode.Open))
                {
                    clsXmlSerializer = new XmlSerializer(typeof(T));
                    clsXmlReader = XmlReader.Create(clsFileStream);
                    clsTempData = (T)clsXmlSerializer.Deserialize(clsXmlReader);

                    if (clsTempData != null)
                    {
                        clsData = (T)clsTempData;
                    }
                    else
                    {
                        clsData = default(T);
                    }

                    clsXmlReader.Close();
                    clsFileStream.Close();
                }
            }
            catch (Exception ex)
            {
                iStt = false;
                Logger.Bomb.Error("DeSerialize:" + ex.ToString());
            }
            return iStt;
        }

      

        private void OnClosing(object sender, FormClosingEventArgs e)
        {
            BombSocks.Dispose();
        }

        private void OnClickStatus(object sender, MouseEventArgs e)
        {
             try
             {
                 BombInfo bi = new BombInfo();
                 if (m_BombInfo.Bombs.Count == 0)
                 {
                     BombPoint bp = new BombPoint();                 
                     List<BombPoint> bps = new List<BombPoint>();
                     bps.Add(bp);
                     bi.Bombs.Add(bps);

                     BombPoint bp2 = new BombPoint();
                     List<BombPoint> bps2 = new List<BombPoint>();
                     bps2.Add(bp2);

                     bi.Bombs.Add(bps2);


                 }

                 Serialize<BombInfo>(@"d:\BombInfo.xml", bi);
             }
             catch (Exception ex)
             {
                 Logger.Bomb.Error("DeSerialize:" + ex.ToString());
             }

        }

        private void label17_Click(object sender, EventArgs e)
        {
            BombSocks.Send("QQ");
        }
    }

    public class BombInfo
    {
        public string Fab = "LCM3";
        public string EQ = "BLAPI07";
        public int ResolutionX = 1366;
        public int ResolutionY = 768;

        public List<List<BombPoint>> Bombs = new List<List<BombPoint>>();


    }

    public class BombPoint
    {
       public int X = 10;
       public int Y = 10;
       public int Diameter = 10;
       public int GrayDiff = 20;   
    }
   

}
