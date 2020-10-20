using System.IO;
using System.IO.Compression;

namespace GZipTest
{
    /// <summary>
    /// Use for compress or decompress files
    /// </summary>
    class Compressor
    {
        /// <summary>
        /// Compresses file
        /// </summary>
        /// <param name="fileToCompress">Configurations of file to compress</param>
        /// <param name="targetFile">Configurations of target file</param>
        public void Compress(FileInfo fileToCompress, FileInfo targetFile)
        {
            using FileStream originalFileStream = fileToCompress.OpenRead();
            if ((File.GetAttributes(fileToCompress.FullName) &
                 FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
            {
                using FileStream compressedFileStream = targetFile.Create();
                using GZipStream compressionStream = 
                    new GZipStream(compressedFileStream, CompressionMode.Compress);

                originalFileStream.CopyTo(compressionStream);
            }
        }

        /// <summary>
        /// Decompresses compressed files
        /// </summary>
        /// <param name="fileToDecompress">Configurations of file to decompress</param>
        /// <param name="targetFile">Configurations of target file</param>
        public void Decompress(FileInfo fileToDecompress, FileInfo targetFile)
        {
            using FileStream originalFileStream = fileToDecompress.OpenRead();
            using FileStream decompressedFileStream = targetFile.Create();
            using GZipStream decompressionStream = 
                new GZipStream(originalFileStream, CompressionMode.Decompress);

            decompressionStream.CopyTo(decompressedFileStream);
        }
    }
}
