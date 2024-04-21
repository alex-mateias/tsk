using Autofac;
using tsk.DataAccess;
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

        builder.RegisterGeneric(typeof(Repository<>)).AsImplementedInterfaces();
        builder.RegisterGeneric(typeof(Service<>)).AsImplementedInterfaces();

        builder.RegisterType<ApplicationDbContext>()
               .WithParameter("connectionString", connectionString)
               .InstancePerLifetimeScope();
    }
}