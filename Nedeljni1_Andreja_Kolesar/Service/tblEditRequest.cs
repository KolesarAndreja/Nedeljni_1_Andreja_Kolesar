//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nedeljni1_Andreja_Kolesar.Service
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblEditRequest
    {
        public int requestId { get; set; }
        public Nullable<int> employeeId { get; set; }
        public string field { get; set; }
        public int previousValue { get; set; }
        public int newValue { get; set; }
        public string status { get; set; }
        public System.DateTime requestDate { get; set; }
    
        public virtual tblEmployee tblEmployee { get; set; }
    }
}
