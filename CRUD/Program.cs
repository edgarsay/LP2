using System;
using System.IO;
using System.Collections;

namespace CRUD
{
    class Program
    {
        static String pth = "data.txt";
        static ArrayList cadastros = new ArrayList(); 

        //buscar,e retorna, um cadastro de pessoa atravez do CPF
        //caso não encontre retorna uma string vazia
        static String read(String CPF)
        {
            String line;
            String[] CNIR = new String[4];
            for(int i = 0;i < cadastros.Count;i++)
            {
                line = cadastros[i].ToString();
                CNIR = line.Split();
                if(CNIR[0] == CPF) return line; 
            }
            return "";
        }
        //adiciona um novo cadastro de pessoas ao vetor cadastros
        static bool create(String CPF, String nome, String idade,  String RG)
        {
            try
            {
                cadastros.Add(CPF+" "+nome+" "+idade+" "+RG);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        // copia os cadastros do arquivo para o vetor
        static void arquivoToVector()
        {
            try
            {
                StreamReader rd =  File.OpenText(pth);
                String line = String.Empty;
                while(rd.EndOfStream)
                {
                    line = rd.ReadLine();
                    cadastros.Add(line);
                }
                rd.Close();
            }
            catch(Exception e)
            {
                StreamWriter wt = File.CreateText(pth);
                wt.Close();
            }
        }

        //copia os cadastros dos vetor para o arquivo
        static void vectorToArquivo()
        {
            StreamWriter wt =  File.CreateText(pth);
            for(int i = 0;i < cadastros.Count;i++){
                wt.WriteLine(cadastros[i]);
            }
            wt.Close();

        }

        static void Main(string[] args)
        {
            arquivoToVector();
            String opcao = String.Empty;
            while(true)
            {                    
                Console.WriteLine("########################");
                Console.WriteLine("Digite:");
                Console.WriteLine("c - Criar Novo Cadastro");
                Console.WriteLine("r - Buscar Cadastro");
                Console.WriteLine("u - modificar Cadastro");
                Console.WriteLine("d - Deletar Cadastro");
                Console.WriteLine("s - Fecha o programa");
                Console.WriteLine("#########################");

                opcao = Console.ReadLine();

                if( opcao.Equals("c") || opcao.Equals("C"))
                {
                    String CPF, nome, idade, RG;
                    Console.Write("CPF:");
                    CPF = Console.ReadLine();
                    while(read(CPF) != "")
                    {
                        Console.WriteLine("CPF ja cadastrado, tente outra vez.");
                        Console.Write("CPF:");
                        CPF = Console.ReadLine();
                    }
                    Console.Write("Nome:");
                    nome = Console.ReadLine();
                    Console.Write("Idade:");
                    idade = Console.ReadLine();
                    Console.Write("RG:");
                    RG = Console.ReadLine();

                    create(CPF, nome, idade, RG);
                }
                else if(opcao.Equals("r") || opcao.Equals("R"))//feito
                {
                    String CPF =  String.Empty;
                    Console.WriteLine("CPF:");
                    CPF = Console.ReadLine();
                    String line = read(CPF);
                    if(line != "")
                    {
                        String[] CNIR = line.Split();
                        Console.WriteLine("CPF: "+CNIR[0]);
                        Console.WriteLine("Nome: "+CNIR[1]);
                        Console.WriteLine("Idade: "+CNIR[2]);
                        Console.WriteLine("RG: "+CNIR[3]);
                    }
                    else
                    {
                        Console.Write("Cadastro não encontrado");
                    }
                }
                else if(opcao.Equals("u") || opcao.Equals("U"))
                {
                    //modificar();

                }
                else if(opcao.Equals("d") || opcao.Equals("D"))
                {
                    //delete();
                }
                else if(opcao.Equals("s") || opcao.Equals("D"))
                {
                    vectorToArquivo();
                    Console.WriteLine("Saindo...");
                    return;
                }
                else
                {
                    Console.WriteLine("Opção Invalida!");
                }


            }

        }
    }
}
