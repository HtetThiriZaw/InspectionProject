using InspectionProject.Helpers;
using InspectionProject.Models;
using InspectionProject.SQL;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InspectionProject.Controllers
{
    public class InspectionController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (SessionHelper.Username == null)
            {
                return RedirectToAction("Login", "Account");
            }
            
            List<InspectionRecordModel> records = new List<InspectionRecordModel>();
            
            // Retrieve records from database
            records = RecordSQL.GetInspectionRecords();

            InspectionRecordsViewModel viewModel = new InspectionRecordsViewModel
            {
                InspectionRecords = records
            };
            return View(viewModel);
        }

        //public ActionResult CreateRecord()
        //{
        //    return View();
        //}

        public ActionResult ViewRecord(int recordID)
        {
            if (SessionHelper.Username == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewRecordDetailsViewModel viewModel = new ViewRecordDetailsViewModel()
            {
                RecordID = recordID,
                CheckListItems = RecordSQL.GetInspectionRecordDetails(recordID)
            };

            return View(viewModel);
        }
    }
}