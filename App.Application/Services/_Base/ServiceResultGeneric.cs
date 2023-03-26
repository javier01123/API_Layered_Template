using System.Collections.ObjectModel;

namespace App.Application.Services._Base
{
    public class ServiceResult<T>
    {

        private ServiceResult(List<Error> errors)
        {
            Errors = errors.AsReadOnly();
            ReturnValue = default;
        }

        private ServiceResult(List<Error> errors, T returnValue)
        {
            Errors = errors.AsReadOnly();
            ReturnValue = returnValue;
        }

        public ReadOnlyCollection<Error> Errors { get; private set; }
        public T? ReturnValue { get; private set; }
        public bool IsSuccesful => !Errors.Any();


        public static ServiceResult<T> Failure(List<Error> errors)
        {
            if (errors == null) throw new ArgumentNullException(nameof(errors));
            if (!errors.Any()) throw new ArgumentNullException($"{nameof(errors)} cannot be empty");
            return new ServiceResult<T>(errors, default);
        }

        public static ServiceResult<T> Success<T>(T returnValue) where T : struct
        {
            return new ServiceResult<T>(new List<Error>(), returnValue);
        }
    }
}
