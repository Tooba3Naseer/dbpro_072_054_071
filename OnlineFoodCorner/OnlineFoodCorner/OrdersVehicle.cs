//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineFoodCorner
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrdersVehicle
    {
        public int OrderId { get; set; }
        public int VehicleId { get; set; }
        public string Status { get; set; }
        public System.DateTime AssignmentDate { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
