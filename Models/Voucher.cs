namespace Tax
{
    public class Voucher
    {
        public required string Type { get; set; }
        public required string VoucherNumber { get; set; }
        public required DateTime VoucherDate { get; set; }
        public decimal TotalGrossAmount
        {
            get
            {
                return Math.Round(VoucherItems.Sum(item => item.Amount), 2);
            }
        }
        public decimal TotalTaxAmount
        {
            get
            {
                return Math.Round(VoucherItems.Sum(item => item.TaxAmount), 2);
            }
        }
        public Boolean UseCollectiveContact { get; set; } = true;
        public string? ContactId { get; set; }
        public string TaxType { get; set; } = "gross";
        public required List<VoucherItem> VoucherItems { get; set; } = new List<VoucherItem>();
        public required string Remark { get; set; }

    }
}