using ItemsWebService.Domain.Exceptions;

namespace ItemsWebService.Domain.ValueObjects
{
    public record ColorName
    {
        public string Value { get; private set; }

        private ColorName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidColorNameException("Color name cannot be empty");
            }

            if (value.Length > 30)
            {
                throw new InvalidColorNameException("Color name length cannot be greater then 30 chars");
            }

            Value = value;
        }

        public static ColorName Create(string value)
        {
            return new ColorName(value);
        }
    }
}
