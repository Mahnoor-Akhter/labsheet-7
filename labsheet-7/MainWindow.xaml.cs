using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace labsheet_7
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		NORTHWNDEntities db = new NORTHWNDEntities();
		public MainWindow()
		{
			InitializeComponent();
		}

		private void q1Btn_Click(object sender, RoutedEventArgs e)
		{
			var query = from c in db.Customers
						group c by c.Country into g
						orderby g.Count() descending
						select new
						{
							Country = g.Key,
							Count = g.Count()
						};
			q1lbxdisplay.ItemsSource = query.ToList();
		}

		

		private void q2Btn_Click(object sender, RoutedEventArgs e)
		{
			var query =  db.Customers_By_City("Italy");
			q2lbxdisplay.ItemsSource = query.ToList();



		}

		private void q3Btn_Click(object sender, RoutedEventArgs e)
		{
			var query = from p in db.Products
						where p.UnitsInStock > 0
						select new
						{
							Product = p.ProductName,
							Available = p.UnitsInStock
						};
			q3lbsdisplay.ItemsSource = query.ToList();
			
		}

		private void q4Btn4_Click(object sender, RoutedEventArgs e)
		{
			var query = from p in db.Products
						where p.Discontinued
						orderby p.Order_Details
						select new
						{
							ProductName= p.ProductName,
							DiscountGiven= p.Discontinued,
							OrderID= p.Order_Details

						};
			q4lbxdisplay.ItemsSource = query.ToList();
		}

		private void q5Btn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void q6Btn_Click(object sender, RoutedEventArgs e)
		{
			var query = from c in db.Categories
						join p in db.Products on c.CategoryName equals p.Category.CategoryName
						orderby p.UnitPrice >=0
						select new
						{
							Category= p.CategoryID,
							CategoryName = c.CategoryName,
							Product = p.ProductName,
							UnitPrice= p.UnitPrice
						};
			q6lbxdisplay.ItemsSource = query.ToList();


		}

		private void q7Btn_Click(object sender, RoutedEventArgs e)
		{
			var query = from c in db.Orders
						orderby c.CustomerID
						select new
						{
						CustomerId= c.CustomerID,
						Oerders= c.Order_Details.Count
						};
			q7lbxdisplay.ItemsSource = query.ToList();
		}

		private void q8Btn_Click(object sender, RoutedEventArgs e)
		{
			var query = from c in db.Customers
						join p in db.Orders on c.CompanyName equals p.CustomerID
						orderby c.Orders.Count() descending
						select new
						{
							CustomerID = c.CustomerID,
							CompanyName = c.CompanyName,
							NumberodOrder = c.Orders.Count
						};
			q8lbxdisplay.ItemsSource = query.ToList();
		}

		private void q9Btn_Click(object sender, RoutedEventArgs e)
		{
			var query = from c in db.Customers
						where c.Orders.Count >= 0
						select new
						{
							CompanyName = c.CompanyName,
							NumberodOrder = c.Orders.Count
						};
			q9lbxdisplay2.ItemsSource = query.ToList();
		}

		
	}
}
