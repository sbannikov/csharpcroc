using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;

namespace AirBattle
{
    /// <summary>
    /// Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Размер кнопки
        /// </summary>
        private const int buttonSize = 48;
        /// <summary>
        /// Размер создаваемого корабля
        /// </summary>
        private int ship;
        /// <summary>
        /// Первая клетка большого корабля
        /// </summary>
        private Data.Cell cell;
        /// <summary>
        /// Состояние игры
        /// </summary>
        private Data.Game game;
        /// <summary>
        /// Сервис
        /// </summary>
        private GameService svc;
        /// <summary>
        /// Домик для сервиса
        /// </summary>
        private ServiceHost host;
        /// <summary>
        /// Клиент веб-сервиса
        /// </summary>
        private GameClient.GameServiceClient client;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public MainForm()
        {
            // Инициализация компонентов дизайнера
            InitializeComponent();
            // Инициализация игры
            game = new Data.Game();
        }

        /// <summary>
        /// Создание метки в ячейке сетки
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        /// <param name="text">Текст метки</param>
        private void AddLabel(int x, int y, string text)
        {
            // Создание новой метки
            Label label = new Label()
            {
                // Текст метки
                Text = text,
                // Размер метки
                Size = new Size(buttonSize, buttonSize),
                // Шрифт метки
                Font = new Font(FontFamily.GenericMonospace, 32),
                // Выравнивание текста
                TextAlign = ContentAlignment.MiddleCenter,
                // Положение метки
                Location = new Point(buttonSize * x, buttonSize * y + menu.Height + tool.Height)
            };
            // Добавление метки на форму
            Controls.Add(label);
        }

