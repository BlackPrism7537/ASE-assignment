using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_assignment
{
    public class Canvas
    {
        private Graphics g = Graphics.FromImage(new Bitmap(300, 300));
        private Pen Pen;
        private Brush Brush;
        private int xPos, yPos;
        private bool fill;

        public Canvas(Graphics g = null)
        {
            if (g == null) { g = Graphics.FromImage(new Bitmap(300, 300)); }
            else { this.g = g; }
            xPos = 0; 
            yPos = 0;
            Pen = new Pen(Color.Black, 1);
            Brush = new SolidBrush(Color.Black);
            fill = false;
        }

        /// <summary>
        /// draws circle of given radius
        /// </summary>
        /// <param name="radius">radius of circle in pixels</param>
        public void DrawCircle(int radius)
        {
            if (fill) g.FillEllipse(Brush, xPos, yPos, radius, radius);
            else g.DrawEllipse(Pen, xPos, yPos, radius, radius);
            Console.WriteLine("drawing circle");
        }

        /// <summary>
        /// draws rectangle of given width and height
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height in pixels</param>
        public void DrawRectangle(int width, int height)
        {
            if (fill) g.FillRectangle(Brush, xPos, yPos, xPos + width, yPos + height);
            else g.DrawRectangle(Pen, xPos, yPos, xPos + width, yPos + height);
        }

        /// <summary>
        /// draws equilateral triangle with given side length
        /// </summary>
        /// <param name="length">side length in pixels</param>
        public void DrawTriangle(int length)
        {
            int y3 = yPos + (int)Math.Round(Math.Sqrt(3)/2 * length);

            Point point1 = new Point(xPos, yPos);
            Point point2 = new Point(xPos + length, yPos);
            Point point3 = new Point(xPos + length/2, y3);

            Point[] points = { point1, point2, point3 };

            if (fill) g.FillPolygon(Brush, points);
            else g.DrawPolygon(Pen, points);
        }

        /// <summary>
        /// moves pen position to given coordinates
        /// </summary>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        public void moveTo(int x, int y)
        {
            xPos = x;
            yPos = y;
        }

        /// <summary>
        /// draws from current position to given coordinates
        /// and changes pen position to given coordinates
        /// </summary>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        public void DrawTo(int x, int y)
        {
            g.DrawLine(Pen, x, y, xPos, yPos);
            moveTo(x, y);
        }

        /// <summary>
        /// changes pen color
        /// </summary>
        /// <param name="color"></param>
        public void ChangeColor(string color)
        {
            Color penColor;
            switch (color)
            {
                case "black":
                    penColor = Color.Black;
                    break;
                case "white":
                    penColor = Color.White;
                    break;
                case "red":
                    penColor = Color.Red;
                    break;
                case "green":
                    penColor = Color.Green;
                    break;
                case "Blue":
                    penColor = Color.Blue;
                    break;
                default:
                    penColor = Pen.Color;
                    break;
            }
            Pen.Color = penColor;
            Brush = new SolidBrush(penColor);
        }

        /// <summary>
        /// changes fill variable
        /// </summary>
        /// <param name="option"></param>
        public void ChangeFill(bool option)
        {
            fill = option;
        }


        /// <summary>
        /// resets pen position
        /// </summary>
        public void Reset()
        {
            xPos = 0;
            yPos = 0;
        }

        /// <summary>
        /// clears canvas
        /// </summary>
        public void Clear()
        {
            g.Clear(Color.Empty);
        }

    }
}
