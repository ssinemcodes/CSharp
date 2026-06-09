namespace PROOJE21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StreamWriter sw = new StreamWriter("D// Sample.txt");
                sw.WriteLine("HELLO WORLD!!");
                sw.WriteLine("From the StreamWriter class");
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
