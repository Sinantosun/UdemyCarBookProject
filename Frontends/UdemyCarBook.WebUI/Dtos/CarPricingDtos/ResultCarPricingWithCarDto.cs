namespace UdemyCarBook.WebUI.Dtos.CarPricingDtos
{
    public class ResultCarPricingWithCarDto
    {
        public int CarPricingId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Amount { get; set; }
        public string CoverImageURL { get; set; }
    }
}
