
public sealed record CreateUserResponse
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Telephone { get; set; }
    public UserPerfil UserPerfil { get; set; }
}
