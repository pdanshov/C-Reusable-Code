﻿//**************************************
//File generated by TRAVERSE SDK::Code Generator tool.
//Copyright(c) 2014, Open Systems, Inc.
//Wednesday, October 01, 2014
//**************************************
#region Using directives
using System;
using System.ComponentModel;		
#endregion
namespace TRAVERSE.Business
{
	///<summary>
	///The data structure representation of the 'tblEdPartnerItemXref' table.
	///</summary>
	///<remarks>
	///This struct is generated by a tool and should never be modified.
	///</remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class TblEdPartnerItemXrefEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// PartnerId : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "tblEdPartnerItemXref"</remarks>
			public System.String PartnerId;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.String OriginalPartnerId;
			
			/// <summary>			
			/// TravItemId : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "tblEdPartnerItemXref"</remarks>
			public System.String TravItemId;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.String OriginalTravItemId;
			
			/// <summary>			
			/// TravUom : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "tblEdPartnerItemXref"</remarks>
			public System.String TravUom;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.String OriginalTravUom;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// EdiUom : 
		/// </summary>
		public System.String  EdiUom ;
		
		/// <summary>
		/// EAN : 
		/// </summary>
		public System.String  EAN = null;
		
		/// <summary>
		/// GTIN : 
		/// </summary>
		public System.String  GTIN = null;
		
		/// <summary>
		/// UPC : 
		/// </summary>
		public System.String  UPC = null;
		
		/// <summary>
		/// SKU : 
		/// </summary>
		public System.String  SKU = null;
		
		/// <summary>
		/// BuyerCode : 
		/// </summary>
		public System.String  BuyerCode = null;
		
		/// <summary>
		/// VendorCode : 
		/// </summary>
		public System.String  VendorCode = null;
		
		/// <summary>
		/// InternalCode : 
		/// </summary>
		public System.String  InternalCode = null;
		
		/// <summary>
		/// InternalCode1 : 
		/// </summary>
		public System.String  InternalCode1 = null;
		
		/// <summary>
		/// InternalCode2 : 
		/// </summary>
		public System.String  InternalCode2 = null;
		#endregion
			
		#endregion "Variable Declarations"
		
		public Object Clone()
		{
			TblEdPartnerItemXrefEntityData _tmp = new TblEdPartnerItemXrefEntityData();
						
			_tmp.PartnerId = this.PartnerId;
			_tmp.OriginalPartnerId = this.OriginalPartnerId;
			_tmp.TravItemId = this.TravItemId;
			_tmp.OriginalTravItemId = this.OriginalTravItemId;
			_tmp.TravUom = this.TravUom;
			_tmp.OriginalTravUom = this.OriginalTravUom;
			
			_tmp.EdiUom = this.EdiUom;
			_tmp.EAN = this.EAN;
			_tmp.GTIN = this.GTIN;
			_tmp.UPC = this.UPC;
			_tmp.SKU = this.SKU;
			_tmp.BuyerCode = this.BuyerCode;
			_tmp.VendorCode = this.VendorCode;
			_tmp.InternalCode = this.InternalCode;
			_tmp.InternalCode1 = this.InternalCode1;
			_tmp.InternalCode2 = this.InternalCode2;
			
			return _tmp;
		}
		
	}//End struct
}

