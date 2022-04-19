using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDadosTI13N
{
    class Menu
    {
        DAO dao;
        public int opcao;
        public Menu()
        {
            opcao = 0;
            dao = new DAO ("BancoDeDadosTI13N");

        }//fim do construtor

        public void MostrarOpcoes()
        {
            Console.WriteLine("Escolha uma das opções abaixo: \n\n" +
                "\n1. Cadastrar"            +
                "\n2. Consultar tudo"       +
                "\n3. Consultar Individual" +
                "\n4. Atualizar"            +
                "\n5. Excluir"              +
                "\n6. Sair");

            opcao = Convert.ToInt32(Console.ReadLine());
        
        }//fim do método

        public void Executar()
        {
            do
            {
           
                MostrarOpcoes();//Mostrar o menu para o usuario

                switch (opcao)
                {
                    case 1:
                    
                        //Colentando os dados
                        Console.WriteLine("Informe seu nome: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("\nInforme seu telefone: ");
                        string telefone = Console.ReadLine();
                        Console.WriteLine("\nInforme seu endereço: ");
                        string endereco = Console.ReadLine();
                        //Executar o método inserir
                        dao.Inserir(nome, telefone, endereco);
                        break;

                    case 2:
                        //Consultar os dados 
                        Console.WriteLine(dao.ConsultarTudo());
                        break;

                    case 3:
                        //Consultar Individual
                        Console.WriteLine("Informe o código que deseja consultar");
                        int codigo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Nome: " + dao.ConsultarNome(codigo) + "\nTelefone: " + dao.ConsultarTelefone(codigo) + "\nEndereço: " + dao.ConsultarEndereco(codigo));
                        break;

                    case 4:
                        //Atualizar Individual
                        Console.WriteLine("Qual campo deseja atualizar?");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual novo dado?");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual código da pessoa que deseja atualizar?");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        dao.Atualizar(campo, novoDado, codigo);
                        break;

                     case 5:
                        //Deletar
                        Console.WriteLine("Informe o código que deseja deletar");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        
                        //Usar o método DAO
                        dao.Deletar(codigo);
                        break;

                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;

                    default:
                        Console.WriteLine("Código digitado não é valido!");
                        break;


                }//fim do switch case
           
            }while (opcao != 0);
        
           }//fim do método

    }//fim da classe
}//fim do projeto
