using System.Globalization;

public class PersonalNumberValidator
{
    //Metod som tar bort eventuella bindestreck och mellanslag
    public string CleanPersonalNumber(string persNumber)
    {
        return persNumber.Replace("-", "").Replace(" ", "");
    }

    //Metod som kontrollerar så att input har 10 eller 12 siffror
    public bool IsValidFormat(string persNumber)
    {
        return persNumber.Length == 10 || persNumber.Length == 12 && long.TryParse(persNumber, out _);
    }

    //Metod som kontrollerar om input är ett giltigt datum, kontrollerar INTE de fyra sista siffrorna 
    public bool IsValidDate(string persNumber)
    {
        string datePart;

        if (persNumber.Length == 12)
        {
            // För 12-siffriga personnummer, används de första 8 siffrorna
            datePart = persNumber.Substring(0, 8);
        }
        else
        {
            // För 10-siffriga personnummer, avgör sekel baserat på årtalet
            int currentYear = DateTime.Now.Year % 100; 
            int year = int.Parse(persNumber.Substring(0, 2));
            string century = year > currentYear ? "19" : "20"; // 19xx om år > nuvarande år, annars 20xx
            datePart = century + persNumber.Substring(0, 6);
        }

        // Kontrollera om datePart är ett giltigt datum i formatet yyyyMMdd
        return DateTime.TryParseExact(datePart, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out _);
    }




    //Metod som beräknar LuhnAlgoritmen = kontrollerar så att sista siffran är korrekt
    public bool PassesLuhnAlgorithm(string persNumber)
    {
        // Om personnumret har 12 siffror, ta bort de första två (århundrade)
        if (persNumber.Length == 12)
        {
            persNumber = persNumber.Substring(2);
        }

        int sum = 0;
        bool doubleDigit = false;

        // Gå igenom varje siffra från höger till vänster
        for (int i = persNumber.Length - 1; i >= 0; i--)
        {
            int digit = int.Parse(persNumber[i].ToString());

            if (doubleDigit)
            {
                digit *= 2;
                if (digit > 9)
                {
                    digit -= 9;
                }
            }

            sum += digit;
            doubleDigit = !doubleDigit;
        }

        // Kontrollera om summan är delbar med 10
        return sum % 10 == 0;
    }


    public bool ValidatePersonalNumber(string persNumber)
    {
        string cleanedPnr = CleanPersonalNumber(persNumber);
        return IsValidFormat(cleanedPnr) &&
           IsValidDate(cleanedPnr) &&
           PassesLuhnAlgorithm(cleanedPnr);
    }

}