using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendorReviewAPI.Models
{
    public class Vendor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<VendorRating> Ratings { get; set; }
    }

    public class VendorRating
    {
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
