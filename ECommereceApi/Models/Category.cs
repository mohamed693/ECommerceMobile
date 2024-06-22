﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ECommereceApi.Models;

[Table("Category")]
public partial class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    //public string ImageUri { get; set; }
    public string ImageId { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    public virtual ICollection<CategorySubCategory> Subs { get; set; } = new List<CategorySubCategory>();
}