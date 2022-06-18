using System;
using System.Collections.Generic;

namespace Wallet
{
    public partial class WalletDb
    {
        public WalletDb()
        {
            Operations = new HashSet<Operation>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public double? Ballance { get; set; }

        public virtual ICollection<Operation> Operations { get; set; }
    }
}
