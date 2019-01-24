using NHS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;


namespace NHS.Controllers
{
    public class HomeController : Controller
    {
        NHSEntities ent = new NHSEntities();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult SJROutcome(int? id)
        {
            clsSJROutComeModel clsSJROutCome = GetSJROutComeModel();
            return View(clsSJROutCome);
        }


        [HttpPost]
        public ActionResult SJROutcome(clsSJROutComeModel clsSJROutComeModel, string btnSave, int id)
        {
            if (btnSave != null)
            {

                SJROutcomes sJROutcomes = new SJROutcomes();

                sJROutcomes.Stage2SJRRequired = clsSJROutComeModel.clsSjrOutCome.Stage2SJRRequired;
                sJROutcomes.Stage2SJRDateSent = clsSJROutComeModel.clsSjrOutCome.Stage2SJRDateSent;
                sJROutcomes.Stage2SJRSentTo = clsSJROutComeModel.clsSjrOutCome.Stage2SJRSentTo;
                sJROutcomes.ReferenceNumber = clsSJROutComeModel.clsSjrOutCome.ReferenceNumber;
                sJROutcomes.DateReceived = Convert.ToDateTime(clsSJROutComeModel.clsSjrOutCome.DateReceived);
                sJROutcomes.Comments = clsSJROutComeModel.clsSjrOutCome.Comments;
                sJROutcomes.CreatedBy = "John Deo";
                sJROutcomes.CreateDate = DateTime.Now;
                sJROutcomes.UpdatedBy = "John Deo";
                sJROutcomes.UpdatedDate = DateTime.Now;
                sJROutcomes.PatientID = id;
                ent.SJROutcomes.Add(sJROutcomes);
                ent.SaveChanges();


                MortalitySurveillance mortalitySurveillance = new MortalitySurveillance();

                mortalitySurveillance.PresentationToMSG = clsSJROutComeModel.clsMortalitySurveillance.PresentationToMSG;
                mortalitySurveillance.DiscussedWithMSG = clsSJROutComeModel.clsMortalitySurveillance.DiscussedWithMSG;
                mortalitySurveillance.AvoidabilityScoreID = clsSJROutComeModel.clsMortalitySurveillance.AvoidabilityScoreID;
                mortalitySurveillance.Comments = clsSJROutComeModel.clsMortalitySurveillance.Comments;
                mortalitySurveillance.FeedbackToNoK = clsSJROutComeModel.clsMortalitySurveillance.FeedbackToNoK;
                mortalitySurveillance.PatientID = id;
                mortalitySurveillance.CreatedBy = "John Deo";
                mortalitySurveillance.CreateDate = DateTime.Now;
                mortalitySurveillance.UpdatedBy = "John Deo";
                mortalitySurveillance.UpdatedDate = DateTime.Now;
                ent.MortalitySurveillance.Add(mortalitySurveillance);
                ent.SaveChanges();


                PatientDetails patientDetail = (from pDetails in ent.PatientDetails
                                                where pDetails.PatientId == id
                                                select pDetails).FirstOrDefault();


                ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                             where revStatus.PatientID == id
                                             select revStatus).FirstOrDefault();


                reviewStatus.PatientID = patientDetail.PatientId;
                reviewStatus.Spellnumber = Convert.ToString(patientDetail.SpellNumber);
                // 3 for Green               
                reviewStatus.SJRoutcome = 3;
                reviewStatus.CreatedBy = "John Deo";
                reviewStatus.CreateDate = DateTime.Now;
                reviewStatus.UpdatedBy = "John Deo";
                reviewStatus.UpdatedDate = DateTime.Now;
                ent.SaveChanges();

                if (reviewStatus.SJRoutcome == 3)
                {
                    return RedirectToAction("MortalityReview", new { Id = patientDetail.PatientId, PName = patientDetail.PatientName, DOB = Convert.ToDateTime(patientDetail.DOB) });
                }
            }

            return View();
        }
        //public ActionResult Stage2SJRform(FormCollection data)

        public ActionResult Stage2SJRformFirstStep(int? id)
        {
            Session["id"] = Convert.ToInt32(id);
            clsSJRFormInitialModel clsSJRFormInitialModel = GetSJRFormInitialModel();
            return View(clsSJRFormInitialModel);
        }

