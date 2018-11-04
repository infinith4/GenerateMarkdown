using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerateMarkdown.Models;

namespace GenerateMarkdown.Utils
{
    public class MarkdownTableUtil
    {
        public static string ConvertCsvToMarkdown(List<TestResultModel.ReadCsvModel> readCsvModelList)
        {
            var markdownTableStr = CreateHeaderStr();
            for (var i = 0; i < readCsvModelList.Count(); i++)
            {
                markdownTableStr += "| ";
                markdownTableStr += $"{readCsvModelList.ElementAt(i).TestNo} | ";
                markdownTableStr += $"{readCsvModelList.ElementAt(i).TestMethodName} | ";
                markdownTableStr += $"{readCsvModelList.ElementAt(i).ContentsOfCheck} | ";
                markdownTableStr += $"{readCsvModelList.ElementAt(i).RemarksOfCheck} | ";
                markdownTableStr += $"{readCsvModelList.ElementAt(i).RequestUrl} | ";
                markdownTableStr += $"{readCsvModelList.ElementAt(i).RequestJson} | ";
                markdownTableStr += $"{readCsvModelList.ElementAt(i).HttpStatusCode} | ";
                markdownTableStr += $"{readCsvModelList.ElementAt(i).ResponseJson} | ";
                markdownTableStr += $"{readCsvModelList.ElementAt(i).IsTestOK} | ";
                markdownTableStr += $"{readCsvModelList.ElementAt(i).RemarksOfResult} | ";
                markdownTableStr += Environment.NewLine;
            }

            return markdownTableStr;
        }

        public static string CreateHeaderStr()
        {
            var markdownTableStr = string.Empty;
            //var csvModelMap = new TestResultModel.ReadCsvModel();
            //var type = typeof(TestResultModel.ReadCsvModel);
            //var attributeCount = 0;
            //foreach (var property in type.GetProperties())
            //{
            //    attributeCount += property.GetCustomAttributes(false).Length;
            //}

            var map = new TestResultModel.ReadCsvModelMap();
            markdownTableStr += "| ";
            for (var i = 0; i < map.MemberMaps.Count(); i++)
            {
                markdownTableStr += $"{map.MemberMaps.ElementAt(i).Data.Names[0]} | ";
            }

            markdownTableStr += Environment.NewLine;
            markdownTableStr += "| ";
            for (var i = 0; i < map.MemberMaps.Count(); i++)
            {
                markdownTableStr += $"---- | ";
            }
            markdownTableStr += Environment.NewLine;

            return markdownTableStr;
        }
    }
}
