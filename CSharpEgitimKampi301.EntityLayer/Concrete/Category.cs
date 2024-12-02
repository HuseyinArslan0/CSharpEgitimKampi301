using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public List<Product> Products { get; set; }
    }

    // field - variable - property
    /*
     eğer bir class altında tanımlanırsa -> Field

            int a;

     eğer get ve set ile tanımlanırsa -> Property

        public int b { get; set; };

     eğer bir metot içerisinde tanımlanırsa -> Variable

         int method()
        {
            int c;
        }
     
     */
}
