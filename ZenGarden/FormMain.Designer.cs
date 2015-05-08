namespace WebMoment.ZenGarden
{
    public partial class FormMain
    {
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gardenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNewWithSize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemStone = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemInstructions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ground = new WebMoment.ZenGarden.Ground();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            resources.ApplyResources(this.mainMenu1, "mainMenu1");
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gardenToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // gardenToolStripMenuItem
            // 
            resources.ApplyResources(this.gardenToolStripMenuItem, "gardenToolStripMenuItem");
            this.gardenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNew,
            this.menuItemNewWithSize,
            this.toolStripSeparator1,
            this.menuItemExit});
            this.gardenToolStripMenuItem.Name = "gardenToolStripMenuItem";
            // 
            // menuItemNew
            // 
            resources.ApplyResources(this.menuItemNew, "menuItemNew");
            this.menuItemNew.Image = global::WebMoment.ZenGarden.ResourceStrings.NewDocumentHS;
            this.menuItemNew.Name = "menuItemNew";
            this.menuItemNew.Click += new System.EventHandler(this.menuItemNew_Click);
            // 
            // menuItemNewWithSize
            // 
            resources.ApplyResources(this.menuItemNewWithSize, "menuItemNewWithSize");
            this.menuItemNewWithSize.Name = "menuItemNewWithSize";
            this.menuItemNewWithSize.Click += new System.EventHandler(this.menuItemNewWithSize_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // menuItemExit
            // 
            resources.ApplyResources(this.menuItemExit, "menuItemExit");
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // editToolStripMenuItem
            // 
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUndo,
            this.menuItemRedo,
            this.toolStripSeparator2,
            this.menuItemStone});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.menuItemEdit_Popup);
            // 
            // menuItemUndo
            // 
            resources.ApplyResources(this.menuItemUndo, "menuItemUndo");
            this.menuItemUndo.Image = global::WebMoment.ZenGarden.ResourceStrings.Edit_UndoHS;
            this.menuItemUndo.Name = "menuItemUndo";
            this.menuItemUndo.Click += new System.EventHandler(this.menuItemUndo_Click);
            // 
            // menuItemRedo
            // 
            resources.ApplyResources(this.menuItemRedo, "menuItemRedo");
            this.menuItemRedo.Image = global::WebMoment.ZenGarden.ResourceStrings.Edit_RedoHS;
            this.menuItemRedo.Name = "menuItemRedo";
            this.menuItemRedo.Click += new System.EventHandler(this.menuItemRedo_Click);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // menuItemStone
            // 
            resources.ApplyResources(this.menuItemStone, "menuItemStone");
            this.menuItemStone.Name = "menuItemStone";
            this.menuItemStone.Click += new System.EventHandler(this.menuItemStone_Click);
            // 
            // viewToolStripMenuItem
            // 
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemRefresh});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            // 
            // menuItemRefresh
            // 
            resources.ApplyResources(this.menuItemRefresh, "menuItemRefresh");
            this.menuItemRefresh.Name = "menuItemRefresh";
            this.menuItemRefresh.Click += new System.EventHandler(this.menuItemRefresh_Click);
            // 
            // toolsToolStripMenuItem
            // 
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClipboard,
            this.toolStripSeparator3,
            this.menuItemOptions});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            // 
            // menuItemClipboard
            // 
            resources.ApplyResources(this.menuItemClipboard, "menuItemClipboard");
            this.menuItemClipboard.Name = "menuItemClipboard";
            this.menuItemClipboard.Click += new System.EventHandler(this.menuItemClipboard_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // menuItemOptions
            // 
            resources.ApplyResources(this.menuItemOptions, "menuItemOptions");
            this.menuItemOptions.Image = global::WebMoment.ZenGarden.ResourceStrings.OptionsHS;
            this.menuItemOptions.Name = "menuItemOptions";
            this.menuItemOptions.Click += new System.EventHandler(this.menuItemOptions_Click);
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemInstructions,
            this.toolStripSeparator4,
            this.menuItemInfo});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // menuItemInstructions
            // 
            resources.ApplyResources(this.menuItemInstructions, "menuItemInstructions");
            this.menuItemInstructions.Image = global::WebMoment.ZenGarden.ResourceStrings.Help;
            this.menuItemInstructions.Name = "menuItemInstructions";
            this.menuItemInstructions.Click += new System.EventHandler(this.menuItemInstructions_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // menuItemInfo
            // 
            resources.ApplyResources(this.menuItemInfo, "menuItemInfo");
            this.menuItemInfo.Name = "menuItemInfo";
            this.menuItemInfo.Click += new System.EventHandler(this.menuItemInfo_Click);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Image = global::WebMoment.ZenGarden.ResourceStrings.Information;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // ground
            // 
            resources.ApplyResources(this.ground, "ground");
            this.ground.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ground.ImageBuffer = ((System.Drawing.Bitmap)(resources.GetObject("ground.ImageBuffer")));
            this.ground.Name = "ground";
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ground);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Menu = this.mainMenu1;
            this.Name = "FormMain";
            this.Closed += new System.EventHandler(this.FormMain_Closed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MainMenu mainMenu1;
        private WebMoment.ZenGarden.Ground ground;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gardenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemNew;
        private System.Windows.Forms.ToolStripMenuItem menuItemNewWithSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemUndo;
        private System.Windows.Forms.ToolStripMenuItem menuItemRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuItemStone;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemClipboard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuItemOptions;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemInstructions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuItemInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}
