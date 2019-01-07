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
    
    public partial class CarePhase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarePhase()
        {
            this.SJRFormProblemTypes = new HashSet<SJRFormProblemType>();
            this.SJRFormProblemTypes1 = new HashSet<SJRFormProblemType>();
            this.SJRFormProblemTypes2 = new HashSet<SJRFormProblemType>();
            this.SJRFormProblemTypes3 = new HashSet<SJRFormProblemType>();
            this.SJRFormProblemTypes4 = new HashSet<SJRFormProblemType>();
            this.SJRFormProblemTypes5 = new HashSet<SJRFormProblemType>();
        }
    
        public int CarePhaseID { get; set; }
        public string PhaseName { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SJRFormProblemType> SJRFormProblemTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SJRFormProblemType> SJRFormProblemTypes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SJRFormProblemType> SJRFormProblemTypes2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SJRFormProblemType> SJRFormProblemTypes3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SJRFormProblemType> SJRFormProblemTypes4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SJRFormProblemType> SJRFormProblemTypes5 { get; set; }
    }
}
