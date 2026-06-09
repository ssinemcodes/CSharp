namespace PROJE19
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //THREADİNG ÖRNEK PROJE 

            for (int i = 0; i < 100; i++)
            {
                Console.Clear();
                Console.WriteLine(DateTime.Now.ToString());
                Thread.Sleep(1000);
            }
        }
    }
}
