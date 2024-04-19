using Autofac;
using tsk.DataAccess;
using tsk.Domain.Interfaces;
using tsk.Domain.Models;
using tsk.Service;

public class AutofacModule : Module
{
    private readonly IConfiguration _configuration;

    public AutofacModule(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void Load(ContainerBuilder builder)
    {
        string connectionString = _configuration.GetConnectionString("DefaultConnection");

        builder.RegisterType<Service<TaskItem>>().As<IService<TaskItem>>();
        builder.RegisterType<Repository<TaskItem>>().As<IRepository<TaskItem>>();

        builder.RegisterType<UserService>().As<IUserService>();
        builder.RegisterType<UserRepository>().As<IUserRepository>();
    }
}