
// Sealed significa que a classe não poderá ser herdada
public sealed class User : BaseEntity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Telephone { get; set; }
    public UserPerfil Perfil { get; set; }
}

public enum UserPerfil
{
    Silver,
    Gold,
    Bronze
}