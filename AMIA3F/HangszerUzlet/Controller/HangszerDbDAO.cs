using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using HangszerUzlet;

namespace Controller
{
    public class HangszerDbDAO
    {
        private static string CONNECTION_STRING = "Data Source=KURAIISTVAN;Initial Catalog=HangszerUzlet;Integrated Security=True";

        public List<HangszerModel> getHangszerek()
        {

            SqlConnection cnn;
            using (cnn = new SqlConnection(CONNECTION_STRING))
                cnn.Open();
            List<HangszerModel> hangszerModels = new List<HangszerModel>();

            foreach (var item in hangszerModels)
            {
                HangszerModel hangszer = new HangszerModel()
                {
                    Nev = item.Nev,
                    Tipus = item.Tipus,
                    Ar = item.Ar
                };
            }

          



            return hangszerModels;
        }
    }
}
