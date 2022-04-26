//css_reference BioImage.dll;
using System;
using System.Windows.Forms;
using System.Drawing;
using BioImage;
using System.Threading;
public class Loader
{
	//Point ROI Tool Example
	public string Load()
	{
		int ind = 1;
		do
		{
			BioImage.Scripting.State s = BioImage.Scripting.GetState();
			if (s != null)
			{
				if (!s.processed)
				{
					if (s.type == BioImage.Scripting.Event.Up && s.buts == MouseButtons.Left)
					{
						SZCT cord = ImageView.viewer.GetCoordinate();
						int x = (int)s.p.X;
						int y = (int)s.p.Y;
						Buf b = ImageView.viewer.image.GetBufByCoord(cord);
						//SetLine(ushort val, int y, int x1, int x2)
						b.SetLine(16000, y, 0, x);
						BioImage.Scripting.LogLine(s.ToString());
						//ImageView.viewer.UpdateView();
					}
					else
					if (s.type == BioImage.Scripting.Event.Down)
					{
						BioImage.Scripting.LogLine(s.ToString());
					}
					else
					if (s.type == BioImage.Scripting.Event.Move)
					{
						BioImage.Scripting.LogLine(s.ToString());
					}
				}
				{
					s.processed = true;
				}
			}
		} while (true);
		return "Done";
	}
}