﻿using System;
using System.IO;
using Gtk;

public partial class MainWindow: Gtk.Window
{
	private string filename;
	private string content = "";

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();

		//textView.Buffer.Text = File.ReadAllText("prueba.txt");
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	/// <summary>
	/// Confirm() devuelve true si el usuario confirma que descarta los cambios
	/// </summary>
	private bool confirm(){

		MessageDialog messageDialog = new MessageDialog (
			this,
			DialogFlags.DestroyWithParent,
			MessageType.Question,
			ButtonsType.YesNo,
			"Hay cambios sin guardar.¿Quieres descartar los cambios?");
		ResponseType responseType = (ResponseType)messageDialog.Run ();
		messageDialog.Destroy ();
//		if (responseType != ResponseType.Yes)//quiere cancelar 
			return responseType == ResponseType.Yes; // true o false

	}

	private bool hasChanges(){
		return !content.Equals (textView.Buffer.Text);
	}

	protected void OnOpenActionActivated (object sender, EventArgs e)
	{
		if (hasChanges() && !confirm ())
				return;

		FileChooserDialog fileChooserDialog = new FileChooserDialog (
			                                      "Elige el archivo",
			                                      this,
			                                      FileChooserAction.Open,
			                                      Stock.Cancel, ResponseType.Close,
			                                      Stock.Open, ResponseType.Ok);
		//if (fileChooserDialog.Run () == (int)ResponseType.Ok)
		if ((ResponseType)fileChooserDialog.Run () == ResponseType.Ok) {//Es lo mismo que lo de arriba
			//Console.WriteLine ("Filename=" + fileChooserDialog.Filename);
			textView.Buffer.Text = File.ReadAllText (fileChooserDialog.Filename);
			content = File.ReadAllText (filename);
			textView.Buffer.Text = File.ReadAllText (filename);
		}

		fileChooserDialog.Destroy ();
	}

	protected void OnSaveActionActivated (object sender, EventArgs e)
	{
		if (filename == null)
			saveAs ();
		else
			File.WriteAllText (filename, textView.Buffer.Text);
	}
	private void saveAs(){
		FileChooserDialog fileChooserDialog = new FileChooserDialog (
			"Guardar como...",
			this,
			FileChooserAction.Save,
			Stock.Cancel, ResponseType.Cancel,
			Stock.Save, ResponseType.Ok);
		if ((ResponseType)fileChooserDialog.Run () == ResponseType.Ok) {
			filename = fileChooserDialog.Filename;
			File.WriteAllText (filename, textView.Buffer.Text);
		}
		fileChooserDialog.Destroy ();
	}
	protected void OnSaveAsActionActivated (object sender, EventArgs e)
	{
		saveAs ();
	}

		
	protected void OnNewActionActivated (object sender, EventArgs e)
	{
		if (hasChanges() && !confirm ()) 
				return;

		
		textView.Buffer.Text = "";
		content = "";
		filename = null;
	}

}
