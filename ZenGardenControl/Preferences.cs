using System;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace WebMoment.ZenGarden
{
	/// <summary>
	/// Summary description for Preferences.
	/// </summary>
	[Serializable]
	public class Preferences
	{
		public const string FILENAME = @"webMoment.ZenGarden.xml";

		public Preferences()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private int zinken = 9;
		[XmlAttribute]
		public int Zinken
		{
			get
			{
				return (this.zinken);
			}
			set
			{
				this.zinken = value;
				this.saved = false;
			}
		}

		private int abstand = 5;
		[XmlAttribute]
		public int Abstand
		{
			get
			{
				return (this.abstand);
			}
			set
			{
				this.abstand = value;
				this.saved = false;
			}
		}

		internal const int m_Aussen = 1;
		// Äußerer Rand ist um m_Aussen breiter

		private int aussen = 1;
		[XmlAttribute]
		public int Aussen
		{
			get
			{
				return (this.aussen);
			}
			set
			{
				this.aussen = value;
				this.saved = false;
			}
		}

		private int maxFarbe = 255;
		// Hellste Farbe der Spur
		[XmlAttribute]
		public int MaxFarbe
		{
			get
			{
				return (this.maxFarbe);
			}
			set
			{
				this.maxFarbe = value;
				this.saved = false;
			}
		}

		private int randomFarbe = 120;
		// Multiplikator für Zufallsfarbe
		[XmlAttribute]
		public int RandomFarbe
		{
			get
			{
				return (this.randomFarbe);
			}
			set
			{
				this.randomFarbe = value;
				this.saved = false;
			}
		}

		private int stufenFarbe = 180;
		// Divident für Farbstufen in den Rillen
		[XmlAttribute]
		public int StufenFarbe
		{
			get
			{
				return (this.stufenFarbe);
			}
			set
			{
				this.stufenFarbe = value;
				this.saved = false;
			}
		}

		private bool saved = false;
		[XmlIgnoreAttribute]
		public bool Saved
		{
			get
			{
				return (this.saved);
			}
			set
			{
				this.saved = value;
			}
		}



		/// <summary>
		/// Saves the prefs in XML format
		/// </summary>
		public void Save()
		{

			if (!this.saved)
			{
				FileStream isoFile = null;

				try
				{
					isoFile = new FileStream(System.Environment.GetFolderPath(
						System.Environment.SpecialFolder.ApplicationData) + 
						Path.DirectorySeparatorChar + 
						Preferences.FILENAME, FileMode.Create);

					XmlSerializer serializer = new XmlSerializer(typeof(Preferences));
					serializer.Serialize(isoFile, this);
					this.saved = true;
					// StreamWriter.Close implicitly closes isoStream.
				}
				catch (Exception e)
				{
					MessageBox.Show(e.ToString());
				}
				finally
				{
					if (isoFile != null)
					{
						isoFile.Close();
					}
				}
			}
		}
	}
}
