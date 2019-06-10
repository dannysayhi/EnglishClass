using System.Collections.Generic;

namespace EnglishCalssManager.Utility.FireBaseSharp
{
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

    public class Course
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public List<string> subscribers { get; set; }
    }
   

}