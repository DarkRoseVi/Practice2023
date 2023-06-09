﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderMarcetPlaceWpf.Models
{
    partial class Product
    {
        public string FullInfo
        {
            get
            {
                return Title;
            }
        }

        public byte[] MainPhoto
        {
            get
            {
                var firstphoro = this.ProductPhoto.FirstOrDefault();
                if (firstphoro != null)
                    return firstphoro.Photo;
                return null;
            }
        }
        private int _count = 1;

     
    }
}
