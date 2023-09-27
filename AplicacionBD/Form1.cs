using MySql.Data.MySqlClient;
using System.Collections;

namespace AplicacionBD
{
    public partial class Form1 : Form
    {
        MySqlConnection conexion;
        MySqlCommand comando;
        MySqlDataReader dato;

        // Mejor solución para este caso que el Arraylist , para que no me muestre repetidos.
        public static HashSet<String> lista = new HashSet<String>();

        public Form1()
        {
            conexion = new MySqlConnection();
            conexion.ConnectionString = "Server=localhost;Port=3306; " +
             "DataBase=dam2023;user=root;Pwd=''";
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            String sql = "show tables";

            comando = new MySqlCommand(sql, conexion);
            dato = comando.ExecuteReader();
            listBox1.Items.Clear();
            while (dato.Read())
            {
                listBox1.Items.Add(dato.GetString(0));

            }
            conexion.Close();
        }





        private void button2_Click(object sender, EventArgs e)
        {
            conexion.Open();
            lista.Clear();
            Form2 formulario = new Form2();
            String sql = "Select  * from " + listBox1.Text;
            comando = new MySqlCommand(sql, conexion);
            dato = comando.ExecuteReader();
            while (dato.Read())

            {

                lista.Add(dato.GetString(1));

            }
            conexion.Close();
            formulario.Show();
            ;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            listBox2.Items.Clear();
            conexion.Open();
            String sql = "Select * from " + listBox1.Text;
            comando = new MySqlCommand(sql, conexion);
            dato = comando.ExecuteReader();

            while (dato.Read())
            {
                listBox2.Items.Add(dato.GetString(0));
            }
            conexion.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}