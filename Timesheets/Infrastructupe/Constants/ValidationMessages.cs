namespace Timesheets.Infrastructure.Constants
{
    public static class ValidationMessages
    {
        public const string SheetAmount = "Amount should be between 0 and 8 hours.";
        public const string InvalidValue = "Incorrect value";
        public const string InvoiceRequestDateError = "Start date should be less then or equal to the end date";
        public const string InvalidPassword = "Password must contain one of the characters: @, #, $";
        public const string InvalidPasswordLength = "Password length must be at least 8";
    }
}