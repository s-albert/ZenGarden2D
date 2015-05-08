using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WebMoment.ZenGarden
{
	/// <summary>
	/// Summary description for DialogSize.
	/// </summary>
	public partial class DialogSize : System.Windows.Forms.Form
    {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DialogSize(int width, int height)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			GardenWidth = width;
			GardenHeight = height;
		}

		public int GardenWidth
		{
			get {return(int)this.numericUpDownWidth.Value;}
			set {this.numericUpDownWidth.Value = value;}
		}

		public int GardenHeight
		{
			get {return (int)this.numericUpDownHeight.Value;}
			set {this.numericUpDownHeight.Value = value;}
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

		#region Windows Form Designer generated code

        #endregion

    }
}
