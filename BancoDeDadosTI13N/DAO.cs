using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Imports para conexão com o banco de dados
using MySql.Data.MySqlClient;//Imports para realizar comandos no banco

namespace BancoDeDadosTI13N
{
    class DAO
    {
        MySqlConnection conexao;
        public string dados;
        public string resultado;
        public int[] cod;
        public string[] nome;
        public string[] telefone;
        public string[] endereco;
        public int i;
        public string msg;
        public int contator;

        //Contrutor
        public DAO(string nomeDoBancoDeDados)
        {
            conexao = new MySqlConnection("server=localhost;DataBase=" + nomeDoBancoDeDados + ";Uid=root;Password=;");
            try
            {
                conexao.Open();//Solicitando a entrada ao banco de dados
                Console.WriteLine("Entrei!!!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
                conexao.Close();//Fechando a conexão com banco de dados
            }//fim da tentativa de conexão com o banco de dados
        }//fim do construtor

        //Criar o método INSERIR
        public void Inserir(string nome, string telefone, string endereco)
        {
            try
            {
                dados = "('','" + nome + "','" + telefone + "','" + endereco + "')";
                resultado = "Insert into Pessoa(codigo, nome, telefone, endereco) values" + dados;
                //Executar o comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + " Linha(s) Afetada(s)!");
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
                
            }//fim do catch
        }//fim do método inserir

        public void PreencherVetor()
        {
            string query = "select * from pessoa";//coletando o dado do BD

            //Instaciando os vetores

            cod      = new int[100];
            nome     = new string[100];
            telefone = new string[100];
            endereco = new string[100];

            //Dar valores inicias para ele

            for (i = 0; i < 100; i++)
            {
                cod[i]      = 0 ;
                nome[i]     = "";
                telefone[i] = "";
                endereco[i] = "";
            }// fim da repetição

            //criar o comando para coleta de dados

            MySqlCommand coletar = new MySqlCommand(query, conexao);

            //usar o comando lendo os dados do banco

            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while (leitura.Read())
            {
                cod[i]      = Convert.ToInt32(leitura["codigo"]);
                nome[i]     = leitura["nome"    ] + "";
                telefone[i] = leitura["telefone"] + "";
                endereco[i] = leitura["endereco"] + "";
                i++;
                contator++;
            }//fim do while

            //fechar o dataReater

            leitura.Close();

        }//fim do preencher vetor

        public string ConsultarTudo()
        {
            //Preencher o vetor
            PreencherVetor();
            msg = "";
            for(int i=0; i < contator; i++)
            {
                msg += "\n\nCódigo: " + cod[i] + ", Nome: " + nome[i] + ", Telefone: " + telefone[i] + ", Endereço: " + endereco[i];
            }//fim do for

            return msg;

        }//fim do consultar tudo

        public string ConsultarNome(int codigo)
        {
            PreencherVetor();
            for(int i = 0; i < contator; i++)
            {
                if (codigo == cod[i])
                {
                    return nome[i];                
                }
            }//fim do for

            return "´Código não encontrado!!!";

        }//fim do consultar nome

         public string ConsultarTelefone(int codigo)
        {
            PreencherVetor();
            for(int i = 0; i < contator; i++)
            {
                if (codigo == cod[i])
                {
                    return telefone[i];                
                }
            }//fim do for

            return "´Código não encontrado!!!";

        }//fim do consultar Telefone

         public string ConsultarEndereco(int codigo)
        {
            PreencherVetor();
            for(int i = 0; i < contator; i++)
            {
                if (codigo == cod[i])
                {
                    return endereco[i];                
                }
            }//fim do for

            return "´Código não encontrado!!!";

        }//fim do consultar Endereço

        public void Atualizar(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update pessoa set" + campo + " = '" + novoDado + "' where codigo = '" + codigo + "'";
                
                //Executar o scrip

                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dado Atualizado com SUCESSO!!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu ERRADO!" + e);
            }
        }//Fim do atualizar

        public void Deletar(int codigo)
        {
            resultado = "delete from pessoa codigo = '" + codigo + "'";

            //Executar comando

            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();

            //mensagem

            Console.WriteLine("Dados Excluídos com SUCESSO!!!");

        }//fim do deletar

    }//fim da classe
}//fim do projeto
