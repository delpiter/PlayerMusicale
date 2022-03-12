using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PlayerMusicale.Model
{
    [Serializable]
    public class Playlist
    {
        public string Name { get; set; }
        public ObservableCollection<Song> Songs { get; set; }
        public Playlist() { }
        public Playlist(string name)
        {
            this.Name = name;
            this.Songs = new ObservableCollection<Song>();
        }
    }
}
