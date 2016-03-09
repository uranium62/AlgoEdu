using System;

namespace AlgoEdu.CreakingTheCoding.Lib
{
    internal class Arg
    {
        public double Value { get; }
        public ArgType Type { get; }
        private byte Prior { get; }

        public Arg(double val)
        {
            Value = val;
            Type  = ArgType.Number;
        }

        public Arg(char operation)
        {
            switch (operation)
            {
                case '+':
                    Type = ArgType.Plus;
                    Prior = 1;
                    break;
                case '-':
                    Type = ArgType.Minus;
                    Prior = 1;
                    break;
                case '/':
                    Type = ArgType.Div;
                    Prior = 2;
                    break;
                case '*':
                    Type = ArgType.Mult;
                    Prior = 2;
                    break;
                case '(':
                    Type = ArgType.Noun;
                    break;
                default:
                    throw new ArgumentException("operation");
            }
    
        }

        public Arg Calc(Arg arg1, Arg arg2)
        {
            if (Type == ArgType.Number)
            {
                throw new InvalidOperationException();
            }
            if (arg1.Type != ArgType.Number)
            {
                throw new ArgumentException("arg1");
            }
            if (arg2.Type != ArgType.Number)
            {
                throw new ArgumentException("arg2");
            }

            switch (Type)
            {
                case ArgType.Plus:
                    return new Arg(arg1.Value + arg2.Value);
                case ArgType.Minus:
                    return new Arg(arg1.Value - arg2.Value);
                case ArgType.Div:
                    return new Arg(arg1.Value / arg2.Value);
                case ArgType.Mult:
                    return new Arg(arg1.Value * arg2.Value);
            }

            throw new InvalidOperationException();
        }

        public bool IsGreterOrEqualPriorThan(Arg oper)
        {
            if (Type == ArgType.Number)
            {
                throw new InvalidOperationException();
            }
            if (oper.Type == ArgType.Number)
            {
                throw new InvalidOperationException();
            }

            return Prior >= oper.Prior;
        }
    }

    internal enum ArgType
    {
        Number = 0,
        Noun = 1,

        Plus,
        Minus,
        Div,
        Mult,      
    }
}
