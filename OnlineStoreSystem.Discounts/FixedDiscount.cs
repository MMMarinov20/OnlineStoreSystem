using System;
using OnlineStoreSystem.Discounts;

namespace OnlineStoreSystem.Discounts
{
    public class FixedDiscount : IDiscount
    {
        private decimal discountAmount;

        public FixedDiscount(decimal discountAmount)
        {
            this.discountAmount = discountAmount;
        }

        public decimal CalculateDiscount(decimal totalAmount)
        {
            return discountAmount;
        }
    }
}