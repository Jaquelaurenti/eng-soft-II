public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset? DateCreated { get; set; }
    public DateTimeOffset? DateUpdated { get; set; }
    public DateTimeOffset? DateDeleted { get; set; }
}

// classe base, que vamos criar para todas as
// demais entidades da nossa aplicação