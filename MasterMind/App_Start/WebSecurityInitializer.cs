using WebMatrix.WebData;

namespace MasterMind.Controllers
{
    public class WebSecurityInitializer
    {
        private WebSecurityInitializer() { }
        public static readonly WebSecurityInitializer Instance = new WebSecurityInitializer();
        private bool isNotInit = true;
        private readonly object SyncRoot = new object();
        public void EnsureInitialize()
        {
            if (isNotInit)
            {
                lock (this.SyncRoot)
                {
                    if (isNotInit)
                    {
                        isNotInit = false;
                        WebSecurity.InitializeDatabaseConnection("Default", "Cadastro", "Id_User", "usuario", autoCreateTables: true);
                    }
                }
            }
        }
    }
}