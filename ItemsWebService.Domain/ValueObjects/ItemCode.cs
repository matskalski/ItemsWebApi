using ItemsWebService.Domain.Exceptions;

namespace ItemsWebService.Domain.ValueObjects
{
    public record ItemCode
    {
        public string Value { get; private set; }

        private ItemCode(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidItemCodeException("Item code value cannot be empty");
            }

            if (value.Length > 12)
            {
                throw new InvalidItemCodeException("Item code value length cannot be greater than 12");
            }

            Value = value;
        }

        public static ItemCode Create(string value)
        {
            return new ItemCode(value);
        }
    }
}
