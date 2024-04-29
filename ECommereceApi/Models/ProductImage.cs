﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ECommereceApi.Models;

[PrimaryKey("ProductId", "Image")]
public partial class ProductImage
{
    [Key]
    public int ProductId { get; set; }

    [Key]
    [StringLength(200)]
    public string Image { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("ProductImages")]
    public virtual Product Product { get; set; }
}