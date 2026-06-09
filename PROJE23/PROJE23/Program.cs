namespace PROJE23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // KULLANICI TARAFINDAN GİRİLEN SAYILARIN GEOMETRİK ORTALAMASINI ALARAK SONUCU EKRANA YAZDIRAN C# KODU

            Console.Write("Kaç sayı girmek istiyorsunuz? ");
            int adet = int.Parse(Console.ReadLine());

            double carpim = 1.0;

            for (int i = 1; i <= adet; i++)
            {
                Console.Write($"{i}. sayıyı girin: ");
                double sayi = double.Parse(Console.ReadLine());
                carpim *= sayi;
            }

            double geometrikOrtalama = Math.Pow(carpim, 1.0 / adet);

            Console.WriteLine($"\nGirilen {adet} sayının geometrik ortalaması: {geometrikOrtalama:F4}");
        }
    }
}
