using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acronym
{
    public partial class MainForm : Form
    {
        private AcronymList list;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка списка сокращений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonLoad_Click(object sender, EventArgs e)
        {
            list = AcronymList.Load("http://www.orioner.ru/croc/AcronymList.xml");
        }

        /// <summary>
        /// Обработать документ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonText_Click(object sender, EventArgs e)
        {
            // Демонстрация использования инициализатора при создании объекта
            OpenFileDialog dialog = new OpenFileDialog()
            {
                DefaultExt = "txt",
                Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*",
                CheckFileExists = true,
                CheckPathExists = true
            };
            // Проверка на отмену выбора файла
            if (dialog.ShowDialog() != DialogResult.OK) return;

            // Имя файла, который надо обработать
            string name = dialog.FileName;

            // Чтение файла в массив строк
            string[] text = System.IO.File.ReadAllLines(name, Encoding.Default);

            // Обработка текста построчно
            foreach (string s in text)
            {
                // Поиск по регулярному выражению
                // сначала прописная буква, потом хотя бы одна прописная буква или цифра
                MatchCollection c = Regex.Matches(s, "[A-ZА-Я][A-ZА-Я0-9]+");
                // Обработка всех найденных в этой строке текста сокращений 
                foreach (Match m in c)
                {
                    // Игнорируем однобуквы (теперь это уже и не нужно, так как
                    // наше регулярное выражение однобуквы не допускает)
                    if (m.Value.Length < 2) continue;

                    // Проверка того, что в списке list.List действительно содержится 
                    // требуемое сокращение. Но проверка не дает нам расшифровки найденного сокращения
                    Acronym ac2 = new Acronym() { Name = m.Value };
                    list.List.Contains(ac2, list);

                    // как бы LINQ
                    Acronym acr = list.List.FirstOrDefault(a => a.Name == m.Value);

                    // Настоящий LINQ - второй вариант строки выше
                    var ac1 = from l in list.List where l.Name == m.Value select l;

                    // Формирование строки списка на экране
                    string str = string.Format("{0}|{1}", m.Value, (acr == null) ? "" : acr.Description);

                    // Проверка на присутствие в списке на экране
                    if (!listResult.Items.Contains(str))
                    {
                        // Добавление в список на экране
                        listResult.Items.Add(str);
                    }
                }
            }
        }

        /// <summary>
        /// Копирование в буфер обмена 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            // Разделитель элементов списка из региональных настроек
            string separator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
            // Формирование заголовка CSV
            string csv = string.Format("Сокращение{0}Описание{0}{1}", separator, Environment.NewLine);
            // Заполнение списка
            foreach (string s in listResult.Items)
            {
                string[] row = s.Split('|');
                string line = string.Format("\"{0}\"{2}\"{1}\"{2}{3}", row[0], row[1], separator, Environment.NewLine);
                csv += line;
            }
            // Строка превращается в последовательность байт в заданной кодировке
            byte[] blob = Encoding.Default.GetBytes(csv);
            // Создаем поток для чтения этих байт из объекта - массива
            System.IO.MemoryStream stream = new System.IO.MemoryStream(blob);
            // Объект для обмена данными с буфером обмена
            DataObject data = new DataObject();
            // Наполнение объекта из потока - тут мы задаем тип наших данных - CSV
            data.SetData(DataFormats.CommaSeparatedValue, stream);
            // Копирование в буфер обмена
            Clipboard.SetDataObject(data, true);
        }       
    }
}
