using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Sim1Test.Rendering
{
    public static class QuantumGateRenderer
    {
        public static void DrawHadamardGate(Graphics g, int x, int y, Color gateColor)
        {
            int size = 44;
            Rectangle rect = new Rectangle(x - size / 2, y - size / 2, size, size);

            using (LinearGradientBrush gradBrush =
                   new LinearGradientBrush(rect, Color.FromArgb(120, 200, 255), gateColor, 45f))
                g.FillRectangle(gradBrush, rect);

            using (Pen borderPen = new Pen(Color.FromArgb(60, 120, 180), 2))
                g.DrawRectangle(borderPen, rect);

            using (Font gateFont = new Font("Times New Roman", 20, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.White))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString("H", gateFont, textBrush, rect, sf);
            }
        }
        public static void DrawXGate(Graphics g, int x, int y, Color gateColor)
        {
            DrawGateBox(g, x, y, "X", gateColor);
        }

        public static void DrawYGate(Graphics g, int x, int y, Color gateColor)
        {
            DrawGateBox(g, x, y, "Y", gateColor);
        }

        public static void DrawZGate(Graphics g, int x, int y, Color gateColor)
        {
            DrawGateBox(g, x, y, "Z", gateColor);
        }

        public static void DrawGateBox(Graphics g, int x, int y, string label, Color gateColor, int size = 44)
        {
            Rectangle rect = new Rectangle(x - size / 2, y - size / 2, size, size);

            using (LinearGradientBrush gradBrush =
                   new LinearGradientBrush(rect,
                       Color.FromArgb(220, gateColor.R, gateColor.G, gateColor.B),
                       Color.FromArgb(160, gateColor.R / 2, gateColor.G / 2, gateColor.B / 2),
                       45f))
            {
                g.FillRectangle(gradBrush, rect);
            }

            using (Pen borderPen = new Pen(
                       Color.FromArgb(200, Math.Max(gateColor.R - 40, 0),
                                           Math.Max(gateColor.G - 40, 0),
                                           Math.Max(gateColor.B - 40, 0)), 2))
            {
                g.DrawRectangle(borderPen, rect);
            }

            using (Font gateFont = new Font("Times New Roman", 20, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.White))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(label, gateFont, textBrush, rect, sf);
            }
        }



        public static void DrawCNOTGate(Graphics g, int x, int controlY, int targetY,
                                        Color controlColor, Color targetColor)
        {
            using (Pen connectPen = new Pen(controlColor, 2))
                g.DrawLine(connectPen, x, controlY, x, targetY);

            int controlRadius = 8;
            using (Brush controlBrush = new SolidBrush(controlColor))
                g.FillEllipse(controlBrush, x - controlRadius, controlY - controlRadius,
                              controlRadius * 2, controlRadius * 2);

            int targetRadius = 20;
            Rectangle targetRect = new Rectangle(x - targetRadius, targetY - targetRadius,
                                                 targetRadius * 2, targetRadius * 2);

            using (LinearGradientBrush gradBrush =
                   new LinearGradientBrush(targetRect, Color.FromArgb(255, 150, 100), targetColor, 45f))
                g.FillEllipse(gradBrush, targetRect);

            using (Pen targetPen = new Pen(Color.FromArgb(180, 80, 50), 2))
                g.DrawEllipse(targetPen, targetRect);

            using (Pen plusPen = new Pen(Color.White, 3))
            {
                g.DrawLine(plusPen, x - 12, targetY, x + 12, targetY);
                g.DrawLine(plusPen, x, targetY - 12, x, targetY + 12);
            }
        }

        public static void DrawOutputBox(Graphics g, int x, int y, string value, Color boxColor, int size = 40)
        {
            Rectangle rect = new Rectangle(x - size / 2, y - size / 2, size, size);

            using (GraphicsPath path = GetRoundedRectPath(rect, 8))
            {
                using (LinearGradientBrush gradBrush = new LinearGradientBrush(
                    rect,
                    Color.FromArgb(255, boxColor.R, boxColor.G, boxColor.B),
                    Color.FromArgb(200, boxColor.R * 3 / 4, boxColor.G * 3 / 4, boxColor.B * 3 / 4),
                    45f))
                    g.FillPath(gradBrush, path);

                using (Pen borderPen = new Pen(
                    Color.FromArgb(180, boxColor.R * 2 / 3, boxColor.G * 2 / 3, boxColor.B * 2 / 3), 2))
                    g.DrawPath(borderPen, path);
            }

            using (Font valueFont = new Font("Consolas", 16, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.White))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                g.DrawString(value, valueFont, textBrush, rect, sf);
            }
        }

        private static GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
