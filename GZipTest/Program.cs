namespace GZipTest
{
    enum Method
    {
        Compress,
        Decompress
    }

    class Program
    {
        static void Main(string[] args)
        {
            var validator = new Validator();
            var messageManager = new MessageManager(validator);

            if (validator.ValidateInput(args))
            {
                var compressor = new Compressor();
                if (validator.Method == Method.Compress)
                {
                    compressor.Compress(validator.Source, validator.Target);
                }
                else if (validator.Method == Method.Decompress)
                {
                    compressor.Decompress(validator.Source, validator.Target);
                }

                messageManager.Success();
            }
            else
            {
                messageManager.WriteWarning();
            }
        }
    }
}
