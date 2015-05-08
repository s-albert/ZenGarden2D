using System;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace WebMoment.ZenGarden
{
	/// <summary>
	/// Liste aller Resourcestring - Namen (damit werden Tippfehler schon zur Compilezeit erkannt)
	/// </summary>
	public enum EnumStrings
	{
		/// <summary>Application error</summary>
		AppError,
		/// <summary>Paypal</summary>
		Paypal,
		/// <summary>Photo</summary>
		Photo,
		/// <summary>Description</summary>
		Description
	};

	
	/// <summary>
	/// Der LocalizationMgr ermöglicht den Zugriff auf Strings über Stringtabellen. Zusätzlich können noch unterschiedliche Sprachen angeboten werden.
	/// </summary>
	public class Strings 
	{
		static ResourceManager rMgr;
		/// <summary>
		/// Returns ResourceManager singleton object.
		/// </summary>
		public static ResourceManager ResMgr 
		{
			get 
			{
				if (rMgr == null) 
				{
					Type thisType = typeof(Strings);
					rMgr = new ResourceManager(thisType.Namespace + ".ResourceStrings", thisType.Assembly);
				}
				return rMgr;
			}
		}

		/// <summary>
		/// Tries to retrieve the resource for the provided key.
		/// </summary>
		/// <param name="key"></param>
		/// <returns>Returns the localized string or if not found the key itself.</returns>
		public static string Get(EnumStrings key) 
		{
			string res = ResMgr.GetString(key.ToString());
			if (res == null) 
			{
				res = key.ToString();
			}
			return res;
		}

		/// <summary>
		/// Sets the UI culture.
		/// </summary>
		/// <param name="uiCultureName">
		/// The name follows the RFC 1766 standard in the 
		/// format "[languagecode2]-[country/regioncode2]". 
		/// E.g.: "de-GER" for the language German, country Germany; 
		/// or "de" for all german speaking countries.
		/// </param>
		public static void SetCulture(string uiCultureName) 
		{
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(uiCultureName);
		}
	}
}
