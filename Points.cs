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
						Annotation an = Annotation.CreatePoint(cord, s.p.X, s.p.Y);
						ImageView.viewer.image.Annotations.Add(an);
						an.Text = "Point" + ind;
						ind++;
						BioImage.Scripting.LogLine(s.ToString());
						ImageView.viewer.UpdateOverlay();
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