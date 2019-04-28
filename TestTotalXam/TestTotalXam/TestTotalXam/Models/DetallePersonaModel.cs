using SQLite;

namespace TestTotalXam.Models
{
    public class DetallePersonaModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdDetallePersonaLocal { get; set; }

        //Name
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }

        //Coordinates
        public string latitude { get; set; }
        public string longitude { get; set; }

        //Location
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }

        //Login
        public string uuid { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        //Id
        public string name { get; set; }
        public string value { get; set; }

        //Picture
        public string thumbnail { get; set; }

        //Result
        public string email { get; set; }
        public string phone { get; set; }
        public string cell { get; set; }
    }
}
