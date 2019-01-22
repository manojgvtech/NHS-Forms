using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHS.Models
{
    public class clsSJROutComeModel
    {
        public clsSJROutcome clsSjrOutCome { get; set; }
        public clsMortalitySurveillance clsMortalitySurveillance { get; set; }
    }

    public class clsSJROutcome
    {
        public int SJROutcome_ID { get; set; }
        public Nullable<int> PatientID { get; set; }
        public bool Stage2SJRRequired { get; set; }
        public string Stage2SJRDateSent { get; set; }
        public string Stage2SJRSentTo { get; set; }
        public string ReferenceNumber { get; set; }
        public Nullable<System.DateTime> DateReceived { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }

    public class clsMortalitySurveillance
    {
        public int MortalitySurveillance_ID { get; set; }
        public Nullable<int> PatientID { get; set; }
        public bool PresentationToMSG { get; set; }
        public string DiscussedWithMSG { get; set; }
        public Nullable<int> AvoidabilityScoreID { get; set; }
        public string Comments { get; set; }
        public string FeedbackToNoK { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}