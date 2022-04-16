using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace PlayerMusicale.Model
{
    [Serializable]
    public class Song
    {
        #region Variables
        public static uint NextID;

        public uint ID { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Path { get; set; }

        public string Duration { get; set; }

        [System.Xml.Serialization.XmlIgnore]
        public BitmapImage CustomImage { get; set; }

        public static string DefaultImagePath = "../../../Assets/Images/DefaultSong.png";
        #endregion

        public Song() { }

        public Song(string name, string author, string path, string duration, BitmapImage bi)
        {
            this.Name = name;
            this.Author = author;
            this.Path = path;
            this.Duration = duration;
            this.CustomImage = bi;
            this.ID = NextID++;
        }

        public Song(string name, string author, string path, string duration)
        {
            this.Name = name;
            this.Author = author;
            this.Path = path;
            this.Duration = duration;
            this.CustomImage = new BitmapImage(new Uri(DefaultImagePath));
            this.ID = NextID++;
        }
    }
}
