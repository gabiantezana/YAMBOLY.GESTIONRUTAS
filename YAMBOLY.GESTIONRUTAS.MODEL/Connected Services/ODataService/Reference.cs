﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Original file name:
// Generation date: 23/07/2018 03:51:11 p.m.
namespace MSS_YAMBOLY_GEOLOCATION.Services.ODataService
{
    
    /// <summary>
    /// There are no comments for ODataService in the schema.
    /// </summary>
    public partial class ODataService : global::System.Data.Services.Client.DataServiceContext
    {
        /// <summary>
        /// Initialize a new ODataService object.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public ODataService(global::System.Uri serviceRoot) : 
                base(serviceRoot)
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for OCRD in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<OCRDType> OCRD
        {
            get
            {
                if ((this._OCRD == null))
                {
                    this._OCRD = base.CreateQuery<OCRDType>("OCRD");
                }
                return this._OCRD;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<OCRDType> _OCRD;
        /// <summary>
        /// There are no comments for MSS_ZONA in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<MSS_ZONAType> MSS_ZONA
        {
            get
            {
                if ((this._MSS_ZONA == null))
                {
                    this._MSS_ZONA = base.CreateQuery<MSS_ZONAType>("MSS_ZONA");
                }
                return this._MSS_ZONA;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<MSS_ZONAType> _MSS_ZONA;
        /// <summary>
        /// There are no comments for MSS_RUTA in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public global::System.Data.Services.Client.DataServiceQuery<MSS_RUTAType> MSS_RUTA
        {
            get
            {
                if ((this._MSS_RUTA == null))
                {
                    this._MSS_RUTA = base.CreateQuery<MSS_RUTAType>("MSS_RUTA");
                }
                return this._MSS_RUTA;
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private global::System.Data.Services.Client.DataServiceQuery<MSS_RUTAType> _MSS_RUTA;
        /// <summary>
        /// There are no comments for OCRD in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToOCRD(OCRDType oCRDType)
        {
            base.AddObject("OCRD", oCRDType);
        }
        /// <summary>
        /// There are no comments for MSS_ZONA in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToMSS_ZONA(MSS_ZONAType mSS_ZONAType)
        {
            base.AddObject("MSS_ZONA", mSS_ZONAType);
        }
        /// <summary>
        /// There are no comments for MSS_RUTA in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public void AddToMSS_RUTA(MSS_RUTAType mSS_RUTAType)
        {
            base.AddObject("MSS_RUTA", mSS_RUTAType);
        }
    }
    /// <summary>
    /// There are no comments for MSS_YAMBOLY_GEOLOCATION.Services.ODataService.OCRDType in the schema.
    /// </summary>
    /// <KeyProperties>
    /// CardCode
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("OCRD")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("CardCode")]
    public partial class OCRDType : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new OCRDType object.
        /// </summary>
        /// <param name="cardCode">Initial value of CardCode.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static OCRDType CreateOCRDType(string cardCode)
        {
            OCRDType oCRDType = new OCRDType();
            oCRDType.CardCode = cardCode;
            return oCRDType;
        }
        /// <summary>
        /// There are no comments for Property CardName in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CardName
        {
            get
            {
                return this._CardName;
            }
            set
            {
                this.OnCardNameChanging(value);
                this._CardName = value;
                this.OnCardNameChanged();
                this.OnPropertyChanged("CardName");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CardName;
        partial void OnCardNameChanging(string value);
        partial void OnCardNameChanged();
        /// <summary>
        /// There are no comments for Property U_COORDINATESARRAY in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string U_COORDINATESARRAY
        {
            get
            {
                return this._U_COORDINATESARRAY;
            }
            set
            {
                this.OnU_COORDINATESARRAYChanging(value);
                this._U_COORDINATESARRAY = value;
                this.OnU_COORDINATESARRAYChanged();
                this.OnPropertyChanged("U_COORDINATESARRAY");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _U_COORDINATESARRAY;
        partial void OnU_COORDINATESARRAYChanging(string value);
        partial void OnU_COORDINATESARRAYChanged();
        /// <summary>
        /// There are no comments for Property CardCode in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string CardCode
        {
            get
            {
                return this._CardCode;
            }
            set
            {
                this.OnCardCodeChanging(value);
                this._CardCode = value;
                this.OnCardCodeChanged();
                this.OnPropertyChanged("CardCode");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _CardCode;
        partial void OnCardCodeChanging(string value);
        partial void OnCardCodeChanged();
        /// <summary>
        /// There are no comments for Property U_MSS_RUTA in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string U_MSS_RUTA
        {
            get
            {
                return this._U_MSS_RUTA;
            }
            set
            {
                this.OnU_MSS_RUTAChanging(value);
                this._U_MSS_RUTA = value;
                this.OnU_MSS_RUTAChanged();
                this.OnPropertyChanged("U_MSS_RUTA");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _U_MSS_RUTA;
        partial void OnU_MSS_RUTAChanging(string value);
        partial void OnU_MSS_RUTAChanged();
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for MSS_YAMBOLY_GEOLOCATION.Services.ODataService.MSS_ZONAType in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Code
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("MSS_ZONA")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("Code")]
    public partial class MSS_ZONAType : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new MSS_ZONAType object.
        /// </summary>
        /// <param name="code">Initial value of Code.</param>
        /// <param name="name">Initial value of Name.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static MSS_ZONAType CreateMSS_ZONAType(string code, string name)
        {
            MSS_ZONAType mSS_ZONAType = new MSS_ZONAType();
            mSS_ZONAType.Code = code;
            mSS_ZONAType.Name = name;
            return mSS_ZONAType;
        }
        /// <summary>
        /// There are no comments for Property Code in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                this.OnCodeChanging(value);
                this._Code = value;
                this.OnCodeChanged();
                this.OnPropertyChanged("Code");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Code;
        partial void OnCodeChanging(string value);
        partial void OnCodeChanged();
        /// <summary>
        /// There are no comments for Property Name in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.OnNameChanging(value);
                this._Name = value;
                this.OnNameChanged();
                this.OnPropertyChanged("Name");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Name;
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        /// <summary>
        /// There are no comments for Property U_MSS_SUPE in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string U_MSS_SUPE
        {
            get
            {
                return this._U_MSS_SUPE;
            }
            set
            {
                this.OnU_MSS_SUPEChanging(value);
                this._U_MSS_SUPE = value;
                this.OnU_MSS_SUPEChanged();
                this.OnPropertyChanged("U_MSS_SUPE");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _U_MSS_SUPE;
        partial void OnU_MSS_SUPEChanging(string value);
        partial void OnU_MSS_SUPEChanged();
        /// <summary>
        /// There are no comments for Property U_MSS_REGI in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string U_MSS_REGI
        {
            get
            {
                return this._U_MSS_REGI;
            }
            set
            {
                this.OnU_MSS_REGIChanging(value);
                this._U_MSS_REGI = value;
                this.OnU_MSS_REGIChanged();
                this.OnPropertyChanged("U_MSS_REGI");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _U_MSS_REGI;
        partial void OnU_MSS_REGIChanging(string value);
        partial void OnU_MSS_REGIChanged();
        /// <summary>
        /// There are no comments for Property U_COORDINATESARRAY in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string U_COORDINATESARRAY
        {
            get
            {
                return this._U_COORDINATESARRAY;
            }
            set
            {
                this.OnU_COORDINATESARRAYChanging(value);
                this._U_COORDINATESARRAY = value;
                this.OnU_COORDINATESARRAYChanged();
                this.OnPropertyChanged("U_COORDINATESARRAY");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _U_COORDINATESARRAY;
        partial void OnU_COORDINATESARRAYChanging(string value);
        partial void OnU_COORDINATESARRAYChanged();
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
    /// <summary>
    /// There are no comments for MSS_YAMBOLY_GEOLOCATION.Services.ODataService.MSS_RUTAType in the schema.
    /// </summary>
    /// <KeyProperties>
    /// Code
    /// </KeyProperties>
    [global::System.Data.Services.Common.EntitySetAttribute("MSS_RUTA")]
    [global::System.Data.Services.Common.DataServiceKeyAttribute("Code")]
    public partial class MSS_RUTAType : global::System.ComponentModel.INotifyPropertyChanged
    {
        /// <summary>
        /// Create a new MSS_RUTAType object.
        /// </summary>
        /// <param name="code">Initial value of Code.</param>
        /// <param name="name">Initial value of Name.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public static MSS_RUTAType CreateMSS_RUTAType(string code, string name)
        {
            MSS_RUTAType mSS_RUTAType = new MSS_RUTAType();
            mSS_RUTAType.Code = code;
            mSS_RUTAType.Name = name;
            return mSS_RUTAType;
        }
        /// <summary>
        /// There are no comments for Property Code in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                this.OnCodeChanging(value);
                this._Code = value;
                this.OnCodeChanged();
                this.OnPropertyChanged("Code");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Code;
        partial void OnCodeChanging(string value);
        partial void OnCodeChanged();
        /// <summary>
        /// There are no comments for Property Name in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this.OnNameChanging(value);
                this._Name = value;
                this.OnNameChanged();
                this.OnPropertyChanged("Name");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _Name;
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        /// <summary>
        /// There are no comments for Property U_MSS_COVE in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string U_MSS_COVE
        {
            get
            {
                return this._U_MSS_COVE;
            }
            set
            {
                this.OnU_MSS_COVEChanging(value);
                this._U_MSS_COVE = value;
                this.OnU_MSS_COVEChanged();
                this.OnPropertyChanged("U_MSS_COVE");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _U_MSS_COVE;
        partial void OnU_MSS_COVEChanging(string value);
        partial void OnU_MSS_COVEChanged();
        /// <summary>
        /// There are no comments for Property U_MSS_NOVE in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string U_MSS_NOVE
        {
            get
            {
                return this._U_MSS_NOVE;
            }
            set
            {
                this.OnU_MSS_NOVEChanging(value);
                this._U_MSS_NOVE = value;
                this.OnU_MSS_NOVEChanged();
                this.OnPropertyChanged("U_MSS_NOVE");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _U_MSS_NOVE;
        partial void OnU_MSS_NOVEChanging(string value);
        partial void OnU_MSS_NOVEChanged();
        /// <summary>
        /// There are no comments for Property U_MSS_ZONA in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string U_MSS_ZONA
        {
            get
            {
                return this._U_MSS_ZONA;
            }
            set
            {
                this.OnU_MSS_ZONAChanging(value);
                this._U_MSS_ZONA = value;
                this.OnU_MSS_ZONAChanged();
                this.OnPropertyChanged("U_MSS_ZONA");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _U_MSS_ZONA;
        partial void OnU_MSS_ZONAChanging(string value);
        partial void OnU_MSS_ZONAChanged();
        /// <summary>
        /// There are no comments for Property U_MSS_REGI in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string U_MSS_REGI
        {
            get
            {
                return this._U_MSS_REGI;
            }
            set
            {
                this.OnU_MSS_REGIChanging(value);
                this._U_MSS_REGI = value;
                this.OnU_MSS_REGIChanged();
                this.OnPropertyChanged("U_MSS_REGI");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _U_MSS_REGI;
        partial void OnU_MSS_REGIChanging(string value);
        partial void OnU_MSS_REGIChanged();
        /// <summary>
        /// There are no comments for Property U_COORDINATESARRAY in the schema.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public string U_COORDINATESARRAY
        {
            get
            {
                return this._U_COORDINATESARRAY;
            }
            set
            {
                this.OnU_COORDINATESARRAYChanging(value);
                this._U_COORDINATESARRAY = value;
                this.OnU_COORDINATESARRAYChanged();
                this.OnPropertyChanged("U_COORDINATESARRAY");
            }
        }
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        private string _U_COORDINATESARRAY;
        partial void OnU_COORDINATESARRAYChanging(string value);
        partial void OnU_COORDINATESARRAYChanged();
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        public event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")]
        protected virtual void OnPropertyChanged(string property)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new global::System.ComponentModel.PropertyChangedEventArgs(property));
            }
        }
    }
}