﻿using System.ComponentModel.DataAnnotations;

namespace WestSouth.IDP.Entities;

public class User : IConcurrencyAware
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(200)]
    [Required]
    public string Subject { get; set; }

    [MaxLength(200)]
    public string UserName { get; set; }

    [MaxLength(200)]
    public string Password { get; set; }

    [Required]
    public bool Active { get; set; }

    [ConcurrencyCheck]
    public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

    public ICollection<UserClaim> Claims { get; set; } = new List<UserClaim>();
    
    [MaxLength(200)]
    public string Email { get; set; }
    
    [MaxLength(200)]
    public string? SecurityCode { get; set; }

    public DateTime SecurityCodeExpirationDate { get; set; }
}