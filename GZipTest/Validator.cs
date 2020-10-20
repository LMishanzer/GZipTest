using System;
using System.IO;

namespace GZipTest
{
    /// <summary>
    /// Validates input and store essential data
    /// </summary>
    class Validator
    {
        #region Properties

        /// <summary>
        /// User typed --help
        /// </summary>
        public bool IsHelpRequired { get; set; }

        /// <summary>
        /// Is number of parameters correct
        /// </summary>
        public bool IsNumberOfParameters { get; private set; }

        /// <summary>
        /// True if compression method is either "compress" or "decompress"
        /// </summary>
        public bool IsMethod { get; private set; }

        /// <summary>
        /// Is source file valid
        /// </summary>
        public bool IsSourceFile { get; private set; }

        /// <summary>
        /// Is target file valid
        /// </summary>
        public bool IsTargetFile { get; private set; }

        /// <summary>
        /// Compression method from the input
        /// </summary>
        public Method Method { get; private set; }

        /// <summary>
        /// Source file
        /// </summary>
        public FileInfo Source { get; private set; }

        /// <summary>
        /// Target file
        /// </summary>
        public FileInfo Target { get; private set; }

        #endregion

        public Validator() { }

        /// <summary>
        /// Validates input (--help is considered as incorrect input)
        /// </summary>
        /// <param name="args">Program arguments:
        /// compression method, source file and target file</param>
        /// <returns>Is input valid</returns>
        public bool ValidateInput(string[] args)
        {
            // Check if help is required
            IsHelpRequired = IsHelp(args);
            if (IsHelpRequired)
                return false;

            // Check number of input parameters
            IsNumberOfParameters = IsParametersNumberValid(args);
            if (!IsNumberOfParameters)
                return false;

            // Check if compression method is correct
            IsMethod = IsMethodValid(args[0]);
            if (!IsMethod)
                return false;

            // Check if source file exists
            IsSourceFile = IsSourceFileValid(args[1]);
            if (!IsSourceFile)
                return false;

            // Check if target file is valid
            IsTargetFile = IsTargetFileValid(args[2]);
            if (!IsTargetFile)
                return false;

            return true;
        }

        #region Checks

        private bool IsHelp(string[] args)
        {
            if (args.Length == 1 && args[0] == "--help")
            {
                return true;
            }

            return false;
        }
        
        private bool IsParametersNumberValid(string[] args)
        {
            return args.Length == 3;
        }

        private bool IsMethodValid(string method)
        {
            if (method == "compress")
            {
                Method = Method.Compress;
                return true;
            }

            if (method == "decompress")
            {
                Method = Method.Decompress;
                return true;
            }

            return false;
        }

        private bool IsSourceFileValid(string sourcePath)
        {
            try
            {
                Source = new FileInfo(sourcePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool IsTargetFileValid(string targetFile)
        {
            try
            {
                Target = new FileInfo(targetFile);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
