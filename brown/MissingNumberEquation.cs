using System;

namespace brown
{
    public class MissingNumberEquation : Equation
    {
        private readonly int _style;

        public MissingNumberEquation(int a, int b, string op, int style)
            : base(a, b, op)
        {
            _style = style;
        }

        public int Style 
        {
            get 
            {
                return _style;
            }    
        }

        public override string ToString()
        {
            if (Operator == "x")
            {
                if (_style == 0)
                {
                    return base.ToString().Replace(string.Format("= {0}", Decorate(Result)), " =");
                }

				if (_style == 1)
				{
                    return base.ToString().Replace(string.Format("{0} x", Decorate(A)), " x");
				}

				if (_style == 2)
				{
                    return base.ToString().Replace(string.Format("x {0}", Decorate(B)), "x ");
				}
            }

            if (Operator == "/")
            {
				if (_style == 0)
				{
                    return base.ToString().Replace(string.Format("= {0}", Decorate(B)), "= ");
				}

				if (_style == 1)
				{
                    return base.ToString().Replace(string.Format("{0} ÷", Decorate(Result)), " ÷");
				}

				if (_style == 2)
				{
					return base.ToString().Replace(string.Format("÷ {0}", Decorate(A)), "÷ ");
				}
            }

            return string.Empty;
        }

        public override bool Equal(Equation eq)
		{
            MissingNumberEquation meq = eq as MissingNumberEquation;

            if (meq == null)
            {
                return false;
            }

            return base.Equal(eq) && _style == meq.Style;
		}
    }
}
