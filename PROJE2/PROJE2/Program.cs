namespace PROJE2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double SAYI1;
            double SAYI2;
            string METIN1;
            string METIN2;
            double SONUC;

            Console.Write("1. Sayıyı Giriniz : ");
            METIN1 = Console.ReadLine();
            SAYI1 = Convert.ToDouble(METIN1);

            Console.Write("2. Sayıyı Giriniz : ");
            METIN2 = Console.ReadLine();
            SAYI2 = Convert.ToDouble(METIN2);

            SONUC = (SAYI1 + SAYI2) / 2d;

            Console.WriteLine("{0} sayısı ile {1} sayısının aritmetik ortalaması {2} olur.", SAYI1, SAYI2, SONUC);
        }
    }
}
