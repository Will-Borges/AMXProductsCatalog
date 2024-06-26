﻿namespace AMXProductsCatalog.Views.Products.UpdateCar.Request
{
    public class UpdateCarProductRequestDTO
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        public UpdateCarProductRequestDTO() { }

        public UpdateCarProductRequestDTO(long id, string brand, string model, int year, decimal price)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
        }
    }
}
