using System;
using System.IO;

namespace BaseSwears {
    public class SwearEncoder: IDisposable {
        /// <summary>
        /// Each encoded value ordered inversely by strength (at least to my American English knowledge)
        /// </summary>
        public static readonly string[] SwearList = {
            "fuck",     //0x0
            "cock",     //0x1
            "dick",     //0x2
            "shit",     //0x3
            "asshole",  //0x4
            "damn",     //0x5
            "bitch",    //0x6
            "bastard",  //0x7
            "piss",     //0x8
            "ass",      //0x9
            "crap",     //0xa
            "hell",     //0xb
            "frick",    //0xc
            "darn",     //0xd
            "heck",     //0xe
            "crud",     //0xf 
        };

        private BinaryReader FileToEncode { get; set; }

        /// <summary>
        /// Creates a SwearEncoder.
        /// </summary>
        /// <param name="_filePath">Path of file to be encoded</param>
        public SwearEncoder(string _filePath) {
            //opening file
            FileToEncode = new BinaryReader(File.Open(_filePath, FileMode.Open));
        }

        /// <summary>
        /// Encodes a file to binary.
        /// </summary>
        /// <param name="_outPath">Path to where the encoded file will be output</param>
        /// <returns>Output file size in bytes</returns>
        public long EncodeBinary(string _outPath) {
            //creating output file and converting
            long convertedBytes = 0;
            using (StreamWriter outFile = new StreamWriter(File.Open(_outPath, FileMode.Create))) {
                while (convertedBytes < FileToEncode.BaseStream.Length) {
                    byte curByte = FileToEncode.ReadByte();

                    //doing bottom 4 bits then top 4 bits
                    byte nybble = (byte)(curByte & 0xf);
                    outFile.Write(SwearList[nybble] + " ");
                    nybble = (byte)((curByte & 0xf0) >> 4);
                    outFile.Write(SwearList[nybble] + " ");

                    convertedBytes++;

                    //newline every 8 bytes
                    if (convertedBytes % 8 == 0)
                        outFile.WriteLine();
                }
            }

            //done
            return convertedBytes;
        }

        public void Dispose() {
            FileToEncode.Dispose();
        }
    }
}
