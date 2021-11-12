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
        Graphics g;
        Pen Pen;
        Brush Brush;
        int xPos, yPos;
        bool fill;

        public Canvas(Graphics g)
        {
            this.g = g;
            xPos = 0; 
            yPos = 0;
            Pen = new Pen(Color.Black, 1);
            Brush = new SolidBrush(Color.Black);
            fill = false;
        }

        public void DrawCircle(int radius)
        {
            if (fill) g.FillEllipse(Brush, xPos, yPos, radius, radius);
            else g.DrawEllipse(Pen, xPos, yPos, radius, radius);
        }

        public void DrawRectangle(int width, int height)
        {
            if (fill) g.FillRectangle(Brush, xPos, yPos, xPos + width, yPos + height);
            else g.DrawRectangle(Pen, xPos, yPos, xPos + width, yPos + height);
        }

        public void DrawTriangle(int length)
        {
            int y2 = yPos + (int)Math.Round(Math.Sqrt(3)/2 * length);

            Point point1 = new Point(xPos, yPos);
            Point point2 = new Point(xPos + length, yPos);
            Point point3 = new Point(xPos + length/2, y2);

            Point[] points = { point1, point2, point3 };

            if (fill) g.FillPolygon(Brush, points);
            else g.DrawPolygon(Pen, points);
        }

        public void moveTo(int x, int y)
        {
            xPos = x;
            yPos = y;
        }

        public void DrawTo(int x, int y)
        {
            g.DrawLine(Pen, x, y, xPos, yPos);
            moveTo(x, y);
        }

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

        public void ChangeFill(bool option)
        {
            fill = option;
        }

        public void reset()
        {
            xPos = 0;
            yPos = 0;
        }

        public void clear()
        {
            g.Clear(Color.White);
        }

    }
}
