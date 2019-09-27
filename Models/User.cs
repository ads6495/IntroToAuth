using System;

namespace IntroToAuth.Models
{
  public class User
  {
    public int id { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }
    public DateTime DateSignedUp { get; set; }
    public DateTime LastLoggedIn { get; set; }
  }
}