using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Net;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
//using InxAPILog;
//using AIP.Windows;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
//using RecipForm;
//using InxGeneral.Dialog;
using Bomb.Log;

public class GlobalParameters
{
    #region " Definition "

    public const char SLASHES = '\\';

    /// <summary>逗號。</summary>
    public const char COMMA = ',';

    /// <summary>句號。</summary>
    public const char PERIOD = '.';

    /// <summary>錢字符號。</summary>
    public const char DOLLAR_SIGN = '$';

    /// <summary> DalsaCameraLink 檔案副檔名。</summary>
    public const string EXTENSION_CCF = ".ccf";

    /// <summary> Basler 檔案副檔名。</summary>
    public const string EXTENSION_PFS = ".pfs";

    /// <summary> Defect File 檔案副檔名。</summary>
    public const string LOG = ".log";

    /// <summary> Image 檔案副檔名(.JPG)。</summary>
    public const string JPG = ".jpg";

    /// <summary> Image 檔案副檔名(.BMP)。</summary>
    public const string BMP = ".bmp";

    /// <summary> Xml 檔案副檔名(.xml)。</summary>
    public const string XML = ".xml";

    /// <summary> 系統名稱。</summary>
    public const string g_strProgramName = "AIP";

    /// <summary>專案設定組件名稱。</summary>
    public const string PROJECT_CONFIGURE_FILE = "ProjectConfigure";

    /// <summary>系統設定組件名稱。</summary>
    public const string SYSTEM_CONFIGURE_FILE = "SystemConfigure.xml";

    public const string LOGIN_FILE = "pw.bin";

    public const string LOGE_BORDER = "=======================================================================================================";
    public const string LOGE_SUBBORDER = "------------------------------------------------";
    [DllImport("kernel32.dll")]
    internal static extern Boolean SetProcessWorkingSetSize(IntPtr procHandler, Int32 min, Int32 max);

    #endregion

    #region " Properties "

    /// <summary>取得或設定，系統編號</summary>
    public static int AipSystemNo
    {
        get { return GlobalParameters.g_iAipSystemNo; }
        set { GlobalParameters.g_iAipSystemNo = value; }
    }
    private static int g_iAipSystemNo;

    /// <summary>取得或設定，紀錄瑕疵檔案。</summary>
    public static Byte[] TempData
    {
        get { return GlobalParameters.g_tTempData; }
        set { GlobalParameters.g_tTempData = value; }
    }
    private static Byte[] g_tTempData;


    #region " 控制視窗介面的參數 "

    /// <summary>取得或設定，工作執行進度。</summary>
    internal static int ProgressStep
    {
        get { return g_iProgressStep; }
        set { g_iProgressStep = value; }
    }
    private static int g_iProgressStep = 0;

    /// <summary>取得或設定，被選起的資料夾索引位置。</summary>
    public static int FolderIndex
    {
        get { return g_iFolderIndex; }
        set { g_iFolderIndex = value; }
    }
    private static int g_iFolderIndex = -1;

    /// <summary>取得或設定，被選取的資料夾名稱。</summary>
    public static string FolderName
    {
        get { return g_strFolderName; }
        set { g_strFolderName = value; }
    }
    private static string g_strFolderName = string.Empty;

    /// <summary>取得或設定，被選擇的檔案名稱。</summary>
    public static string RecipeName
    {
        get { return g_strRecipeName; }
        set { g_strRecipeName = value; }
    }
    private static string g_strRecipeName = string.Empty;

    /// <summary>取得或設定，相機裝置名稱。</summary>
    public static string CCDName
    {
        get { return g_strCCDName; }
        set { g_strCCDName = value; }
    }
    private static string g_strCCDName = string.Empty;

    /// <summary>取得或設定，是否已經取得到影像。</summary>
    public static List<bool> IsCapturedLists
    {
        get { return g_bIsCapturedLists; }
        set { g_bIsCapturedLists = value; }
    }
    private static List<bool> g_bIsCapturedLists = new List<bool>();

