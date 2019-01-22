using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NHS.Models
{
    public class clsFeedBackModel
    {
        public int FeedBack_ID { get; set; }
        public Nullable<int> PatientID { get; set; }
        [Display(Name = "Above & Beyond form completed")]
        public bool FormCompleted { get; set; }
        [Display(Name = "Compliments fed back to clinical team")]
        public bool ComplementsFedBack { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
  
}