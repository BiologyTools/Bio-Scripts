//css_reference BioImage.dll;
using System;
using System.Windows.Forms;
using System.Drawing;
using BioImage;
public class Loader
{
	public string Load()
	{
		do
		{
			BioImage.Scripting.State s = BioImage.Scripting.GetState();
			if (s != null)
			{
				if (s.p.X < 10 && s.p.Y < 10)
				{
					return "Corner (" + s.p.X + ", " + s.p.Y + ")";

				}
				if (s.type == BioImage.Scripting.Event.Move)
				{
					if (s.p.X < 25 && s.p.Y < 25)
					{
						return "Move (" + s.p.X + ", " + s.p.Y + ")";
					}
				}
				else
				if (s.type == BioImage.Scripting.Event.Up)
				{
					if (s.p.X < 50 && s.p.Y < 50)
					{
						return "Up (" + s.p.X + ", " + s.p.Y + ")";
					}
				}
				else
				if (s.type == BioImage.Scripting.Event.Down)
				{
					if (s.p.X < 75 && s.p.Y < 75)
					{
						return "Down (" + s.p.X + ", " + s.p.Y + ")";
					}
				}
			}
		} while (true);

		return "Done";
	}
}