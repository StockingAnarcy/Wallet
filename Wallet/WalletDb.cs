using System;
using System.Collections.Generic;

namespace Wallet
{
    public partial class WalletDb
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public double? Ballance { get; set; }
    }
}
