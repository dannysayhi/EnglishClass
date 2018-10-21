using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text;

namespace EnglishCalssManager.Broadcast.CardNotice
{
    class CardNotice
    {
        public static String SendNotificationFromFirebaseCloud(String Title, String Message)
        {
            var result = "-1";
            var webAddr = "https://fcm.googleapis.com/fcm/send";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "key=AAAA9W25YKA:APA91bE4aCDtVqe_JIOWt3NFqXsSnERtVHxGXFqId4RRx8jFVaxSLP0MORI5_qLo0qtKTpGV5wyQi4hxdR4Njiwmeuf0vZqKyjVyt8QjRaKEcIvvHRPfDlbj_rbnCt7h_elp2H2HLzuA");
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string strNJson = @"{
                    ""to"": ""eOqBiqOVyyI:APA91bGp82KZ2CRiZImYU5Dkwgnv0fL6_QEB14Sod7TEl4O0woax_TTX0giFWyIyxMlx8oVzv57Yq96rth87tsji4qWurL_RD4ukOxg32OdV9jctmVE_J_le3I0lgKVkIgEfbt5XK8s9"",
                    ""data"": {
                        ""ShortDesc"": ""Some short desc"",
                        ""IncidentNo"": ""any number"",
                        ""Description"": ""detail desc""
                      },
                      ""notification"": {
                                    ""title"":" + @"""" + @"" + Title + @"" + @"""" + @",
                        ""text"":" + @"""" + @"" + Message + @"" + @"""" + @",
                    ""sound"":""default""
                      }
                }";

                streamWriter.Write(strNJson);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }
    }
}
