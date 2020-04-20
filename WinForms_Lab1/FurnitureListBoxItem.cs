using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Resources;
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
        public Point? pictureBoxSize;
        public FurnitureListBoxItem(Image _displayImage, PointF _displayPoint, GraphicsPath _path = null, Point? _pictureBoxSize = null)
        {
            displayImage = _displayImage;
            displayPoint = _displayPoint;
            anchorPoint = null;
            rotation = 0;
            path = _path;
            pathPoints = null;
            type = (string)displayImage.Tag;
            pictureBoxSize = _pictureBoxSize;
        }

        public override string ToString()
        {
            ResourceManager resources = new ResourceManager(typeof(RoomPlanner));
            switch (type)
            { 
                case "coffe-table.png":
                    return resources.GetString("FurnitureListBoxItem.CoffeTable.Text") + $" {displayPoint}";
                case "double-bed.png":
                    return resources.GetString("FurnitureListBoxItem.DoubleBed.Text") + $" {displayPoint}";
                case "sofa.png":
                    return resources.GetString("FurnitureListBoxItem.Sofa.Text") + $" {displayPoint}";
                case "table.png":
                    return resources.GetString("FurnitureListBoxItem.Table.Text") + $" {displayPoint}";
                case "wall.png":
                    return resources.GetString("FurnitureListBoxItem.Wall.Text") + $" {displayPoint}";
                default:
                    return "Error in Item";
            }
        }

        [OnSerializing]
        private void OnSer(StreamingContext context)
        {
            if (path != null && path.PointCount > 0)
                pathPoints = path.PathPoints;
        }

        [OnDeserialized]
        private void OnDesered(StreamingContext context)
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
