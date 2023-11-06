using System.ComponentModel.DataAnnotations;

namespace CaminhadasAPI.Models.DTOs; 

public class LoginRequestDto {
    [Required] [DataType(DataType.EmailAddress)]
    public string UserName { get; set; }
    
    [Required] [DataType(DataType.Password)]
    public string Password { get; set; }
}