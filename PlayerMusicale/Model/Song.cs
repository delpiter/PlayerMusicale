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
        public static ObservableCollection<Song> AllSongs = new ObservableCollection<Song>();

        private static uint NextID = 0;
        public uint ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Path { get; set; }
        public BitmapImage CustomImage { get; set; }

        public const string ImagePath = "../../Assets/Images/DefaultSong.png";

        public Song() { }

        public Song(string name, string author, string path, BitmapImage bi)
        {
            this.Name = name;
            this.Author = author;
            this.Path = path;
            this.CustomImage = bi;
            this.ID = NextID++;
            AllSongs.Add(this);
            
            //sbrobobbo
        }
    }
}
