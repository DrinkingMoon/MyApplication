using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWpfMVVMApp.Common;

namespace MyWpfMVVMApp.Entity
{

    public class Dish : BaseEntity
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Comment { get; set; }


        public double? Score { get; set; }

        [ForeignKey("Restaurant")]
        public string FKID_Restaurant { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
