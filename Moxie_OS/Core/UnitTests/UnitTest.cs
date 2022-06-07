using System;

namespace Moxie.Core.UnitTests
{
    public class UnitTest
    {
        private bool isVital = false;
        private string name = "Unnamed";
        
        public UnitTest(bool isVital, string name)
        {
            this.isVital = isVital;
            this.name = name;
        }

        public virtual bool Test() { return true; }

        public virtual void Execute()
        {
            if(Test())
                Kernel.Log($"{name}'s unit tests passed.", type: 2);
            else
            {
                if(!isVital)
                    Kernel.Log($"{name}'s unit tests didn't passed.", type: 3);
                else
                {
                    Kernel.Log($"{name}'s unit tests didn't passed and is vital. Can't keep up.", type: 3);
                    Console.WriteLine("Press 's' to shutdown, Press another key to reboot");

                    var choice = Console.ReadKey();
                    
                    if(choice.KeyChar == 's')
                        Cosmos.System.Power.Shutdown();
                    else
                        Cosmos.HAL.Power.ACPIReboot();
                }
            }
        }
    }
}