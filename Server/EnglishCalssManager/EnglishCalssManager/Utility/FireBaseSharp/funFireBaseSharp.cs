using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Windows.Forms;
using System.Collections;
using Newtonsoft.Json;

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

        CardMsgs_historyClass _cardMsgHistory = new CardMsgs_historyClass();

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
            //client.Delete("https://myapplicationfirebasetes-7c3dc.firebaseio.com/");
            client.DeleteAsync("https://myapplicationfirebasetes-7c3dc.firebaseio.com/");
        }

        public async Task<string> ISresponse()
        {
            string Str_response = "null";
            try
            {
                FirebaseResponse response = await client.GetAsync("Pickup/");
                Str_response = response.Body;
            }
            catch (Exception ex)
            { }
           
            return Str_response;
        }

        public async Task<string> getData(string _path)
        {
            _cardMsgHistory.CardMsgs_history = "0";
            FirebaseResponse response = await client.GetAsync(_path);
            return _cardMsgHistory.CardMsgs_history = response.Body;
        }

        /// <summary>
        /// Retrieving
        /// </summary>
        /// <returns></returns>
        public async Task<List<Data>> Retrieving()
        {
            ArrayList _vehicles = new ArrayList();
            List<Data> vehicles=new List<Data>();
            testData vt = new testData();
            Data vtemp = new Data();
            if (client != null)
            {
                FirebaseResponse response = await client.GetAsync("Pickup/");
                if (response.Body != "null")
                {
                    // var dd =  JsonConvert.DeserializeObject<Data>(response.Body);
                    //string test = response.Body.Replace("null,","");
                    var mList = JsonConvert.DeserializeObject<IDictionary<string, Data>>(response.Body);
                    //vehicles = response.ResultAs<List<Data>>();
                    //vt = response.ResultAs<testData>();
                    //_vehicles =  response.ResultAs<ArrayList>();

                    foreach(var ml in mList)
                    {
                        vehicles.Add(ml.Value);
                    }
                    
                    List<string> dastr = new List<string>();

                    //for(int i =0;i< _vehicles.Count;i++)
                    //{
                    //    if(_vehicles[i]!=null)
                    //    {
                    //        var customerFromJson = JsonConvert.DeserializeObject<Data>(_vehicles[i].ToString());
                    //        //vtemp.ID = customerFromJson.ID;
                    //        //vtemp.Phone = customerFromJson.Phone;
                    //        //vtemp.sendTime = customerFromJson.sendTime;
                    //        //vtemp.TwName = customerFromJson.TwName;
                    //        vehicles.Add(customerFromJson);
                    //    }
                    //}
                    /*
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
                    */

                }
            }
            return vehicles;
        }
        /// <summary>
        /// normal insert
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_data"></param>
        public async void insert(string _path, object _data)
        {
            SetResponse response = await client.SetAsync(_path, _data);
            Data result = response.ResultAs<Data>();
        }

        /// <summary>
        /// normal insert
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_data"></param>
        public async void update(string _path, object _data)
        {
            //SetResponse response = await client.UpdateAsync(_path, _data);
            //Data result = response.ResultAs<Data>();

            FirebaseResponse response = await client.UpdateAsync(_path, _data);
            Data result = response.ResultAs<Data>(); //The response will contain the data written
        }

        /// <summary>
        /// normal insert
        /// </summary>
        /// <param name="_path"></param>
        /// <param name="_data"></param>
        public void push(string _path, object _data)
        {
            PushResponse response = client.Push(_path, _data);
            string res= response.Result.name; //The result will contain the child name of the new data that was added
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

            SetResponse response = await client.SetAsync("Pickup/" + _id, data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Data inserted" + result.ID);
        }

        /// <summary>
        /// Total Del function
        /// </summary>
        /// <returns></returns>
        public async Task<bool> deleteTotal()
        {
            FirebaseResponse response = await client.DeleteAsync("Pickup/");
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
            FirebaseResponse response = await client.DeleteAsync(_ID);
           // MessageBox.Show("Data Delete  " + _ID + "  successfully");
        }


        /////////////////////////
        /// <summary>
        /// Retrieving
        /// </summary>
        /// <returns></returns>
        public async Task<List<CardMsgs>> Retrieving(string _str)
        {
            List<CardMsgs> vehicles = null;
            if (client != null)
            {
                FirebaseResponse response = await client.GetAsync(_str);
                if (response.Body != "null")
                {
                    vehicles = response.ResultAs<List<CardMsgs>>().ToList();
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

        /////////////////////////
        /// <summary>
        /// Retrieving
        /// </summary>
        /// <returns></returns>
        public async Task<CardMsgs> Retrieving_unit(string _str)
        {
            CardMsgs vehicles = null;
            if (client != null)
            {
                FirebaseResponse response = await client.GetAsync(_str);
                if (response.Body != "null")
                {
                    vehicles = response.ResultAs<CardMsgs>();
                }
            }
            return vehicles;
        }
    }
}
