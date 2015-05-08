using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Threading;
using System.Diagnostics;

namespace WebMoment.ZenGarden
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public partial class FormMain : System.Windows.Forms.Form
    {

        internal const string Applicationname = "Zen Garden";

		private const string APPICON = "ZenGarden.ICO";


		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			readPreferences();
		}

		private bool readPreferences()
		{
			FileStream isoFile = null;

			try
			{
				isoFile = new FileStream(System.Environment.GetFolderPath(
					System.Environment.SpecialFolder.ApplicationData) + 
					Path.DirectorySeparatorChar + 
					Preferences.FILENAME, FileMode.Open);

				XmlSerializer serializer = new XmlSerializer(typeof(Preferences));
				Ground.Prefs = (Preferences) serializer.Deserialize(isoFile);
				return true;
			}
			catch(Exception)
			{	// no action
				Ground.Prefs = new Preferences();
				return false;
			}
			finally
			{
				if (isoFile != null) isoFile.Close();
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

        #endregion

        /// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            Application.EnableVisualStyles();

			try
			{
				Application.Run(new FormMain());
			}
			catch (Exception e1)
			{
				MessageBox.Show(e1.Message, "Error");
			}
		}

		private void menuItemRefresh_Click(object sender, System.EventArgs e)
		{
			ground.Repaint();
		}

		private void menuItemNew_Click(object sender, System.EventArgs e)
		{
			ground.New();
		}

		private void menuItemNewWithSize_Click(object sender, System.EventArgs e)
		{
			DialogSize dlg = new DialogSize(this.Width,this.Height);
			if (DialogResult.OK == dlg.ShowDialog(this))
			{
				this.Size = new Size(dlg.GardenWidth,dlg.GardenHeight);
			}
		}

		private void menuItemExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void menuItemOptions_Click(object sender, System.EventArgs e)
		{
			DialogOptions dlg = new DialogOptions();
			dlg.ShowDialog(this);
		}

		private void menuItemUndo_Click(object sender, System.EventArgs e)
		{
			ground.Undo();
		}

		private void menuItemRedo_Click(object sender, System.EventArgs e)
		{	
			ground.Redo();
		
		}

		private void menuItemEdit_Popup(object sender, System.EventArgs e)
		{
			this.menuItemUndo.Enabled = ground.CanUndo();
			this.menuItemRedo.Enabled = ground.CanRedo();
		}

		private void menuItemStone_Click(object sender, System.EventArgs e)
		{
			ground.BuildStone();
		}

		private void menuItemClipboard_Click(object sender, System.EventArgs e)
		{
			if (ground.ImageBuffer != null)
			{
				IDataObject ido = new DataObject();
				ido.SetData(DataFormats.Bitmap, true, ground.ImageBuffer);
				Clipboard.SetDataObject(ido, true);
				MessageBox.Show(this,Strings.Get(EnumStrings.Photo),"Click",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		private void FormMain_Closed(object sender, System.EventArgs e)
		{
			Ground.Prefs.Save();
		}

        private void menuItemInstructions_Click(object sender, EventArgs e)
        {
            try
            {
                if (Thread.CurrentThread.CurrentUICulture.IsNeutralCulture)
                    Process.Start(@"Resources\Help.en.pdf");
                else
                    Process.Start(@"Resources\Help.de.pdf");
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void menuItemInfo_Click(object sender, EventArgs e)
        {
            Essy.Controls.AboutForm form = new Essy.Controls.AboutForm((Image)new Bitmap("ZenGarden.ICO"));
            form.ControlBox = false;
            form.ShowDialog(this);
        }
    }
}
