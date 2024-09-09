namespace Project.Domain.Interfaces;
public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid().ToString();
        CreatedDate = DateTime.Now;
        IsDeleted = false;
    }
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
}
