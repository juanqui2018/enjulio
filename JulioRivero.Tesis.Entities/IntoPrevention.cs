using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulioRivero.Tesis.Entities
{
    public class IntoPrevention
    {
        public int Id { get; set; }
        public int PreventionId { get; set; }
        public string Kind { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Prevention { get; set; }
        public string FileImage { get; set; }
    }
}
