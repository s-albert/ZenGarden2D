using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Collections;
	
namespace WebMoment.ZenGarden
{
	enum EnumMode {Normal, Stone, Grass};

	public partial class Ground:System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        private System.ComponentModel.Container components = null;
	

		internal bool isStandalone = false;
		internal System.Drawing.Bitmap m_Hintergrund;

		private System.Drawing.Bitmap mImageBuffer;

		public System.Drawing.Bitmap ImageBuffer
		{
			get
			{
				return (this.mImageBuffer);
			}
			set
			{
				this.mImageBuffer = value;
			}
		}

		internal Rechen m_Rechen;
		internal StoneCollection m_Stones;
		internal EnumMode m_Mode; 
		internal int m_iStones;
		internal System.Windows.Forms.Cursor m_StoneCursor;
		internal System.Windows.Forms.Cursor m_RechenCursor;
		internal System.Windows.Forms.Cursor m_GrassCursor;
		internal Grass m_Grass;

		
		private static Preferences mPrefs = new Preferences();

		public static Preferences Prefs
		{
			get
			{
				return (mPrefs);
			}
			set
			{
				mPrefs = value;
			}
		}

	
		
		/// <summary>Construct the applet
		/// </summary>
		public Ground()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Ground_MouseWheel);


			this.SetStyle(ControlStyles.DoubleBuffer | 
				ControlStyles.UserPaint | 
				ControlStyles.AllPaintingInWmPaint,
				true);
			this.UpdateStyles();

			New();

			m_Rechen = new Rechen(this, m_Stones);
			m_Grass = new Grass();
			System.Windows.Forms.Cursor temp_Cursor;
			temp_Cursor = System.Windows.Forms.Cursors.Cross;
			m_RechenCursor = temp_Cursor;
			System.Windows.Forms.Cursor temp_Cursor2;
			temp_Cursor2 = System.Windows.Forms.Cursors.Hand;
			m_StoneCursor = temp_Cursor2;
			System.Windows.Forms.Cursor temp_Cursor3;
			temp_Cursor3 = System.Windows.Forms.Cursors.SizeAll;
			m_GrassCursor = temp_Cursor3;


		}

		private void Ground_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				
				case Keys.F3: 
					m_Rechen.turnLeft(Ground.ModifierKeys == Keys.Control);
					if (Ground.MouseButtons == MouseButtons.Left)
						m_Rechen.moveTo();
					Refresh(); break;
				
				case Keys.F4: 
					if (Ground.MouseButtons == MouseButtons.Left)
						m_Rechen.moveTo();
					m_Rechen.turnRight(Ground.ModifierKeys == Keys.Control);
					Refresh(); break;
				
				case Keys.Space: 
					BuildStone();
					Refresh();
					break;
				
			}
		}

		private void Ground_Resize(object sender, System.EventArgs e)
		{
			ImageBuffer = null;
			Refresh();
		}

		private void Ground_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (m_Mode == EnumMode.Grass)
			{
				m_Grass.plant(e.X, e.Y);
				m_Mode = 0;
				Cursor = m_RechenCursor;
			}
		}

		private void Ground_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if ((m_Mode == 0) && (Ground.ModifierKeys == Keys.Alt))
			{
				m_Grass.plan(e.X, e.Y);
				Cursor = m_GrassCursor;
				m_Mode = EnumMode.Grass;
				Refresh();
			}
		}

		private void Ground_Load(object sender, System.EventArgs e)
		{
			start();
		}

		private void Ground_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{

			m_Rechen.turn(e.Delta);

			if (Ground.MouseButtons == MouseButtons.Left)
				m_Rechen.moveTo();
			Refresh();
		}


		private void Ground_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (Ground.MouseButtons != MouseButtons.Left)
			{
				if (m_Mode == EnumMode.Normal)
					m_Rechen.stop(e.X, e.Y);
				Refresh();
			}
			else
			{
				if (m_Mode == EnumMode.Normal)
					m_Rechen.moveTo(e.X, e.Y);
				else if (m_Mode == EnumMode.Grass)
					m_Grass.resize(e.X, e.Y);
				Refresh();
			}
		}

		private void Ground_Click(object sender, System.EventArgs e)
		{
			if (m_Mode == EnumMode.Stone)
			{
				Point p = this.PointToClient(Ground.MousePosition);
				m_Stones[m_iStones - 1].newEdge(p.X, p.Y);
			}
			Refresh();	
		}



		private void drawSand()
		{
			System.Windows.Forms.Cursor temp_Cursor = this.Cursor;
			this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			m_Hintergrund = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
			ImageBuffer = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
									
			for (int i = 0; i < Size.Width; i++)
				for (int j = 0; j < Size.Height; j++)
				{
					int iFarbe = System.Math.Max((int) System.Math.Round(SupportClass.Random.NextDouble() * 250), 100);
					System.Drawing.Color c = System.Drawing.Color.FromArgb(iFarbe, iFarbe, iFarbe);
					m_Hintergrund.SetPixel(i, j, c);
				}
			Cursor = temp_Cursor;
		}

		private void Ground_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics graphicsBuffer; 

			if (ImageBuffer == null)
			{
				drawSand();
				graphicsBuffer = Graphics.FromImage(ImageBuffer);
				graphicsBuffer.DrawImage(this.m_Hintergrund,0,0);
			}
			else
				graphicsBuffer = Graphics.FromImage(ImageBuffer);

			
				if ((m_Mode == EnumMode.Normal) && 
					(m_Rechen.paintSpur(graphicsBuffer, Ground.ModifierKeys == Keys.Shift)) == false)
					m_Rechen.stop();
				
				m_Grass.paint(graphicsBuffer);
				
				int i2 = 0;
				for (; i2 < m_iStones; i2++)
					m_Stones[i2].paint(graphicsBuffer);
				while (m_Stones[i2] != null)
				{
					m_Stones[i2].paint(graphicsBuffer);
					i2++;
				}
				
				e.Graphics.DrawImage(this.ImageBuffer, 0, 0);

				if (m_Mode == EnumMode.Grass)
					m_Grass.paintTemp(e.Graphics);
				else if (m_Mode == 0)
					m_Rechen.paintRechen(e.Graphics);

		}

		
		//UPGRADE_TODO: The equivalent of method 'java.applet.Applet.start' is not an override method. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1143"'
		/// <summary>Start the applet
		/// </summary>
		public void  start()
		{
			Focus();
			Cursor = m_RechenCursor;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
				
		public void Repaint()
		{
			for (int i = 0; i < m_iStones; i++)
				m_Stones[i].invalidate();
			Refresh();
		}

		public void New()
		{
			ImageBuffer = null;
			m_iStones = 0;
			m_Stones = new StoneCollection();
			m_Mode = EnumMode.Normal;
			Cursor = m_RechenCursor;
		}

		public void Redo()
		{
			if (m_Stones[m_iStones] != null)
			{
				(m_Stones[m_iStones] as Stone).unDelete();
				m_iStones++;
				m_Mode = EnumMode.Normal;
				Cursor = m_RechenCursor;
				Refresh();
			}
		}

		public void Undo()
		{
			if (m_Mode == EnumMode.Grass)
			{
				m_Grass.delete();
				m_Mode = 0;
				Refresh();
			}
			else if (m_iStones > 0)
				// && (JOptionPane.showConfirmDialog(this,"Wollen Sie wirklich den letzten Stein entfernen ?",
				//   "Frage", JOptionPane.YES_NO_OPTION) == JOptionPane.YES_OPTION))
			{
				m_iStones--;
				(m_Stones[m_iStones] as Stone).invalidate();
				(m_Stones[m_iStones] as Stone).delete(true);
				m_Mode = 0;
				Cursor = m_RechenCursor;
				Refresh();
			}
		}

		public bool CanUndo()
		{
			return m_iStones > 0;
		}

		public bool CanRedo()
		{
			return m_iStones < m_Stones.Count;
		}

		public void BuildStone()
		{
			if (m_Mode != EnumMode.Stone)
			{
				m_Mode = EnumMode.Stone;
				Cursor = m_StoneCursor;
				m_Stones.Insert(m_iStones, new Stone(this));
				m_iStones++;
			}
			else if (m_Mode == EnumMode.Stone)
			{
				m_Stones[m_iStones - 1].finish();
				m_Mode = EnumMode.Normal;
				Cursor = m_RechenCursor;
			}
		}
	}
}