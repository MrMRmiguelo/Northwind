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

namespace Northwind
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataClasses1DataContext dc = new DataClasses1DataContext(Properties.Settings.Default.NorthwindConnectionString);
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void BtnAgragar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCompany.Text != "" && txtContacto.Text != "" && txtTContacto.Text != "" && txtTelefono.Text != "" && txtDireccion.Text != "" && txtCiudad.Text != "" && txtRegion.Text != "" && txtPostal.Text != "" && txtPais.Text != "" && txtFax.Text != "")
                {
                    Customers cust = new Customers();

                    cust.CompanyName = txtCompany.Text;
                    cust.ContactName = txtContacto.Text;
                    cust.ContactTitle = txtTContacto.Text;
                    cust.Address = txtDireccion.Text;
                    cust.City = txtCiudad.Text;
                    cust.Region = txtRegion.Text;
                    cust.PostalCode = txtPostal.Text;
                    cust.Country = txtPais.Text;
                    cust.Phone = txtTelefono.Text;
                    cust.Fax = txtFax.Text;
                    dc.Customers.InsertOnSubmit(cust);
                    dc.SubmitChanges();
                    MessageBox.Show("Se Agrego Correctamente")

                }
                else
                {
                    MessageBox.Show("falta un dato por completar", MessageBoxImage.Warning.ToString());

                }

            }
            }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnMLista_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
