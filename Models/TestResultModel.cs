using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace GenerateMarkdown.Models
{
    public class TestResultModel
    {
        public string EnvironmentId;  //テスト環境ID (develop, staging, production)

        public class CsvModel
        {
            public int TestNo;  //テスト番号

            public string TestMethodName;  //テストメソッド名

            public string ContentsOfCheck;  //テスト内容

            public string RemarksOfCheck;  //備考(テスト内容に対する)

            public string RequestUrl;  //リクエストURL

            public string RequestJson;  //リクエストパラメータ

            public string HttpStatusCode;  //Http Status Code

            public string ResponseJson;  //レスポンスパラメータ

            public bool IsTestOK = false;  //テスト結果(true or false)

            public string RemarksOfResult;  //備考(テスト結果に対する)
        }

        public class ReadCsvModel
        {
            public string TestNo;  //テスト番号

            public string TestMethodName;  //テストメソッド名

            public string ContentsOfCheck;  //テスト内容

            public string RemarksOfCheck;  //備考(テスト内容に対する)

            public string RequestUrl;  //リクエストURL

            public string RequestJson;  //リクエストパラメータ

            public string HttpStatusCode;  //Http Status Code

            public string ResponseJson;  //レスポンスパラメータ

            public string IsTestOK;  //テスト結果(true or false)

            public string RemarksOfResult;  //備考(テスト結果に対する)
        }
        public sealed class ReadCsvModelMap : ClassMap<ReadCsvModel>
        {
            public ReadCsvModelMap()
            {
                this.Map(m => m.TestNo).Name("テスト番号").Index(0);
                this.Map(m => m.TestMethodName).Name("テストメソッド名").Index(1);
                this.Map(m => m.ContentsOfCheck).Name("テスト内容").Index(2);
                this.Map(m => m.RemarksOfCheck).Name("備考(テスト内容に対する)").Index(3);
                this.Map(m => m.RequestUrl).Name("リクエストURL").Index(4);
                this.Map(m => m.RequestJson).Name("リクエストパラメータ").Index(5);
                this.Map(m => m.HttpStatusCode).Name("Http Status Code").Index(6);
                this.Map(m => m.ResponseJson).Name("レスポンスパラメータ").Index(7);
                this.Map(m => m.IsTestOK).Name("テスト結果(true or false)").Index(8);
                this.Map(m => m.RemarksOfResult).Name("備考(テスト結果に対する)").Index(9);
            }
        }

        public sealed class CsvModelMap : ClassMap<CsvModel>
        {
            public CsvModelMap()
            {
                this.Map(m => m.TestNo).Name("テスト番号");
                this.Map(m => m.TestMethodName).Name("テストメソッド名");
                this.Map(m => m.ContentsOfCheck).Name("テスト内容");
                this.Map(m => m.RemarksOfCheck).Name("備考(テスト内容に対する)");
                this.Map(m => m.RequestUrl).Name("リクエストURL");
                this.Map(m => m.RequestJson).Name("リクエストパラメータ");
                this.Map(m => m.HttpStatusCode).Name("Http Status Code");
                this.Map(m => m.ResponseJson).Name("レスポンスパラメータ");
                this.Map(m => m.IsTestOK).Name("テスト結果(true or false)");
                this.Map(m => m.RemarksOfResult).Name("備考(テスト結果に対する)");
            }
        }
    }
}
