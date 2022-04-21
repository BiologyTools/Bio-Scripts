//css_reference BioImage.dll;
using System;
using System.Windows.Forms;
using System.Drawing;
using BioImage;
public class Loader
{
	public string Load()
	{
		bool run = true;
		do
		{
			BioImage.Scripting.State s = BioImage.Scripting.GetState();
			if (s != null)
			{
				if (s.p.X < 10 && s.p.Y < 10)
				{
					run = false;
					return "Corner";
				}
				if (s.type == BioImage.Scripting.Event.Move)
				{
					if (s.p.X < 25 && s.p.Y < 25)
					{
						run = false;
						return "Move";
					}
				}
				else
				if (s.type == BioImage.Scripting.Event.Up)
				{
					if (s.p.X < 50 && s.p.Y < 50)
					{
						run = false;
						return "Up";
					}
				}
				else
				if (s.type == BioImage.Scripting.Event.Down)
				{
					if (s.p.X < 50 && s.p.Y < 50)
					{
						run = false;
						return "Down";
					}
				}
			}
		} while (run);

		return "OK";
	}
}