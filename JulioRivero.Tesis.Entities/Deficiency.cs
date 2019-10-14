using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulioRivero.Tesis.Entities
{
    public class Deficiency
    {
        public int Id { get; set; }
        public int ImpairmentId { get; set; }
        public string Kind { get; set; }
        public string Name { get; set; }
        public string Introduction { get; set; }
        public string Symptom { get; set; }
        public string Prevention { get; set; }
        public string FileImage { get; set; }

    }
}
