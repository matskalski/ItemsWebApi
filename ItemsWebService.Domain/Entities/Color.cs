using ItemsWebService.Domain.ValueObjects;

namespace ItemsWebService.Domain.Entities
{
    public class Color
    {
        public ColorId Id { get; private set; }
        private ColorName _name;

        private Color(Color color)
        {
            Id = color.Id;
            _name = color._name;
        }

        private Color(ColorId id, ColorName name)
        {
            Id = id;
            _name = name;
        }

        private Color()
        {

        }

        public static Color Create(Color color)
        {
            return new Color(color);
        }

        public static Color Create(ColorId id, ColorName name)
        {
            return new Color(id, name);
        }


    }
}
