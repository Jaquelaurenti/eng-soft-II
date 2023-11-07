public sealed record CreateUserResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UserPerfil Perfil { get; set; }
    //public string Password { get; set; }
}