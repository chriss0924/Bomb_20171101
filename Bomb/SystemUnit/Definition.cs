
/// <summary>影像處理工具。</summary>
public enum XVision_Tool
{
	/// <summary>Open eVision 。</summary>
    eVision,
	/// <summary>Open CV 。</summary>
    OpenCV,
	/// <summary>自行開發。</summary>
    Customer
}
/// <summary>序列化方法。 </summary>
public enum XSerializerMethod
{
    /// <summary>XML 序列化。</summary>
    XmlSerializer,
    /// <summary>Binary 序列化。</summary>
    BinarySerializer,
}

/// <summary>影像色彩類別。</summary>
public enum XImageByteType
{
	/// <summary>每一個像素用 8 Bit 來表示。</summary>
    Image8,
	/// <summary>每一個像素用 24 Bit 來表示。</summary>
    Image24,
	/// <summary>每一個像素用 1 Bit 來表示。</summary>
    Image1,
	/// <summary>未知。</summary>
    NA
}

/// <summary>影像檔案格式。</summary>
public enum XImageFileType
{
	/// <summary>Windows Bitmap，其副檔名為 *.bmp 。</summary>
    BMP,
	/// <summary>Jpeg，其副檔名為 *.jpg 或 *.jpeg 。</summary>
    Jpeg,
	/// <summary>Jpeg2000，其副檔名為 *.j2k 。</summary>
    Jpeg2000,
	/// <summary>PNG，其副檔名為 *.png 。</summary>
    PNG,
	/// <summary>TIFF，其副檔名為 *.titf 。</summary>
    TIFF,
    DEFAULT
}

/// <summary>IO狀態。</summary>
public enum XIOState 
{ 
	/// <summary>開。</summary>
	On, 
	/// <summary>關。</summary>
	Off, 
	/// <summary>未知。</summary>
	Unknow,
}

/// <summary>錯誤狀態碼。</summary>
public class XErrorCode
{
	/// <summary>預設狀態，成功。</summary>
	public const int ST_SUCCESS = 0;

	//  System Error
	/// <summary>系統錯誤。</summary>
	public const int ER_SYSTEM = -100;
	/// <summary>系統錯誤，使用者介面錯誤。</summary>
	public const int ER_USER_INTERFACE = -101;
	/// <summary>系統錯誤，初始錯誤。</summary>
	public const int ER_INITIAL = -102;
	/// <summary>系統錯誤，找不到裝置。</summary>
    public const int ER_NO_DEVICE = -103;
	/// <summary>系統錯誤，使用者介面錯誤。</summary>
    public const int ER_NOT_EXIST = -104;

	//  Procedure Error
    /// <summary>程序錯誤。</summary>
	public const int ER_PROCEDURE = -1000;
    /// <summary>程序錯誤，參數錯誤。</summary>
    public const int ER_PARAMETER = -1001;
    /// <summary>程序錯誤，檔案不存在。</summary>
    public const int ER_FILE_NOT_EXIST = -1002;
	/// <summary>程序錯誤，檔案格式不正確。</summary>
	public const int ER_FILE_NOT_CORRECT = -1003;
    /// <summary>程序錯誤，逾時。</summary>
    public const int ER_TIMEOUT = -1001;

	// Motion Error
	/// <summary>運動卡錯誤，初始異常。</summary>
	public const int ER_MOTION_INIT = -2000;
	/// <summary>運動卡錯誤，急停異常。</summary>
	public const int ER_MOTION_ESTOP = -2001;
	/// <summary>運動卡錯誤，裝置卡異常。</summary>
	public const int ER_MOTION_CARD = -2002;
	/// <summary>運動卡錯誤，逾時。</summary>
	public const int ER_MOTION_TIMEOUT = -2003;
	/// <summary>運動卡錯誤，Adlink 8164 卡錯誤碼，登記範圍為 -2100~-2142 。</summary>
	public const int ER_MOTION_8164_NO_ERROR = -2100;	// 登記 -2100~-2142 為 Adlink 8164 卡的錯誤碼。
	/// <summary>運動卡錯誤，沒有這個功能。</summary>
	public const int ER_MOTION_NO_FUNCTION = -2007;
	/// <summary>運動卡錯誤，裝置卡異常。</summary>
	public const int ER_MOTION_KINEMATICS = -2008;
	/// <summary>運動卡錯誤，已經運作了，無法重覆運作。</summary>
	public const int ER_MOTION_OPERATED = -2009;
	/// <summary>運動卡錯誤，已經運作了，伺服關閉。</summary>
	public const int ER_MOTION_SERVO_OFF = -2010;

