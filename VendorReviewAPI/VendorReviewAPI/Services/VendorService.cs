using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorReviewAPI.Models;

namespace VendorReviewAPI.Services
{
    public class VendorService
    {
        public static VendorService Instance { get; } = new VendorService();

        private VendorService()
        {
            InitializeVendors();
        }

        List<Vendor> vendors;

        public List<Vendor> GetAllVendors()
        {
            return vendors;
        }

        public Vendor AddRating(int vendorId, VendorRating rating)
        {
            rating.Review += " (Toolbox)";
            vendors.Find(v => v.Id == vendorId)?.Ratings.Add(rating);

            return vendors.Find(v => v.Id == vendorId);
        }

        private void InitializeVendors()
        {
            vendors = new List<Vendor>()
            {
                new Vendor {
                    Id = 1,
                    Name = "Cog City",
                    Ratings = new List<VendorRating>{
                        new VendorRating{ Rating = 1, Review = "Good" },
                        new VendorRating{ Rating = 2, Review = "OK" },
                        new VendorRating{ Rating = 3, Review = "Better" }
                    }
                },
                new Vendor{
                    Id = 2,
                    Name = "Industrock",
                    Ratings = new List<VendorRating>{
                        new VendorRating{ Rating = 1, Review = "Good" },
                        new VendorRating{ Rating = 2, Review = "OK" },
                        new VendorRating{ Rating = 3, Review = "Better" }
                    }
                },
                new Vendor{
                    Id = 3,
                    Name = "Factory Train",
                    Ratings = new List<VendorRating>{
                        new VendorRating{ Rating = 1, Review = "Good" },
                        new VendorRating{ Rating = 2, Review = "OK" },
                        new VendorRating{ Rating = 3, Review = "Better" }
                    }
                },
                new Vendor{
                    Id = 4,
                    Name = "Stocket",
                    Ratings = new List<VendorRating>{
                        new VendorRating{ Rating = 1, Review = "Good" },
                        new VendorRating{ Rating = 2, Review = "OK" },
                        new VendorRating{ Rating = 3, Review = "Better" }
                    }
                }
            };
        }
    }
}
