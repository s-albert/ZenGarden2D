using System;
	
namespace WebMoment.ZenGarden
{
	public class Grass
	{
		internal int m_Mode;
		internal int m_xRadius;
		internal int m_yRadius;
		internal System.Drawing.Point m_Startpunkt;
		internal System.Drawing.Color m_Color;
		internal const int m_MinGreen = 80;
		internal const int m_RandomGreen = 50;
		internal const int m_RandomOther = 50;
		
		public Grass()
		{
			m_Mode = 0;
			m_xRadius = 0;
			m_yRadius = 0;
			m_Startpunkt = new System.Drawing.Point(0, 0);
			m_Color = System.Drawing.Color.FromArgb(0, 0, 0);
		}
		
		public virtual void  plan(int x, int y)
		{
			m_Mode = 1;
			m_Startpunkt.X = x;
			m_Startpunkt.Y = y;
			int green = (int) System.Math.Round(SupportClass.Random.NextDouble() * m_RandomGreen + m_MinGreen);
			int other = (int) System.Math.Round(SupportClass.Random.NextDouble() * m_RandomOther);
			m_Color = System.Drawing.Color.FromArgb(other, green, other);
		}
		
		public virtual void  plant(int x, int y)
		{
			resize(x, y);
			m_Mode = 2;
		}
		
		public virtual void  resize(int x, int y)
		{
			m_xRadius = System.Math.Abs(m_Startpunkt.X - x);
			m_yRadius = System.Math.Abs(m_Startpunkt.Y - y);
		}
		
		public virtual void  paintTemp(System.Drawing.Graphics g)
		{
			if (m_Mode == 1)
			{
				SupportClass.GraphicsManager.Manager.SetColor(g, m_Color);
				g.DrawEllipse(SupportClass.GraphicsManager.Manager.GetPen(g), m_Startpunkt.X, m_Startpunkt.Y, m_xRadius, m_yRadius);
			}
		}
		
		public virtual void  delete()
		{
			m_Mode = 3;
		}
		
		public virtual void  paint(System.Drawing.Graphics gHintergrund)
		{
			if (m_Mode == 2)
			{
				SupportClass.GraphicsManager.Manager.SetColor(gHintergrund, m_Color);
				gHintergrund.FillEllipse(SupportClass.GraphicsManager.Manager.GetBrush(gHintergrund), m_Startpunkt.X, m_Startpunkt.Y, m_xRadius, m_yRadius);
				m_Mode = 3;
			}
		}
	}
}