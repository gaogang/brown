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
        public IEnumerable<MissingNumberEquation> Generate(IEnumerable<int> digits, string op, int numberOfQuestions)
        {
            if (numberOfQuestions <= 0) 
            {
                throw new ArgumentException("numberOfQuestions");
            }

            List<MissingNumberEquation> questions = new List<MissingNumberEquation>();

            Random rand = new Random();
            int style = 0;

            while(questions.Count < numberOfQuestions)
            {
                int aid = rand.Next(digits.Count());
                int bid = rand.Next(digits.Count());

                int a = digits.ElementAt(aid);
                int b = digits.ElementAt(bid);

                // Reset style
                if (style == 3) 
                {
                    style = 0;
                }

                if (a + b < 10) 
                {
                    continue;
                }

                MissingNumberEquation eq = null;

                try
                {
                    eq = new MissingNumberEquation(a, b, op, style);   
                }
                catch(ArgumentException)
                {
                    continue;
                }

                if (!questions.Any(q => q.Equal(eq)))
                {
                    questions.Add(eq);

                    style++;
                }
            }

            return questions;
        }
    }
}
