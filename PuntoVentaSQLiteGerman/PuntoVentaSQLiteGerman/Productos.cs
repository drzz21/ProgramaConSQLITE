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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
        }

        private void Productos_Load(object sender, EventArgs e)
        {
            SQLiteConnection cadenaconexion = new SQLiteConnection("Data Source=C:/Users/j0ker/Documents/visual studio 2015/Projects/PuntoVentaSQLiteGerman/PuntoVentaSQLiteGerman/bin/Debug/PuntoVenta.sqlite");
            cadenaconexion.Open();

            string consulta = "select * from PRODUCTO";
            SQLiteCommand comando = new SQLiteCommand(consulta, cadenaconexion);
            SQLiteDataReader datos = comando.ExecuteReader();

            while (datos.Read())
            {
                //MessageBox.Show(Convert.ToString(datos[0]) + " " + Convert.ToString(datos[1]));
                dataGridView1.Rows.Insert(0, Convert.ToString(datos[0]), Convert.ToString(datos[1]), "$"+Convert.ToString(datos[2]));
            }




            cadenaconexion.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CantidadDeProductos(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString(), dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString()).ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
