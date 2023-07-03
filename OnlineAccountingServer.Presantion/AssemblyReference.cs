
using System.Data;
using System.Reflection;

namespace OnlineAccountingServer.Presantation
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly =typeof(Assembly).Assembly;
        //.Assembly özelliğiyle bu türün ait olduğu derlemenin temsilini elde eder. 
    }
}
