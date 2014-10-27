﻿//**************************************
//File generated by TRAVERSE SDK::Code Generator tool.
//Copyright(c) 2014, Open Systems, Inc.
//Wednesday, October 01, 2014
//**************************************
//DO NOT edit this file. Instead use the partial class in PartnerItemXref.cs

#region using directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using TRAVERSE.Core;
#endregion

namespace TRAVERSE.Business
{
    ///<summary>
     //An object representation of 'tblEdPartnerItemXref'.
     //</summary>
    [Serializable, DataObject]
    public abstract class PartnerItemXrefBase : EntityBase
    {
        #region Fields
        [NonSerialized]
        ///<summary>
        ///inner data of the entity.
        ///</summary>
        private TblEdPartnerItemXrefEntityData entityData;

        ///<summary>
        ///a backup of the inner data of the entity.
        ///</summary>
        private TblEdPartnerItemXrefEntityData backupData;
        
        #endregion
        
        #region Constructor
        /// <summary>
        /// Instantiates the object and initializes inner data classes.
        /// </summary>
        protected PartnerItemXrefBase(string compId):base(compId)
        {
            //initialize inner dataclass
            this.entityData = new TblEdPartnerItemXrefEntityData();
            this.backupData = null;
        }
        #endregion
        
        #region Properties
        /// <summary>
        /// Gets or sets the database field PartnerId. 
        /// </summary>
        /// <value>This type is varchar.</value>
        /// <remarks>
        /// This property can not be set to null. 
        /// </remarks>
        [DescriptionAttribute(""), BindableAttribute(true)]
        [DataObjectField(true, false, false, 50)]
        public virtual System.String PartnerId
        {
            get
            {
                return this.entityData.PartnerId; 
            }
            set
            {
                if (!this.IsNew || this.entityData.PartnerId == value)
                    return;
                    
                OnColumnChanging("PartnerId");
                this.entityData.PartnerId = value;
                OnColumnChanged("PartnerId");
                OnPropertyChanged("PartnerId");
            }
        }
        
        /// <summary>
        ///Get the original value of the PartnerId property.
        /// </summary>
        /// <remarks>This is the original value of the PartnerId property.</remarks>
        /// <value>This type is varchar</value>
        [BrowsableAttribute(false), XmlIgnoreAttribute()]
        public  virtual System.String OriginalPartnerId
        {
            get { return this.entityData.OriginalPartnerId; }
            set { this.entityData.OriginalPartnerId = value; }
        }
        
        /// <summary>
        /// Gets or sets the database field TravItemId. 
        /// </summary>
        /// <value>This type is varchar.</value>
        /// <remarks>
        /// This property can not be set to null. 
        /// </remarks>
        [DescriptionAttribute(""), BindableAttribute(true)]
        [DataObjectField(true, false, false, 20)]
        public virtual System.String TravItemId
        {
            get
            {
                return this.entityData.TravItemId; 
            }
            set
            {
                if (!this.IsNew || this.entityData.TravItemId == value)
                    return;
                    
                OnColumnChanging("TravItemId");
                this.entityData.TravItemId = value;
                OnColumnChanged("TravItemId");
                OnPropertyChanged("TravItemId");
            }
        }
        
        /// <summary>
        ///Get the original value of the TravItemId property.
        /// </summary>
        /// <remarks>This is the original value of the TravItemId property.</remarks>
        /// <value>This type is varchar</value>
        [BrowsableAttribute(false), XmlIgnoreAttribute()]
        public  virtual System.String OriginalTravItemId
        {
            get { return this.entityData.OriginalTravItemId; }
            set { this.entityData.OriginalTravItemId = value; }
        }
        
        /// <summary>
        /// Gets or sets the database field TravUom. 
        /// </summary>
        /// <value>This type is varchar.</value>
        /// <remarks>
        /// This property can not be set to null. 
        /// </remarks>
        [DescriptionAttribute(""), BindableAttribute(true)]
        [DataObjectField(true, false, false, 5)]
        public virtual System.String TravUom
        {
            get
            {
                return this.entityData.TravUom; 
            }
            set
            {
                if (!this.IsNew || this.entityData.TravUom == value)
                    return;
                    
                OnColumnChanging("TravUom");
                this.entityData.TravUom = value;
                OnColumnChanged("TravUom");
                OnPropertyChanged("TravUom");
            }
        }
        
