using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1.Serialize
{

    internal class SerializeTest
    {
        public ObservableCollection<SimpleData> Data { get; }

        public SerializeTest()
        {
            Data = [];
            Data.Add(new SimpleData() { Value = 1, EnumType = EnumType.Show });
            Data.Add(new SimpleData() { Value = 2, EnumType = EnumType.Edit });
        }

        public static void Run()
        {
            var node = new Node()
            {
                Name = "node1",

            };
            node.Data[1].Value = 99;
            var stringValue = JsonSerializer.Serialize(node);

            var noddddd = JsonSerializer.Deserialize<Node>(stringValue);


        }

    }

    public class Node 
    {

        public string Name { get; set; }

        public ObservableCollection<SimpleData> Data { get;  set; }

        public Node()
        {
            Data = [];
            Data.Add(new SimpleData() { Value = 1, EnumType = EnumType.Show });
            Data.Add(new SimpleData() { Value = 2, EnumType = EnumType.Edit });
        }

    }


    public class SimpleData
    {
        public  double Value { get; set; }

        public EnumType EnumType { get; set; }
    }

    public enum EnumType
    {
        Show,
        Edit
    }
}
