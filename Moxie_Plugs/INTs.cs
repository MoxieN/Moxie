using System;
using IL2CPU.API.Attribs;
using static Cosmos.Core.INTs;

namespace Moxie_Plugs
{
    [Plug(Target = typeof(Cosmos.Core.INTs))]
    public class INTs
    {
        public static void HandleException(uint aEIP, string aDescription, string aName, ref IRQContext ctx, uint lastKnownAddressValue = 0)
        {
            const string xHex = "0123456789ABCDEF";
            uint xPtr = ctx.EIP;

            unsafe
            {
                byte* xAddress = (byte*) 0xB8000;
                
                Console.Clear();
                
                PutErrorString(0, 0, "Moxie crashed!");
                PutErrorString(1, 0, "Please report the following error to the developer");
                PutErrorString(3, 0, $"Error: CPU Exception x{xHex[(int)((ctx.Interrupt >> 4) & 0xF)]}{xHex[(int)(ctx.Interrupt & 0xF)]}");
                
                if (lastKnownAddressValue != 0) {
                    PutErrorString(4, 0, "Last known address: 0x");

                    PutErrorChar(4, 22, xHex[(int)((lastKnownAddressValue >> 28) & 0xF)]);
                    PutErrorChar(4, 23, xHex[(int)((lastKnownAddressValue >> 24) & 0xF)]);
                    PutErrorChar(4, 24, xHex[(int)((lastKnownAddressValue >> 20) & 0xF)]);
                    PutErrorChar(4, 25, xHex[(int)((lastKnownAddressValue >> 16) & 0xF)]);
                    PutErrorChar(4, 26, xHex[(int)((lastKnownAddressValue >> 12) & 0xF)]);
                    PutErrorChar(4, 27, xHex[(int)((lastKnownAddressValue >> 8) & 0xF)]);
                    PutErrorChar(4, 28, xHex[(int)((lastKnownAddressValue >> 4) & 0xF)]);
                    PutErrorChar(4, 29, xHex[(int)(lastKnownAddressValue & 0xF)]);
                }
            }
            
            // Lock up
            while (true)
            {
                
            }
        }
        
        private static void PutErrorChar(int line, int col, char c) {
            unsafe
            {
                byte* xAddress = (byte*)0xB8000;

                xAddress += ((line * 80) + col) * 2;

                xAddress[0] = (byte)c;
                xAddress[1] = 0x0C;
            }
        }
        
        private static void PutErrorString(int line, int startCol, string error) {
            for (int i = 0; i < error.Length; i++) {
                PutErrorChar(line, startCol + i, error[i]);
            }
        }
    }
}
