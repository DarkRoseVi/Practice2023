using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdministratorMarketPlaceWpf.Models
{
    partial class Order
    {
        public Visibility VisiblAdress
        {
            get
            {

                if (AdressDelivery == null || AdressDelivery.Length == 0)
                    return Visibility.Collapsed;

                else
                    return Visibility.Visible;


            }
        }

        public Visibility VisbDelPoint
        {
            get
            {

                if (DeliveryPointId == null)
                {
                    return Visibility.Collapsed;
                }
                else return Visibility.Visible;
            }
        }


        public string AdressPoint
        {
            get
            {
                if (DeliveryPoint != null)
                {

                    return DeliveryPoint.Adress;
                }
                else return "";
            }

        }

        public string AdressDel
        {
            get
            {
                return AdressDelivery;
            }
        }
    }
}
