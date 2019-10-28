using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RobotClient_Kuka_youBot_
{
    public static class TrueRandom
    {
        private static RNGCryptoServiceProvider Provider = new RNGCryptoServiceProvider();

        public static int GetRandomInt(int _Low, int _High)
        {
            byte[] Buffer = new byte[4];
            Provider.GetBytes(Buffer);
            uint Rnd = BitConverter.ToUInt32(Buffer, 0);
            Rnd = Rnd % (uint)(_High - _Low + 1);
            int Result = Convert.ToInt32(Rnd) + _Low;
            return Result;
        }

        public static int GetRandomInt()
        {
            byte[] Buffer = new byte[4];
            Provider.GetBytes(Buffer);
            return BitConverter.ToInt32(Buffer, 0);
        }

        public static double GetRandomDouble()
        {
            const ulong Precision = 1000000000000000;
            const double DPrecision = Precision;
            byte[] Buffer = new byte[sizeof(ulong)];
            Provider.GetBytes(Buffer);
            ulong Rnd = BitConverter.ToUInt64(Buffer, 0) % Precision;
            return Rnd / DPrecision;
        }
    }
}
