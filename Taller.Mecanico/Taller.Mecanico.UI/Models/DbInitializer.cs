using Taller.Mecanico.Models.Context;

namespace Taller.Mecanico.UI.Models
{
    public static class DbInitializer
    {
        public static void Initialize(TallerContext context) { 
            context.Database.EnsureCreated();
        }
    }
}
