using System.Data.Entity;
using System.Web.Mvc;
using Application.Implementation;
using Application.Interfaces;
using Data.EF;
using Infrastructure.Interfaces;
using Login.Controllers;
using Login.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using PhukienDT.Controllers;
using Unity.Mvc3;

namespace PhukienDT
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			// e.g. container.RegisterType<ITestService, TestService>();            
			container.RegisterType(typeof(IUnitOfWork), typeof(EFUnitOfWork));
			container.RegisterType(typeof(IRepository<,>), typeof(EFRepository<,>));
			//container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
			//container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();

			container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
			container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
			container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
			container.RegisterType<AccountController>(new InjectionConstructor());

			//Service
			container.RegisterType<ILoaiSPService, LoaiSPService>();
			container.RegisterType<ISanphamService, SanphamService>();
			container.RegisterType<IUserService, UserService>();
            container.RegisterType<IHoadonService, HoadonService>();
            container.RegisterType<IGiatinService, GiatinService>();
            container.RegisterType<ICthdService, CthdService>();
            container.RegisterType<ICtGiohangService, CtGiohangService>();
			container.RegisterType<IHoadonmuatinService, HoadonmuatinService>();
			container.RegisterType<IFunctionService, FunctionService>();
			//container.RegisterType<IRatingService, RatingService>();
			//container.RegisterType<ICtRatingService, CtRatingService>();

			//Controller
			container.RegisterType<IController, HomeController>("Home");
			container.RegisterType<IController, SanphamController>("Sanpham");
            container.RegisterType<IController, HoadonController>("Hoadon");
			container.RegisterType<IController, KhachHangController>("KhachHang");
			container.RegisterType<IController, NguoibanController>("Nguoiban");
			container.RegisterType<IController, RatingController>("Rating");
			container.RegisterType<IController, WebmasterController>("Webmaster");
			//container.RegisterType<IController, RatingController>("Rating");

			//container.RegisterType<IStudentService, StudentService>();
			//container.RegisterType<IController, TestController>("Test");
			return container;
        }
    }
}