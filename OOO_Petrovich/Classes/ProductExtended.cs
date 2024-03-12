using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace OOO_Petrovich.Classes
{
    internal class ProductExtended
    {
        public Model.product Product { get; set; }

        public string PhotoCor 
        {
            get 
            {
                if (!File.Exists(Environment.CurrentDirectory + "/Images/" + Product.productImage))
                    return "/Resources/picture.png";
                return Environment.CurrentDirectory + "Images" + Product.productImage; 
            }
        }
    }
}
