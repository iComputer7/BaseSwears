using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace BaseSwears {
    public class SwearDecoder: IDisposable {
        private StreamReader FileToDecode { get; set; }

        /// <summary>
        /// Creates a SwearEncoder.
        /// </summary>
        /// <param name="_filePath">Path of file to be encoded</param>
        public SwearDecoder(string _filePath) {
            //opening file
            FileToDecode = new StreamReader(File.Open(_filePath, FileMode.Open));
        }

        /// <summary>
        /// Decodes a file to binary.
        /// </summary>
        /// <param name="_outPath">Path to where the decoded file will be output</param>
        /// <returns>Output file size in bytes</returns>
        public long DecodeBinary(string _outPath) {
            //creating output file and converting
            long convertedBytes = 0;
            using (BinaryWriter outFile = new BinaryWriter(File.Open(_outPath, FileMode.Create))) {
                //reading input file line by line
                string curLine;
                long lineNo = 0;
                while ((curLine = FileToDecode.ReadLine()) != null) {
                    string[] curWords = curLine.Split(' ').Where(x => x != string.Empty).ToArray();

                    //should always have even number of words on a line
                    lineNo++;
                    if (curWords.Length % 2 != 0) 
                        throw new Exception($"Line {lineNo} doesn't contain an even number of words.");


                    //swear -> nybble
                    List<byte> buffer = new List<byte>();
                    for (int i = 0; i < curWords.Length; i += 2) {
                        //bottom 4 bits then top 4 bits
                        byte b = (byte)Array.IndexOf(SwearEncoder.SwearList, curWords[i]);
                        byte t = (byte)Array.IndexOf(SwearEncoder.SwearList, curWords[i + 1]);
                        buffer.Add((byte)(b | (t << 4)));
                        convertedBytes++;
                    }

                    //writing bytes to file
                    buffer.ForEach(x => outFile.Write(x));
                }
            }

            //done
            return convertedBytes;
        }

        public void Dispose() {
            FileToDecode.Dispose();
        }
    }
}
