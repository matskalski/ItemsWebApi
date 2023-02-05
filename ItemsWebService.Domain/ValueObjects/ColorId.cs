using ItemsWebService.Domain.Exceptions;

namespace ItemsWebService.Domain.ValueObjects
{
    public record ColorId
    {
        public short Value { get; private set; }

        private ColorId(short value)
        {
            if (value <= 0)
            {
                throw new InvalidColorIdValueException();
            }

            Value = value;
        }

        public static ColorId Create(short value)
        {
            return new ColorId(value);
        }
    }
}
