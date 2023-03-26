using App.Application.Services._Base;
using Microsoft.AspNetCore.Identity;

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
