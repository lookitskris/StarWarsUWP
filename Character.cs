using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace StarWars
{
    [DataContract]
    public class Character
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public string portraitID { get; set; } 
        public BitmapImage portrait { get; set; }
    }
}
