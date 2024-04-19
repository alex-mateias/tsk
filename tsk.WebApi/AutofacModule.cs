using Autofac;
using tsk.Domain.Interfaces;
using tsk.Service;
using tsk.Domain.Models;
using tsk.DataAccess;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Service<TaskItem>>().As<IService<TaskItem>>();
        builder.RegisterType<Repository<TaskItem>>().As<IRepository<TaskItem>>();

        builder.RegisterType<UserService>().As<IUserService>();
        builder.RegisterType<UserRepository>().As<IUserRepository>();
    }
}