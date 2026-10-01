namespace Applcation.Feature.ManagerBranch.DTO
{
    public sealed record class RegisterManagerBranchDTO
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public int BranchId { get; init; }


    }
}
