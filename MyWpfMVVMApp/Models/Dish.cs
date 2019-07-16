using MyWpfMVVMApp.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfMVVMApp.Models
{
    public class Dish : RaisePropertyChanged
    {
        [Key]
        public Guid? PKID { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Comment { get; set; }

        public double? Score { get; set; }

        [ForeignKey("Restaurant")]
        public Guid FKID_Restaurant { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
