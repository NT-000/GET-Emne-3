using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialPlatform
{   
    internal class People
    {   
        private List<People> people;
        private int Id { get; set; }
        private string Name { get; set; }
        private int Age { get; set; }
        private string Work { get; set; }
        private string Password { get; set; }

        public People(string name, int age, string work, string password)
        {
            Id = people.Count+1;
            Name = name;
            Age = age;
            Work = work;
            Password = password;
           people.Add(new People(name, age, work, password));
            
        }

        public void ShowPeople()
        {
            foreach (var man in people)
            {
                Console.WriteLine($"{man.Name} id: {man.Id}");
            }
        }

        public void InputId()
        {
            
        }
    }
}
