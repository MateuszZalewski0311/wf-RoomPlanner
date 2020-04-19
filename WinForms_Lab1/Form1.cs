﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_Lab1
{
    public partial class RoomPlanner : Form
    {
        private Button selectedButton;
        private bool movingSelectedItem = false;
        private bool wallPainting = false;
        private PointF pathStart = new PointF();
        private GraphicsPath wallPath = new GraphicsPath();
        public RoomPlanner()
        {
            InitializeComponent();
            coffeTableButton.BackgroundImage.Tag = "coffe-table.png";
            tableButton.BackgroundImage.Tag = "table.png";
            sofaButton.BackgroundImage.Tag = "sofa.png";
            doubleBedButton.BackgroundImage.Tag = "double-bed.png";
            wallButton.BackgroundImage.Tag = "wall.png";
        }
        private void RoomPlanner_Load(object sender, EventArgs e)
        {
            newBitmapInPictureBox(splitContainer.Panel1.Width, splitContainer.Panel1.Height);
        }

        private void newBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newBitmapInPictureBox(splitContainer.Panel1.Width, splitContainer.Panel1.Height);
            createdFurnitureListBox.Items.Clear();
            if (selectedButton != null)
            {
                selectedButton.BackColor = Color.White;
                selectedButton = null;
            }
            wallPainting = false;
            wallPath = new GraphicsPath();
        }

        private void newBitmapInPictureBox(int width, int height)
        {
            blueprintPictureBox.Width = width;
            blueprintPictureBox.Height = height;
            Bitmap bmp = new Bitmap(blueprintPictureBox.Width, blueprintPictureBox.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);
            blueprintPictureBox.Image = bmp;   
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (!(sender is Button))
                return;

            Button oldButton = selectedButton;
            selectedButton = (Button)sender;

            if (wallPainting == true)
            {
                resetWallPainting();
                repaintPictureBoxFromList();
            }
            if (selectedButton.BackColor == Color.White)
            {
                if (oldButton != null && oldButton.BackColor == Color.Moccasin)
                    oldButton.BackColor = Color.White;
                selectedButton.BackColor = Color.Moccasin;
            }
            else if (selectedButton.BackColor == Color.Moccasin)
            {
                selectedButton.BackColor = Color.White;
                selectedButton = null;
                return;
            }
        }

        private void blueprintPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedButton == null /*|| e.X > blueprintPictureBox.Image.Width || e.Y > blueprintPictureBox.Image.Height*/)
            {
                if (createdFurnitureListBox.SelectedItem != null && createdFurnitureListBox.SelectedItem is FurnitureListBoxItem selectedItem)
                {
                    if((string)selectedItem.displayImage.Tag == "wall.png")
                    {
                        Pen wallPen = new Pen(Color.FromArgb(128, 0, 0, 0), 10);
                        wallPen.LineJoin = LineJoin.Round;
                        if (selectedItem.path != null && selectedItem.path.IsOutlineVisible(e.Location, wallPen))
                        {
                            movingSelectedItem = true;
                            return;
                        }
                    }
                    else if (Math.Abs(selectedItem.displayPoint.X - e.X) < selectedItem.displayImage.Width / 2 && (Math.Abs(selectedItem.displayPoint.Y - e.Y) < selectedItem.displayImage.Height / 2))
                    {
                        movingSelectedItem = true;
                        return;
                    }
                }
                for (int i = 0; i < createdFurnitureListBox.Items.Count; ++i)
                {
                    if (!(createdFurnitureListBox.Items[i] is FurnitureListBoxItem))
                        continue;
                    FurnitureListBoxItem item = createdFurnitureListBox.Items[i] as FurnitureListBoxItem;
                    if ((string)item.displayImage.Tag == "wall.png" && item.path != null)
                    {
                        Pen wallPen = new Pen(Color.Black, 10);
                        wallPen.LineJoin = LineJoin.Round;
                        if (item.path.IsOutlineVisible(e.Location, wallPen))
                        {
                            createdFurnitureListBox.ClearSelected();
                            createdFurnitureListBox.SetSelected(i, true);
                        }
                    }
                    else
                    {
                        if (Math.Abs(item.displayPoint.X - e.X) < item.displayImage.Width / 2 && (Math.Abs(item.displayPoint.Y - e.Y) < item.displayImage.Height / 2))
                        {
                            createdFurnitureListBox.ClearSelected();
                            createdFurnitureListBox.SetSelected(i, true);
                        }
                    }
                }
                return;
            }

            if (selectedButton == wallButton)
            {
                if (e.Button == MouseButtons.Right)
                {
                    resetWallPainting();
                    selectedButton.BackColor = Color.White;
                    selectedButton = null;
                    repaintPictureBoxFromList();
                    return;
                }
                if (wallPainting == false)
                {
                    pathStart = new PointF(e.X, e.Y);
                    wallPainting = true;
                    createdFurnitureListBox.Items.Add(new FurnitureListBoxItem(selectedButton.BackgroundImage, pathStart, wallPath));
                    return;
                }
                if (wallPath.PointCount == 0)
                    wallPath.AddLine(pathStart, new PointF(e.X, e.Y));
                else
                    wallPath.AddLine(wallPath.GetLastPoint(), new PointF(e.X, e.Y));
                repaintPictureBoxFromList(e.Location);
            }    
            else if (e.Button != MouseButtons.Right)
            {
                PointF point = new PointF(e.X - selectedButton.BackgroundImage.Width / 2, e.Y - selectedButton.BackgroundImage.Height / 2);
                Graphics g = Graphics.FromImage(blueprintPictureBox.Image);
                g.DrawImage(selectedButton.BackgroundImage, point);
                blueprintPictureBox.Refresh();
                g.Dispose();

                createdFurnitureListBox.Items.Add(new FurnitureListBoxItem(selectedButton.BackgroundImage, e.Location));

                selectedButton.BackColor = Color.White;
                selectedButton = null; 
            }
        }

        private void blueprintPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            movingSelectedItem = false;
        }

        private void RoomPlanner_Resize(object sender, EventArgs e)
        {
            if (blueprintPictureBox.Width > splitContainer.Panel1.Width && blueprintPictureBox.Height > splitContainer.Panel1.Height)
                return;

            blueprintPictureBox.Width = Math.Max(blueprintPictureBox.Width, splitContainer.Panel1.Width);
            blueprintPictureBox.Height = Math.Max(blueprintPictureBox.Height, splitContainer.Panel1.Height);

            Bitmap bmp = new Bitmap(blueprintPictureBox.Width, blueprintPictureBox.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);
            g.DrawImage(blueprintPictureBox.Image , 0, 0);
            blueprintPictureBox.Image = bmp;
            g.Dispose();
        }

        private void blueprintPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (wallPainting == false)
                return;
            repaintPictureBoxFromList(e.Location);
        }

        private void repaintPictureBoxFromList(PointF? mouseClickPoint = null)
        {
            // Pen handle for wall painting
            Pen wallPen;
            // ImageAttributes for transparent image drawing
            float[][] matrixItems ={
                        new float[] {1, 0, 0, 0, 0},
                        new float[] {0, 1, 0, 0, 0},
                        new float[] {0, 0, 1, 0, 0},
                        new float[] {0, 0, 0, 0.5f, 0},
                        new float[] {0, 0, 0, 0, 1}};
            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);
            ImageAttributes imageAtt = new ImageAttributes();
            imageAtt.SetColorMatrix(
               colorMatrix,
               ColorMatrixFlag.Default,
               ColorAdjustType.Bitmap);

            Graphics g = Graphics.FromImage(blueprintPictureBox.Image);
            g.FillRectangle(Brushes.White, 0, 0, blueprintPictureBox.Image.Width, blueprintPictureBox.Image.Height);
            for (int i = 0; i < createdFurnitureListBox.Items.Count; ++i)
            {
                if (!(createdFurnitureListBox.Items[i] is FurnitureListBoxItem))
                    continue;
                
                FurnitureListBoxItem item = createdFurnitureListBox.Items[i] as FurnitureListBoxItem;
                if ((string)item.displayImage.Tag == "wall.png")
                {
                    if (item == createdFurnitureListBox.SelectedItem)
                        wallPen = new Pen(Color.FromArgb(128, 0, 0, 0), 10); // semi transparent
                    else
                        wallPen = new Pen(Color.Black, 10); // opaque
                    wallPen.LineJoin = LineJoin.Round;

                    if (item.path != null && item.path.PointCount > 0)
                    {
                        GraphicsPath graphicsPath = (GraphicsPath)item.path.Clone();
                        if (wallPath == item.path && mouseClickPoint != null)
                            graphicsPath.AddLine(graphicsPath.GetLastPoint(), (PointF)mouseClickPoint);
                        g.DrawPath(wallPen, graphicsPath);
                    }
                    else if (item.path != null && item.path.PointCount == 0 && mouseClickPoint != null)
                        g.DrawLine(wallPen, pathStart, (PointF)mouseClickPoint);
                }
                else
                {
                    PointF point = new PointF(item.displayPoint.X - item.displayImage.Width / 2, item.displayPoint.Y - item.displayImage.Height / 2);
                    if (item == createdFurnitureListBox.SelectedItem)
                    {
                        g.DrawImage(item.displayImage, new Rectangle((int)point.X, (int)point.Y, item.displayImage.Width, item.displayImage.Height), 0.0f, 0.0f, item.displayImage.Width, item.displayImage.Height, GraphicsUnit.Pixel, imageAtt);
                    }
                    else
                        g.DrawImage(item.displayImage, point);
                }
            }
            g.Dispose();
            blueprintPictureBox.Refresh();
        }

        private void resetWallPainting()
        {
            if (wallPainting == true)
            {
                if (wallPath.PointCount == 0)
                    createdFurnitureListBox.Items.RemoveAt(createdFurnitureListBox.Items.Count - 1);
                wallPath = new GraphicsPath();
                wallPainting = false;
            }
        }

        private void createdFurnitureListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (wallPainting == true)
                resetWallPainting();
            repaintPictureBoxFromList();
        }
    }
}