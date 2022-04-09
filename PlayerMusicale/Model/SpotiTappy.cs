using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;

namespace PlayerMusicale.Model
{
    public class SpotiTappy
    {
        public static List<Playlist> Playlists = new List<Playlist>();

        public SpotiTappy()
        {

        }

        public static void SaveFiles()
        {
            StreamWriter sw;
            using (sw = new StreamWriter("../../../Serialization/AllSongs.xml")) 
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));
                serializer.Serialize(sw, Song.AllSongs);
            }
            using (sw = new StreamWriter("../../../Serialization/PlayLists.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));
                serializer.Serialize(sw, Playlists);
            }

            JObject obj = new JObject();
            obj.RemoveAll();
            obj.Add("SongID", Song.NextID);
            obj.Add("PlayListID", Playlist.nextID);
            string json = obj.ToString();
            File.WriteAllText(@"../../../Serialization/IDs.json", json);
        }

        public static void LoadFiles()
        {
            StreamReader sr;
            if(File.Exists("../../../Serialization/AllSongs.xml"))
            {
                using (sr = new StreamReader("../../../Serialization/AllSongs.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));
                    Song.AllSongs = (List<Song>)serializer.Deserialize(sr);
                }
            }
            
            if (File.Exists("../../../Serialization/PlayLists.xml"))
            {
                using (sr = new StreamReader("../../../Serialization/PlayLists.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Playlist>));
                    Playlists = (List<Playlist>)serializer.Deserialize(sr);
                }
            }

            JObject obj = JObject.Parse(File.ReadAllText(@"../../../Serialization/IDs.json"));
            uint id1 = (uint)obj.First;
            uint id2 = (uint)obj.Last;

            Song.NextID = id1;
            Playlist.nextID = id2;

        }
    }
}
