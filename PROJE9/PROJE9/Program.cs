namespace PROJE9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] SayıDizisi = new int[3];
                for (int i = 0; i < SayıDizisi.Length; i++)
                {
                    Console.Write("Sayı dizisinin {0}. elemanını giriniz :", i);
                    string Metin = Console.ReadLine();
                    SayıDizisi[i] = Convert.ToInt32(Metin);
                }

                int Toplam = 0;

                for (int i = 0; i < SayıDizisi.Length; i++)
                {
                    Toplam += SayıDizisi[i];
                }

                Console.WriteLine("Sayı dizisinin elemanları toplamı {0} 'dır.", Toplam);
            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA : {}0", ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
