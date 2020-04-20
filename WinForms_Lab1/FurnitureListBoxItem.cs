using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;

namespace WinForms_Lab1
{
    [Serializable]
    public class FurnitureListBoxItem
    {
        public string type;
        public Image displayImage;
        public PointF displayPoint;
        public PointF? anchorPoint;
        public int rotation;
        [NonSerialized]
        public GraphicsPath path;
        private PointF[] pathPoints;
        public FurnitureListBoxItem(Image _displayImage, PointF _displayPoint, GraphicsPath _path = null)
        {
            displayImage = _displayImage;
            displayPoint = _displayPoint;
            anchorPoint = null;
            rotation = 0;
            path = _path;
            pathPoints = null;
            type = (string)displayImage.Tag;
        }

        public override string ToString()
        {
            switch (type)
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

        [OnSerializing]
        private void PathToPts(StreamingContext context)
        {
            if (path != null && path.PointCount > 0)
                pathPoints = path.PathPoints;
        }

        [OnDeserialized]
        private void PtsToPath(StreamingContext context)
        {
            if (pathPoints != null && pathPoints.Length > 1)
            {
                path = new GraphicsPath();
                for (int i = 1; i < pathPoints.Length; ++i)
                {
                    path.AddLine(pathPoints[i - 1], pathPoints[i]);
                }
            }
        }
    }
}
