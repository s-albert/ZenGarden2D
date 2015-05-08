namespace WebMoment.ZenGarden
{
    public partial class Ground
    {
        private void InitializeComponent()
        {
            // 
            // Ground
            // 
            this.Name = "Ground";
            this.Size = new System.Drawing.Size(520, 448);
            this.Click += new System.EventHandler(this.Ground_Click);
            this.Resize += new System.EventHandler(this.Ground_Resize);
            this.Load += new System.EventHandler(this.Ground_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Ground_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Ground_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ground_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ground_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ground_MouseDown);


        }
    }
}
