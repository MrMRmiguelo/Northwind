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
using System.Windows.Shapes;

namespace Northwind
{
    /// <summary>
    /// Lógica de interacción para Listado.xaml
    /// </summary>
    public partial class Listado : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext(Properties.Settings.Default.NorthwindConnectionString);
        public Listado()
        {
            MainWindow main = new MainWindow();
          
            var comida = from u in dc.GetTable<Customers>()
                         select new { u.CustomerID, u.CompanyName, u.ContactName, u.ContactTitle, u.Address, u.City, u.Region, u.PostalCode, u.Country, u.Phone, u.Fax };
            InitializeComponent();
            dgLista.ItemsSource = comida.ToList();
        }

        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtID.Text != "")
            {
                dc = new DataClasses1DataContext();
                var buscar = from u in dc.GetTable<Customers>()
                             where u.CustomerID.Equals(txtID.Text)
                             select new { u.CompanyName, u.ContactName, u.ContactTitle, u.Address, u.City, u.Region, u.PostalCode, u.Country, u.Phone, u.Fax };
                dgLista.ItemsSource = buscar.ToList();
                if (buscar == null)
                { MessageBox.Show("no existe");
                    dgLista.ItemsSource = buscar.ToList();
                }


            }
            else
                MessageBox.Show("ingrese un ID Valido"); txtID.Focus();
        }
    }
}
