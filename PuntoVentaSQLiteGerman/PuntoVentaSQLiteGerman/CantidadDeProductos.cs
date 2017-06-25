using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace PuntoVentaSQLiteGerman
{
    public partial class CantidadDeProductos : Form
    {
        public CantidadDeProductos()
        {
            InitializeComponent();
        }

        public CantidadDeProductos(string clave, string nombre)
        {
            InitializeComponent();
            label1.Text = clave;
            label2.Text = nombre;
        }

        private void CantidadDeProductos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection cadenaconexion = new SQLiteConnection("Data Source=C:/Users/j0ker/Documents/visual studio 2015/Projects/PuntoVentaSQLiteGerman/PuntoVentaSQLiteGerman/bin/Debug/PuntoVenta.sqlite");
            cadenaconexion.Open();

            string consulta = "select max(id) from venta;";
            SQLiteCommand comando = new SQLiteCommand(consulta, cadenaconexion);
            SQLiteDataReader datos = comando.ExecuteReader();

            consulta = "insert into RELACION VALUES('" + Convert.ToString(datos[0]) + "', '" + label1.Text + "' , '" + textBox1.Text + "')";
            comando = new SQLiteCommand(consulta, cadenaconexion);
            comando.ExecuteNonQuery();
            
            cadenaconexion.Close();
            this.Dispose();
        }
    }
}
