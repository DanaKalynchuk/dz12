using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace дз12
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void CreateLogo(Graphics g)
        {
            // Встановлюємо розмір об'єкту Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);
            g.PageUnit = GraphicsUnit.Pixel;
            g.PageScale = 1;

            // Координати центра логотипу
            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;

            // Розмір та кольори фігур
            int circleSize = 100;
            Color circleColor1 = Color.Blue;
            Color circleColor2 = Color.FromArgb(255, 0, 128, 0);
            Color textColor = Color.Black;

            // Створюємо коло та заливаємо його кольором
            Rectangle circleRect = new Rectangle(centerX - circleSize / 2, centerY - circleSize / 2, circleSize, circleSize);
            Brush brush = new LinearGradientBrush(circleRect, circleColor1, circleColor2, LinearGradientMode.ForwardDiagonal);
            g.FillEllipse(brush, circleRect);

            // Створюємо маленьке коло в центрі
            circleSize = 50;
            circleRect = new Rectangle(centerX - circleSize / 2, centerY - circleSize / 2, circleSize, circleSize);
            brush = new SolidBrush(circleColor1);
            g.FillEllipse(brush, circleRect);

            // Створюємо лінії
            int lineLength = 70;
            int lineSpacing = 20;
            Pen pen = new Pen(circleColor2, 4);
            g.DrawLine(pen, centerX - lineLength - lineSpacing, centerY, centerX - lineSpacing, centerY);
            g.DrawLine(pen, centerX + lineSpacing, centerY, centerX + lineLength + lineSpacing, centerY);
            g.DrawLine(pen, centerX, centerY - lineLength - lineSpacing, centerX, centerY - lineSpacing);
            g.DrawLine(pen, centerX, centerY + lineSpacing, centerX, centerY + lineLength + lineSpacing);

            
            // Додаємо текст
            Font font = new Font("Arial", 24, FontStyle.Bold);
            string text = "My Company";
            SizeF textSize = g.MeasureString(text, font);
            float textX = centerX - textSize.Width / 2;
            float textY = centerY + circleSize ;

            // Рисуємо тінь тексту
            Brush shadowBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 0)); // Чорний колір з непрозорістю 50%
            g.DrawString(text, font, shadowBrush, textX + 4, textY + 4);

            // Рисуємо окантовку тексту
            Brush strokeBrush = new SolidBrush(Color.AntiqueWhite);
            g.DrawString(text, font, strokeBrush, textX - 1, textY - 1);
            g.DrawString(text, font, strokeBrush, textX + 1, textY - 1);
            g.DrawString(text, font, strokeBrush, textX - 1, textY + 1);
            g.DrawString(text, font, strokeBrush, textX + 1, textY + 1);

            // Рисуємо основний текст
            Brush textBrush = new SolidBrush(textColor);
            g.DrawString(text, font, textBrush, textX, textY);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            CreateLogo(e.Graphics);
        }
    }
}

