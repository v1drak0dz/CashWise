using CashWise.Domain.Enums;

namespace CashWise.Domain.Entities
{
    public sealed class Investments
    {
        public int Id { get; }
        public decimal InvestedValue { get; }
        public DateTime StartDate { get; }
        public InvestimentType InvestimentType { get; }
        public RentabilityTax RentabilityTax { get; }
        public float AdministrationTax { get; }
        public float CorretagemTax { get; }
        public float RevenueTax { get; } // Imposto de Renda
        public float IoF { get; }

        public Investments(int id, decimal investedValue, DateTime startDate, InvestimentType investimentType, RentabilityTax rentabilityTax, float administrationTax, float corretagemTax, float revenueTax, float ioF)
        {
            Id = id;
            InvestedValue = investedValue;
            StartDate = startDate;
            InvestimentType = investimentType;
            RentabilityTax = rentabilityTax;
            AdministrationTax = administrationTax;
            CorretagemTax = corretagemTax;
            RevenueTax = revenueTax;
            IoF = ioF;
        }
    }
}
