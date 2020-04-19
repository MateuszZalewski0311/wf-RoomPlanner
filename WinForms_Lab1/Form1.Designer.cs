namespace WinForms_Lab1
{
    partial class RoomPlanner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.blueprintPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.addFurnitureGroupBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.coffeTableButton = new System.Windows.Forms.Button();
            this.tableButton = new System.Windows.Forms.Button();
            this.sofaButton = new System.Windows.Forms.Button();
            this.doubleBedButton = new System.Windows.Forms.Button();
            this.wallButton = new System.Windows.Forms.Button();
            this.createdFurnitureGroupBox = new System.Windows.Forms.GroupBox();
            this.createdFurnitureListBox = new RefreshingListBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueprintPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.addFurnitureGroupBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.createdFurnitureGroupBox.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AutoScroll = true;
            this.splitContainer.Panel1.Controls.Add(this.blueprintPictureBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer.Size = new System.Drawing.Size(684, 437);
            this.splitContainer.SplitterDistance = 454;
            this.splitContainer.TabIndex = 0;
            // 
            // blueprintPictureBox
            // 
            this.blueprintPictureBox.BackColor = System.Drawing.Color.White;
            this.blueprintPictureBox.Location = new System.Drawing.Point(0, 0);
            this.blueprintPictureBox.Name = "blueprintPictureBox";
            this.blueprintPictureBox.Size = new System.Drawing.Size(400, 400);
            this.blueprintPictureBox.TabIndex = 0;
            this.blueprintPictureBox.TabStop = false;
            this.blueprintPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blueprintPictureBox_MouseDown);
            this.blueprintPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.blueprintPictureBox_MouseMove);
            this.blueprintPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.blueprintPictureBox_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.addFurnitureGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.createdFurnitureGroupBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(226, 437);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // addFurnitureGroupBox
            // 
            this.addFurnitureGroupBox.Controls.Add(this.flowLayoutPanel1);
            this.addFurnitureGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addFurnitureGroupBox.Location = new System.Drawing.Point(3, 3);
            this.addFurnitureGroupBox.Name = "addFurnitureGroupBox";
            this.addFurnitureGroupBox.Size = new System.Drawing.Size(220, 212);
            this.addFurnitureGroupBox.TabIndex = 0;
            this.addFurnitureGroupBox.TabStop = false;
            this.addFurnitureGroupBox.Text = "Add furniture";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.coffeTableButton);
            this.flowLayoutPanel1.Controls.Add(this.tableButton);
            this.flowLayoutPanel1.Controls.Add(this.sofaButton);
            this.flowLayoutPanel1.Controls.Add(this.doubleBedButton);
            this.flowLayoutPanel1.Controls.Add(this.wallButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(214, 193);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // coffeTableButton
            // 
            this.coffeTableButton.BackColor = System.Drawing.Color.White;
            this.coffeTableButton.BackgroundImage = global::WinForms_Lab1.Properties.Resources.coffee_table;
            this.coffeTableButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.coffeTableButton.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.coffeTableButton.Location = new System.Drawing.Point(3, 3);
            this.coffeTableButton.Name = "coffeTableButton";
            this.coffeTableButton.Size = new System.Drawing.Size(75, 75);
            this.coffeTableButton.TabIndex = 0;
            this.coffeTableButton.UseVisualStyleBackColor = false;
            this.coffeTableButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // tableButton
            // 
            this.tableButton.BackColor = System.Drawing.Color.White;
            this.tableButton.BackgroundImage = global::WinForms_Lab1.Properties.Resources.table;
            this.tableButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableButton.Location = new System.Drawing.Point(84, 3);
            this.tableButton.Name = "tableButton";
            this.tableButton.Size = new System.Drawing.Size(75, 75);
            this.tableButton.TabIndex = 1;
            this.tableButton.UseVisualStyleBackColor = false;
            this.tableButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // sofaButton
            // 
            this.sofaButton.BackColor = System.Drawing.Color.White;
            this.sofaButton.BackgroundImage = global::WinForms_Lab1.Properties.Resources.sofa;
            this.sofaButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sofaButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sofaButton.Location = new System.Drawing.Point(3, 84);
            this.sofaButton.Name = "sofaButton";
            this.sofaButton.Size = new System.Drawing.Size(75, 75);
            this.sofaButton.TabIndex = 2;
            this.sofaButton.UseVisualStyleBackColor = false;
            this.sofaButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // doubleBedButton
            // 
            this.doubleBedButton.BackColor = System.Drawing.Color.White;
            this.doubleBedButton.BackgroundImage = global::WinForms_Lab1.Properties.Resources.double_bed;
            this.doubleBedButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doubleBedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.doubleBedButton.Location = new System.Drawing.Point(84, 84);
            this.doubleBedButton.Name = "doubleBedButton";
            this.doubleBedButton.Size = new System.Drawing.Size(75, 75);
            this.doubleBedButton.TabIndex = 3;
            this.doubleBedButton.UseVisualStyleBackColor = false;
            this.doubleBedButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // wallButton
            // 
            this.wallButton.BackColor = System.Drawing.Color.White;
            this.wallButton.BackgroundImage = global::WinForms_Lab1.Properties.Resources.wall;
            this.wallButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.wallButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wallButton.Location = new System.Drawing.Point(3, 165);
            this.wallButton.Name = "wallButton";
            this.wallButton.Size = new System.Drawing.Size(75, 75);
            this.wallButton.TabIndex = 4;
            this.wallButton.UseVisualStyleBackColor = false;
            this.wallButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // createdFurnitureGroupBox
            // 
            this.createdFurnitureGroupBox.Controls.Add(this.createdFurnitureListBox);
            this.createdFurnitureGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createdFurnitureGroupBox.Location = new System.Drawing.Point(3, 221);
            this.createdFurnitureGroupBox.Name = "createdFurnitureGroupBox";
            this.createdFurnitureGroupBox.Size = new System.Drawing.Size(220, 213);
            this.createdFurnitureGroupBox.TabIndex = 1;
            this.createdFurnitureGroupBox.TabStop = false;
            this.createdFurnitureGroupBox.Text = "Created furniture";
            // 
            // createdFurnitureListBox
            // 
            this.createdFurnitureListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createdFurnitureListBox.FormattingEnabled = true;
            this.createdFurnitureListBox.Location = new System.Drawing.Point(3, 16);
            this.createdFurnitureListBox.Name = "createdFurnitureListBox";
            this.createdFurnitureListBox.Size = new System.Drawing.Size(214, 194);
            this.createdFurnitureListBox.TabIndex = 0;
            this.createdFurnitureListBox.SelectedIndexChanged += new System.EventHandler(this.createdFurnitureListBox_SelectedIndexChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(684, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBlueprintToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newBlueprintToolStripMenuItem
            // 
            this.newBlueprintToolStripMenuItem.Name = "newBlueprintToolStripMenuItem";
            this.newBlueprintToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.newBlueprintToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.newBlueprintToolStripMenuItem.Text = "New blueprint";
            this.newBlueprintToolStripMenuItem.Click += new System.EventHandler(this.newBlueprintToolStripMenuItem_Click);
            // 
            // RoomPlanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "RoomPlanner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoomPlanner";
            this.Load += new System.EventHandler(this.RoomPlanner_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RoomPlanner_KeyDown);
            this.Resize += new System.EventHandler(this.RoomPlanner_Resize);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.blueprintPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.addFurnitureGroupBox.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.createdFurnitureGroupBox.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.PictureBox blueprintPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox addFurnitureGroupBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox createdFurnitureGroupBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBlueprintToolStripMenuItem;
        private System.Windows.Forms.Button coffeTableButton;
        private System.Windows.Forms.Button tableButton;
        private System.Windows.Forms.Button sofaButton;
        private System.Windows.Forms.Button doubleBedButton;
        private RefreshingListBox createdFurnitureListBox;
        private System.Windows.Forms.Button wallButton;
    }
}

