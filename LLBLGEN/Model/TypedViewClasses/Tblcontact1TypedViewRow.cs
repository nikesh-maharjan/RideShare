﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.6.</auto-generated>
//------------------------------------------------------------------------------
using System;

namespace RideShare.LLBLGEN.TypedViewClasses
{
	/// <summary>Class which represents a row in the typedView 'Tblcontact1'.</summary>
	public partial class Tblcontact1TypedViewRow 
	{
		partial void OnCreated();
		
		/// <summary>Initializes a new instance of the <see cref="Tblcontact1TypedViewRow"/> class.</summary>
		public Tblcontact1TypedViewRow()
		{
			OnCreated();
		}
		
		/// <summary>Gets or sets the ContactCreateDate field. </summary>
		public System.DateTime ContactCreateDate { get; set; }
		/// <summary>Gets or sets the ContactGuid field. </summary>
		public System.Guid ContactGuid { get; set; }
		/// <summary>Gets or sets the ContactType field. </summary>
		public Nullable<System.Guid> ContactType { get; set; }
		/// <summary>Gets or sets the ContactUpdateDate field. </summary>
		public System.DateTime ContactUpdateDate { get; set; }
		/// <summary>Gets or sets the ContactValue field. </summary>
		public System.String ContactValue { get; set; }
		/// <summary>Gets or sets the IsActive field. </summary>
		public System.String IsActive { get; set; }
		/// <summary>Gets or sets the UserGuid field. </summary>
		public System.Guid UserGuid { get; set; }
	}
}
