//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NHS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MedicalExaminer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MedicalExaminer()
        {
            this.MedicalExaminerReview = new HashSet<MedicalExaminerReview>();
        }
    
        public int ME_ID { get; set; }
        public string ME_FirstName { get; set; }
        public string ME_MiddleName { get; set; }
        public string ME_LastName { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MedicalExaminerReview> MedicalExaminerReview { get; set; }
    }
}
