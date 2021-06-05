using HattrickPSK.DataAcces;
using HattrickPSK.Messages;
using HattrickPSK.Models;
using HattrickPSK.Services;
using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using HattrickPSK.Messages.MessageInterfaces;

namespace HattrickPSK
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {   
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            #region Database
            container.RegisterType<DbContext, DatabaseContext>();
            container.RegisterType<IDataAccess, DAL>();
            //(TypeLifetime.Singleton) ako se stavi za DAL baca error kod walleta za cirkularnu listu
            #endregion

            #region Services
            container.RegisterType<IRegistrationService,RegistrationService>();
            container.RegisterType<IAddBalanceService, AddBalanceService>();
            container.RegisterType<IChangePasswordService, ChangePasswordService>();
            container.RegisterType<IForgotenPasswordBodyMessage, ForgottenPasswordMailMessageBody>();
            #endregion

            #region Responose
            container.RegisterType<IBalanceErrorMessagess, BalanceErrorMessages>();
            container.RegisterType<ITransactionErrorMessagess, TransactionErrorMessagess>();
            container.RegisterType<IChangePasswordErrorMessages,ChangePasswordErrorMessages>();
            container.RegisterType<ILoginErrorMessagess, LoginErrorMessages>();          
            #endregion
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}