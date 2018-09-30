using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotelsweb.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace hotelsweb.Pages.Hotels
{
    public class IndexModel : PageModel
    {
        private readonly HotelsContext _context;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(HotelsContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Hotel> Hotels { get; private set; }

        public async Task OnGetAsync()
        {
            var rand = new Random();
            Hotels = await _context.Hotels.OrderBy(h => rand.Next()).ToListAsync().ConfigureAwait(false);

            _logger.LogInformation("Top hotel: {hotel}", Hotels.First().Name);
        }
    }
}