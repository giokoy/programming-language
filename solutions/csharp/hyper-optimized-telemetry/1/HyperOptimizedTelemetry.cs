using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];

        switch (reading)
        {
            case >= 4_294_967_296L and <= 9_223_372_036_854_775_807L:
                buffer[0] = 256 - 8; // long (signed)
                BitConverter.GetBytes(reading).CopyTo(buffer, 1);
                break;

            case >= 2_147_483_648L and <= 4_294_967_295L:
                buffer[0] = 4; // uint (unsigned)
                BitConverter.GetBytes((uint)reading).CopyTo(buffer, 1);
                break;

            case >= 65_536L and <= 2_147_483_647L:
                buffer[0] = 256 - 4; // int (signed)
                BitConverter.GetBytes((int)reading).CopyTo(buffer, 1);
                break;

            case >= 0L and <= 65_535L:
                buffer[0] = 2; // ushort (unsigned)
                BitConverter.GetBytes((ushort)reading).CopyTo(buffer, 1);
                break;

            case >= -32_768L and <= -1L:
                buffer[0] = 256 - 2; // short (signed)
                BitConverter.GetBytes((short)reading).CopyTo(buffer, 1);
                break;

            case >= -2_147_483_648L and <= -32_769L:
                buffer[0] = 256 - 4; // int (signed)
                BitConverter.GetBytes((int)reading).CopyTo(buffer, 1);
                break;

            default:
                buffer[0] = 256 - 8; // long (signed: -9_223_372_036_854_775_808 a -2_147_483_649)
                BitConverter.GetBytes(reading).CopyTo(buffer, 1);
                break;
        }

        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        return buffer[0] switch
        {
            256 - 8 => BitConverter.ToInt64(buffer, 1),
            4       => BitConverter.ToUInt32(buffer, 1),
            256 - 4 => BitConverter.ToInt32(buffer, 1),
            2       => BitConverter.ToUInt16(buffer, 1),
            256 - 2 => BitConverter.ToInt16(buffer, 1),
            _       => 0L
        };
    }
}