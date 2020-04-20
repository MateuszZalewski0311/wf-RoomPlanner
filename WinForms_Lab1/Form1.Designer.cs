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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomPlanner));
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
            this.createdFurnitureListBox = new WinForms_Lab1.RefreshingListBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveBlueprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polskiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            resources.ApplyResources(this.splitContainer.Panel1, "splitContainer.Panel1");
            this.splitContainer.Panel1.Controls.Add(this.blueprintPictureBox);
            this.splitContainer.Panel1.Resize += new System.EventHandler(this.splitContainer_Panel1_Resize);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tableLayoutPanel1);
            // 
            // blueprintPictureBox
            // 
            this.blueprintPictureBox.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.blueprintPictureBox, "blueprintPictureBox");
            this.blueprintPictureBox.Name = "blueprintPictureBox";
            this.blueprintPictureBox.TabStop = false;
            this.blueprintPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blueprintPictureBox_MouseDown);
            this.blueprintPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.blueprintPictureBox_MouseMove);
            this.blueprintPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.blueprintPictureBox_MouseUp);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.addFurnitureGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.createdFurnitureGroupBox, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // addFurnitureGroupBox
            // 
            this.addFurnitureGroupBox.Controls.Add(this.flowLayoutPanel1);
            resources.ApplyResources(this.addFurnitureGroupBox, "addFurnitureGroupBox");
            this.addFurnitureGroupBox.Name = "addFurnitureGroupBox";
            this.addFurnitureGroupBox.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.coffeTableButton);
            this.flowLayoutPanel1.Controls.Add(this.tableButton);
            this.flowLayoutPanel1.Controls.Add(this.sofaButton);
            this.flowLayoutPanel1.Controls.Add(this.doubleBedButton);
            this.flowLayoutPanel1.Controls.Add(this.wallButton);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // coffeTableButton
            // 
            this.coffeTableButton.BackColor = System.Drawing.Color.White;
            this.coffeTableButton.BackgroundImage = global::WinForms_Lab1.Properties.Resources.coffee_table;
            resources.ApplyResources(this.coffeTableButton, "coffeTableButton");
            this.coffeTableButton.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.coffeTableButton.Name = "coffeTableButton";
            this.coffeTableButton.UseVisualStyleBackColor = false;
            this.coffeTableButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // tableButton
            // 
            this.tableButton.BackColor = System.Drawing.Color.White;
            this.tableButton.BackgroundImage = global::WinForms_Lab1.Properties.Resources.table;
            resources.ApplyResources(this.tableButton, "tableButton");
            this.tableButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tableButton.Name = "tableButton";
            this.tableButton.UseVisualStyleBackColor = false;
            this.tableButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // sofaButton
            // 
            this.sofaButton.BackColor = System.Drawing.Color.White;
            this.sofaButton.BackgroundImage = global::WinForms_Lab1.Properties.Resources.sofa;
            resources.ApplyResources(this.sofaButton, "sofaButton");
            this.sofaButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sofaButton.Name = "sofaButton";
            this.sofaButton.UseVisualStyleBackColor = false;
            this.sofaButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // doubleBedButton
            // 
            this.doubleBedButton.BackColor = System.Drawing.Color.White;
            this.doubleBedButton.BackgroundImage = global::WinForms_Lab1.Properties.Resources.double_bed;
            resources.ApplyResources(this.doubleBedButton, "doubleBedButton");
            this.doubleBedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.doubleBedButton.Name = "doubleBedButton";
            this.doubleBedButton.UseVisualStyleBackColor = false;
            this.doubleBedButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // wallButton
            // 
            this.wallButton.BackColor = System.Drawing.Color.White;
            this.wallButton.BackgroundImage = global::WinForms_Lab1.Properties.Resources.wall;
            resources.ApplyResources(this.wallButton, "wallButton");
            this.wallButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wallButton.Name = "wallButton";
            this.wallButton.UseVisualStyleBackColor = false;
            this.wallButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // createdFurnitureGroupBox
            // 
            this.createdFurnitureGroupBox.Controls.Add(this.createdFurnitureListBox);
            resources.ApplyResources(this.createdFurnitureGroupBox, "createdFurnitureGroupBox");
            this.createdFurnitureGroupBox.Name = "createdFurnitureGroupBox";
            this.createdFurnitureGroupBox.TabStop = false;
            // 
            // createdFurnitureListBox
            // 
            resources.ApplyResources(this.createdFurnitureListBox, "createdFurnitureListBox");
            this.createdFurnitureListBox.FormattingEnabled = true;
            this.createdFurnitureListBox.Name = "createdFurnitureListBox";
            this.createdFurnitureListBox.SelectedIndexChanged += new System.EventHandler(this.createdFurnitureListBox_SelectedIndexChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newBlueprintToolStripMenuItem,
            this.openBlueprintToolStripMenuItem,
            this.saveBlueprintToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newBlueprintToolStripMenuItem
            // 
            this.newBlueprintToolStripMenuItem.Name = "newBlueprintToolStripMenuItem";
            resources.ApplyResources(this.newBlueprintToolStripMenuItem, "newBlueprintToolStripMenuItem");
            this.newBlueprintToolStripMenuItem.Click += new System.EventHandler(this.newBlueprintToolStripMenuItem_Click);
            // 
            // openBlueprintToolStripMenuItem
            // 
            this.openBlueprintToolStripMenuItem.Name = "openBlueprintToolStripMenuItem";
            resources.ApplyResources(this.openBlueprintToolStripMenuItem, "openBlueprintToolStripMenuItem");
            this.openBlueprintToolStripMenuItem.Click += new System.EventHandler(this.openBlueprintToolStripMenuItem_Click);
            // 
            // saveBlueprintToolStripMenuItem
            // 
            this.saveBlueprintToolStripMenuItem.Name = "saveBlueprintToolStripMenuItem";
            resources.ApplyResources(this.saveBlueprintToolStripMenuItem, "saveBlueprintToolStripMenuItem");
            this.saveBlueprintToolStripMenuItem.Click += new System.EventHandler(this.saveBlueprintToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.polskiToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // polskiToolStripMenuItem
            // 
            this.polskiToolStripMenuItem.Name = "polskiToolStripMenuItem";
            resources.ApplyResources(this.polskiToolStripMenuItem, "polskiToolStripMenuItem");
            this.polskiToolStripMenuItem.Click += new System.EventHandler(this.polskiToolStripMenuItem_Click);
            // 
            // RoomPlanner
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "RoomPlanner";
            this.Load += new System.EventHandler(this.RoomPlanner_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RoomPlanner_KeyDown);
            this.Resize += new System.EventHandler(this.splitContainer_Panel1_Resize);
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
        private System.Windows.Forms.ToolStripMenuItem openBlueprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveBlueprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polskiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
    }
}

