using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameKoreanDirectories
{
    public class Registro
    {
        public string originalPath { get; set; }
        public string originalName { get; set; }
        public string extension { get; set; }
        public string newPath { get; set; }
        public string newName { get; set; }
        public bool converted { get; set; }
        public string status { get; set; }
        public bool isDirectory { get; set; }
        public Registro[] children { get; set; }
    }
}
