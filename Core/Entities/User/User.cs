using Core.Entities.Base;

namespace Core.Entities.UserEntities;


public class User : Base.BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
