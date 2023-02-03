//using AutoMapper;

//namespace OEleitor.WebApp.MVC.Configuration
//{
//    public static class AutoMapperInjector
//    {
//        public static IServiceCollection AddAutoMapperInjector(this IServiceCollection services)
//        {
//            var mapperConfig = new MapperConfiguration(mc =>
//            {
//                mc.AddProfile(new EleitorProfile());
//                mc.AddProfile(new UserProfile());
//            });

//            var mapper = mapperConfig.CreateMapper();
//            services.AddSingleton(mapper);

//            return services;
//        }
//    }
//}
