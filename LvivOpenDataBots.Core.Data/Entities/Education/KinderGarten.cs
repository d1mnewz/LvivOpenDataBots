// ReSharper disable InconsistentNaming

using System.Runtime.Serialization;

namespace LvivOpenDataBots.Core.Data.Entities
{
    // ReSharper disable once ClassNeverInstantiated.Global
    [DataContract]
    public class KinderGarten : Record
    {
        public int _id { get; set; }
        public string Name { get; set; }
        public string Phone_number { get; set; }
        public string Post_code { get; set; }

        public string Street_name { get; set; }
        public string Building_number { get; set; }



        public string Holder { get; set; }


        // may need renaming after Bogdan change names in API
        [DataMember(Name = "E-mail")]
        public string Email { get; set; }

        [DataMember(Name = "Coordinates_(longitude)")]
        public string Coordinates_longitude { get; set; }

        [DataMember(Name = "Coordinates_(latitude)")]
        public string Coordinates_latitude { get; set; }

        [DataMember(Name = "Web-site")]
        public string Website { get; set; }
    }

    public abstract class Record
    {
    }
}




//URL: http://opendata.city-adm.lviv.ua/dataset/shkola-sadol/resource/92ac88b2-f4cf-46ac-a8b8-64600c1ec23a

//Структура набору даних:
//    'Name' - назва школи-садку;
//    'Street_name' - назва вулиці;
//    'Building_number' - номер будинку;
//    'Post_code' - поштовий індекс;
//    'Phone_number' - номер телефону;
//    'E-mail' - електронна пошта;
//    'Web-site' - веб-сайт;
//    'Holder' - кому підпорядковується;
//    'Coordinates_(longitude)' - координати(довгота);
//    'Coordinates_(latitude)' - координати(широта).