    /// <summary>取得，預設儲存影像是否。</summary>
    public static bool SaveImage
    {
        get { return g_bIsSaveImage; }
        set { g_bIsSaveImage = value; }
    }
    private static bool g_bIsSaveImage = false;

    /// <summary>取得或設定，儲存影像的格式。</summary>
    //public static SaveType SaveFormat
    //{
    //    get { return g_eSaveFormat; }
    //    set { g_eSaveFormat = value; }
    //}
    //private static SaveType g_eSaveFormat = SaveType.DEFAULT;

    /// <summary>取得或設定，與屬性資料相對應的元件。</summary>
    public static Control UIControl
    {
        get { return g_clsUIControl; }
        set { g_clsUIControl = value; }
    }
    private static Control g_clsUIControl = null;

    /// <summary>取得或設定，指定使用的相機元件。</summary>
    //public static XICamera Camera
    //{
    //    get { return g_clsCamera; }
    //    set { g_clsCamera = value; }
    //}
    //private static XICamera g_clsCamera = null;

    /// <summary> 取得，CCD相關設定 </summary>
    //public static List<CcdInfo> CCD { get { return g_clsCcd; } }
    //private static List<CcdInfo> g_clsCcd = new List<CcdInfo>();

    /// <summary>取得或設定，檢測狀態。</summary>
    //public static InspectStatus InspectStatus
    //{
    //    get { return g_eInspectStatus; }
    //    set { g_eInspectStatus = value; }
    //}
    //private static InspectStatus g_eInspectStatus;

    /// <summary>取得或設定，系統設定檔。</summary>
    public static SystemConfigure TempSystemConfigure
    {
        get { return g_clsTempSystemConfigure; }
        set { g_clsTempSystemConfigure = value; }
    }
    private static SystemConfigure g_clsTempSystemConfigure;

    /// <summary>圖片蒐集器視窗。</summary>
    //public static PictureEditor frmImageCollector = null;

    /// <summary>調機程式視窗。</summary>
    //public static CameraTool frmAdjustmentTool = null;

    /// <summary>系統設定視窗。</summary>
    //public static SystemSetup frmSystemSetup = null;

    /// <summary>參數設定視窗。</summary>
    //public static RecipeForm frmRecipeSetup = null;

    //public static InxCommunication.Dialog.XTcpSimulator frmTcpSimulator = null;

    //public static ControlToolbar frmControlToolbar = null;

    //public static SimulatorViewer frmSimulatorViewer = null;

    #endregion

    #region " 影像預設參數 "

    /// <summary>取得，預設的影像寬度。</summary>
    public static int Width { get { return GlobalParameters.g_iWidth; } }
    private static int g_iWidth = 6576;

    /// <summary>取得，預設的影像高度。</summary>
    public static int Height { get { return GlobalParameters.g_iHeight; } }
    private static int g_iHeight = 4384;

    #endregion

    #region " 相機預設參數 "

    /// <summary>取得，相機預設的連接埠。</summary>
    public static int Port
    {
        get { return g_iPort; }
        set { g_iPort = value; }
    }
    private static int g_iPort = -1;

    /// <summary>取得或設定，面板解析度(寬)。</summary>
    public static int ResolutionX
    {
        get { return g_iResolutionX; }
        set { g_iResolutionX = value; }
    }
    private static int g_iResolutionX = 1366;

    /// <summary>取得或設定，面板解析度(高)。</summary>
    public static int ResolutionY
    {
        get { return g_iResolutionY; }
        set { g_iResolutionY = value; }
    }
    private static int g_iResolutionY = 768;

    /// <summary>取得，相機預設編號。</summary>
    public static int CameraNumber { get { return g_iCameraNumber; } }
    private static int g_iCameraNumber = 0;

    /// <summary>取得，相機預設的訊號線種類。</summary>
    public static string ConnectionType
    {
        get { return GlobalParameters.g_strConnectionType; }
        set { GlobalParameters.g_strConnectionType = value; }
    }
    private static string g_strConnectionType = "-None-";

    /// <summary>取得，相機預設位址。</summary>
    public static string CameraIP { get { return g_strCameraIP; } }
    private static string g_strCameraIP = "127.0.0.1";

