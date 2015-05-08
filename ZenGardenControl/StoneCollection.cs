using System;
using System.Collections;
using System.Xml.Serialization;

namespace WebMoment.ZenGarden
{
	/// <summary>
	/// Summary description for StoneCollection.
	/// </summary>
	[Serializable]
	[XmlInclude(typeof(Stone))]
	public class StoneCollection : ICollection, IEnumerable  
	{
		private ArrayList _Stones = new ArrayList();

		/// <summary>
		/// Collection of Stones
		/// </summary>
		public StoneCollection()
		{
		}

		/// <summary>
		/// Verifies the index
		/// </summary>
		/// <param name="index">Index to test</param>
		/// <returns>True if the index is in range</returns>
		public bool IsValid(int index)
		{
			return (index >= 0) && (index < this.Count);
		}

		/// <summary>
		/// Number of Stones
		/// </summary>
		public int Count { get { return _Stones.Count; } }

		/// <summary>
		/// True if synchronized
		/// </summary>
		public bool IsSynchronized { get { return _Stones.IsSynchronized; } }

		/// <summary>
		/// SyncRoot
		/// </summary>
		public object SyncRoot { get { return _Stones.SyncRoot; } }

		/// <summary>
		/// Copies Stones
		/// </summary>
		/// <param name="a"></param>
		/// <param name="i"></param>
		public void CopyTo( Array a, int i ){ _Stones.CopyTo( a, i ); }

		// IEnumerable

		/// <summary>
		/// Gets the enumerator
		/// </summary>
		/// <returns>Enumerator</returns>
		public IEnumerator GetEnumerator()
		{
			return _Stones.GetEnumerator(); 
		}

		/// <summary>
		///  Default indexer
		/// </summary>
		public Stone this[int index]               
		{                                    
			get 
			{
				if (this._Stones.Count > index)
					return (Stone)this._Stones[index];
				else
					return null;
			}
                              
		}                                   

		public void Insert(int index, Stone s)
		{
			if (this._Stones.Count > index)
				_Stones.Insert(index,s);
			else
				Add(s);
		}
		

		/// <summary>
		/// Adds one Stone
		/// </summary>
		/// <param name="stoneInsert">Stone</param>
		public void Add( Stone stoneInsert)
		{ 
				_Stones.Add(stoneInsert);
		}

		/// <summary>
		/// Removes one Stone
		/// </summary>
		/// <param name="i">Index</param>
		public void RemoveAt(int i)
		{
			if (i > 0)
				_Stones.RemoveAt(i);
		}



		/// <summary>
		/// Clears all Stones
		/// </summary>
		public void Clear()
		{
			_Stones.Clear();
		}
	}
}
