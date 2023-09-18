﻿using System.Drawing;

namespace TrOCR.Ocr;

public class ColorItemX
{
    public ColorItemX(string name, Color color)
    {
        Name = name;
        ItemColor = color;
    }

    public Color ItemColor { get; set; }

    public string Name { get; set; }
}
