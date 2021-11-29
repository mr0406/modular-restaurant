using System;

namespace ModularRestaurant.Shared.Domain.Exceptions
{
    public class FileTooLargeException : Exception
    {
        public readonly long FileSizeInBytes;
        public readonly long MaxSizeInBytes;
        
        public FileTooLargeException(long fileSizeInBytes, long maxSizeInBytes)
            : base($"File is too large, file size: {fileSizeInBytes} bytes. Max file size: {maxSizeInBytes} bytes")
        {
            FileSizeInBytes = fileSizeInBytes;
            MaxSizeInBytes = maxSizeInBytes;
        }
    }
}