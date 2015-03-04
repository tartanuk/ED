using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnSUMAClicked (object sender, EventArgs e)
	{
		texto.Buffer.Text = nom1.Text+" "+nom2.Text;
	}

	protected void OnUnirClicked (object sender, EventArgs e)
	{
		texto.Buffer.Text = nom3.Text+" "+nom4.Text;
	}
}
