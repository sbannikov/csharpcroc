using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelSample
{
    public partial class MyRibbon
    {
        private void MyRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        /// <summary>
        /// Обработчик нажатия на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                Dictionary<string, int> companies = new Dictionary<string, int>();
                // Текущий открытый документ, текущий лист
                Excel.Worksheet sheet = ThisAddIn.App.ActiveSheet;
                Excel.Range cell;
                // Начинаем анализ со второй строки
                int row = 2;             
                cell = sheet.Range[$"B{row}"];
                // До первой пустой строки
                while (cell.Value != null)
                {
                    string name = cell.Value;
                    if (companies.ContainsKey(name))
                    {
                        // Просто увеличиваем счетчик
                        companies[name]++;
                    }
                    else
                    {
                        // Добавляем новую строку в словарь
                        companies.Add(name, 1);
                    }
                    row++;
                    cell = sheet.Range[$"B{row}"];
                }
                // Заполнение выходного списка
                Excel.Worksheet result = ThisAddIn.App.ActiveWorkbook.Worksheets["Лист2"];
                row = 1;
                foreach (var kvp in companies)
                {
                    result.Range[$"A{row}"].Value = kvp.Key;
                    result.Range[$"B{row}"].Value = kvp.Value;
                    row++;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
