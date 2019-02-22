using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Piano
{
    public partial class MainForm : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Boolean Beep(int frequency, int duration);

        /// <summary>
        /// Ширина белой клавиши
        /// </summary>
        private const int WhiteWidth = 40;


        /// <summary>
        /// Строка конфигурации
        /// </summary>
        private string config;

        public MainForm()
        {
            // Вывод звука - каналы 
            InitializeComponent();
            InitializeKeyboard();
            // Чтение конфигурации
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            config = System.IO.File.ReadAllText(path + @"\KeyboardMap.txt");
        }

        /// <summary>
        /// Добавление клавиши
        /// </summary>
        /// <param name="b"></param>
        private void AddKey(Button b, int i, int n)
        {
            b.Name = "button" + n;
            b.TabIndex = i;
            b.MouseDown += Mouse_Down;
            b.MouseUp += Mouse_Up;
            Controls.Add(b);
        }

        /// <summary>
        /// Добавление белой клавиши
        /// </summary>
        /// <param name="i">Номер клавиши по расположению</param>
        private void AddWhiteKey(int i, int n)
        {
            // Создание объекта с инициализацией
            Button b = new PianoButton(n, Color.White)
            {                
                Location = new Point(12 + i * WhiteWidth, 12),
                Size = new Size(WhiteWidth, 240),
            };
            AddKey(b, i, n);
        }

        /// <summary>
        /// Добавление черной клавиши
        /// </summary>
        /// <param name="i"></param>
        /// <param name="n"></param>
        private void AddBlackKey(int i, int n)
        {
            // Создание объекта с инициализацией
            Button b = new PianoButton(n, Color.Black)
            {
                Location = new Point(34 + i * WhiteWidth, 12),
                Size = new Size(30, 160),
            };
            AddKey(b, i, n);
        }

        /// <summary>
        /// Добавление октавы
        /// </summary>
        /// <param name="n"></param>
        private void AddOctava(int n)
        {
            int[] whites = { 0, 2, 4, 5, 7, 9, 11 };

            AddBlackKey(n * 7 + 0, n * 12 + 1);
            AddBlackKey(n * 7 + 1, n * 12 + 3);
            AddBlackKey(n * 7 + 3, n * 12 + 6);
            AddBlackKey(n * 7 + 4, n * 12 + 8);
            AddBlackKey(n * 7 + 5, n * 12 + 10);
            for (int i = 0; i < 7; i++)
            {
                AddWhiteKey(n * 7 + i, n * 12 + whites[i]);
            }
        }

        /// <summary>
        /// Построение клавиатуры
        /// </summary>
        private void InitializeKeyboard()
        {
            for (int i = 0; i < 4; i++)
            {
                AddOctava(i);
            }
        }

        /// <summary>
        /// Нажатие кнопки мыши над клавишей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            PianoButton b = (PianoButton)sender;
            // Включение звука
            b.Play();
        }

        /// <summary>
        /// Клавиша мыши отпущена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            PianoButton b = (PianoButton)sender;
            b.Stop();
        }

        /// <summary>
        /// Клавиша на клавиатуре нажата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Key_Down(object sender, KeyEventArgs e)
        {
            string key = e.KeyCode.ToString();
            int n = config.IndexOf(key);
            if (n >= 0)
            {
                n += 24;
                ((PianoButton)Controls["button" + n]).Play();
            }
        }

        /// <summary>
        /// Клавиша на клавиатуре отпущена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Key_Up(object sender, KeyEventArgs e)
        {
            string key = e.KeyCode.ToString();
            int n = config.IndexOf(key);
            if (n >= 0)
            {
                n += 24;
                ((PianoButton)Controls["button" + n]).Stop();
                //   wave[n].Stop();
            }
        }

    }
}
