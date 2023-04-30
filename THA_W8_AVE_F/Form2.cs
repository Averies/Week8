using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.IO;

namespace THA_W8_AVE_F
{
    public partial class Form2 : Form
    {
        public static MySqlConnection sqlconnect;
        public static MySqlCommand sqlcommand;
        public static MySqlDataAdapter sqladapter;
        public static string connectionstring;
        public static string sqlquery;
        public Form2()
        {
            InitializeComponent();
        }
        DataTable dthome = new DataTable();
        private void Form2_Load(object sender, EventArgs e)
        {
            connectionstring = "server=127.0.0.1;uid=root;pwd=averies10;database=premier_league";
            sqlconnect = new MySqlConnection(connectionstring);

            sqlquery = "SELECT  m.team_home as 'Team Home' FROM match m;";
            sqlcommand = new MySqlCommand(sqlquery, sqlconnect);
            sqladapter = new MySqlDataAdapter(sqlcommand);
            sqladapter.Fill(dthome);
            comboBoxhome.DataSource = dthome;
            comboBoxhome.ValueMember = "Team Home";
            comboBoxhome.ValueMember = "Team Home";
        }
    }
}
