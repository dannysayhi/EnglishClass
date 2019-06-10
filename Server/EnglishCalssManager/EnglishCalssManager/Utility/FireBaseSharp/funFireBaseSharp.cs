using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Windows.Forms;

namespace EnglishCalssManager.Utility.FireBaseSharp
{
  public class funFireBaseSharp
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            //AuthSecret = "gSLuhjaxGzidY1Q2bpetzHySg7XDockgKX5NXdjU",
            //BasePath = "https://rfid-4b9d3.firebaseio.com/"
            AuthSecret = "FAzRi11bjsEuKjNuGIf27gznMamj2mBRLPNFq9YX",
            BasePath = "https://myapplicationfirebasetes-7c3dc.firebaseio.com/"
        };

        IFirebaseClient client;

        public bool IsConnect()
        {
           
            if (client != null)
            {
                //MessageBox.Show("connection OK");
                return true;
            }
            else
            {
                return false;
            }
        }
        public void connection()
        {
            client = new FireSharp.FirebaseClient(config);
        }

        public void disconnection()
        {
            client.Delete("https://myapplicationfirebasetes-7c3dc.firebaseio.com/");
        }

        public async Task<string> ISresponse()
        {
            string Str_response = "null";
            try
            {
                FirebaseResponse response = await client.GetTaskAsync("Pickup/");
                Str_response = response.Body;
            }
            catch (Exception ex)
            { }
           
            return Str_response;
        }

        /// <summary>
        /// Retrieving
        /// </summary>
        /// <returns></returns>
        public async Task<List<Data>> Retrieving()
        {
            List<Data> vehicles=null;
            if (client != null)
            {
                FirebaseResponse response = await client.GetTaskAsync("Pickup/");
                if (response.Body != "null")
                {
                    vehicles = response.ResultAs<List<Data>>().ToList();
                    //Data obj = response.ResultAs<Data>();
                    for (int i = 0; i < vehicles.Count; i++)
                    {
                        if (vehicles[i] != null)
                        {
                           // txt_ID.Text = vehicles[i].ID;
                           // txt_phone.Text = vehicles[i].phone;
                           // txt_Groups.Text = vehicles[i].Groups;
                            //fun_delete(vehicles[i + 1].ID);
                           // MessageBox.Show("Data Retrieved successfully");
                        }
                    }

                }
            }
            return vehicles;
        }

        public async void insert(string _path, object _data)
        {
            SetResponse response = await client.SetTaskAsync(_path, _data);
            Data result = response.ResultAs<Data>();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_phone"></param>
        /// <param name="_groups"></param>
        public async void insert(string _id, string _phone, string _groups)
        {
            var data = new Data
            {
                ID = _id,
                Phone = _phone,
                Groups = _groups,
            };

            SetResponse response = await client.SetTaskAsync("Pickup/" + _id, data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Data inserted" + result.ID);
        }
        /// <summary>
        /// Total Del function
        /// </summary>
        /// <returns></returns>
        public async Task<bool> deleteTotal()
        {
            FirebaseResponse response = await client.DeleteTaskAsync("Pickup/");
            return true;
            //bool result = false;
            //if (client != null)
            //{
            //    FirebaseResponse response = await client.GetTaskAsync("Pickup/");
            //    if (response.Body != "null")
            //    {
            //        List<Data> vehicles = response.ResultAs<List<Data>>().ToList();
            //        //Data obj = response.ResultAs<Data>();
            //        for (int i = 0; i < vehicles.Count; i++)
            //        {
            //            try
            //            {
            //                //txt_ID.Text = vehicles[i].ID;
            //                //txt_phone.Text = vehicles[i].phone;
            //                //txt_Groups.Text = vehicles[i].Groups;
            //                if (vehicles[i] != null)
            //                {
            //                    fun_delete(vehicles[i].ID.ToString());
            //                    result = true;
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                //result = false; 
            //                MessageBox.Show(ex.ToString());
            //            }
            //        }

            //    }
            //}
            //return result;
        }

        /// <summary>
        /// base fun Delete
        /// </summary>
        /// <param name="_ID"></param>
        public async void delete(string _ID)
        {
            FirebaseResponse response = await client.DeleteTaskAsync(_ID);
           // MessageBox.Show("Data Delete  " + _ID + "  successfully");
        }

    }
}
