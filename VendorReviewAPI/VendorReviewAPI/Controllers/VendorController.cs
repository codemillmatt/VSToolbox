using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendorReviewAPI.Models;
using VendorReviewAPI.Services;

namespace VendorReviewAPI.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    { 
        [HttpGet]
        public List<Vendor> GetAllVendors()
        {
            return VendorService.Instance.GetAllVendors();
        }
    }
}
