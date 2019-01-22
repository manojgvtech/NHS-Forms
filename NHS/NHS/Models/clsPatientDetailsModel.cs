using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NHS.Models
{
    public class clsPatientDetailsModel
    {

        public clsPatientDetails objclPatientDetails { get; set; }
        public List<clsClinicalCoding> CilinicalCoding { get; set; }
    }

    public class clPatientDetailsDashbord
    {
        public List<clsPatientDetailsDashbord> PatientDtls { get; set; }
        //public List<clsClinicalCoding> clinicalCoding { get; set; }
        //public List<clsBindPatientDetailsSJRReview> PatientDtlsAndSJRReview { get; set; }
    }

    public class clsPatientDetails
    {
        //public int PatientId { get; set; }
        //[Display(Name = "Patient Name")]
        //public string PatientName { get; set; }
        //[Display(Name = "MRN")]
        //public string MRN { get; set; }
        //[Display(Name = "Gender")]
        //public bool Gender { get; set; }
        //[Display(Name = "Patient age at time of death")]
        //public Nullable<int> Age { get; set; }
        //[Display(Name = "Day/ Date of Admission")]
        //public Nullable<System.DateTime> DateofAdmission { get; set; }
        //[Display(Name = "Ward (on discharge)")]
        //public string DischargeWard { get; set; }       
        //public Nullable<int> DischargeConsultantCode { get; set; }
        //[Display(Name = "Emergency / Planned Admission")]
        //public string EmergencyAdmission { get; set; }
        //[Display(Name = "Time of arrival")]
        //public Nullable<System.TimeSpan> TimeofAdmission { get; set; }
        //[Display(Name = "Day/ Date of Death")]
        //public Nullable<System.DateTime> DateofDeath { get; set; }
        //[Display(Name = "Time of death")]
        //public Nullable<System.TimeSpan> TimeofDeath { get; set; }
        //[Display(Name = "Primary Diagnosis")]
        //public string PrimaryDiagnosis { get; set; }
        //[Display(Name = "Coding issue identified?")]
        //public bool CodingIssueIdentified { get; set; }
        //[Display(Name = "Comments on coding")]
        //public string Comments { get; set; }
        //public string CreatedBy { get; set; }
        //public Nullable<System.DateTime> CreateDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public Nullable<System.DateTime> UpdatedDate { get; set; }
      
        public int PatientId { get; set; }
        public Nullable<int> SpellNumber { get; set; }
        [Display(Name = "Patient Name")]
        public string PatientName { get; set; }
        [Display(Name = "MRN")]
        public Nullable<int> NHSNumber { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Display(Name = "Patient age at time of death")]
        public Nullable<int> Age { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        [Display(Name = "Day/ Date of Admission")]
        public Nullable<System.DateTime> DateofAdmission { get; set; }
        [Display(Name = "Time of arrival")]
        public Nullable<System.TimeSpan> TimeofAdmission { get; set; }
        [Display(Name = "Ward (on discharge)")]
        public string DischargeWard { get; set; }
        [Display(Name = "Day/ Date of Death")]
        public Nullable<System.DateTime> DateofDeath { get; set; }
        [Display(Name = "Time of death")]
        public Nullable<System.TimeSpan> TimeofDeath { get; set; }
        public string WardofDeath { get; set; }
        public string DischargeConsultantCode { get; set; }
        public string DischargeConsutantName { get; set; }
        public string DischargeSpecialtyCode { get; set; }
        public string DischargeSpeciality { get; set; }
        public string Caregroup { get; set; }
        [Display(Name = "Emergency / Planned Admission")]
        public string AdmissionType { get; set; }
        [Display(Name = "Primary Diagnosis")]
        public string PrimaryDiagnosis { get; set; }
        public string PrimaryProcedure { get; set; }
        public Nullable<int> ComorbiditiesCount { get; set; }
        public string SHMIGroup { get; set; }
        public bool CodingIssueIdentified { get; set; }
        [Display(Name = "Comments on coding")]
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

    }

    public class clsPatientDetailsDashbord
    {
        //public int PatientId { get; set; }
        //[Display(Name = "Patient Name")]
        //public string PatientName { get; set; }
        //[Display(Name = "MRN")]
        //public string MRN { get; set; }
        //[Display(Name = "Patient age at time of death")]
        //public Nullable<int> Age { get; set; }
        //[Display(Name = "Day/ Date of Admission")]
        //public Nullable<System.DateTime> DateofAdmission { get; set; }
        //[Display(Name = "Ward (on discharge)")]
        //public string DischargeWard { get; set; }
        //public int DischargeConsultantCode { get; set; }
        //[Display(Name = "Emergency / Planned Admission")]
        //public string EmergencyAdmission { get; set; }
        //[Display(Name = "Time of arrival")]
        //public Nullable<System.TimeSpan> TimeofAdmission { get; set; }
        //[Display(Name = "Day/ Date of Death")]
        //public Nullable<System.DateTime> DateofDeath { get; set; }
        //[Display(Name = "Time of death")]
        //public Nullable<System.TimeSpan> TimeofDeath { get; set; }
        //[Display(Name = "Consultant (on discharge)")]
        //public string DischargeConsultantName { get; set; }

        public int PatientId { get; set; }
        public Nullable<int> SpellNumber { get; set; }
        public string PatientName { get; set; }
        public Nullable<int> NHSNumber { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<System.DateTime> DateofAdmission { get; set; }
        public Nullable<System.TimeSpan> TimeofAdmission { get; set; }
        public string DischargeWard { get; set; }
        public Nullable<System.DateTime> DateofDeath { get; set; }
        public Nullable<System.TimeSpan> TimeofDeath { get; set; }
        public string WardofDeath { get; set; }
        public string DischargeConsultantCode { get; set; }
        public string DischargeConsutantName { get; set; }
        public string DischargeSpecialtyCode { get; set; }
        public string DischargeSpeciality { get; set; }
        public string Caregroup { get; set; }
        public string AdmissionType { get; set; }
        public string PrimaryDiagnosis { get; set; }
        public string PrimaryProcedure { get; set; }
        public Nullable<int> ComorbiditiesCount { get; set; }
        public string SHMIGroup { get; set; }
        public bool CodingIssueIdentified { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }


        public Nullable<int> PatientID { get; set; }
        public string Spellnumber { get; set; }
        public Nullable<int> METriage { get; set; }
        public Nullable<int> SJR1 { get; set; }
        public Nullable<int> SJR2 { get; set; }
        public Nullable<int> SJRoutcome { get; set; }
        public string MortalityReview { get; set; }
        public string CodingReview { get; set; }

       
        public Nullable<bool> FullSJRRequired { get; set; }
    }


    //public class clsBindPatientDetailsSJRReview
    //{
    //    public int PatientId { get; set; }
    //    [Display(Name = "Patient Name")]
    //    public string PatientName { get; set; }
    //    [Display(Name = "MRN")]
    //    public string MRN { get; set; }
    //    [Display(Name = "Patient age at time of death")]
    //    public Nullable<int> Age { get; set; }
    //    [Display(Name = "Day/ Date of Admission")]
    //    public Nullable<System.DateTime> DateofAdmission { get; set; }
    //    [Display(Name = "Ward (on discharge)")]
    //    public string DischargeWard { get; set; }
    //    public int DischargeConsultantCode { get; set; }
    //    [Display(Name = "Emergency / Planned Admission")]
    //    public string EmergencyAdmission { get; set; }
    //    [Display(Name = "Time of arrival")]
    //    public Nullable<System.TimeSpan> TimeofAdmission { get; set; }
    //    [Display(Name = "Day/ Date of Death")]
    //    public Nullable<System.DateTime> DateofDeath { get; set; }
    //    [Display(Name = "Time of death")]
    //    public Nullable<System.TimeSpan> TimeofDeath { get; set; }
    //    [Display(Name = "Consultant (on discharge)")]
    //    public string DischargeConsultantName { get; set; }
    //    public int SJRReviewSpecialityID { get; set; }
    //    public string Name { get; set; }
    //}


    public class clsClinicalCoding
    {
        public int ClinicalCodingID { get; set; }
        public Nullable<int> PatienitID { get; set; }
        public Nullable<int> SpellNumber { get; set; }
        public Nullable<int> FCENumber { get; set; }
        public Nullable<int> Position { get; set; }
        public string Diagnosiscode { get; set; }
        public string DiagnosisDescription { get; set; }
        public Nullable<int> ComorbidityFlag { get; set; }
        public string ProcedureCode { get; set; }
        public string ProcedureDescription { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}