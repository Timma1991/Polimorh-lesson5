using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliMorph
{
    internal class RationalNumbers
    {
        private int _numerator;
        private int _denominator;
        public int Numerator
        {
            get { return _numerator; }
        }

        public int Denominator
        {
            get { return _denominator; }
        }
        public RationalNumbers(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("The denominator must be non-zero.");

            if (denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }

            _numerator = numerator;
            _denominator = denominator;

        }
        public static bool  operator ==(RationalNumbers first, RationalNumbers second)
        {
            return first.Equals(second);
        }
        public static bool operator !=(RationalNumbers first,RationalNumbers second)
        {
            return !first.Equals(second);
        }

        //Сокращение дроби до ее наименьших значений
        private RationalNumbers ReduceToLowestTerms(int other)
        {
            int gcd = RationalNumbers.GetGCD(other, Denominator);
            int multiplier = gcd / Denominator;
            int newNumerator = Numerator * multiplier;
            return new RationalNumbers(newNumerator, gcd);
        }        

        //Нахождение наибольшего общего делител
        private static int GetGCD(int term1, int term2)
        {
            if (term2 == 0)
                return term1;
            else
                return GetGCD(term2, term1 % term2);
        }

        //Создание оператора сложения
        public static RationalNumbers operator +(RationalNumbers r1, RationalNumbers r2)
        {
            return new RationalNumbers((r1.Numerator * r2.Denominator)
                + (r2.Numerator * r1.Denominator), r1.Denominator * r2.Denominator);
        }

        //Создание оператора вычетания
        public static RationalNumbers operator -(RationalNumbers r1, RationalNumbers r2)
        {
            return new RationalNumbers((r1.Numerator * r2.Denominator)
                - (r2.Numerator * r1.Denominator), r1.Denominator * r2.Denominator);
        }

        //Добавление операторов умножения и деления
        public static RationalNumbers operator *(RationalNumbers r1, RationalNumbers r2)
        {
            return new RationalNumbers(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
        }

        public static RationalNumbers operator /(RationalNumbers r1, RationalNumbers r2)
        {
            return new RationalNumbers(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);
        }
        //Добавление оператора остатка от деления
        public static RationalNumbers operator %(RationalNumbers r1,RationalNumbers r2)
        {
            return new RationalNumbers(r1.Numerator % r2.Numerator, r1.Denominator % r2.Denominator);
        }

        //Добавления оператора инкремента и дикримента
        public static RationalNumbers operator ++(RationalNumbers r1)
        {
            r1._numerator++;
            r1._denominator++;
            return r1;
        }
        public static RationalNumbers operator --(RationalNumbers r1)
        {
            r1._numerator--;
            r1._denominator--;
            return r1;
        }

        public double Sym
        {
            get { return Math.Sqrt(_numerator * _numerator + _denominator * _denominator); }
        }
        //Добавление оператора сравнения
        public static bool operator >(RationalNumbers r1,RationalNumbers r2)
        {
            if(r1.Denominator == r2.Denominator)
            {
                return r1.Numerator > r2.Numerator;
            }
            RationalNumbers temp = r1.ReduceToLowestTerms(r2.Denominator);
            return temp.Numerator > r2.Numerator;
        }

        public static bool operator <(RationalNumbers r1, RationalNumbers r2)
        {
            if (r1.Denominator == r2.Denominator)
            {
                return r1.Numerator < r2.Numerator;
            }
            RationalNumbers temp = r1.ReduceToLowestTerms(r2.Denominator);
            return temp.Numerator < r2.Numerator;
        }

        public static bool operator >=(RationalNumbers r1, RationalNumbers r2)
        {
            if (r1.Denominator == r2.Denominator)
            {
                return r1.Numerator >= r2.Numerator;
            }
            RationalNumbers temp = r1.ReduceToLowestTerms(r2.Denominator);
            return temp.Numerator >= r2.Numerator;
        }

        public static bool operator <=(RationalNumbers r1, RationalNumbers r2)
        {
            if (r1.Denominator == r2.Denominator)
            {
                return r1.Numerator <= r2.Numerator;
            }
            RationalNumbers temp = r1.ReduceToLowestTerms(r2.Denominator);
            return temp.Numerator <= r2.Numerator;
        }


        public override bool Equals(object? obj)
        {
            if(obj is not RationalNumbers)
            {
                return false;
            }
            var other = obj as RationalNumbers;
            return this.Numerator == other.Numerator &&
                this.Denominator == other.Denominator;
        }

        public override string? ToString()
        {
            return $"{Numerator}/{Denominator}";
        }
    }
}
