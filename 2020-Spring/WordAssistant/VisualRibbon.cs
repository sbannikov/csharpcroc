using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

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
    }
}
