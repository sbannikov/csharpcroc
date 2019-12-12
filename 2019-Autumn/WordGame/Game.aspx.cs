using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WordGame
{
    public partial class Game : System.Web.UI.Page
    {
        /// <summary>
        /// Волшебное слово
        /// </summary>
        private const string Word = "ЭКВИВАЛЕНТНОСТЬ";       

        /// <summary>
        /// Словарь
        /// </summary>
        private Storage.IDict dict;

        /// <summary>
        /// Счетчик нажатия на клавиши
        /// </summary>
        private int PressCount
        {
            get
            {
                if (Session["count"] == null)
                {
                    Session["count"] = 0;
                }
                return (int)Session["count"];
            }
            set
            {
                Session["count"] = value;
            }
        }

        /// <summary>
        /// Стек
        /// </summary>
        private Stack<int> stack
        {
            get
            {
                if (Session["stack"] == null)
                {
                    Session["stack"] = new Stack<int>();
                }
                return (Stack<int>)Session["stack"];
            }
            set
            {
                Session["stack"] = value;
            }
        }

        /// <summary>
        /// Загрузка страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            int n = 0;
            foreach (char c in Word)
            {
                // Кнопка с буквой
                Button button = new Button()
                {
                    ID = (n++).ToString(),
                    Text = c.ToString(),
                    Width = new Unit(64),
                    Height = new Unit(64),
                    BackColor = System.Drawing.Color.White
                };
                button.Font.Size = new FontUnit(32);
                button.Font.Bold = true;
                button.Click += Button_Click;
                panel.Controls.Add(button);

                Literal literal = new Literal()
                {
                    Text = "&nbsp;"
                };
                panel.Controls.Add(literal);
            }

            // Загрузка словаря
            switch (Properties.Settings.Default.Source)
            {
                case "Database":
                    dict = new Storage.Database();
                    break;

                case "XML":
                    dict = Storage.WordList.Load("http://www.orioner.ru/croc/WordList.xml");
                    break;

                default:
                    // наверное, сообщение об ошибке конфигурации
                    break;
            }
        }

        /// <summary>
        /// Нажатие на кнопку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            word.Text += button.Text;
            // Блокировка кнопки для однократного запуска
            button.Enabled = false;
            button.BackColor = System.Drawing.Color.Coral;
            // Определить номер кнопки и положить в стек
            int n = int.Parse(button.ID);
            stack.Push(n);

            // Счётчик нажатий на кнопки 
            PressCount++;

            // Проверка слова по словарю
            Storage.Word w = new Storage.Word(word.Text);
            // Проверка на слово в словаре

            // [*] if (list.Words.Contains(w, list))
            if (dict.Contains(word.Text))
            {
                ListItem item = new ListItem(word.Text);
                // Поискать слово в списке на экране
                if (!words.Items.Contains(item))
                {
                    // Добавить в список
                    // [!] дописать сортировку когда будет время
                    words.Items.Add(word.Text);
                    // Сбросить слово
                    clear_Click(null, null);
                }
            }
        }

        /// <summary>
        /// Удаление последнего символа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void back_Click(object sender, EventArgs e)
        {
            try
            {
                word.Text = word.Text.Substring(0, word.Text.Length - 1);
                int n = stack.Pop();
                foreach (var item in panel.Controls)
                {
                    // Проверка на соответствие типу данных
                    if (item is Button)
                    {
                        // Приведение к типу кнопка
                        Button button = (Button)item;
                        if (button.ID == n.ToString())
                        {
                            button.Enabled = true;
                            button.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
                PressCount++;
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }
        }

        /// <summary>
        /// Кнопка сброса заданного слова
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void clear_Click(object sender, EventArgs e)
        {
            stack.Clear();
            word.Text = string.Empty;
            foreach (var item in panel.Controls)
            {
                // Проверка на соответствие типу данных
                if (item is Button)
                {
                    // Приведение к типу кнопка
                    Button button = (Button)item;

                    button.Enabled = true;
                    button.BackColor = System.Drawing.Color.White;
                }
            }
            PressCount++;
        }

        /// <summary>
        /// Добавление слова в словарь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void enter_Click(object sender, EventArgs e)
        {
            // Добавить слово в базу данных
            dict.Append(word.Text);
        }
    }
}