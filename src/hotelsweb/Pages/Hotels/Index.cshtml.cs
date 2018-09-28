using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hotelsweb.Models;
using Microsoft.Extensions.Logging;

namespace hotelsweb.Pages.Hotels
{
    public class IndexModel : PageModel
    {
        private readonly HotelsContext context;
        private readonly ILogger<IndexModel> logger;

        public IndexModel(HotelsContext context, ILogger<IndexModel> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public IList<Hotel> Hotels;
        public async Task OnGetAsync()
        {
            var rand = new Random();
            Hotels = await context.Hotels.OrderBy(h => rand.Next()).ToListAsync();
            logger.LogInformation("Top hotel: {hotel}", Hotels.First().Name);
        }

    }
}