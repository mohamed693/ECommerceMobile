﻿namespace ECommereceApi.DTOs.Product
{
    public class CategorySubCategoyValueAddDTO
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string Value { get; set; }
    }
}
