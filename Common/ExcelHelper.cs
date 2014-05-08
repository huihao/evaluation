using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.POIFS;
using NPOI.Util;
using NPOI.POIFS.FileSystem;

using NPOI.SS.UserModel;
using System.Web;

namespace Maticsoft.Common
{
    public class ExcelHelper
    {
        /// <summary>
        /// DataTable导出到Excel文件
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">保存位置</param>
        public static void Export(DataTable dtSource, string strHeaderText, string strFileName)
        {
            using (MemoryStream ms = Export(dtSource, strHeaderText))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }


        /// <summary>
        /// DataTable导出到Excel
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        public static MemoryStream Export(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet();

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "VASX";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "文件作者信息"; //填加xls文件作者信息
                si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息
                si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息
                si.Comments = "作者信息"; //填加xls文件作者信息
                si.Title = "标题信息"; //填加xls文件标题信息
                si.Subject = "主题信息";//填加文件主题信息
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet();
                    }

                    #region 表头及样式
                    //{
                    //    HSSFRow headerRow = sheet.CreateRow(0);
                    //    headerRow.HeightInPoints = 25;
                    //    headerRow.CreateCell(0).SetCellValue(strHeaderText);

                    //    ICellStyle headStyle = workbook.CreateCellStyle();
                    //    headStyle.Alignment = CellHorizontalAlignment.CENTER;
                    //    HSSFFont font = workbook.CreateFont();
                    //    font.FontHeightInPoints = 20;
                    //    font.Boldweight = 700;
                    //    headStyle.SetFont(font);
                    //    headerRow.GetCell(0).CellStyle = headStyle;
                    //    sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                    //    headerRow.Dispose();
                    //}
                    #endregion


                    #region 列头及样式
                    {
                        IRow headerRow = sheet.CreateRow(0);
                        ICellStyle headStyle = workbook.CreateCellStyle();
                        //headStyle.Alignment = CellHorizontalAlignment;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                        }
                        // headerRow.Dispose();
                    }
                    #endregion

