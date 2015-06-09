using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib.Computer;
using System.Drawing;
using Lib;
using System.Text.RegularExpressions;

namespace CW.View
{
    public enum ViewStyle : int
    {
        binaryNumbers = 1,
        hexNumbers = 2,
        binaryColor = 3,
        hexColor = 4
    }

    public class ViewSettings
    {
        public static Color selectedColor = Color.FromArgb(199, 230, 255);
        public static int titleOffcet = 70;
        public static int registersTop = 145;
        public static int cellWidth = 25;
        public static int cellHeight = 16;
        public static int cellGap = 4;
        public static ViewStyle style = ViewStyle.hexNumbers;
        public static Brush borderColor = Brushes.Green;
        public static int borderSize = 2;
        public static Font font = new Font(FontFamily.GenericMonospace, 10);
    }

    public class View
    {


        public static PaintEventArgs ViewMemory(Computer computer, PaintEventArgs view)
        {
            Graphics target = view.Graphics;
            Memory memory = computer.memory;

            for (int i = 0; i < Memory.REGISTERS_NUMBER; i++)
            {
                string hex = memory.GetRegister(i).HexString();

                
                string[] array = new string[OctoByte.OCTO_SIZE];
                for (int j = 0; j < array.Length; j++ )
                {
                    array[j] = hex.Substring(j * 2, 2);
                }

                hex = "";
                for (int j = 0; j < array.Length; j++)
                {
                    hex += array[j]+" ";
                }

                int x = 0;
                int y = ViewSettings.cellHeight * i;

                if (computer.selectedRegisters.IndexOf(i) != -1)
                {
                    target.FillRectangle(new SolidBrush(ViewSettings.selectedColor), x + ViewSettings.titleOffcet, y, ViewSettings.cellWidth * 8, ViewSettings.cellHeight);
                }
                target.DrawString("$" + i, ViewSettings.font, Brushes.Blue, new PointF(x, y));
                target.DrawString(hex, ViewSettings.font, Brushes.Blue, new PointF(x + ViewSettings.titleOffcet, y));
            }

            for (int i = 0; i < Memory.MEMORY_SIZE; i++)
            {
                target.DrawString(Lib.Utils.Utils.IntToHex(i, 2), ViewSettings.font, Brushes.Blue, new PointF(0, ViewSettings.cellHeight * i + ViewSettings.registersTop));

                for (int j = 0; j < OctoByte.OCTO_SIZE; j++)
                {
                    if (ViewSettings.style == ViewStyle.binaryColor)
                    {
                        for (int k = 0; k < Lib.Computer.Byte.BYTE_SIZE; k++)
                        {
                            bool value = memory[i][j][k];
                            int x = j * (ViewSettings.cellGap + Lib.Computer.Byte.BYTE_SIZE * ViewSettings.cellWidth) + k * ViewSettings.cellWidth + ViewSettings.titleOffcet;
                            int y = i * ViewSettings.cellHeight + ViewSettings.registersTop;

                            if (memory[i][j][k])
                            {
                                target.FillRectangle(Brushes.Black, x, y, ViewSettings.cellWidth, ViewSettings.cellHeight);

                                if (k == 0)
                                {
                                    target.DrawLine(new Pen(ViewSettings.borderColor, ViewSettings.borderSize), new Point(x - ViewSettings.cellGap / 2, 0), new Point(x - ViewSettings.cellGap / 2, Memory.MEMORY_SIZE * ViewSettings.cellHeight));
                                }
                            }
                        }
                    }


                    if (ViewSettings.style == ViewStyle.binaryNumbers)
                    {
                        for (int k = 0; k < Lib.Computer.Byte.BYTE_SIZE; k++)
                        {
                            bool value = memory[i][j][k];
                            int x = j * (ViewSettings.cellGap + Lib.Computer.Byte.BYTE_SIZE * ViewSettings.cellWidth) + k * ViewSettings.cellWidth + ViewSettings.titleOffcet;
                            int y = i * ViewSettings.cellHeight + ViewSettings.registersTop;

                            if (k == 0)
                            {
                                target.DrawLine(new Pen(ViewSettings.borderColor, ViewSettings.borderSize), new Point(x - ViewSettings.cellGap / 2, ViewSettings.registersTop), new Point(x - ViewSettings.cellGap / 2, Memory.MEMORY_SIZE * ViewSettings.cellHeight + ViewSettings.registersTop));
                            }
                            if (memory[i][j][k])
                            {
                                target.DrawString(Lib.Utils.Utils.BoolToString(value) + "", ViewSettings.font, Brushes.Red, new PointF(x, y));
                            }
                            else
                            {
                                target.DrawString(Lib.Utils.Utils.BoolToString(value) + "", ViewSettings.font, Brushes.Blue, new PointF(x, y));
                            }
                        }
                    }


                    if (ViewSettings.style == ViewStyle.hexNumbers)
                    {
                        string hex = memory[i][j].HexString;
                        int x = j * ViewSettings.cellWidth + ViewSettings.titleOffcet;
                        int y = i * ViewSettings.cellHeight + ViewSettings.registersTop;
                        if(computer.selectedOctos.IndexOf(i) != -1)
                        {
                            target.FillRectangle(new SolidBrush(ViewSettings.selectedColor), x, y, ViewSettings.cellWidth * 8, ViewSettings.cellHeight);
                        }
                        target.DrawString(hex, ViewSettings.font, Brushes.Blue, new PointF(x, y));
                    }

                    if (ViewSettings.style == ViewStyle.hexColor)
                    {
                        int intensity = memory[i][j].Value(Format.Classic);
                        int x = j * ViewSettings.cellWidth + ViewSettings.titleOffcet;
                        int y = i * ViewSettings.cellHeight + ViewSettings.registersTop;
                        target.FillRectangle(new SolidBrush(Color.FromArgb(intensity, intensity, intensity)), x, y, ViewSettings.cellWidth, ViewSettings.cellHeight);
                    }
                }
            }

            return view;
        }
    }
}
