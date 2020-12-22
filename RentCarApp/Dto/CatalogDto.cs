using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCarApp.Dto
{
    public class CatalogDto<TKey>
    {
        public TKey Id { get; set; }
        public string Name { get; set; }
    }
}
