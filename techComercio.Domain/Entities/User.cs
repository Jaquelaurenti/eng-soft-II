// quero garantir que a classe de usuario ela nao poassa ser herdada 
public sealed class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
}