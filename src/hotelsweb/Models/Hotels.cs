using System;

namespace hotelsweb.Models
{
  public class Hotel
  {
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public int Rating { get; set; }
    public int StarterPricePerNight { get; set; }
    public int Visits { get; set; }
    public string Year { get; set; }

     public string ImageNum
    {
      get
      {
        Random rnd = new Random();
        int num = rnd.Next(1, 3);
        return  $"hotel_{num}.png";
      }
    }

  }
}