        [HttpPost]
        public ActionResult Stage2SJRformFirstStep(clsSJRFormInitialModel clsSJRFormInitialModel, string BtnNext, int? id)
        {
            try
            {
                Session["PId"] = id;
                if (BtnNext != null)
                {
                    if (clsSJRFormInitialModel.clsSjrFormInitial.SJRFormInitial_ID == 0)
                    {
                        CareRating careRating1 = new CareRating();
                        careRating1.Name = clsSJRFormInitialModel.clsInitialManagementCareRating.Name;
                        careRating1.CreatedBy = "John Deo";
                        careRating1.CreateDate = DateTime.Now;
                        careRating1.UpdatedBy = "John Deo";
                        careRating1.UpdatedDate = DateTime.Now;
                        ent.CareRating.Add(careRating1);
                        ent.SaveChanges();

                        int intInitialManagementRatingId = careRating1.CareRatingID;

                        CareRating careRating2 = new CareRating();
                        careRating2.Name = clsSJRFormInitialModel.clsOnGoingCareRating.Name;
                        careRating2.CreatedBy = "John Deo";
                        careRating2.CreateDate = DateTime.Now;
                        careRating2.UpdatedBy = "John Deo";
                        careRating2.UpdatedDate = DateTime.Now;
                        ent.CareRating.Add(careRating2);
                        ent.SaveChanges();

                        int intOnGoingCareRatingId = careRating2.CareRatingID;

                        CareRating careRating3 = new CareRating();
                        careRating3.Name = clsSJRFormInitialModel.clsCareDuringProcedureCareRating.Name;
                        careRating3.CreatedBy = "John Deo";
                        careRating3.CreateDate = DateTime.Now;
                        careRating3.UpdatedBy = "John Deo";
                        careRating3.UpdatedDate = DateTime.Now;
                        ent.CareRating.Add(careRating3);
                        ent.SaveChanges();

                        int intCareDuringProcedureCareRatingId = careRating3.CareRatingID;


                        CareRating careRating4 = new CareRating();
                        careRating4.Name = clsSJRFormInitialModel.clsEndLifeCareRating.Name;
                        careRating4.CreatedBy = "John Deo";
                        careRating4.CreateDate = DateTime.Now;
                        careRating4.UpdatedBy = "John Deo";
                        careRating4.UpdatedDate = DateTime.Now;
                        ent.CareRating.Add(careRating4);
                        ent.SaveChanges();

                        int intEndLifeCareRating = careRating4.CareRatingID;

                        //Session["careRating4"] = careRating4;

                        CareRating careRating5 = new CareRating();
                        careRating5.Name = clsSJRFormInitialModel.clsOverAllAssessmentCareRating.Name;
                        careRating5.CreatedBy = "John Deo";
                        careRating5.CreateDate = DateTime.Now;
                        careRating5.UpdatedBy = "John Deo";
                        careRating5.UpdatedDate = DateTime.Now;
                        ent.CareRating.Add(careRating5);
                        ent.SaveChanges();

                        int intOverAllAssessmentCareRatingId = careRating5.CareRatingID;

                        //Session["careRating5"] = careRating5;

                        CareRating careRating6 = new CareRating();
                        careRating6.Name = clsSJRFormInitialModel.clsQualityDocumentationCareRating.Name;
                        careRating6.CreatedBy = "John Deo";
                        careRating6.CreateDate = DateTime.Now;
                        careRating6.UpdatedBy = "John Deo";
                        careRating6.UpdatedDate = DateTime.Now;
                        ent.CareRating.Add(careRating6);
                        ent.SaveChanges();

                        int intQualityDocumentationCareRatingId = careRating6.CareRatingID;


                        SJRFormInitial sJRFormInitial = new SJRFormInitial();

                        sJRFormInitial.PatientID = id;
                        //Stage=0 For Stage2SJRForm Only 
                        sJRFormInitial.Stage = 0;
                        sJRFormInitial.InitialManagement = clsSJRFormInitialModel.clsSjrFormInitial.InitialManagement;
                        sJRFormInitial.OngoingCare = clsSJRFormInitialModel.clsSjrFormInitial.OngoingCare;
                        sJRFormInitial.CareDuringProcedure = clsSJRFormInitialModel.clsSjrFormInitial.CareDuringProcedure;
                        sJRFormInitial.EndLifeCare = clsSJRFormInitialModel.clsSjrFormInitial.EndLifeCare;
                        sJRFormInitial.OverAllAssessment = clsSJRFormInitialModel.clsSjrFormInitial.OverAllAssessment;
                        sJRFormInitial.InitialManagementCareRatingID = intInitialManagementRatingId;
                        sJRFormInitial.OngoingCareRatingID = intOnGoingCareRatingId;
                        sJRFormInitial.CareDuringProcedureCareRatingID = intCareDuringProcedureCareRatingId;
                        sJRFormInitial.EndLifeCareRatingID = intEndLifeCareRating;
                        sJRFormInitial.OverAllAssessmentCareRatingID = intOverAllAssessmentCareRatingId;
                        sJRFormInitial.QualityDocumentationCode = intQualityDocumentationCareRatingId;
                        sJRFormInitial.CreatedBy = "John Deo";
                        sJRFormInitial.CreateDate = DateTime.Now;
                        sJRFormInitial.UpdatedBy = "John Deo";
                        sJRFormInitial.UpdatedDate = DateTime.Now;
                        ent.SJRFormInitial.Add(sJRFormInitial);
                        ent.SaveChanges();

                        PatientDetails patientDetail = (from pDetails in ent.PatientDetails
                                                        where pDetails.PatientId == id
                                                        select pDetails).FirstOrDefault();


                        ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                                     where revStatus.PatientID == id
                                                     select revStatus).FirstOrDefault();

                        reviewStatus.PatientID = id;
                        // 1 for Amber
                        reviewStatus.METriage = 3;
                        reviewStatus.SJR1 = 1;
                        reviewStatus.SJR2 = 0;
                        reviewStatus.SJR2 = 0;
                        reviewStatus.SJRoutcome = 0;
                        reviewStatus.CreatedBy = "John Deo";
                        reviewStatus.CreateDate = DateTime.Now;
                        reviewStatus.UpdatedBy = "John Deo";
                        reviewStatus.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();

                        clsSJRFormInitialModel.clsSjrFormInitial.SJRFormInitial_ID = sJRFormInitial.SJRFormInitial_ID;
                        Session["sessionSJRFormInitial"] = clsSJRFormInitialModel;

                        Response.Redirect("/Home/Stage2SJRformSecondStep", false);
                        //return RedirectToAction("/Stage2SJRformSecondStep");
                    }
                    else
                    {



                        SJRFormInitial sJRFormInitial = (from sjr in ent.SJRFormInitial
                                                         where sjr.SJRFormInitial_ID == clsSJRFormInitialModel.clsSjrFormInitial.SJRFormInitial_ID
                                                         select sjr).FirstOrDefault();

                        int intPId = Convert.ToInt32(sJRFormInitial.PatientID);

                        sJRFormInitial.PatientID = intPId;
                        //Stage=0 For Stage2SJRForm Only 
                        sJRFormInitial.Stage = 0;
                        sJRFormInitial.InitialManagement = clsSJRFormInitialModel.clsSjrFormInitial.InitialManagement;
                        sJRFormInitial.OngoingCare = clsSJRFormInitialModel.clsSjrFormInitial.OngoingCare;
                        sJRFormInitial.CareDuringProcedure = clsSJRFormInitialModel.clsSjrFormInitial.CareDuringProcedure;
                        sJRFormInitial.EndLifeCare = clsSJRFormInitialModel.clsSjrFormInitial.EndLifeCare;
                        sJRFormInitial.OverAllAssessment = clsSJRFormInitialModel.clsSjrFormInitial.OverAllAssessment;
                        sJRFormInitial.CreatedBy = "John Deo";
                        sJRFormInitial.CreateDate = DateTime.Now;
                        sJRFormInitial.UpdatedBy = "John Deo";
                        sJRFormInitial.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();


                        CareRating careRating1 = (from x in ent.CareRating
                                                  where x.CareRatingID == sJRFormInitial.InitialManagementCareRatingID
                                                  select x).FirstOrDefault();


                        careRating1.Name = clsSJRFormInitialModel.clsInitialManagementCareRating.Name;
                        careRating1.CreatedBy = "John Deo";
                        careRating1.CreateDate = DateTime.Now;
                        careRating1.UpdatedBy = "John Deo";
                        careRating1.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();


                        CareRating careRating2 = (from x in ent.CareRating
                                                  where x.CareRatingID == sJRFormInitial.OngoingCareRatingID
                                                  select x).FirstOrDefault();


                        careRating2.Name = clsSJRFormInitialModel.clsOnGoingCareRating.Name;
                        careRating2.CreatedBy = "John Deo";
                        careRating2.CreateDate = DateTime.Now;
                        careRating2.UpdatedBy = "John Deo";
                        careRating2.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();

                        CareRating careRating3 = (from x in ent.CareRating
                                                  where x.CareRatingID == sJRFormInitial.CareDuringProcedureCareRatingID
                                                  select x).FirstOrDefault();


                        //Session["careRating2"] = careRating2;


                        careRating3.Name = clsSJRFormInitialModel.clsCareDuringProcedureCareRating.Name;
                        careRating3.CreatedBy = "John Deo";
                        careRating3.CreateDate = DateTime.Now;
                        careRating3.UpdatedBy = "John Deo";
                        careRating3.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();


                        CareRating careRating4 = (from x in ent.CareRating
                                                  where x.CareRatingID == sJRFormInitial.EndLifeCareRatingID
                                                  select x).FirstOrDefault();


                        careRating4.Name = clsSJRFormInitialModel.clsEndLifeCareRating.Name;
                        careRating4.CreatedBy = "John Deo";
                        careRating4.CreateDate = DateTime.Now;
                        careRating4.UpdatedBy = "John Deo";
                        careRating4.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();


                        CareRating careRating5 = (from x in ent.CareRating
                                                  where x.CareRatingID == sJRFormInitial.OverAllAssessmentCareRatingID
                                                  select x).FirstOrDefault();


                        careRating5.Name = clsSJRFormInitialModel.clsOverAllAssessmentCareRating.Name;
                        careRating5.CreatedBy = "John Deo";
                        careRating5.CreateDate = DateTime.Now;
                        careRating5.UpdatedBy = "John Deo";
                        careRating5.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();


                        CareRating careRating6 = (from x in ent.CareRating
                                                  where x.CareRatingID == sJRFormInitial.QualityDocumentationCode
                                                  select x).FirstOrDefault();



                        careRating6.Name = clsSJRFormInitialModel.clsQualityDocumentationCareRating.Name;
                        careRating6.CreatedBy = "John Deo";
                        careRating6.CreateDate = DateTime.Now;
                        careRating6.UpdatedBy = "John Deo";
                        careRating6.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();

                        PatientDetails patientDetail = (from pDetails in ent.PatientDetails
                                                        where pDetails.PatientId == id
                                                        select pDetails).FirstOrDefault();


                        ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                                     where revStatus.PatientID == id
                                                     select revStatus).FirstOrDefault();

                        reviewStatus.PatientID = id;
                        // 1 for Amber
                        reviewStatus.METriage = 3;
                        reviewStatus.SJR1 = 1;
                        reviewStatus.SJR2 = 0;
                        reviewStatus.SJR2 = 0;
                        reviewStatus.SJRoutcome = 0;
                        reviewStatus.CreatedBy = "John Deo";
                        reviewStatus.CreateDate = DateTime.Now;
                        reviewStatus.UpdatedBy = "John Deo";
                        reviewStatus.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();

                        clsSJRFormInitialModel.clsSjrFormInitial.SJRFormInitial_ID = sJRFormInitial.SJRFormInitial_ID;
                        Session["sessionSJRFormInitial"] = clsSJRFormInitialModel;

                        Session["ssPatientId"] = intPId;
                        //Response.Redirect("/Home/Stage2SJRformSecondStep", false);
                        return RedirectToAction("/Stage2SJRformSecondStep");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

            return View();
        }


        public ActionResult Stage2SJRformSecondStep(FormCollection data, string BtnPrevious, string BtnFinish)
        {
            try
            {
                //int id = Convert.ToInt32(Session["id"]);
                int PID = Convert.ToInt32(Session["PId"]);
                if (BtnPrevious != null)
                {
                    //Session["BtnPrevious"] = BtnPrevious;
                    Response.Redirect("/Home/Stage2SJRformFirstStep", false);
                    //return RedirectToAction("/Stage2SJRformFirstStep");
                }
                if (BtnFinish != null)
                {

                    //var lastRecordPatientMap = ent.PatientMap.OrderByDescending(p => p.PatientID).FirstOrDefault();
                    //int lastPatientId = lastRecordPatientMap.PatientID;

                    CarePhase carePhase1 = new CarePhase();
                    string strAssessmentCarePhase = data["ddlAssessmentCarePhase"];
                    carePhase1.PhaseName = strAssessmentCarePhase;
                    carePhase1.CreatedBy = "John Deo";
                    carePhase1.CreateDate = DateTime.Now;
                    carePhase1.UpdatedBy = "John Deo";
                    carePhase1.UpdatedDate = DateTime.Now;
                    ent.CarePhase.Add(carePhase1);
                    ent.SaveChanges();

                    int intAssessmentCarePhaseId = carePhase1.CarePhaseID;


                    CarePhase carePhase2 = new CarePhase();
                    string strMedicationCarePhase = data["ddlMedicationCarePhase"];
                    carePhase2.PhaseName = strMedicationCarePhase;
                    carePhase2.CreatedBy = "John Deo";
                    carePhase2.CreateDate = DateTime.Now;
                    carePhase2.UpdatedBy = "John Deo";
                    carePhase2.UpdatedDate = DateTime.Now;
                    ent.CarePhase.Add(carePhase2);
                    ent.SaveChanges();

                    int intMedicationCarePhaseId = carePhase2.CarePhaseID;

                    CarePhase carePhase3 = new CarePhase();
                    string strTretmentCarePhase = data["ddlTretmentCarePhase"];
                    carePhase3.PhaseName = strTretmentCarePhase;
                    carePhase3.CreatedBy = "John Deo";
                    carePhase3.CreateDate = DateTime.Now;
                    carePhase3.UpdatedBy = "John Deo";
                    carePhase3.UpdatedDate = DateTime.Now;
                    ent.CarePhase.Add(carePhase3);
                    ent.SaveChanges();

                    int intTretmentCarePhaseId = carePhase3.CarePhaseID;

                    CarePhase carePhase4 = new CarePhase();
                    string strInfectionCarePhase = data["ddlInfectionCarePhase"];
                    carePhase4.PhaseName = strInfectionCarePhase;
                    carePhase4.CreatedBy = "John Deo";
                    carePhase4.CreateDate = DateTime.Now;
                    carePhase4.UpdatedBy = "John Deo";
                    carePhase4.UpdatedDate = DateTime.Now;
                    ent.CarePhase.Add(carePhase4);
                    ent.SaveChanges();


                    int intInfectionCarePhaseId = carePhase4.CarePhaseID;

                    CarePhase carePhase5 = new CarePhase();
                    string strProcedureCarePhaseId = data["ddlProcedureCarePhase"];
                    carePhase5.PhaseName = strProcedureCarePhaseId;
                    carePhase5.CreatedBy = "John Deo";
                    carePhase5.CreateDate = DateTime.Now;
                    carePhase5.UpdatedBy = "John Deo";
                    carePhase5.UpdatedDate = DateTime.Now;
                    ent.CarePhase.Add(carePhase5);
                    ent.SaveChanges();


                    int intProcedureCarePhaseId = carePhase5.CarePhaseID;

                    CarePhase carePhase6 = new CarePhase();
                    string strOtherTypeCarePhaseId = data["ddlOtherTypeCarePhase"];
                    carePhase6.PhaseName = strOtherTypeCarePhaseId;
                    carePhase6.CreatedBy = "John Deo";
                    carePhase6.CreateDate = DateTime.Now;
                    carePhase6.UpdatedBy = "John Deo";
                    carePhase6.UpdatedDate = DateTime.Now;
                    ent.CarePhase.Add(carePhase6);
                    ent.SaveChanges();

                    int intOtherTypeCarePhaseId = carePhase6.CarePhaseID;


                    AvoidabilityScore avoidabilityScore = new AvoidabilityScore();
                    string strAvoidabilityScore = data["ddlAvoidabilityScore"];
                    avoidabilityScore.Name = strAvoidabilityScore;
                    avoidabilityScore.CreatedBy = "John Deo";
                    avoidabilityScore.CreateDate = DateTime.Now;
                    avoidabilityScore.UpdatedBy = "John Deo";
                    avoidabilityScore.UpdatedDate = DateTime.Now;
                    ent.AvoidabilityScore.Add(avoidabilityScore);
                    ent.SaveChanges();


                    int intAvoidabilityScoreId = avoidabilityScore.AvoidabilityScoreID;

                    ResponsePT responsePT = new ResponsePT();
                    string strAssessmentResponse = data["ddlAssessmentResponse"];
                    responsePT.Response = strAssessmentResponse;
                    responsePT.CreatedBy = "John Deo";
                    responsePT.CreateDate = DateTime.Now;
                    responsePT.UpdatedBy = "John Deo";
                    responsePT.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT);
                    ent.SaveChanges();

                    int intAssessmentResponseId = responsePT.ResponseID;

                    ResponsePT responsePT1 = new ResponsePT();
                    string strMedicationResponse = data["ddlMedicationResponse"];
                    responsePT1.Response = strMedicationResponse;
                    responsePT1.CreatedBy = "John Deo";
                    responsePT1.CreateDate = DateTime.Now;
                    responsePT1.UpdatedBy = "John Deo";
                    responsePT1.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT1);
                    ent.SaveChanges();

                    int intMedicationResponseId = responsePT1.ResponseID;

                    ResponsePT responsePT2 = new ResponsePT();
                    string strTreatmentResponse = data["ddlTreatmentResponse"];
                    responsePT2.Response = strTreatmentResponse;
                    responsePT2.CreatedBy = "John Deo";
                    responsePT2.CreateDate = DateTime.Now;
                    responsePT2.UpdatedBy = "John Deo";
                    responsePT2.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT2);
                    ent.SaveChanges();

                    int intTreatmentResponseId = responsePT2.ResponseID;

                    ResponsePT responsePT3 = new ResponsePT();
                    string strInfectionResponse = data["ddlInfectionResponse"];
                    responsePT3.Response = strInfectionResponse;
                    responsePT3.CreatedBy = "John Deo";
                    responsePT3.CreateDate = DateTime.Now;
                    responsePT3.UpdatedBy = "John Deo";
                    responsePT3.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT3);
                    ent.SaveChanges();

                    int intInfectionResponseId = responsePT3.ResponseID;


