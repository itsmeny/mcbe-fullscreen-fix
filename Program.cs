using Microsoft.Win32;
using System;

namespace mcbe_fullscreen_fix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string keyPath = @"SOFTWARE\Policies\Microsoft\Windows\EdgeUI";
            const string valueName = "AllowEdgeSwipe";
            try
            {
                using (RegistryKey baseKey = Registry.LocalMachine)
                {
                    using (RegistryKey edgeUIKey = baseKey.OpenSubKey(keyPath, true))
                    {
                        if (edgeUIKey == null)
                        {
                            using (RegistryKey newKey = baseKey.CreateSubKey(keyPath))
                            {
                                newKey.SetValue(valueName, 0, RegistryValueKind.DWord);
                            }
                        }
                        else
                        {
                            edgeUIKey.SetValue(valueName, 0, RegistryValueKind.DWord);
                        }
                        Console.WriteLine("Successfully Set AllowEdgeSwipe to 0");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
