//  MessageService.cs
//
//  This file was derived from a file from #Develop. 
//
//  Copyright (C) 2001-2007 Mike Krüger <mkrueger@novell.com>
// 
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System;
using System.IO;

using MonoDevelop.Core.Gui;
using MonoDevelop.Core.Gui.Dialogs;
using Mono.Addins;
using MonoDevelop.Core;
using Gtk;

namespace MonoDevelop.Core.Gui
{
	/// <summary>
	/// This interface must be implemented by all services.
	/// </summary>
	public class MessageService : GuiSyncObject, IMessageService
	{
		Window rootWindow;
		
		public object RootWindow {
			get { return rootWindow; }
			set { rootWindow = (Window) value; }
		}
		
		public void ShowError(Exception ex)
		{
			ShowError(ex, null, rootWindow);
		}
		
		public void ShowError(string message)
		{
			ShowError(null, message, rootWindow);
		}

		public void ShowError (Window parent, string message)
		{
			ShowError (null, message, parent);
		}
		
		public void ShowErrorFormatted(string formatstring, params string[] formatitems)
		{
			ShowError(null, String.Format(StringParserService.Parse(formatstring), formatitems), rootWindow);
		}

		private struct ErrorContainer
		{
			public Exception ex;
			public string message;

			public ErrorContainer (Exception e, string msg)
			{
				ex = e;
				message = msg;
			}
		}

		public void ShowError (Exception ex, string message)
		{
			ShowError (ex, message, rootWindow);
		}

		public void ShowError (Exception ex, string message, Window parent)
		{
			ShowError (ex, message, parent, false);
		}
		
		public void ShowError (Exception ex, string message, Window parent, bool modal)
		{
			ErrorDialog dlg = new ErrorDialog (parent);
			
			if (message == null) {
				if (ex != null)
					dlg.Message = GettextCatalog.GetString ("Exception occurred: {0}", ex.Message);
				else {
					dlg.Message = "An unknown error occurred";
					dlg.AddDetails (Environment.StackTrace, false);
				}
			} else
				dlg.Message = message;
			
			if (ex != null) {
				UserException uex = ex as UserException;
				if (uex != null) {
					if (uex.Details != null)
						dlg.AddDetails (uex.Details, true);
				} else {
					dlg.AddDetails (GettextCatalog.GetString ("Exception occurred: {0}", ex.Message) + "\n\n", true);
					dlg.AddDetails (ex.ToString (), false);
				}
			}

			if (modal) {
				dlg.Run ();
				dlg.Dispose ();
			} else
				dlg.Show ();
		}

		public void ShowWarning (string message)
		{
			ShowWarning (message, false);
		}
		
		public void ShowWarning (string message, bool modal)
		{
			MessageDialog md = new MessageDialog (rootWindow, DialogFlags.Modal | DialogFlags.DestroyWithParent, MessageType.Warning, ButtonsType.Ok, EscapeBraces(message));
			md.Response += new ResponseHandler(OnResponse);
			md.Close += new EventHandler(OnClose);
			
			if (modal) {
				md.Run ();
				md.Dispose ();
			} else
				md.ShowAll ();
		}		
		
		public void ShowWarningFormatted(string formatstring, params string[] formatitems)
		{
			ShowWarning(String.Format(StringParserService.Parse(formatstring), formatitems));
		}
		
		public bool AskQuestion(string question, string caption)
		{
			MessageDialog md = new MessageDialog (rootWindow, DialogFlags.Modal | DialogFlags.DestroyWithParent, MessageType.Question, ButtonsType.YesNo, EscapeBraces(question));
			try {
				int response = md.Run ();
				md.Hide ();
				
				if ((ResponseType) response == ResponseType.Yes)
					return true;
				else
					return false;
			} finally {
				md.Destroy ();
			}
		}
		
		public bool AskQuestionFormatted(string caption, string formatstring, params string[] formatitems)
		{
			return AskQuestion(String.Format(StringParserService.Parse(formatstring), formatitems), caption);
		}
		
		public bool AskQuestionFormatted(string formatstring, params string[] formatitems)
		{
			return AskQuestion(String.Format(StringParserService.Parse(formatstring), formatitems));
		}
		
		public bool AskQuestion(string question)
		{
			return AskQuestion(StringParserService.Parse(question), GettextCatalog.GetString ("Question"));
		}

		public QuestionResponse AskQuestionWithCancel(string question, string caption)
		{
			MessageDialog md = new MessageDialog (rootWindow, DialogFlags.Modal | DialogFlags.DestroyWithParent, MessageType.Question, ButtonsType.None, EscapeBraces(question));
			try {
				md.AddActionWidget (new Button (Gtk.Stock.No), ResponseType.No);
				md.AddActionWidget (new Button (Gtk.Stock.Cancel), ResponseType.Cancel);
				md.AddActionWidget (new Button (Gtk.Stock.Yes), ResponseType.Yes);
				md.ActionArea.ShowAll ();
				
				ResponseType response = (ResponseType)md.Run ();
				md.Hide ();

				if (response == ResponseType.Yes) {
					return QuestionResponse.Yes;
				}

				if (response == ResponseType.No) {
					return QuestionResponse.No;
				}

				if (response == ResponseType.Cancel) {
					return QuestionResponse.Cancel;
				}

				return QuestionResponse.Cancel;
			} finally {
				md.Destroy ();
			}
		}
		
