using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque_Material_Construção
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FRMLogin());
            //Application.Run(new FRMPrincipal("gian", "mestre"));
            //Application.Run(new FRMConfig());
            //Application.Run(new FRMFuncionario());
            //Application.Run(new FRMFornecedores());
            //Application.Run(new FRMProduto());
            //Application.Run(new FRMOrcamento("nome_venda"));
            //Application.Run(new FRMVendas("Gian Luca"));
            //Application.Run(new FRMRelatorio());
        }
    }
}
