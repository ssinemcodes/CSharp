using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TDKAkilliArama
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            client.DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

            Console.WriteLine("=== TDK Gelişmiş Arama Motoru ===");
            Console.Write("Aramak istediğiniz kelime/isim: ");
            string arananKelime = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(arananKelime))
            {
                Console.WriteLine("Lütfen bir kelime girin!");
            }
            else
            {
                Console.WriteLine("\nSorgulanıyor...\n");
                await TdkHepsiniAra(arananKelime);
            }

            Console.WriteLine("\nÇıkmak için bir tuşa basın...");
            Console.ReadKey();
        }

        static async Task TdkHepsiniAra(string kelime)
        {
            var trCulture = System.Globalization.CultureInfo.GetCultureInfo("tr-TR");
            string aranan = Uri.EscapeDataString(kelime.ToLower(trCulture));

            string gtsUrl = $"https://sozluk.gov.tr/gts?ara={aranan}";
            string adlarUrl =
$"https://sozluk.gov.tr/adlar?ara={aranan}&gore=1&cins=2";
            bool bulundu = false;

            // 1. AŞAMA: SÖZLÜK TARAMASI 
            try
            {
                string gtsJson = await client.GetStringAsync(gtsUrl);
                if (!gtsJson.Contains("\"error\""))
                {
                    bulundu = true;
                    Console.WriteLine($"[ SÖZLÜK ANLAMI : {kelime.ToUpper(trCulture)} 
]"); 
                    JArray gtsDizi = JArray.Parse(gtsJson);
                    foreach (var kayit in gtsDizi)
                    {
                        var anlamlar = kayit["anlamlarListe"];
                        if (anlamlar != null)
                        {
                            int i = 1;
                            foreach (var anlam in anlamlar)
                            {
                                Console.WriteLine($"{i}. {anlam["anlam"]}");
                                i++;
                            }
                        }
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Sözlük sorgusu hatası: {ex.Message}");
            }

            // 2. AŞAMA: İSİM TARAMASI 
            try
            {
                string adlarJson = await client.GetStringAsync(adlarUrl);
                if (!adlarJson.Contains("\"error\""))
                {
                    bulundu = true;
                    Console.WriteLine($"[ İSİM ANLAMI : {kelime.ToUpper(trCulture)} 
]"); 
                    JArray adlarDizi = JArray.Parse(adlarJson);
                    foreach (var kayit in adlarDizi)
                    {
                        string cinsiyetKodu = kayit["cinsiyet"]?.ToString();
                        string cinsiyet = cinsiyetKodu switch
                        {
                            "1" => "Erkek",
                            "2" => "Kız",
                            "3" => "Erkek ve Kız",
                            _ => "Belirtilmemiş"
                        };

                        Console.WriteLine($"> Cinsiyet: {cinsiyet}");
                        Console.WriteLine($"> Anlamı  : {kayit["anlam"]}");
                        Console.WriteLine("-------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"İsim sorgusu hatası: {ex.Message}");
            }

            if (!bulundu)
                Console.WriteLine("Sonuç bulunamadı.");
        }
    }
}