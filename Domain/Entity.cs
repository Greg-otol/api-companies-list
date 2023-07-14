namespace api_companies_list.Domain;

public class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    public DateTime DataInclusao { get; set; }
}
