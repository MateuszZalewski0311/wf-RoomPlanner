using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinForms_Lab1
{
    public class FurnitureListBoxItem
    {
        public Image displayImage;
        public PointF displayPoint;
        public GraphicsPath path;
        public FurnitureListBoxItem(Image _displayImage, PointF _displayPoint, GraphicsPath _path = null)
        {
            displayImage = _displayImage;
            displayPoint = _displayPoint;
            path = _path;
        }

        public override string ToString()
        {
            switch (displayImage.Tag)
            { 
                case "coffe-table.png":
                    return $"Kitchen Table {displayPoint}";
                case "double-bed.png":
                    return $"Bed {displayPoint}";
                case "sofa.png":
                    return $"Sofa {displayPoint}";
                case "table.png":
                    return $"Table {displayPoint}";
                case "wall.png":
                    return $"Wall {displayPoint}";
                default:
                    return "Error in Item";
            }
        }
    }
}
