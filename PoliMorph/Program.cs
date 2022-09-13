namespace PoliMorph
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new RationalNumbers(2, 4);
            var b = new RationalNumbers(2, 4);
            
            if ( a == b)
            {
                Console.WriteLine("im happy");
            }

           
        }
    }
}