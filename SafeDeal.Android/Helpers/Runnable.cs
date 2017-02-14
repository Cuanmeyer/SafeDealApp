using System;

using Java.Lang;

namespace SafeDeal.Helpers
{
	public class Runnable : Java.Lang.Object, IRunnable
	{
		public EventHandler RunAction { get; set; }

		public void Run ()
		{
			RunAction?.Invoke (this, new EventArgs ());
		}
	}
}
