using System;
namespace brown
{
    public class Equation
    {
		private readonly string _operator;

        private int _a;
        private int _b;

        public Equation(int a, int b, string op)
        {
            _a = a;
            _b = b;
            _operator = op;
        }

        public int A 
        {
            get 
            {
                return _a;
            }
        }

        public int B 
        {
            get 
            {
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

            _a = a;
            _b = b;

            if (_operator == "/") 
            {
                return string.Format("{0} ÷ {1} = {2}", Decorate(Result), Decorate(a), Decorate(b));
            }

            return string.Format("{0} x {1} = {2}", Decorate(a), Decorate(b), Decorate(Result));
        }

        public virtual bool Equal(Equation eq)
        {
            if (_operator == "/") {
                return eq.A == _a && eq.B == _b && eq.Operator == _operator;
            }

            return eq.A == _a && eq.B == _b;
        }

        internal static string Decorate(int val)
        {
            return val.ToString();
        }
    }
}
