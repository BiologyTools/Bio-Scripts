//css_reference Bio.dll;

using System;
using System.Windows.Forms;
using System.Drawing;
using Bio;
using System.Threading;

public class Loader
{
	//Point ROI Tool Example
	public string Load()
	{
		int ind = 1;
		do
		{
			Bio.Scripting.State s = Bio.Scripting.GetState();
			if (s != null)
			{
				if (!s.processed)
				{
					if (s.type == Bio.Scripting.Event.Down && s.buts == MouseButtons.Left)
					{
						ZCT cord = Bio.App.viewer.GetCoordinate();
						Bio.Scripting.LogLine(cord.ToString() + " Coordinate");
						Bio.ROI an = Bio.ROI.CreatePoint(cord, s.p.X, s.p.Y);
						Bio.ImageView.SelectedImage.Annotations.Add(an);
						Bio.Scripting.LogLine(cord.ToString() + " Coordinate");
						an.Text = "Point" + ind;
						ind++;
						Bio.Scripting.LogLine(s.ToString() + " Point");
						//ImageView.viewer.UpdateOverlay();
					}
					else
					if (s.type == Bio.Scripting.Event.Up)
					{
						Bio.Scripting.LogLine(s.ToString());
					}
					else
					if (s.type == Bio.Scripting.Event.Move)
					{
						Bio.Scripting.LogLine(s.ToString());
					}
					s.processed = true;
				}
			}
		} while (true);
		return "OK";
	}
}
