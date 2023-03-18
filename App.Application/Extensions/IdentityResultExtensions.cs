using App.Application.Services._Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Extensions
{
    internal static class IdentityResultExtensions
    {
        internal static List<Error> MapResultToServiceErrors(this IdentityResult identityResult)
        {
           return identityResult.Errors
                                .Select(e => new Error($"{e.Code} - {e.Description}"))
                                .ToList();
        }
    }
}
