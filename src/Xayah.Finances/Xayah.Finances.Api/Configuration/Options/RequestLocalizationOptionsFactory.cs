﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Xayah.Finances.Api.Configuration.Options
{
    public static class RequestLocalizationOptionsFactory
    {
        public static Action<RequestLocalizationOptions> Create()
        {
            return options =>
            {
                options.DefaultRequestCulture = new RequestCulture("pt-BR");
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo("pt-BR") };
            };
        }
    }
}
