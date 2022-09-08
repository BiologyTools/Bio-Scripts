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
			Bio.Scripting.State s = Bio.Scripting.GetState();
			if (s != null)
			{
				if (!s.processed)
				{
					if (s.type == Bio.Scripting.Event.Up && s.buts == MouseButtons.Left)
					{
						ZCT cord = ImageView.viewer.GetCoordinate();
						Annotation an = Annotation.CreatePoint(cord, s.p.X, s.p.Y);
						ImageView.viewer.image.Annotations.Add(an);
						an.Text = "Point" + ind;
						ind++;
						Bio.Scripting.LogLine(s.ToString());
						ImageView.viewer.UpdateOverlay();
					}
					else
					if (s.type == Bio.Scripting.Event.Down)
					{
						Bio.Scripting.LogLine(s.ToString());
					}
					else
					if (s.type == Bio.Scripting.Event.Move)
					{
						Bio.Scripting.LogLine(s.ToString());
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
