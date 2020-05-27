﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 原始程式碼已由 Microsoft.VSDesigner 自動產生，版本 4.0.30319.42000。
// 
#pragma warning disable 1591

namespace Bomb.WebReference {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BL_API_BOMBSoap", Namespace="http://tempuri.org/")]
    public partial class BL_API_BOMB : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetBombInformationOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetBombResultOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public BL_API_BOMB() {
            this.Url = global::Bomb.Properties.Settings.Default.Bomb_WebReference_BL_API_BOMB;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetBombInformationCompletedEventHandler GetBombInformationCompleted;
        
        /// <remarks/>
        public event GetBombResultCompletedEventHandler GetBombResultCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetBombInformation", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetBombInformation(string fab, string equipmentId, string BLId) {
            object[] results = this.Invoke("GetBombInformation", new object[] {
                        fab,
                        equipmentId,
                        BLId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetBombInformationAsync(string fab, string equipmentId, string BLId) {
            this.GetBombInformationAsync(fab, equipmentId, BLId, null);
        }
        
        /// <remarks/>
        public void GetBombInformationAsync(string fab, string equipmentId, string BLId, object userState) {
            if ((this.GetBombInformationOperationCompleted == null)) {
                this.GetBombInformationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBombInformationOperationCompleted);
            }
            this.InvokeAsync("GetBombInformation", new object[] {
                        fab,
                        equipmentId,
                        BLId}, this.GetBombInformationOperationCompleted, userState);
        }
        
        private void OnGetBombInformationOperationCompleted(object arg) {
            if ((this.GetBombInformationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetBombInformationCompleted(this, new GetBombInformationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetBombResult", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetBombResult(string fab, string equipmentId, string BLId, string pictureName, string XyAxis, string bombResult) {
            object[] results = this.Invoke("GetBombResult", new object[] {
                        fab,
                        equipmentId,
                        BLId,
                        pictureName,
                        XyAxis,
                        bombResult});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetBombResultAsync(string fab, string equipmentId, string BLId, string pictureName, string XyAxis, string bombResult) {
            this.GetBombResultAsync(fab, equipmentId, BLId, pictureName, XyAxis, bombResult, null);
        }
        
        /// <remarks/>
        public void GetBombResultAsync(string fab, string equipmentId, string BLId, string pictureName, string XyAxis, string bombResult, object userState) {
            if ((this.GetBombResultOperationCompleted == null)) {
                this.GetBombResultOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBombResultOperationCompleted);
            }
            this.InvokeAsync("GetBombResult", new object[] {
                        fab,
                        equipmentId,
                        BLId,
                        pictureName,
                        XyAxis,
                        bombResult}, this.GetBombResultOperationCompleted, userState);
        }
        
        private void OnGetBombResultOperationCompleted(object arg) {
            if ((this.GetBombResultCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetBombResultCompleted(this, new GetBombResultCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    public delegate void GetBombInformationCompletedEventHandler(object sender, GetBombInformationCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetBombInformationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetBombInformationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    public delegate void GetBombResultCompletedEventHandler(object sender, GetBombResultCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1099.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetBombResultCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetBombResultCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591