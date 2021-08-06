using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorReviewAPI.Models;
using VendorReviewAPI.Services;

namespace VendorReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        [HttpPost]
        public Vendor AddRating(int vendorId, [FromBody] VendorRating rating)
        {
            var vendor = VendorService.Instance.AddRating(vendorId, rating);

            return vendor;
        }
    }
}
