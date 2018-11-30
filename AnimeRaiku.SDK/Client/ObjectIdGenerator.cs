using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Text;
using System.Threading;

namespace AnimeRaiku.SDK.Client
{
    internal class ObjectIdGenerator
    {
        private static readonly DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static int __staticIncrement = (new Random()).Next();

        private static readonly int __staticMachine = (GetMachineHash() + GetAppDomainId()) & 0x00ffffff;
        private static readonly short __staticPid = GetPid();


        public static string GenerateNewId()
        {
            int timestamp = GetTimestampFromDateTime(DateTime.Now);
            int increment = Interlocked.Increment(ref __staticIncrement) & 0x00ffffff; // only use low order 3 bytes
            var pid = __staticPid;
            var machine = __staticMachine;

            var _a = timestamp;
            var _b = (machine << 8) | (((int)pid >> 8) & 0xff);
            var _c = ((int)pid << 24) | increment;

            return Generate(_a, _b, _c);// new ObjectId(timestamp, __staticMachine, __staticPid, increment);
        }

        private static int GetTimestampFromDateTime(DateTime timestamp)
        {
            var secondsSinceEpoch = (long)Math.Floor((ToUniversalTime(timestamp) - unixEpoch).TotalSeconds);
            if (secondsSinceEpoch < int.MinValue || secondsSinceEpoch > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException("timestamp");
            }
            return (int)secondsSinceEpoch;
        }

        private static DateTime ToUniversalTime(DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                return DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc);
            }
            else if (dateTime == DateTime.MaxValue)
            {
                return DateTime.SpecifyKind(DateTime.MaxValue, DateTimeKind.Utc);
            }
            else
            {
                return dateTime.ToUniversalTime();
            }
        }

        private static string Generate(int _a, int _b, int _c)
        {
            var c = new char[24];
            c[0] = ToHexChar((_a >> 28) & 0x0f);
            c[1] = ToHexChar((_a >> 24) & 0x0f);
            c[2] = ToHexChar((_a >> 20) & 0x0f);
            c[3] = ToHexChar((_a >> 16) & 0x0f);
            c[4] = ToHexChar((_a >> 12) & 0x0f);
            c[5] = ToHexChar((_a >> 8) & 0x0f);
            c[6] = ToHexChar((_a >> 4) & 0x0f);
            c[7] = ToHexChar(_a & 0x0f);
            c[8] = ToHexChar((_b >> 28) & 0x0f);
            c[9] = ToHexChar((_b >> 24) & 0x0f);
            c[10] = ToHexChar((_b >> 20) & 0x0f);
            c[11] = ToHexChar((_b >> 16) & 0x0f);
            c[12] = ToHexChar((_b >> 12) & 0x0f);
            c[13] = ToHexChar((_b >> 8) & 0x0f);
            c[14] = ToHexChar((_b >> 4) & 0x0f);
            c[15] = ToHexChar(_b & 0x0f);
            c[16] = ToHexChar((_c >> 28) & 0x0f);
            c[17] = ToHexChar((_c >> 24) & 0x0f);
            c[18] = ToHexChar((_c >> 20) & 0x0f);
            c[19] = ToHexChar((_c >> 16) & 0x0f);
            c[20] = ToHexChar((_c >> 12) & 0x0f);
            c[21] = ToHexChar((_c >> 8) & 0x0f);
            c[22] = ToHexChar((_c >> 4) & 0x0f);
            c[23] = ToHexChar(_c & 0x0f);
            return new string(c);
        }

        private static char ToHexChar(int value)
        {
            return (char)(value + (value < 10 ? '0' : 'a' - 10));
        }

        private static int GetMachineHash()
        {
            // use instead of Dns.HostName so it will work offline
            var machineName = GetMachineName();
            return 0x00ffffff & machineName.GetHashCode(); // use first 3 bytes of hash
        }

        private static string GetMachineName()
        {
            return Environment.MachineName;
        }

        private static int GetAppDomainId()
        {
            return 1;
        }

        private static short GetPid()
        {
            try
            {
                return (short)GetCurrentProcessId(); // use low order two bytes only
            }
            catch (SecurityException)
            {
                return 0;
            }
        }

        private static int GetCurrentProcessId()
        {
            return Process.GetCurrentProcess().Id;
        }
    }
}