	//  Vision Error
	/// <summary>視覺相關錯誤， eVision 錯誤。</summary>
	public const int ER_EVISION = -3010;
	/// <summary>視覺相關錯誤，eVision 演算法錯誤。</summary>
	public const int ER_VISION_ALGORITHM = -3011;

    //VixionX Error
    /// <summary>視覺相關錯誤，XVision 錯誤。</summary>
    public const int ER_VISIONX = -3020;    

	/// <summary>視覺相關錯誤，相機錯誤。</summary>
	public const int ER_CAMERA = -3040;
	/// <summary>視覺相關錯誤，相機初始錯誤。</summary>
	public const int ER_CAMERA_INIT = -3041;
	/// <summary>視覺相關錯誤，相機硬體錯誤。</summary>
	public const int ER_CAMERA_HARDWARE = -3043;
	/// <summary>視覺相關錯誤，相機設置錯誤。</summary>
	public const int ER_CAMERA_OPERATION = -3044;
	/// <summary>視覺相關錯誤，相機參數錯誤。</summary>
	public const int ER_CAMERA_PARAMETER = -3046;

	// Communication
	/// <summary>通訊錯誤。</summary>
	public const int ER_COMMUNICATION = -3500;
	/// <summary>通訊錯誤，通訊狀態未連接。</summary>
	public const int ER_COMM_NOT_CONNECT = -3501;
	/// <summary>通訊錯誤，通訊逾時。</summary>
	public const int ER_COMM_TIMEOUT = -3502;

	// IO Error
	/// <summary>IO錯誤，初始錯誤。</summary>
	public const int ER_IO_INIT = -4000;
	/// <summary>IO錯誤，設置連接埠錯誤。</summary>
	public const int ER_IO_SET_PORT = -4001;
	/// <summary>IO錯誤，取得連接埠錯誤。</summary>
	public const int ER_IO_GET_PORT = -4002;
	/// <summary>IO錯誤，逾時。</summary>
	public const int ER_IO_TIMEOUT = -4003;
	/// <summary>IO錯誤，Adlink 7230 卡錯誤，錯誤碼範圍 -4201~-4217。</summary>
	public const int ER_IO_7230_NO_ERROR = -4100;	// 登記 -4100~-4167 為 Adlink 7230 卡的錯誤碼; -4201~-4217為Adlink 7230 卡驅動程式的錯誤碼。
    public const int ER_IO_7250_NO_ERROR = -4100;	// 仿照 Adlink 7230 ，將錯誤碼登記為 Adlink 7250 
    
    // Classification Error
	/// <summary>分類器錯誤。</summary>
    public const int ER_CLASSIFICATION_DATA_DIMENTION = -5000;
	/// <summary>分類器錯誤，規則錯誤。</summary>
    public const int ER_CLASSIFICATION_RULE = -5001;
	/// <summary>分類器錯誤，特徵擷取異常。</summary>
    public const int ER_CLASSIFICATION_FEATURE_GENERATION = -5002;

    // Robot Error
	/// <summary>機器手臂錯誤。</summary>
    public const int ER_ROBOT = -6000;
	/// <summary>機器手臂錯誤，參數異常。</summary>
    public const int ER_ROBOT_PARAMETER = -6001;

