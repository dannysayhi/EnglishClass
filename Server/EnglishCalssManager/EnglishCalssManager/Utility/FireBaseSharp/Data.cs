using System.Collections.Generic;

namespace EnglishCalssManager.Utility.FireBaseSharp
{
    public class testData
    {
        public List<Data> Data { get; set; }
    }

    public class Data
    {
        public object ID { get; set; }
        public object Phone { get; set; }
        public object Groups { get; set; }
        public string TwName { get; set; }
        public string Parent { get; set; }
        public string sendTime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Permission { get; set; }
    }

    public class ManagerSent
    {
        public List<Sent> Sent { get; set; }
    }
    public class ManagerReceives
    {
        public List<Receives> Receives { get; set; }
    }
    public class Sent
    {
            public string content { get; set; }
            public string sender { get; set; }
            public string time { get; set; }
            public string to { get; set; }
    }

    public class Receives
    {
        public string content { get; set; }
        public string sender { get; set; }
        public string time { get; set; }
        public string to { get; set; }
    }

    public class ListCardMsg
    {
        public List<CardMsgs> CardMsgs { get; set; }
        public string CardMsgs_history { get; set; }
    }
    public class CardMsgs
    {
        public string content { get; set; }
        public string student { get; set; }
        public string time { get; set; }
        public string title { get; set; }
        //public int count { get; set; }
    }

    /// <summary>
    /// Bool Card history record
    /// </summary>
    public class CardMsgs_historyClass
    {
        public string CardMsgs_history { get; set; }
    }
 
    public class Course
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public List<string> subscribers { get; set; }
    }
   


}