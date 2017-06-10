using System;
using System.Collections.Generic;
using System.Linq;
using brown.Ext;

namespace brown
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfQuestions = 20;

            QuestionGenerator gen = new QuestionGenerator();
            IEnumerable<Equation> mulEqs = gen.Generate(new List<int> { 3, 4, 5, 6, 8}, "x", numberOfQuestions);
            IEnumerable<Equation> divEqs = gen.Generate(new List<int> { 3, 4, 5, 6, 8 }, "/", numberOfQuestions);

            List<Equation> eqs = new List<Equation>();
            eqs.AddRange(mulEqs);
            eqs.AddRange(divEqs);

            List<Equation> mixed = eqs.Mix().ToList();

            int count = 1;
            foreach(Equation eq in mixed)
            {
                Console.Write(eq);
                if (count % 4 == 0) 
                {
                    Console.WriteLine();
                } 
                else 
                {
                    Console.Write("\t");    
                }
                count++;
            }
        }
    }
}
