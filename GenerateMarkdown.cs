using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GenerateMarkdown.Models;
using Markdig;

namespace GenerateMarkdown
{
    public class GenerateMarkdown
    {
        public static string CreateMarkdown(ArticleModel artilce)
        {
            var result = Markdown.ToHtml(ConvertCsvToHtmlTable(artilce.Content));
            Console.WriteLine(result);   // prints: <p>This is a text with some <em>emphasis</em></p>

            return result;
        }

        private static string ConvertCsvToHtmlTable(string csvText)
        {
            //split the CSV, assume no commas or line breaks in text
            var splitString = new List<List<string>>();
            var lineSplit = csvText.Split('\n').ToList();
            foreach (var line in lineSplit)
            {
                splitString.Add(line.Split(',').ToList());
            }

            //encode text safely, and create table
            var tableResult = "<table>";
            foreach (var splitLine in splitString)
            {
                tableResult += "<tr>";
                foreach (var splitText in splitLine)
                {
                    tableResult += "<td>" + WebUtility.HtmlEncode(splitText) + "</td>";
                }
                tableResult += "</tr>";
            }
            tableResult += "</table>";
            return tableResult;
        }
    }
}
