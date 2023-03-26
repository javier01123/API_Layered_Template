using App.Application.Services._Base;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.ObjectModel;

namespace App.API.Extensions
{
    static class ServiceResultExtensions
    {
        public static ModelStateDictionary ErrorsToModelState(this ServiceResult serviceResult)
        {
            return Map(serviceResult.Errors);
        }

        public static ModelStateDictionary ErrorsToModelState<T>(this ServiceResult<T> serviceResult)
        {
            return Map(serviceResult.Errors);
        }

        private static ModelStateDictionary Map(ReadOnlyCollection<Error> errors)
        {
            var ms = new ModelStateDictionary();
            foreach (var error in errors)
                if (string.IsNullOrWhiteSpace(error.Property))
                    ms.AddModelError(ERROR_KEYS.NonPropertyError, error.Message);
                else
                    ms.AddModelError(error.Property, error.Message);
            return ms;
        }
    }
}