    // PLC Error
    /// <summary>PLC錯誤。</summary>
    public const int ER_PLC = -7000;
    /// <summary>PLC錯誤，連線錯誤。</summary>
    public const int ER_PLC_COMMUNICATION = -7001;
    /// <summary>PLC錯誤，MX Component 錯誤碼範圍 -7100~-7099。</summary>
    public const int ER_PLC_MX_COMPONENT_NO_ERROR = -7100;

	//Barcode Reader
	/// <summary>Barcode Reader錯誤。</summary>
	public const int ER_BarcodeRead = -8000;
	/// <summary>Barcode Reader讀取錯誤。</summary>
	public const int ER_BarcodeRead_NoReader = -8001;

	/// =====================================================
	/// Warning Definition
	/// 不屬於嚴重錯誤類型的定義型態。
	/// =====================================================

	// Interface
	/// <summary>警告，Interface無此方法。</summary>
	public const int WN_INTERFACE_NO_FUNCTION = 20001;

	// Initialization
	/// <summary>警告，版本不同。</summary>
	public const int WN_VERSION_DIFFERENT = 20002;

	// General
	/// <summary>警告，逾時。</summary>
	public const int WN_TIMEOUT = 20003;

	// Vision
	/// <summary>警告，eVision 異常。</summary>
	public const int WN_EVISION = 20010;

	//  Procedure Error
	public const int WN_PROCEDURE = 20005;

	# region " Motion Card - 錯誤碼轉譯區 "

	/// <summary> Adlink 8164 函數所回傳的錯誤碼如下: </summary>
	public enum Error_8164 : short
	{
		ERR_NoError = 0,						// 0
		ERR_BoardNoInit = 1,					// 1
		ERR_InvalidBoardNumber = 2,			// 2
		ERR_InitializedBoardNumber = 3,			// 3
		ERR_BaseAddressError = 4,				// 4
		ERR_BaseAddressConflict = 5,			// 5
		ERR_DuplicateBoardSetting = 6,			// 6
		ERR_DuplicateIrqSetting = 7,			// 7
		ERR_PCIBiosNotExist = 8,				// 8
		ERR_PCIIrqNotExist = 9,				// 9
		ERR_PCICardNotExist = 10,				// 10
		ERR_SpeedError = 11,   				// 11
		ERR_MoveRatioError = 12,				// 12
		ERR_PosOutOfRange = 13,				// 13
		ERR_AxisAlreadyStop = 14,				// 14
		ERR_AxisArrayError = 15,				// 15
		ERR_SlowDownPointError = 16,			// 16
		ERR_CompareMethodError = 17,			// 17
		ERR_CompareNoError = 18,				// 18
		ERR_CompareAxisError = 19,				// 19
		ERR_CompareTableSizeError = 20,			// 20
		ERR_CompareFunctionError = 21,			// 21
		ERR_CompareTableNotReady = 22,			// 22
		ERR_CompareLineNotReady = 23,			// 23
		ERR_NoCardFound = 24,					// 24
		ERR_LatchNoError = 25,					// 25
		ERR_AxisRangeError = 26,				// 26
		ERR_DioNoError = 27,					// 27
		ERR_PChangeSlowDownPointError = 28,		// 28
		ERR_SpeedChangeError = 29,				// 29
		ERR_CardNoError = 30,					// 30
		ERR_LinkIntError = 31,					// 31
		ERR_HardwareCompareAxisWrong = 32,		// 32
		ERR_AutoCompareSourceWrong = 33,		// 33
		ERR_CompareDeviceTypeError = 34,		// 34
		ERR_PulserHomeTypeError = 35,			// 35
		ERR_EventAlreadyEnable = 36,			// 36
		ERR_EventNotEnableYet = 37,			// 37
		ERR_LineArcParameterError = 38,			// 38
		ERR_ConfigFileOpenError = 39,			// 39
		ERR_CompareFIFONotReady = 40,			// 40
		ERR_EventInitError = 41,				// 41
		ERR_MemAllocError = 42,				// 42
	}

