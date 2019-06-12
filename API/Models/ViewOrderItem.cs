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
    
    public partial class ViewOrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PriceUnit { get; set; }
        public decimal DiscountUnit { get; set; }
        public Nullable<decimal> FinalPriceUnit { get; set; }
        public string Remark { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> OrderStatusId { get; set; }
        public string Product { get; set; }
        public Nullable<decimal> Date { get; set; }
        public string DateStr { get; set; }
        public string Mobile { get; set; }
        public string Person { get; set; }
        public string OrderStatus { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public Nullable<decimal> OrderDiscount { get; set; }
        public Nullable<decimal> Transport { get; set; }
    }
}