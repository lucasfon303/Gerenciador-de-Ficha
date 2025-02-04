using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gerenciador_de_Ficha
{
    [System.Serializable]
    internal class Player
    {
        enum Sair { Sim = 1, Não }

        public string nome;
        public string classe;
        public string raça;
        public string sexo;
        public string idade;
        static public List<Player> players = new List<Player>();
        public static bool escolheuSair = false;
        public static string erro = "Opção inválida. Pressione ENTER para retornar ao menu inicial.";
        public static string retornar = "Pressione ENTER para retornar ao menu inicial.";
        public static string noPlayer = "Nenhum jogador registrado.";

        static public void Adicionar()
        {
            Console.Clear();
            Console.WriteLine("CADASTRO DE FICHA-");
            Player playerInfo = new Player();
            Console.WriteLine("Informe o nome do personagem:");
            playerInfo.nome = Console.ReadLine();
            Console.WriteLine("Informe a classe do personagem:");
            playerInfo.classe = Console.ReadLine();
            Console.WriteLine("Informe a raça do personagem:");
            playerInfo.raça = Console.ReadLine();
            Console.WriteLine("Informe o sexo do personagem:");
            playerInfo.sexo = Console.ReadLine();
            Console.WriteLine("Informe a idade do personagem:");
            playerInfo.idade = Console.ReadLine();

            players.Add(playerInfo);
            Salvar();

            Console.WriteLine($"Cadastro concluído.\n{retornar}");
            Console.ReadLine();
        }
        static public void Listagem()
        {
            Console.Clear();
            Console.WriteLine("-LISTA DE JOGADORES-");
            Console.WriteLine("============================");
            if (players.Count > 0)
            {
                int ID = 0;
                foreach (Player player in players)
                {
                    Console.WriteLine($"ID: {ID}");
                    Console.WriteLine($"Nome: {player.nome}");
                    Console.WriteLine($"Classe: {player.classe}");
                    Console.WriteLine($"Raça: {player.raça}");
                    Console.WriteLine($"Sexo: {player.sexo}");
                    Console.WriteLine($"Idade: {player.idade}");
                    Console.WriteLine("============================");
                    ID++;
                }
            }
            else
            {
                Console.WriteLine(noPlayer);
            }
        }
        static public void Salvar()
        {
            FileStream stream = new FileStream("players.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, players);

            stream.Close();
        }
        static public void Carregar()
        {
            FileStream stream = new FileStream("players.dat", FileMode.OpenOrCreate);
            try
            {
                BinaryFormatter encoder = new BinaryFormatter();

                players = (List<Player>)encoder.Deserialize(stream);

                if (players == null)
                {
                    players = new List<Player>();
                }
            }
            catch (Exception)
            {
                players = new List<Player>();
            }
            stream.Close();
        }
        static public void Remover()
        {
            Console.Clear();
            Console.WriteLine("-REMOVEDOR DE FICHAS-");
            if (players.Count == 0)
            {
                Console.WriteLine(noPlayer);
                Console.WriteLine(retornar);
                Console.ReadLine();
            }
            else
            {
                bool IDVALIDO = false;
                while (IDVALIDO == false)
                {
                    Listagem();
                    Console.WriteLine("Informe o ID do jogador que você deseja remover:");
                    string IDStr = Console.ReadLine();
                    bool IDBool = int.TryParse(IDStr, out int ID);
                    if (IDBool == true)
                    {
                        if (ID >= 0 & ID < players.Count)
                        {
                            players.RemoveAt(ID);
                            Salvar();
                            IDVALIDO = true;
                            Console.WriteLine(retornar);
                        }
                        else
                        {
                            Console.WriteLine($"O ID digitado é invalido. {retornar}");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
            }
        }
        static public void SairOp()
        {
            Console.Clear();
            Console.WriteLine("-SAIR-");
            Console.WriteLine("Tem certeza que deseja sair?\n1 - Sim\n2 - Não");
            Sair opção2 = (Sair)int.Parse(Console.ReadLine());
            if (opção2 == Sair.Não)
            {
                Console.WriteLine("Pressione ENTER para retornar ao menu inicial.");
                Console.ReadLine();
            }
            else
            {
                escolheuSair = true;
            }
        }
    }
}
