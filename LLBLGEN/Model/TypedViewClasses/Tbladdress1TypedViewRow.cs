﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.6.</auto-generated>
//------------------------------------------------------------------------------
using System;

namespace RideShare.LLBLGEN.TypedViewClasses
{
	/// <summary>Class which represents a row in the typedView 'Tbladdress1'.</summary>
	public partial class Tbladdress1TypedViewRow 
	{
		partial void OnCreated();
		
		/// <summary>Initializes a new instance of the <see cref="Tbladdress1TypedViewRow"/> class.</summary>
		public Tbladdress1TypedViewRow()
		{
			OnCreated();
		}
		
		/// <summary>Gets or sets the AddressCreateDate field. </summary>
		public System.DateTime AddressCreateDate { get; set; }
		/// <summary>Gets or sets the AddressGuid field. </summary>
		public System.Guid AddressGuid { get; set; }
		/// <summary>Gets or sets the AddressUpdateDate field. </summary>
		public System.DateTime AddressUpdateDate { get; set; }
		/// <summary>Gets or sets the City field. </summary>
		public System.String City { get; set; }
		/// <summary>Gets or sets the PostalCode field. </summary>
		public Nullable<System.Int32> PostalCode { get; set; }
		/// <summary>Gets or sets the State field. </summary>
		public System.String State { get; set; }
		/// <summary>Gets or sets the Street1 field. </summary>
		public System.String Street1 { get; set; }
		/// <summary>Gets or sets the Street2 field. </summary>
		public System.String Street2 { get; set; }
		/// <summary>Gets or sets the UserGuid field. </summary>
		public System.Guid UserGuid { get; set; }
	}
}