	/// <summary> 將Adlink 8164 motion card 的錯誤碼轉換成系統的錯誤碼。 </summary>
	/// <param name="adlinkErrorCode">Adlink 8164 的錯誤碼</param>
	/// <returns>如果無錯誤，會回傳狀態成功，如果有錯誤，將會回傳負值的錯誤碼代表錯誤發生</returns>
	public static int Adlink8164ErrorCode(int adlinkErrorCode, System.Reflection.MethodBase info)
	{
		if (adlinkErrorCode == (int)Error_8164.ERR_NoError || adlinkErrorCode == (int)Error_8164.ERR_CardNoError)
		{
			return ST_SUCCESS;
		}
		else
		{
			XStatus.Report(XStatus.Type.Device, info, "Adlink 8164 : " + ((Error_8164)adlinkErrorCode).ToString());
			return ER_MOTION_8164_NO_ERROR - adlinkErrorCode;
		}
	}

    /// <summary>
    /// Festo 錯誤碼
    /// </summary>
    public enum Error_Festo : short
    {
        ERR_NoError = 0,						// 0
        ERR_ControllerNoInit = 1,				// 1
        ERR_ConnectError = 2,				    // 2
        ERR_DisconnectError = 3,				// 3
        ERR_CloseError = 4,				        // 4
        ERR_InitalControllerError = 5,			// 5
        ERR_HomingError = 6,				    // 6
        ERR_RelativeMoveError = 7,				// 7
        ERR_AbsoluteMoveError = 8,				// 8
        ERR_StartRecordMoveError = 9,			// 9
        ERR_EStopError = 10,				    // 10
        ERR_NormalStopError = 11,				// 11
        ERR_AlarmResetError = 12,				// 12
        ERR_SetServoError = 13,				    // 13
        ERR_GetIOStatusError = 14,				// 14
        ERR_MotionIODecodeError = 15,	        // 15
        ERR_GetCurrentSpeedError = 16,		    // 16
        ERR_GetEncodePositionError = 17,        // 17
        ERR_GetTargetPositionError = 18,        // 18
        ERR_WaitMotionDownError = 19,	        // 19
        ERR_ScanMotionStatusError = 20,		    // 20
        ERR_GetRecordTableError = 21,	        // 21
        ERR_ConnectNoError = 22,				    // 2

        ERR_FestoNoFunctionError = 99,		    // 99
    }

    /// <summary> 將Festo motion Controller 的錯誤碼轉換成系統的錯誤碼。 </summary>
	/// <param name="FestoErrorCode">Festo 的錯誤碼</param>
    /// <returns>如果無錯誤，會回傳狀態成功，如果有錯誤，將會回傳負值的錯誤碼代表錯誤發生</returns>
    public static int FestoErrorCode(int FestoErrorCode, System.Reflection.MethodBase info)
    {
        if (FestoErrorCode == (int)Error_Festo.ERR_NoError || FestoErrorCode == (int)Error_Festo.ERR_ConnectError)
        {
            return ST_SUCCESS;
        }
        else
        {
            XStatus.Report(XStatus.Type.Device, info, "Festo : " + ((Error_Festo)FestoErrorCode).ToString());
            return FestoErrorCode;
        }
    }

	#endregion

	#region " IO Card - 錯誤碼轉譯區"

