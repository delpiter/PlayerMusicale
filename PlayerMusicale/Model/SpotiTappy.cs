using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using System.Windows.Media.Imaging;

namespace PlayerMusicale.Model
{
    public class SpotiTappy
    {
        public List<Playlist> Playlists { get; set; }

        public List<Song> AllSongs { get; set; }

        public SpotiTappy()
        {
            this.Playlists = new List<Playlist>();
            this.AllSongs = new List<Song>();
        }

        public void SaveFiles()
        {
            StreamWriter sw;
            using (sw = new StreamWriter("../../../Serialization/AllSongs.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));
                serializer.Serialize(sw, AllSongs);
            }
            using (sw = new StreamWriter("../../../Serialization/PlayLists.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Playlist>));
                serializer.Serialize(sw, Playlists);
            }

            JObject obj = new JObject();
            obj.RemoveAll();
            obj.Add("SongID", Song.NextID);
            obj.Add("PlayListID", Playlist.nextID);
            string json = obj.ToString();
            File.WriteAllText(@"../../../Serialization/IDs.json", json);
        }

        public void LoadFiles()
        {
            StreamReader sr;
            if (File.Exists("../../../Serialization/AllSongs.xml"))
            {
                using (sr = new StreamReader("../../../Serialization/AllSongs.xml"))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Song>));
                    AllSongs = (List<Song>)serializer.Deserialize(sr);
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

            ImageOnStartup();
        }
        private void ImageOnStartup()
        {
            for (int i = 0; i < AllSongs.Count; i++)
            {
                FileInfo f = new FileInfo(AllSongs[i].Path);
                AllSongs[i].CustomImage = LoadImages(TagLib.File.Create(f.FullName));
            }
            for (int i = 0; i < Playlists.Count; i++)
            {
                Playlists[i].Image = new BitmapImage(new Uri(Playlists[i].ImagePath));
            }
        }

        private BitmapImage LoadImages(TagLib.File tfile)
        {
            MemoryStream ms = new MemoryStream(tfile.Tag.Pictures[0].Data.Data);

            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = ms;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            bitmap.Freeze();

            return bitmap;

        }
    }
}

