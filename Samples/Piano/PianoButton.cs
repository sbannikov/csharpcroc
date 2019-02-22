using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;


namespace Piano
{
    public class PianoButton : Button
    {
        private WaveOut wave;

        /// <summary>
        /// Исходный цвет кнопки
        /// </summary>
        private System.Drawing.Color color;
               
        /// <summary>
        /// Создание кнопки пианино
        /// </summary>
        /// <param name="n">Номер кнопки, начиная с 0</param>
        /// <param name="back">Цвет фона кнопки</param>
        public PianoButton(int n, System.Drawing.Color back)
        {
            Tag = n.ToString();
            var gen = new SignalGenerator();
            gen.Type = SignalGeneratorType.Sin;
            gen.Frequency = Convert.ToInt32(130.81 * Math.Pow(2, n / 12.0));
            wave = new WaveOut();
            wave.Init(gen);
            BackColor = back;
            color = back;
        }

        /// <summary>
        /// Нажатие на кнопку и извлечение звука
        /// </summary>
        public void Play()
        {            
            BackColor = System.Drawing.Color.Red;
            wave.Play();
        }

        /// <summary>
        /// Кнопка отпущена, звук закончился
        /// </summary>
        public void Stop()
        {
            BackColor = color;
            wave.Stop();
        }
    }
}
