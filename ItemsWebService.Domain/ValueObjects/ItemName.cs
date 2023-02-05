using ItemsWebService.Domain.Exceptions;

namespace ItemsWebService.Domain.ValueObjects
{
    public record ItemName
    {
        public string Value { get; private set; }

        private ItemName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidItemNameException("Color name cannot be empty");
            }

            if (value.Length > 30)
            {
                throw new InvalidItemNameException("Color name length cannot be greater then 30 chars");
            }

            Value = value;
        }

        public static ItemName Create(string value)
        {
            return new ItemName(value);
        }
    }
}
