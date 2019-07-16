using MyWpfMVVMApp.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfMVVMApp.Models
{
    public class Restaurant : RaisePropertyChanged
    {
        [Key]
        public Guid? PKID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
