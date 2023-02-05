using ItemsWebService.Domain.ValueObjects;

namespace ItemsWebService.Domain.Entities
{
    public class Item
    {
        public ItemId Id { get; private set; }
        private ItemName _name;
        private ItemCode _code;
        private short _colorId;
        private Color _color;
        private string _comment;

        private Item(ItemId id, ItemName name, ItemCode code, Color color, string comment)
        {
            Id = id;
            _name = name;
            _code = code;
            _color = color;
            _comment = comment;
        }

        public static Item Create(int id, string name, string code, Color color, string comment)
        {
            return new Item(ItemId.Create(id), ItemName.Create(name), ItemCode.Create(code), Color.Create(color), comment);
        }

        public Item Update(string name, string code, Color color, string comment)
        {
            _name = ItemName.Create(name);
            _code = ItemCode.Create(code);
            _color = Color.Create(color);
            _comment = comment;

            return this;
        }

        private Item()
        {

        }
    }
}
