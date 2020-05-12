using System;
using System.Collections.Generic;

namespace InspectionProject.Models
{
    public class InspectionRecordModel
    {
        public int RecordID { get; set; }

        public string RecordedBy { get; set; }

        public DateTime DatePerformed { get; set; }
    }

    public class InspectionRecordsViewModel
    {
        public List<InspectionRecordModel> InspectionRecords { get; set; }
    }

    public class CheckListItemModel
    {
        public int ItemID { get; set; }

        public int InspectionRecordID { get; set; }

        public int CheckListItemID { get; set; }

        public bool CheckStatus { get; set; }
    }

    public class ViewRecordDetailsViewModel
    {
        public int RecordID { get; set; }

        public List<CheckListItemModel> CheckListItems { get; set; }
    }
}