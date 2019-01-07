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
    
    public partial class OtherReferral
    {
        public int OtherReferral_ID { get; set; }
        public Nullable<int> PatientID { get; set; }
        public Nullable<bool> PatientSafetySIRI { get; set; }
        public string PatientSafetySIRIReason { get; set; }
        public Nullable<bool> ChildDeathCoordinator { get; set; }
        public Nullable<bool> LearningDisabilityNurse { get; set; }
        public Nullable<bool> HeadOfCompliance { get; set; }
        public string HeadOfComplianceReason { get; set; }
        public Nullable<bool> PALsComplaints { get; set; }
        public string PALsComplaintsReason { get; set; }
        public Nullable<bool> WardTeam { get; set; }
        public string WardTeamReason { get; set; }
        public Nullable<bool> Other { get; set; }
        public string OtherReason { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual PatientMap PatientMap { get; set; }
    }
}
