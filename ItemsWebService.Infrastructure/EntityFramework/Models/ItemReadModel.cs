namespace ItemsWebService.Infrastructure.EntityFramework.Models
{
    public class ItemReadModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Comment { get; set; }

        public short ColorId { get; set; }
        public ColorReadModel Color { get; set; }
    }
}
