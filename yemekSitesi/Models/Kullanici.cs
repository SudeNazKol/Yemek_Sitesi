using System.ComponentModel.DataAnnotations;

public class Kullanici
{
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Sifre { get; set; }
}