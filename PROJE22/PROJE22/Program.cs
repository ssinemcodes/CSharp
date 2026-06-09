using System.Text;

namespace PROJE22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using System;
            using System.Collections.Generic;
            using System.IO;
            using System.Management;
            using System.Text;


class DonanımBilgisi
        {
            static void Main(string[] args)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("Donanım bilgileri toplanıyor...\n");

                var sb = new StringBuilder();
                sb.AppendLine("============================================");
                sb.AppendLine("       BİLGİSAYAR DONANIM BİLGİLERİ       ");
                sb.AppendLine($"       {DateTime.Now:dd.MM.yyyy HH:mm:ss}       ");
                sb.AppendLine("============================================\n");

                // ─── İŞLEMCİ ─────────────────────────────────────────── 
                sb.AppendLine("[ İŞLEMCİ (CPU) ]");
                sb.AppendLine(new string('-', 44));
                try
                {
                    using var searcher = new ManagementObjectSearcher("SELECT * FROM 
        Win32_Processor"); 
        
                    int i = 1;
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        sb.AppendLine($"  {i++}. Marka/Model : {obj["Name"]}");
                        sb.AppendLine($"     Üretici     : {obj["Manufacturer"]}");
                        sb.AppendLine($"     Çekirdek    : {obj["NumberOfCores"]} çekirdek / 
        { obj["NumberOfLogicalProcessors"]}
                        mantıksal işlemci"); 
                        sb.AppendLine($"     Max Hız     : {obj["MaxClockSpeed"]} MHz");
                        sb.AppendLine($"     Mimari      : 
        { GetArchitecture(obj["Architecture"]?.ToString())}
                        "); 
                        sb.AppendLine();
                    }
                }
                catch (Exception ex)
                {
                    sb.AppendLine($"  [HATA] İşlemci bilgisi alınamadı: {ex.Message}\n");
                }

                // ─── EKRAN KARTI ──────────────────────────────────────── 
                sb.AppendLine("[ EKRAN KARTI (GPU) ]");
                sb.AppendLine(new string('-', 44));
                try
                {
                    using var searcher = new ManagementObjectSearcher("SELECT * FROM 
        Win32_VideoController"); 
        
                    int i = 1;
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        ulong ramBytes = Convert.ToUInt64(obj["AdapterRAM"] ?? 0);
                        string ramStr = ramBytes > 0 ? $"{ramBytes / (1024 * 1024)} MB" :
        "Bilinmiyor";

                        sb.AppendLine($"  {i++}. Marka/Model : {obj["Name"]}");
                        sb.AppendLine($"     Sürücü      : {obj["DriverVersion"]}");
                        sb.AppendLine($"     Video RAM   : {ramStr}");
                        sb.AppendLine($"     Çözünürlük  : 
        { obj["CurrentHorizontalResolution"]}
                        x{ obj["CurrentVerticalResolution"]}
                        "); 
                        sb.AppendLine();
                    }
                }
                catch (Exception ex)
                {
                    sb.AppendLine($"  [HATA] Ekran kartı bilgisi alınamadı: {ex.Message}\n");
                }

                // ─── RAM ──────────────────────────────────────────────── 
                sb.AppendLine("[ RAM (Bellek) ]");
                sb.AppendLine(new string('-', 44));
                try
                {
                    using var searcher = new ManagementObjectSearcher("SELECT * FROM 
        Win32_PhysicalMemory"); 
        
                    int i = 1;
                    ulong toplamRam = 0;

                    foreach (ManagementObject obj in searcher.Get())
                    {
                        ulong kapasiteBytes = Convert.ToUInt64(obj["Capacity"] ?? 0);
                        toplamRam += kapasiteBytes;
                        string kapasite = $"{kapasiteBytes / (1024 * 1024 * 1024)} GB";
                        uint hiz = Convert.ToUInt32(obj["Speed"] ?? 0);

                        sb.AppendLine($"  {i++}. Marka       : {obj["Manufacturer"]}");
                        sb.AppendLine($"     Kapasite    : {kapasite}");
                        sb.AppendLine($"     Hız         : {hiz} MHz");
                        sb.AppendLine($"     Tür         : {obj["MemoryType"] ?? "Bilinmiyor"} 
        / DDR{ GetDdrType(obj["SMBIOSMemoryType"]?.ToString())}
                        "); 
                        sb.AppendLine($"     Part No     : 
        { obj["PartNumber"]?.ToString()?.Trim()}
                        "); 
                        sb.AppendLine($"     Slot        : {obj["DeviceLocator"]}");
                        sb.AppendLine();
                    }

                    sb.AppendLine($"  Toplam RAM  : {toplamRam / (1024 * 1024 * 1024)} GB");
                    sb.AppendLine();
                }
                catch (Exception ex)
                {
                    sb.AppendLine($"  [HATA] RAM bilgisi alınamadı: {ex.Message}\n");
                }

                // ─── SABİT DİSK ───────────────────────────────────────── 
                sb.AppendLine("[ SABİT DİSK / DEPOLAMA ]");
                sb.AppendLine(new string('-', 44));
                try
                {
                    using var searcher = new ManagementObjectSearcher("SELECT * FROM 
        Win32_DiskDrive"); 
        
                    int i = 1;
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        ulong boyutBytes = Convert.ToUInt64(obj["Size"] ?? 0);
                        string boyut = boyutBytes > 0
                            ? $"{boyutBytes / (1024UL * 1024 * 1024)} GB ({boyutBytes /
        (1024UL * 1024 * 1024 * 1024.0):F2} TB)"
                            : "Bilinmiyor";

                        sb.AppendLine($"  {i++}. Model       : {obj["Model"]}");
                        sb.AppendLine($"     Üretici     : {obj["Manufacturer"]}");
                        sb.AppendLine($"     Kapasite    : {boyut}");
                        sb.AppendLine($"     Arayüz      : {obj["InterfaceType"]}");
                        sb.AppendLine($"     Seri No     : 
        { obj["SerialNumber"]?.ToString()?.Trim()}
                        "); 
                        sb.AppendLine($"     Durum       : {obj["Status"]}");
                        sb.AppendLine();
                    }
                }
                catch (Exception ex)
                {
                    sb.AppendLine($"  [HATA] Disk bilgisi alınamadı: {ex.Message}\n");
                }

                sb.AppendLine("============================================");
                sb.AppendLine("           RAPOR SONU");
                sb.AppendLine("============================================");

                // ─── NOT DEFTERİNE YAZ ────────────────────────────────── 
                string dosyaYolu = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    "donanim_bilgisi.txt");

                File.WriteAllText(dosyaYolu, sb.ToString(), Encoding.UTF8);

                Console.WriteLine(sb.ToString());
                Console.WriteLine($"\n✅ Bilgiler kaydedildi: {dosyaYolu}");
                Console.WriteLine("\nNot Defteri açılıyor...");

                // Not Defteri'ni aç 
                System.Diagnostics.Process.Start("notepad.exe", dosyaYolu);

                Console.WriteLine("\nÇıkmak için bir tuşa basın...");
                Console.ReadKey();
            }

            // ─── Yardımcı Metodlar ────────────────────────────────────── 

            static string GetArchitecture(string? code) => code switch
            {
                "0" => "x86",
                "1" => "MIPS",
                "2" => "Alpha",
                "3" => "PowerPC",
                "5" => "ARM",
                "6" => "ia64 (Itanium)",
                "9" => "x64",
                "12" => "ARM64",
                _ => $"Kod: {code}"
            };

            static string GetDdrType(string? code) => code switch
            {
                "20" => "DDR",
                "21" => "DDR2",
                "22" => "DDR2 FB-DIMM",
                "24" => "DDR3",
                "26" => "DDR4",
                "34" => "DDR5",
                _ => "?"
            };
        }
    }
    }
}
