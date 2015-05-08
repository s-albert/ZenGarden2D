using System;
public class SupportClass
{
	private static System.Random mRandom = new System.Random();

	public static System.Random Random
	{
		get
		{
			return (mRandom);
		}
		set
		{
			mRandom = value;
		}
	}


	/*******************************/
	public class GraphicsManager
	{
		public static System.Drawing.Graphics CreateGraphics(System.Drawing.Graphics oldGraphics)
		{
			System.IntPtr hdc = oldGraphics.GetHdc();
			oldGraphics.ReleaseHdc(hdc);
			return System.Drawing.Graphics.FromHdc(hdc);
		}

		/// <summary>
		/// This method draws a Bezier curve.
		/// </summary>
		/// <param name="graphics">It receives the Graphics instance</param>
		/// <param name="array">An array of (x,y) pairs of coordinates used to draw the curve.</param>
		public static void Bezier(System.Drawing.Graphics graphics, int[] array)
		{
			System.Drawing.Pen pen;
			pen = GraphicsManager.Manager.GetPen(graphics);
			graphics.DrawBezier(pen, array[0], array[1], array[2], array[3], array[4], array[5], array[6], array[7]);
		}

		public static System.Drawing.Point GetTextSize(System.Drawing.Graphics graphics, System.Drawing.Font graphicsFont, System.String text)
		{
			System.Drawing.Point textSize;
			System.Drawing.SizeF tempSizeF;
			tempSizeF = graphics.MeasureString(text, graphicsFont);
			textSize = new System.Drawing.Point();
			textSize.X = (int) tempSizeF.Width;
			textSize.Y = (int) tempSizeF.Height;
			return textSize;
		}

		public static System.Drawing.Point GetTextSize(System.Drawing.Graphics graphics, System.Drawing.Font graphicsFont, System.String text, System.Int32 width, System.Drawing.StringFormat format)
		{
			System.Drawing.Point textSize;
			System.Drawing.SizeF tempSizeF;
			tempSizeF = graphics.MeasureString(text, graphicsFont, width, format);
			textSize = new System.Drawing.Point();
			textSize.X = (int) tempSizeF.Width;
			textSize.Y = (int) tempSizeF.Height;
			return textSize;
		}

		private static GraphicsHashTable mManager = new GraphicsHashTable();

		public static GraphicsHashTable Manager
		{
			get
			{
				return (mManager);
			}
			set
			{
				mManager = value;
			}
		}


		public class GraphicsHashTable:System.Collections.Hashtable 
		{
					
			public System.Drawing.Graphics GetGraphics(System.Windows.Forms.Control control)
			{
				System.Drawing.Graphics graphic;
				if (control.Visible == true)
				{
					graphic = control.CreateGraphics();
					if (this[graphic] == null)
					{
						GraphicsProperties tempProps = new GraphicsProperties();
						tempProps.color = control.ForeColor;
						tempProps.BackColor = control.BackColor;
						tempProps.TextColor = control.ForeColor;
						tempProps.GraphicFont = control.Font;
						Add(graphic, tempProps);
					}
				}
				else
				{
					graphic = null;
				}
				return graphic;
			}
					
			public void SetBackColor(System.Drawing.Graphics graphic, System.Drawing.Color color)
			{
				if (this[graphic] != null)
					((GraphicsProperties) this[graphic]).BackColor = color;
				else
				{
					GraphicsProperties tempProps = new GraphicsProperties();
					tempProps.BackColor = color;
					Add(graphic, tempProps);
				}
			}

			public System.Drawing.Color GetBackColor(System.Drawing.Graphics graphic)
			{
				if (this[graphic] == null)
					return System.Drawing.Color.White;
				else
					return ((GraphicsProperties) this[graphic]).BackColor;
			}

			public void SetTextColor(System.Drawing.Graphics graphic, System.Drawing.Color color)
			{
				if (this[graphic] != null)
					((GraphicsProperties) this[graphic]).TextColor = color;
				else
				{
					GraphicsProperties tempProps = new GraphicsProperties();
					tempProps.TextColor = color;
					Add(graphic, tempProps);
				}
			}

			public System.Drawing.Color GetTextColor(System.Drawing.Graphics graphic) 
			{
				if (this[graphic] == null)
					return System.Drawing.Color.White;
				else
					return ((GraphicsProperties) this[graphic]).TextColor;
			}

			public void SetBrush(System.Drawing.Graphics graphic, System.Drawing.SolidBrush brush) 
			{
				if (this[graphic] != null)
					((GraphicsProperties) this[graphic]).GraphicBrush = brush;
				else
				{
					GraphicsProperties tempProps = new GraphicsProperties();
					tempProps.GraphicBrush = brush;
					Add(graphic, tempProps);
				}
			}

			public System.Drawing.SolidBrush GetBrush(System.Drawing.Graphics graphic)
			{
				if (this[graphic] == null)
					return new System.Drawing.SolidBrush(System.Drawing.Color.Black);
				else
					return ((GraphicsProperties) this[graphic]).GraphicBrush;
			}

