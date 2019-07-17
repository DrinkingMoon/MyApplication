
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MyWpfMVVMApp.Common;
using MyWpfMVVMApp.Entity;
using MyWpfMVVMApp.Service;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MyWpfMVVMApp.ViewModel
{
    public class MainViewModel :  RaisePropertyChanged
    {
        IDataService<Restaurant> _dataService;

        DishViewModel _selectedDishViewModel;

        double _count;

        string _name;

        private Restaurant _restaurant;

        ObservableCollection<DishViewModel> _dishViewModels = new ObservableCollection<DishViewModel>();

        public DishViewModel SelectedDishViewModel { get => _selectedDishViewModel; set => _selectedDishViewModel = value; }

        public double Count { get => _count; set => _count = value; }

        public string Name { get => _name; set => _name = value; }

        public Restaurant Restaurant { get => _restaurant; set => _restaurant = value; }

        public ObservableCollection<DishViewModel> DishViewModels { get => _dishViewModels; set => _dishViewModels = value; }

        public ICommand MouseMoveCMD
        {
            get {
                return new RelayCommand(() => 
                {
                    Messenger.Default.Send<object>("鼠标滑过", "MouseMove");
                });
            }
        }

        public ICommand PlaceOrderCommand { get; set; }

        public ICommand SelectItemCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Count = DishViewModels.Count(i => i.IsSelected == true);
                });
            }
        }

        public ICommand RemoveItemCommand { get; set; }

        public ICommand AddItemCMD { get {
                return new RelayCommand(() =>
                {

                    DishViewModel addDvm = new DishViewModel() { Dish = new Dish(), IsSelected = false };
                    DishViewModels.Add(addDvm);
                    SelectedDishViewModel = addDvm;
                });
            } }

        public ICommand DeleteItemCMD { get {
                return new RelayCommand(() =>
                {
                    DishViewModels.Remove(SelectedDishViewModel);
                });
            } }

        public MainViewModel()
        {
            _dataService = new SqlDataService();

            LoadRestaurant();
            LoadDishViewModels();


            PlaceOrderCommand = new RelayCommand(PlaceOrder);
            RemoveItemCommand = new RelayCommand(() =>
            {
                _dishViewModels.RemoveAt(0);
            });
        }

        void LoadRestaurant()
        {
            _restaurant = _dataService.GetItem();
        }

        void LoadDishViewModels()
        {
            _restaurant.Dishes.ToList().ForEach(k => 
            {
                DishViewModel dvm = new DishViewModel()
                {
                    Dish = k,
                    IsSelected = false
                };
                
                _dishViewModels.Add(dvm);
            }); 
        }

        void PlaceOrder()
        {
            _restaurant.Dishes = new List<Dish>();

            if (_dataService is XmlDataService)
            {
                _dishViewModels.Where(k => k.IsSelected == true).ToList().ForEach(k => { _restaurant.Dishes.Add(k.Dish); });
            }
            else if(_dataService is SqlDataService)
            {
                _dishViewModels.ToList().ForEach(k => { _restaurant.Dishes.Add(k.Dish); });
            }

            _dataService.SaveInfo(_restaurant);

            Messenger.Default.Send<string>("设置成功", "Submit");
        }
    }
}