                    ResponsePT responsePT4 = new ResponsePT();
                    string strProcedureResponse = data["ddlProcedureResponse"];
                    responsePT4.Response = strProcedureResponse;
                    responsePT4.CreatedBy = "John Deo";
                    responsePT4.CreateDate = DateTime.Now;
                    responsePT4.UpdatedBy = "John Deo";
                    responsePT4.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT4);
                    ent.SaveChanges();

                    int intProcedureResponseId = responsePT4.ResponseID;

                    ResponsePT responsePT5 = new ResponsePT();
                    string strMonitoringResponse = data["ddlMonitoringResponse"];
                    responsePT5.Response = strMonitoringResponse;
                    responsePT5.CreatedBy = "John Deo";
                    responsePT5.CreateDate = DateTime.Now;
                    responsePT5.UpdatedBy = "John Deo";
                    responsePT5.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT5);
                    ent.SaveChanges();

                    int intMonitoringResponseId = responsePT5.ResponseID;


                    ResponsePT responsePT6 = new ResponsePT();
                    string strResuscitationResponse = data["ddlResuscitationResponse"];
                    responsePT6.Response = strResuscitationResponse;
                    responsePT6.CreatedBy = "John Deo";
                    responsePT6.CreateDate = DateTime.Now;
                    responsePT6.UpdatedBy = "John Deo";
                    responsePT6.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT6);
                    ent.SaveChanges();

                    int intResuscitationResponseId = responsePT6.ResponseID;


                    ResponsePT responsePT7 = new ResponsePT();
                    string strOtherTypeResponse = data["ddlOtherTypeResponse"];
                    responsePT7.Response = strOtherTypeResponse;
                    responsePT7.CreatedBy = "John Deo";
                    responsePT7.CreateDate = DateTime.Now;
                    responsePT7.UpdatedBy = "John Deo";
                    responsePT7.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT7);
                    ent.SaveChanges();

                    int intOtherTypeResponseId = responsePT7.ResponseID;
                    string strSJRFormProblemTypeComments = data["taComment"];

                    //int intPID = Convert.ToInt32(Session["ssPatientId"]);

                    SJRFormProblemType sJRFormProblemType = new SJRFormProblemType();
                    sJRFormProblemType.PatientID = PID;
                    sJRFormProblemType.AssessmentResponseID = intAssessmentResponseId;
                    sJRFormProblemType.AssessmentCarePhaseID = intAssessmentCarePhaseId;
                    sJRFormProblemType.MedicationResponseID = intMedicationResponseId;
                    sJRFormProblemType.MedicationCarePhaseID = intMedicationCarePhaseId;
                    sJRFormProblemType.TreatmentResponseID = intTreatmentResponseId;
                    sJRFormProblemType.TreatmentCarePhaseID = intTretmentCarePhaseId;
                    sJRFormProblemType.InfectionResponseID = intInfectionResponseId;
                    sJRFormProblemType.InfectionCarePhaseID = intInfectionCarePhaseId;
                    sJRFormProblemType.ProcedureResponseID = intProcedureResponseId;
                    sJRFormProblemType.ProcedureCarePhaseID = intProcedureCarePhaseId;
                    sJRFormProblemType.MonitoringResponseID = intMonitoringResponseId;
                    sJRFormProblemType.ResuscitationResponseID = intResuscitationResponseId;
                    sJRFormProblemType.OthertypeResponseID = intOtherTypeResponseId;
                    sJRFormProblemType.OthertypeCarePhaseID = intOtherTypeCarePhaseId;
                    sJRFormProblemType.AvoidabilityScoreID = intAvoidabilityScoreId;
                    sJRFormProblemType.Comments = strSJRFormProblemTypeComments;
                    sJRFormProblemType.Stage = 0;
                    sJRFormProblemType.CreatedBy = "John Deo";
                    sJRFormProblemType.CreateDate = DateTime.Now;
                    sJRFormProblemType.UpdatedBy = "John Deo";
                    sJRFormProblemType.UpdatedDate = DateTime.Now;

                    ent.SJRFormProblemType.Add(sJRFormProblemType);
                    ent.SaveChanges();

                    PatientDetails patientDetail = (from pDetails in ent.PatientDetails
                                                    where pDetails.PatientId == PID
                                                    select pDetails).FirstOrDefault();

                    ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                                 where revStatus.PatientID == PID
                                                 select revStatus).FirstOrDefault();

                    reviewStatus.PatientID = PID;
                    // 1 for Amber
                    reviewStatus.METriage = 3;
                    reviewStatus.SJR1 = 3;
                    reviewStatus.SJR2 = 2;
                    reviewStatus.SJRoutcome = 0;
                    reviewStatus.CreatedBy = "John Deo";
                    reviewStatus.CreateDate = DateTime.Now;
                    reviewStatus.UpdatedBy = "John Deo";
                    reviewStatus.UpdatedDate = DateTime.Now;
                    ent.SaveChanges();

                    if (reviewStatus.SJR1 == 3)
                    {
                        return RedirectToAction("MortalityReview", new { Id = patientDetail.PatientId, PName = patientDetail.PatientName, DOB = Convert.ToDateTime(patientDetail.DOB) });
                        // Response.Redirect("/Home/Stage2SJRformSecondStep");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
                // return View("Error", new HandleErrorInfo(ex, "Stage2SJRformSecondStep", "Home"));
            }
            return View();
        }

        public ActionResult Stage3SJRformFirstStep()
        {
            clsSJRFormInitialModel clsSJRFormInitialModel = GetSJRFormInitialModel();
            return View(clsSJRFormInitialModel);
        }


        [HttpPost]
        public ActionResult Stage3SJRformFirstStep(clsSJRFormInitialModel clsSJRFormInitialModel, string BtnNext, int id)
        {
            try
            {
                Session["PId"] = id;
                if (BtnNext != null)
                {
                    if (clsSJRFormInitialModel.clsSjrFormInitial.SJRFormInitial_ID == 0)
                    {
                        CareRating careRating1 = new CareRating();
                        careRating1.Name = clsSJRFormInitialModel.clsInitialManagementCareRating.Name;
                        careRating1.CreatedBy = "John Deo";
                        careRating1.CreateDate = DateTime.Now;
                        careRating1.UpdatedBy = "John Deo";
                        careRating1.UpdatedDate = DateTime.Now;
                        ent.CareRating.Add(careRating1);
                        ent.SaveChanges();

                        int intInitialManagementRatingId = careRating1.CareRatingID;
                        //Session["careRating1"] = careRating1;

                        CareRating careRating2 = new CareRating();
                        careRating2.Name = clsSJRFormInitialModel.clsOnGoingCareRating.Name;
                        careRating2.CreatedBy = "John Deo";
                        careRating2.CreateDate = DateTime.Now;
                        careRating2.UpdatedBy = "John Deo";
                        careRating2.UpdatedDate = DateTime.Now;
                        ent.CareRating.Add(careRating2);
                        ent.SaveChanges();

                        int intOnGoingCareRatingId = careRating2.CareRatingID;


                        //Session["careRating2"] = careRating2;

                        CareRating careRating3 = new CareRating();
                        careRating3.Name = clsSJRFormInitialModel.clsCareDuringProcedureCareRating.Name;
                        careRating3.CreatedBy = "John Deo";
                        careRating3.CreateDate = DateTime.Now;
                        careRating3.UpdatedBy = "John Deo";
                        careRating3.UpdatedDate = DateTime.Now;
                        ent.CareRating.Add(careRating3);
                        ent.SaveChanges();

                        int intCareDuringProcedureCareRatingId = careRating3.CareRatingID;

                        //Session["careRating3"] = careRating3;

                        CareRating careRating4 = new CareRating();
                        careRating4.Name = clsSJRFormInitialModel.clsEndLifeCareRating.Name;
                        careRating4.CreatedBy = "John Deo";
                        careRating4.CreateDate = DateTime.Now;
                        careRating4.UpdatedBy = "John Deo";
                        careRating4.UpdatedDate = DateTime.Now;
                        ent.CareRating.Add(careRating4);
                        ent.SaveChanges();

                        int intEndLifeCareRating = careRating4.CareRatingID;

                        //Session["careRating4"] = careRating4;

                        CareRating careRating5 = new CareRating();
                        careRating5.Name = clsSJRFormInitialModel.clsOverAllAssessmentCareRating.Name;
                        careRating5.CreatedBy = "John Deo";
                        careRating5.CreateDate = DateTime.Now;
                        careRating5.UpdatedBy = "John Deo";
                        careRating5.UpdatedDate = DateTime.Now;
                        ent.CareRating.Add(careRating5);
                        ent.SaveChanges();

                        int intOverAllAssessmentCareRatingId = careRating5.CareRatingID;

                        //Session["careRating5"] = careRating5;

                        CareRating careRating6 = new CareRating();
                        careRating6.Name = clsSJRFormInitialModel.clsQualityDocumentationCareRating.Name;
                        careRating6.CreatedBy = "John Deo";
                        careRating6.CreateDate = DateTime.Now;
                        careRating6.UpdatedBy = "John Deo";
                        careRating6.UpdatedDate = DateTime.Now;
                        ent.CareRating.Add(careRating6);
                        ent.SaveChanges();

                        int intQualityDocumentationCareRatingId = careRating6.CareRatingID;


                        SJRFormInitial sJRFormInitial = new SJRFormInitial();

                        sJRFormInitial.PatientID = id;
                        //Stage=0 For Stage2SJRForm Only 
                        sJRFormInitial.Stage = 1;
                        sJRFormInitial.InitialManagement = clsSJRFormInitialModel.clsSjrFormInitial.InitialManagement;
                        sJRFormInitial.OngoingCare = clsSJRFormInitialModel.clsSjrFormInitial.OngoingCare;
                        sJRFormInitial.CareDuringProcedure = clsSJRFormInitialModel.clsSjrFormInitial.CareDuringProcedure;
                        sJRFormInitial.EndLifeCare = clsSJRFormInitialModel.clsSjrFormInitial.EndLifeCare;
                        sJRFormInitial.OverAllAssessment = clsSJRFormInitialModel.clsSjrFormInitial.OverAllAssessment;
                        sJRFormInitial.InitialManagementCareRatingID = intInitialManagementRatingId;
                        sJRFormInitial.OngoingCareRatingID = intOnGoingCareRatingId;
                        sJRFormInitial.CareDuringProcedureCareRatingID = intCareDuringProcedureCareRatingId;
                        sJRFormInitial.EndLifeCareRatingID = intEndLifeCareRating;
                        sJRFormInitial.OverAllAssessmentCareRatingID = intOverAllAssessmentCareRatingId;
                        sJRFormInitial.QualityDocumentationCode = intQualityDocumentationCareRatingId;
                        sJRFormInitial.CreatedBy = "John Deo";
                        sJRFormInitial.CreateDate = DateTime.Now;
                        sJRFormInitial.UpdatedBy = "John Deo";
                        sJRFormInitial.UpdatedDate = DateTime.Now;
                        ent.SJRFormInitial.Add(sJRFormInitial);
                        ent.SaveChanges();

                        PatientDetails patientDetail = (from pDetails in ent.PatientDetails
                                                        where pDetails.PatientId == id
                                                        select pDetails).FirstOrDefault();


                        ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                                     where revStatus.PatientID == id
                                                     select revStatus).FirstOrDefault();

                        reviewStatus.PatientID = id;
                        // 1 for Amber
                        reviewStatus.METriage = 3;
                        reviewStatus.SJR1 = 3;
                        reviewStatus.SJR2 = 1;
                        reviewStatus.SJRoutcome = 0;
                        reviewStatus.CreatedBy = "John Deo";
                        reviewStatus.CreateDate = DateTime.Now;
                        reviewStatus.UpdatedBy = "John Deo";
                        reviewStatus.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();

                        clsSJRFormInitialModel.clsSjrFormInitial.SJRFormInitial_ID = sJRFormInitial.SJRFormInitial_ID;
                        Session["sessionSJRFormInitial"] = clsSJRFormInitialModel;

                        // Response.Redirect("/Home/Stage2SJRformSecondStep", false);
                        return RedirectToAction("/Stage3SJRformSecondStep");
                    }
                    else
                    {


                        //int intQualityDocumentationCareRatingId = careRating6.CareRatingID;

                        //var lastRecordPatientMap = ent.PatientMap.OrderByDescending(p => p.PatientID).FirstOrDefault();
                        //int lastPatientId = lastRecordPatientMap.PatientID;


                        SJRFormInitial sJRFormInitial = (from sjr in ent.SJRFormInitial
                                                         where sjr.SJRFormInitial_ID == clsSJRFormInitialModel.clsSjrFormInitial.SJRFormInitial_ID
                                                         select sjr).FirstOrDefault();

                        int intPId = Convert.ToInt32(sJRFormInitial.PatientID);

                        sJRFormInitial.PatientID = intPId;
                        //Stage=0 For Stage2SJRForm Only 
                        sJRFormInitial.Stage = 1;
                        sJRFormInitial.InitialManagement = clsSJRFormInitialModel.clsSjrFormInitial.InitialManagement;
                        sJRFormInitial.OngoingCare = clsSJRFormInitialModel.clsSjrFormInitial.OngoingCare;
                        sJRFormInitial.CareDuringProcedure = clsSJRFormInitialModel.clsSjrFormInitial.CareDuringProcedure;
                        sJRFormInitial.EndLifeCare = clsSJRFormInitialModel.clsSjrFormInitial.EndLifeCare;
                        sJRFormInitial.OverAllAssessment = clsSJRFormInitialModel.clsSjrFormInitial.OverAllAssessment;
                        sJRFormInitial.CreatedBy = "John Deo";
                        sJRFormInitial.CreateDate = DateTime.Now;
                        sJRFormInitial.UpdatedBy = "John Deo";
                        sJRFormInitial.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();


                        CareRating careRating1 = (from x in ent.CareRating
                                                  where x.CareRatingID == sJRFormInitial.InitialManagementCareRatingID
                                                  select x).FirstOrDefault();


                        careRating1.Name = clsSJRFormInitialModel.clsInitialManagementCareRating.Name;
                        careRating1.CreatedBy = "John Deo";
                        careRating1.CreateDate = DateTime.Now;
                        careRating1.UpdatedBy = "John Deo";
                        careRating1.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();


                        CareRating careRating2 = (from x in ent.CareRating
                                                  where x.CareRatingID == sJRFormInitial.OngoingCareRatingID
                                                  select x).FirstOrDefault();


                        careRating2.Name = clsSJRFormInitialModel.clsOnGoingCareRating.Name;
                        careRating2.CreatedBy = "John Deo";
                        careRating2.CreateDate = DateTime.Now;
                        careRating2.UpdatedBy = "John Deo";
                        careRating2.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();

                        CareRating careRating3 = (from x in ent.CareRating
                                                  where x.CareRatingID == sJRFormInitial.CareDuringProcedureCareRatingID
                                                  select x).FirstOrDefault();


                        //Session["careRating2"] = careRating2;


                        careRating3.Name = clsSJRFormInitialModel.clsCareDuringProcedureCareRating.Name;
                        careRating3.CreatedBy = "John Deo";
                        careRating3.CreateDate = DateTime.Now;
                        careRating3.UpdatedBy = "John Deo";
                        careRating3.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();


                        CareRating careRating4 = (from x in ent.CareRating
                                                  where x.CareRatingID == sJRFormInitial.EndLifeCareRatingID
                                                  select x).FirstOrDefault();


                        careRating4.Name = clsSJRFormInitialModel.clsEndLifeCareRating.Name;
                        careRating4.CreatedBy = "John Deo";
                        careRating4.CreateDate = DateTime.Now;
                        careRating4.UpdatedBy = "John Deo";
                        careRating4.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();


                        CareRating careRating5 = (from x in ent.CareRating
                                                  where x.CareRatingID == sJRFormInitial.OverAllAssessmentCareRatingID
                                                  select x).FirstOrDefault();


                        careRating5.Name = clsSJRFormInitialModel.clsOverAllAssessmentCareRating.Name;
                        careRating5.CreatedBy = "John Deo";
                        careRating5.CreateDate = DateTime.Now;
                        careRating5.UpdatedBy = "John Deo";
                        careRating5.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();


                        CareRating careRating6 = (from x in ent.CareRating
                                                  where x.CareRatingID == sJRFormInitial.QualityDocumentationCode
                                                  select x).FirstOrDefault();



                        careRating6.Name = clsSJRFormInitialModel.clsQualityDocumentationCareRating.Name;
                        careRating6.CreatedBy = "John Deo";
                        careRating6.CreateDate = DateTime.Now;
                        careRating6.UpdatedBy = "John Deo";
                        careRating6.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();

                        PatientDetails patientDetail = (from pDetails in ent.PatientDetails
                                                        where pDetails.PatientId == id
                                                        select pDetails).FirstOrDefault();


                        ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                                     where revStatus.PatientID == id
                                                     select revStatus).FirstOrDefault();

                        reviewStatus.PatientID = id;
                        // 1 for Amber
                        reviewStatus.METriage = 3;
                        reviewStatus.SJR1 = 3;
                        reviewStatus.SJR2 = 1;
                        reviewStatus.SJRoutcome = 0;
                        reviewStatus.CreatedBy = "John Deo";
                        reviewStatus.CreateDate = DateTime.Now;
                        reviewStatus.UpdatedBy = "John Deo";
                        reviewStatus.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();


                        clsSJRFormInitialModel.clsSjrFormInitial.SJRFormInitial_ID = sJRFormInitial.SJRFormInitial_ID;
                        Session["sessionSJRFormInitial"] = clsSJRFormInitialModel;

                        Session["ssPatientId"] = intPId;
                        //Response.Redirect("/Home/Stage2SJRformSecondStep", false);
                        return RedirectToAction("/Stage3SJRformSecondStep");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

            return View();

        }

        public ActionResult Stage3SJRformSecondStep(FormCollection data, string BtnPrevious, string BtnFinish)
        {
            try
            {

                //int id = Convert.ToInt32(Session["id"]);
                int PID = Convert.ToInt32(Session["PId"]);
                if (BtnPrevious != null)
                {
                    //Session["BtnPrevious"] = BtnPrevious;
                    Response.Redirect("/Home/Stage2SJRformFirstStep", false);
                    //return RedirectToAction("/Stage2SJRformFirstStep");
                }
                if (BtnFinish != null)
                {


                    CarePhase carePhase1 = new CarePhase();
                    string strAssessmentCarePhase = data["ddlAssessmentCarePhase"];
                    carePhase1.PhaseName = strAssessmentCarePhase;
                    carePhase1.CreatedBy = "John Deo";
                    carePhase1.CreateDate = DateTime.Now;
                    carePhase1.UpdatedBy = "John Deo";
                    carePhase1.UpdatedDate = DateTime.Now;
                    ent.CarePhase.Add(carePhase1);
                    ent.SaveChanges();

                    int intAssessmentCarePhaseId = carePhase1.CarePhaseID;


                    CarePhase carePhase2 = new CarePhase();
                    string strMedicationCarePhase = data["ddlMedicationCarePhase"];
                    carePhase2.PhaseName = strMedicationCarePhase;
                    carePhase2.CreatedBy = "John Deo";
                    carePhase2.CreateDate = DateTime.Now;
                    carePhase2.UpdatedBy = "John Deo";
                    carePhase2.UpdatedDate = DateTime.Now;
                    ent.CarePhase.Add(carePhase2);
                    ent.SaveChanges();

                    int intMedicationCarePhaseId = carePhase2.CarePhaseID;

                    CarePhase carePhase3 = new CarePhase();
                    string strTretmentCarePhase = data["ddlTretmentCarePhase"];
                    carePhase3.PhaseName = strTretmentCarePhase;
                    carePhase3.CreatedBy = "John Deo";
                    carePhase3.CreateDate = DateTime.Now;
                    carePhase3.UpdatedBy = "John Deo";
                    carePhase3.UpdatedDate = DateTime.Now;
                    ent.CarePhase.Add(carePhase3);
                    ent.SaveChanges();

                    int intTretmentCarePhaseId = carePhase3.CarePhaseID;

                    CarePhase carePhase4 = new CarePhase();
                    string strInfectionCarePhase = data["ddlInfectionCarePhase"];
                    carePhase4.PhaseName = strInfectionCarePhase;
                    carePhase4.CreatedBy = "John Deo";
                    carePhase4.CreateDate = DateTime.Now;
                    carePhase4.UpdatedBy = "John Deo";
                    carePhase4.UpdatedDate = DateTime.Now;
                    ent.CarePhase.Add(carePhase4);
                    ent.SaveChanges();


                    int intInfectionCarePhaseId = carePhase4.CarePhaseID;

                    CarePhase carePhase5 = new CarePhase();
                    string strProcedureCarePhaseId = data["ddlProcedureCarePhase"];
                    carePhase5.PhaseName = strProcedureCarePhaseId;
                    carePhase5.CreatedBy = "John Deo";
                    carePhase5.CreateDate = DateTime.Now;
                    carePhase5.UpdatedBy = "John Deo";
                    carePhase5.UpdatedDate = DateTime.Now;
                    ent.CarePhase.Add(carePhase5);
                    ent.SaveChanges();


                    int intProcedureCarePhaseId = carePhase5.CarePhaseID;

                    CarePhase carePhase6 = new CarePhase();
                    string strOtherTypeCarePhaseId = data["ddlOtherTypeCarePhase"];
                    carePhase6.PhaseName = strOtherTypeCarePhaseId;
                    carePhase6.CreatedBy = "John Deo";
                    carePhase6.CreateDate = DateTime.Now;
                    carePhase6.UpdatedBy = "John Deo";
                    carePhase6.UpdatedDate = DateTime.Now;
                    ent.CarePhase.Add(carePhase6);
                    ent.SaveChanges();

                    int intOtherTypeCarePhaseId = carePhase6.CarePhaseID;


                    AvoidabilityScore avoidabilityScore = new AvoidabilityScore();
                    string strAvoidabilityScore = data["ddlAvoidabilityScore"];
                    avoidabilityScore.Name = strAvoidabilityScore;
                    avoidabilityScore.CreatedBy = "John Deo";
                    avoidabilityScore.CreateDate = DateTime.Now;
                    avoidabilityScore.UpdatedBy = "John Deo";
                    avoidabilityScore.UpdatedDate = DateTime.Now;
                    ent.AvoidabilityScore.Add(avoidabilityScore);
                    ent.SaveChanges();


                    int intAvoidabilityScoreId = avoidabilityScore.AvoidabilityScoreID;

                    ResponsePT responsePT = new ResponsePT();
                    string strAssessmentResponse = data["ddlAssessmentResponse"];
                    responsePT.Response = strAssessmentResponse;
                    responsePT.CreatedBy = "John Deo";
                    responsePT.CreateDate = DateTime.Now;
                    responsePT.UpdatedBy = "John Deo";
                    responsePT.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT);
                    ent.SaveChanges();

                    int intAssessmentResponseId = responsePT.ResponseID;

                    ResponsePT responsePT1 = new ResponsePT();
                    string strMedicationResponse = data["ddlMedicationResponse"];
                    responsePT1.Response = strMedicationResponse;
                    responsePT1.CreatedBy = "John Deo";
                    responsePT1.CreateDate = DateTime.Now;
                    responsePT1.UpdatedBy = "John Deo";
                    responsePT1.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT1);
                    ent.SaveChanges();

                    int intMedicationResponseId = responsePT1.ResponseID;

                    ResponsePT responsePT2 = new ResponsePT();
                    string strTreatmentResponse = data["ddlTreatmentResponse"];
                    responsePT2.Response = strTreatmentResponse;
                    responsePT2.CreatedBy = "John Deo";
                    responsePT2.CreateDate = DateTime.Now;
                    responsePT2.UpdatedBy = "John Deo";
                    responsePT2.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT2);
                    ent.SaveChanges();

                    int intTreatmentResponseId = responsePT2.ResponseID;

                    ResponsePT responsePT3 = new ResponsePT();
                    string strInfectionResponse = data["ddlInfectionResponse"];
                    responsePT3.Response = strInfectionResponse;
                    responsePT3.CreatedBy = "John Deo";
                    responsePT3.CreateDate = DateTime.Now;
                    responsePT3.UpdatedBy = "John Deo";
                    responsePT3.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT3);
                    ent.SaveChanges();

                    int intInfectionResponseId = responsePT3.ResponseID;


                    ResponsePT responsePT4 = new ResponsePT();
                    string strProcedureResponse = data["ddlProcedureResponse"];
                    responsePT4.Response = strProcedureResponse;
                    responsePT4.CreatedBy = "John Deo";
                    responsePT4.CreateDate = DateTime.Now;
                    responsePT4.UpdatedBy = "John Deo";
                    responsePT4.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT4);
                    ent.SaveChanges();

                    int intProcedureResponseId = responsePT4.ResponseID;

                    ResponsePT responsePT5 = new ResponsePT();
                    string strMonitoringResponse = data["ddlMonitoringResponse"];
                    responsePT5.Response = strMonitoringResponse;
                    responsePT5.CreatedBy = "John Deo";
                    responsePT5.CreateDate = DateTime.Now;
                    responsePT5.UpdatedBy = "John Deo";
                    responsePT5.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT5);
                    ent.SaveChanges();

                    int intMonitoringResponseId = responsePT5.ResponseID;


                    ResponsePT responsePT6 = new ResponsePT();
                    string strResuscitationResponse = data["ddlResuscitationResponse"];
                    responsePT6.Response = strResuscitationResponse;
                    responsePT6.CreatedBy = "John Deo";
                    responsePT6.CreateDate = DateTime.Now;
                    responsePT6.UpdatedBy = "John Deo";
                    responsePT6.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT6);
                    ent.SaveChanges();

                    int intResuscitationResponseId = responsePT6.ResponseID;


                    ResponsePT responsePT7 = new ResponsePT();
                    string strOtherTypeResponse = data["ddlOtherTypeResponse"];
                    responsePT7.Response = strOtherTypeResponse;
                    responsePT7.CreatedBy = "John Deo";
                    responsePT7.CreateDate = DateTime.Now;
                    responsePT7.UpdatedBy = "John Deo";
                    responsePT7.UpdatedDate = DateTime.Now;
                    ent.ResponsePT.Add(responsePT7);
                    ent.SaveChanges();

                    int intOtherTypeResponseId = responsePT7.ResponseID;
                    string strSJRFormProblemTypeComments = data["taComment"];

                    //int intPID = Convert.ToInt32(Session["ssPatientId"]);

                    SJRFormProblemType sJRFormProblemType = new SJRFormProblemType();
                    sJRFormProblemType.PatientID = PID;
                    sJRFormProblemType.AssessmentResponseID = intAssessmentResponseId;
                    sJRFormProblemType.AssessmentCarePhaseID = intAssessmentCarePhaseId;
                    sJRFormProblemType.MedicationResponseID = intMedicationResponseId;
                    sJRFormProblemType.MedicationCarePhaseID = intMedicationCarePhaseId;
                    sJRFormProblemType.TreatmentResponseID = intTreatmentResponseId;
                    sJRFormProblemType.TreatmentCarePhaseID = intTretmentCarePhaseId;
                    sJRFormProblemType.InfectionResponseID = intInfectionResponseId;
                    sJRFormProblemType.InfectionCarePhaseID = intInfectionCarePhaseId;
                    sJRFormProblemType.ProcedureResponseID = intProcedureResponseId;
                    sJRFormProblemType.ProcedureCarePhaseID = intProcedureCarePhaseId;
                    sJRFormProblemType.MonitoringResponseID = intMonitoringResponseId;
                    sJRFormProblemType.ResuscitationResponseID = intResuscitationResponseId;
                    sJRFormProblemType.OthertypeResponseID = intOtherTypeResponseId;
                    sJRFormProblemType.OthertypeCarePhaseID = intOtherTypeCarePhaseId;
                    sJRFormProblemType.AvoidabilityScoreID = intAvoidabilityScoreId;
                    sJRFormProblemType.Comments = strSJRFormProblemTypeComments;
                    sJRFormProblemType.Stage = 1;
                    sJRFormProblemType.CreatedBy = "John Deo";
                    sJRFormProblemType.CreateDate = DateTime.Now;
                    sJRFormProblemType.UpdatedBy = "John Deo";
                    sJRFormProblemType.UpdatedDate = DateTime.Now;

                    ent.SJRFormProblemType.Add(sJRFormProblemType);
                    ent.SaveChanges();

                    PatientDetails patientDetail = (from pDetails in ent.PatientDetails
                                                    where pDetails.PatientId == PID
                                                    select pDetails).FirstOrDefault();


                    ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                                 where revStatus.PatientID == PID
                                                 select revStatus).FirstOrDefault();

                    reviewStatus.PatientID = PID;
                    // 1 for Amber
                    reviewStatus.METriage = 3;
                    reviewStatus.SJR1 = 3;
                    reviewStatus.SJR2 = 3;
                    reviewStatus.SJRoutcome = 2;
                    reviewStatus.CreatedBy = "John Deo";
                    reviewStatus.CreateDate = DateTime.Now;
                    reviewStatus.UpdatedBy = "John Deo";
                    reviewStatus.UpdatedDate = DateTime.Now;
                    ent.SaveChanges();

                    if (reviewStatus.SJR2 == 3)
                    {
                        return RedirectToAction("MortalityReview", new { Id = patientDetail.PatientId, PName = patientDetail.PatientName, DOB = Convert.ToDateTime(patientDetail.DOB) });
                    }

                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            return View();

        }

        private clsPatientDetailsModel GetPatientDetailsModel()
        {
            if (Session["sessionPatientDetailsModel"] == null)
            {
                Session["sessionPatientDetailsModel"] = new clsPatientDetailsModel();
            }
            return (clsPatientDetailsModel)Session["sessionPatientDetailsModel"];
        }

        private clsMedicalExaminerReviewModel GetMedicalExaminerReviewModel()
        {
            if (Session["sessionMedicalExaminerReview"] == null)
            {
                Session["sessionMedicalExaminerReview"] = new clsMedicalExaminerReviewModel();
            }
            return (clsMedicalExaminerReviewModel)Session["sessionMedicalExaminerReview"];
        }

        private clsMedicalExaminerDecisionModel GetMedicalExaminerDecisionModel()
        {
            if (Session["sessionMedicalExaminerDecision"] == null)
            {
                Session["sessionMedicalExaminerDecision"] = new clsMedicalExaminerDecisionModel();
            }
            return (clsMedicalExaminerDecisionModel)Session["sessionMedicalExaminerDecision"];
        }

        private clsSJRReviewModel GetSJRReviewModel()
        {
            if (Session["sessionSJRReview"] == null)
            {
                Session["sessionSJRReview"] = new clsSJRReviewModel();
            }
            return (clsSJRReviewModel)Session["sessionSJRReview"];
        }

        private clsOtherReferralModel GetOtherReferralModel()
        {
            if (Session["sessionOtherReferral"] == null)
            {
                Session["sessionOtherReferral"] = new clsOtherReferralModel();
            }
            return (clsOtherReferralModel)Session["sessionOtherReferral"];
        }

        private clsFeedBackModel GetFeedBackModel()
        {
            if (Session["sessionFeedBack"] == null)
            {
                Session["sessionFeedBack"] = new clsFeedBackModel();
            }
            return (clsFeedBackModel)Session["sessionFeedBack"];
        }

        private clsSJRFormInitialModel GetSJRFormInitialModel()
        {
            if (Session["sessionSJRFormInitial"] == null)
            {
                Session["sessionSJRFormInitial"] = new clsSJRFormInitialModel();
            }
            return (clsSJRFormInitialModel)Session["sessionSJRFormInitial"];
        }

        private clsSJROutComeModel GetSJROutComeModel()
        {
            if (Session["sessionSJROutComeModel"] == null)
            {
                Session["sessionSJROutComeModel"] = new clsSJROutComeModel();
            }
            return (clsSJROutComeModel)Session["sessionSJROutComeModel"];
        }


        public ActionResult PatientDetails(int? id)
        {
            clsPatientDetailsModel objPDM = GetPatientDetailsModel();

            Session["sessionPatientId"] = id;
            if (id != null)
            {
                clsPatientDetailsModel obj = new clsPatientDetailsModel();
                obj.objclPatientDetails = (from x in ent.PatientDetails
                                           where x.PatientId == id
                                           select new clsPatientDetails
                                           {
                                               PatientId = x.PatientId,
                                               SpellNumber = x.SpellNumber,
                                               PatientName = x.PatientName,
                                               AdmissionType = x.AdmissionType,
                                               NHSNumber = x.NHSNumber,
                                               DischargeConsutantName = x.DischargeConsutantName,
                                               Gender = x.Gender,
                                               Age = x.Age,
                                               DateofAdmission = x.DateofAdmission,
                                               DischargeWard = x.DischargeWard,
                                               DateofDeath = x.DateofDeath,
                                               TimeofDeath = x.TimeofDeath,
                                               TimeofAdmission = x.TimeofAdmission,
                                               PrimaryDiagnosis = x.PrimaryDiagnosis,
                                               CodingIssueIdentified = x.CodingIssueIdentified == true ? true : false,
                                               Comments = x.Comments
                                           }).FirstOrDefault();


                ViewBag.CilinicalCodingDropdown = (from cilinicalCoding in ent.ClinicalCoding select cilinicalCoding).ToList();

                ViewBag.CilinicalCodingCount = ent.ClinicalCoding.Count();


                Session["sessionClinicalCodingModel"] = obj;

                return View(obj);
            }
            else
            {

                ViewBag.CilinicalCodingDropdown = (from cilinicalCoding in ent.ClinicalCoding select cilinicalCoding).ToList();

                ViewBag.CilinicalCodingCount = ent.ClinicalCoding.Count();

                return View(objPDM);


            }
        }

        [HttpPost]
        public ActionResult PatientDetails(clsPatientDetailsModel clsPatientDetailsModel, string btnCloseYes, int? id)
        {
            try
            {
                clsPatientDetailsModel obj = new clsPatientDetailsModel();

                ViewBag.CilinicalCodingCount = ent.ClinicalCoding.Count();
                ViewBag.CilinicalCodingDropdown = (from cilinicalCoding in ent.ClinicalCoding select cilinicalCoding).ToList();
                //if (clsPatientDetailsModel.objclPatientDetails.PatientId != id)
                //{

                int intPId = Convert.ToInt32(id);

                ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                             where revStatus.PatientID == intPId
                                             select revStatus).FirstOrDefault();

                if (reviewStatus != null)
                {
                    int intPID = Convert.ToInt32(Session["sessionPatientId"]);



                    PatientDetails patientDetail = (from pDetails in ent.PatientDetails
                                                    where pDetails.PatientId == intPID
                                                    select pDetails).FirstOrDefault();


                    patientDetail.CodingIssueIdentified = clsPatientDetailsModel.objclPatientDetails.CodingIssueIdentified;
                    patientDetail.Comments = clsPatientDetailsModel.objclPatientDetails.Comments;
                    patientDetail.CreatedBy = "John Deo";
                    patientDetail.CreateDate = DateTime.Now;
                    patientDetail.UpdatedBy = "John Deo";
                    patientDetail.UpdatedDate = DateTime.Now;
                    ent.SaveChanges();


                    ReviewStatus reviewStatusUp = (from revStatus in ent.ReviewStatus
                                                   where revStatus.PatientID == intPID
                                                   select revStatus).FirstOrDefault();

                    reviewStatusUp.PatientID = intPID;
                    // 1 for Amber
                    reviewStatusUp.METriage = 1;
                    reviewStatusUp.SJR1 = 0;
                    reviewStatusUp.SJR2 = 0;
                    reviewStatusUp.SJRoutcome = 0;
                    reviewStatusUp.CreatedBy = "John Deo";
                    reviewStatusUp.CreateDate = DateTime.Now;
                    reviewStatusUp.UpdatedBy = "John Deo";
                    reviewStatusUp.UpdatedDate = DateTime.Now;
                    ent.SaveChanges();

                    Session["sessionPatientDetailsModel"] = clsPatientDetailsModel;
                    Response.Redirect("/Home/MedicalExaminerReview", false);
                }
                else
                {


                    int intPID = Convert.ToInt32(Session["sessionPatientId"]);


                    PatientDetails patientDetail = (from pDetails in ent.PatientDetails
                                                    where pDetails.PatientId == intPID
                                                    select pDetails).FirstOrDefault();


                    patientDetail.CodingIssueIdentified = clsPatientDetailsModel.objclPatientDetails.CodingIssueIdentified;
                    patientDetail.Comments = clsPatientDetailsModel.objclPatientDetails.Comments;
                    patientDetail.CreatedBy = "John Deo";
                    patientDetail.CreateDate = DateTime.Now;
                    patientDetail.UpdatedBy = "John Deo";
                    patientDetail.UpdatedDate = DateTime.Now;
                    ent.SaveChanges();

                    ReviewStatus reviewStatus1 = new ReviewStatus();
                    reviewStatus1.PatientID = intPId;
                    // 1 for Amber
                    reviewStatus1.METriage = 1;
                    reviewStatus1.SJR1 = 0;
                    reviewStatus1.SJR2 = 0;
                    reviewStatus1.SJRoutcome = 0;
                    reviewStatus1.CreatedBy = "John Deo";
                    reviewStatus1.CreateDate = DateTime.Now;
                    reviewStatus1.UpdatedBy = "John Deo";
                    reviewStatus1.UpdatedDate = DateTime.Now;
                    ent.ReviewStatus.Add(reviewStatus1);
                    ent.SaveChanges();

                    Session["sessionPatientDetailsModel"] = clsPatientDetailsModel;
                    Response.Redirect("/Home/MedicalExaminerReview", false);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            return View();
        }

        public ActionResult MedicalExaminerReview()
        {
            clsMedicalExaminerReviewModel clsMedicalExaminerReviewModel = GetMedicalExaminerReviewModel();
            return View(clsMedicalExaminerReviewModel);
        }

        [HttpPost]
        public ActionResult MedicalExaminerReview(clsMedicalExaminerReviewModel clsMedicalExaminerReviewModel, string BtnPrevious, string BtnNext)
        {
            try
            {

                if (BtnPrevious != null)
                {
                    Response.Redirect("/Home/PatientDetails", false);
                }

                if (BtnNext != null)
                {
                    if (clsMedicalExaminerReviewModel.objclsMedicalExaminerReview.MEReviewId == 0)
                    {

                        string firstName = "";
                        string midName = "";
                        string lastName = "";

                        string strMEName = clsMedicalExaminerReviewModel.objclsMedicalExaminer.ME_FirstName;
                        if (strMEName != null)
                        {
                            var names = strMEName.Split(' ');
                            firstName = names[0];
                            midName = names[1];
                            lastName = names[2];
                        }


                        MedicalExaminer medicalExaminer = new MedicalExaminer();

                        medicalExaminer.ME_FirstName = firstName;
                        medicalExaminer.ME_MiddleName = midName;
                        medicalExaminer.ME_LastName = lastName;
                        medicalExaminer.CreatedBy = "John Deo";
                        medicalExaminer.CreateDate = DateTime.Now;
                        medicalExaminer.UpdatedBy = "John Deo";
                        medicalExaminer.UpdatedDate = DateTime.Now;
                        ent.MedicalExaminer.Add(medicalExaminer);
                        ent.SaveChanges();

                        int intMEID = medicalExaminer.ME_ID;

                        int intPID = Convert.ToInt32(Session["sessionPatientId"]);

                        MedicalExaminerReview medicalExaminerReview = new MedicalExaminerReview();

                        medicalExaminerReview.PatientID = intPID;
                        medicalExaminerReview.ME_ID = intMEID;

                        medicalExaminerReview.QAP_Discussion = clsMedicalExaminerReviewModel.objclsMedicalExaminerReview.QAP_Discussion;
                        medicalExaminerReview.Notes_Review = clsMedicalExaminerReviewModel.objclsMedicalExaminerReview.Notes_Review;
                        medicalExaminerReview.Nok_Discussion = clsMedicalExaminerReviewModel.objclsMedicalExaminerReview.Nok_Discussion;
                        medicalExaminerReview.Comments = clsMedicalExaminerReviewModel.objclsMedicalExaminerReview.Comments;
                        medicalExaminerReview.QAPName = clsMedicalExaminerReviewModel.objclsMedicalExaminerReview.QAPName;
                        medicalExaminerReview.CreatedBy = "John Deo";
                        medicalExaminerReview.CreateDate = DateTime.Now;
                        medicalExaminerReview.UpdatedBy = "John Deo";
                        medicalExaminerReview.UpdatedDate = DateTime.Now;
                        ent.MedicalExaminerReview.Add(medicalExaminerReview);

                        ent.SaveChanges();

                        ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                                     where revStatus.PatientID == intPID
                                                     select revStatus).FirstOrDefault();

                        reviewStatus.PatientID = intPID;
                        // 1 for Amber
                        reviewStatus.METriage = 1;
                        reviewStatus.SJR1 = 0;
                        reviewStatus.SJR2 = 0;
                        reviewStatus.SJRoutcome = 0;
                        reviewStatus.CreatedBy = "John Deo";
                        reviewStatus.CreateDate = DateTime.Now;
                        reviewStatus.UpdatedBy = "John Deo";
                        reviewStatus.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();

                        clsMedicalExaminerReviewModel.objclsMedicalExaminerReview.MEReviewId = medicalExaminerReview.MEReviewId;
                        Session["sessionMedicalExaminerReview"] = clsMedicalExaminerReviewModel;
                        Response.Redirect("/Home/MedicalExaminerDecision", false);

                    }
                    else
                    {
                        int intPID = Convert.ToInt32(Session["sessionPatientId"]);



                        MedicalExaminerReview medicalExaminerReview = (from MEReview in ent.MedicalExaminerReview
                                                                       where MEReview.MEReviewId == clsMedicalExaminerReviewModel.objclsMedicalExaminerReview.MEReviewId
                                                                       select MEReview).FirstOrDefault();


                        medicalExaminerReview.PatientID = intPID;

                        medicalExaminerReview.QAP_Discussion = clsMedicalExaminerReviewModel.objclsMedicalExaminerReview.QAP_Discussion;
                        medicalExaminerReview.Notes_Review = clsMedicalExaminerReviewModel.objclsMedicalExaminerReview.Notes_Review;
                        medicalExaminerReview.Nok_Discussion = clsMedicalExaminerReviewModel.objclsMedicalExaminerReview.Nok_Discussion;
                        medicalExaminerReview.Comments = clsMedicalExaminerReviewModel.objclsMedicalExaminerReview.Comments;
                        medicalExaminerReview.QAPName = clsMedicalExaminerReviewModel.objclsMedicalExaminerReview.QAPName;
                        medicalExaminerReview.CreatedBy = "John Deo";
                        medicalExaminerReview.CreateDate = DateTime.Now;
                        medicalExaminerReview.UpdatedBy = "John Deo";
                        medicalExaminerReview.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();

                        MedicalExaminer medicalExaminer = (from mExaminer in ent.MedicalExaminer
                                                           where mExaminer.ME_ID == medicalExaminerReview.ME_ID
                                                           select mExaminer).FirstOrDefault();


                        string firstName = "";
                        string midName = "";
                        string lastName = "";

                        string strMEName = clsMedicalExaminerReviewModel.objclsMedicalExaminer.ME_FirstName;
                        if (strMEName != null)
                        {
                            var names = strMEName.Split(' ');
                            firstName = names[0];
                            midName = names[1];
                            lastName = names[2];
                        }

                        medicalExaminer.ME_FirstName = firstName;
                        medicalExaminer.ME_MiddleName = midName;
                        medicalExaminer.ME_LastName = lastName;
                        medicalExaminer.CreatedBy = "John Deo";
                        medicalExaminer.CreateDate = DateTime.Now;
                        medicalExaminer.UpdatedBy = "John Deo";
                        medicalExaminer.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();

                        ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                                     where revStatus.PatientID == intPID
                                                     select revStatus).FirstOrDefault();

                        reviewStatus.PatientID = intPID;
                        // 1 for Amber
                        reviewStatus.METriage = 1;
                        reviewStatus.SJR1 = 0;
                        reviewStatus.SJR2 = 0;
                        reviewStatus.SJRoutcome = 0;
                        reviewStatus.CreatedBy = "John Deo";
                        reviewStatus.CreateDate = DateTime.Now;
                        reviewStatus.UpdatedBy = "John Deo";
                        reviewStatus.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();


                        clsMedicalExaminerReviewModel.objclsMedicalExaminerReview.MEReviewId = medicalExaminerReview.MEReviewId;
                        Session["sessionMedicalExaminerReview"] = clsMedicalExaminerReviewModel;
                        Response.Redirect("/Home/MedicalExaminerDecision", false);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

            return View();
        }

        public ActionResult MedicalExaminerDecision()
        {
            clsMedicalExaminerDecisionModel clsMedicalExaminerDecisionModel = GetMedicalExaminerDecisionModel();
            return View(clsMedicalExaminerDecisionModel);
        }

        [HttpPost]
        public ActionResult MedicalExaminerDecision(clsMedicalExaminerDecisionModel clsMedicalExaminerDecisionModel, string BtnPrevious, string BtnNext)
        {
            try
            {
                if (BtnPrevious != null)
                {
                    Response.Redirect("/Home/MedicalExaminerReview", false);
                }
                if (BtnNext != null)
                {
                    if (clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.MED_ID == 0)
                    {

                        CoronerReferralReason coronerReferralReason = new CoronerReferralReason();
                        coronerReferralReason.ReasonName = clsMedicalExaminerDecisionModel.objclsCoronerReferralReason.ReasonName;
                        coronerReferralReason.CreatedBy = "John Deo";
                        coronerReferralReason.CreateDate = DateTime.Now;
                        coronerReferralReason.UpdatedBy = "John Deo";
                        coronerReferralReason.UpdatedDate = DateTime.Now;
                        ent.CoronerReferralReason.Add(coronerReferralReason);
                        ent.SaveChanges();

                        int intCoronerReferralReasonsId = coronerReferralReason.Reason_ID;

                        int intPID = Convert.ToInt32(Session["sessionPatientId"]);

                        MedicalExaminerDecision medicalExaminerDecision = new MedicalExaminerDecision();
                        medicalExaminerDecision.PatientID = intPID;
                        medicalExaminerDecision.MCCDissue = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.MCCDissue;
                        medicalExaminerDecision.CornerReferral = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CornerReferral;
                        medicalExaminerDecision.HospitalPostMortem = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.HospitalPostMortem;
                        medicalExaminerDecision.CoronerReferralReasonID = intCoronerReferralReasonsId;
                        medicalExaminerDecision.CauseOfDeath1 = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CauseOfDeath1;
                        medicalExaminerDecision.CauseOfDeath2 = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CauseOfDeath2;
                        medicalExaminerDecision.CauseOfDeath3 = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CauseOfDeath3;
                        medicalExaminerDecision.CauseOfDeath4 = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CauseOfDeath4;
                        medicalExaminerDecision.DeathCertificate = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.DeathCertificate;
                        medicalExaminerDecision.CornerReferralComplete = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CornerReferralComplete;
                        medicalExaminerDecision.CoronerDecisionInquest = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CoronerDecisionInquest;
                        medicalExaminerDecision.CoronerDecisionPostMortem = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CoronerDecisionPostMortem;
                        medicalExaminerDecision.CoronerDecision100A = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CoronerDecision100A;
                        medicalExaminerDecision.CoronerDecisionGPissue = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CoronerDecisionGPissue;
                        medicalExaminerDecision.CreatedBy = "John Deo";
                        medicalExaminerDecision.CreateDate = DateTime.Now;
                        medicalExaminerDecision.UpdatedBy = "John Deo";
                        medicalExaminerDecision.UpdatedDate = DateTime.Now;
                        ent.MedicalExaminerDecision.Add(medicalExaminerDecision);
                        ent.SaveChanges();

                        ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                                     where revStatus.PatientID == intPID
                                                     select revStatus).FirstOrDefault();

                        reviewStatus.PatientID = intPID;
                        // 1 for Amber
                        reviewStatus.METriage = 1;
                        reviewStatus.SJR1 = 0;
                        reviewStatus.SJR2 = 0;
                        reviewStatus.SJRoutcome = 0;
                        reviewStatus.CreatedBy = "John Deo";
                        reviewStatus.CreateDate = DateTime.Now;
                        reviewStatus.UpdatedBy = "John Deo";
                        reviewStatus.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();

                        clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.MED_ID = medicalExaminerDecision.MED_ID;
                        Session["sessionMedicalExaminerDecision"] = clsMedicalExaminerDecisionModel;

                        Response.Redirect("/Home/SJRAssessmentTriage", false);

                    }
                    else
                    {
                        int intPID = Convert.ToInt32(Session["sessionPatientId"]);



                        MedicalExaminerDecision medicalExaminerDecision = (from medicalExaminerD in ent.MedicalExaminerDecision
                                                                           where medicalExaminerD.MED_ID == clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.MED_ID
                                                                           select medicalExaminerD).FirstOrDefault();


                        medicalExaminerDecision.PatientID = intPID;
                        medicalExaminerDecision.MCCDissue = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.MCCDissue;
                        medicalExaminerDecision.CornerReferral = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CornerReferral;
                        medicalExaminerDecision.HospitalPostMortem = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.HospitalPostMortem;
                        medicalExaminerDecision.CauseOfDeath1 = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CauseOfDeath1;
                        medicalExaminerDecision.CauseOfDeath2 = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CauseOfDeath2;
                        medicalExaminerDecision.CauseOfDeath3 = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CauseOfDeath3;
                        medicalExaminerDecision.CauseOfDeath4 = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CauseOfDeath4;
                        medicalExaminerDecision.DeathCertificate = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.DeathCertificate;
                        medicalExaminerDecision.CornerReferralComplete = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CornerReferralComplete;
                        medicalExaminerDecision.CoronerDecisionInquest = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CoronerDecisionInquest;
                        medicalExaminerDecision.CoronerDecisionPostMortem = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CoronerDecisionPostMortem;
                        medicalExaminerDecision.CoronerDecision100A = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CoronerDecision100A;
                        medicalExaminerDecision.CoronerDecisionGPissue = clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.CoronerDecisionGPissue;
                        medicalExaminerDecision.CreatedBy = "John Deo";
                        medicalExaminerDecision.CreateDate = DateTime.Now;
                        medicalExaminerDecision.UpdatedBy = "John Deo";
                        medicalExaminerDecision.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();



                        CoronerReferralReason coronerReferralReason = (from coronerReferral in ent.CoronerReferralReason
                                                                       where coronerReferral.Reason_ID == medicalExaminerDecision.CoronerReferralReasonID
                                                                       select coronerReferral).FirstOrDefault();

                        coronerReferralReason.ReasonName = clsMedicalExaminerDecisionModel.objclsCoronerReferralReason.ReasonName;
                        coronerReferralReason.CreatedBy = "John Deo";
                        coronerReferralReason.CreateDate = DateTime.Now;
                        coronerReferralReason.UpdatedBy = "John Deo";
                        coronerReferralReason.UpdatedDate = DateTime.Now;



                        ent.SaveChanges();

                        ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                                     where revStatus.PatientID == intPID
                                                     select revStatus).FirstOrDefault();

                        reviewStatus.PatientID = intPID;
                        // 1 for Amber
                        reviewStatus.METriage = 1;
                        reviewStatus.SJR1 = 0;
                        reviewStatus.SJR2 = 0;
                        reviewStatus.SJRoutcome = 0;
                        reviewStatus.CreatedBy = "John Deo";
                        reviewStatus.CreateDate = DateTime.Now;
                        reviewStatus.UpdatedBy = "John Deo";
                        reviewStatus.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();

                        clsMedicalExaminerDecisionModel.objclsMedicalExaminerDecision.MED_ID = medicalExaminerDecision.MED_ID;
                        Session["sessionMedicalExaminerDecision"] = clsMedicalExaminerDecisionModel;
                        Response.Redirect("/Home/SJRAssessmentTriage", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

            return View();
        }

        public ActionResult SJRAssessmentTriage()
        {
            clsSJRReviewModel clsSJRReviewModel = GetSJRReviewModel();
            return View(clsSJRReviewModel);
        }

        [HttpPost]
        public ActionResult SJRAssessmentTriage(clsSJRReviewModel clsSJRReviewModel, string BtnPrevious, string BtnNext)
        {
            try
            {
                if (BtnPrevious != null)
                {
                    Response.Redirect("/Home/MedicalExaminerDecision", false);
                }
                if (BtnNext != null)
                {
                    if (clsSJRReviewModel.objclsSJRReview.SJRReview_ID == 0)
                    {

                        SJRReviewSpeciality sJRReviewSpeciality = new SJRReviewSpeciality();
                        sJRReviewSpeciality.Name = clsSJRReviewModel.objclsSJRReviewSpeciality.Name;
                        sJRReviewSpeciality.CreatedBy = "John Deo";
                        sJRReviewSpeciality.CreateDate = DateTime.Now;
                        sJRReviewSpeciality.UpdatedBy = "John Deo";
                        sJRReviewSpeciality.UpdatedDate = DateTime.Now;
                        ent.SJRReviewSpeciality.Add(sJRReviewSpeciality);
                        ent.SaveChanges();


                        int intSJRReviewSpecialityId = sJRReviewSpeciality.SJRReviewSpecialityID;

                        int intPID = Convert.ToInt32(Session["sessionPatientId"]);


                        SJRReview sJRReview = new SJRReview();
                        sJRReview.PatientID = intPID;
                        sJRReview.PaediatricPatient = clsSJRReviewModel.objclsSJRReview.PaediatricPatient;
                        sJRReview.LearningDisabilityPatient = clsSJRReviewModel.objclsSJRReview.LearningDisabilityPatient;
                        sJRReview.MentalillnessPatient = clsSJRReviewModel.objclsSJRReview.MentalillnessPatient;
                        sJRReview.ElectiveAdmission = clsSJRReviewModel.objclsSJRReview.ElectiveAdmission;
                        sJRReview.NoKConcernsDeath = clsSJRReviewModel.objclsSJRReview.NoKConcernsDeath;
                        sJRReview.OtherConcern = clsSJRReviewModel.objclsSJRReview.NoKConcernsDeath;
                        sJRReview.FullSJRRequired = clsSJRReviewModel.objclsSJRReview.FullSJRRequired;
                        sJRReview.SJRReviewSpecialityID = intSJRReviewSpecialityId;
                        sJRReview.CreatedBy = "John Deo";
                        sJRReview.CreateDate = DateTime.Now;
                        sJRReview.UpdatedBy = "John Deo";
                        sJRReview.UpdatedDate = DateTime.Now;
                        ent.SJRReview.Add(sJRReview);
                        ent.SaveChanges();

                        ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                                     where revStatus.PatientID == intPID
                                                     select revStatus).FirstOrDefault();

                        reviewStatus.PatientID = intPID;
                        // 1 for Amber
                        reviewStatus.METriage = 1;
                        reviewStatus.SJR1 = 0;
                        reviewStatus.SJR2 = 0;
                        reviewStatus.SJRoutcome = 0;
                        reviewStatus.CreatedBy = "John Deo";
                        reviewStatus.CreateDate = DateTime.Now;
                        reviewStatus.UpdatedBy = "John Deo";
                        reviewStatus.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();


                        clsSJRReviewModel.objclsSJRReview.SJRReview_ID = sJRReview.SJRReview_ID;
                        Session["sessionSJRReview"] = clsSJRReviewModel;

                        Response.Redirect("/Home/OtherReferrals", false);

                    }
                    else
                    {
                        int intPID = Convert.ToInt32(Session["sessionPatientId"]);



                        SJRReview sJRReview = (from sjrReview in ent.SJRReview
                                               where sjrReview.SJRReview_ID == clsSJRReviewModel.objclsSJRReview.SJRReview_ID
                                               select sjrReview).FirstOrDefault();

                        sJRReview.PatientID = intPID;
                        sJRReview.PaediatricPatient = clsSJRReviewModel.objclsSJRReview.PaediatricPatient;
                        sJRReview.LearningDisabilityPatient = clsSJRReviewModel.objclsSJRReview.LearningDisabilityPatient;
                        sJRReview.MentalillnessPatient = clsSJRReviewModel.objclsSJRReview.MentalillnessPatient;
                        sJRReview.ElectiveAdmission = clsSJRReviewModel.objclsSJRReview.ElectiveAdmission;
                        sJRReview.NoKConcernsDeath = clsSJRReviewModel.objclsSJRReview.NoKConcernsDeath;
                        sJRReview.OtherConcern = clsSJRReviewModel.objclsSJRReview.NoKConcernsDeath;
                        sJRReview.FullSJRRequired = clsSJRReviewModel.objclsSJRReview.FullSJRRequired;

                        sJRReview.CreatedBy = "John Deo";
                        sJRReview.CreateDate = DateTime.Now;
                        sJRReview.UpdatedBy = "John Deo";
                        sJRReview.UpdatedDate = DateTime.Now;
                        ent.SJRReview.Add(sJRReview);
                        ent.SaveChanges();

                        SJRReviewSpeciality sJRReviewSpeciality = (from sJRReviewSpec in ent.SJRReviewSpeciality
                                                                   where sJRReviewSpec.SJRReviewSpecialityID == sJRReview.SJRReviewSpecialityID
                                                                   select sJRReviewSpec).FirstOrDefault();

                        sJRReviewSpeciality.Name = clsSJRReviewModel.objclsSJRReviewSpeciality.Name;
                        sJRReviewSpeciality.CreatedBy = "John Deo";
                        sJRReviewSpeciality.CreateDate = DateTime.Now;
                        sJRReviewSpeciality.UpdatedBy = "John Deo";
                        sJRReviewSpeciality.UpdatedDate = DateTime.Now;

                        ent.SaveChanges();


                        ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                                     where revStatus.PatientID == intPID
                                                     select revStatus).FirstOrDefault();

                        reviewStatus.PatientID = intPID;
                        // 1 for Amber
                        reviewStatus.METriage = 1;
                        reviewStatus.SJR1 = 0;
                        reviewStatus.SJR2 = 0;
                        reviewStatus.SJRoutcome = 0;
                        reviewStatus.CreatedBy = "John Deo";
                        reviewStatus.CreateDate = DateTime.Now;
                        reviewStatus.UpdatedBy = "John Deo";
                        reviewStatus.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();
                        clsSJRReviewModel.objclsSJRReview.SJRReview_ID = sJRReview.SJRReview_ID;
                        Session["sessionSJRReview"] = clsSJRReviewModel;

                        Response.Redirect("/Home/OtherReferrals", false);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            return View();
        }

        public ActionResult OtherReferrals()
        {
            clsOtherReferralModel clsOtherReferralModel = GetOtherReferralModel();
            return View(clsOtherReferralModel);
        }

        [HttpPost]
        public ActionResult OtherReferrals(clsOtherReferralModel clsOtherReferralModel, string BtnPrevious, string BtnNext)
        {
            try
            {
                if (BtnPrevious != null)
                {
                    Response.Redirect("/Home/SJRAssessmentTriage", false);
                }
                if (BtnNext != null)
                {
                    if (clsOtherReferralModel.OtherReferral_ID == 0)
                    {

                        int intPID = Convert.ToInt32(Session["sessionPatientId"]);


                        OtherReferral otherReferral = new OtherReferral();

                        otherReferral.PatientID = intPID;
                        otherReferral.PatientSafetySIRI = clsOtherReferralModel.PatientSafetySIRI;
                        otherReferral.PatientSafetySIRIReason = clsOtherReferralModel.PatientSafetySIRIReason;
                        otherReferral.ChildDeathCoordinator = clsOtherReferralModel.ChildDeathCoordinator;
                        otherReferral.LearningDisabilityNurse = clsOtherReferralModel.LearningDisabilityNurse;
                        otherReferral.HeadOfCompliance = clsOtherReferralModel.HeadOfCompliance;
                        otherReferral.HeadOfComplianceReason = clsOtherReferralModel.HeadOfComplianceReason;
                        otherReferral.PALsComplaints = clsOtherReferralModel.PALsComplaints;
                        otherReferral.PALsComplaintsReason = clsOtherReferralModel.PALsComplaintsReason;
                        otherReferral.WardTeam = clsOtherReferralModel.WardTeam;
                        otherReferral.WardTeamReason = clsOtherReferralModel.WardTeamReason;
                        otherReferral.Other = clsOtherReferralModel.Other;
                        otherReferral.OtherReason = clsOtherReferralModel.OtherReason;
                        otherReferral.CreatedBy = "John Deo";
                        otherReferral.CreateDate = DateTime.Now;
                        otherReferral.UpdatedBy = "John Deo";
                        otherReferral.UpdatedDate = DateTime.Now;
                        ent.OtherReferral.Add(otherReferral);
                        ent.SaveChanges();

                        ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                                     where revStatus.PatientID == intPID
                                                     select revStatus).FirstOrDefault();

                        reviewStatus.PatientID = intPID;
                        // 1 for Amber
                        reviewStatus.METriage = 1;
                        reviewStatus.SJR1 = 0;
                        reviewStatus.SJR2 = 0;
                        reviewStatus.SJRoutcome = 0;
                        reviewStatus.CreatedBy = "John Deo";
                        reviewStatus.CreateDate = DateTime.Now;
                        reviewStatus.UpdatedBy = "John Deo";
                        reviewStatus.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();

                        clsOtherReferralModel.OtherReferral_ID = otherReferral.OtherReferral_ID;
                        Session["sessionOtherReferral"] = clsOtherReferralModel;
                        Response.Redirect("/Home/PositiveFeedback", false);
                    }

                    else
                    {
                        int intPID = Convert.ToInt32(Session["sessionPatientId"]);


                        OtherReferral otherReferral = (from otherRefe in ent.OtherReferral
                                                       where otherRefe.OtherReferral_ID == clsOtherReferralModel.OtherReferral_ID
                                                       select otherRefe).FirstOrDefault();

                        otherReferral.PatientID = intPID;
                        otherReferral.PatientSafetySIRI = clsOtherReferralModel.PatientSafetySIRI;
                        otherReferral.PatientSafetySIRIReason = clsOtherReferralModel.PatientSafetySIRIReason;
                        otherReferral.ChildDeathCoordinator = clsOtherReferralModel.ChildDeathCoordinator;
                        otherReferral.LearningDisabilityNurse = clsOtherReferralModel.LearningDisabilityNurse;
                        otherReferral.HeadOfCompliance = clsOtherReferralModel.HeadOfCompliance;
                        otherReferral.HeadOfComplianceReason = clsOtherReferralModel.HeadOfComplianceReason;
                        otherReferral.PALsComplaints = clsOtherReferralModel.PALsComplaints;
                        otherReferral.PALsComplaintsReason = clsOtherReferralModel.PALsComplaintsReason;
                        otherReferral.WardTeam = clsOtherReferralModel.WardTeam;
                        otherReferral.WardTeamReason = clsOtherReferralModel.WardTeamReason;
                        otherReferral.Other = clsOtherReferralModel.Other;
                        otherReferral.OtherReason = clsOtherReferralModel.OtherReason;
                        otherReferral.CreatedBy = "John Deo";
                        otherReferral.CreateDate = DateTime.Now;
                        otherReferral.UpdatedBy = "John Deo";
                        otherReferral.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();

                        ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                                     where revStatus.PatientID == intPID
                                                     select revStatus).FirstOrDefault();

                        reviewStatus.PatientID = intPID;
                        // 1 for Amber
                        reviewStatus.METriage = 1;
                        reviewStatus.SJR1 = 0;
                        reviewStatus.SJR2 = 0;
                        reviewStatus.SJRoutcome = 0;
                        reviewStatus.CreatedBy = "John Deo";
                        reviewStatus.CreateDate = DateTime.Now;
                        reviewStatus.UpdatedBy = "John Deo";
                        reviewStatus.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();

                        clsOtherReferralModel.OtherReferral_ID = otherReferral.OtherReferral_ID;
                        Session["sessionOtherReferral"] = clsOtherReferralModel;
                        Response.Redirect("/Home/PositiveFeedback", false);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            return View();
        }

        public ActionResult PositiveFeedback()
        {
            clsFeedBackModel clsFeedBackModel = GetFeedBackModel();
            return View(clsFeedBackModel);
        }

        [HttpPost]

        public ActionResult PositiveFeedback(clsFeedBackModel clsFeedBackModel, string BtnPrevious, string BtnFinish, string BtnNext)
        {
            try
            {
                if (BtnPrevious != null)
                {
                    Response.Redirect("/Home/OtherReferrals", false);
                }
                if (BtnFinish != null)
                {
                    if (clsFeedBackModel.FeedBack_ID == 0)
                    {

                        int intPID = Convert.ToInt32(Session["sessionPatientId"]);

                        FeedBack feedBack = new FeedBack();
                        feedBack.PatientID = intPID;
                        feedBack.FormCompleted = clsFeedBackModel.FormCompleted;
                        feedBack.ComplementsFedBack = clsFeedBackModel.ComplementsFedBack;
                        feedBack.CreatedBy = "John Deo";
                        feedBack.CreateDate = DateTime.Now;
                        feedBack.UpdatedBy = "John Deo";
                        feedBack.UpdatedDate = DateTime.Now;
                        ent.FeedBack.Add(feedBack);
                        ent.SaveChanges();

                        ReviewStatus reviewStatus = (from revStatus in ent.ReviewStatus
                                                     where revStatus.PatientID == intPID
                                                     select revStatus).FirstOrDefault();

                        reviewStatus.PatientID = intPID;
                        // 1 for Amber
                        reviewStatus.METriage = 3;
                        reviewStatus.SJR1 = 2;
                        reviewStatus.SJR2 = 0;
                        reviewStatus.SJR2 = 0;
                        reviewStatus.SJRoutcome = 0;
                        reviewStatus.CreatedBy = "John Deo";
                        reviewStatus.CreateDate = DateTime.Now;
                        reviewStatus.UpdatedBy = "John Deo";
                        reviewStatus.UpdatedDate = DateTime.Now;
                        ent.SaveChanges();



                        clsFeedBackModel.FeedBack_ID = feedBack.FeedBack_ID;
                        Session["sessionFeedBack"] = clsFeedBackModel;

                        //Response.Redirect("/Home/CORSPatient", false);

                        PatientDetails patientDetails = (from pDetls in ent.PatientDetails
                                                         where pDetls.PatientId == intPID
                                                         select pDetls).FirstOrDefault();

                        if (reviewStatus.METriage == 3)
                        {
                            return RedirectToAction("MortalityReview", new { Id = patientDetails.PatientId, PName = patientDetails.PatientName, DOB = Convert.ToDateTime(patientDetails.DOB) });
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            return View();
        }

        public ActionResult MedicalExaminerDashboard(FormCollection formCollection, string btnSearch, int? pNo)
        {
            Session.Remove("sessionPatientDetailsModel");
            Session.Remove("sessionMedicalExaminerReview");
            Session.Remove("sessionMedicalExaminerDecision");
            Session.Remove("sessionSJRReview");
            Session.Remove("sessionOtherReferral");
            Session.Remove("sessionFeedBack");
            Session.Remove("sessionSJRFormInitial");
            Session.Remove("sessionSJROutComeModel");
            Session.Remove("sessionPatientId");


            if (btnSearch != null)
            {
                //string strStartDate = formCollection["txtStartDate"];
                //string strEndDate = formCollection["txtEndDate"];
                string strDischargeSpeciality = formCollection["ddlDischargeSpeciality"];
                string strWardDeath = formCollection["ddlWardDeath"];
                string strDischargeConsultant = formCollection["ddlDischargeConsultant"];
                //int intDischargeConsultantId = Convert.ToInt32(ddlSpecialityReviewName);

                clPatientDetailsDashbord clsPatientDetailsDashbord = new clPatientDetailsDashbord();
                clsPatientDetailsDashbord.PatientDtls = (from x in ent.PatientDetails
                                                         where x.DischargeSpeciality == strDischargeSpeciality || x.DischargeWard == strWardDeath || x.DischargeConsutantName == strDischargeConsultant
                                                         select new clsPatientDetailsDashbord
                                                         {
                                                             PatientId = x.PatientId,
                                                             PatientName = x.PatientName,
                                                             DOB = x.DOB,
                                                             NHSNumber = x.NHSNumber,
                                                             DateofAdmission = x.DateofAdmission.HasValue ? x.DateofAdmission : null,
                                                             DateofDeath = x.DateofDeath,
                                                             WardofDeath = x.WardofDeath,
                                                             TimeofDeath = x.TimeofDeath,
                                                             DischargeSpeciality = x.DischargeSpeciality,
                                                             AdmissionType = x.AdmissionType,
                                                             DischargeWard = x.DischargeWard,
                                                             DischargeConsutantName = x.DischargeConsutantName,
                                                         }).ToList();

                ViewBag.LoadDischargeSpecialityDropdown = (from dischrageSpecility in ent.PatientDetails select dischrageSpecility).ToList();

                ViewBag.wardDeathDropdown = (from patientDetails in ent.PatientDetails
                                             select patientDetails).ToList();

                ViewBag.dischargeConsultantDropdown = (from dischargeConsultant in ent.PatientDetails
                                                       select dischargeConsultant).ToList();



                return View(clsPatientDetailsDashbord);

            }
            else
            {


                clPatientDetailsDashbord clPatientDetailsDashbord = new clPatientDetailsDashbord();
                clPatientDetailsDashbord.PatientDtls = (from x in ent.PatientDetails
                                                        join u in ent.ReviewStatus on x.PatientId equals u.PatientID into leftjoinreviewstatus
                                                        from objrevstatus in leftjoinreviewstatus.DefaultIfEmpty()
                                                        join sjrReview in ent.SJRReview on x.PatientId equals sjrReview.PatientID into leftSJRReview
                                                        from objReview in leftSJRReview.DefaultIfEmpty()
                                                        orderby x.PatientId ascending
                                                        select new clsPatientDetailsDashbord
                                                        {
                                                            PatientId = x.PatientId,
                                                            PatientName = x.PatientName,
                                                            DOB = x.DOB,
                                                            NHSNumber = x.NHSNumber,
                                                            DateofAdmission = x.DateofAdmission.HasValue ? x.DateofAdmission : null,
                                                            DateofDeath = x.DateofDeath,
                                                            WardofDeath = x.WardofDeath,
                                                            DischargeSpeciality = x.DischargeSpeciality,
                                                            AdmissionType = x.AdmissionType,
                                                            DischargeWard = x.DischargeWard,
                                                            DischargeConsutantName = x.DischargeConsutantName,
                                                            TimeofDeath = x.TimeofDeath,
                                                            METriage = objrevstatus.METriage,
                                                            SJR1 = objrevstatus.SJR1,
                                                            SJR2 = objrevstatus.SJR2,
                                                            SJRoutcome = objrevstatus.SJRoutcome,
                                                            FullSJRRequired = objReview.FullSJRRequired

                                                        }).ToList();


                ViewBag.LoadDischargeSpecialityDropdown = (from dischrageSpecility in ent.PatientDetails select dischrageSpecility).ToList();

                ViewBag.wardDeathDropdown = (from patientDetails in ent.PatientDetails
                                             select patientDetails).ToList();

                ViewBag.dischargeConsultantDropdown = (from dischargeConsultant in ent.PatientDetails
                                                       select dischargeConsultant).ToList();



                return View(clPatientDetailsDashbord);
            }

        }

        public ActionResult MortalityReview(string Id, string PName, DateTime DOB)
        {
            int pId = Convert.ToInt32(Id);
            //  DateTime dateTime = DOB ?? DateTime.Now;

            clsCodingReview obj = new clsCodingReview();
            obj = (from x in ent.ReviewStatus
                   join sjrReview in ent.SJRReview on x.PatientID equals sjrReview.PatientID into leftSJRReview
                   from objReview in leftSJRReview.DefaultIfEmpty()
                       //join u in ent.PatientDetails on x.PatientID equals u.PatientId into leftjoinPatdDtls
                       //from objPDtls in leftjoinPatdDtls.DefaultIfEmpty()
                   where x.PatientID == pId
                   select new clsCodingReview
                   {
                       PatientId = x.PatientID,
                       METriage = x.METriage,
                       SJR1 = x.SJR1,
                       SJR2 = x.SJR2,
                       SJRoutcome = x.SJRoutcome,
                       //PName= PName,
                       //DOB = DOB,
                       PatientName = PName,
                       DOB = DOB,
                       FullSJRRequired = objReview.FullSJRRequired

                   }).FirstOrDefault();

            if (obj == null)
            {
                obj = (from x in ent.PatientDetails
                       where x.PatientId == pId
                       select new clsCodingReview
                       {
                           PatientId = x.PatientId,
                           PatientName = PName,
                           DOB = DOB
                       }).FirstOrDefault();
            }


            return View(obj);
        }

        public ActionResult PatientHistory()
        {


            return View();
        }
    }
}
