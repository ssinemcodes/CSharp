namespace PROJE18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //KULALNICI TARAFINDAN GİRİLEN SATIR SAYISI KADAR HER SATIRDA BİR FAZLA * 
            //SEMBOLÜ YAZARAK EKRANA YAZAN KOD


            try
            {
                Console.Write("Satır sayısını girin: ");
                int n = int.Parse(Console.ReadLine());

                if (n <= 0)
                    throw new ArgumentException("Satır sayısı sıfırdan büyük olmalıdır."); 


                for (int i = 1; i <= n; i++)
                {
                    Console.WriteLine(new string('*', i));
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Hata: Lütfen geçerli bir sayı girin.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nProgram sonlandı.");
            }
        }
    }
}
