using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        byte[] pdf = File.ReadAllBytes("file.pdf");
        byte[] txt = File.ReadAllBytes("file.txt");
        byte[] apk = File.ReadAllBytes("file.apk");
        byte[] exe = File.ReadAllBytes("file.exe");
        
        byte[] data = Combine(pdf, txt, apk, exe);
        
        string outFile = "output.exe";
        
        File.WriteAllBytes(outFile, data);
        
        Process.Start(outFile);
    }
    
    static byte[] Combine(params byte[][] arrays)
    {
        int totalLength = arrays.Sum(a => a.Length);
        byte[] result = new byte[totalLength];
        int currentIndex = 0;
        foreach (byte[] array in arrays)
        {
            Buffer.BlockCopy(array, 0, result, currentIndex, array.Length);
            currentIndex += array.Length;
        }
        return result;
    }
}
