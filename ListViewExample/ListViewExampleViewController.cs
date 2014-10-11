using System;
using System.Drawing;
using RestSharp;
using Foundation;
using UIKit;
using System.Collections.Generic;
using RestSharp.Serializers;
using RestSharp.Deserializers;

namespace ListViewExample
{
	public partial class ListViewExampleViewController : UIViewController 
	{
		List<string> ListaDatos = new List<string>();
		string[] tableItems = new string[] {"Vegetables","Fruits","Flower Buds","Legumes","Bulbs","Tubers","Meat","Fishes","Pasta","Candies"};

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

			var client = new RestClient ("http://bordadossantiago.com/getjson.php");
			var request = new RestRequest ("resource/{Name}", Method.GET);

			request.RequestFormat = DataFormat.Json;
			var response = client.Execute (request);
			RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer ();

			//var JSONObj = deserial.Deserialize<Dictionary<string,string>> (response);
			//IRestResponse response = client.Execute (request);
			var content = response.Content;
			//client.Authenticator = new SimpleAuthenticator ("","","","");
			//id, Name, Message, test, another

			//Resupuest a resp = deserial.Deserialize<Resupuesta> (response);
		

			base.LoadView ();
			DataSource data = new DataSource (ListaDatos);
			ListaDatos.InsertRange (0,tableItems);
			tvDato.Source = data;
			tvDato.ReloadData ();
			tvDato.ReloadInputViews ();


		}

		public class Resupuesta{
			public string id { get; set;}
			public string Name { get; set;}
			public string Message { get; set;}
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
			

		partial void btnDato_TouchUpInside (UIButton sender)
		{
			if (string.IsNullOrEmpty (txtDato.Text)) {
				UIAlertView _error = new UIAlertView ("Campo vacio", "El campo no puede estar vacio",null,"OK",null);
				_error.Show();
			}else{
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

