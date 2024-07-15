namespace FifthAssignment.Presentation.WebApp.Middelware
{
    public interface IUserVerification
    {
        bool UserRoleIsAdminVerification();
        bool IsLogIn();
    }
}
