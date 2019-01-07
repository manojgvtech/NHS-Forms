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

        
        public ActionResult SJROutcome(string btnSumbit)
        {
            if (btnSumbit != null)
            {
                //  Response.Redirect("/MedicalExaminerDashboard.cshtml");

                return RedirectToAction("/MedicalExaminerDashboard");
            }

            //if (data.Count != 0)
            //{
            //    var lastRecordPatientMap = ent.PatientMaps.OrderByDescending(p => p.PatientID).FirstOrDefault();
            //    int lastPatientId = lastRecordPatientMap.PatientID;

            //    SJROutcomes sJROutcomes = new SJROutcomes();
            //    Boolean blStage2SJRRequiredYes = data["cbStage2SJRRequiredYes"] != null ? true : false;
            //    Boolean blStage2SJRRequiredNo = data["cbStage2SJRRequiredNo"] != null ? true : false;
            //    string strStage2SJRDateSent = data["txtStage2SJRDateSent"];
            //    string strStage2SJRSentTo = data["txtStage2SJRSentTo"];
            //    string strRefernceNumber = data["txtRefernceNumber"];
            //    string strDateReceived = data["txtDateReceived"];
            //    string strRCAOutcomeComments = data["taRCAOutcomeComments"];

            //    if (blStage2SJRRequiredNo == true)
            //    {
            //        sJROutcomes.Stage2SJRRequired = false;
            //    }

            //    sJROutcomes.Stage2SJRRequired = blStage2SJRRequiredYes;
            //    sJROutcomes.Stage2SJRDateSent = strStage2SJRDateSent;
            //    sJROutcomes.Stage2SJRSentTo = strStage2SJRSentTo;
            //    sJROutcomes.ReferenceNumber = strRefernceNumber;
            //    sJROutcomes.DateReceived = Convert.ToDateTime(strDateReceived);
            //    sJROutcomes.Comments = strRCAOutcomeComments;
            //    sJROutcomes.PatientID = lastPatientId;
            //    ent.SJROutcomes1.Add(sJROutcomes);
            //    ent.SaveChanges();


            //    MortalitySurveillance mortalitySurveillance = new MortalitySurveillance();
            //    Boolean blPresentationToMSGYes = data["cbPresentationToMSGYes"] != null ? true : false;
            //    Boolean blPresentationToMSGNo = data["cbPresentationToMSGNo"] != null ? true : false;
            //    if (blPresentationToMSGNo == true)
            //    {
            //        mortalitySurveillance.PresentationToMSG = false;
            //    }
            //    string strDiscussedToMSG = data["txtDiscussedToMSG"];
            //    int intAvoidabilityScoreId = Convert.ToInt32(data["ddlAvoidabilityScore"]);
            //    string strMortalitySurveillanceComments = data["taMortalitySurveillanceComments"];
            //    string strFeedbackToNok = data["taFeedbackToNok"];

            //    mortalitySurveillance.PresentationToMSG = blPresentationToMSGYes;
            //    mortalitySurveillance.DiscussedWithMSG = strDiscussedToMSG;
            //    mortalitySurveillance.AvoidabilityScoreID = intAvoidabilityScoreId;
            //    mortalitySurveillance.Comments = strMortalitySurveillanceComments;
            //    mortalitySurveillance.FeedbackToNoK = strFeedbackToNok;
            //    mortalitySurveillance.PatientID = lastPatientId;
            //    ent.MortalitySurveillances.Add(mortalitySurveillance);
            //    ent.SaveChanges();
            // }
            return View();
        }
        //public ActionResult Stage2SJRform(FormCollection data)
       

        public ActionResult Stage2SJRformFirstStep(FormCollection data, string BtnNext)
        {
            if (BtnNext != null)
            {
                try
                {
                    CareRating careRating1 = new CareRating();
                    string strInitialManagementRating = data["ddlInitialManagementRating"];
                    careRating1.Name = strInitialManagementRating;
                    Session["careRating1"] = careRating1;

                    CareRating careRating2 = new CareRating();
                    string strOnGoingCareRating = data["ddlOnGoingCareRating"];
                    careRating2.Name = strOnGoingCareRating;
                    Session["careRating2"] = careRating2;

                    CareRating careRating3 = new CareRating();
                    string strCareDuringProcedureCareRating = data["ddlCareDuringProcedureCareRating"];
                    careRating3.Name = strCareDuringProcedureCareRating;
                    Session["careRating3"] = careRating3;

                    CareRating careRating4 = new CareRating();
                    string strEndLifeCareRating = data["ddlEndLifeCareRating"];
                    careRating4.Name = strEndLifeCareRating;
                    Session["careRating4"] = careRating4;

                    CareRating careRating5 = new CareRating();
                    string strOverAllAssessmentCareRating = data["ddlOverAllAssessmentCareRating"];
                    careRating5.Name = strOverAllAssessmentCareRating;
                    Session["careRating5"] = careRating5;

                    SJRFormInitial sJRFormInitial = new SJRFormInitial();

                    string strInitialManagement = data["taInitialManagement"];
                    sJRFormInitial.InitialManagement = strInitialManagement;
                    string strOngoingCare = data["taOngoingCare"];
                    sJRFormInitial.OngoingCare = strOngoingCare;
                    string strCareDuringProcedure = data["taCareDuringProcedure"];
                    sJRFormInitial.CareDuringProcedure = strCareDuringProcedure;
                    string strEndLifeCare = data["taEndLifeCare"];
                    sJRFormInitial.EndLifeCare = strEndLifeCare;
                    string strOverAllAssessment = data["taOverAllAssessment"];
                    sJRFormInitial.OverAllAssessment = strOverAllAssessment;
                    Session["sJRFormInitial"] = sJRFormInitial;

                    //return RedirectToAction("/Stage2SJRformSecondStep");
                    Response.Redirect("/Home/Stage2SJRformSecondStep");
                }
                catch (Exception ex)
                {
                    Console.Write(ex.StackTrace);
                }
            }

            return View();
        }

        public ActionResult Stage2SJRformSecondStep(FormCollection data, string BtnPrevious, string BtnFinish)
        {
            if (BtnPrevious != null)
            {
                Session["BtnPrevious"] = BtnPrevious;
                return RedirectToAction("/Stage2SJRformFirstStep");
            }
            if (BtnFinish != null)
            {
                try
                {
                    var sessionInitialManagementRating = (NHS.Models.CareRating)Session["careRating1"];
                    var sessionOnGoingCareRating = (NHS.Models.CareRating)Session["careRating2"];
                    var sessionCareDuringProcedureCareRating = (NHS.Models.CareRating)Session["careRating3"];
                    var sessionEndLifeCareRating = (NHS.Models.CareRating)Session["careRating4"];
                    var sessionOverAllAssessmentCareRating = (NHS.Models.CareRating)Session["careRating5"];

                    string strInitialManagementRating = sessionInitialManagementRating.Name;
                    string strOnGoingCareRating = sessionOnGoingCareRating.Name;
                    string strCareDuringProcedureCareRating = sessionCareDuringProcedureCareRating.Name;
                    string strEndLifeCareRating = sessionEndLifeCareRating.Name;
                    string strOverAllAssessmentCareRating = sessionOverAllAssessmentCareRating.Name;

                    var sjrFormInitial = (NHS.Models.SJRFormInitial)Session["sJRFormInitial"];
                    string strInitialManagement = sjrFormInitial.InitialManagement;
                    string strOngoingCare = sjrFormInitial.OngoingCare;
                    string strCareDuringProcedure = sjrFormInitial.CareDuringProcedure;
                    string strEndLifeCare = sjrFormInitial.EndLifeCare;
                    string strOverAllAssessment = sjrFormInitial.OverAllAssessment;


                    var lastRecordPatientMap = ent.PatientMaps.OrderByDescending(p => p.PatientID).FirstOrDefault();
                    int lastPatientId = lastRecordPatientMap.PatientID;

                    CareRating careRating1 = new CareRating();
               
                    careRating1.Name = strInitialManagementRating;
                    careRating1.CreatedBy = "John Deo";
                    careRating1.CreateDate = DateTime.Now;
                    careRating1.UpdatedBy = "John Deo";
                    careRating1.UpdatedDate = DateTime.Now;
                    ent.CareRatings.Add(careRating1);
                    ent.SaveChanges();

                    int intInitialManagementRatingId = careRating1.CareRatingID;

                    CareRating careRating2 = new CareRating();
               
                    careRating2.Name = strOnGoingCareRating;
                    careRating2.CreatedBy = "John Deo";
                    careRating2.CreateDate = DateTime.Now;
                    careRating2.UpdatedBy = "John Deo";
                    careRating2.UpdatedDate = DateTime.Now;
                    ent.CareRatings.Add(careRating2);
                    ent.SaveChanges();

                    int intOnGoingCareRatingId = careRating2.CareRatingID;

                    CareRating careRating3 = new CareRating();
               
                    careRating3.Name = strCareDuringProcedureCareRating;
                    careRating3.CreatedBy = "John Deo";
                    careRating3.CreateDate = DateTime.Now;
                    careRating3.UpdatedBy = "John Deo";
                    careRating3.UpdatedDate = DateTime.Now;
                    ent.CareRatings.Add(careRating3);
                    ent.SaveChanges();

                    int intCareDuringProcedureCareRatingId = careRating3.CareRatingID;

                    CareRating careRating4 = new CareRating();
             
                    careRating4.Name = strEndLifeCareRating;
                    careRating4.CreatedBy = "John Deo";
                    careRating4.CreateDate = DateTime.Now;
                    careRating4.UpdatedBy = "John Deo";
                    careRating4.UpdatedDate = DateTime.Now;
                    ent.CareRatings.Add(careRating4);
                    ent.SaveChanges();

                    int intEndLifeCareRating = careRating4.CareRatingID;

                    CareRating careRating5 = new CareRating();
               
                    careRating5.Name = strOverAllAssessmentCareRating;
                    careRating5.CreatedBy = "John Deo";
                    careRating5.CreateDate = DateTime.Now;
                    careRating5.UpdatedBy = "John Deo";
                    careRating5.UpdatedDate = DateTime.Now;
                    ent.CareRatings.Add(careRating5);
                    ent.SaveChanges();

                    int intOverAllAssessmentCareRatingId = careRating5.CareRatingID;

                    SJRFormInitial sJRFormInitial = new SJRFormInitial();

                    sJRFormInitial.PatientID = lastPatientId;
                    //Stage=0 For Stage2SJRForm Only 
                    sJRFormInitial.Stage = 0;
                
                    sJRFormInitial.InitialManagement = strInitialManagement;
                    sJRFormInitial.InitialManagementCareRatingID = intInitialManagementRatingId;
                    sJRFormInitial.OngoingCare = strOngoingCare;
                    sJRFormInitial.OngoingCareRatingID = intOnGoingCareRatingId;
                    sJRFormInitial.CareDuringProcedure = strCareDuringProcedure;
                    sJRFormInitial.CareDuringProcedureCareRatingID = intCareDuringProcedureCareRatingId;
                    sJRFormInitial.EndLifeCare = strEndLifeCare;
                    sJRFormInitial.EndLifeCareRatingID = intEndLifeCareRating;
                    sJRFormInitial.OverAllAssessment = strOverAllAssessment;
                    sJRFormInitial.OverAllAssessmentCareRatingID = intOverAllAssessmentCareRatingId;
                    sJRFormInitial.CreatedBy = "John Deo";
                    sJRFormInitial.CreateDate = DateTime.Now;
                    sJRFormInitial.UpdatedBy = "John Deo";
                    sJRFormInitial.UpdatedDate = DateTime.Now;
                    ent.SJRFormInitials.Add(sJRFormInitial);
                    ent.SaveChanges();

                    CarePhase carePhase1 = new CarePhase();
                    string strAssessmentCarePhase = data["ddlAssessmentCarePhase"];
                    carePhase1.PhaseName = strAssessmentCarePhase;
                    carePhase1.CreatedBy = "John Deo";
                    carePhase1.CreateDate = DateTime.Now;
                    carePhase1.UpdatedBy = "John Deo";
                    carePhase1.UpdatedDate = DateTime.Now;
                    ent.CarePhases.Add(carePhase1);
                    ent.SaveChanges();

                    int intAssessmentCarePhaseId = carePhase1.CarePhaseID;


                    CarePhase carePhase2 = new CarePhase();
                    string strMedicationCarePhase = data["ddlMedicationCarePhase"];
                    carePhase2.PhaseName = strMedicationCarePhase;
                    carePhase2.CreatedBy = "John Deo";
                    carePhase2.CreateDate = DateTime.Now;
                    carePhase2.UpdatedBy = "John Deo";
                    carePhase2.UpdatedDate = DateTime.Now;
                    ent.CarePhases.Add(carePhase2);
                    ent.SaveChanges();

                    int intMedicationCarePhaseId = carePhase2.CarePhaseID;

                    CarePhase carePhase3 = new CarePhase();
                    string strTretmentCarePhase = data["ddlTretmentCarePhase"];
                    carePhase3.PhaseName = strTretmentCarePhase;
                    carePhase3.CreatedBy = "John Deo";
                    carePhase3.CreateDate = DateTime.Now;
                    carePhase3.UpdatedBy = "John Deo";
                    carePhase3.UpdatedDate = DateTime.Now;
                    ent.CarePhases.Add(carePhase3);
                    ent.SaveChanges();

                    int intTretmentCarePhaseId = carePhase3.CarePhaseID;

                    CarePhase carePhase4 = new CarePhase();
                    string strInfectionCarePhase = data["ddlInfectionCarePhase"];
                    carePhase4.PhaseName = strInfectionCarePhase;
                    carePhase4.CreatedBy = "John Deo";
                    carePhase4.CreateDate = DateTime.Now;
                    carePhase4.UpdatedBy = "John Deo";
                    carePhase4.UpdatedDate = DateTime.Now;
                    ent.CarePhases.Add(carePhase4);
                    ent.SaveChanges();


                    int intInfectionCarePhaseId = carePhase4.CarePhaseID;

                    CarePhase carePhase5 = new CarePhase();
                    string strProcedureCarePhaseId = data["ddlProcedureCarePhase"];
                    carePhase5.PhaseName = strProcedureCarePhaseId;
                    carePhase5.CreatedBy = "John Deo";
                    carePhase5.CreateDate = DateTime.Now;
                    carePhase5.UpdatedBy = "John Deo";
                    carePhase5.UpdatedDate = DateTime.Now;
                    ent.CarePhases.Add(carePhase5);
                    ent.SaveChanges();


                    int intProcedureCarePhaseId = carePhase5.CarePhaseID;

                    CarePhase carePhase6 = new CarePhase();
                    string strOtherTypeCarePhaseId = data["ddlOtherTypeCarePhase"];
                    carePhase6.PhaseName = strOtherTypeCarePhaseId;
                    carePhase6.CreatedBy = "John Deo";
                    carePhase6.CreateDate = DateTime.Now;
                    carePhase6.UpdatedBy = "John Deo";
                    carePhase6.UpdatedDate = DateTime.Now;
                    ent.CarePhases.Add(carePhase6);
                    ent.SaveChanges();

                    int intOtherTypeCarePhaseId = carePhase6.CarePhaseID;


                    AvoidabilityScore avoidabilityScore = new AvoidabilityScore();
                    string strAvoidabilityScore = data["ddlAvoidabilityScore"];
                    avoidabilityScore.Name = strAvoidabilityScore;
                    avoidabilityScore.CreatedBy = "John Deo";
                    avoidabilityScore.CreateDate = DateTime.Now;
                    avoidabilityScore.UpdatedBy = "John Deo";
                    avoidabilityScore.UpdatedDate = DateTime.Now;
                    ent.AvoidabilityScores.Add(avoidabilityScore);
                    ent.SaveChanges();


                    int intAvoidabilityScoreId = avoidabilityScore.AvoidabilityScoreID;

                    ResponsePT responsePT = new ResponsePT();
                    string strAssessmentResponse = data["ddlAssessmentResponse"];
                    responsePT.Response = strAssessmentResponse;
                    responsePT.CreatedBy = "John Deo";
                    responsePT.CreateDate = DateTime.Now;
                    responsePT.UpdatedBy = "John Deo";
                    responsePT.UpdatedDate = DateTime.Now;
                    ent.ResponsePTs.Add(responsePT);
                    ent.SaveChanges();

                    int intAssessmentResponseId = responsePT.ResponseID;

                    ResponsePT responsePT1 = new ResponsePT();
                    string strMedicationResponse = data["ddlMedicationResponse"];
                    responsePT1.Response = strMedicationResponse;
                    responsePT1.CreatedBy = "John Deo";
                    responsePT1.CreateDate = DateTime.Now;
                    responsePT1.UpdatedBy = "John Deo";
                    responsePT1.UpdatedDate = DateTime.Now;
                    ent.ResponsePTs.Add(responsePT1);
                    ent.SaveChanges();

                    int intMedicationResponseId = responsePT1.ResponseID;

                    ResponsePT responsePT2 = new ResponsePT();
                    string strTreatmentResponse = data["ddlTreatmentResponse"];
                    responsePT2.Response = strTreatmentResponse;
                    responsePT2.CreatedBy = "John Deo";
                    responsePT2.CreateDate = DateTime.Now;
                    responsePT2.UpdatedBy = "John Deo";
                    responsePT2.UpdatedDate = DateTime.Now;
                    ent.ResponsePTs.Add(responsePT2);
                    ent.SaveChanges();

                    int intTreatmentResponseId = responsePT2.ResponseID;

                    ResponsePT responsePT3 = new ResponsePT();
                    string strInfectionResponse = data["ddlInfectionResponse"];
                    responsePT3.Response = strInfectionResponse;
                    responsePT3.CreatedBy = "John Deo";
                    responsePT3.CreateDate = DateTime.Now;
                    responsePT3.UpdatedBy = "John Deo";
                    responsePT3.UpdatedDate = DateTime.Now;
                    ent.ResponsePTs.Add(responsePT3);
                    ent.SaveChanges();

                    int intInfectionResponseId = responsePT3.ResponseID;


                    ResponsePT responsePT4 = new ResponsePT();
                    string strProcedureResponse = data["ddlProcedureResponse"];
                    responsePT4.Response = strProcedureResponse;
                    responsePT4.CreatedBy = "John Deo";
                    responsePT4.CreateDate = DateTime.Now;
                    responsePT4.UpdatedBy = "John Deo";
                    responsePT4.UpdatedDate = DateTime.Now;
                    ent.ResponsePTs.Add(responsePT4);
                    ent.SaveChanges();

                    int intProcedureResponseId = responsePT4.ResponseID;

                    ResponsePT responsePT5 = new ResponsePT();
                    string strMonitoringResponse = data["ddlMonitoringResponse"];
                    responsePT5.Response = strMonitoringResponse;
                    responsePT5.CreatedBy = "John Deo";
                    responsePT5.CreateDate = DateTime.Now;
                    responsePT5.UpdatedBy = "John Deo";
                    responsePT5.UpdatedDate = DateTime.Now;
                    ent.ResponsePTs.Add(responsePT5);
                    ent.SaveChanges();

                    int intMonitoringResponseId = responsePT5.ResponseID;


                    ResponsePT responsePT6 = new ResponsePT();
                    string strResuscitationResponse = data["ddlResuscitationResponse"];
                    responsePT6.Response = strResuscitationResponse;
                    responsePT6.CreatedBy = "John Deo";
                    responsePT6.CreateDate = DateTime.Now;
                    responsePT6.UpdatedBy = "John Deo";
                    responsePT6.UpdatedDate = DateTime.Now;
                    ent.ResponsePTs.Add(responsePT6);
                    ent.SaveChanges();

                    int intResuscitationResponseId = responsePT6.ResponseID;


                    ResponsePT responsePT7 = new ResponsePT();
                    string strOtherTypeResponse = data["ddlOtherTypeResponse"];
                    responsePT7.Response = strOtherTypeResponse;
                    responsePT7.CreatedBy = "John Deo";
                    responsePT7.CreateDate = DateTime.Now;
                    responsePT7.UpdatedBy = "John Deo";
                    responsePT7.UpdatedDate = DateTime.Now;
                    ent.ResponsePTs.Add(responsePT7);
                    ent.SaveChanges();

                    int intOtherTypeResponseId = responsePT7.ResponseID;
                    string strSJRFormProblemTypeComments = data["taComment"];

                    SJRFormProblemType sJRFormProblemType = new SJRFormProblemType();
                    sJRFormProblemType.PatientID = lastPatientId;
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

                    ent.SJRFormProblemTypes.Add(sJRFormProblemType);
                    ent.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.Write(ex.StackTrace);
                }
            }
            return View();

        }

        public ActionResult Stage3SJRformFirstStep(FormCollection data)
        {
            return View();

        }

        public ActionResult Stage3SJRformSecondStep(FormCollection data)
        {
            return View();

        }

        public ActionResult MedExamFormStep1(FormCollection data, string BtnNext)
        {
            try
            {
                if (BtnNext != null)
                {

                    string strPatientName = data["txtPatientName"];
                    string strMRN = data["txtMRN"];
                    string strAge = data["txtAge"];
                    string strGender = data["ddlGender"];
                    string strDischargeWard = data["txtDischargeWard"];
                    string strDischargeConsultant = data["txtDischargeConsultant"];
                    string strEmergencyAdmission = data["txtEmergencyAdmission"];
                    string strDateOfAdmission = data["txtDateOfAdmission"];
                    string strTimeOfAdmission = data["txtTimeOfAdmission"];
                    string strDateOfDeath = data["txtDateOfDeath"];
                    string strTimeOfDeath = data["txtTimeOfDeath"];
                    string strPrimaryDiagnosis = data["txtPrimaryDiagnosis"];
                    string strComments = data["taComments"];

                    PatientDetail patientDetail = new PatientDetail();
                    patientDetail.PatientName = strPatientName;
                    patientDetail.MRN = strMRN;
                    patientDetail.Age = Convert.ToInt32(strAge);
                    patientDetail.Gender = Convert.ToInt32(strGender) == 1 ? true: false;
                    patientDetail.DischargeWard = strDischargeWard;
                    patientDetail.EmergencyAdmission = strEmergencyAdmission;
                    patientDetail.DateofAdmission = Convert.ToDateTime(strDateOfAdmission);
                    patientDetail.TimeofAdmission = Convert.ToDateTime(strTimeOfAdmission);
                    patientDetail.DateofDeath = Convert.ToDateTime(strDateOfDeath);
                    patientDetail.TimeofDeath = Convert.ToDateTime(strTimeOfDeath);
                    patientDetail.PrimaryDiagnosis = strPrimaryDiagnosis;
                    patientDetail.Comments = strComments;
                    Session["sessionPatientDetail"] = patientDetail;

                    DischargeConsultant dischargeConsultant = new DischargeConsultant();
                    dischargeConsultant.DischargeConsultantName = strDischargeConsultant;
                    Session["sessionDischargeConsultant"] = dischargeConsultant;

                    Response.Redirect("/Home/MedExamFormStep2");

                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            return View();
        }

        public ActionResult MedExamFormStep2(FormCollection data, string BtnNext)
        {
            try
            {
                if (BtnNext != null)
                {

                    string firstName = "";
                    string midName = "";
                    string lastName = "";

                    string strMEName = data["ddlMEName"];
                    if (strMEName != null)
                    {
                        var names = strMEName.Split(' ');
                        firstName = names[0];
                        midName = names[1];
                        lastName = names[2];
                    }

                    string strQAP = data["txtQAP"];
                    //Boolean blQAPDiscussion = data["cbQAPDiscussion"] != null  ? data["cbQAPDiscussion"]=="1"? true:false : false;
                    //Boolean blNotesReview = data["cbNotesReview"] != null ? data["cbNotesReview"] == "1" ? true : false : false;
                    //Boolean blNoK_Discussion = data["cbNoK_Discussion"] != null ? data["cbNoK_Discussion"] == "1" ? true : false : false;

                    Boolean blQAPDiscussion = data["cbQAPDiscussion"] != null ? true : false;
                    Boolean blNotesReview = data["cbNotesReview"] != null ? true : false;
                    Boolean blNoK_Discussion = data["cbNoK_Discussion"] != null ? true : false;
                    string strComment = data["taComment"];


                    MedicalExaminer medicalExaminer = new MedicalExaminer();
                    medicalExaminer.ME_FirstName = firstName;
                    medicalExaminer.ME_MiddleName = midName;
                    medicalExaminer.ME_LastName = lastName;
                    Session["sessionMedicalExaminer"] = medicalExaminer;

                    MedicalExaminerReview medicalExaminerReview = new MedicalExaminerReview();
                    medicalExaminerReview.QAP_Discussion = blQAPDiscussion;
                    medicalExaminerReview.Notes_Review = blNotesReview;
                    medicalExaminerReview.Nok_Discussion = blNoK_Discussion;
                    medicalExaminerReview.Comments = strComment;
                    Session["sessionMedicalExaminerReview"] = medicalExaminerReview;

                    Response.Redirect("/Home/MedExamFormStep3");

                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

            return View();
        }

        public ActionResult MedExamFormStep3(FormCollection data, string BtnNext)
        {
            try
            {
                if (BtnNext != null)
                {

                    string strCoronerReferralResonName = data["ddlCoronerReferralResonName"];

                    Boolean blMCCSIssue = data["cbMCCSIssue"] != null ? true : false;
                    Boolean blCoronerReferral = data["cbCoronerReferral"] != null ? true : false;
                    Boolean blHospitalPostMortem = data["cbHospitalPostMortem"] != null ? true : false;
                    string strCouseOfDeath = data["txtCouseOfDeath"];
                    Boolean blDeathCertificate = data["cbDeathCertificate"] != null ? true : false;
                    Boolean blCoronerReferralComplete = data["cbCoronerReferralComplete"] != null ? true : false;
                    Boolean blCoronerDecisionInquest = data["cbCoronerDecisionInquest"] != null ? true : false;
                    Boolean blCoronerDecisionPostMortem = data["cbCoronerDecisionPostMortem"] != null ? true : false;
                    Boolean blCoronerDecision100A = data["cbCoronerDecision100A"] != null ? true : false;
                    Boolean blCoronerDecisionGPIssue = data["cbCoronerDecisionGPIssue"] != null ? true : false;

                    CoronerReferralReason coronerReferralReason = new CoronerReferralReason();
                    coronerReferralReason.ReasonName = strCoronerReferralResonName;
                    Session["sessionCoronerReferralReason"] = coronerReferralReason;

                    MedicalExaminerDecision medicalExaminerDecision = new MedicalExaminerDecision();
                    medicalExaminerDecision.MCCDissue = blMCCSIssue;
                    medicalExaminerDecision.CornerReferral = blCoronerReferral;
                    medicalExaminerDecision.HospitalPostMortem = blHospitalPostMortem;
                    medicalExaminerDecision.CauseOfDeath = strCouseOfDeath;
                    medicalExaminerDecision.DeathCertificate = blDeathCertificate;
                    medicalExaminerDecision.CornerReferralComplete = blCoronerReferralComplete;
                    medicalExaminerDecision.CoronerDecisionInquest = blCoronerDecisionInquest;
                    medicalExaminerDecision.CoronerDecisionPostMortem = blCoronerDecisionPostMortem;
                    medicalExaminerDecision.CoronerDecision100A = blCoronerDecision100A;
                    medicalExaminerDecision.CoronerDecisionGPissue = blCoronerDecisionGPIssue;
                    Session["sessionMedicalExaminerDecision"] = medicalExaminerDecision;

                    Response.Redirect("/Home/MedExamFormStep4");

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }

            return View();
        }

        public ActionResult MedExamFormStep4(FormCollection data, string BtnNext)
        {
            try
            {
                if (BtnNext != null)
                {

                    string strSJRReviewSpecialty = data["ddlSJRReviewSpecialty"];

                    Boolean blPaediatricPatient = data["cbPaediatricPatient"] != null ? true : false;
                    Boolean blLearningDisabilityPatient = data["cbLearningDisabilityPatient"] != null ? true : false;
                    Boolean blMentalIllnessPatient = data["cbMentalIllnessPatient"] != null ? true : false;
                    Boolean blElectiveAdmission = data["cbElectiveAdmission"] != null ? true : false;
                    Boolean blNokConcernsDeath = data["cbNokConcernsDeath"] != null ? true : false;
                    Boolean blOtherConcerns = data["cbOtherConcerns"] != null ? true : false;
                    Boolean blFullSJRRequired = data["cbFullSJRRequired"] != null ? true : false;
                    Boolean blFullSJRRequiredYes = data["cbFullSJRRequiredYes"] != null ? true : false;
                    Boolean blFullSJRRequiredNo = data["cbFullSJRRequiredNo"] != null ? true : false;

                    SJRReviewSpeciality sJRReviewSpeciality = new SJRReviewSpeciality();
                    sJRReviewSpeciality.Name = strSJRReviewSpecialty;
                    Session["sessionSJRReviewSpeciality"] = sJRReviewSpeciality;

                    SJRReview sJRReview = new SJRReview();
                    sJRReview.PaediatricPatient = blPaediatricPatient;
                    sJRReview.LearningDisabilityPatient = blLearningDisabilityPatient;
                    sJRReview.MentalillnessPatient = blMentalIllnessPatient;
                    sJRReview.ElectiveAdmission = blElectiveAdmission;
                    sJRReview.NoKConcernsDeath = blNokConcernsDeath;
                    sJRReview.OtherConcern = blOtherConcerns;
                    if (blFullSJRRequiredYes == true)
                    {
                        sJRReview.FullSJRRequired = true;
                    }
                    if (blFullSJRRequiredNo == true)
                    {
                        sJRReview.FullSJRRequired = false;
                    }
                    Session["sessionSJRReview"] = sJRReview;

                    Response.Redirect("/Home/MedExamFormStep5");

                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            return View();
        }

        public ActionResult MedExamFormStep5(FormCollection data, string BtnNext)
        {
            try
            {

                if (BtnNext != null)
                {

                    Boolean blPatientSafetySIRI = data["cbPatientSafetySIRI"] != null ? true : false;
                    string strPatientSafetySIRIReason = data["txtPatientSafetySIRIReason"];
                    Boolean blChildDeathCoOrdinator = data["cbChildDeathCoOrdinator"] != null ? true : false;
                    Boolean blLearningDisabilityNurse = data["cbLearningDisabilityNurse"] != null ? true : false;
                    Boolean blHeadOfComliance = data["cbHeadOfComliance"] != null ? true : false;
                    string strHeadOfComlianceReason = data["txtHeadOfComlianceReason"];
                    Boolean blPALsComplaints = data["cbPALsComplaints"] != null ? true : false;
                    string strPALsComplaintsReason = data["txtPALsComplaintsReason"];
                    Boolean blWardTeam = data["cbWardTeam"] != null ? true : false;
                    string strWardTeamReson = data["txtWardTeamReson"];
                    Boolean blOther = data["cbOther"] != null ? true : false;
                    string strOtherReason = data["txtOtherReason"];

                    OtherReferral otherReferral = new OtherReferral();

                    otherReferral.PatientSafetySIRI = blPatientSafetySIRI;
                    otherReferral.PatientSafetySIRIReason = strPatientSafetySIRIReason;
                    otherReferral.ChildDeathCoordinator = blChildDeathCoOrdinator;
                    otherReferral.LearningDisabilityNurse = blLearningDisabilityNurse;
                    otherReferral.HeadOfCompliance = blHeadOfComliance;
                    otherReferral.HeadOfComplianceReason = strHeadOfComlianceReason;
                    otherReferral.PALsComplaints = blPALsComplaints;
                    otherReferral.PALsComplaintsReason = strPALsComplaintsReason;
                    otherReferral.WardTeam = blWardTeam;
                    otherReferral.WardTeamReason = strWardTeamReson;
                    otherReferral.Other = blOther;
                    otherReferral.OtherReason = strOtherReason;
                    Session["sessionOtherReferral"] = otherReferral;

                    Response.Redirect("/Home/MedExamFormStep6");
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            return View();
        }

        public ActionResult MedExamFormStep6(FormCollection data, string BtnPrevious, string BtnFinish)
        {
            try
            {
                if (BtnFinish != null)
                {

                    Boolean blFormCompleted = data["cbFormCompleted"] != null ? true : false;
                    Boolean blComplimentsFedBack = data["cbComplimentsFedBack"] != null ? true : false;

                    #region Save Record in Patient Details, Discharge Consultant, Patient Map Table 

                    var sessionPatientDetail = (NHS.Models.PatientDetail)Session["sessionPatientDetail"];
                    var sessionDischargeConsultant = (NHS.Models.DischargeConsultant)Session["sessionDischargeConsultant"];

                    string sessionDischargeConsultantName = sessionDischargeConsultant.DischargeConsultantName;

                    DischargeConsultant dischargeConsultant = new DischargeConsultant();
                    dischargeConsultant.DischargeConsultantName = sessionDischargeConsultantName;
                    dischargeConsultant.CreatedBy = "John Deo";
                    dischargeConsultant.CreateDate = DateTime.Now;
                    dischargeConsultant.UpdatedBy = "John Deo";
                    dischargeConsultant.UpdatedDate = DateTime.Now;
                    ent.DischargeConsultants.Add(dischargeConsultant);
                    ent.SaveChanges();

                    int intDischargeConsultantCode = dischargeConsultant.DischargeConsultantCode;

                    PatientDetail patientDetail = new PatientDetail();

                    patientDetail.PatientName = sessionPatientDetail.PatientName;
                    patientDetail.MRN = sessionPatientDetail.MRN;
                    patientDetail.Age = sessionPatientDetail.Age;
                    patientDetail.Gender = sessionPatientDetail.Gender;
                    patientDetail.DischargeWard = sessionPatientDetail.DischargeWard;
                    patientDetail.DischargeConsultantCode = intDischargeConsultantCode;
                    patientDetail.EmergencyAdmission = sessionPatientDetail.EmergencyAdmission;
                    patientDetail.DateofAdmission = sessionPatientDetail.DateofAdmission;
                    patientDetail.TimeofAdmission = sessionPatientDetail.TimeofAdmission;
                    patientDetail.DateofDeath = sessionPatientDetail.DateofDeath;
                    patientDetail.TimeofDeath = sessionPatientDetail.TimeofDeath;
                    patientDetail.PrimaryDiagnosis = sessionPatientDetail.PrimaryDiagnosis;
                    patientDetail.Comments = sessionPatientDetail.Comments;
                    patientDetail.CreatedBy = "John Deo";
                    patientDetail.CreateDate = DateTime.Now;
                    patientDetail.UpdatedBy = "John Deo";
                    patientDetail.UpdatedDate = DateTime.Now;
                    ent.PatientDetails.Add(patientDetail);
                    ent.SaveChanges();

                    int intMRN = patientDetail.PatientId;

                    PatientMap patientMap = new PatientMap();

                    patientMap.MRN = Convert.ToString(intMRN);
                    patientMap.CreatedBy = "John Deo";
                    patientMap.CreateDate = DateTime.Now;
                    patientMap.UpdatedBy = "John Deo";
                    patientMap.UpdatedDate = DateTime.Now;
                    ent.PatientMaps.Add(patientMap);
                    ent.SaveChanges();

                    #endregion

                    #region Svae Record in Medical Examiner, Medical Examiner Review Table 

                    var sessionMedicalExaminer = (NHS.Models.MedicalExaminer)Session["sessionMedicalExaminer"];
                    string sessionFirstName = sessionMedicalExaminer.ME_FirstName;
                    string sessionMidName = sessionMedicalExaminer.ME_MiddleName;
                    string sessionLastName = sessionMedicalExaminer.ME_LastName;

                    MedicalExaminer medicalExaminer = new MedicalExaminer();
                    medicalExaminer.ME_FirstName = sessionFirstName;
                    medicalExaminer.ME_MiddleName = sessionMidName;
                    medicalExaminer.ME_LastName = sessionLastName;
                    medicalExaminer.CreatedBy = "John Deo";
                    medicalExaminer.CreateDate = DateTime.Now;
                    medicalExaminer.UpdatedBy = "John Deo";
                    medicalExaminer.UpdatedDate = DateTime.Now;
                    ent.MedicalExaminers.Add(medicalExaminer);
                    ent.SaveChanges();

                    int intMEID = medicalExaminer.ME_ID;


                    var sessionMedicalExaminerReview = (NHS.Models.MedicalExaminerReview)Session["sessionMedicalExaminerReview"];

                    MedicalExaminerReview medicalExaminerReview = new MedicalExaminerReview();
                    medicalExaminerReview.PatientID = intMRN;
                    medicalExaminerReview.ME_ID = intMEID;
                    medicalExaminerReview.QAP_Discussion = sessionMedicalExaminerReview.QAP_Discussion;
                    medicalExaminerReview.Notes_Review = sessionMedicalExaminerReview.Notes_Review;
                    medicalExaminerReview.Nok_Discussion = sessionMedicalExaminerReview.Nok_Discussion;
                    medicalExaminerReview.Comments = sessionMedicalExaminerReview.Comments;
                    medicalExaminerReview.CreatedBy = "John Deo";
                    medicalExaminerReview.CreateDate = DateTime.Now;
                    medicalExaminerReview.UpdatedBy = "John Deo";
                    medicalExaminerReview.UpdatedDate = DateTime.Now;
                    ent.MedicalExaminerReviews.Add(medicalExaminerReview);
                    ent.SaveChanges();

                    #endregion


                    #region Save Record in CoronerReferralReson, MedicalExaminerDecision Table

                    var sessionCoronerReferralReason = (NHS.Models.CoronerReferralReason)Session["sessionCoronerReferralReason"];

                    CoronerReferralReason coronerReferralReason = new CoronerReferralReason();
                    coronerReferralReason.ReasonName = sessionCoronerReferralReason.ReasonName;
                    ent.CoronerReferralReasons.Add(coronerReferralReason);
                    ent.SaveChanges();

                    int intCoronerReferralReasonsId = coronerReferralReason.Reason_ID;

                    var sessionMedicalExaminerDecision = (NHS.Models.MedicalExaminerDecision)Session["sessionMedicalExaminerDecision"];

                    MedicalExaminerDecision medicalExaminerDecision = new MedicalExaminerDecision();
                    medicalExaminerDecision.PatientID =intMRN;
                    medicalExaminerDecision.MCCDissue = sessionMedicalExaminerDecision.MCCDissue;
                    medicalExaminerDecision.CornerReferral = sessionMedicalExaminerDecision.CornerReferral;
                    medicalExaminerDecision.HospitalPostMortem = sessionMedicalExaminerDecision.HospitalPostMortem;
                    medicalExaminerDecision.CoronerReferralReasonID = intCoronerReferralReasonsId;
                    medicalExaminerDecision.CauseOfDeath = sessionMedicalExaminerDecision.CauseOfDeath;
                    medicalExaminerDecision.DeathCertificate = sessionMedicalExaminerDecision.DeathCertificate;
                    medicalExaminerDecision.CornerReferralComplete = sessionMedicalExaminerDecision.CornerReferralComplete;
                    medicalExaminerDecision.CoronerDecisionInquest = sessionMedicalExaminerDecision.CoronerDecisionInquest;
                    medicalExaminerDecision.CoronerDecision100A = sessionMedicalExaminerDecision.CoronerDecision100A;
                    medicalExaminerDecision.CoronerDecisionPostMortem = sessionMedicalExaminerDecision.CoronerDecisionPostMortem;
                    medicalExaminerDecision.CoronerDecisionGPissue = sessionMedicalExaminerDecision.CoronerDecisionGPissue;
                    medicalExaminerDecision.CreatedBy = "John Deo";
                    medicalExaminerDecision.CreateDate = DateTime.Now;
                    medicalExaminerDecision.UpdatedBy = "John Deo";
                    medicalExaminerDecision.UpdatedDate = DateTime.Now;
                    ent.MedicalExaminerDecisions.Add(medicalExaminerDecision);
                    ent.SaveChanges();

                    #endregion

                    #region Save Record in SJRReviewSpeciality and SJRReview

                    var sessionSJRReviewSpeciality = (NHS.Models.SJRReviewSpeciality)Session["sessionSJRReviewSpeciality"];

                    SJRReviewSpeciality sJRReviewSpeciality = new SJRReviewSpeciality();
                    sJRReviewSpeciality.Name = sessionSJRReviewSpeciality.Name;
                    sJRReviewSpeciality.CreatedBy = "John Deo";
                    sJRReviewSpeciality.CreateDate = DateTime.Now;
                    sJRReviewSpeciality.UpdatedBy = "John Deo";
                    sJRReviewSpeciality.UpdatedDate = DateTime.Now;
                    ent.SJRReviewSpecialities.Add(sJRReviewSpeciality);
                    ent.SaveChanges();

                    int intSJRReviewSpecialityId = sJRReviewSpeciality.SJRReviewSpecialityID;

                    var sessionSJRReview = (NHS.Models.SJRReview)Session["sessionSJRReview"];

                    SJRReview sJRReview = new SJRReview();
                    sJRReview.PatientID = intMRN;
                    sJRReview.PaediatricPatient = sessionSJRReview.PaediatricPatient;
                    sJRReview.LearningDisabilityPatient = sessionSJRReview.LearningDisabilityPatient;
                    sJRReview.MentalillnessPatient = sessionSJRReview.MentalillnessPatient;
                    sJRReview.ElectiveAdmission = sessionSJRReview.ElectiveAdmission;
                    sJRReview.NoKConcernsDeath = sessionSJRReview.NoKConcernsDeath;
                    sJRReview.OtherConcern = sessionSJRReview.OtherConcern;
                    sJRReview.FullSJRRequired = sessionSJRReview.FullSJRRequired;
                    sJRReview.SJRReviewSpecialityID = intSJRReviewSpecialityId;
                    sJRReview.CreatedBy = "John Deo";
                    sJRReview.CreateDate = DateTime.Now;
                    sJRReview.UpdatedBy = "John Deo";
                    sJRReview.UpdatedDate = DateTime.Now;
                    ent.SJRReviews.Add(sJRReview);
                    ent.SaveChanges();

                    #endregion

                    #region Save Record in OtherReferral Table 

                    var sessionOtherReferral = (NHS.Models.OtherReferral)Session["sessionOtherReferral"];

                    OtherReferral otherReferral = new OtherReferral();

                    otherReferral.PatientID = intMRN;
                    otherReferral.PatientSafetySIRI = sessionOtherReferral.PatientSafetySIRI;
                    otherReferral.PatientSafetySIRIReason = sessionOtherReferral.PatientSafetySIRIReason;
                    otherReferral.ChildDeathCoordinator = sessionOtherReferral.ChildDeathCoordinator;
                    otherReferral.LearningDisabilityNurse = sessionOtherReferral.LearningDisabilityNurse;
                    otherReferral.HeadOfCompliance = sessionOtherReferral.HeadOfCompliance;
                    otherReferral.HeadOfComplianceReason = sessionOtherReferral.HeadOfComplianceReason;
                    otherReferral.PALsComplaints = sessionOtherReferral.PALsComplaints;
                    otherReferral.PALsComplaintsReason = sessionOtherReferral.PALsComplaintsReason;
                    otherReferral.WardTeam = sessionOtherReferral.WardTeam;
                    otherReferral.WardTeamReason = sessionOtherReferral.WardTeamReason;
                    otherReferral.Other = sessionOtherReferral.Other;
                    otherReferral.OtherReason = sessionOtherReferral.OtherReason;
                    otherReferral.CreatedBy = "John Deo";
                    otherReferral.CreateDate = DateTime.Now;
                    otherReferral.UpdatedBy = "John Deo";
                    otherReferral.UpdatedDate = DateTime.Now;
                    ent.OtherReferrals.Add(otherReferral);
                    ent.SaveChanges();

                    #endregion

                    FeedBack feedBack = new FeedBack();
                    feedBack.PatientID =intMRN;
                    feedBack.FormCompleted = blFormCompleted;
                    feedBack.ComplementsFedBack = blComplimentsFedBack;
                    feedBack.CreatedBy = "John Deo";
                    feedBack.CreateDate = DateTime.Now;
                    feedBack.UpdatedBy = "John Deo";
                    feedBack.UpdatedDate = DateTime.Now;
                    ent.FeedBacks.Add(feedBack);
                    ent.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
            }
            return View();
        }
 
        public ActionResult MedicalExaminerDashboard()
        {
            return View();
        }
        public ActionResult CORSPatient(string Id, string PName, string DOB)
        {
            ViewBag.Id = Id;
            ViewBag.Name = PName;
            ViewBag.DOB = DOB;

            return View();
        }
    }
}
