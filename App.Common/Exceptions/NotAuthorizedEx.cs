namespace App.Common.Exceptions
{
    public class NotAuthorizedEx : Exception
    {
        public NotAuthorizedEx(string message) : base(message) { }
    }
}
