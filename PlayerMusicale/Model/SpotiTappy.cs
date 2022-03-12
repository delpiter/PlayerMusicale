using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;

namespace PlayerMusicale.Model
{
    public static class SpotiTappy
    {
        public static ObservableCollection<Playlist> Playlists = new ObservableCollection<Playlist>();

        public static void SaveXML()
        {
            StreamWriter sw;
            using (sw = new StreamWriter("../Serialization/AllSongs.xml")) 
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Song>));
                serializer.Serialize(sw, Song.AllSongs);
            }
            using (sw = new StreamWriter("../Serialization/PlayObservableCollections.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Song>));
                serializer.Serialize(sw, Playlists);
            }

        }

        public static void LoadXML()
        {
            StreamReader sr;
            if(File.Exists("../Serialization/AllSongs.xml"))
            {
                using (sr = new StreamReader("../Serialization/AllSongs.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Song>));
                    Song.AllSongs = (ObservableCollection<Song>)serializer.Deserialize(sr);
                }
            }
            
            if (File.Exists("../Serialization/Play.xml"))
            {
                using (sr = new StreamReader("../Serialization/PlayObservableCollections.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Playlist>));
                    Playlists = (ObservableCollection<Playlist>)serializer.Deserialize(sr);
                }
            }
        }
    }
}
