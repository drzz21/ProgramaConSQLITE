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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection cadenaconexion = new SQLiteConnection("Data Source=C:/Users/j0ker/Documents/visual studio 2015/Projects/PuntoVentaSQLiteGerman/PuntoVentaSQLiteGerman/bin/Debug/PuntoVenta.sqlite");
            cadenaconexion.Open();
            string fecha = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            string consulta = "insert into VENTA(fecha) values('" + fecha + "')";
            SQLiteCommand comando = new SQLiteCommand(consulta, cadenaconexion);
            comando.ExecuteNonQuery();





            cadenaconexion.Close();

            Productos p = new Productos();
            p.ShowDialog();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            
            SQLiteConnection cadenaconexion = new SQLiteConnection("Data Source=C:/Users/j0ker/Documents/visual studio 2015/Projects/PuntoVentaSQLiteGerman/PuntoVentaSQLiteGerman/bin/Debug/PuntoVenta.sqlite");
            cadenaconexion.Open();

            string consulta = "select r.venta, sum(p.precio * r.cantidad), v.fecha from relacion r join producto p on r.producto = p.id join venta v  on v.id = r.venta group by v.id order by v.id desc;";
            SQLiteCommand comando = new SQLiteCommand(consulta, cadenaconexion);
            SQLiteDataReader datos = comando.ExecuteReader();

            while (datos.Read())
            {
                 dataGridView1.Rows.Insert(0,Convert.ToString(datos[0]), "$"+Convert.ToString(datos[1]), Convert.ToString(datos[2]));
            }
            
            cadenaconexion.Close();

        
    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Venta vn = new Venta();
            SQLiteConnection cadenaconexion = new SQLiteConnection("Data Source=C:/Users/j0ker/Documents/visual studio 2015/Projects/PuntoVentaSQLiteGerman/PuntoVentaSQLiteGerman/bin/Debug/PuntoVenta.sqlite");
            cadenaconexion.Open();

            string consulta = "select p.nombre, p.precio, r.cantidad from producto p join relacion r on r.producto = p.id where r.venta = " + dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            SQLiteCommand comando = new SQLiteCommand(consulta, cadenaconexion);
            SQLiteDataReader datos = comando.ExecuteReader();

            while (datos.Read())
            {
                vn.dgv().Rows.Insert(0, Convert.ToString(datos[0]), "$" + Convert.ToString(datos[1]), Convert.ToString(datos[2]));
            }
            vn.ShowDialog();

            cadenaconexion.Close();
        }
    }
}