        /// <summary>
        ///Get the original value of the TravUom property.
        /// </summary>
        /// <remarks>This is the original value of the TravUom property.</remarks>
        /// <value>This type is varchar</value>
        [BrowsableAttribute(false), XmlIgnoreAttribute()]
        public  virtual System.String OriginalTravUom
        {
            get { return this.entityData.OriginalTravUom; }
            set { this.entityData.OriginalTravUom = value; }
        }
        
        /// <summary>
        /// Gets or sets the database field EdiUom. 
        /// </summary>
        /// <value>This type is varchar.</value>
        /// <remarks>
        /// This property can not be set to null. 
        /// </remarks>
        [DescriptionAttribute(""), BindableAttribute(true)]
        [DataObjectField(false, false, false, 5)]
        public virtual System.String EdiUom
        {
            get
            {
                return this.entityData.EdiUom; 
            }
            set
            {
                if (this.entityData.EdiUom == value)
                    return;
                    
                OnColumnChanging("EdiUom");
                this.entityData.EdiUom = value;
                OnColumnChanged("EdiUom");
                OnPropertyChanged("EdiUom");
            }
        }
        
        /// <summary>
        /// Gets or sets the database field EAN. 
        /// </summary>
        /// <value>This type is varchar.</value>
        /// <remarks>
        /// This property can be set to null. 
        /// </remarks>
        [DescriptionAttribute(""), BindableAttribute(true)]
        [DataObjectField(false, false, true, 50)]
        public virtual System.String EAN
        {
            get
            {
                return this.entityData.EAN; 
            }
            set
            {
                if (this.entityData.EAN == value)
                    return;
                    
                OnColumnChanging("EAN");
                this.entityData.EAN = value;
                OnColumnChanged("EAN");
                OnPropertyChanged("EAN");
            }
        }
        
        /// <summary>
        /// Gets or sets the database field GTIN. 
        /// </summary>
        /// <value>This type is varchar.</value>
        /// <remarks>
        /// This property can be set to null. 
        /// </remarks>
        [DescriptionAttribute(""), BindableAttribute(true)]
        [DataObjectField(false, false, true, 50)]
        public virtual System.String GTIN
        {
            get
            {
                return this.entityData.GTIN; 
            }
            set
            {
                if (this.entityData.GTIN == value)
                    return;
                    
                OnColumnChanging("GTIN");
                this.entityData.GTIN = value;
                OnColumnChanged("GTIN");
                OnPropertyChanged("GTIN");
            }
        }
        
        /// <summary>
        /// Gets or sets the database field UPC. 
        /// </summary>
        /// <value>This type is varchar.</value>
        /// <remarks>
        /// This property can be set to null. 
        /// </remarks>
        [DescriptionAttribute(""), BindableAttribute(true)]
        [DataObjectField(false, false, true, 50)]
        public virtual System.String UPC
        {
            get
            {
                return this.entityData.UPC; 
            }
            set
            {
                if (this.entityData.UPC == value)
                    return;
                    
                OnColumnChanging("UPC");
                this.entityData.UPC = value;
                OnColumnChanged("UPC");
                OnPropertyChanged("UPC");
            }
        }
        
        /// <summary>
        /// Gets or sets the database field SKU. 
        /// </summary>
        /// <value>This type is varchar.</value>
        /// <remarks>
        /// This property can be set to null. 
        /// </remarks>
        [DescriptionAttribute(""), BindableAttribute(true)]
        [DataObjectField(false, false, true, 50)]
        public virtual System.String SKU
        {
            get
            {
                return this.entityData.SKU; 
            }
            set
            {
                if (this.entityData.SKU == value)
                    return;
                    
                OnColumnChanging("SKU");
                this.entityData.SKU = value;
                OnColumnChanged("SKU");
                OnPropertyChanged("SKU");
            }
        }
        
