//using Autofac;
//using Task9.Clients;
//using Task9.Models.Requests;
//using Task9.Steps.UserServiceSteps;

//namespace Task9.DI
//{
//    public class TestDependencyModule : Module
//    {

//        protected override void Load(ContainerBuilder builder)
//        {
//            builder
//                .RegisterType<UserServiceClient>()
//                .AsSelf().SingleInstance();

//            builder
//                .RegisterType<WalletServiceClient>()
//                .AsSelf().SingleInstance();

//            builder
//               .RegisterType<UserAssertSteps>()
//               .AsSelf();


//            builder
//               .RegisterType<UserSteps>()
//               .AsSelf();


//            builder
//              .RegisterType<UserServiceRegisterUserRequest>()
//              .AsSelf()
//              .SingleInstance();


//            builder
//              .RegisterType<DataContext>()
//              .AsSelf()
//              .SingleInstance();


//            base.Load(builder);
//        }


//    }

//}


