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
    
    public partial class MedicalExaminerReview
    {
        public int MEReviewId { get; set; }
        public Nullable<int> PatientID { get; set; }
        public Nullable<int> ME_ID { get; set; }
        public Nullable<bool> QAP_Discussion { get; set; }
        public Nullable<bool> Notes_Review { get; set; }
        public Nullable<bool> Nok_Discussion { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string QAPName { get; set; }
    
        public virtual MedicalExaminer MedicalExaminer { get; set; }
        public virtual PatientDetails PatientDetails { get; set; }
    }
}
