﻿using System;
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

                    cust.CustomerID = txtCustomerID.Text;
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
                    MessageBox.Show("Se Agrego Correctamente");

                }
                else
                {
                    MessageBox.Show("falta un dato por completar", MessageBoxImage.Warning.ToString());

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCompany.Text != "" && txtContacto.Text != "" && txtTContacto.Text != "" && txtTelefono.Text != "" && txtDireccion.Text != "" && txtCiudad.Text != "" && txtRegion.Text != "" && txtPostal.Text != "" && txtPais.Text != "" && txtFax.Text != "")
            {

                var update = dc.Customers.FirstOrDefault(up => up.Phone.Equals(txtTelefono.Text));
               
                update.CompanyName = txtCompany.Text;
                update.ContactName = txtContacto.Text;
                update.ContactTitle = txtTContacto.Text;
                update.Address = txtDireccion.Text;
                update.City = txtCiudad.Text;
                update.Region = txtRegion.Text;
                update.PostalCode = txtPostal.Text;
                update.Country = txtPais.Text;
                update.Phone = txtTelefono.Text;
                update.Fax = txtFax.Text;
                try
                {
                    dc.SubmitChanges();
                    MessageBox.Show("Registro actualizado con exito");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }


                
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCustomerID.Text != "")
            {
                var comida = (from com in dc.Customers
                                where com.CustomerID == txtCustomerID.Text
                                select com).FirstOrDefault();
                if (comida != null)
                {
                    var eliminar = from elim in dc.Customers
                                   where elim.CustomerID.Equals(txtCustomerID.Text)
                                   select elim;
                    foreach (var detalles in eliminar)
                    {
                        dc.Customers.DeleteOnSubmit(detalles);
                    }
                    try
                    {
                        dc.SubmitChanges();
                        MessageBox.Show("Registro eliminado con exito");
                        
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                    MessageBox.Show("Para eliminar escriba un numero de ID Valido"); txtCustomerID.Focus();
            }
            else
                MessageBox.Show("No existe registo con ese nombre");
        }
    

        private void BtnMLista_Click(object sender, RoutedEventArgs e)
        {
            Listado lis = new Listado();
            lis.ShowDialog();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtCustomerID.Text = "";
        txtCompany.Text = "";
        txtContacto.Text = "";
        txtTContacto.Text = "";
        txtDireccion.Text = "";
        txtTelefono.Text = "";
            txtCiudad.Text = "";
            txtRegion.Text = "";
            txtPostal.Text = "";
            txtPais.Text = "";
            txtFax.Text = "";
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {

            
        }
    }
}
