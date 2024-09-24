using System;
using System.Collections;
using System.Collections.Generic;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class Queue<T> : IEnumerable<T>
{
    private Node<T> head;
    private Node<T> tail;

    public Queue()
    {
        head = null;
        tail = null;
    }

    public void Enqueue(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (tail != null)
        {
            tail.Next = newNode;
        }
        tail = newNode;
        if (head == null)
        {
            head = newNode;
        }
    }

    public T Dequeue()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Queue is empty.");
        }
        T value = head.Data;
        head = head.Next;
        if (head == null)
        {
            tail = null;
        }
        return value;
    }

    public T Peek()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Queue is empty.");
        }
        return head.Data;
    }

    public void Print()
    {
        int index = 0;
        foreach (T item in this)
        {
            if (index % 2 != 0)
            {
                Console.Write(item + " ");
            }
            index++;
        }
        Console.WriteLine();
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Какого типа будут узлы очереди? (int, string, double)");
        string type = Console.ReadLine().ToLower();

        switch (type)
        {
            case "int":
                ExecuteQueue<int>();
                break;
            case "string":
                ExecuteQueue<string>();
                break;
            case "double":
                ExecuteQueue<double>();
                break;
            default:
                Console.WriteLine("Неподдерживаемый тип данных.");
                break;
        }
    }

    public static void ExecuteQueue<T>()
    {
        Queue<T> queue = new Queue<T>();
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Дополнить очередь");
            Console.WriteLine("2. Исключить из очереди");
            Console.WriteLine("3. Пройти и напечатать очередь");
            Console.WriteLine("4. Выйти");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Неверный ввод. Пожалуйста, выберите правильный пункт меню.");
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите значение для добавления в очередь:");
                    T data = (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                    queue.Enqueue(data);
                    break;
                case 2:
                    try
                    {
                        T dequeued = queue.Dequeue();
                        Console.WriteLine("Исключено из очереди: " + dequeued);
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case 3:
                    queue.Print();
                    break;
                case 4:
                    return;
            }
        }
    }
}
