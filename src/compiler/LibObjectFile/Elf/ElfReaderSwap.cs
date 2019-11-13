﻿using System.IO;

namespace LibObjectFile.Elf
{
    internal sealed class ElfReaderSwap : ElfReader<ElfDecoderSwap>
    {
        public ElfReaderSwap(ElfObjectFile elfObjectFile, Stream stream) : base(elfObjectFile, stream)
        {
        }
    }
}