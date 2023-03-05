using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services._Base
{
    public class ServiceResult<T>
    {
        private ServiceResult(List<Error> errors, T returnValue)
        {
            Errors = errors.AsReadOnly();
            ReturnValue = returnValue;
        }

        public ReadOnlyCollection<Error> Errors { get; private set; }
        public T ReturnValue { get; private set; }
        public bool IsSuccesful => !Errors.Any();


        public static ServiceResult<T> ForFailure(List<Error> errors)
        {
            if(errors == null) throw new ArgumentNullException(nameof(errors));  
            if(!errors.Any()) throw new ArgumentNullException($"{nameof(errors)} cannot be empty");
            return new ServiceResult<T>(errors, default);
        }

        public static ServiceResult<T> ForSuccess(T returnValue)
        {
            return new ServiceResult<T>(new List<Error>(), returnValue);
        }
    }
}
