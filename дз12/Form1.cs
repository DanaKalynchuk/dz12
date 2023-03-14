using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace дз12
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = 1000; // Оновлення кожну секунду
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DateTime time = DateTime.Now;
            int seconds = time.Second;
            int minutes = time.Minute;
            int hours = time.Hour % 12;

            // Отримання розміру і центра вікна форми
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;
            int centerX = formWidth / 2;
            int centerY = formHeight / 2;

            // Розмір і положення круга
            int circleSize = Math.Min(formWidth, formHeight) * 3 / 5;
            int circleX = centerX - circleSize / 2;
            int circleY = centerY - circleSize / 2;

            // Рисуємо круг
            Pen pen = new Pen(Color.Black, 2);
            g.DrawEllipse(pen, circleX, circleY, circleSize, circleSize);

            // Розмір і положення точки на центрі годинника
            int dotSize = circleSize / 15;
            int dotX = centerX - dotSize / 2;
            int dotY = centerY - dotSize / 2;

            // Рисуємо точку на центрі годинника
            SolidBrush brush = new SolidBrush(Color.Black);
            g.FillEllipse(brush, dotX, dotY, dotSize, dotSize);

            // Розмір і положення стрілки годин
            int hourHandSize = circleSize / 3;
            double hourAngle = (hours + minutes / 60.0) * 30.0;
            hourAngle = hourAngle * Math.PI / 180.0;

            // Рисуємо стрілку годин
            int hourHandEndX = centerX + (int)(hourHandSize / 2 * Math.Sin(hourAngle));
            int hourHandEndY = centerY - (int)(hourHandSize / 2 * Math.Cos(hourAngle));
            g.DrawLine(pen, centerX, centerY, hourHandEndX, hourHandEndY);

            // Розмір і положення стрілки хвилин
            int minuteHandSize = circleSize * 2 / 3;
            double minuteAngle = (minutes + seconds / 60.0) * 6.0;
            minuteAngle = minuteAngle * Math.PI / 180.0;

            // Рисуємо стрілку хвилин
            int minuteHandEndX = centerX + (int)(minuteHandSize / 2 * Math.Sin(minuteAngle));
            int minuteHandEndY = centerY - (int)(minuteHandSize / 2 * Math.Cos(minuteAngle));
            g.DrawLine(pen, centerX, centerY, minuteHandEndX, minuteHandEndY);

            // Розмір і положення стрілки секунд
            int secondHandSize = circleSize * 4 / 5;
            double secondAngle = seconds * 6.0;
            secondAngle = secondAngle * Math.PI / 180.0;

            // Рисуємо стрілку секунд
            int secondHandEndX = centerX + (int)(secondHandSize / 2 * Math.Sin(secondAngle));
            int secondHandEndY = centerY - (int)(secondHandSize / 2 * Math.Cos(secondAngle));

            g.DrawLine(new Pen(Color.Red, 1), centerX, centerY, secondHandEndX, secondHandEndY);
            // Розмір і положення цифр на годиннику
            int fontSize = circleSize / 20;
            Font font = new Font("Arial", fontSize, FontStyle.Bold);
            SolidBrush fontBrush = new SolidBrush(Color.Green);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
           
            // Вивід цифр годин
            for (int i = 1; i <= 12; i++)
            {
                double angle = (i - 3) * 30.0;
                double x = centerX + Math.Cos(angle * Math.PI / 180.0) * circleSize / 2.2;
                double y = centerY + Math.Sin(angle * Math.PI / 180.0) * circleSize / 2.2;
                g.DrawString(i.ToString(), font, fontBrush, (float)x, (float)y, stringFormat);
            }

            // Вивід поділок на хвилини
            for (int i = 0; i < 60; i++)
            {
                double angle = (i - 15) * 6.0;
                double x = centerX + Math.Cos(angle * Math.PI / 180.0) * circleSize / 2.2;
                double y = centerY + Math.Sin(angle * Math.PI / 180.0) * circleSize / 2.2;
                if (i % 5 == 0)
                {
                    continue;
                }
                else
                {
                    g.DrawEllipse(pen, (float)x - dotSize / 8, (float)y - dotSize / 8, dotSize / 6, dotSize / 6);
                }
            }
        }
    }
}
