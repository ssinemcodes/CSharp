namespace PROJE1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int SAYI1;
            int SAYI2;
            string METIN1;
            string METIN2;
            int SONUC;

            Console.Write("1. Sayıyı Giriniz : ");
            METIN1 = Console.ReadLine();
            SAYI1 = Convert.ToInt32(METIN1);


            Console.Write("1. Sayıyı Giriniz : ");
            METIN2 = Console.ReadLine();
            SAYI2 = Convert.ToInt32(METIN2);

            SONUC = SAYI1 + SAYI2;

            Console.WriteLine(SONUC.ToString());
        }
    }
}
