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
    
    public partial class FormerStaff
    {
        public int FormerStaffId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<System.DateTime> ExitDate { get; set; }
        public string Reason { get; set; }
        public Nullable<decimal> ExitAllowance { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
