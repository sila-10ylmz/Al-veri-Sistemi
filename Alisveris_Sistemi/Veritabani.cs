using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alisveris_Sistemi
{

    public class Veritabani
    {

        public MySqlConnection bag = new MySqlConnection("Server=localhost;Database=mobilya;Uid=root;Pwd=;");


        public int  sepet_temiz(int k_id)
        {
            int x = 0;
            bag.Open();
            MySqlCommand cmd = new MySqlCommand("delete from sepet where k_id='" + k_id + "'" , bag);
            x = cmd.ExecuteNonQuery();
            bag.Close();
            return x;
        }


        public int siparis_ekle (int k_id, int s_id)
        {
            int x = 0;
            bag.Open();
            MySqlCommand cmd = new MySqlCommand("insert into siparisler (k_id,u_id)values('" + k_id + "','" + s_id + "')", bag);
            x = cmd.ExecuteNonQuery();
            bag.Close();
            return x;
        }

        public int siparis_cikar(int id)
        {
            int x = 0;
            bag.Open();
            MySqlCommand cmd = new MySqlCommand("delete from siparisler where id='" + id + "'", bag);
            x = cmd.ExecuteNonQuery();
            bag.Close();
            return x;
        }

        public int urun_cikar(int id)
        {
            int x = 0;
            bag.Open();
            MySqlCommand cmd = new MySqlCommand("delete from urunler where id='" + id + "'", bag);
            x = cmd.ExecuteNonQuery();
            bag.Close();
            return x;
        }


        public int sepet_cikar(int k_id, int s_id)
        {
            int x = 0;
            bag.Open();
            MySqlCommand cmd = new MySqlCommand("delete from sepet where k_id='" + k_id + "' and u_id='" + s_id + "'", bag);
            x = cmd.ExecuteNonQuery();
            bag.Close();
            return x;
        }

        public int fav_cikar(int k_id, int s_id)
        {
            int x = 0;
            bag.Open();
            MySqlCommand cmd = new MySqlCommand("delete from fav where k_id='"+k_id+"' and s_id='"+s_id+"'", bag);
            x = cmd.ExecuteNonQuery();
            bag.Close();
            return x;
        }


        public int sepet_ekle(int k_id, int s_id)
        {
            int x = 0;
            bag.Open();
            MySqlCommand cmd = new MySqlCommand("insert into sepet (k_id,u_id)values('" + k_id + "','" + s_id + "')", bag);
            x = cmd.ExecuteNonQuery();
            bag.Close();
            return x;
        }

        public int fav_ekle(int k_id,int s_id)
        {
            int x = 0;
            bag.Open();
            MySqlCommand cmd = new MySqlCommand("insert into fav (k_id,s_id)values('" + k_id + "','"+s_id+"')", bag);
            x = cmd.ExecuteNonQuery();
            bag.Close();
            return x;
        }
        public int kategori_ekle(string kadi)
        {
            int x = 0;
            bag.Open();
            MySqlCommand cmd = new MySqlCommand("insert into kategori (kadi)values('"+kadi+"')",bag);
            x= cmd.ExecuteNonQuery();
            bag.Close();
            return x;
        }

        public int kategori_silme(string kadi)
        {

            int x = 0;
            bag.Open();
            MySqlCommand cmd = new MySqlCommand("delete from kategori where kadi='"+kadi+"'", bag);
            x = cmd.ExecuteNonQuery();
            bag.Close();
            return x;
        }


    }
}
