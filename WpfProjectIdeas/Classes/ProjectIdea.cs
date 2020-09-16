using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace WpfProjectIdeas.Classes
{
    public class ProjectIdea
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Frontend { get; set; }
        public string Backend { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        // Boolean values.
        public bool Desktop { get; set; }
        public bool Web { get; set; }
        public bool Mobile { get; set; }
        public bool IOT { get; set; }

        public bool  DragDrop { get; set; }
        public bool Animation { get; set; }
        public bool API { get; set; }
        public bool AI { get; set; }
        public bool Sound { get; set; }
        public bool Video { get; set; }
        public bool Image { get; set; }
        public bool ThreeDModel { get; set; }
        public bool DataScrape { get; set; }
        public bool Chat { get; set; }
        public bool InterDevice { get; set; }
        public bool Server { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Frontend} - {Backend}";
        }

    }
}
