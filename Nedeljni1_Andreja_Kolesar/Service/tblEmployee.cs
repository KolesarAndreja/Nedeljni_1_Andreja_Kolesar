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
    
    public partial class tblEmployee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblEmployee()
        {
            this.tblDailyReports = new HashSet<tblDailyReport>();
            this.tblEditRequests = new HashSet<tblEditRequest>();
            this.tblProjects = new HashSet<tblProject>();
            this.tblProjects1 = new HashSet<tblProject>();
            this.tblProjects2 = new HashSet<tblProject>();
            this.tblProjects3 = new HashSet<tblProject>();
            this.tblProjects4 = new HashSet<tblProject>();
        }
    
        public int employeeId { get; set; }
        public int userID { get; set; }
        public int sectorId { get; set; }
        public Nullable<int> positionID { get; set; }
        public int yearsOfService { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public int qualificationsId { get; set; }
        public Nullable<int> managerId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDailyReport> tblDailyReports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEditRequest> tblEditRequests { get; set; }
        public virtual tblManager tblManager { get; set; }
        public virtual tblPosition tblPosition { get; set; }
        public virtual tblProfessionalQualification tblProfessionalQualification { get; set; }
        public virtual tblSector tblSector { get; set; }
        public virtual tblUser tblUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProject> tblProjects { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProject> tblProjects1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProject> tblProjects2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProject> tblProjects3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProject> tblProjects4 { get; set; }
    }
}
