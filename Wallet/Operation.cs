using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Wallet
{
    public partial class Operation
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public string? Data { get; set; }
        public string? Vid { get; set; }
        public string? Type { get; set; }
        public double? Summ { get; set; }
        [JsonIgnore]
        public virtual WalletDb? User { get; set; }
    }
}
