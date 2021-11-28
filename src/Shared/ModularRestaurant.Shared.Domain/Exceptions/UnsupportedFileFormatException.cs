using System;
using System.Collections.Generic;

namespace ModularRestaurant.Shared.Domain.Exceptions
{
    public class UnsupportedFileFormatException : Exception
    {
        public string FileFormat { get; }
        public List<string> SupportedFormats { get; }
        
        public UnsupportedFileFormatException(string fileFormat, List<string> supportedFormats)
            : base($"File format: {fileFormat} is unsupported. " +
                   $"Supported file formats: {string.Join(", ", supportedFormats)}")
        {
            FileFormat = fileFormat;
            SupportedFormats = supportedFormats;
        }
    }
}