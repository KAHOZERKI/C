using System;
using System.Collections.Generic;
class Program
{
    public static void Main()
    {
        string s = Console.ReadLine();
        string[] ss = s.Split(' ');
        int[] numbers = new int[10];
        for (int i = 0; i < 10; i++)
        {
            numbers[i] = int.Parse(ss[i]);
        }
        Queue<int> player1 = new Queue<int>();
        Queue<int> player2 = new Queue<int>();
        for (int i = 0; i < 10; i++)
            if (i % 2 == 0)
            {
                player1.Enqueue(numbers[i]);
            }
            else
            {
                player2.Enqueue(numbers[i]);
            }
        while (player1.Count != 0 || player2.Count != 0)
        {
            Console.WriteLine("Игрок1 " + player1.Peek() + " Игрок2 " + player2.Peek());
            if ((player1.Peek() == 9 && player2.Peek() == 0))
            {
                player2.Enqueue(player2.Peek());
                player2.Enqueue(player1.Peek());
                player2.Dequeue();
                player1.Dequeue();
            }
            else
            {

                if (player1.Peek() > player2.Peek())
                {
                    player1.Enqueue(player1.Peek());
                    player1.Enqueue(player2.Peek());
                    player1.Dequeue();
                    player2.Dequeue();
                }
                else
                {
                    if ((player2.Peek() == 9 && player1.Peek() == 0))
                    {
                        player1.Enqueue(player1.Peek());
                        player1.Enqueue(player2.Peek());
                        player1.Dequeue();
                        player2.Dequeue();
                    }
                    else
                    {
                        player2.Enqueue(player2.Peek());
                        player2.Enqueue(player1.Peek());
                        player2.Dequeue();
                        player1.Dequeue();
                    }
                }
            }
            if (player1.Count == 0 || player2.Count == 0)
            {
                if (player1.Count != 0)
                {
                    Console.Write("Игрок1");
                }
                else
                {
                    Console.Write("Игрок2");
                }
                break;
            }
        }
    }
}
