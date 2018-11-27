using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen.Assessment
{
    public abstract class Person: IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Person()
        {

        }
        public Person(int height)
        {
            this.height = height;
        }

        public int height { get; set; }

        public abstract override string ToString();

        public abstract string GetDetails();
    }
}
