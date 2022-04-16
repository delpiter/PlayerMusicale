using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace PlayerMusicale.Model
{
    [Serializable]
    public class Playlist
    {
        #region Variables
        public static uint nextID;

        static string DefaultImagePath = "Assets/Images/DefaultPlaylist.png";

        public string Name { get; set; }

        public List<Song> Songs { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public BitmapImage Image { get; set; }

        public string ImagePath { get; set; }

        public uint ID { get; set; }
        #endregion

        public Playlist() { }
        public Playlist(string name)
        {
            this.ID = nextID++;
            this.Name = name;
            this.Songs = new List<Song>();
            //this.Image = new BitmapImage(new Uri(DefaultImagePath));
        }

        public void ChangeImage(string path)
        {
            this.ImagePath = path;
            this.Image = new BitmapImage(new Uri(path));
        }

        public void Add(Song s)
        {
            this.Songs.Add(s);
        }
    }
}
