using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Models.Base
{
    public class CommonEntity<TKey> : Catalog<TKey>
    {
        public string Description { get; set; }
    }
}
