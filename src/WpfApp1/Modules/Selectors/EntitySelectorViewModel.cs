using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Modules.Selectors
{
    [ObservableObject]
    internal partial class EntitySelectorViewModel
    {
        public EntitySelectorViewModel()
        {
            Entities = new ObservableCollection<ModelBase>
            {
                new Person { Name = "Alice", Age = 30 },
                new Animal { Species = "Dog", Sound = "dddd" },
                new Person { Name = "Bob", Age = 25 },
                new Animal { Species = "Cat", Sound = "cccc" }
            };
            StatusMessage = "Select an entity from the list.";
        }

        [ObservableProperty]
        string _statusMessage;

        public ObservableCollection<ModelBase> Entities { get; set; }

        [RelayCommand]
        public void Add(string entityType)
        {
            try
            {
                if (entityType == "Person")
                {
                    Entities.Add(new Person { Name = $"新用户{DateTime.Now}", Age = 20 });
                }
                else if (entityType == "Animal")
                {
                    Entities.Add(new Animal { Species = $"狗{DateTime.Now:mmssss}", Sound = "汪汪" });
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"添加失败: {ex.Message}";
            }
        }

        [RelayCommand]
        public void Remove(ModelBase item)
        {
            var existItem = Entities.FirstOrDefault(e => e.Id == item.Id);
            Entities.Remove(existItem);
        }
    }
}
