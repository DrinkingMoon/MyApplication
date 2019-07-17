using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfMVVMApp.Common
{
    public abstract class BaseEntity : RaisePropertyChanged
    {
        [Key]
        public string PKID { get; set; }

        public DateTime? PKCreateTime { get; set; }

        public string PKCreateUser { get; set; }

        public DateTime? PKModifyTime { get; set; }

        public string PKModifyUser { get; set; }

        public DateTime? PKDeleteTime { get; set; }

        public string PKDeleteUser { get; set; }


        public BaseEntity()
        {
            //PKID = Guid.NewGuid().ToString();
            //PKCreateTime = DateTime.Now;
        }
    }
}
