﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bubblesort
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = 0;
            Bubble b;
            Employee origin;
            Employee[] employees;
            string filename;

            // catch missing arguments error.
            try
            {
                filename = args[0];

                // catch file not found exception.
                try
                {
                    var sr = new StreamReader(filename);
                    n = int.Parse(sr.ReadLine());
                    employees = new Employee[n];
                    b = new Bubble();

                    // reading Employee information by for loop
                    for (int i = 0; i < n; i++)
                    {
                        string nextLine = sr.ReadLine();
                        employees[i] = new Employee(nextLine);
                    }
                    sr.Close();

                    b.bubble_sort(employees);

                    //bublesort with method    
                    StreamWriter sw = new StreamWriter("roster.txt");
                    for (int i = 0; i < n; i++)
                    {
                        sw.WriteLine(employees[i].original);
                    }
                    sw.Close();


                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("File has not found.");
                }
            }
            catch (IndexOutOfRangeException asa)
            {
                Console.WriteLine("Missing argument line");
            }
        }
    }

    class Employee
    {
        public string name;
        public int id;
        private int age;
        private string job;
        private int year;
        public string original;

        public Employee(string data)
        {
            string[] fields = data.Split('|');
            name = fields[0];
            id = int.Parse(fields[1]);
            age = int.Parse(fields[2]);
            job = fields[3];
            year = int.Parse(fields[4]);
            original = data;
        }
    }


    // bubble sort
    class Bubble
    {

        public void bubble_sort(Employee[] A)
        {
            Employee backup;
            int compare;
            int exchanges = 0;
            // check the last index's value and index-1, and compare the weight and exchanges.
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = A.Length - 1; j > i; j--)
                {
                    if (A[j].id < A[j - 1].id)
                    {
                        backup = A[j];
                        A[j] = A[j - 1];
                        A[j - 1] = backup;
                        exchanges++;
                        foreach (Employee c in A)
                        {
                            Console.Write(c.id.ToString() + " ");
                        }
                        Console.WriteLine("");
                    }
                }
            }
            compare = A.Length * (A.Length - 1) / 2;
            Console.WriteLine("comparisons: " + compare);
            Console.WriteLine("exchanges: " + exchanges);
        }
    }
}




