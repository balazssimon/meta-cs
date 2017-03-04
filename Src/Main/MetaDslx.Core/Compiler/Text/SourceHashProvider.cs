using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetaDslx.Compiler.Text;
using System.IO;
using System.Security.Cryptography;

namespace MetaDslx.Compiler.Utilities
{
    internal class SourceHashProvider
    {
        internal static int GetHashSize(SourceHashAlgorithm checksumAlgorithm)
        {
            switch (checksumAlgorithm)
            {
                case SourceHashAlgorithm.Sha1:
                    return 20;
                case SourceHashAlgorithm.Sha256:
                    return 32;
                default:
                    return 0;
            }
        }

        internal static byte[] ComputeHash(SourceHashAlgorithm checksumAlgorithm, byte[] buffer, int offset, int count)
        {
            switch (checksumAlgorithm)
            {
                case SourceHashAlgorithm.Sha1:
                    using (var algorithm = new SHA1CryptoServiceProvider())
                    {
                        return algorithm.ComputeHash(buffer, offset, count);
                    }
                case SourceHashAlgorithm.Sha256:
                    using (var algorithm = new SHA256CryptoServiceProvider())
                    {
                        return algorithm.ComputeHash(buffer, offset, count);
                    }
                default:
                    return EmptyCollections.ByteArray;
            }
        }

        internal static byte[] ComputeHash(SourceHashAlgorithm checksumAlgorithm, Stream buffer)
        {
            switch (checksumAlgorithm)
            {
                case SourceHashAlgorithm.Sha1:
                    using (var algorithm = new SHA1CryptoServiceProvider())
                    {
                        return algorithm.ComputeHash(buffer);
                    }
                case SourceHashAlgorithm.Sha256:
                    using (var algorithm = new SHA256CryptoServiceProvider())
                    {
                        return algorithm.ComputeHash(buffer);
                    }
                default:
                    return EmptyCollections.ByteArray;
            }
        }
    }
}
