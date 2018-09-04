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
            int numberOfQuestions = 30;

            QuestionGenerator gen = new QuestionGenerator();
            IEnumerable<MissingNumberEquation> mulEqs = gen.Generate(new List<int> { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}, "x", numberOfQuestions);
            IEnumerable<MissingNumberEquation> divEqs = gen.Generate(new List<int> { 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}, "/", numberOfQuestions);

            List<MissingNumberEquation> eqs = new List<MissingNumberEquation>();
            eqs.AddRange(mulEqs);
            eqs.AddRange(divEqs);

            List<MissingNumberEquation> mixed = eqs.Mix().ToList();

            int numberOfColumns = 5;
            int count = 1;

            foreach(Equation eq in mixed)
            {
                Console.Write(eq);
                if (count % numberOfColumns == 0) 
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
