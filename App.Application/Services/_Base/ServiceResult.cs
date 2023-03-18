using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services._Base
{

    public class ServiceResult
    {

        protected ServiceResult(List<Error> errors)
        {
            Errors = errors.AsReadOnly();            
        } 

        public ReadOnlyCollection<Error> Errors { get; protected set; }       
        public bool IsSuccesful => !Errors.Any();


        public static ServiceResult Failure(List<Error> errors)
        {
            if(errors == null) throw new ArgumentNullException(nameof(errors));  
            if(!errors.Any()) throw new ArgumentNullException($"{nameof(errors)} cannot be empty");
            return new ServiceResult(errors);
        }

        public static ServiceResult Success()
        {
            return new ServiceResult(new List<Error>());
        }
    }
}
