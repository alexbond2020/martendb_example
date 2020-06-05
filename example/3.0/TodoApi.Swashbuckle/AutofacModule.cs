using Autofac;
using Marten;
using TodoApi.DataAccess;
using TodoApi.Service;

namespace TodoApi
{
    public class AutofacModule : Module
    {
        private readonly string _connectionString;
        public AutofacModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            var documentStore = DocumentStore.For(_connectionString);
            builder.Register(r => documentStore).As<IDocumentStore>().SingleInstance();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).SingleInstance();
            builder.RegisterType<TodoService>().As<ITodoService>().SingleInstance();
        }
    }
}
