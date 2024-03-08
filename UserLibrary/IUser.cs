namespace UserLibrary;

interface IUser
{
    string Name { get; set; }
    string Surname { get; set; }
    string Phone { get; set; }
    string Login { get; set; }
    string Password { get; set; }
    bool IsAdmin { get; }
}