        /// <summary>
        /// Gets or sets the database field BuyerCode. 
        /// </summary>
        /// <value>This type is varchar.</value>
        /// <remarks>
        /// This property can be set to null. 
        /// </remarks>
        [DescriptionAttribute(""), BindableAttribute(true)]
        [DataObjectField(false, false, true, 50)]
        public virtual System.String BuyerCode
        {
            get
            {
                return this.entityData.BuyerCode; 
            }
            set
            {
                if (this.entityData.BuyerCode == value)
                    return;
                    
                OnColumnChanging("BuyerCode");
                this.entityData.BuyerCode = value;
                OnColumnChanged("BuyerCode");
                OnPropertyChanged("BuyerCode");
            }
        }
        
        /// <summary>
        /// Gets or sets the database field VendorCode. 
        /// </summary>
        /// <value>This type is varchar.</value>
        /// <remarks>
        /// This property can be set to null. 
        /// </remarks>
        [DescriptionAttribute(""), BindableAttribute(true)]
        [DataObjectField(false, false, true, 50)]
        public virtual System.String VendorCode
        {
            get
            {
                return this.entityData.VendorCode; 
            }
            set
            {
                if (this.entityData.VendorCode == value)
                    return;
                    
                OnColumnChanging("VendorCode");
                this.entityData.VendorCode = value;
                OnColumnChanged("VendorCode");
                OnPropertyChanged("VendorCode");
            }
        }
        
        /// <summary>
        /// Gets or sets the database field InternalCode. 
        /// </summary>
        /// <value>This type is varchar.</value>
        /// <remarks>
        /// This property can be set to null. 
        /// </remarks>
        [DescriptionAttribute(""), BindableAttribute(true)]
        [DataObjectField(false, false, true, 50)]
        public virtual System.String InternalCode
        {
            get
            {
                return this.entityData.InternalCode; 
            }
            set
            {
                if (this.entityData.InternalCode == value)
                    return;
                    
                OnColumnChanging("InternalCode");
                this.entityData.InternalCode = value;
                OnColumnChanged("InternalCode");
                OnPropertyChanged("InternalCode");
            }
        }
        
        /// <summary>
        /// Gets or sets the database field InternalCode1. 
        /// </summary>
        /// <value>This type is varchar.</value>
        /// <remarks>
        /// This property can be set to null. 
        /// </remarks>
        [DescriptionAttribute(""), BindableAttribute(true)]
        [DataObjectField(false, false, true, 50)]
        public virtual System.String InternalCode1
        {
            get
            {
                return this.entityData.InternalCode1; 
            }
            set
            {
                if (this.entityData.InternalCode1 == value)
                    return;
                    
                OnColumnChanging("InternalCode1");
                this.entityData.InternalCode1 = value;
                OnColumnChanged("InternalCode1");
                OnPropertyChanged("InternalCode1");
            }
        }
        
        /// <summary>
        /// Gets or sets the database field InternalCode2. 
        /// </summary>
        /// <value>This type is varchar.</value>
        /// <remarks>
        /// This property can be set to null. 
        /// </remarks>
        [DescriptionAttribute(""), BindableAttribute(true)]
        [DataObjectField(false, false, true, 50)]
        public virtual System.String InternalCode2
        {
            get
            {
                return this.entityData.InternalCode2; 
            }
            set
            {
                if (this.entityData.InternalCode2 == value)
                    return;
                    
                OnColumnChanging("InternalCode2");
                this.entityData.InternalCode2 = value;
                OnColumnChanged("InternalCode2");
                OnPropertyChanged("InternalCode2");
            }
        }
        
        #endregion "Properties"
        
        #region Table Meta Data
        /// <summary>
        ///The name of the underlying database table.
        /// </summary>
        [BrowsableAttribute(false), XmlIgnoreAttribute()]
        public static string TableName
        {
            get { return "tblEdPartnerItemXref"; }
        }
        
