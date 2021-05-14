namespace Libraries.Abstraction.Validations
{
    public static class CPFValidation
    {
        public static bool Validate(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return false;

            if (cpf.Length is not 11)
                return false;

            var isEqual = true;

            for (var i = 1; i < 11 && isEqual; i++)
                if (cpf[i] != cpf[0])
                    isEqual = false;

            if (isEqual || cpf == "12345678909")
                return false;

            var numbers = new int[11];

            for (var i = 0; i < 11; i++)
                numbers[i] = int.Parse(cpf[i].ToString());

            var sum = 0;

            for (var i = 0; i < 9; i++)
                sum += (10 - i) * numbers[i];

            var result = sum % 11;

            if (result == 1 || result == 0)
            {
                if (numbers[9] is not 0)
                    return false;
            }
            else if (numbers[9] != 11 - result)
                return false;

            sum = 0;

            for (var i = 0; i < 10; i++)
                sum += (11 - i) * numbers[i];

            result = sum % 11;

            if (result == 1 || result == 0)
            {
                if (numbers[10] is not 0)
                    return false;
            }
            else if (numbers[10] != 11 - result)
                return false;

            return true;
        }
    }
}