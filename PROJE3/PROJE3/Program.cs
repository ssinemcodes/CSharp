namespace PROJE3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int SONUC = 0;

                for (int i = 1; i <= 10; i++)
                {
                    SONUC += i;
                }

                Console.WriteLine("1 ile 10 arasındaki tam sayıların toplamı {0} olur.", SONUC);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
