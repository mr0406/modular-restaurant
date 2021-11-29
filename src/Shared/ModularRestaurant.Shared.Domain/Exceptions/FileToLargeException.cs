using System;

namespace ModularRestaurant.Shared.Domain.Exceptions
{
    public class FileToLargeException : Exception
    {
        public readonly long FileSizeInBytes;
        public readonly long MaxSizeInBytes;
        
        public FileToLargeException(long fileSizeInBytes, long maxSizeInBytes)
            : base($"File is too large, File size: {fileSizeInBytes} bytes. Max file size: {maxSizeInBytes} bytes")
        {
            FileSizeInBytes = fileSizeInBytes;
            MaxSizeInBytes = maxSizeInBytes;
        }
    }
}