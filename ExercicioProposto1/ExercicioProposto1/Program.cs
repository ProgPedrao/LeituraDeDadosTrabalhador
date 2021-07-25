using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercicioProposto1.Entities;
using ExercicioProposto1.Entities.Enums;

namespace ExercicioProposto1
{
    class Program
    {
        static void Main(string[] args)
        {
            string nomeDepartamento, nomeDoTrabalhador;
            WorkerLevel level;
            double baseSalary;


            Console.Write("Digite o nome do departamento: ");
            nomeDepartamento = Console.ReadLine();


            Console.WriteLine("Insira os dados do trabalhador: ");
            
            Console.Write("Digite o nome do funcionário: ");
            nomeDoTrabalhador = Console.ReadLine();

            Console.Write("Digite a qualificação do funcionário (Junior/MidLevel/Senior): ");
            level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());

            Console.Write("Digite o salario do funcionário: ");
            baseSalary = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department department = new Department(nomeDepartamento);
            Worker funcionario = new Worker(nomeDoTrabalhador, baseSalary, level, department);


            Console.Write("Quantos contratos este trabalhador terá? ");
            int qtdContracts = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < qtdContracts; i++)
            {
                Console.WriteLine($"Entre com os dados do #{i+1} contrato");

                Console.Write("Insira a data (DD/MM/YYYY): ");
                DateTime data = DateTime.Parse(Console.ReadLine());

                Console.Write("Valor por hora: ");
                double valorPorHora = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duração do contrato (Horas): ");
                int duracaoContrato = Convert.ToInt32(Console.ReadLine());

                HourContract contract = new HourContract(data, valorPorHora, duracaoContrato);
                funcionario.AddContract(contract);
            }

            Console.WriteLine("-------------------------------------");

            Console.WriteLine("Entre com o mês e ano para calcular o ganho: (MM/YYYY)");
            string monthAndYear = Console.ReadLine();

            int month = Convert.ToInt32(monthAndYear.Split('/')[0]);
            int year = Convert.ToInt32(monthAndYear.Split('/')[1]);

            Console.WriteLine("Name: " + funcionario.Name);
            Console.WriteLine("Departamento: " + funcionario.Department.Name);
            Console.WriteLine("Income for (" + monthAndYear + "): R$" + funcionario.Income(year, month));
        }
    }
}
