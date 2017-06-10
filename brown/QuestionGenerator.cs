using System;
using System.Collections.Generic;
using System.Linq;
using brown.Ext;

namespace brown
{
    public class QuestionGenerator
    {
        /// <summary>
        /// Generate the questions given specified digits, ops and numberOfQuestions.
        /// </summary>
        /// <returns>The generate.</returns>
        /// <param name="digits">Digits.</param>
        /// <param name="op">Ops.</param>
        /// <param name="numberOfQuestions">Number of questions.</param>
        public IEnumerable<Equation> Generate(IEnumerable<int> digits, string op, int numberOfQuestions)
        {
            if (numberOfQuestions <= 0) 
            {
                throw new ArgumentException("numberOfQuestions");
            }

            // 1 is omitted to increase the difficulty
            List<int> fixedDigits = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<Equation> questions = new List<Equation>();

            while(questions.Count < numberOfQuestions)
            {
                int a = digits.Rand();
                int b = fixedDigits.Rand();

                Equation eq = null;

                try
                {
                    eq = new Equation(a, b, op);   
                }
                catch(ArgumentException)
                {
                    continue;
                }

                if (!questions.Any(q => q.Equal(eq)))
                {
                    questions.Add(eq);
                }
            }

            return questions;
        }
    }
}
