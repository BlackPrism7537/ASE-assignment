using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_assignment
{
    class Canvas
    {
        Graphics g;
        Pen Pen;
        int xPos, yPos;

        public Canvas(Graphics g)
        {
            this.g = g;
            xPos = 0; 
            yPos = 0;
            Pen = new Pen(Color.Black, 1);
        }

        public void DrawCircle(int radius)
        {
            g.DrawEllipse(Pen, xPos, yPos, radius, radius);
        }

        public void DrawRectangle(int width, int height)
        {
            g.DrawRectangle(Pen, xPos, yPos, xPos + width, yPos + height);
        }

        public void DrawTriangle(int length)
        {
            int y2 = yPos + (int)Math.Round(Math.Sqrt(3)/2 * length);

            g.DrawLine(Pen, xPos, yPos, xPos + length, yPos);
            g.DrawLine(Pen, xPos + length, yPos, xPos + length/2, y2);
            g.DrawLine(Pen, xPos, yPos, xPos + length / 2, y2);
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
        }

        public void ChangeFill(bool option)
        {
            //TODO
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
