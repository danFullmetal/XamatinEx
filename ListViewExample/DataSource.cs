using System;

//Nuevas librerias
using System.Collections.Generic;
using UIKit;
using Foundation;


namespace ListViewExample
{
	public class DataSource : UITableViewSource
	{
		static NSString Identificador = new NSString("Tabla Prueba");
		List <string> ListaDatos;


		public DataSource (List <string> _listadatos)
		{
			ListaDatos = _listadatos;

		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return ListaDatos.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell celda = tableView.DequeueReusableCell (Identificador);
			if (celda == null) {
				celda = new UITableViewCell (UITableViewCellStyle.Default, Identificador);
			}
			celda.SelectionStyle = UITableViewCellSelectionStyle.Blue;
			celda.TextLabel.Text = ListaDatos [indexPath.Row];

			return celda;

		}

		public override string TitleForHeader (UITableView tableView, nint section)
		{
			return "Lista Datos";
		}

		public override string TitleForFooter (UITableView tableView, nint section)
		{
			return "Elementos: "+ListaDatos.Count;
		}
	}
}

