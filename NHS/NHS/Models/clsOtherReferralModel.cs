using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NHS.Models
{
    public class clsOtherReferralModel
    {
        public int OtherReferral_ID { get; set; }
        public Nullable<int> PatientID { get; set; }
        [Display(Name = "Referred to Patient Safety for SIRI Scoping")]
        public bool PatientSafetySIRI { get; set; }
        [Display(Name = "Reason")]
        public string PatientSafetySIRIReason { get; set; }
        [Display(Name = "Referred to Child Death Co-ordinator")]
        public bool ChildDeathCoordinator { get; set; }
        [Display(Name = "Referred to Learning Disability Nurse for LEDER reporting")]
        public bool LearningDisabilityNurse { get; set; }
        [Display(Name = "Referred to Head of Compliance for CQC reporting")]
        public bool HeadOfCompliance { get; set; }
        [Display(Name = "Reason")]
        public string HeadOfComplianceReason { get; set; }
        [Display(Name = "Referred to PALs/ Complaints")]
        public bool PALsComplaints { get; set; }
        [Display(Name = "Reason")]
        public string PALsComplaintsReason { get; set; }
        [Display(Name = "Referred to Ward team")]
        public bool WardTeam { get; set; }
        [Display(Name = "Reason")]
        public string WardTeamReason { get; set; }
        [Display(Name = "Other")]
        public bool Other { get; set; }
        [Display(Name = "Other")]
        public string OtherReason { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}