namespace Budget_Estimates_Management_System.Models
{
    enum UserRoleType
    {
        Admin = 0,
        BudgetStaff = 1,
        MinistryStaff = 2,
        PsipStaff =3,
    }

    enum EntryStatus
    {
        Unsubmitted = 0,
        Submitted = 1,
        Approved = 2
    }

    enum OperationType
    {
        Submit = 0,
        Reject = 1,
        Approve = 2,
        Unaprove =3,
    }
}
