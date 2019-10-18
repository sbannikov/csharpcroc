using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Cостояние игры
        /// </summary>
        private Data.Game game = new Data.Game();

        /// <summary>
        /// Длина корабля
        /// </summary>
        private int cells = 0;

        /// <summary>
        /// Первая клетка большого корабля
        /// </summary>
        private Data.Cell cell;

        /// <summary>
        /// Клиент веб-сервиса моего партнера по игре
        /// </summary>
        private GameClient.GameServiceClient client;

        /// <summary>
        /// Конструктор формы по умолчанию
        /// </summary>
        public MainForm()
        {
            // Инициализация компонентов формы
            InitializeComponent();
        }

        /// <summary>
        /// Обработка события загрузки формы
        /// </summary>
        /// <param name="sender">Форма</param>
        /// <param name="e">Параметры события</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    // Создание кнопки моего поля
                    var b1 = new CellButton(x, y, true )
                    {
                        Size = new Size(32, 32),
                        // Учет высоты меню и высоты панели инструментов при добавлении кнопки
                        Location = new Point(40 * x, 40 * y + menu.Height + tool.Height)
                    };
                    // Обработчик события
                    b1.Click += myButtonClick;
                    // Добавление кнопки на форму
                    Controls.Add(b1);

                    // Создание кнопки чужого поля
                    var b2 = new CellButton(x, y, false)
                    {
                        Size = new Size(32, 32),
                        // Учет высоты меню и высоты панели инструментов при добавлении кнопки
                        Location = new Point(40 * (x+11), 40 * y + menu.Height + tool.Height)
                    };
                    // Обработчик события
                    b2.Click += enemyButtonClick;
                    // Добавление кнопки на форму
                    Controls.Add(b2);
                }
            }
            // Учет высоты строки состояний
            Height += status.Height;
            // Интервал срабатывания таймера из конфигурации
            timer.Interval = Properties.Settings.Default.Interval;
            // Включение таймера
            timer.Enabled = true;
        }

        /// <summary>
        /// Обработка нажатия кнопки на поле противника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enemyButtonClick(object sender, EventArgs e)
        {
            if (client != null)
            {
                // Приведение типа данных
                CellButton b = (CellButton)sender;
                // Создание клетки
                var cell = new Data.Cell(b.X, b.Y);
                // Выстрелить
                client.Fire(cell);
            }
        }

        /// <summary>
        /// Обработчик нажатия кнопки
        /// </summary>
        /// <param name="sender">Кнопка</param>
        /// <param name="e"></param>
        private void myButtonClick(object sender, EventArgs e)
        {
            try
            {
                // Приведение типа данных
                CellButton b = (CellButton)sender;
                // Проверить корректность размещения корабля
                if (!game.My.CheckAround(b.X, b.Y))
                {
                    return;
                }
                // Расстановка кораблей
                switch (cells)
                {
                    case 1: // Однопалубный корабль
                        // Покрасить кнопку-корабль
                        b.BackColor = Color.OrangeRed;
                        // Отлипнуть кнопку
                        ship1.Checked = false;
                        // Создать корабль
                        game.My.AddShip1(b.X, b.Y);
                        // Возврат в основной режим
                        cells = 0;
                        break;

                    case 2: // Двухпалубный корабль
                        if (cell == null)
                        {
                            // Запомнить первую клетку
                            b.BackColor = Color.ForestGreen;
                            cell = new Data.Cell(b.X, b.Y);
                            cell.CellState = Data.State.Alive;
                        }
                        else if (!cell.CheckNear(b.X, b.Y))
                        {
                            // Нажата некорректная вторая клетка
                            return;
                        }
                        else
                        {
                            // Покрасить первую кнопку-корабль
                            getButton(cell.X, cell.Y, true).BackColor = Color.OrangeRed;
                            // Покрасить вторую кнопку-корабль
                            b.BackColor = Color.OrangeRed;
                            // Отлипнуть кнопку
                            ship2.Checked = false;
                            // Добавить двухпалбный корабль
                            game.My.AddShip2(cell, b.X, b.Y);
                            // Сброс отмеченной клетки
                            cell = null;
                            // Возврат в основной режим
                            cells = 0;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Выход из программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Закрыть главную форму
            this.Close();
        }

        /// <summary>
        /// Сохранение игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Запрос имени файла
            if (save.ShowDialog() == DialogResult.OK)
            {
                // Сохранение в заданный файл
                game.Save(save.FileName);
            }
        }

        /// <summary>
        /// Расстановка однопалубного корабля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ship1_Click(object sender, EventArgs e)
        {
            // "залипание" кнопки
            ship1.Checked = true;
            // Разрешение добавления однопалубного корабля
            cells = 1;
        }

        /// <summary>
        /// Расстановка двухпалубного корабля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ship2_Click(object sender, EventArgs e)
        {
            // "залипание" кнопки
            ship2.Checked = true;
            // Разрешение добавления двухпалубного корабля
            cells = 2;
        }

        /// <summary>
        /// Поиск кнопки по координатам сетки
        /// </summary>
        /// <param name="x">Абсцисса</param>
        /// <param name="y">Ордината</param>
        /// <param name="my">Признак поля игрока</param>
        /// <returns></returns>
        private CellButton getButton(int x, int y, bool my)
        {
            foreach (Control control in Controls)
            {
                // Проверка на возможность приведения типа
                if (!(control is CellButton)) continue;
                // Приведение типа в явной форме
                CellButton button = (CellButton)control;
                // Проверка на совпадение координат
                if ((button.X == x) && (button.Y == y) && (button.My == my))
                {  // Мы нашли нужную кнопку
                    return button;
                }
            }
            return null;
        }

        /// <summary>
        /// Событие срабатывания таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                // Временно отключаем таймер
                timer.Enabled = false;
                // Обновление метки времени
                Program.db.Register();
                // Отражение активности в строке состояния
                timerLabel.Text = timerLabel.Text == "*" ? "." : "*";
                // Проверка на очередь
                Data.Cell cell;
                if (Program.fire.TryDequeue(out cell))
                {
                    // Проверка того, куда мы попали и попали ли вообще
                    cell.CellState = game.My.CellState(cell);
                    // Поиск кнопки по координатам
                    CellButton b = getButton(cell.X, cell.Y, true);
                    // Перекрасить кнопку
                    b.BackColor = (cell.CellState == Data.State.Alive) ? Color.DarkRed : Color.LimeGreen;
                    // Как будто мы всегда попали
                    if (client != null)
                    {
                        // Вернуть результат выстрела
                        client.Result(cell);
                    }
                }
                if (Program.result.TryDequeue(out cell))
                {
                    // Поиск кнопки по координатам
                    CellButton b = getButton(cell.X, cell.Y, false);
                    // Перекрасить кнопку
                    b.BackColor = (cell.CellState == Data.State.Alive) ? Color.Red:  Color.Blue;
                }
            }
            finally
            {
                // Обратно включаем таймер
                timer.Enabled = true;
            }
        }

        /// <summary>
        /// Событие перед закрытием главного окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Выключение таймера
            timer.Enabled = false;
        }

        /// <summary>
        /// Начало игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Создание формы
                var form = new ChoosePlayerForm();
                // Если сделан выбор из формы
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Выбранный игрок в списке
                    Database.Sessions s = (Database.Sessions)form.list.SelectedItem;
                    string uri = $"http://{s.ComputerName}:8888/SeaBattle/GameService/";
                    // Клиент сервиса
                    client = new GameClient.GameServiceClient();
                    client.Endpoint.Address = new System.ServiceModel.EndpointAddress(uri);
                    client.Open();
                    // Запрос имени игрока
                    string name = client.GetName();
                    // Вывод на экран
                    MessageBox.Show(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