        /// <summary>
        /// Обработка события загрузки формы
        /// </summary>
        /// <param name="sender">Объект события</param>
        /// <param name="e">Параметры события</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Формирование квадратного поля
            for (int x = 1; x <= Data.Game.FieldSize; x++)
            {
                for (int y = 1; y <= Data.Game.FieldSize; y++)
                {
                    // Создание новой кнопки своего поля
                    // Использование инициализатора
                    CellButton b1 = new CellButton(x, y, true)
                    {
                        // Размер кнопки
                        Size = new Size(buttonSize, buttonSize),
                        // Положение кнопки
                        Location = new Point(buttonSize * x, buttonSize * y + menu.Height + tool.Height)
                    };
                    // Добавление обработчика кнопки
                    b1.Click += Button_Click;
                    // Добавление кнопки на форму
                    Controls.Add(b1);

                    // Создание новой кнопки чужого поля
                    // Использование инициализатора
                    CellButton b2 = new CellButton(x, y, false)
                    {
                        // Размер кнопки
                        Size = new Size(buttonSize, buttonSize),
                        // Положение кнопки
                        Location = new Point(buttonSize * (x + 11), buttonSize * y + menu.Height + tool.Height)
                    };
                    b2.Click += Fire_Click;
                    // Добавление кнопки на форму
                    Controls.Add(b2);
                }
            }
            // Формирование подписей
            for (int a = 1; a <= Data.Game.FieldSize; a++)
            {
                // Буквенная подпись по горизонтали
                AddLabel(a, 0, Convert.ToChar(a + Convert.ToInt16('А') - 1).ToString());
                AddLabel(a + 11, 0, Convert.ToChar(a + Convert.ToInt16('А') - 1).ToString());
                // Цифровая подпись по вертикали
                AddLabel(0, a, (a - 1).ToString());
                AddLabel(11, a, (a - 1).ToString());
            }
            // Коррекция высоты формы
            Height += status.Height;
            // Интервал таймера из конфигурации
            timer.Interval = Properties.Settings.Default.Interval;
            // Включение таймера
            timer.Enabled = true;
            // Запуск в отдельном потоке
            Task.Factory.StartNew(() =>
            {
                // Создание сервиса
                svc = new GameService();
                // Создание домика для сервиса
                host = new ServiceHost(svc);
                // Включение сервиса
                host.Open();
            });
        }

        /// <summary>
        /// Нажатие на кнопку вражеского поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fire_Click(object sender, EventArgs e)
        {
            // Проверка на существование клиента
            if (client != null)
            {
                // Приведение типа
                CellButton b = (CellButton)sender;
                // Создание объекта клетки
                Data.Cell cell = new Data.Cell(b.X, b.Y);
                // Выстрел по вражескому полю
                client.Fire(cell);
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку моего поля
        /// </summary>
        /// <param name="sender">Кнопка</param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                // Приведение типа
                CellButton b = (CellButton)sender;
                // Проверка доступности клетки
                if (!game.My.CheckCellAvail(b.X, b.Y)) return;
                // Определение режима работы
                switch (ship)
                {
                    case 1: // Однопалубный корабль
                        // Добавление корабля
                        game.My.AddShip1(b.X, b.Y);
                        // Перекрасить кнопку
                        b.BackColor = Data.Cell.ShipColor;
                        // Отпустить кнопку 
                        button1.Checked = false;
                        // Корабль создан
                        ship = 0;
                        break;

                    case 2: // Двухпалубный корабль
                        if (cell == null)
                        {
                            // Покрасить первую кнопку
                            b.BackColor = Color.Orchid;
                            // Запомнить первую клетку
                            cell = new Data.Cell(b.X, b.Y)
                            {
                                CellState = Data.State.Active
                            };
                        }
                        else if (!cell.CheckCellNear(b.X, b.Y))
                        {
                            return;
                        }
                        else
                        {
                            // Покрасить первую кнопку
                            getButton(cell.X, cell.Y, true).BackColor = Data.Cell.ShipColor;
                            // Покрасить вторую кнопку
                            b.BackColor = Data.Cell.ShipColor;
                            // Добавить корабль
                            game.My.AddShip2(cell, b.X, b.Y);
                            // Кнопка "отлипла"
                            button2.Checked = false;
                            // Забыть клетку, которую мы запомнили
                            cell = null;
                            // Корабль создан
                            ship = 0;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Добавление корабля", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Пункт меню - Выход из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Закрыть форму
            this.Close();
        }

        /// <summary>
        /// Начало создания однопалубного корабля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ship = 1;
            // Кнопка "залипла"
            button1.Checked = true;
        }

        /// <summary>
        /// Начало создания двухпалубного корабля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ship = 2;
            // Кнопка "залипла"
            button2.Checked = true;
        }

        /// <summary>
        /// Сохранение состояния игры в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Запросить имя файла
            if (save.ShowDialog() == DialogResult.OK)
            {
                // Сохранить в заданный файл
                game.Save(save.FileName);
            }
        }

        /// <summary>
        /// Загрузка состояния игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    game = Data.Game.Load(open.FileName);
                    // Визуализация данных игры
                    foreach (Data.Ship ship in game.My.Ships)
                    {
                        foreach (Data.Cell cell in ship.Cells)
                        {
                            getButton(cell.X, cell.Y, true).BackColor = Data.Cell.ShipColor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Загрузка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Обработчик таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            // Обновление метки времени в базе
            Program.db.Register();
            // Индикация активности
            timerLabel.Text = (timerLabel.Text == "*") ? "." : "*";

            Data.Cell cell;
            // Проверка на наличие выстрела
            if (Program.fire.TryDequeue(out cell))
            {
                // Определение кнопки
                CellButton b = getButton(cell.X, cell.Y, true);
                // Определение результата выстрела
                cell.CellState = game.My.CellState(cell);
                // Отобразить состояние клетки
                b.BackColor = cell.CellState == Data.State.None? Color.Blue : Color.IndianRed;
                // Возврат результата
                client.Result(cell);
            }
            // Проверка на наличие результата
            if (Program.result.TryDequeue(out cell))
            {
                // Отобразить состояние клетки
                CellButton b = getButton(cell.X, cell.Y, false);
                // Отобразить состояние клетки
                b.BackColor = cell.CellState == Data.State.None ? Color.Blue : Color.IndianRed;
            }
        }
        /// <summary>
        /// Событие попытки закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Отключение таймера
            timer.Enabled = false;
        }
        /// <summary>
        /// Найти кнопку по координатам
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        /// <param name="my">Признак собственного поля</param>
        /// <returns></returns>
        private CellButton getButton(int x, int y, bool my)
        {            
            foreach (Control control in Controls)
            {
                // Проверка на соответствие типа
                if (!(control is CellButton)) continue;
                // Приведение типа в явной форме
                CellButton button = (CellButton)control;
                // Проверка на совпадение координат
                if ((button.X == x) && (button.Y == y) && (button.My == my))
                {
                    // Мы нашли нужную кнопку
                    return button;
                }
            }
            // Кнопка не найдена
            return null;
        }

        /// <summary>
        /// Обработчик пункта меню "Игра | Начать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создание формы
            var form = new ChoosePlayerForm();
            // Отображение модального окна
            if (form.ShowDialog() == DialogResult.OK)
            {
                Storage.Session s = (Storage.Session)form.list.SelectedItem;
                // Ссылка на веб-сервис игры
                string uri = $"http://localhost:8888/AirBattle/GameService/";
                // Клиент сервиса
                client = new GameClient.GameServiceClient();
                client.Endpoint.Address = new EndpointAddress(uri);
                client.Open();
                // Запрос имени игрока
                string name = client.GetName();
                // Вывод на экран
                MessageBox.Show(name);
            }
        }
    }
}