			public void SetPen(System.Drawing.Graphics graphic, System.Drawing.Pen pen) 
			{
				if (this[graphic] != null)
					((GraphicsProperties) this[graphic]).GraphicPen = pen;
				else
				{
					GraphicsProperties tempProps = new GraphicsProperties();
					tempProps.GraphicPen = pen;
					Add(graphic, tempProps);
				}
			}

			public System.Drawing.Pen GetPen(System.Drawing.Graphics graphic)
			{
				if (this[graphic] == null)
					return System.Drawing.Pens.Black;
				else
					return ((GraphicsProperties) this[graphic]).GraphicPen;
			}

			public void SetFont(System.Drawing.Graphics graphic, System.Drawing.Font font) 
			{
				if (this[graphic] != null)
					((GraphicsProperties) this[graphic]).GraphicFont = font;
				else
				{
					GraphicsProperties tempProps = new GraphicsProperties();
					tempProps.GraphicFont = font;
					Add(graphic,tempProps);
				}
			}

			public System.Drawing.Font GetFont(System.Drawing.Graphics graphic)
			{
				if (this[graphic] == null)
					return new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
				else
					return ((GraphicsProperties) this[graphic]).GraphicFont;
			}

			public void SetColor(System.Drawing.Graphics graphic, System.Drawing.Color color) 
			{
				if (this[graphic] != null)
				{
					((GraphicsProperties) this[graphic]).GraphicPen.Color = color;
					((GraphicsProperties) this[graphic]).GraphicBrush.Color = color;
					((GraphicsProperties) this[graphic]).color = color;
				}
				else
				{
					GraphicsProperties tempProps = new GraphicsProperties();
					tempProps.GraphicPen.Color = color;
					tempProps.GraphicBrush.Color = color;
					tempProps.color = color;
					Add(graphic,tempProps);
				}
			}
			public System.Drawing.Color GetColor(System.Drawing.Graphics graphic) 
			{
				if (this[graphic] == null)
					return System.Drawing.Color.Black;
				else
					return ((GraphicsProperties) this[graphic]).color;
			}

			/// <summary>
			/// This method gets the TextBackgroundColor of a Graphics instance
			/// </summary>
			/// <param name="graphic">The graphics instance</param>
			/// <returns></returns>
			public System.Drawing.Color GetTextBackgroundColor(System.Drawing.Graphics graphic)
			{
				if (this[graphic] == null)
					return System.Drawing.Color.Black;
				else 
				{ 
					return ((GraphicsProperties) this[graphic]).TextBackgroundColor;
				}
			}

			/// <summary>
			/// This method set the TextBackgroundColor of a Graphics instace
			/// </summary>
			/// <param name="graphic">The graphics instace</param>
			/// <param name="color">The System.Color to set the TextBackgroundColor</param>
			public void SetTextBackgroundColor(System.Drawing.Graphics graphic, System.Drawing.Color color) 
			{
				if (this[graphic] != null)
				{
					((GraphicsProperties) this[graphic]).TextBackgroundColor = color;								
				}
				else
				{
					GraphicsProperties tempProps = new GraphicsProperties();
					tempProps.TextBackgroundColor = color;				
					Add(graphic,tempProps);
				}
			}

			class GraphicsProperties
			{
				public System.Drawing.Color TextBackgroundColor = System.Drawing.Color.Black;
				public System.Drawing.Color color = System.Drawing.Color.Black;
				public System.Drawing.Color BackColor = System.Drawing.Color.White;
				public System.Drawing.Color TextColor = System.Drawing.Color.Black;
				public System.Drawing.SolidBrush GraphicBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
				public System.Drawing.Pen   GraphicPen = new System.Drawing.Pen(System.Drawing.Color.Black);
				public System.Drawing.Font  GraphicFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			}
		}
	}

	/*******************************/
	/// <summary>
	/// Creates a GraphicsPath from two Int Arrays with a specific number of points.
	/// </summary>
	/// <param name="xPoints">Int Array to set the X points of the GraphicsPath</param>
	/// <param name="yPoints">Int Array to set the Y points of the GraphicsPath</param>
	/// <param name="pointsNumber">Number of points to add to the GraphicsPath</param>
	/// <returns>A new GraphicsPath</returns>
	public static System.Drawing.Drawing2D.GraphicsPath CreateGraphicsPath(int[] xPoints, int[] yPoints, int pointsNumber)
	{
		System.Drawing.Drawing2D.GraphicsPath tempGraphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
		if (pointsNumber == 2)
			tempGraphicsPath.AddLine(xPoints[0], yPoints[0], xPoints[1], yPoints[1]);
		else
		{
			System.Drawing.Point[] tempPointArray = new System.Drawing.Point[pointsNumber];
			for (int index = 0; index < pointsNumber; index++)
				tempPointArray[index] = new System.Drawing.Point(xPoints[index], yPoints[index]);

			tempGraphicsPath.AddPolygon(tempPointArray);
		}
		return tempGraphicsPath;
	}

	/*******************************/
	public static System.Drawing.Point[] GetPoints(int[] xPoints, int[] yPoints, int nPoints)
	{
		System.Drawing.Point [] points = new System.Drawing.Point[nPoints];
		for (int index=0; index < nPoints; index++)
		{
			points[index] = new System.Drawing.Point(xPoints[index],yPoints[index]);

		}
		return points;
	}

}
