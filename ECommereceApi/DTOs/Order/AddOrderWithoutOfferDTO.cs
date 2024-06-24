﻿using ECommereceApi.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommereceApi.DTOs.Order
{
    public class AddOrderWithoutOfferDTO
    {
        public int UserId { get; set; }
        public string Governerate { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
