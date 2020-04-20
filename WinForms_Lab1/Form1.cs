using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
            blueprintPictureBox.MouseWheel += blueprintPictureBox_MouseWheel;
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
            createdFurnitureListBox.ClearSelected();

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
                            selectedItem.anchorPoint = new PointF(selectedItem.displayPoint.X - e.X, selectedItem.displayPoint.Y - e.Y);
                            return;
                        }
                    }
                    else if (Math.Abs(selectedItem.displayPoint.X - e.X) < selectedItem.displayImage.Width / 2 && (Math.Abs(selectedItem.displayPoint.Y - e.Y) < selectedItem.displayImage.Height / 2))
                    {
                        movingSelectedItem = true;
                        selectedItem.anchorPoint = new PointF(selectedItem.displayPoint.X - e.X, selectedItem.displayPoint.Y - e.Y);
                        return;
                    }
                }
                for (int i = 0; i < createdFurnitureListBox.Items.Count; ++i)
                {
                    if (!(createdFurnitureListBox.Items[i] is FurnitureListBoxItem))
                        continue;
                    FurnitureListBoxItem item = createdFurnitureListBox.Items[i] as FurnitureListBoxItem;
                    if (item.type == "wall.png" && item.path != null)
                    {
                        Pen wallPen = new Pen(Color.Black, 10);
                        wallPen.LineJoin = LineJoin.Round;
                        if (item.path.IsOutlineVisible(e.Location, wallPen))
                        {
                            createdFurnitureListBox.ClearSelected();
                            createdFurnitureListBox.SetSelected(i, true);
                            movingSelectedItem = true;
                            item.anchorPoint = new PointF(item.displayPoint.X - e.X, item.displayPoint.Y - e.Y);
                        }
                    }
                    else
                    {
                        if (Math.Abs(item.displayPoint.X - e.X) < item.displayImage.Width / 2 && (Math.Abs(item.displayPoint.Y - e.Y) < item.displayImage.Height / 2))
                        {
                            createdFurnitureListBox.ClearSelected();
                            createdFurnitureListBox.SetSelected(i, true);
                            movingSelectedItem = true;
                            item.anchorPoint = new PointF(item.displayPoint.X - e.X, item.displayPoint.Y - e.Y);
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
            if (movingSelectedItem == true && createdFurnitureListBox.SelectedItem is FurnitureListBoxItem selectedItem)
            {
                movingSelectedItem = false;
                selectedItem.anchorPoint = null;
            }
        }

        private void splitContainer_Panel1_Resize(object sender, EventArgs e)
        {
            if (blueprintPictureBox.Width > splitContainer.Panel1.Width && blueprintPictureBox.Height > splitContainer.Panel1.Height)
                return;

            blueprintPictureBox.Width = Math.Max(blueprintPictureBox.Width, splitContainer.Panel1.Width);
            blueprintPictureBox.Height = Math.Max(blueprintPictureBox.Height, splitContainer.Panel1.Height);

            Bitmap bmp = new Bitmap(blueprintPictureBox.Width, blueprintPictureBox.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);
            if (blueprintPictureBox.Image != null)
                g.DrawImage(blueprintPictureBox.Image , 0, 0);
            blueprintPictureBox.Image = bmp;
            g.Dispose();
        }

        private void blueprintPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (wallPainting == false)
            {
                if (movingSelectedItem == true && createdFurnitureListBox.SelectedItem is FurnitureListBoxItem selectedItem && selectedItem.anchorPoint != null)
                {
                    PointF point = new PointF(e.X + selectedItem.anchorPoint.Value.X, e.Y + selectedItem.anchorPoint.Value.Y);
                    if ((string)selectedItem.displayImage.Tag == "wall.png")
                    {
                        Matrix translateMatrix = new Matrix();
                        translateMatrix.Translate(point.X - selectedItem.displayPoint.X, point.Y - selectedItem.displayPoint.Y);
                        selectedItem.path.Transform(translateMatrix);
                        selectedItem.displayPoint.X = selectedItem.path.PathPoints[0].X;
                        selectedItem.displayPoint.Y = selectedItem.path.PathPoints[0].Y;
                    }
                    else
                    {
                        selectedItem.displayPoint.X = point.X;
                        selectedItem.displayPoint.Y = point.Y;
                    }
                    //createdFurnitureListBox.Items[createdFurnitureListBox.SelectedIndex] = createdFurnitureListBox.Items[createdFurnitureListBox.SelectedIndex];
                    createdFurnitureListBox.RefreshItem(createdFurnitureListBox.SelectedIndex);
                    repaintPictureBoxFromList();
                }
                return;
            }
            repaintPictureBoxFromList(e.Location);
        }

        private void blueprintPictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (createdFurnitureListBox.SelectedIndex < 0)
                return;

            HandledMouseEventArgs he = (HandledMouseEventArgs)e;
            he.Handled = true;
            if (createdFurnitureListBox.SelectedItem is FurnitureListBoxItem selectedItem)
                selectedItem.rotation -= e.Delta / 12;
            repaintPictureBoxFromList();
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
                if (item.type == "wall.png")
                {
                    if (item == createdFurnitureListBox.SelectedItem)
                        wallPen = new Pen(Color.FromArgb(128, 0, 0, 0), 10); // semi transparent
                    else
                        wallPen = new Pen(Color.Black, 10); // opaque
                    wallPen.LineJoin = LineJoin.Round;

                    //Matrix for rotation
                    if (item.path != null)
                    {
                        Matrix rotateMatrix = null;
                        if (item.path.PointCount > 1)
                        {
                            rotateMatrix = new Matrix();
                            rotateMatrix.RotateAt(item.rotation, item.path.PathPoints[0]);
                        }

                        if (item.path.PointCount > 0)
                        {
                            GraphicsPath graphicsPath = (GraphicsPath)item.path.Clone();
                            if (wallPath == item.path && mouseClickPoint != null)
                                graphicsPath.AddLine(graphicsPath.GetLastPoint(), (PointF)mouseClickPoint);
                            if (rotateMatrix != null)
                                graphicsPath.Transform(rotateMatrix);
                            g.DrawPath(wallPen, graphicsPath);
                        }
                        else if (item.path.PointCount == 0 && mouseClickPoint != null)
                            g.DrawLine(wallPen, pathStart, (PointF)mouseClickPoint);
                    }
                }
                else
                {
                    if (item.rotation != 0)
                    {
                        g.TranslateTransform(item.displayPoint.X, item.displayPoint.Y);
                        g.RotateTransform(item.rotation);
                        g.TranslateTransform(-item.displayPoint.X, -item.displayPoint.Y);
                    }

                    PointF point = new PointF(item.displayPoint.X - item.displayImage.Width / 2, item.displayPoint.Y - item.displayImage.Height / 2);
                    if (item == createdFurnitureListBox.SelectedItem)
                    {
                        g.DrawImage(item.displayImage, new Rectangle((int)point.X, (int)point.Y, item.displayImage.Width, item.displayImage.Height), 0.0f, 0.0f, item.displayImage.Width, item.displayImage.Height, GraphicsUnit.Pixel, imageAtt);
                    }
                    else
                        g.DrawImage(item.displayImage, point);
                }
                g.ResetTransform();
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

        private void RoomPlanner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && createdFurnitureListBox.SelectedIndex > -1)
            {
                createdFurnitureListBox.Items.RemoveAt(createdFurnitureListBox.SelectedIndex);
            }
        }

        private void openBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                openFileDialog.Filter = "Blueprint files (*.bp)|*.bp";
                openFileDialog.FilterIndex = 2;
                //openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] fileName = openFileDialog.FileName.Split('.');
                    if (fileName[fileName.Length - 1] != "bp")
                    {
                        MessageBox.Show("Failed to open the blueprint.");
                        return;
                    }

                    //Read the contents of the file into a stream
                    Stream fileStream = null;
                    try
                    {
                        fileStream = openFileDialog.OpenFile();
                        if (fileStream != null)
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            List<FurnitureListBoxItem> listBoxItems = new List<FurnitureListBoxItem>();

                            listBoxItems = (List<FurnitureListBoxItem>)formatter.Deserialize(fileStream);

                            newBitmapInPictureBox(splitContainer.Panel1.Width, splitContainer.Panel1.Height);
                            createdFurnitureListBox.Items.Clear();
                            if (selectedButton != null)
                            {
                                selectedButton.BackColor = Color.White;
                                selectedButton = null;
                            }
                            wallPainting = false;
                            wallPath = new GraphicsPath();

                            for (int i = 0; i < listBoxItems.Count; ++i)
                            {
                                createdFurnitureListBox.Items.Add(listBoxItems[i]);
                            }
                        }
                    }
                    catch (System.Runtime.Serialization.SerializationException)
                    {
                        MessageBox.Show("Failed to load the blueprint.");
                        return;
                    }
                    finally
                    {
                        if (fileStream != null)
                            fileStream.Close();
                    }
                    repaintPictureBoxFromList();
                    createdFurnitureListBox.RefreshItems();
                    MessageBox.Show("Blueprint loaded successfully!");
                }
            }
        }

        private void saveBlueprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Blueprint files (*.bp)|*.bp";
                saveFileDialog.FilterIndex = 2;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] fileName = saveFileDialog.FileName.Split('.');
                    if (fileName[fileName.Length - 1] != "bp")
                    {
                        MessageBox.Show("Failed to save the blueprint.");
                        return;
                    }

                    Stream fileStream = null;
                    try
                    {
                        fileStream = saveFileDialog.OpenFile();
                        if (fileStream != null)
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            List<FurnitureListBoxItem> listBoxItems = new List<FurnitureListBoxItem>();
                            for (int i = 0; i < createdFurnitureListBox.Items.Count; ++i)
                            {
                                if (createdFurnitureListBox.Items[i] is FurnitureListBoxItem item)
                                    listBoxItems.Add(item);
                            }

                            formatter.Serialize(fileStream, listBoxItems);
                        }
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Failed to save the blueprint.");
                        return;
                    }
                    finally
                    {
                        if (fileStream != null)
                            fileStream.Close();
                    }
                    MessageBox.Show("Blueprint saved successfully!");
                }
            }
        }
    }

    public class RefreshingListBox : ListBox
    {
        public new void RefreshItem(int index)
        {
            base.RefreshItem(index);
        }

        public new void RefreshItems()
        {
            base.RefreshItems();
        }
    }
}
