using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Word;

namespace WordAssistant
{
    public partial class VisualRibbon
    {
        private void VisualRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        /// <summary>
        /// Обработчик кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFields_Click(object sender, RibbonControlEventArgs e)
        {
            // Создание формы
            using (var form = new FieldForm())
            {
                // Показать форму как диалоговое окно
                form.ShowDialog();
            }
        }

        /// <summary>
        /// Выравнивание таблиц текущего документа или выделения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTables_Click(object sender, RibbonControlEventArgs e)
        {
            // Текущее выделение
            Selection s = ThisAddIn.App.Selection;
            // Список таблиц
            Tables tables = (s.Start == s.End) ? ThisAddIn.App.ActiveDocument.Tables : s.Tables;
            // Обработка таблиц
            foreach (Table t in tables)
            {
                t.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitWindow);
            }
        }
    }
}