    /// <summary>取得，相機預設檔案名稱。</summary>
    public static string VirtualCameraName { get { return g_strVirtualCameraName; } }
    private static string g_strVirtualCameraName = "VirtualCamera";

    /// <summary>取得，相機預設設定檔。</summary>
    public static string CamFileName { get { return g_strCamFileName; } }
    private static string g_strCamFileName = "-None-";

    /// <summary>取得，相機網路裝置名稱</summary>
    public static string NetworkDeviceName { get { return GlobalParameters.g_strNetworkDeviceName; } }
    private static string g_strNetworkDeviceName = "-None-";

    /// <summary>取得，相機預設的是否為全彩影像的布林值。</summary>
    public static bool IsFullColor { get { return g_bIsFullColor; } }
    private static bool g_bIsFullColor = false;

    /// <summary>取得或設定， 是否有要載入 Cam File。</summary>
    public static bool EnableCamFile
    {
        get { return g_bEnableCamFile; }
        set { g_bEnableCamFile = value; }
    }
    private static bool g_bEnableCamFile = false;

    /// <summary>取得或設定，是否開啟相機連續取像</summary>
    public static bool FreeRunEnable
    {
        get { return GlobalParameters.g_bFreeRunEnable; }
        set { GlobalParameters.g_bFreeRunEnable = value; }
    }
    private static bool g_bFreeRunEnable = false;

    #endregion

    #region " 連線預設參數 "

    /// <summary>取得，遠端預設位址。</summary>
    public static string RemoteIP { get { return GlobalParameters.g_strRemoteIP; } }
    private static string g_strRemoteIP = "10.55.160.133";

    /// <summary>取得，本機預設位址。</summary>
    public static string LocalIP { get { return g_strLocalIP; } set { g_strLocalIP = value; } }
    private static string g_strLocalIP = "127.0.0.1";

    /// <summary>取得，遠端預設通訊埠。</summary>
    public static string RemotePort { get { return GlobalParameters.g_strRemotePort; } }
    private static string g_strRemotePort = "8030";

    /// <summary>取得，本機預設通訊埠。</summary>
    public static string LocalPort { get { return GlobalParameters.g_strLocalPort; } }
    private static string g_strLocalPort = "8080";

    /// <summary>取得，預設的接收的逾時時間。</summary>
    public static int ReceiveTimeOut { get { return GlobalParameters.g_iReceiveTimeOut; } }
    private static int g_iReceiveTimeOut = 30000;

    /// <summary>取得，預設的傳送的逾時時間。</summary>
    public static int SendTimeOut { get { return GlobalParameters.g_iSendTimeOut; } }
    private static int g_iSendTimeOut = 20000;

    /// <summary>取得或設定，Host IP 位址。</summary>
    public static IPAddress[] HostAddress
    {
        get { return g_clsHostAddress; }
        set { g_clsHostAddress = value; }
    }
    private static IPAddress[] g_clsHostAddress = Dns.GetHostAddresses(Dns.GetHostName());

    #endregion

    #region " 檢測模相關參數 "

    /// <summary>取得或設定，全部點燈數量。</summary>
    public static int TotalPatternCount
    {
        get { return g_iTotalPatternCount; }
        set { g_iTotalPatternCount = value; }
    }
    private static int g_iTotalPatternCount;

    /// <summary>取得或設定，是否啟用自動模式。</summary>
    public static bool IsAutoMode
    {
        get { return g_bIsAutoMode; }
        set { g_bIsAutoMode = value; }
    }
    private static bool g_bIsAutoMode = false;

    /// <summary>取得或設定，檢測模式。</summary>
    //public static InspectionType DetectionType
    //{
    //    get { return g_eDetectionType; }
    //    set { g_eDetectionType = value; }
    //}
    //private static InspectionType g_eDetectionType = InspectionType.ANALOG_DETECTION;

    #endregion

    #region " 自訂儲存路徑 "

    /// <summary>取得或設定，ACP 專案名稱。</summary>
    public string AcpProjectName
    {
        get { return g_strAcpProjectName; }
        set { g_strAcpProjectName = value; }
    }
    private string g_strAcpProjectName = "ACP";

