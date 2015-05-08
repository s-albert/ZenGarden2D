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
	public partial class DialogOptions : System.Windows.Forms.Form
    {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DialogOptions()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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

        private void DialogOptions_Load(object sender, System.EventArgs e)
		{
			this.numericUpDownAbstand.Value = Ground.Prefs.Abstand;
			this.numericUpDownZinken.Value = Ground.Prefs.Zinken;
			this.numericUpDownAussen.Value = Ground.Prefs.Aussen;
			this.numericUpDownMaxFarbe.Value = Ground.Prefs.MaxFarbe;
			this.numericUpDownRandomFarbe.Value = Ground.Prefs.RandomFarbe;
			this.numericUpDownStufenFarbe.Value = Ground.Prefs.StufenFarbe;
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			Ground.Prefs.Abstand = (int)this.numericUpDownAbstand.Value;
			Ground.Prefs.Zinken = (int)this.numericUpDownZinken.Value;
			Ground.Prefs.Aussen = (int)this.numericUpDownAussen.Value;
			Ground.Prefs.MaxFarbe = (int)this.numericUpDownMaxFarbe.Value;
			Ground.Prefs.RandomFarbe = (int)this.numericUpDownRandomFarbe.Value;
			Ground.Prefs.StufenFarbe = (int)this.numericUpDownStufenFarbe.Value;
		}

		private void buttonStandard_Click(object sender, System.EventArgs e)
		{
			Ground.Prefs = new Preferences();
			DialogOptions_Load(this, EventArgs.Empty);
		}

		private void numericUpDown_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (sender.GetType() != typeof(NumericUpDown))
				throw new ApplicationException("Control must be NumericUpDown");
			NumericUpDown n = (NumericUpDown)sender;
			if (n.Value > n.Maximum) n.Value = n.Maximum;
			else if (n.Value < n.Minimum) n.Value = n.Minimum;
		}
	}
}
