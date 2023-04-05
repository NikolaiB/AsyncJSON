using System.Text.Json;
using System.IO;

using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        class Person
        {


            public string Name { get; }
            public int Age { get; set; }
            public Person(string name, int age)
            {
                Name = name;
                Age = age;
            }
        }

        static async Task Main(string[] args)
        {
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                Person tom = new Person("Tom", 37);
                await JsonSerializer.SerializeAsync<Person>(fs, tom);
                Console.WriteLine("Data has been saved to file");
            }

            
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                Person? person = await JsonSerializer.DeserializeAsync<Person>(fs);
                Console.WriteLine($"Name: {person.Name}  Age: {person.Age}");
            }


        }
    }
}