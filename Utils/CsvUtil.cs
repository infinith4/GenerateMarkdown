using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using GenerateMarkdown.Models;

namespace GenerateMarkdown.Utils
{
    public class CsvUtil
    {
        public static void CsvWrite(string outputCsvFilePath, List<TestResultModel.CsvModel> testCsvModelList)
        {
            using (var streamWriter = new StreamWriter(outputCsvFilePath, true, Encoding.UTF8))
            using (var csv = new CsvWriter(streamWriter))
            {
                csv.Configuration.RegisterClassMap<TestResultModel.CsvModelMap>();
                csv.WriteHeader<TestResultModel.CsvModel>();
                csv.NextRecord();
                csv.WriteRecords(testCsvModelList);
            }
        }

        public static void CreateCsv(string outputCsvFilePath, TestResultModel.CsvModel record)
        {
            using (var streamWriter = new StreamWriter(outputCsvFilePath, true, Encoding.UTF8))
            using (var csv = new CsvWriter(streamWriter))
            {
                //csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.RegisterClassMap<TestResultModel.CsvModelMap>();
                //csv.WriteHeader<TestResultModel.CsvModelMap>();

                //csv.NextRecord();
                //logUtil.ConsoleWriteLineWithInfoLog($"records.Count: {records.Count()}; customerNumberList: {customerNumberList.Count()}")
                csv.WriteRecord(record);
                csv.NextRecord();
            }
        }

        public static List<TestResultModel.ReadCsvModel> ReadCsvFile(string csvFilePath)
        {
            using (var streamReader = new StreamReader(csvFilePath, Encoding.UTF8))
            using (var csv = new CsvReader(streamReader))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.RegisterClassMap<TestResultModel.ReadCsvModelMap>();
                //csv.Configuration.ShouldSkipRecord = false;  //カンマありの空行はカウントされるが、ただの空行はスキップされる

                var records = csv.GetRecords<TestResultModel.ReadCsvModel>();
                var csvModelList = new List<TestResultModel.ReadCsvModel>();
                foreach (var record in records)
                {
                    csvModelList.Add(record);
                }
                //for (var i = 0;i <records.Count(); i++)
                //{
                //    csvModelList.Add(records.ElementAt(i));
                //}
                return csvModelList;
            }
        }
    }
}
