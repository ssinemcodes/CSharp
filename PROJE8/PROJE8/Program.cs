namespace PROJE8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string Sonuc = "";
                for (int i = 1; i <= 10; i++)
                {
                    if (i % 3 == 0 || i % 5 == 0)
                    {
                        Sonuc += i.ToString() + " ";
                    }
                }

                Console.WriteLine("1 ile 10 arasındaki 3'e veya 5'e tam bölünen sayılar : {0}",
                     Sonuc.Trim());
            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA : {0}", ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
