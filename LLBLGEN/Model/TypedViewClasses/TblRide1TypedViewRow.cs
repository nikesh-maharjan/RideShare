﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.6.</auto-generated>
//------------------------------------------------------------------------------
using System;

namespace RideShare.LLBLGEN.TypedViewClasses
{
	/// <summary>Class which represents a row in the typedView 'TblRide1'.</summary>
	public partial class TblRide1TypedViewRow 
	{
		partial void OnCreated();
		
		/// <summary>Initializes a new instance of the <see cref="TblRide1TypedViewRow"/> class.</summary>
		public TblRide1TypedViewRow()
		{
			OnCreated();
		}
		
		/// <summary>Gets or sets the RideCreateDate field. </summary>
		public System.DateTime RideCreateDate { get; set; }
		/// <summary>Gets or sets the RideEndAddressGuid field. </summary>
		public System.Guid RideEndAddressGuid { get; set; }
		/// <summary>Gets or sets the RideEndDateTime field. </summary>
		public System.DateTime RideEndDateTime { get; set; }
		/// <summary>Gets or sets the RideFromGuid field. </summary>
		public System.Guid RideFromGuid { get; set; }
		/// <summary>Gets or sets the RideGuid field. </summary>
		public System.Guid RideGuid { get; set; }
		/// <summary>Gets or sets the RideStartAddressGuid field. </summary>
		public System.Guid RideStartAddressGuid { get; set; }
		/// <summary>Gets or sets the RideStartDateTime field. </summary>
		public System.DateTime RideStartDateTime { get; set; }
		/// <summary>Gets or sets the RideToGuid field. </summary>
		public System.Guid RideToGuid { get; set; }
		/// <summary>Gets or sets the RideUpdateDate field. </summary>
		public System.DateTime RideUpdateDate { get; set; }
	}
}
