namespace Ordering.Domain.ValueObjects
{
    public record Address
    {
        public string FirstName { get; } = default!;
        public string LastName { get; } = default!;
        public string? EmailAddress { get; } = default!;
        public string AddressLine { get; } = default!;
        public string Country { get; } = default!;
        public string State { get; } = default!;
        public string ZipCode { get; } = default!;
        protected Address()
        {
        }

        private Address(string firstName, string lastName, string emailAddres, string addresLine, string country, string state, string xipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddres;
            AddressLine = addresLine;
            Country = country;
            State = state;
            ZipCode = xipCode;
        }

        public static Address Of(string firstName, string lastName, string emailAddres, string addresLine, string country, string state, string xipCode)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(emailAddres);
            ArgumentException.ThrowIfNullOrWhiteSpace(firstName);

            return new Address(firstName, lastName, emailAddres, addresLine, country, state, xipCode);
        }
    }
}