        /// <summary>
        ///The name of the underlying database table's columns.
        /// </summary>
        [BrowsableAttribute(false), XmlIgnoreAttribute()]
        public static string[] TableColumns
        {
            get
            {
                return new string[] {"PartnerId", "TravItemId", "TravUom", "EdiUom", "EAN", "GTIN", "UPC", "SKU", "BuyerCode", "VendorCode", "InternalCode", "InternalCode1", "InternalCode2"};
            }
        }
        /// <summary>
        /// Array containing name of primary key columns.
        /// </summary>
        [BrowsableAttribute(false), XmlIgnoreAttribute()]
        public static string[] KeyColumns
        {
            get { return new string[] {"PartnerId", "TravItemId", "TravUom"}; }
        }
        #region PartnerItemXrefColumn Enum
        
        /// <summary>
        /// Enumerate the PartnerItemXref columns.
        /// </summary>
        [Serializable]
        public enum Columns
        {
            [EnumTextValue("PartnerId")]
            [ColumnEnum("PartnerId", typeof(System.String), System.Data.DbType.AnsiString, true, false, false, 50)]
            PartnerId,
            [EnumTextValue("TravItemId")]
            [ColumnEnum("TravItemId", typeof(System.String), System.Data.DbType.AnsiString, true, false, false, 20)]
            TravItemId,
            [EnumTextValue("TravUom")]
            [ColumnEnum("TravUom", typeof(System.String), System.Data.DbType.AnsiString, true, false, false, 5)]
            TravUom,
            [EnumTextValue("EdiUom")]
            [ColumnEnum("EdiUom", typeof(System.String), System.Data.DbType.AnsiString, false, false, false, 5)]
            EdiUom,
            [EnumTextValue("EAN")]
            [ColumnEnum("EAN", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
            EAN,
            [EnumTextValue("GTIN")]
            [ColumnEnum("GTIN", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
            GTIN,
            [EnumTextValue("UPC")]
            [ColumnEnum("UPC", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
            UPC,
            [EnumTextValue("SKU")]
            [ColumnEnum("SKU", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
            SKU,
            [EnumTextValue("BuyerCode")]
            [ColumnEnum("BuyerCode", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
            BuyerCode,
            [EnumTextValue("VendorCode")]
            [ColumnEnum("VendorCode", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
            VendorCode,
            [EnumTextValue("InternalCode")]
            [ColumnEnum("InternalCode", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
            InternalCode,
            [EnumTextValue("InternalCode1")]
            [ColumnEnum("InternalCode1", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
            InternalCode1,
            [EnumTextValue("InternalCode2")]
            [ColumnEnum("InternalCode2", typeof(System.String), System.Data.DbType.AnsiString, false, false, true, 50)]
            InternalCode2
        }//End enum
    
        #endregion PartnerItemXrefColumn Enum        
        #endregion     
        #region Validation
        
        /// <summary>
        /// Assigns validation rules to this object based on model definition.
        /// </summary>
        /// <remarks>This method overrides the base class to add schema related validation.</remarks>
        protected override void AddValidationRules()
        {
            //Validation rules based on database schema.
            ValidationRules.AddRule(Validation.CommonRules.StringRequired,"PartnerId");
            ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("PartnerId",50));
            ValidationRules.AddRule(Validation.CommonRules.StringRequired,"TravItemId");
            ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("TravItemId",20));
            ValidationRules.AddRule(Validation.CommonRules.StringRequired,"TravUom");
            ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("TravUom",5));
            ValidationRules.AddRule(Validation.CommonRules.NotNull,"EdiUom");
            ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("EdiUom",5));
            ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("EAN",50));
            ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("GTIN",50));
            ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("UPC",50));
            ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("SKU",50));
            ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("BuyerCode",50));
            ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("VendorCode",50));
            ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("InternalCode",50));
            ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("InternalCode1",50));
            ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("InternalCode2",50));
        }
           #endregion
        #region Overrides
        /// <summary>
        /// Data structure with backing fields for entity class.
        /// </summary>
        protected override ICloneable BackupData
        {
            get
            {
                return backupData;
            }
            set
            {
                backupData = value as TblEdPartnerItemXrefEntityData;
            }
        }
        /// <summary>
        /// Data structure with backing fields for entity class.
        /// </summary>
        protected override ICloneable EntityData
        {
            get
            {
                return entityData;
            }
            set
            {
                entityData = value as TblEdPartnerItemXrefEntityData;
            }
        }
        #endregion

    }
}    