    /// <summary>取得或設定，專案名稱。</summary>
    public static string ProjectName
    {
        get { return GlobalParameters.g_strProjectName; }
        set { GlobalParameters.g_strProjectName = value; }
    }
    private static string g_strProjectName = "Project";

    /// <summary>取得或設定，存放資料的檔案資料夾路徑。</summary>
    public static string InxLibPath
    {
        get { return g_strInxLibPath; }
        set { g_strInxLibPath = value; }
    }
    private static string g_strInxLibPath = "InxLib";

    /// <summary>取得或設定，主要專案的資料夾路徑。</summary>
    public static string MainFolderPath
    {
        get { return g_strMainFolderPath; }
        set { g_strMainFolderPath = value; }
    }
    private static string g_strMainFolderPath = @"D:\API\";

    /// <summary>取得或設定，主要專案的資料夾路徑。</summary>
    public static string MainAIPFolderPath
    {
        get { return g_strMainAIPFolderPath; }
        set { g_strMainAIPFolderPath = value; }
    }
    private static string g_strMainAIPFolderPath = @"D:\API\AIP";

    /// <summary>取得或設定，ACP 儲存瑕疵資料夾路徑。</summary>
    public static string ACPDefectFolderPath
    {
        get { return g_strACPDefectFolderPath; }
        set { g_strACPDefectFolderPath = value; }
    }
    private static string g_strACPDefectFolderPath = @"D:\API\ACP\Report\";

    /// <summary>取得，儲存瑕疵的路徑。</summary>
    public static string DataFolderPath { get { return g_strDataFolderPath; } }
    private static string g_strDataFolderPath = "Report";

    /// <summary>取得，儲存影像的路徑。</summary>
    public static string ImageFolderPath { get { return g_strImageFolderPath; } }
    private static string g_strImageFolderPath = "Image";

    /// <summary>取得，儲存系統日誌的路徑。</summary>
    public static string LogFolderPath { get { return g_strLogFolderPath; } }
    private static string g_strLogFolderPath = "Log";

    /// <summary>取得，儲存 Recipe 的路徑。</summary>
    public static string RecipeFolderPath { get { return g_strRecipeFolderPath; } }
    private static string g_strRecipeFolderPath = "Recipe";

    /// <summary>取得，儲存 Camera 的路徑。</summary>
    public static string CameraFolderPath { get { return g_strCameraFolderPath; } }
    private static string g_strCameraFolderPath = "Camera";

    /// <summary>取得，儲存組件的路徑。</summary>
    public static string ConfigureFolderPath { get { return g_strConfigureFolderPath; } }
    private static string g_strConfigureFolderPath = "Configure";

    /// <summary>取得，儲存日誌的路徑。</summary>
    public static string Log4netFolderPath { get { return g_strLog4netFolderPath; } }
    private static string g_strLog4netFolderPath = "LogFile";

    /// <summary>取得，系統預設讀取專案組件的路徑。</summary>
    public static string ProjectFolderPath { get { return g_strProjectFolderPath; } }
    private static string g_strProjectFolderPath = "ProjectSetup";

    /// <summary>取得或設定，記錄當前瑕疵檔案路徑。</summary>
    public static string DefectDataFilePath
    {
        get { return GlobalParameters.g_strDefectDataFilePath; }
        set { GlobalParameters.g_strDefectDataFilePath = value; }
    }
    private static string g_strDefectDataFilePath = string.Empty;

    #endregion

    #region " 預設儲存路徑 "

    /// <summary>取得，預設儲存瑕疵的路徑。</summary>
    public static string DefaultDataFolderPath { get { return GlobalParameters.g_strDefaultDataFolderPath; } }
    private static string g_strDefaultDataFolderPath = g_strMainFolderPath + g_strDataFolderPath + SLASHES;

    /// <summary>取得，預設儲存影像的路徑。</summary>
    public static string DefaultImageFolderPath { get { return GlobalParameters.g_strDefaultImageFolderPath; } }
    private static string g_strDefaultImageFolderPath = g_strMainFolderPath + g_strImageFolderPath + SLASHES;

