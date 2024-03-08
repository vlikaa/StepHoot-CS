namespace UserLibrary;

// Проверок на null(в параметрах) не будет, т.к методы используются там,
// где проверка на null происходит извне
public static class UserHelper
{
    public static bool IsCorrectName(User user)
    {
        if (string.IsNullOrEmpty(user.Name))
            return false;

        if (user.Name.Length < 3)
            return false;

        // Проверка на регистр
        return !char.IsLower(user.Name[0]) && !user.Name.Skip(1).Any(char.IsUpper);
    }
    
    public static bool IsCorrectSurname(User user)
    {
        if (string.IsNullOrEmpty(user.Surname))
            return false;

        if (user.Surname.Length < 3)
            return false;

        // Проверка на регистр
        return !char.IsLower(user.Surname[0]) && !user.Surname.Skip(1).Any(char.IsUpper);
    }
    
    public static bool IsCorrectPhone(User user)
    {
        if (string.IsNullOrEmpty(user.Phone))
            return false;

        if (user.Phone.Length != 10 )
            return false;

        // проверка на каждый элемент строки является цифрой
        return user.Phone.All(char.IsDigit);
    }
    
    public static bool IsCorrectLogin(User user)
    {
        if (string.IsNullOrEmpty(user.Login))
            return false;

        if (user.Login.Length < 6)
            return false;

        // Login может содержать только: буквы, цифры и символ '_'
        return user.Login.All(c => char.IsDigit(c) || char.IsLetter(c) || c == '_');
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
        return IsCorrectName(user) && IsCorrectSurname(user) &&
               IsCorrectPhone(user) && IsCorrectLogin(user) &&
               IsCorrectPassword(user);
    }
}