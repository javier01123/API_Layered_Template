﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services._Base
{
    internal abstract class BaseService
    {
        protected readonly List<Error> _errors = new List<Error>();

        protected void AddError(string property, string message)
        {
            _errors.Add(new Error(property, message));
        }

        protected void AddError(string message)
        {
            _errors.Add(new Error("non_field_errors", message));
        }

        protected void ClearErrors() => _errors.Clear();

        protected bool HasErrors() => _errors.Any();
          
    }
}
