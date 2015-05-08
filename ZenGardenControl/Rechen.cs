using System;
using System.Drawing;
using System.Collections;

namespace WebMoment.ZenGarden
{

	public class Rechen
	{
		
		internal System.Drawing.Point m_Position;
		internal System.Drawing.Point m_LastPosition;
		internal System.Drawing.Point m_AktuellPosition;

		internal const double m_TurnSpeed = 0.01;
		internal const double m_TurnSpeedFast = 0.03;
		internal double m_Richtung;
		internal StoneCollection m_Stones;
		internal Ground m_Ground;
		
		public Rechen(Ground oGround, StoneCollection oStones)
		{
			m_Ground = oGround;
			m_Stones = oStones;
			m_LastPosition = new System.Drawing.Point(- 1, - 1);
			m_Position = new System.Drawing.Point(new System.Drawing.Size(m_LastPosition));
			m_AktuellPosition = new System.Drawing.Point(new System.Drawing.Size(m_LastPosition));
			m_Richtung = 3 * System.Math.PI / 2;
		}
		
		public virtual void  moveTo(int x, int y)
		{
			m_LastPosition.X = m_Position.X;
			m_LastPosition.Y = m_Position.Y;
			
			m_Position.X = x;
			m_Position.Y = y;
			
			m_AktuellPosition.X = x;
			m_AktuellPosition.Y = y;
		}
		
		public virtual void  moveTo()
		{
			m_LastPosition.X = m_AktuellPosition.X;
			m_LastPosition.Y = m_AktuellPosition.Y;
			m_Position.X = m_LastPosition.X;
			m_Position.Y = m_LastPosition.Y;
		}


		
		public virtual void  stop(int x, int y)
		{
			m_Position.X = - 1;
			m_LastPosition.X = - 1;
			m_AktuellPosition.X = x;
			m_AktuellPosition.Y = y;
		}
		
		public virtual void  stop()
		{
			m_Position.X = - 1;
			m_LastPosition.X = - 1;
		}
		
		public virtual void  turnLeft(bool bFast)
		{
			if (bFast)
				m_Richtung -= m_TurnSpeedFast;
			else
				m_Richtung -= m_TurnSpeed;
			if (m_Richtung >= 2 * System.Math.PI)
				m_Richtung += 2 * System.Math.PI;
		}

		public virtual void  turn(int speed)
		{
			m_Richtung += (double)speed / 2000;
			if (m_Richtung < 0)
				m_Richtung -= 2 * System.Math.PI;
			else if (m_Richtung >= 2 * System.Math.PI)
				m_Richtung += 2 * System.Math.PI;
		}
		
		public virtual void  turnRight(bool bFast)
		{
			if (bFast)
				m_Richtung += m_TurnSpeedFast;
			else
				m_Richtung += m_TurnSpeed;
			if (m_Richtung < 0)
				m_Richtung -= 2 * System.Math.PI;
		}
		
