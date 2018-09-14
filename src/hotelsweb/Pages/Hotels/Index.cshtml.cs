using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hotelsweb.Models;

namespace hotelsweb.Pages.Hotels
{
  public class IndexModel : PageModel
  {
    private readonly HotelsContext _context;
    public IndexModel(HotelsContext context)
    {
      _context = context;
    }

    public IList<Hotel> Hotels;
    public async Task OnGetAsync()
    {
      var items = from h in _context.Hotels
                  orderby h.Name
                  select h;

      Hotels = await items.ToListAsync();
    }

  }
}