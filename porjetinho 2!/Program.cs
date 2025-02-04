using System;

namespace Gerenciador_de_Ficha
{
    internal class Program
    {
        enum Menu { Listagem = 1, Adicionar, Remover, Sair }

        static void Main(string[] args)
        {
            while (Player.escolheuSair == false)
            {
                Player.Carregar();
                Console.WriteLine("Seja bem vindo ao sistema de fichas de RPG!");
                Console.WriteLine("1 - Listagem\n2 - Adicionar\n3 - Remover\n4 - Sair");
                string opStr = Console.ReadLine();
                Console.Clear();
                bool opBool = int.TryParse(opStr, out int opInt);
                if (opBool == true)
                {
                    Menu opcao = (Menu)opInt;

                    switch (opcao)
                    {
                        case Menu.Listagem:
                            Player.Listagem();
                            Console.WriteLine(Player.retornar);
                            Console.ReadLine();
                            break;
                        case Menu.Adicionar:
                            Player.Adicionar();
                            break;
                        case Menu.Remover:
                            Player.Remover();
                            break;
                        case Menu.Sair:
                            Player.SairOp();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(Player.erro);
                }
                Console.Clear();
            }
        }
    }
}
