using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PawMapLoader.Res.PawPack.V1
{
    public class Unpacker
    {
        public static byte[] ExpectedTableHeaderStart =
        {
            0x5C,
            0x5C,
            0x70,
            0x6C
        };

        public static byte[] ExpectedTableHeaderEnd =
        {
            0x5C,
            0x5C
        };

        public static void Unpack(byte[] data)
        {
            List<UnpackableFile> unpackableFiles = new List<UnpackableFile>();
            
            byte[] pointerTableHeaderStart = new byte[4];
            byte[] pointerTableHeaderEnd = new byte[2];
            Buffer.BlockCopy(data, 0, pointerTableHeaderStart, 0, 4);
            Buffer.BlockCopy(data, 9, pointerTableHeaderEnd, 0, 2);
            if (
                !pointerTableHeaderStart.SequenceEqual(ExpectedTableHeaderStart) ||
                !pointerTableHeaderEnd.SequenceEqual(ExpectedTableHeaderEnd)
                ) throw new InvalidDataException($"File is invalid or corrupt! Throwing..." +
                                                 $"\nExpected: {ExpectedTableHeaderStart} .. {ExpectedTableHeaderEnd}" +
                                                 $"\nGot: {pointerTableHeaderStart} .. {pointerTableHeaderEnd}");
            
            int tablelen;
            byte[] tablelenbytes = new byte[4];
            Buffer.BlockCopy(data, 4, tablelenbytes, 0, 4);
            tablelen = BitConverter.ToInt32(tablelenbytes, 0);
            
            string[] tableData = new string[tablelen];
            string tempData = string.Empty;
            int tableIndex = 0;
            for (int i = 12; i < data.Length; i++)
            {
                if (i == data.Length-1) throw new InvalidDataException($"Hit end of file! Pointer table may be corrupt!");
                if (tableIndex > tablelen) break;
                if (data[i] == 0x5C && data[i+1] == 0x5C)
                {
                    if (tempData != string.Empty)
                        tableData[tableIndex] = tempData;
                    tableIndex++;
                    i++;
                    continue;
                }
                tempData += (char)data[i];
            }
        }

        public class UnpackableFile
        {
            public byte[] data;
            public string Filepath;
            public int Length;
            public int Offset;
        }
    }
}