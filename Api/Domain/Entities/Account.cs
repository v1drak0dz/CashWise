using Api.Domain.Interfaces;

namespace Api.Domain.Entities
{
    public sealed class Accounts : IAccounts
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Accounts(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Account name is required!", nameof(name));
            }

            Id = Guid.NewGuid();
            Name = name.Trim();
        }

    }
}
