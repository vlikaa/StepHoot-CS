namespace UserLibrary;

// Проверок на null(в параметрах) не будет, т.к методы используются там,
// где проверка на null происходит извне
public static class UserHelper
{
    public static bool IsCorrectName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return false;

        if (name.Length < 3)
            return false;

        // Проверка на регистр
        return !char.IsLower(name[0]) && !name.Skip(1).Any(char.IsUpper);
    }
    
    public static bool IsCorrectSurname(string surname)
    {
        if (string.IsNullOrEmpty(surname))
            return false;

        if (surname.Length < 3)
            return false;

        // Проверка на регистр
        return !char.IsLower(surname[0]) && !surname.Skip(1).Any(char.IsUpper);
    }
    
    public static bool IsCorrectPhone(string phone)
    {
        if (string.IsNullOrEmpty(phone))
            return false;

        if (phone.Length != 10 )
            return false;

        // проверка на каждый элемент строки является цифрой
        return phone.All(char.IsDigit);
    }
    
    public static bool IsCorrectLogin(string login)
    {
        if (string.IsNullOrEmpty(login))
            return false;

        if (login.Length < 6)
            return false;

        // Login может содержать только: буквы, цифры и символ '_'
        return login.All(c => char.IsDigit(c) || char.IsLetter(c) || c == '_');
    }
    
    public static bool IsCorrectPassword(User user)
    {
        if (string.IsNullOrEmpty(user.Password))
            return false;

        if (user.Password.Length < 8)
            return false;
        
        // А-ля "БеЗоПаСнОсТь", чтоб пароль не содержал данные User-а
        return !user.Password.ToLower().Contains(user.Name.ToLower()) && !user.Password.ToLower().Contains(user.Surname.ToLower()) && !user.Password.ToLower().Contains(user.Login.ToLower());
    }
    
    public static bool IsCorrectUser(User user)
    {
        // Инкапсуляция ;)
        return IsCorrectName(user.Name) && IsCorrectSurname(user.Surname) &&
               IsCorrectPhone(user.Phone) && IsCorrectLogin(user.Login) &&
               IsCorrectPassword(user);
    }
}