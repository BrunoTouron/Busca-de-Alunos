using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Busca_de_Alunos2.Startup))]
namespace Busca_de_Alunos2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