    /// <summary>取得，預設儲存日誌的路徑。</summary>
    public static string DefaultLogFolderPath { get { return GlobalParameters.g_strDefaultLogFolderPath; } }
    private static string g_strDefaultLogFolderPath = g_strMainFolderPath + g_strLogFolderPath + SLASHES;

    /// <summary>取得，預設儲存 Recipe 的路徑。</summary>
    public static string DefaultRecipeFolderPath { get { return GlobalParameters.g_strDefaultRecipeFolderPath; } }
    private static string g_strDefaultRecipeFolderPath = g_strMainFolderPath + g_strRecipeFolderPath + SLASHES;

    /// <summary>取得，預設儲存 Camera 的路徑。</summary>
    public static string DefaultCameraFolderPath { get { return GlobalParameters.g_strDefaultCameraFolderPath; } }
    private static string g_strDefaultCameraFolderPath = g_strMainFolderPath + g_strCameraFolderPath + SLASHES;

    /// <summary>取得，預設儲存日誌的路徑。</summary>
    public static string DefaultLog4netFolderPath { get { return GlobalParameters.g_strDefaultLog4netFolderPath; } }
    private static string g_strDefaultLog4netFolderPath = g_strMainFolderPath + g_strLog4netFolderPath + SLASHES;

    /// <summary>取得，預設專案的路徑。</summary>
    public static string DefaultProjectSetupFolderPath { get { return GlobalParameters.g_strtProjectSetupFolderPath; } }
    private static string g_strtProjectSetupFolderPath = g_strMainFolderPath + g_strProjectFolderPath + SLASHES;

    /// <summary>取得，預設儲存組件的路徑。</summary>
    public static string DefaultConfigureFolderPath { get { return GlobalParameters.g_strDefaultConfigureFolderPath; } }
    private static string g_strDefaultConfigureFolderPath = g_strMainFolderPath + g_strConfigureFolderPath + SLASHES;

    #endregion

    #endregion

    #region " Properties - Base Data "

    /// <summary>取得本機位址。</summary>
    public static IPAddress[] g_clsIpLocal = Dns.GetHostAddresses(Dns.GetHostName());

    /// <summary>用於儲存 Pattern 名稱資訊。</summary>
    //public static List<string> g_strPatternLists = new List<string>();

    /// <summary>用於儲存資料夾路徑。</summary>
    public static List<string> g_strImageFolderLists = new List<string>();

    /// <summary>用於儲存檔案路徑。</summary>
    public static List<string> g_strImageFileLists = new List<string>();

    #endregion

    #region " Methods - Serialize / Deserialize "

