using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace tic_tac_toe
{
    public partial class ToplistForm : Form
    {
        public ToplistForm()
        {
            InitializeComponent();
        }

        private void ToplistForm_Load(object sender, EventArgs e)
        {
            savePlayersData();
            loadPlayersData();
        }

        public static void savePlayersData()
        {
            List<Player> playerList = new List<Player>();
            playerList.Add(new Player()
            {
                Name = "Teszt1",
                Loses = 12,
                Wins = 30
            });
            playerList.Add(new Player()
            {
                Name = "Teszt2",
                Loses = 14,
                Wins = 55
            });
            string playersJson = JsonSerializer.Serialize(playerList);
            File.WriteAllText(@"C:\Users\gabri\Desktop\ISKOLA\6.félév\C#\egyetemikurzus-2022\toplist.json", playersJson);
        }

        public static List<Player> loadPlayersData()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\gabri\Desktop\ISKOLA\6.félév\C#\egyetemikurzus-2022\toplist.json"))
            {
                string json = r.ReadToEnd();
                List<Player> items = JsonSerializer.Deserialize<List<Player>>(json);
                return items;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
