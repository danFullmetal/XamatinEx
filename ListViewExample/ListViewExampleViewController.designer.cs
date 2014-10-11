// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;

namespace ListViewExample
{
	[Register ("ListViewExampleViewController")]
	partial class ListViewExampleViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnDato { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tvDato { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtDato { get; set; }

		[Action ("btnDato_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnDato_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnDato != null) {
				btnDato.Dispose ();
				btnDato = null;
			}
			if (tvDato != null) {
				tvDato.Dispose ();
				tvDato = null;
			}
			if (txtDato != null) {
				txtDato.Dispose ();
				txtDato = null;
			}
		}
	}
}
