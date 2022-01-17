using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Marizona.WebUI.Core.Provider
{
    public class CultureProvider : RequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            //istiyende sili deyismek onda burani en ele besdi
            string lang = "az";

            var path = httpContext.Request.Path;

            var match = Regex.Match(path, @"\/(?<lang>az|en|ru)\/?.*");

            if (match.Success)
            {
                lang = match.Groups["lang"].Value;

                //bidefe dili secenden sonra novbeti defede o dil olsun:
                httpContext.Response.Cookies.Delete("lang");
                httpContext.Response.Cookies.Append("lang", lang, new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(7)
                });

                return Task.FromResult(new ProviderCultureResult(lang, lang));
            }

            if (httpContext.Request.Cookies.TryGetValue("lang", out lang))
            {
                return Task.FromResult(new ProviderCultureResult(lang, lang));
            }

            return Task.FromResult(new ProviderCultureResult(lang, lang));
        }
    }
}
