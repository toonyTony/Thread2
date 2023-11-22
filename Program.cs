using System;
using System.Diagnostics;
using System.Threading;


        string inputString = "Строка с пробелом ";
        int numThreads = 2;

        Thread[] threads = new Thread[numThreads];

      
        int partSize = inputString.Length / numThreads;
        for (int i = 0; i < numThreads; i++)
        {
            int startIndex = i * partSize;
            int endIndex = (i == numThreads - 1) ? inputString.Length : (i + 1) * partSize;

         
            threads[i] = new Thread(() =>
            {
               
                RemoveLastSpace(inputString, startIndex, endIndex);
            });
        }

  
        Stopwatch stopwatch = Stopwatch.StartNew();

    
        foreach (Thread thread in threads)
        {
            thread.Start();
        }

        
        foreach (Thread thread in threads)
        {
            thread.Join();
        }

    
        stopwatch.Stop();

   
        Console.WriteLine($"Строка без пробела: {inputString}");
        Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} milliseconds");
    static void RemoveLastSpace(string input, int startIndex, int endIndex)
    {
       
        for (int i = endIndex - 1; i >= startIndex; i--)
        {
            if (input[i] == ' ')
            {
              
                input = input.Remove(i, 1);
                break;
            }
        }
    }
