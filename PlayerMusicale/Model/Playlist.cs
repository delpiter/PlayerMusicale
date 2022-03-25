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
        static string DefaultImagePath = "../../Assets/Images/DefaultPlaylist.png";
        public string Name { get; set; }
        public List<Song> Songs { get; set; }
        public BitmapImage Image { get; set; }

        public Playlist() { }
        public Playlist(string name)
        {
            this.Name = name;
            this.Songs = new List<Song>();
            this.Image = new BitmapImage(new Uri(DefaultImagePath));
        }
    }
}