	/// <summary> Adlink 7230 錯誤代碼。</summary>
	public enum Error_7230 : short
	{
		NoError = 0,
		ErrorUnknownCardType = -1,
		ErrorInvalidCardNumber = -2,
		ErrorTooManyCardRegistered = -3,
		ErrorCardNotRegistered = -4,
		ErrorFuncNotSupport = -5,
		ErrorInvalidIoChannel = -6,
		ErrorInvalidAdRange = -7,
		ErrorContIoNotAllowed = -8,
		ErrorDiffRangeNotSupport = -9,
		ErrorLastChannelNotZero = -10,
		ErrorChannelNotDescending = -11,
		ErrorChannelNotAscending = -12,
		ErrorOpenDriverFailed = -13,
		ErrorOpenEventFailed = -14,
		ErrorTransferCountTooLarge = -15,
		ErrorNotDoubleBufferMode = -16,
		ErrorInvalidSampleRate = -17,
		ErrorInvalidCounterMode = -18,
		ErrorInvalidCounter = -19,
		ErrorInvalidCounterState = -20,
		ErrorInvalidBinBcdParam = -21,
		ErrorBadCardType = -22,
		ErrorInvalidDaRefVoltage = -23,
		ErrorAdTimeOut = -24,
		ErrorNoAsyncAI = -25,
		ErrorNoAsyncAO = -26,
		ErrorNoAsyncDI = -27,
		ErrorNoAsyncDO = -28,
		ErrorNotInputPort = -29,
		ErrorNotOutputPort = -30,
		ErrorInvalidDioPort = -31,
		ErrorInvalidDioLine = -32,
		ErrorContIoActive = -33,
		ErrorDblBufModeNotAllowed = -34,
		ErrorConfigFailed = -35,
		ErrorInvalidPortDirection = -36,
		ErrorBeginThreadError = -37,
		ErrorInvalidPortWidth = -38,
		ErrorInvalidCtrSource = -39,
		ErrorOpenFile = -40,
		ErrorAllocateMemory = -41,
		ErrorDaVoltageOutOfRange = -42,
		ErrorDaExtRefNotAllowed = -43,
		ErrorDIODataWidthError = -44,
		ErrorTaskCodeError = -45,
		ErrortriggercountError = -46,
		ErrorInvalidTriggerMode = -47,
		ErrorInvalidTriggerType = -48,
		ErrorInvalidCounterValue = -50,
		ErrorInvalidEventHandle = -60,
		ErrorNoMessageAvailable = -61,
		ErrorEventMessgaeNotAdded = -62,
		ErrorCalibrationTimeOut = -63,
		ErrorUndefinedParameter = -64,
		ErrorInvalidBufferID = -65,
		ErrorInvalidSampledClock = -66,
		ErrorInvalisOperationMode = -67,


		//Error code number for driver API
		ErrorConfigIoctl = -201,
		ErrorAsyncSetIoctl = -202,
		ErrorDBSetIoctl = -203,
		ErrorDBHalfReadyIoctl = -204,
		ErrorContOPIoctl = -205,
		ErrorContStatusIoctl = -206,
		ErrorPIOIoctl = -207,
		ErrorDIntSetIoctl = -208,
		ErrorWaitEvtIoctl = -209,
		ErrorOpenEvtIoctl = -210,
		ErrorCOSIntSetIoctl = -211,
		ErrorMemMapIoctl = -212,
		ErrorMemUMapSetIoctl = -213,
		ErrorCTRIoctl = -214,
		ErrorGetResIoctl = -215,
		ErrorCalIoctl = -216,
		ErrorPMIntSetIoctl = -217,
	}


