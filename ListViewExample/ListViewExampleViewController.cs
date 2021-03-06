﻿using System;
using System.Drawing;
using RestSharp;
using Foundation;
using UIKit;
using System.Collections.Generic;
using RestSharp.Serializers;
using RestSharp.Deserializers;
using MonoTouch.Dialog;

namespace ListViewExample
{
	public class Respuesta
	{
		public string Name { get; set; }
	}

	public partial class ListViewExampleViewController : UIViewController
	{
		List<string> ListaDatos = new List<string> ();

		public List<Respuesta> jsonObj;

		public ListViewExampleViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
					
			// Release any cached data, images, etc that aren't in use.
		}

		public override void LoadView ()
		{
			GetData ();
			base.LoadView ();
			DataSource data = new DataSource (ListaDatos);
			tvDato.Source = data;
			tvDato.ReloadData ();
			tvDato.ReloadInputViews ();
		}

		public void GetData ()
		{
			if (!Reachability.IsHostReachable ("www.bordadossantiago.com")) {
				var alert = new UIAlertView {
					Title = "Unable to connect to server", 
					Message = "Verify network connections"
				};
				alert.AddButton ("OK");
				// last button added is the 'cancel' button (index of '2')
				alert.Clicked += delegate(object a, UIButtonEventArgs b) {
					Console.WriteLine ("Button " + b.ButtonIndex.ToString () + " clicked");
				};
				alert.Show ();
			} else {
				// Create a new RestClient and RestRequest
				var client = new RestClient ("http://bordadossantiago.com/getjson.php");
				var request = new RestRequest ("resource/{Name}", Method.GET);

				// ask for the response to be in JSON syntax
				request.RequestFormat = DataFormat.Json;

				//send the request to the web service and store the response when it comes back
				var response = client.Execute (request);
				// The next line of code will only run after the response has been received

				// Create a new Deserializer to be able to parse the JSON object
				RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer ();

				//Single variable
				jsonObj = deserial.Deserialize<List<Respuesta>> (response);

				Console.WriteLine (jsonObj.Count);

				//foreach para sacar los valores y aniadirlos a la lista
				foreach (Respuesta x in jsonObj) {
					Respuesta datos = new Respuesta ();
					datos.Name = x.Name;
					ListaDatos.Add (datos.Name);
				}
			}
		}


		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		partial void btnRefresh_TouchUpInside (UIButton sender)
		{
			//boton apara refrescar los datos del web service
			ListaDatos.Clear ();
			GetData ();
			DataSource data = new DataSource (ListaDatos);
			tvDato.Source = data;
			tvDato.ReloadData ();
			tvDato.ReloadInputViews ();
		}

		partial void btnDato_TouchUpInside (UIButton sender)
		{
			if (string.IsNullOrEmpty (txtDato.Text)) {
				UIAlertView _error = new UIAlertView ("Campo vacio", "El campo no puede estar vacio", null, "OK", null);
				_error.Show ();
			} else {
				ListaDatos.Add (txtDato.Text);
				DataSource data = new DataSource (ListaDatos);
				tvDato.Source = data;
				tvDato.ReloadData ();
				tvDato.ReloadInputViews ();
				txtDato.Text = "";

			}
		}
		#endregion
	}
}

