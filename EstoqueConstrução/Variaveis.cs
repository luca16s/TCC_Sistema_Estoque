using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_Material_Construção
{
    class Variaveis
    {

        #region Variáveis
        //Funcionarios
        private string cpf;
        private string nome;
        private string login;
        private string senha;
        private string identidade;
        private string nascimento;
        private string endereco;
        private string cep;
        private string complemento;
        private string cidade;
        private string uf;
        private string telefone;
        private string celular;
        private string email;
        private string permissao;

        public string Cpf
        {
            get
            {
                return cpf;
            }

            set
            {
                cpf = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string Senha
        {
            get
            {
                return senha;
            }

            set
            {
                senha = value;
            }
        }

        public string Identidade
        {
            get
            {
                return identidade;
            }

            set
            {
                identidade = value;
            }
        }

        public string Nascimento
        {
            get
            {
                return nascimento;
            }

            set
            {
                nascimento = value;
            }
        }

        public string Endereco
        {
            get
            {
                return endereco;
            }

            set
            {
                endereco = value;
            }
        }

        public string Cep
        {
            get
            {
                return cep;
            }

            set
            {
                cep = value;
            }
        }

        public string Complemento
        {
            get
            {
                return complemento;
            }

            set
            {
                complemento = value;
            }
        }

        public string Cidade
        {
            get
            {
                return cidade;
            }

            set
            {
                cidade = value;
            }
        }

        public string Uf
        {
            get
            {
                return uf;
            }

            set
            {
                uf = value;
            }
        }

        public string Telefone
        {
            get
            {
                return telefone;
            }

            set
            {
                telefone = value;
            }
        }

        public string Celular
        {
            get
            {
                return celular;
            }

            set
            {
                celular = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Permissao
        {
            get
            {
                return permissao;
            }

            set
            {
                permissao = value;
            }
        }
        //Fornecedor
        private string fantasia;
        private string social;
        private string cnpj;
        private string iE;
        private string telefone_Empresa;
        private string email_Empresa;
        private string endereco_Empresa;
        private string cep_Empresa;
        private string complemento_Empresa;
        private string bairro_Empresa;
        private string cidade_Empresa;
        private string uf_Empresa;
        private string representante;
        private string telefone_Representante;
        private string email_Representante;
        private string celular_Representante;
        private string obs;

        public string Fantasia
        {
            get
            {
                return fantasia;
            }

            set
            {
                fantasia = value;
            }
        }

        public string Social
        {
            get
            {
                return social;
            }

            set
            {
                social = value;
            }
        }

        public string Cnpj
        {
            get
            {
                return cnpj;
            }

            set
            {
                cnpj = value;
            }
        }

        public string IE
        {
            get
            {
                return iE;
            }

            set
            {
                iE = value;
            }
        }

        public string Telefone_Empresa
        {
            get
            {
                return telefone_Empresa;
            }

            set
            {
                telefone_Empresa = value;
            }
        }

        public string Email_Empresa
        {
            get
            {
                return email_Empresa;
            }

            set
            {
                email_Empresa = value;
            }
        }

        public string Endereco_Empresa
        {
            get
            {
                return endereco_Empresa;
            }

            set
            {
                endereco_Empresa = value;
            }
        }

        public string Cep_Empresa
        {
            get
            {
                return cep_Empresa;
            }

            set
            {
                cep_Empresa = value;
            }
        }

        public string Complemento_Empresa
        {
            get
            {
                return complemento_Empresa;
            }

            set
            {
                complemento_Empresa = value;
            }
        }

        public string Bairro_Empresa
        {
            get
            {
                return bairro_Empresa;
            }

            set
            {
                bairro_Empresa = value;
            }
        }

        public string Cidade_Empresa
        {
            get
            {
                return cidade_Empresa;
            }

            set
            {
                cidade_Empresa = value;
            }
        }

        public string Uf_Empresa
        {
            get
            {
                return uf_Empresa;
            }

            set
            {
                uf_Empresa = value;
            }
        }

        public string Representante
        {
            get
            {
                return representante;
            }

            set
            {
                representante = value;
            }
        }

        public string Telefone_Representante
        {
            get
            {
                return telefone_Representante;
            }

            set
            {
                telefone_Representante = value;
            }
        }

        public string Email_Representante
        {
            get
            {
                return email_Representante;
            }

            set
            {
                email_Representante = value;
            }
        }

        public string Celular_Representante
        {
            get
            {
                return celular_Representante;
            }

            set
            {
                celular_Representante = value;
            }
        }

        public string Obs
        {
            get
            {
                return obs;
            }

            set
            {
                obs = value;
            }
        }
        //Fim Fornecedor

        //Produto
        private string codigo_Produto;
        private string nome_Produto;
        private string descricao_Produto;
        private string categoria_Produto;
        private string marca_Produto;
        private string foto_Produto;
        private string fornecedor_Produto;
        private string preco_Custo_Produto;
        private string frete_Produto;
        private string icms_Produto;
        private string despesas_Produto;
        private string lucro_Produto;
        private string desconto_Produto;
        private string preco_Minimo;
        private string acrescimos_Produto;
        private string preco_Final;
        private string estoque_Minimo;
        private string estoque_Recomendado;
        private string estoque_Atual;
        private string estoque_Maximo;
        private string unidade_Medida;
        private string medida;
        private string prateleira;
        private string corredor;
        private string balcao;

        public string Codigo_Produto
        {
            get
            {
                return codigo_Produto;
            }

            set
            {
                codigo_Produto = value;
            }
        }

        public string Nome_Produto
        {
            get
            {
                return nome_Produto;
            }

            set
            {
                nome_Produto = value;
            }
        }

        public string Descricao_Produto
        {
            get
            {
                return descricao_Produto;
            }

            set
            {
                descricao_Produto = value;
            }
        }

        public string Categoria_Produto
        {
            get
            {
                return categoria_Produto;
            }

            set
            {
                categoria_Produto = value;
            }
        }

        public string Marca_Produto
        {
            get
            {
                return marca_Produto;
            }

            set
            {
                marca_Produto = value;
            }
        }

        public string Foto_Produto
        {
            get
            {
                return foto_Produto;
            }

            set
            {
                foto_Produto = value;
            }
        }

        public string Fornecedor_Produto
        {
            get
            {
                return fornecedor_Produto;
            }

            set
            {
                fornecedor_Produto = value;
            }
        }

        public string Preco_Custo_Produto
        {
            get
            {
                return preco_Custo_Produto;
            }

            set
            {
                preco_Custo_Produto = value;
            }
        }

        public string Frete_Produto
        {
            get
            {
                return frete_Produto;
            }

            set
            {
                frete_Produto = value;
            }
        }

        public string Icms_Produto
        {
            get
            {
                return icms_Produto;
            }

            set
            {
                icms_Produto = value;
            }
        }

        public string Despesas_Produto
        {
            get
            {
                return despesas_Produto;
            }

            set
            {
                despesas_Produto = value;
            }
        }

        public string Lucro_Produto
        {
            get
            {
                return lucro_Produto;
            }

            set
            {
                lucro_Produto = value;
            }
        }

        public string Desconto_Produto
        {
            get
            {
                return desconto_Produto;
            }

            set
            {
                desconto_Produto = value;
            }
        }

        public string Preco_Minimo
        {
            get
            {
                return preco_Minimo;
            }

            set
            {
                preco_Minimo = value;
            }
        }

        public string Acrescimos_Produto
        {
            get
            {
                return acrescimos_Produto;
            }

            set
            {
                acrescimos_Produto = value;
            }
        }

        public string Preco_Final
        {
            get
            {
                return preco_Final;
            }

            set
            {
                preco_Final = value;
            }
        }

        public string Estoque_Minimo
        {
            get
            {
                return estoque_Minimo;
            }

            set
            {
                estoque_Minimo = value;
            }
        }

        public string Estoque_Recomendado
        {
            get
            {
                return estoque_Recomendado;
            }

            set
            {
                estoque_Recomendado = value;
            }
        }

        public string Estoque_Atual
        {
            get
            {
                return estoque_Atual;
            }

            set
            {
                estoque_Atual = value;
            }
        }

        public string Estoque_Maximo
        {
            get
            {
                return estoque_Maximo;
            }

            set
            {
                estoque_Maximo = value;
            }
        }

        public string Unidade_Medida
        {
            get
            {
                return unidade_Medida;
            }

            set
            {
                unidade_Medida = value;
            }
        }

        public string Medida
        {
            get
            {
                return medida;
            }

            set
            {
                medida = value;
            }
        }

        public string Prateleira
        {
            get
            {
                return prateleira;
            }

            set
            {
                prateleira = value;
            }
        }

        public string Corredor
        {
            get
            {
                return corredor;
            }

            set
            {
                corredor = value;
            }
        }

        public string Balcao
        {
            get
            {
                return balcao;
            }

            set
            {
                balcao = value;
            }
        }

        //Fim Produtos

        //Venda
        private string Codigo_Venda, Data_Venda, Cliente_Venda, CPF_Venda, Vendedor_Venda, Tipo_Venda, Valor_Parcela, Numero_Parcela, Valor_Itens, Desconto, Valor_Total, Valor_Pago, Troco;
        private string dados_produtos;

        public string Codigo_Venda1
        {
            get
            {
                return Codigo_Venda;
            }

            set
            {
                Codigo_Venda = value;
            }
        }

        public string Data_Venda1
        {
            get
            {
                return Data_Venda;
            }

            set
            {
                Data_Venda = value;
            }
        }

        public string Cliente_Venda1
        {
            get
            {
                return Cliente_Venda;
            }

            set
            {
                Cliente_Venda = value;
            }
        }

        public string CPF_Venda1
        {
            get
            {
                return CPF_Venda;
            }

            set
            {
                CPF_Venda = value;
            }
        }

        public string Vendedor_Venda1
        {
            get
            {
                return Vendedor_Venda;
            }

            set
            {
                Vendedor_Venda = value;
            }
        }

        public string Tipo_Venda1
        {
            get
            {
                return Tipo_Venda;
            }

            set
            {
                Tipo_Venda = value;
            }
        }

        public string Valor_Parcela1
        {
            get
            {
                return Valor_Parcela;
            }

            set
            {
                Valor_Parcela = value;
            }
        }

        public string Numero_Parcela1
        {
            get
            {
                return Numero_Parcela;
            }

            set
            {
                Numero_Parcela = value;
            }
        }

        public string Valor_Itens1
        {
            get
            {
                return Valor_Itens;
            }

            set
            {
                Valor_Itens = value;
            }
        }

        public string Desconto1
        {
            get
            {
                return Desconto;
            }

            set
            {
                Desconto = value;
            }
        }

        public string Valor_Total1
        {
            get
            {
                return Valor_Total;
            }

            set
            {
                Valor_Total = value;
            }
        }

        public string Valor_Pago1
        {
            get
            {
                return Valor_Pago;
            }

            set
            {
                Valor_Pago = value;
            }
        }

        public string Troco1
        {
            get
            {
                return Troco;
            }

            set
            {
                Troco = value;
            }
        }

        public string Dados_produtos
        {
            get
            {
                return dados_produtos;
            }

            set
            {
                dados_produtos = value;
            }
        }
        //Fim Vendas

        //Devolucoes
        private string Codigo_Devolucoes, Data_Devolucoes, Codigo_Produto_Devolucoes, Produto_Devolucoes, Quantidade_Devolucoes, Valor_Devolucoes, Marca_Devolucoes;

        public string Codigo_Devolucoes1
        {
            get
            {
                return Codigo_Devolucoes;
            }

            set
            {
                Codigo_Devolucoes = value;
            }
        }

        public string Data_Devolucoes1
        {
            get
            {
                return Data_Devolucoes;
            }

            set
            {
                Data_Devolucoes = value;
            }
        }

        public string Codigo_Produto_Devolucoes1
        {
            get
            {
                return Codigo_Produto_Devolucoes;
            }

            set
            {
                Codigo_Produto_Devolucoes = value;
            }
        }

        public string Produto_Devolucoes1
        {
            get
            {
                return Produto_Devolucoes;
            }

            set
            {
                Produto_Devolucoes = value;
            }
        }

        public string Quantidade_Devolucoes1
        {
            get
            {
                return Quantidade_Devolucoes;
            }

            set
            {
                Quantidade_Devolucoes = value;
            }
        }

        public string Valor_Devolucoes1
        {
            get
            {
                return Valor_Devolucoes;
            }

            set
            {
                Valor_Devolucoes = value;
            }
        }

        public string Marca_Devolucoes1
        {
            get
            {
                return Marca_Devolucoes;
            }

            set
            {
                Marca_Devolucoes = value;
            }
        }
        //Fim devoluções

        //Trocas
        private string Codigo_Troca, Codigo_Venda_Troca, Data_Troca, Codigo_Produto_Troca, Produto_Troca, Quantidade_Troca, Valor_Troca, Marca_Troca;

        public string Codigo_Troca1
        {
            get
            {
                return Codigo_Troca;
            }

            set
            {
                Codigo_Troca = value;
            }
        }

        public string Codigo_Venda_Troca1
        {
            get
            {
                return Codigo_Venda_Troca;
            }

            set
            {
                Codigo_Venda_Troca = value;
            }
        }

        public string Data_Troca1
        {
            get
            {
                return Data_Troca;
            }

            set
            {
                Data_Troca = value;
            }
        }

        public string Codigo_Produto_Troca1
        {
            get
            {
                return Codigo_Produto_Troca;
            }

            set
            {
                Codigo_Produto_Troca = value;
            }
        }

        public string Produto_Troca1
        {
            get
            {
                return Produto_Troca;
            }

            set
            {
                Produto_Troca = value;
            }
        }

        public string Quantidade_Troca1
        {
            get
            {
                return Quantidade_Troca;
            }

            set
            {
                Quantidade_Troca = value;
            }
        }

        public string Valor_Troca1
        {
            get
            {
                return Valor_Troca;
            }

            set
            {
                Valor_Troca = value;
            }
        }

        public string Marca_Troca1
        {
            get
            {
                return Marca_Troca;
            }

            set
            {
                Marca_Troca = value;
            }
        }

        //Fim trocas
        #endregion

        public Variaveis()
        {

        }
        
        #region Funcionarios

        public Variaveis(string cpf, string nome, string login, string senha, string identidade, string nascimento, string endereco, string cep, string complemento, string cidade, string uf, string telefone, string celular, string email, string permissao)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.login = login;
            this.senha = senha;
            this.identidade = identidade;
            this.nascimento = nascimento;
            this.endereco = endereco;
            this.cep = cep;
            this.complemento = complemento;
            this.cidade = cidade;
            this.uf = uf;
            this.telefone = telefone;
            this.celular = celular;
            this.email = email;
            this.permissao = permissao;

            //FRMFuncionario funcionario = new FRMFuncionario(this.cpf, this.nome, this.login, this.senha, this.identidade, this.nascimento, this.endereco, this.cep, this.complemento, this.cidade, this.uf, this.telefone, this.celular, this.email, this.permissao);
        }

        public void VarFuncionario(string cpf, string nome, string login, string senha, string identidade, string nascimento, string endereco, string cep, string complemento, string cidade, string uf, string telefone, string celular, string email, string permissao)
        {
            this.cpf = cpf.Replace(".", "").Replace("-", "");
            this.nome = nome;
            this.login = login;
            this.senha = senha;
            this.identidade = identidade;
            this.nascimento = nascimento.Replace("/", "");
            this.endereco = endereco;
            this.cep = cep.Replace("-", "");
            this.complemento = complemento;
            this.cidade = cidade;
            this.uf = uf;
            this.telefone = telefone.Replace("(", "").Replace(")", "").Replace("-", "");
            this.celular = celular.Replace("(", "").Replace(")", "").Replace("-", "");
            this.email = email;
            this.permissao = permissao;
        }

        

        

        #endregion
        #region Fornecedores
        public void VarFornecedor(string cnpj, string nome_fantasia, string razao_social, string ie, string telefone, string email, string endereco, string cep, string complemento, string bairro, string cidade, string uf, string representante, string telefone_representante, string email_representante, string celular_representante, string observacoes)
        {
            this.celular_Representante = celular_representante.Replace("(", "").Replace(")", "").Replace("-", "");
            this.email_Empresa = email;
            this.cnpj = cnpj.Replace("-", "").Replace("/", "").Replace(".", "");
            this.fantasia = nome_fantasia;
            this.social = razao_social;
            this.IE = ie;
            this.telefone_Empresa = telefone.Replace("(", "").Replace(")", "").Replace("-", "");
            this.email_Representante = email_representante;
            this.endereco_Empresa = endereco;
            this.cep_Empresa = cep;
            this.complemento_Empresa = complemento;
            this.bairro_Empresa = bairro;
            this.cidade_Empresa = cidade;
            this.uf_Empresa = uf;
            this.representante = representante;
            this.telefone_Representante = telefone_representante.Replace("(", "").Replace(")", "").Replace("-", "");
            this.obs = observacoes;
        }
        #endregion


        #region Login
        public void VarLogin(string login, string senha)
        {
            this.login = login;
            this.senha = senha;
        }
        #endregion

        
    }
}