		public virtual bool paintSpur(System.Drawing.Graphics g, bool shift)
		{
			if (m_LastPosition.X >= 0)
			{
				//UPGRADE_TODO: Method 'java.lang.Math.round' was converted to 'System.Math.Round' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073"'
				int xRechenEnde = (int) System.Math.Round(System.Math.Cos(m_Richtung) * Ground.Prefs.Zinken * Ground.Prefs.Abstand);
				//UPGRADE_TODO: Method 'java.lang.Math.round' was converted to 'System.Math.Round' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073"'
				int yRechenEnde = (int) System.Math.Round(System.Math.Sin(m_Richtung) * Ground.Prefs.Zinken * Ground.Prefs.Abstand);
				bool bCollision = false;
				int n = 0;
				while ((!bCollision) && (m_Stones[n] != null) && (!m_Stones[n].Deleted))
				{
					bCollision = ((m_Stones[n].contains(m_Position.X, m_Position.Y)) || (m_Stones[n].contains(m_Position.X + xRechenEnde, m_Position.Y + yRechenEnde)));
					n++;
				}
				if (!bCollision)
				{
					for (int i = 0; i < Ground.Prefs.Zinken; i++)
					{
						int Abstand = Ground.Prefs.Abstand;
						if (shift)
						// Äußere Ränder verbeitern
						{
							if ((i == 0) || (i == Ground.Prefs.Zinken - 1))
							{
								Abstand += Ground.Prefs.Aussen;
							}
							else if ((i == 0) || (i == Ground.Prefs.Zinken - 2))
							{
								Abstand -= Ground.Prefs.Aussen;
							}
						}
						
						for (int j = 0; j < Abstand; j++)
						{
							int iFarbe = 0;
							
							if (m_Richtung < System.Math.PI)
							{
								//UPGRADE_TODO: Method 'java.lang.Math.round' was converted to 'System.Math.Round' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073"'
								iFarbe = System.Math.Min((int) System.Math.Round(Ground.Prefs.RandomFarbe * SupportClass.Random.NextDouble()) + Ground.Prefs.StufenFarbe / (Abstand - j), Ground.Prefs.MaxFarbe);
							}
							else
							{
								//UPGRADE_TODO: Method 'java.lang.Math.round' was converted to 'System.Math.Round' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073"'
								iFarbe = System.Math.Min((int) System.Math.Round(Ground.Prefs.RandomFarbe * SupportClass.Random.NextDouble()) + Ground.Prefs.StufenFarbe / (j + 1), Ground.Prefs.MaxFarbe);
							}
							SupportClass.GraphicsManager.Manager.SetColor(g, System.Drawing.Color.FromArgb(iFarbe, iFarbe, iFarbe));
							int BerechneAbstand = Ground.Prefs.Abstand;
							if ((i == 1) && (Ground.Prefs.Abstand != Abstand))
								BerechneAbstand = Ground.Prefs.Abstand + Ground.Prefs.Aussen;
							// sonst wird 1.breite Spur überschrieben
							//UPGRADE_TODO: Method 'java.lang.Math.round' was converted to 'System.Math.Round' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073"'
							int xOffset = (int) System.Math.Round(System.Math.Cos(m_Richtung) * (i * BerechneAbstand + j));
							//UPGRADE_TODO: Method 'java.lang.Math.round' was converted to 'System.Math.Round' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073"'
							int yOffset = (int) System.Math.Round(System.Math.Sin(m_Richtung) * (i * BerechneAbstand + j));
							if (m_LastPosition == m_Position)
							{
								m_LastPosition.X--;
							}
								
							g.DrawLine(SupportClass.GraphicsManager.Manager.GetPen(g), m_LastPosition.X + xOffset, m_LastPosition.Y + yOffset, m_Position.X + xOffset, m_Position.Y + yOffset);
						}
					}
				}
				return bCollision;
			}
			return true;
		}
		
		public virtual void  paintRechen(System.Drawing.Graphics g)
		{
			Brush brush;
			if (m_LastPosition.X >= 0)
				brush = Brushes.Red;
			else
				brush = Brushes.Peru;

			int xEnd = (int) System.Math.Round(m_AktuellPosition.X + System.Math.Cos(m_Richtung) * Ground.Prefs.Zinken * Ground.Prefs.Abstand);
			int yEnd = (int) System.Math.Round(m_AktuellPosition.Y + System.Math.Sin(m_Richtung) * Ground.Prefs.Zinken * Ground.Prefs.Abstand);

			g.DrawLine(new Pen(brush, 8),  
				m_AktuellPosition.X, m_AktuellPosition.Y, 
				xEnd, 
				yEnd);
			g.DrawLine(new Pen(Brushes.SandyBrown, 3),  
				m_AktuellPosition.X, m_AktuellPosition.Y, 
				xEnd, 
				yEnd);

		}
	}
}