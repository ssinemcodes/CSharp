namespace PROJE4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int Sonuc = 0;

                for (int i = 1; i <= 10; i++)
                {
                    if (i % 2 != 0)
                    {
                        Sonuc += i;
                    }
                }

                Console.WriteLine("1 İle 10 arasındaki tek sayıların toplamı {0}'dr.", Sonuc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
