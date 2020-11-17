using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using MusicDating.Models.Entities;

public class ApplicationUser : IdentityUser
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateCreated { get; set; }

    public ICollection<UserInstrument> UserInstruments { get; set; }
}