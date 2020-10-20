using System;

namespace GZipTest
{
    /// <summary>
    /// Writes messages using Validator
    /// </summary>
    class MessageManager
    {
        private readonly Validator _validator;

        public MessageManager(Validator validator)
        {
            _validator = validator;
        }

        /// <summary>
        /// Writes necessary warnings
        /// </summary>
        public void WriteWarning()
        {
            if (_validator.IsHelpRequired)
                PrintHelp();
            else if (!_validator.IsNumberOfParameters)
                Console.WriteLine(Messages.Number);
            else if (!_validator.IsMethod)
                Console.WriteLine(Messages.Method);
            else if(!_validator.IsSourceFile)
                Console.WriteLine(Messages.Source);
            else if (!_validator.IsTargetFile)
                Console.WriteLine(Messages.Target);
        }

        /// <summary>
        /// Writes info about compression
        /// </summary>
        public void Success()
        {
            if (_validator.Method == Method.Compress)
                Console.WriteLine(Messages.SuccessCompression, 
                    _validator.Source.Name, _validator.Source.Length.ToString(), 
                    _validator.Target.Length.ToString());

            else if (_validator.Method == Method.Decompress)
                Console.WriteLine(Messages.SuccessDecompression, 
                    _validator.Source.Name, _validator.Target.Name);
        }

        private void PrintHelp()
        {
            Console.WriteLine(Messages.HelpMessage, '\n');
        }
    }
}
