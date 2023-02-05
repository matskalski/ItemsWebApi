using ItemsWebService.Domain.Exceptions;

namespace ItemsWebService.Domain.ValueObjects
{
    public record ItemId
    {
        public int Value { get; private set; }

        private ItemId(int value)
        {
            if (value <= 0)
            {
                throw new InvalidItemIdException();
            }

            Value = value;
        }

        public static ItemId Create(int value)
        {
            return new ItemId(value);
        }
    }
}
