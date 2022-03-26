namespace Budget_Estimates_Management_System.Models
{
    enum DataAccess
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
}
