namespace ItemsWebService.Infrastructure.EntityFramework.Models
{
    public class ColorReadModel
    {
        public short Id { get; set; }
        public string Name { get; set; }

        public ICollection<ItemReadModel> Items { get; set; }
    }
}
