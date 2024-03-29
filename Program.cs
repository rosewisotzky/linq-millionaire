﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_millionaire
{
    // Build a collection of customers who are millionaires
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

            List<Customer> millionaires = customers.Where(c => c.Balance > 1000000.00).ToList();
            foreach (Customer millionaire in millionaires)
            {
                Console.WriteLine($"{millionaire.Name} is a millionaire.");
            }

            /*
                Given the same customer set, display how many millionaires per bank.
                Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

                Example Output:
                WF 2
                BOA 1
                FTB 1
                CITI 1
            */
            // Here we're creating a new collectoin called millionairePerBank. We are going through our list called millionaires and using .GroupBy to access the Bank and the Name of each customer object. Then we're creating a NEW object, where the Bank is the key and then we're saying that the Number of Millionaires is going to be the number of names we are counting.
            var millionairePerBank = millionaires.GroupBy(
                mil => mil.Bank,
                mil => mil.Name,
                (key, person) => new
                {
                    Bank = key,
                    NumberOfMillionaires = person.Count()
                }
            );
            foreach(var customer in millionairePerBank) {
                Console.WriteLine($"{customer.Bank} {customer.NumberOfMillionaires}");
                
            }
        }

    }
}

