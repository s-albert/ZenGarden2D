using System;
using System.Drawing;

namespace WebMoment.ZenGarden
{
	
	public class Stone
	{
		virtual public bool Deleted
		{
			get
			{
				return m_bDelete;
			}
			
		}
		
		internal int[] m_EckeX;
		internal int[] m_EckeY;
		internal int m_iEcken;
		internal bool m_bZeichenMode;
		internal System.Drawing.Drawing2D.GraphicsPath m_Polygon;
		internal System.Drawing.Point[] m_Points;
		internal Ground m_Ground;
		internal System.Drawing.Color[] m_Colors;
		internal bool m_bPainted;
		internal bool m_bDelete;
		internal int iMaxColors = 50;
		internal int iMaxEcken = 60;
		internal int m_MaxFarbe = 220;
		internal int m_RandomFarbe = 140;
		internal int m_MinFarbe = 80;
		
		public Stone(Ground oGround)
		{
			m_bZeichenMode = true;
			m_iEcken = 0;
			m_Ground = oGround;
			m_bPainted = false;
			m_bDelete = false;
			m_EckeX = new int[iMaxEcken];
			m_EckeY = new int[iMaxEcken];
			m_Colors = new System.Drawing.Color[iMaxColors + 1];
		}
		
		public virtual void  newEdge(int x, int y)
		{
			if ((m_bZeichenMode) && (m_iEcken < iMaxEcken / 2))
			{
				m_EckeX[m_iEcken] = x;
				m_EckeY[m_iEcken] = y;
				m_iEcken++;
			}
		}
		
		public virtual void  delete(bool repaint)
		{
			m_bDelete = true;
			if (repaint)
				m_bPainted = false;
		}
		
		public virtual void  unDelete()
		{
			m_bDelete = false;
			m_bPainted = false;
		}
		
		
		public virtual void  finish()
		{
			m_bZeichenMode = false;
			//UPGRADE_TODO: Constructor 'java.awt.Polygon.Polygon' was converted to 'SupportClass.CreateGraphicsPath' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073_javaawtPolygonPolygon_int[]_int[]_int"'
			m_Polygon = SupportClass.CreateGraphicsPath(m_EckeX, m_EckeY, m_iEcken);
			int i = 0;
			for (; i <= iMaxColors; i++)
			{
				//UPGRADE_TODO: Method 'java.lang.Math.round' was converted to 'System.Math.Round' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073"'
				int iFarbe = System.Math.Min((int) System.Math.Round(m_RandomFarbe * SupportClass.Random.NextDouble()) + m_MinFarbe, m_MaxFarbe);
				m_Colors[i] = System.Drawing.Color.FromArgb(iFarbe, iFarbe, iFarbe);
			}
			for (i = m_iEcken; i < m_iEcken * 2; i++)
			{
				int x, y;
				do 
				{
					//UPGRADE_TODO: Method 'java.lang.Math.round' was converted to 'System.Math.Round' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073"'
					x = (int) System.Math.Round(SupportClass.Random.NextDouble() * m_Ground.Size.Width);
					//UPGRADE_TODO: Method 'java.lang.Math.round' was converted to 'System.Math.Round' which has a different behavior. 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="jlca1073"'
					y = (int) System.Math.Round(SupportClass.Random.NextDouble() * m_Ground.Size.Height);
				}
				while (!m_Polygon.IsVisible(x, y));
				m_EckeX[i] = x;
				m_EckeY[i] = y;
			}
		}
		
		public virtual bool contains(int x, int y)
		{
			if (m_Polygon != null)
				return m_Polygon.IsVisible(x, y);
			else
				return false;
		}
		
		public virtual void  invalidate()
		{
			m_bPainted = false;
		}
		
		public virtual void  paint(System.Drawing.Graphics g)
		{
			//    Graphics2D g2 = (Graphics2D) g;
			SupportClass.GraphicsManager.Manager.SetColor(g, System.Drawing.Color.DarkGray);
			if (m_bZeichenMode)
			{
				SupportClass.GraphicsManager.Manager.SetColor(g, System.Drawing.Color.Black);
				if (m_iEcken > 1)
					g.DrawLines(Pens.White, SupportClass.GetPoints(m_EckeX, m_EckeY, m_iEcken));
			}
			else if (!m_bPainted)
			{
				System.Windows.Forms.Cursor temp_Cursor;
				temp_Cursor = new System.Windows.Forms.Cursor(new System.IntPtr(1));
				temp_Cursor = m_Ground.Cursor;
				System.Windows.Forms.Cursor oCursor = temp_Cursor;
				System.Windows.Forms.Cursor temp_Cursor2;
				temp_Cursor2 = System.Windows.Forms.Cursors.WaitCursor;
				m_Ground.Cursor = temp_Cursor2;
				SupportClass.GraphicsManager.Manager.SetColor(g, System.Drawing.Color.Gray);
				int i = 0;
				for (int x1 = 0; x1 < m_iEcken * 2; x1++)
					for (int x2 = 1; x2 < m_iEcken * 2 - 1; x2++)
						for (int x3 = 2; x3 < m_iEcken * 2 - 2; x3++)
						{
							if ((x1 != x2) && (x1 != x3) && (x2 != x3))
							{
								if (!m_bDelete)
								{
									if (i >= iMaxColors)
										i = 0;
									
									SupportClass.GraphicsManager.Manager.SetColor(g, m_Colors[i]);
									/*
									GradientPaint gp = new GradientPaint(new Point(m_EckeX[0],m_EckeY[0]),
									m_Colors[i],new Point(m_EckeX[m_iEcken*2-1],m_EckeY[m_iEcken*2-1]),m_Colors[i+1]);
									g2.setPaint(gp);*/
									i++;
								}
								int[] xPoints = new int[3];
								xPoints[0] = m_EckeX[x1];
								xPoints[1] = m_EckeX[x2];
								xPoints[2] = m_EckeX[x3];
								int[] yPoints = new int[3];
								yPoints[0] = m_EckeY[x1];
								yPoints[1] = m_EckeY[x2];
								yPoints[2] = m_EckeY[x3];
								g.FillPath(SupportClass.GraphicsManager.Manager.GetBrush(g), SupportClass.CreateGraphicsPath(xPoints, yPoints, 3));
							}
						}
				m_bPainted = true;
				m_Ground.Cursor = oCursor;
			}
		}
	}
}