
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MyWpfMVVMApp.Common;
using MyWpfMVVMApp.Entity;

namespace MyWpfMVVMApp.ViewModel
{
    public class DishViewModel : RaisePropertyChanged
    {
        Dish _dish;

        bool _isSelected;

        public Dish Dish { get => _dish; set => _dish = value; }
        public bool IsSelected { get => _isSelected; set => _isSelected = value; }
    }
}
