namespace CSharpJourney.core.Services
{
    public static class PasswordValidatorService
    {
        public static void ValidarComprimento(string password)
        {
            int senhaTamanho = password.Length;
            if (senhaTamanho < 8)
            {

                throw new ArgumentException("Sua senha é muito curta (mínimo 8 caracteres).");
            }
            if (senhaTamanho > 16)
            {
                throw new ArgumentException("Sua senha excede o número máximo de caracteres (máximo 16 caracteres).");
            }
        }
        public static void ValidarMaiusculoMinusculo(string password)
        {
            if (!password.Any(char.IsUpper))
            {
                throw new ArgumentException("Não contem letra maiscula");
            }
            if (!password.Any(char.IsLower))
            {
                throw new ArgumentException("Não contem letra minuscula");
            }
        }
        public static void ValidarCaractereNumerico(string password)
        {
            if (!password.Any(char.IsDigit))
            {
                throw new ArgumentException("Não contem nenhum número");
            }
        }
        public static void ValidarCaractereEspecial(string password)
        {
            if (!password.Any(c => !char.IsLetterOrDigit(c)))
            {
                throw new ArgumentException("Não contem nenhum caracter especial");
            }
        }
    }
}
