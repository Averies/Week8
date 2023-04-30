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

namespace THA_W8_AVE_F
{
    public partial class Form1 : Form
    {
        public static MySqlConnection sqlconnect;
        public static MySqlCommand sqlcommand;
        public static MySqlDataAdapter sqladapter;
        public static string connectionstring;
        public static string sqlquery;
        
        public Form1()
        {
            InitializeComponent();
        }
        DataTable dtteam = new DataTable();
        private void Form1_Load(object sender, EventArgs e)
        {
            connectionstring = "server=127.0.0.1;uid=root;pwd=averies10;database=premier_league";
            sqlconnect = new MySqlConnection(connectionstring);
            
            sqlquery = "SELECT  t.team_name as 'Team' FROM team t;";
            sqlcommand = new MySqlCommand(sqlquery,sqlconnect);
            sqladapter = new MySqlDataAdapter(sqlcommand);
            sqladapter.Fill(dtteam);
            comboBox_team.DataSource = dtteam;
            comboBox_team.ValueMember = "Team";
            comboBox_team.ValueMember = "Team";
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            DataTable dtplayer = new DataTable();
            sqlquery = "SELECT p.player_name as 'Player Name', p.playing_pos as 'Position' FROM player p,team t WHERE p.team_id=t.team_id AND t.team_name='" + comboBox_team.SelectedValue.ToString()+"';";
            sqlcommand = new MySqlCommand(sqlquery, sqlconnect);
            sqladapter = new MySqlDataAdapter(sqlcommand);
            sqladapter.Fill(dtplayer);
            dgv_player.DataSource = dtplayer;
        }

        private void comboBox_team_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void showMatchDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }
    }
}
