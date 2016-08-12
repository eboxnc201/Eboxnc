using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Fasterflect;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using HtmlAgilityPack;
using NPOI.XSSF.UserModel;



namespace AttendanceTools
{
    public class ExcelHelper
    {
        public static byte[] ToExcelDataFromList<T>(string fileName, List<T> list, List<string> topHeader, List<string> excludeNames)
        {

            var wBook = new NPOI.HSSF.UserModel.HSSFWorkbook();
            var wSheet = wBook.CreateSheet(fileName);
            var type = typeof(T);
            var propertys = type.GetProperties(Flags.Public | Flags.Instance);
            var headerDic = new Dictionary<int, Tuple<string, string, string>>();

            //获取 导出表格列头的中午名和属性名映射以及排序关系
            foreach (var p in propertys)
            {
                if (p.HasAttribute<ExportAttribute>())
                {
                    var attr = p.Attribute<ExportAttribute>();
                    if (excludeNames != null && excludeNames.Contains(attr.Name))
                        continue;
                    headerDic.Add(attr.Index, new Tuple<string, string, string>(p.Name, attr.Name, attr.CommentSource));
                }
            }
            headerDic = (from entry in headerDic
                         orderby entry.Key ascending
                         select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
            //列头部分
            NPOI.SS.UserModel.IRow headeRow = wSheet.CreateRow(0);
            var columnIndex = 0;
            foreach (KeyValuePair<int, Tuple<string, string, string>> dic in headerDic)
            {
                headeRow.CreateCell(columnIndex).SetCellValue(dic.Value.Item2);
                columnIndex++;
            }
            //如果有统计头添加一行
            if (topHeader != null)
            {
                NPOI.SS.UserModel.IRow statisticaRow = wSheet.CreateRow(1);
                int cellcount = 0;

                foreach (var item in topHeader)
                {
                    if (item != null)
                    {
                        statisticaRow.CreateCell(cellcount).SetCellValue(item);
                    }
                    cellcount++;
                }
            }

            //数据部分
            var rowCount = 1;
            if (topHeader != null)
            {
                rowCount = 2;
            }
            foreach (var l in list)
            {
                if (l == null)
                    continue;
                NPOI.SS.UserModel.IRow wRow = wSheet.CreateRow(rowCount);
                columnIndex = 0;
                foreach (KeyValuePair<int, Tuple<string, string, string>> dic in headerDic)
                {
                    PropertyInfo propertyInfo = type.GetProperty(dic.Value.Item1);
                    var value = propertyInfo.GetValue(l, null);
                    ICell cell = null;
                    switch (propertyInfo.PropertyType.Name)
                    {
                        case "Int32":
                        case "Double":
                            if (value != null)
                            {
                                Double dvalue = Convert.ToDouble(value);
                                cell = wRow.CreateCell(columnIndex);
                                cell.SetCellValue(dvalue);
                            }
                            break;
                        default:
                            string svalue = string.Empty;
                            if (value != null)
                            {
                                svalue = value.ToString();
                                cell = wRow.CreateCell(columnIndex);
                                cell.SetCellValue(svalue);
                            }
                            break;
                    }

                    if (!string.IsNullOrEmpty(dic.Value.Item3) && cell != null)
                    {
                        PropertyInfo commentpropertyInfo = type.GetProperty(dic.Value.Item3);
                        var comment = commentpropertyInfo.GetValue(l, null).ToString();
                        if (!string.IsNullOrEmpty(comment))
                        {
                            var patr = wSheet.CreateDrawingPatriarch();
                            var comment1 = patr.CreateCellComment(new HSSFClientAnchor(0, 0, 0, 0, 1, 2, 4, 4));
                            comment1.String = new HSSFRichTextString(comment.ToString());
                            comment1.Author = "eboxnc";
                            cell.CellComment = comment1;
                        }
                    }
                    columnIndex++;
                }
                rowCount++;
            }
            // 写入到客户端 
            var ms = new System.IO.MemoryStream();
            wBook.Write(ms);
            wBook = null;
            ms.Close();
            ms.Dispose();
            byte[] fileContents = ms.ToArray();
            return fileContents;
        }

        public static byte[] ToExcelDataFromDataTable(string fileName, DataTable tb)
        {


            var wBook = new NPOI.HSSF.UserModel.HSSFWorkbook();
            var wSheet = wBook.CreateSheet(fileName);
            var headerDic = new Dictionary<int, string>();
            List<string> propertys = new List<string>();
            for (int i = 0; i < tb.Columns.Count; i++)
            {
                propertys.Add(tb.Columns[i].ColumnName);

            }
            //获取 导出Table的列名
            int index = 0;
            foreach (var p in propertys)
            {
                headerDic.Add(index, p.ToString());
                index++;
            }
            headerDic = (from entry in headerDic
                         orderby entry.Key ascending
                         select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
            //列头部分
            NPOI.SS.UserModel.IRow headeRow = wSheet.CreateRow(0);
            foreach (KeyValuePair<int, string> dic in headerDic)
            {
                headeRow.CreateCell(dic.Key).SetCellValue(dic.Value);
            }
            //数据部分
            var rowCount = 1;
            foreach (DataRow l in tb.Rows)
            {
                NPOI.SS.UserModel.IRow wRow = wSheet.CreateRow(rowCount);
                foreach (KeyValuePair<int, string> dic in headerDic)
                {
                    string cvalue = l[dic.Value].ToString();
                    wRow.CreateCell(dic.Key).SetCellValue(cvalue);
                }
                rowCount++;
            }
            // 写入到客户端 
            var ms = new System.IO.MemoryStream();
            wBook.Write(ms);
            wBook = null;
            ms.Close();
            ms.Dispose();
            byte[] fileContents = ms.ToArray();
            return fileContents;
        }

        /// <summary>
        /// 分析html 字符串 返回 dataTable
        /// </summary>
        /// <param name="htmlText"></param>
        /// <returns></returns>
        public static DataTable GetDataTableByHtml(string htmlText)
        {
            var dt = new DataTable();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlText);
            HtmlNode rootNode = doc.DocumentNode;
            HtmlNode tableNode = rootNode.SelectSingleNode("//table");
            if (tableNode != null)
            {
                var outerNode = HtmlNode.CreateNode(tableNode.OuterHtml);
                var theadNode = outerNode.SelectSingleNode("//thead/tr");
                var trNodeList = outerNode.SelectNodes("//tbody/tr");
                if (theadNode != null)
                {
                    var thNodeList = theadNode.SelectNodes("th");
                    foreach (HtmlNode th in thNodeList)
                    {
                        dt.Columns.Add(th.InnerText, typeof(string));
                    }
                }
                foreach (HtmlNode tr in trNodeList)
                {
                    var row = dt.NewRow();
                    var tdNodeList = tr.SelectNodes("td");
                    if (tdNodeList == null)
                    {
                        tdNodeList = tr.SelectNodes("th");
                    }
                    if (tdNodeList == null)
                    {
                        continue;
                    }
                    var columnIndex = 0;
                    foreach (HtmlNode td in tdNodeList)
                    {
                        row[columnIndex] = td.InnerText;
                        columnIndex++;
                    }
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }

        public static DataTable ImportExcelFile(string filePath)
        {
            HSSFWorkbook workbook;
            #region//初始化信息
            try
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    workbook = new HSSFWorkbook(file);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            #endregion

            NPOI.SS.UserModel.ISheet sheet = workbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
            DataTable dt = new DataTable();
            rows.MoveNext();

            HSSFRow row = (HSSFRow)rows.Current;
            for (int j = 0; j < (sheet.GetRow(0).LastCellNum); j++)
            {
                //dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
                //将第一列作为列表头
                dt.Columns.Add(row.GetCell(j).ToString());
            }
            while (rows.MoveNext())
            {
                row = (HSSFRow)rows.Current;
                DataRow dr = dt.NewRow();
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    NPOI.SS.UserModel.ICell cell = row.GetCell(i);
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        /// <summary>
        /// 从excle导入到数据集，excle中的工作表对应dataset中的table，工作表名和列名分别对应table中的表名和列名
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataSet ExcelToDataSet(string path)
        {
            DataSet ds = new DataSet();
            IWorkbook wb = WorkbookFactory.Create(path);
            for (int sheetIndex = 0; sheetIndex < wb.Count; sheetIndex++)
            {
                ISheet sheet = wb.GetSheetAt(sheetIndex);
                DataTable dt = new DataTable(sheet.SheetName);

                //添加列
                int columnCount = sheet.GetRow(0).PhysicalNumberOfCells;
                for (int i = 0; i < columnCount; i++)
                    dt.Columns.Add(sheet.GetRow(0).GetCell(i).StringCellValue);

                //添加行,从索引为1的行开始
                int rowsCount = sheet.PhysicalNumberOfRows;
                for (int i = 1; i < rowsCount; i++)
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                        dr.SetField(j, sheet.GetRow(i).GetCell(j).StringCellValue);
                    dt.Rows.Add(dr);
                }
                ds.Tables.Add(dt);
            }
            return ds;
        }
    }
}
