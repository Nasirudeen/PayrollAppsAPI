//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PayrollAppsAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Loan
    {
        public int LoanId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public string LoanName { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Deduction { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
