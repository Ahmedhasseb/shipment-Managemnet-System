using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applcation.Feature.Branches
{
    public sealed record class BranchDTO
    {
        public string BranchName { get; init; } = string.Empty;
        public string BranchEmail { get; init; } = string.Empty;
        public string BranchPhone { get; init; }
        public string BranchAddress { get; init; } = string.Empty;
        public int LocationID { get; init; }
            
    }
}