		public QuestionResponse AskQuestionFormattedWithCancel(string caption, string formatstring, params string[] formatitems)
		{
			return AskQuestionWithCancel(String.Format(StringParserService.Parse(formatstring), formatitems), caption);
		}
		
		public QuestionResponse AskQuestionFormattedWithCancel(string formatstring, params string[] formatitems)
		{
			return AskQuestionWithCancel(String.Format(StringParserService.Parse(formatstring), formatitems));
		}
		
		public QuestionResponse AskQuestionWithCancel(string question)
		{
			return AskQuestionWithCancel(StringParserService.Parse(question), GettextCatalog.GetString ("Question"));
		}
		
		public int ShowCustomDialog(string caption, string dialogText, params string[] buttontexts)
		{
			MessageDialog md = new MessageDialog (rootWindow, DialogFlags.Modal | DialogFlags.DestroyWithParent, MessageType.Question, ButtonsType.None, EscapeBraces(dialogText));
				
			try {
				for (int i = 0; i < buttontexts.Length; i++)
					md.AddActionWidget (new Button (buttontexts[i]), i);

				md.ActionArea.ShowAll ();
				int response = md.Run ();
				md.Hide ();

				return response;
			} finally {
				md.Destroy ();
			}
		}
		
		public int ShowCustomDialog (System.Type dialogType, object[] args)
		{
			Gtk.Dialog dialog = null;
			try {
				dialog = (Gtk.Dialog) System.Activator.CreateInstance (dialogType, args);
				dialog.Modal = true;
				dialog.TransientFor = rootWindow;
				dialog.DestroyWithParent = true;
				
				int response = dialog.Run ();
				return response;
			} finally {
				if (dialog != null)
					dialog.Destroy ();
			}
		}
		
		public void ShowMessage(string message)
		{
			ShowMessage(message, "MonoDevelop");
		}
		
		public void ShowMessageFormatted(string formatstring, params string[] formatitems)
		{
			ShowMessage(String.Format(StringParserService.Parse(formatstring), formatitems));
		}
		
		public void ShowMessageFormatted(string caption, string formatstring, params string[] formatitems)
		{
			ShowMessage(String.Format(StringParserService.Parse(formatstring), formatitems), caption);
		}
		
		public void ShowMessage(string message, string caption)
		{
			MessageDialog md = new MessageDialog (rootWindow, DialogFlags.Modal | DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, EscapeBraces(message));
			md.Response += new ResponseHandler(OnResponse);
			md.Close += new EventHandler(OnClose);
			md.ShowAll ();
		}

		public void ShowMessage(string message, Window parent)
		{			
			MessageDialog md = new MessageDialog (rootWindow, DialogFlags.Modal | DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, EscapeBraces(message));
			
			if (parent != null)			
				md.TransientFor = parent;
							
			md.Response += new ResponseHandler(OnResponse);
			md.Close += new EventHandler(OnClose);
			md.ShowAll();
		}

		string EscapeBraces(string stringToEscape)
		{
			return stringToEscape.Replace("{", "{{").Replace("}", "}}");
		}

		void OnResponse (object o, ResponseArgs e)
		{
			((Dialog)o).Hide();
		}
		
		void OnClose(object o, EventArgs e)
		{
			((Dialog)o).Hide();
		} 
		
		// call this method to show a dialog and get a response value
		// returns null if cancel is selected
		public string GetTextResponse(string question, string caption, string initialValue)
		{
			return GetTextResponse(question, caption, initialValue, false);
		}
		
		private string GetTextResponse (string question, string caption, string initialValue, bool isPassword)
		{
			string returnValue = null;
			
			Dialog md = new Dialog (caption, rootWindow, DialogFlags.Modal | DialogFlags.DestroyWithParent);
			try {
				// add a label with the question
				Label questionLabel = new Label(question);
				questionLabel.UseMarkup = true;
				questionLabel.Xalign = 0.0F;
				md.VBox.PackStart(questionLabel, true, false, 6);
				
				// add an entry with initialValue
				Entry responseEntry = (initialValue != null) ? new Entry(initialValue) : new Entry();
				md.VBox.PackStart(responseEntry, false, true, 6);
				responseEntry.Visibility = !isPassword;
				
				// add action widgets
				md.AddActionWidget(new Button(Gtk.Stock.Cancel), ResponseType.Cancel);
				md.AddActionWidget(new Button(Gtk.Stock.Ok), ResponseType.Ok);
				
				md.VBox.ShowAll();
				md.ActionArea.ShowAll();
				md.HasSeparator = false;
				md.BorderWidth = 6;
				
				int response = md.Run ();
				md.Hide ();
				
				if ((ResponseType) response == ResponseType.Ok) {
					returnValue =  responseEntry.Text;
				}

				return returnValue;
			} finally {
				md.Destroy ();
			}
		}
		
		public string GetTextResponse(string question, string caption)
		{
			return GetTextResponse(question, caption, string.Empty, false);
		}
		
		public string GetPassword (string question, string caption)
		{
			return GetTextResponse(question, caption, string.Empty, true);
		}
	}
}
