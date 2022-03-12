using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerMusicale.Model
{
    [Serializable]
    public class Song
    {
        private static uint NextID = 0;
        public uint ID { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Path { get; set; }

        public Song() { }

        public Song(string name, string author, string path)
        {
            this.Name = name;
            this.Author = author;
            this.Path = path;
            this.ID = NextID++;
        }
    }
}
