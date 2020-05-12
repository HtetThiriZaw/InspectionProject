using InspectionProject.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;

namespace InspectionProject.SQL
{
    public static class RecordSQL
    {
        readonly static string databaseName = ConfigurationManager.AppSettings["sql_database_name"];
        
        public static List<InspectionRecordModel> GetInspectionRecords()
        {
            List<InspectionRecordModel> records = new List<InspectionRecordModel>();

            BaseSQL baseSQL = new BaseSQL();
            using (MySqlConnection con = new MySqlConnection(baseSQL.ConnStr(databaseName)))
            {
                string query = "SELECT * FROM InspectionRecords";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    con.Open();

                    using(MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            InspectionRecordModel record = new InspectionRecordModel
                            {
                                RecordID = sdr.GetInt16(sdr.GetOrdinal("RecordID")),
                                RecordedBy = sdr.GetString(sdr.GetOrdinal("RecordBy")),
                                DatePerformed = sdr.GetDateTime(sdr.GetOrdinal("DatePerformed"))
                            };

                            records.Add(record);
                        }
                    }

                    con.Close();
                }
            }

            return records;
        }

        public static List<CheckListItemModel> GetInspectionRecordDetails(int recordID)
        {
            List<CheckListItemModel> items = new List<CheckListItemModel>();

            BaseSQL baseSQL = new BaseSQL();
            using (MySqlConnection con = new MySqlConnection(baseSQL.ConnStr(databaseName)))
            {
                string query = "SELECT * FROM InspectionRecordCheckLists " +
                               "WHERE InspectionRecordID = @recordID";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@recordID", recordID);

                    con.Open();

                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            CheckListItemModel item = new CheckListItemModel
                            {
                                ItemID = sdr.GetInt16(sdr.GetOrdinal("ItemID")),
                                InspectionRecordID = sdr.GetInt16(sdr.GetOrdinal("InspectionRecordID")),
                                CheckListItemID = sdr.GetInt16(sdr.GetOrdinal("CheckListItemID")),
                                CheckStatus = sdr.GetBoolean(sdr.GetOrdinal("CheckStatus")),
                            };

                            items.Add(item);
                        }
                    }

                    con.Close();
                }
            }

            return items;
        }
    }
}