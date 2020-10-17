using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Speakers
    {
        public int Id { get; set; }

        [StringLength(2000)]
        public String Name { get; set; }
        [StringLength(4000)]
        public String Bio { get; set; }
        [StringLength(1000)]
        public  virtual String WebSite { get; set; }


    }
}
