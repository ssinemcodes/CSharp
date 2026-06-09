namespace PROJE20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //"\", "|", "-" ve "/" sembollerini kullanarak pervane etkisi gösteren 
            (toplamda 100 defa dönen) bir animasyon yapılmak istenmektedir. 




            try
            {
                int DelayTime = 100;
                for (int i = 1; i <= 100; i++)
                {
                    Console.Clear();
                    Console.WriteLine("                -");
                    Thread.Sleep(DelayTime);
                    Console.Clear();
                    Console.WriteLine("                |");
                    Thread.Sleep(DelayTime);
                    Console.Clear();
                    Console.WriteLine("                /");
                    Thread.Sleep(DelayTime);
                    Console.Clear();
                    Console.WriteLine("                -");
                    Thread.Sleep(DelayTime);
                    Console.Clear();
                    Console.WriteLine("                |");
                    Thread.Sleep(DelayTime);
                    Console.Clear();
                    Console.WriteLine("                -");
                    Thread.Sleep(DelayTime);
                    Console.Clear();
                    Console.WriteLine("                \\");
                    Thread.Sleep(DelayTime);
                    Console.Clear();
                    Console.WriteLine("                |");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA : {0}", ex.ToString());
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
