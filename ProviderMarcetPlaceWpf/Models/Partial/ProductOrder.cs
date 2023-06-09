using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProviderMarcetPlaceWpf.Models
{
    partial class ProductOrder
    {
        public Visibility vis 
        {
            get 
            {
                if (Product.ProviderId == HelpClass.AutoUser.Id)
                {
                    return Visibility.Visible;
                }
                else return Visibility.Collapsed;
            }
        }
        public string Statys
        {
            get
            {
                return StatysOrder.Title;
            }

        }
        public string Color
        {
            get
            {
                if (StatysOrder.Id == 5)
                {
                    return "#90EE90";
                }
                else if (StatysOrder.Id == 7 || StatysOrder.Id == 6)
                {
                    return "#FA8072";
                }
                else if (StatysOrder.Id == 8)
                {
                    return "#7FFFD4";
                }
                else return "#FFFFFF";
            }
        }
    }
}
