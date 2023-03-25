using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using ConsolePresentation;
using Data;
using System.Runtime.CompilerServices;
using Data.Models;
using Business;

namespace ConsolePresentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Display d = new Display();
            
            //CompetitionBusiness competitionBusiness = new CompetitionBusiness();
            ////string input = Console.ReadLine();
            ////if (input == "C")
            ////{
            ////    Console.WriteLine(List());
            //List<Competition> competitions = competitionBusiness.GetAll();


            //if (competitions != null)
            //{
            //    foreach (var competition in competitions)
            //        Console.WriteLine("{0} {1} {2} {3} {4}", competition.Id, competition.Name, competition.Country, competition.Place, competition.DateTime);

            //}
            //else
            //    Console.WriteLine("No available competitions");

        }
    }

    
}
