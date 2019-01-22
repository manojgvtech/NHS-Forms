using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NHS.Models
{
    public class clsClinicalCodingModel
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

    //public class clListPatientDetailsDashbord
    //{
    //    public List<clsClinicalCodingModel> CilinicalCoding { get; set; }
    //    //public List<clsBindPatientDetailsSJRReview> PatientDtlsAndSJRReview { get; set; }
    //}
}