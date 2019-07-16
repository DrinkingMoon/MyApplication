using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;
using System.Windows;
using System.Windows.Data;

namespace ClassLibrary1
{
    public class Student : DependencyObject,INotifyPropertyChanged
    {
        public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase binding)
        {
            return BindingOperations.SetBinding(this, dp, binding);
        }

        public string UserAge
        {
            get { return (string)GetValue(UserAgeProperty); }
            set { SetValue(UserAgeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserAge.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserAgeProperty =
            DependencyProperty.Register("UserAge", typeof(string), typeof(Student), new PropertyMetadata("0"));

        public static readonly DependencyProperty DepNameProperty =
            DependencyProperty.Register("DepName", typeof(string), typeof(Student));

        public string DepName
        {
            get { return (string)GetValue(DepNameProperty); }
            set { SetValue(DepNameProperty, value); }
        }

        bool _hasJob;

        public bool HasJob
        {
            get { return _hasJob; }
            set { _hasJob = value; }
        }

        string _skill;

        public string Skill
        {
            get { return _skill; }
            set { _skill = value; }
        }

        int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }


        string _name;

        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;

                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
        public static DataTable InitTable()
        {
            ObservableCollection<Student> obStu = InitObCollection();

            DataTable result = new DataTable();

            foreach (PropertyInfo item in typeof(Student).GetProperties())
            {
                result.Columns.Add(item.Name);
            }

            foreach (Student item in obStu)
            {
                DataRow dr = result.NewRow();
                foreach (PropertyInfo property in typeof(Student).GetProperties())
                {
                    dr[property.Name] = property.GetValue(item);
                }

                result.Rows.Add(dr);
            }

            return result;
        }

        public static ObservableCollection<Student> InitObCollection()
        {
            ObservableCollection<Student> obResult = new ObservableCollection<Student>();

            obResult.Add(new Student() { Id = 1, Age = 25, Name = "Tim" });
            obResult.Add(new Student() { Id = 2, Age = 21, Name = "Tom" });
            obResult.Add(new Student() { Id = 3, Age = 27, Name = "Daive" });
            obResult.Add(new Student() { Id = 4, Age = 31, Name = "Jim" });
            obResult.Add(new Student() { Id = 5, Age = 34, Name = "Ketty" });
            obResult.Add(new Student() { Id = 6, Age = 37, Name = "Alen" });

            return obResult;
        }

        public static readonly RoutedEvent NameChangeEvent =
            EventManager.RegisterRoutedEvent("NameChange", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Student));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
