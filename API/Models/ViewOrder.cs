//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ViewOrder
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> DateG { get; set; }
        public Nullable<decimal> Date { get; set; }
        public string DateStr { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> Transport { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> PersonId { get; set; }
        public string Status { get; set; }
    }
}
