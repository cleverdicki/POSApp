//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POSApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int transactionId { get; set; }
        public string customerName { get; set; }
        public string foodName { get; set; }
        public Nullable<int> foodQuantity { get; set; }
        public Nullable<int> foodPrice { get; set; }
    }
}
