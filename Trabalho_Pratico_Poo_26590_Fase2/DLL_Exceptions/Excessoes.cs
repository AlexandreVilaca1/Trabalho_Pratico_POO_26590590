using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL_Exceptions
{
    public class ValorNuloException : ApplicationException
    {
        public ValorNuloException(string mensagem) : base(mensagem) { }
    }
    public class RepteticaoDadosException : ApplicationException
    {
        public RepteticaoDadosException(string mensagem) : base(mensagem) { }
    }
    public class FicheiroException : ApplicationException
    {
        public FicheiroException(string mensagem) : base(mensagem) { }
    }

}
