﻿using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace RunGroopWebApp
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value; 
        }
    }
}
