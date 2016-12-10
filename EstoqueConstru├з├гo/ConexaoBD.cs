using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Estoque_Material_Construção
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    class ConexaoBD
    {
        //gian/samsung123
        string conexaoString = "server=localhost;uid=root;" + "pwd=samsung123;database=construcao;";
        private MySqlConnection conexao;
        private MySqlCommand comando = new MySqlCommand();
        private MySqlDataReader leitor;
        public string nomeBD;
        public string permissao;
        Variaveis variaveis = new Variaveis();
        
        public MySqlConnection AbrirConexao()
        {
            //conexaoString = "server=localhost;uid=root;" + "pwd=samsung123;database=construcao;";
            try
            {
                conexao = new MySqlConnection();
                conexao.ConnectionString = conexaoString;
                return conexao;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return conexao;
        }

        #region Funcionarios
        /*public void PesquisarFuncionarios(MySqlConnection Conn, string codigo)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "SELECT * FROM funcionarios WHERE cpf = @codigo";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        Variaveis escrever_Func = new Variaveis(leitor.GetString("cpf"), leitor.GetString("nome"), leitor.GetString("login"), leitor.GetString("senha"), leitor.GetString("identidade"), leitor.GetString("aniversario"), leitor.GetString("endereco"), leitor.GetString("cep"), leitor.GetString("complemento"), leitor.GetString("cidade"), leitor.GetString("uf"), leitor.GetString("telefone"), leitor.GetString("celular"), leitor.GetString("email"), leitor.GetString("permissao"));
                        MessageBox.Show(variaveis.getCelular());
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " " + ex.Message);
                }
                finally
                {
                    if (leitor != null)
                    {
                        leitor.Close();
                    }

                    if (Conn != null)
                    {
                        Conn.Close();
                    }

                }
            }
        }*/
        
        #endregion
        
        #region Login
        public Boolean Login(MySqlConnection Conn, string user, string senha)
        {
            Conn.Open();
            comando.Connection = Conn;
            if (Conn.State == ConnectionState.Open)
            {
                try
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "Select * from funcionarios where login = @login and senha = @senha;";
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@login", user);
                    comando.Parameters.AddWithValue("@senha", senha);
                    leitor = comando.ExecuteReader();
                    if(leitor.Read() == true)
                    {
                        nomeBD = leitor.GetString("nome");
                        permissao = leitor.GetString("permissao");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error " + ex.Number + " " + ex.Message);
                }
            }
            return false;
        }
        #endregion
    }
}
