namespace ItemsWebService.Application.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ColorDto Color { get; set; }
        public string Comment { get; set; }
    }
}