    public enum Error_7250 : short
    {
        NoError = 0,
        ErrorUnknownCardType = -1,
        ErrorInvalidCardNumber = -2,
        ErrorTooManyCardRegistered = -3,
        ErrorCardNotRegistered = -4,
        ErrorFuncNotSupport = -5,
        ErrorInvalidIoChannel = -6,
        ErrorInvalidAdRange = -7,
        ErrorContIoNotAllowed = -8,
        ErrorDiffRangeNotSupport = -9,
        ErrorLastChannelNotZero = -10,
        ErrorChannelNotDescending = -11,
        ErrorChannelNotAscending = -12,
        ErrorOpenDriverFailed = -13,
        ErrorOpenEventFailed = -14,
        ErrorTransferCountTooLarge = -15,
        ErrorNotDoubleBufferMode = -16,
        ErrorInvalidSampleRate = -17,
        ErrorInvalidCounterMode = -18,
        ErrorInvalidCounter = -19,
        ErrorInvalidCounterState = -20,
        ErrorInvalidBinBcdParam = -21,
        ErrorBadCardType = -22,
        ErrorInvalidDaRefVoltage = -23,
        ErrorAdTimeOut = -24,
        ErrorNoAsyncAI = -25,
        ErrorNoAsyncAO = -26,
        ErrorNoAsyncDI = -27,
        ErrorNoAsyncDO = -28,
        ErrorNotInputPort = -29,
        ErrorNotOutputPort = -30,
        ErrorInvalidDioPort = -31,
        ErrorInvalidDioLine = -32,
        ErrorContIoActive = -33,
        ErrorDblBufModeNotAllowed = -34,
        ErrorConfigFailed = -35,
        ErrorInvalidPortDirection = -36,
        ErrorBeginThreadError = -37,
        ErrorInvalidPortWidth = -38,
        ErrorInvalidCtrSource = -39,
        ErrorOpenFile = -40,
        ErrorAllocateMemory = -41,
        ErrorDaVoltageOutOfRange = -42,
        ErrorDaExtRefNotAllowed = -43,
        ErrorDIODataWidthError = -44,
        ErrorTaskCodeError = -45,
        ErrortriggercountError = -46,
        ErrorInvalidTriggerMode = -47,
        ErrorInvalidTriggerType = -48,
        ErrorInvalidCounterValue = -50,
        ErrorInvalidEventHandle = -60,
        ErrorNoMessageAvailable = -61,
        ErrorEventMessgaeNotAdded = -62,
        ErrorCalibrationTimeOut = -63,
        ErrorUndefinedParameter = -64,
        ErrorInvalidBufferID = -65,
        ErrorInvalidSampledClock = -66,
        ErrorInvalisOperationMode = -67,


        //Error code number for driver API
        ErrorConfigIoctl = -201,
        ErrorAsyncSetIoctl = -202,
        ErrorDBSetIoctl = -203,
        ErrorDBHalfReadyIoctl = -204,
        ErrorContOPIoctl = -205,
        ErrorContStatusIoctl = -206,
        ErrorPIOIoctl = -207,
        ErrorDIntSetIoctl = -208,
        ErrorWaitEvtIoctl = -209,
        ErrorOpenEvtIoctl = -210,
        ErrorCOSIntSetIoctl = -211,
        ErrorMemMapIoctl = -212,
        ErrorMemUMapSetIoctl = -213,
        ErrorCTRIoctl = -214,
        ErrorGetResIoctl = -215,
        ErrorCalIoctl = -216,
        ErrorPMIntSetIoctl = -217,
    }


	/// <summary> Adlink 7230 錯誤代碼轉換。</summary>
	/// <param name="iAdlinkErrorCode">錯誤代碼。</param>
	/// <param name="clsInfo">資訊。</param>
	/// <returns>回傳錯誤代碼。</returns>
	public static int Adlink7230ErrorCode(int iAdlinkErrorCode, System.Reflection.MethodBase clsInfo)
	{
		if (iAdlinkErrorCode == (int)Error_7230.NoError)
		{
			return ST_SUCCESS;
		}
		else
		{
			XStatus.Report(XStatus.Type.Motion, clsInfo, "Adlink 7230 : " + ((Error_7230)iAdlinkErrorCode).ToString());
			return ER_IO_7230_NO_ERROR + iAdlinkErrorCode;
		}
	}

	/// <summary> Adlink 7250 錯誤代碼轉換。</summary>
	/// <param name="iAdlinkErrorCode">錯誤代碼。</param>
	/// <param name="clsInfo">資訊。</param>
	/// <returns>回傳錯誤代碼。</returns>
    public static int Adlink7250ErrorCode(int iAdlinkErrorCode, System.Reflection.MethodBase clsInfo)
    {
        if (iAdlinkErrorCode == (int)Error_7250.NoError)
        {
            return ST_SUCCESS;
        }
        else
        {
            XStatus.Report(XStatus.Type.Motion, clsInfo, "Adlink 7250 : " + ((Error_7250)iAdlinkErrorCode).ToString());
            return ER_IO_7250_NO_ERROR + iAdlinkErrorCode;
        }
    }

