using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicForms
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Координата X нажатия кнопки мыши на элементе схемы
        /// </summary>
        private int x;
        /// <summary>
        /// Координата Y нажатия кнопки мыши на элементе схемы
        /// </summary>
        private int y;
        /// <summary>
        /// Признак нажатия кнопки мыши на элементе схемы
        /// </summary>
        private bool pressed;
        /// <summary>
        /// Первый элемент схемы для соединения
        /// </summary>
        private Logicals.LogicalControl first;
        /// <summary>
        /// Список связей
        /// </summary>
        private List<LogicalLink> links;

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            // Инициализация полей
            pressed = false;
            first = null;
            links = new List<LogicalLink>();
        }

        /// <summary>
        /// Выход из прилождения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Добавление логического элемента на схему
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            ToolStripButton s = (ToolStripButton)sender;
            string className = string.Format("LogicForms.Logicals.{0}", s.Tag);

            // Control c = (Control)Activator.CreateInstance(null, className).Unwrap();
            Logicals.LogicalControl c = new Logicals.LogicalControl();
            c.BackgroundImage = (Bitmap)Properties.Resources.ResourceManager.GetObject((string)s.Tag);
            c.Code = (string)s.Tag;
            c.MouseDown += ComponentMouseDown;
            c.MouseMove += ComponentMouseMove;
            c.MouseUp += ComponentMouseUp;
            c.MouseDoubleClick += ComponentMouseDoubleClick;
            // Относительная (обратная) координата входа для корректной отрисовки связей
            c.input = (string)s.Tag == "LogicalNot" ? 2 : 6;
            // Добавление элемента на схему
            mainPanel.Controls.Add(c);
        }

        /// <summary>
        /// Двойной щелчок по элементу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComponentMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (first == null)
            {
                first = (Logicals.LogicalControl)sender;
            }
            else
            {
                // Добавление связи
                LogicalLink link = new LogicalLink()
                {
                    From = first,
                    To = (Logicals.LogicalControl)sender
                };
                first.Output = link;
                links.Add(link);
                // Принудительно перерисовать
                mainPanel.Invalidate();
                // Связь добавлена
                first = null;
                // Сформировать логическое выражение
                UpdateExpression();
            }
        }

        /// <summary>
        /// Мышь нажата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComponentMouseDown(object sender, MouseEventArgs e)
        {
            pressed = true;
            x = e.X;
            y = e.Y;
        }

        /// <summary>
        /// Движение мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComponentMouseMove(object sender, MouseEventArgs e)
        {
            if (pressed)
            {
                Control c = (Control)sender;

                // Переместить на новое место
                c.Location = new Point(e.X - x + c.Location.X, e.Y - y + c.Location.Y);
                // Принудительно перерисовать
                mainPanel.Invalidate();
            }
        }

        /// <summary>
        /// Мышь отпущена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComponentMouseUp(object sender, MouseEventArgs e)
        {
            pressed = false;
        }

        /// <summary>
        /// Отрисовка панели и связей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            // e.Graphics.Clear(Color.White);
            foreach (LogicalLink link in links)
            {
                int x1 = link.From.Location.X + link.From.Size.Width;
                int y1 = link.From.Location.Y + link.From.Size.Height / 2;
                int x2 = link.To.Location.X;
                int y2 = link.To.Location.Y + link.To.Size.Height / link.To.input;
                Pen p = new Pen(Color.Red, 2);
                e.Graphics.DrawLine(p, x1, y1, x2, y2);
            }
        }

        /// <summary>
        /// Определение корня графа
        /// </summary>
        /// <returns></returns>
        private Logicals.LogicalControl Root()
        {
            foreach (Logicals.LogicalControl c in mainPanel.Controls)
            {
                if (c.Output == null)
                {
                    return c;
                }
            }
            return null;
        }


        /// <summary>
        /// Обновление логического выражения
        /// (не реализовано полностью)
        /// </summary>
        private void UpdateExpression()
        {
            expressionText.Text = "";
            Logicals.LogicalControl root = Root();
            if (root == null) return;
            expressionText.Text = root.Code;
        }

    }
}