    /// <summary>序列化資料轉成 Xml 格式。</summary>
    /// <typeparam name="T">型別，可能為自訂的 Class or 其他基本型別。</typeparam>
    /// <param name="strPath">檔案路徑。</param>
    /// <param name="clsData">物件資料。</param>
    /// <returns>執行結果狀態碼 XErrorCode 。</returns>
    public static int Serialize<T>(string strPath, T clsData)
    {
        int iStt = XErrorCode.ST_SUCCESS;
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
            Logger.Bomb.Error("[Serialize<T>] - " + ex.ToString());
            if (clsXmlWriter != null) clsXmlWriter.Close();
            iStt = XErrorCode.ER_SYSTEM;
            XStatus.Report(XStatus.Type.Windows, MethodInfo.GetCurrentMethod(), XStatus.GetExceptionLine(ex));
        }
        finally
        {
            clsXmlSettings = null;
            clsXmlWriter = null;
            clsXmlSerializer = null;
            clsXmlSerializerNamespaces = null;
        }
        return iStt;
    }

    /// <summary>反序列化 Xml 文件中的資料轉成物件資料。。</summary>
    /// <typeparam name="T">型別，可能為自訂的 Class or 其他基本型別。</typeparam>
    /// <param name="strPath">檔案路徑。</param>
    /// <param name="clsData">物件資料。</param>
    /// <returns>執行結果狀態碼 XErrorCode 。</returns>
    public static int Deserialize<T>(string strPath, ref T clsData)
    {
        int iStt = XErrorCode.ST_SUCCESS;
        object clsTempData = null;
        //FileStream clsFileStream = null;
        MemoryStream clsMemoryStream = null;
        XmlSerializer clsXmlSerializer = null;
        XmlReader clsXmlReader = null;
        UTF8Encoding clsEncoding = null;
        try
        {
            clsEncoding = new UTF8Encoding();
            //using (clsFileStream = new FileStream(strPath, FileMode.Open))
            using (clsMemoryStream = new MemoryStream(clsEncoding.GetBytes(File.ReadAllText(strPath))))
            {
                clsXmlSerializer = new XmlSerializer(typeof(T));
                //clsXmlReader = XmlReader.Create(clsFileStream);
                //clsTempData = (T)clsXmlSerializer.Deserialize(clsXmlReader);
                clsTempData = (T)clsXmlSerializer.Deserialize(clsMemoryStream);
                if (clsTempData != null)
                {
                    clsData = (T)clsTempData;
                }
                else
                {
                    clsData = default(T);
                }
                clsMemoryStream.Close();
                //clsXmlReader.Close();
                //clsFileStream.Close();
            }
        }
        catch (Exception ex)
        {
            Logger.Bomb.Error("[Deserialize<T>] - " + ex.ToString());
            if (clsXmlReader != null)
            {
                clsXmlReader.Close();
            }
            //if (clsFileStream != null) clsFileStream.Close();
            if (clsMemoryStream != null)
            {
                clsMemoryStream = null;
            }
            iStt = XErrorCode.ER_SYSTEM;
            XStatus.Report(XStatus.Type.Windows, MethodInfo.GetCurrentMethod(), XStatus.GetExceptionLine(ex));
        }
        finally
        {
            //clsFileStream = null;
            clsXmlSerializer = null;
            clsXmlReader = null;
            clsMemoryStream = null;
        }
        return iStt;
    }

    #endregion

    #region " Methods - Data to Byte array"

    public static int TransformDataToByteArray(object objData, ref byte[] byteData)
    {
        int iStt = XErrorCode.ST_SUCCESS;
        try
        {
            InxAPI.API2.AIPDefectData clsMergeDefectData = objData as InxAPI.API2.AIPDefectData;
            if (clsMergeDefectData != null)
            {
                BinaryFormatter clsBinary = new BinaryFormatter();
                MemoryStream clsStream = new MemoryStream();
                clsBinary.Serialize(clsStream, clsMergeDefectData);
                byteData = new byte[clsStream.Length];
                byteData = clsStream.ToArray();
                g_tTempData = new Byte[byteData.Length];
                byteData.CopyTo(g_tTempData, 0);
            }
        }
        catch (Exception ex)
        {
            Logger.Bomb.Error("[TransformDataToByteArray] : " + ex);
            XStatus.Report(XStatus.Type.Procedure, MethodBase.GetCurrentMethod(), XStatus.GetExceptionLine(ex));
        }
        return iStt;
    }


    #endregion

    #region " Methods - Folder/File "

    /// <summary>指定資料夾的位置，去抓取底下有多少個資料夾，並且獲取該名稱。</summary>
    /// <param name="strFolder">資料夾路徑。</param>
    /// <returns>回傳目前指定的資料夾底下有多少個資料夾。</returns>
    public static List<string> GetFoldersNameFromFolder(string strFolder)
    {
        int iStt = XErrorCode.ST_SUCCESS;
        string strParentName = string.Empty;
        List<string> strFolderLists = new List<string>();
        try
        {
            // 確保資料夾是否存在
            if (!Directory.Exists(strFolder))
            {
                return strFolderLists;
            }

            // 設定要讀取的資料夾
            DirectoryInfo clsTarget = new DirectoryInfo(strFolder);
            DirectoryInfo[] clsTargetFolderLists = clsTarget.GetDirectories();
            if (clsTargetFolderLists.Length > 0)
            {
                foreach (DirectoryInfo clsFolder in clsTargetFolderLists)
                {
                    iStt = GetFileNameFromFolder(clsFolder.FullName);
                    if (iStt == XErrorCode.ST_SUCCESS)
                    {
                        strFolderLists.Add(clsFolder.FullName);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Bomb.Error("[GetFoldersNameFromFolder] - " + ex.ToString());
            XStatus.Report(XStatus.Type.Windows, MethodInfo.GetCurrentMethod(), XStatus.GetExceptionLine(ex));
        }
        return strFolderLists;
    }

    public static int GetFileNameFromFolder(string strPath)
    {
        int iStt = XErrorCode.ST_SUCCESS;
        try
        {
            DirectoryInfo clsTarget = new DirectoryInfo(strPath);
            DirectoryInfo[] clsTargetFolderLists = clsTarget.GetDirectories();
            FileInfo[] clsFileInfoLists = clsTarget.GetFiles();
            if (clsTargetFolderLists.Length > 0)
            {
                // 表示有其他資料夾。
                foreach (DirectoryInfo clsFolder in clsTargetFolderLists)
                {
                    iStt = GetFileNameFromFolder(clsFolder.FullName);
                    if (iStt == XErrorCode.ST_SUCCESS)
                    {
                        return iStt;
                    }
                }
            }
            else
            {
                if (clsFileInfoLists.Length > 0)
                {
                    // 表示有檔案。
                    foreach (FileInfo clsFileInfo in clsFileInfoLists)
                    {
                        if (clsFileInfo.FullName.LastIndexOf(".bmp") > -1 ||
                           clsFileInfo.FullName.LastIndexOf(".jpg") > -1)
                        {
                            // 找到一筆符合。
                            return XErrorCode.ST_SUCCESS;
                        }
                    }
                }
            }

            iStt = XErrorCode.ER_PROCEDURE;
        }
        catch (Exception ex)
        {
            Logger.Bomb.Error("[GetFileNameFromFolder] - " + ex.ToString());
        }
        return iStt;
    }

    #endregion

    #region " Methods - Data Format "

    /// <summary>提供一個取得日期格式，例:2014/10/10/。</summary>
    /// <returns>回傳日期字串格式。</returns>
    public static string GetCurrentDateFormat()
    {
        string strDateFormat = string.Empty;
        strDateFormat = DateTime.Now.Year.ToString("0000") +
                        DateTime.Now.Month.ToString("00") +
                        DateTime.Now.Day.ToString("00") + @"\";
        return strDateFormat;
    }

    /// <summary>提供一個取得時間格式，例:20:23:235。。</summary>
    /// <returns>回傳日期字串格式。</returns>
    public static string GetCurrentTimeFormat()
    {
        string strTimeFormat = string.Empty;
        strTimeFormat = DateTime.Now.Hour.ToString("00") +
                        DateTime.Now.Minute.ToString("00") +
                        DateTime.Now.Second.ToString("00") +
                        DateTime.Now.Millisecond.ToString("000");
        return strTimeFormat;
    }

    /// <summary>提供一個取得完整時間格式。</summary>
    /// <returns>回傳日期字串格式。</returns>
    public static string GetCurrentAllTimeFormat()
    {
        string strAllTimeFormat = string.Empty;
        strAllTimeFormat = DateTime.Now.Year.ToString("0000") +
                           DateTime.Now.Month.ToString("00") +
                           DateTime.Now.Day.ToString("00") +
                           DateTime.Now.Hour.ToString("00") +
                           DateTime.Now.Minute.ToString("00") +
                           DateTime.Now.Second.ToString("00") +
                           DateTime.Now.Millisecond.ToString("000");
        return strAllTimeFormat;
    }

    public static string GetLogTitle(string strTitle)
    {
        string strFullTitle = string.Empty;
        strFullTitle = "｜                                           " + strTitle +
                        "                                           ｜";
        return strFullTitle;
    }

    public static string GetLogSubTitle(string strSubTitle)
    {
        string strFullSubTitle = string.Empty;
        strFullSubTitle = "            [" + strSubTitle +
                            "]           ";
        return strFullSubTitle;
    }

    #endregion
}
