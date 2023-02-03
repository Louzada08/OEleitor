using Microsoft.AspNetCore.Mvc;

namespace OEleitor.WebApp.MVC.Configuration
{
    public static class WebAppConfig
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddControllersWithViews(o =>
            {
                o.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => "O valor preenchido é inválido para este campo.");
                o.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => "Este campo precisa ser preenchido.");
                o.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => "Este campo precisa ser preenchido.");
                o.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => "É necessário que o body na requisição não esteja vazio.");
                o.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor(x => "O valor preenchido é inválido para este campo.");
                o.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => "O valor preenchido é inválido para este campo.");
                o.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => "O campo deve ser numérico");
                o.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(x => "O valor preenchido é inválido para este campo.");
                o.ModelBindingMessageProvider.SetValueIsInvalidAccessor(x => "O valor preenchido é inválido para este campo.");
                o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => "O campo deve ser numérico.");
                o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "Este campo precisa ser preenchido.");

                o.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            services.AddRazorPages();

            return services;
        }

        //public static void UseMvcConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //  //if (env.IsDevelopment())
        //  //{
        //  //  app.UseDeveloperExceptionPage();
        //  //}
        //  //else
        //  //{
        //  //}

        //  app.UseExceptionHandler("/erro/500");
        //  app.UseStatusCodePagesWithRedirects("/erro/{0}");
        //  app.UseHsts();

        //  app.UseHttpsRedirection();
        //  app.UseStaticFiles();

        //  app.UseRouting();

        //  app.UseIdentityConfiguration();

        //  var supportedCultures = new[] { new CultureInfo("pt-BR") };
        //  app.UseRequestLocalization(new RequestLocalizationOptions
        //  {
        //    DefaultRequestCulture = new RequestCulture("pt-BR"),
        //    SupportedCultures = supportedCultures,
        //    SupportedUICultures = supportedCultures
        //  });

        //  app.UseMiddleware<ExceptionMiddleware>();

        //        app.MapControllerRoute(
        //                    name: "default",
        //              pattern: "{controller=Patrimonio}/{action=Index}/{id?}");
        //}
    }
}