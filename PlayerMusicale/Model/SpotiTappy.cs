using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace PlayerMusicale.Model
{
    [Serializable]
    internal class SpotiTappy
    {
        public static List<Song> AllSongs { get; set; }
        public List<Playlist> Playlists { get; set; }

        public SpotiTappy() { }



        public void SaveXML()
        {
            StreamWriter sw;
            using (sw = new StreamWriter("../Serialization/AllSongs.xml")) 
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));
                serializer.Serialize(sw, AllSongs);
            }
            using (sw = new StreamWriter("../Serialization/PlayLists.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));
                serializer.Serialize(sw, Playlists);
            }

        }

        public void LoadXML()
        {
            StreamReader sr;
            if(File.Exists("../Serialization/AllSongs.xml"))
            {
                using (sr = new StreamReader("../Serialization/AllSongs.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));
                    AllSongs = (List<Song>)serializer.Deserialize(sr);
                }
            }
            
            if (File.Exists("../Serialization/Play.xml"))
            {
                using (sr = new StreamReader("../Serialization/PlayLists.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Playlist>));
                    Playlists = (List<Playlist>)serializer.Deserialize(sr);
                }
            }
        }
    }
}
