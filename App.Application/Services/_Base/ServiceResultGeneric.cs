﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services._Base
{
    public class ServiceResult<T>:ServiceResult
    {

        //private ServiceResult(List<Error> errors)
        //{
        //    Errors = errors.AsReadOnly();
        //    ReturnValue =default(T);
        //}

        private ServiceResult(List<Error> errors, T? returnValue):base(errors)
        {
            //Errors = errors.AsReadOnly();
            ReturnValue = returnValue;
        }

        //public ReadOnlyCollection<Error> Errors { get; private set; }
        public T? ReturnValue { get; private set; }
        //public bool IsSuccesful => !Errors.Any();


        public static ServiceResult<T?> Failure(List<Error> errors)
        {
            if(errors == null) throw new ArgumentNullException(nameof(errors));  
            if(!errors.Any()) throw new ArgumentNullException($"{nameof(errors)} cannot be empty");
            return new ServiceResult<T?>(errors, default(T?));
        }

        public static ServiceResult<T> Success(T returnValue)
        {
            return new ServiceResult<T>(new List<Error>(), returnValue);
        }
    }
}
