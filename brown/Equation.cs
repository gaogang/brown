using System;
namespace brown
{
    public class Equation
    {
        private readonly int _a;
        private readonly int _b;
        private readonly string _operator;

        public Equation(int a, int b, string op)
        {
            if (a == 0 && b == 0) 
            {
                throw new ArgumentException("a and b cannot be 0 at the same time");    
            }

            if (op == "/" && a * b == 0) 
            {
                throw new ArgumentException("a cannot be 0 when the operator is divide");
            }

            _a = a;
            _b = b;
            _operator = op;
        }

        public int A {
            get {
                return _a;
            }
        }

        public int B {
            get {
                return _b;
            }
        }

        public string Operator {
            get {
                return _operator;
            }
        }

        public int Result
        {
            get 
            {
                return _a * _b;   
            }    
        }

        public Equation Clone()
        {
            return new Equation(_a, _b, _operator);
        }

        public override string ToString()
        {
            // Base on the millisecond component of Now, we decide the order
            // of A and B in the equation
            bool flippingCoin = (DateTime.Now.Millisecond % 2) == 0;

            int a = flippingCoin ? _a : _b;
            int b = flippingCoin ? _b : _a;

            if (_operator == "/") 
            {
                return string.Format("{0} ÷ {1} = ", Decorate(Result), Decorate(a != 0 ? a : b));
            }

            return string.Format("{0} x {1} = ", Decorate(a), Decorate(b));
        }

        public bool Equal(Equation eq)
        {
            if (_operator == "/") {
                return eq.A == _a && eq.B == _b && eq.Operator == _operator;
            }

            return eq.A == _a && eq.B == _b;
        }

        private static string Decorate(int val)
        {
            if (val < 10) 
            {
                return string.Format(" {0}", val);
            }

            return val.ToString();
        }
    }
}
