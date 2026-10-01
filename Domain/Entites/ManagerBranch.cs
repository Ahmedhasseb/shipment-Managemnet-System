using Domain.Entites.BaseClass;

namespace Domain.Entites
{
    public class ManagerBranch : BaseEntity
    {


        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int ManagerBranchId { get; set; }
        public Branch branch { get; set; }
    }
}
