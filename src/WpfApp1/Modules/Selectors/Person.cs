using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Modules.Selectors
{
    public class ModelBase : ObservableObject
    {
        public Guid Id { get; } = Guid.NewGuid();
    }

    public class Person : ModelBase
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Animal : ModelBase
    {
        public string Species { get; set; }
        public string Sound { get; set; }
    }
}