	#endregion

    #region " PLC - 錯誤碼轉譯區 "

    /// <summary>MX Component 錯誤表。</summary>
    public enum MX_Component : int
    {
        NoError = 0,
        Timeout = -1,
        SendError = -2,
        ReceiveError = -3,
        ConnectError = -4,
        ElseError = -5,
    }

    /// <summary> MX Component 錯誤代碼轉換。</summary>
    /// <param name="iMxComponentErrorCode">錯誤代碼。</param>
    /// <param name="clsInfo">資訊。</param>
    /// <returns>回傳錯誤代碼。</returns>
    public static int MxComponentErrorCode(int iMxComponentErrorCode, System.Reflection.MethodBase clsInfo)
    {
        if (iMxComponentErrorCode == (int) MX_Component.NoError)
        {
            return ST_SUCCESS;
        }
        else
        {
            if (iMxComponentErrorCode == 0x01010002 ||
                iMxComponentErrorCode == 0x01808505 ||
                iMxComponentErrorCode == 0x10000044 )
            {
                iMxComponentErrorCode = (int)MX_Component.Timeout;
            }
            else if (iMxComponentErrorCode == 0x01808201 ||
                     iMxComponentErrorCode == 0x01808202 ||
                     iMxComponentErrorCode == 0x01808302 ||
                     iMxComponentErrorCode == 0x01808503)
            {
                iMxComponentErrorCode = (int) MX_Component.SendError;
            }
            else if (iMxComponentErrorCode == 0x01808301 ||
                     iMxComponentErrorCode == 0x01808504)
            {
                iMxComponentErrorCode = (int)MX_Component.ReceiveError;
            }
            else if (iMxComponentErrorCode == 0x01808502 ||
                     iMxComponentErrorCode == 0x01808008 ||
                     iMxComponentErrorCode == 0x01802064 ||
                     iMxComponentErrorCode == 0x0180840C ||
                     iMxComponentErrorCode == 0x0180840D)
            {
                iMxComponentErrorCode = (int)MX_Component.ConnectError;
            }
            else
            {
                iMxComponentErrorCode = (int)MX_Component.ElseError;
            }

            XStatus.Report(XStatus.Type.PLC, clsInfo, "MxComponent : " + ((MX_Component)iMxComponentErrorCode).ToString());
            return ER_PLC_MX_COMPONENT_NO_ERROR + iMxComponentErrorCode;
        }
    }

    #endregion

}

/// <summary>裝置類別。</summary>
public struct XDeviceType
{
    /// <summary>DIO卡 Advanttech ADAM_6050。</summary>
    public const string ADAM_6050 = "ADAM_6050";
    /// <summary>DIO卡 ADLink PCI-7230。</summary>
    public const string ADLINK_7230 = "PCI_7230";
    /// <summary>DIO卡 ADLink PCI-7250。</summary>
    public const string ADLINK_7250 = "PCI_7250";
    /// <summary>DIO卡 ADLink PCI-7440。</summary>
    public const string ADLINK_7442 = "PCI_7442";
    /// <summary>虛擬 Digital Input 卡。</summary>
    public const string VIRTUAL_DI = "Virtual_DI";
    /// <summary>虛擬 Digital Output 卡。</summary>
    public const string VIRTUAL_DO = "Virtual_DO";
	/// <summary>虛擬 Digital Input/Output 卡。</summary>
	public const string VIRTUAL_DIO = "Virtual_DIO";
	/// <summary>DIO卡 ADLink PCI-7440。</summary>
	public const string ADLINK_8164 = "Adlink_8164";
	/// <summary>DIO卡 ADLink PCI-7440。</summary>
	public const string FESTO_CVE = "Festo";
	/// <summary>虛擬 Motion 卡。</summary>
	public const string VIRTUAL_MOTION = "Virtual Motion";
    /// <summary>LogRecoder名稱。</summary>
    public const string LOG_RECODER = "訊息紀錄器 / 收集器";
}