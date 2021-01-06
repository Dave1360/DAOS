using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using MusicDating.Models.Entities;

public class Profile
{
    public string ProfileId { get; set; }
    public int? ZipCode { get; set; }
    public string City { get; set; }
    public int? PhoneNumber { get; set; }
    public DateTime? Birthday { get; set; }
    public string Description { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

}