using OfficeOpenXml;
using TestFrameWorkCore.Model;

namespace TestFrameWorkCore.Helper
{
    public class ExcelHelper
    {
        private string filepath;

        public ExcelHelper(string _filepath)
        {
            this.filepath = _filepath;
        }
 
        public List<object[]> GetLoginUserData()
        {
            var result = new List<object[]>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(filepath))
            {
                var workSheet = package.Workbook.Worksheets.FirstOrDefault();
                var table = workSheet.Tables.FirstOrDefault();
                var totalColumn = table.Range.Columns;
                var totalRow = table.Range.Rows;
                for (var i = 2; i <= totalRow; i++)
                {
                    result.Add(new object[] { workSheet.Cells[i, 1].Value.ToString(),
                                             workSheet.Cells[i, 2].Value.ToString(),
                                             bool.Parse(workSheet.Cells[i, 3].Value.ToString()) });
                }
            }
            return result;
        }
        public List<KeyWordData> GetKeyWordData()
        {
            var keywords = new List<KeyWordData>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(filepath))
            {
                var workSheet = package.Workbook.Worksheets.FirstOrDefault();
                var table = workSheet.Tables.FirstOrDefault();
                var totalColumn = table.Range.Columns;
                var totalRow = table.Range.Rows;
                for (var i = 2; i <= totalRow; i++)
                {
                    var keyword = workSheet.Cells[i, 1].Value.ToString();
                    var data = workSheet.Cells[i, 2].Value?.ToString();

                    keywords.Add(new KeyWordData
                    {
                        Keyword = keyword,
                        Data = data
                    });
                }

                return keywords;
            }
        }
    }
}
