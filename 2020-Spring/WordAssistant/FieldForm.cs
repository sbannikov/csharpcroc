using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace WordAssistant
{
    public partial class FieldForm : Form
    {
        public FieldForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FieldForm_Load(object sender, EventArgs e)
        {
            // Инициализация списка документов
            foreach (Document doc in ThisAddIn.App.Documents)
            {
                comboDoc1.Items.Add(new ListItem<Document>(doc));
                comboDoc2.Items.Add(new ListItem<Document>(doc));
            }
            // Связь выпадающих списков со списками полей
            comboDoc1.Tag = listFields1;
            comboDoc2.Tag = listFields2;
        }

        /// <summary>
        /// Изменение выбранного элемента списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Явное приведение типа
            ComboBox box = (ComboBox)sender;
            ListBox list = (ListBox)box.Tag;

            // Проверка на наличие выбранного элемента
            if (box.SelectedItem != null)
            {
                // Текущий выбранный документ
                var item = (ListItem<Document>)box.SelectedItem;

                // Предварительная очистка списка
                list.Items.Clear();

                // Обработка всех свойств документа
                foreach (Microsoft.Office.Core.DocumentProperty p in item.Item.CustomDocumentProperties)
                {
                    // Добавить свойство в список
                    list.Items.Add(new ListItem<Microsoft.Office.Core.DocumentProperty>(p));
                }
            }
        }

        /// <summary>
        /// Копирование свойств из документа в документ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRight_Click(object sender, EventArgs e)
        {
            // Документ-приемник
            ListItem<Document> doc2 = (ListItem<Document>)comboDoc2.SelectedItem;
            // Список свойств документа-приемника
            Microsoft.Office.Core.DocumentProperties props = doc2.Item.CustomDocumentProperties;

            // Обработка только выбранных полей
            foreach (ListItem<Microsoft.Office.Core.DocumentProperty> item in listFields1.CheckedItems)
            {
                try
                {
                    // Копирование свойства
                    props.Add(item.Item.Name, item.Item.LinkToContent, item.Item.Type, item.Item.Value);
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    if (ex.ErrorCode == -2147467259)
                    {
                        // Свойство уже существует, повторное добавление невозможно
                        switch (MessageBox.Show($"Свойство '{item.Item.Name}' уже существует. Перезаписать?", "Копирование свойств", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            case DialogResult.Yes:
                                // [!] надо перезаписать свойство, но я пока не знаю как это сделать
                                break;

                            case DialogResult.No:
                                // Намеренно ничего не делаем
                                break;

                            case DialogResult.Cancel:
                                return;

                            default:
                                throw new Exception("Ну так не бывает!");
                        }
                    }
                    else
                    {
                        throw ex;
                    }
                }
                
            }

            // Обновление списка
            comboDoc_SelectedIndexChanged(comboDoc2, null);
        }
    }
}
