namespace PROJE6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Sayıyı Giriniz : ");
                string Metin = Console.ReadLine();
                int Sayi = Convert.ToInt32(Metin);
                int Sonuc = 1;

                for (int i = 1; i <= Sayi; i++)
                {
                    Sonuc *= Sayi;
                }

                Console.WriteLine("{0} sayısının kendisi kadar kuvveti {1} 'dir.", Sayi, Sonuc);
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

