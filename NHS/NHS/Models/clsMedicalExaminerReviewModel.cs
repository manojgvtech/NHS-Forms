using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NHS.Models
{
    public class clsMedicalExaminerReviewModel
    {
        public clsMedicalExaminer objclsMedicalExaminer { get; set; }
        public clsMedicalExaminerReview objclsMedicalExaminerReview { get; set; }
    }

    public class clsMedicalExaminer
    {
        public int ME_ID { get; set; }

        [Display(Name = "Name of ME ")]
        public string ME_FirstName { get; set; }
        public string ME_MiddleName { get; set; }
        public string ME_LastName { get; set; }
        //[Display(Name = "Name of ME ")]
        //public string Fullname { get { return string.Format("{0} {1} {2}", ME_FirstName, ME_MiddleName, ME_LastName); } }
        //public string Fullname { get { return ME_FirstName + " " + ME_MiddleName + " " + ME_LastName; } }
        //public List<SelectListItem> Fullname { get; set; }
        
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
    public class clsMedicalExaminerReview
    {
        public int MEReviewId { get; set; }
        public int PatientID { get; set; }
        public int ME_ID { get; set; }
        public bool QAP_Discussion { get; set; }
        public bool Notes_Review { get; set; }
        public bool Nok_Discussion { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        [Display(Name = "Name of QAP")]
        public string QAPName { get; set; }

    }
}