                    rowIndex = 1;
                }
                #endregion


                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    ICell newCell = dataRow.CreateCell(column.Ordinal);

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                //sheet.Dispose();
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                return ms;
            }
        }

        /// <summary>
        /// 多个DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// 
        /// <param name="strHeaderText">表头文本</param>
        public static void Export(DataTable[] dtSource, List<string> sheetNames, string strFileName)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = null;

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "AOZZO";
                workbook.DocumentSummaryInformation = dsi;
                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "Linky"; //填加xls文件作者信息
                si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息
                si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息
                si.Comments = "作者信息"; //填加xls文件作者信息
                si.Title = "标题信息"; //填加xls文件标题信息
                si.Subject = "主题信息";//填加文件主题信息
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;

            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            #region 遍历datatable

            for (int k = 0; k < dtSource.Length; k++)
            {
                sheet = workbook.CreateSheet(sheetNames[k]);
                //取得列宽
                int[] arrColWidth = new int[dtSource[k].Columns.Count];
                foreach (DataColumn item in dtSource[k].Columns)
                {
                    arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                }
                for (int i = 0; i < dtSource[k].Rows.Count; i++)
                {
                    for (int j = 0; j < dtSource[k].Columns.Count; j++)
                    {
                        int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource[k].Rows[i][j].ToString()).Length;
                        if (intTemp > arrColWidth[j])
                        {
                            arrColWidth[j] = intTemp;
                        }
                    }
                }
                int rowIndex = 0;
                foreach (DataRow row in dtSource[k].Rows)
                {
                    #region 新建表，填充表头，填充列头，样式
                    if (rowIndex == 65535 || rowIndex == 0)
                    {
                        if (rowIndex != 0)
                        {
                            sheet = workbook.CreateSheet();
                        }

                        #region 表头及样式
                        //{
                        //    HSSFRow headerRow = sheet.CreateRow(0);
                        //    headerRow.HeightInPoints = 25;
                        //    headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        //    ICellStyle headStyle = workbook.CreateCellStyle();
                        //    headStyle.Alignment = CellHorizontalAlignment.CENTER;
                        //    HSSFFont font = workbook.CreateFont();
                        //    font.FontHeightInPoints = 20;
                        //    font.Boldweight = 700;
                        //    headStyle.SetFont(font);
                        //    headerRow.GetCell(0).CellStyle = headStyle;
                        //    sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                        //    headerRow.Dispose();
                        //}
                        #endregion


                        #region 列头及样式
                        {
                            IRow headerRow = sheet.CreateRow(0);
                            ICellStyle headStyle = workbook.CreateCellStyle();
                            //headStyle.Alignment = HSSFCellStyle.ALIGN_CENTER;
                            IFont font = workbook.CreateFont();
                            font.FontHeightInPoints = 10;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);
                            foreach (DataColumn column in dtSource[k].Columns)
                            {
                                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                                //设置列宽
                                sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                            }
                            // headerRow.Dispose();
                        }
                        #endregion

                        rowIndex = 1;
                    }
                    #endregion


                    #region 填充内容
                    IRow dataRow = sheet.CreateRow(rowIndex);
                    foreach (DataColumn column in dtSource[k].Columns)
                    {
                        ICell newCell = dataRow.CreateCell(column.Ordinal);

                        string drValue = row[column].ToString();

                        switch (column.DataType.ToString())
                        {
                            case "System.String"://字符串类型
                                newCell.SetCellValue(drValue);
                                break;
                            case "System.DateTime"://日期类型
                                DateTime dateV;
                                DateTime.TryParse(drValue, out dateV);
                                newCell.SetCellValue(dateV);

                                newCell.CellStyle = dateStyle;//格式化显示
                                break;
                            case "System.Boolean"://布尔型
                                bool boolV = false;
                                bool.TryParse(drValue, out boolV);
                                newCell.SetCellValue(boolV);
                                break;
                            case "System.Int16"://整型
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                int intV = 0;
                                int.TryParse(drValue, out intV);
                                newCell.SetCellValue(intV);
                                break;
                            case "System.Decimal"://浮点型
                            case "System.Double":
                                double doubV = 0;
                                double.TryParse(drValue, out doubV);
                                newCell.SetCellValue(doubV);
                                break;
                            case "System.DBNull"://空值处理
                                newCell.SetCellValue("");
                                break;
                            default:
                                newCell.SetCellValue("");
                                break;
                        }

                    }
                    #endregion

                    rowIndex++;
                }
            }
            #endregion
            //using (MemoryStream ms = new MemoryStream())
            //{
            //    workbook.Write(ms);
            //    ms.Flush();
            //    ms.Position = 0;

            //    //sheet.Dispose();
            //    //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
            //    return ms;
            //}
            using (FileStream fs = new FileStream(strFileName, FileMode.Create))
            {
                workbook.Write(fs);
                fs.Close();
            }
        }

        /// <summary>
        /// 导出物流版Excel
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="strHeaderText"></param>
        /// <param name="strFileName"></param>
        public static void ExportWL(DataTable[] dtSource, List<string> sheetNames, string strFileName)
        {
            using (MemoryStream ms = ExportWL(dtSource, sheetNames))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }


        /// <summary>
        /// 物流DataTable导出到Excel
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        public static MemoryStream ExportWL(DataTable[] dtSource, List<string> sheetNames)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = null;

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "AOZZO";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "文件作者信息"; //填加xls文件作者信息
                si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息
                si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息
                si.Comments = "作者信息"; //填加xls文件作者信息
                si.Title = "标题信息"; //填加xls文件标题信息
                si.Subject = "主题信息";//填加文件主题信息
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");
            for (int k = 0; k < dtSource.Length; k++)
            {
                sheet = workbook.CreateSheet(sheetNames[k]);
                //取得列宽
                int[] arrColWidth = new int[dtSource[k].Columns.Count];
                foreach (DataColumn item in dtSource[k].Columns)
                {
                    arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
                }
                for (int i = 0; i < dtSource[k].Rows.Count; i++)
                {
                    for (int j = 0; j < dtSource[k].Columns.Count; j++)
                    {
                        int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource[k].Rows[i][j].ToString()).Length;
                        if (intTemp > arrColWidth[j])
                        {
                            arrColWidth[j] = intTemp;
                        }
                    }
                }
                int rowIndex = 0;
                string tempBuyerNick = "";
                int srow = 1, cnti = -1, cntj;
                foreach (DataRow row in dtSource[k].Rows)
                {
                    cnti++;
                    #region 新建表，填充表头，填充列头，样式
                    if (rowIndex == 65535 || rowIndex == 0)
                    {
                        //if (rowIndex != 0)
                        //{
                        //    sheet = workbook.CreateSheet(sheetNames[k]);
                        //}

                        #region 表头及样式
                        //{
                        //    HSSFRow headerRow = sheet.CreateRow(0);
                        //    headerRow.HeightInPoints = 25;
                        //    headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        //    ICellStyle headStyle = workbook.CreateCellStyle();
                        //    headStyle.Alignment = CellHorizontalAlignment.CENTER;
                        //    HSSFFont font = workbook.CreateFont();
                        //    font.FontHeightInPoints = 20;
                        //    font.Boldweight = 700;
                        //    headStyle.SetFont(font);
                        //    headerRow.GetCell(0).CellStyle = headStyle;
                        //    sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                        //    headerRow.Dispose();
                        //}
                        #endregion


                        #region 列头及样式
                        {
                            IRow headerRow = sheet.CreateRow(0);
                            ICellStyle headStyle = workbook.CreateCellStyle();
                            //headStyle.Alignment = HSSFCellStyle.ALIGN_CENTER;
                            IFont font = workbook.CreateFont();
                            font.FontHeightInPoints = 10;
                            font.Boldweight = 700;
                            headStyle.SetFont(font);
                            foreach (DataColumn column in dtSource[k].Columns)
                            {
                                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                                headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                                //设置列宽
                                sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);
                            }
                            // headerRow.Dispose();
                        }
                        #endregion

                        rowIndex = 1;
                    }
                    #endregion


                    #region 填充内容
                    IRow dataRow = sheet.CreateRow(rowIndex);
                    cntj = -1;
                    bool flag = false;
                    foreach (DataColumn column in dtSource[k].Columns)
                    {
                        cntj++;
                        ICell newCell = dataRow.CreateCell(column.Ordinal);
                        if (column.ColumnName == "订单总体积")
                        {
                            if (!flag)
                                continue;
                            //sheet.AddMergedRegion(new Region(srow, cntj, cnti, cntj));
                            srow = cnti++;
                        }
                        if (column.ColumnName == "买家昵称")
                        {
                            if (row[column].ToString() != tempBuyerNick)
                            {
                                flag = true;
                                tempBuyerNick = row[column].ToString();
                            }
                            else
                                flag = false;
                        }

                        string drValue = row[column].ToString();

                        switch (column.DataType.ToString())
                        {
                            case "System.String"://字符串类型
                                newCell.SetCellValue(drValue);
                                break;
                            case "System.DateTime"://日期类型
                                DateTime dateV;
                                DateTime.TryParse(drValue, out dateV);
                                newCell.SetCellValue(dateV);

                                newCell.CellStyle = dateStyle;//格式化显示
                                break;
                            case "System.Boolean"://布尔型
                                bool boolV = false;
                                bool.TryParse(drValue, out boolV);
                                newCell.SetCellValue(boolV);
                                break;
                            case "System.Int16"://整型
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                int intV = 0;
                                int.TryParse(drValue, out intV);
                                newCell.SetCellValue(intV);
                                break;
                            case "System.Decimal"://浮点型
                            case "System.Double":
                                double doubV = 0;
                                double.TryParse(drValue, out doubV);
                                newCell.SetCellValue(doubV);
                                break;
                            case "System.DBNull"://空值处理
                                newCell.SetCellValue("");
                                break;
                            default:
                                newCell.SetCellValue("");
                                break;
                        }

                    }
                    #endregion

                    rowIndex++;
                }
            }
            //sheet.AddMergedRegion(new Region(2, 2, 4, 4));
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                //sheet.Dispose();
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                return ms;
            }
        }

        /// <summary>
        /// 用于Web导出
        /// </summary>
        /// <param name="dt">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">文件名</param>
        public static void ExportByWeb(DataTable dt, string strHeaderText, string strFileName)
        {
            HttpContext curContext = HttpContext.Current;

            // 设置编码和附件格式
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));

            curContext.Response.BinaryWrite(Export(dt, strHeaderText).GetBuffer());
            curContext.Response.End();
        }

        /// <summary>读取excel
        /// 默认第一行为标头
        /// </summary>
        /// <param name="strFileName">excel文档路径</param>
        /// <strFileName></strFileName>
        /// <sheetIndex>要导入的sheet的索引</sheetIndex>
        /// <returns></returns>
        public static DataTable Import(string strFileName, int sheetIndex = 0)
        {
            DataTable dt = new DataTable();

            HSSFWorkbook hssfworkbook;

            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            ISheet sheet = hssfworkbook.GetSheetAt(sheetIndex);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                string column = cell.ToString();
                if (!string.IsNullOrEmpty(column))
                    dt.Columns.Add(column);
            }

            cellCount = dt.Columns.Count;

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row == null)
                {
                    continue;
                }
                else
                {
                    bool flag = true;
                    foreach (var item in row.Cells)
                    {
                        var str = item.ToString();
                        if (item.ToString() != string.Empty)
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (!flag)
                    {
                        DataRow dataRow = dt.NewRow();

                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            var cell = row.GetCell(j);
                            if (cell != null)
                            {
                                var getcell = row.GetCell(j).ToString();
                                dataRow[j] = getcell;
                            }
                        }

                        dt.Rows.Add(dataRow);
                    }

                }

                /*DataRow dataRow = dt.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    var cell = row.GetCell(j);
                    if (cell != null)
                    {
                        var getcell = row.GetCell(j).ToString();
                        dataRow[j] = getcell;
                    }
                }

                dt.Rows.Add(dataRow);*/
            }
            return dt;
        }

        /// <summary>读取excel中所有的sheet
        /// 
        /// </summary>
        /// <param name="strFileName">excel文档路径</param>
        /// <strFileName></strFileName>
        /// <sheetIndex>要导入的sheet的索引</sheetIndex>
        /// <returns></returns>
        public static List<DataTable> Import(string strFileName, string help, int sheetNum = 0)
        {
            DataTable dt = null;

            HSSFWorkbook hssfworkbook;

            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }

            List<DataTable> res = new List<DataTable>();

            int len = sheetNum == 0 ? hssfworkbook.NumberOfSheets : sheetNum;

            for (int x = 0; x < len; x++)
            {
                dt = new DataTable();
                ISheet sheet = hssfworkbook.GetSheetAt(x);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                IRow headerRow = sheet.GetRow(0);
                //int cellCount = headerRow.LastCellNum;

                for (int j = 0; j < 2; j++)
                {
                    ICell cell = headerRow.GetCell(j);
                    dt.Columns.Add(cell.ToString());
                }

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = dt.NewRow();

                    for (int j = 0; j < 2; j++)
                    {
                        if (row.GetCell(j) != null)
                            dataRow[j] = row.GetCell(j).ToString();
                    }

                    dt.Rows.Add(dataRow);
                }
                res.Add(dt);
            }
            return res;
        }

        /// <summary>
        /// 导出excel并保存至服务器
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filepath">保存在服务器上的路径,相对路径</param>
        /// /// <param name="columnNames">列名列表</param>
        /// <returns>返回导出的链接</returns>
        public static string ExportExcel(DataTable dt, string filepath, List<string> columnNames = null)
        {
            try
            {
                if (columnNames != null)
                {
                    SetColumnNames(dt, columnNames);
                }

                //创建文件夹
                var patch = Maticsoft.Common.FileUtil.CreateCurrentDateFolder(HttpContext.Current.Server.MapPath(filepath), DateTime.Today);
                string fileName = DateTime.Now.Ticks.ToString() + ".xls";
                //导出之前,保留一份在服务器上
                ExcelHelper.Export(dt, "", patch + fileName);
                return filepath + DateTime.Now.ToString("yyyyMM") + "/" + fileName;
            }
            catch
            {
                throw;
            }
        }

        public static DataTable SetColumnNames(DataTable dt, List<string> names)
        {
            //设置表格的列名
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (i < names.Count)
                    dt.Columns[i].ColumnName = names[i];

            }
            return dt;
        }

        /// <summary>
        /// 导出物流订单Excel
        /// </summary>
        /// <param name="dtlist"></param>
        /// <param name="filepath"></param>
        /// <param name="sheetNames"></param>
        /// <param name="sheetColumnNames"></param>
        /// <returns></returns>
        public static string ExportWLExcel(DataTable[] dtlist, string filepath, List<string> sheetNames = null, List<string> sheetColumnNames = null)
        {
            try
            {
                if (sheetColumnNames != null)
                {
                    for (int i = 0; i < sheetNames.Count; i++)
                    {
                        SetColumnNames(dtlist[i], sheetColumnNames);
                    }
                }

                //创建文件夹
                var patch = Maticsoft.Common.FileUtil.CreateCurrentDateFolder(HttpContext.Current.Server.MapPath(filepath), DateTime.Today);
                string fileName = DateTime.Now.Ticks.ToString() + ".xls";
                //导出之前,保留一份在服务器上
                ExcelHelper.ExportWL(dtlist, sheetNames, patch + fileName);
                return filepath + DateTime.Now.ToString("yyyyMM") + "/" + fileName;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 多个datatable导出excel并保存至服务器
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filepath">路径,相对路径</param>
        /// /// <param name="columnNames">列名列表</param>
        /// <returns>返回导出的链接</returns>
        public static string ExportExcel(DataTable[] dtlist, string filepath, List<string> sheetNames = null, List<string>[] sheetColumnNames = null)
        {
            try
            {
                if (sheetColumnNames != null)
                {
                    for (int i = 0; i < sheetNames.Count; i++)
                    {
                        SetColumnNames(dtlist[i], sheetColumnNames[i]);
                    }
                }

                //创建文件夹
                var patch = Maticsoft.Common.FileUtil.CreateCurrentDateFolder(HttpContext.Current.Server.MapPath(filepath), DateTime.Today);
                string fileName = DateTime.Now.Ticks.ToString() + ".xls";
                //导出之前,保留一份在服务器上
                ExcelHelper.Export(dtlist, sheetNames, patch + fileName);
                return filepath + DateTime.Now.ToString("yyyyMM") + "/" + fileName;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 多个datatable导出excel并保存至服务器
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filepath">路径,绝对路径</param>
        /// /// <param name="columnNames">列名列表</param>
        /// <returns>返回导出的链接</returns>
        public static string ExportExcel(DataTable[] dtlist, string filepath, List<string> sheetNames = null)
        {
            try
            {
                //创建文件夹
                var patch = filepath;
                string fileName = DateTime.Now.Ticks.ToString() + ".xls";
                //导出之前,保留一份在服务器上
                ExcelHelper.Export(dtlist, sheetNames, patch + fileName);
                return filepath + DateTime.Now.ToString("yyyyMM") + "/" + fileName;
            }
            catch
            {
                throw;
            }
        }
    }
}