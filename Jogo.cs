using System; // Biblioteca do C#

class Jogo
{
    static void Main()
    {
        Random gerar = new Random();

        string nome = "Matheus";
        int vida = 100;

        int vidaMonstro = 200;
        int ataqueMonstro = 15;



        while (vida > 0 && vidaMonstro > 0)
        {
            int numero = gerar.Next(1, 21);
            
            MostrarMenu();
            string escolha = Console.ReadLine();
            Console.Clear();

            if (escolha == "1" || escolha == "Atacar" || escolha == "atacar")
            {
                int critico = gerar.Next(1, 11);
                AtaqueJogador(ref vidaMonstro, ref ataqueMonstro, ref vida, ref nome, ref critico);
                MostrarStatus(ref vidaMonstro, ref vida, ref nome);
            }

            else if (escolha == "2" || escolha == "Curar" || escolha == "curar")
            {
                CurarJogador(ref vida, ref ataqueMonstro, ref nome);
                MostrarStatus(ref vidaMonstro, ref vida, ref nome);
            }
            else if (escolha == "3" || escolha == "Defender" || escolha == "defender")
            {
                DefenderJogador(ref vidaMonstro, ref vida, ref ataqueMonstro);
                MostrarStatus(ref vidaMonstro, ref vida, ref nome);
            }
            else if (escolha == "4")
            {
                DadoSorte(ref numero, ref vidaMonstro, ref vida, ref ataqueMonstro);
                MostrarStatus(ref vidaMonstro, ref vida, ref nome);
            }

            else
            {
                Console.WriteLine("Opção invalida.");
                continue;
            }

            if (vida <= 0)
            {
                Console.WriteLine("========================================================================");
                Console.WriteLine("\nGame Over.\n");
                Console.WriteLine("========================================================================");
            }
            else if (vidaMonstro <= 0)
            {
                Console.WriteLine("========================================================================");
                Console.WriteLine("\nParabéns você ganhou!!!!\n");
                Console.WriteLine("========================================================================");
            }
            Console.WriteLine("Pressione Enter para ir para o próximo turno...");
            Console.ReadLine();
            Console.Clear();
        }
    }
    static void MostrarMenu()
    {
        Console.WriteLine("1- Atacar");
        Console.WriteLine("2- Curar");
        Console.WriteLine("3- Defender");
        Console.WriteLine("4- Dado da sorte");
    }
    static void MostrarStatus(ref int vidaMonstro, ref int vida, ref string nome)
    {
        Console.WriteLine("\n========================================================================");
        Console.WriteLine("\nO monstro atacou: -15 de vida");
        Console.WriteLine($"\nVida atual do monstro: {vidaMonstro}\nVida atual do jogador {nome}: {vida}\n");
        Console.WriteLine("========================================================================\n");
    }
    static void AtaqueJogador(ref int vidaMonstro, ref int ataqueMonstro, ref int vida, ref string nome, ref int critico)
    {
        if (critico > 9)
        {
            vidaMonstro -= (20 * 2);
            vida -= ataqueMonstro;
            Console.WriteLine("Parabéns você efetuou um ataque critico, causando o dobro de dano.");
        }
        else
        {
            Console.WriteLine("Você realizou um ataque: 20 Dano");
            vidaMonstro -= 20;
            vida -= ataqueMonstro;
        }

    }

    static void CurarJogador(ref int vida, ref int ataqueMonstro, ref string nome)
    {
        Console.WriteLine("Você conseguiu curar: 22 vida");
        vida += 22;
        vida -= ataqueMonstro;

        Console.WriteLine("O monstro atacou: -15 de vida");
    }
    static void DefenderJogador(ref int vidaMonstro, ref int vida, ref int ataqueMonstro)
    {
        vida -= (ataqueMonstro / 2);
        vida += (22 / 3);
        vidaMonstro -= (20 / 3);
        Console.WriteLine("Você bloqueou metade do ataque, curou 1 terço da sua vida e deu 1 terço de dano no monstro.");
    }
    static void DadoSorte(ref int numero, ref int vidaMonstro, ref int vida, ref int ataqueMonstro)
    {
        if (numero == 20)
        {
            vidaMonstro = 0;
            Console.WriteLine("\n========================================================================\n");
            Console.WriteLine("Parabéns você matou o Monstro");
            Console.WriteLine("\n========================================================================");
        }
        else
        {
            vida -= (ataqueMonstro * 2);
            Console.WriteLine($"Parabéns você tomou o dobro de dano.");
        }
    }
}