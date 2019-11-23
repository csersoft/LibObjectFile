﻿// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license.
// See the license.txt file in the project root for more information.

using LibObjectFile.Elf;
using LibObjectFile.Utils;

namespace LibObjectFile.Ar
{
    /// <summary>
    /// An ELF file entry.
    /// </summary>
    public sealed class ArElfFile : ArFile
    {
        public ArElfFile()
        {
        }

        public ArElfFile(ElfObjectFile elfObjectFile)
        {
            ElfObjectFile = elfObjectFile;
        }
        
        /// <summary>
        /// Gets or sets the ELF object file.
        /// </summary>
        public ElfObjectFile ElfObjectFile { get; set; }

        protected override ulong GetSizeAuto()
        {
            if (ElfObjectFile != null)
            {
                if (ElfObjectFile.TryUpdateLayout(new DiagnosticBag()))
                {
                    return ElfObjectFile.Layout.TotalSize;
                }
            }
            return 0;
        }

        protected override void Read(ArArchiveFileReader reader)
        {
            var startPosition = reader.Stream.Position;
            var endPosition = startPosition + (long) Size;
            ElfObjectFile = ElfObjectFile.Read(new SliceStream(reader.Stream, reader.Stream.Position, (long)Size));
            SizeKind = ValueKind.Auto;
            reader.Stream.Position = endPosition;
        }

        protected override void Write(ArArchiveFileWriter writer)
        {
            if (ElfObjectFile != null)
            {
                ElfObjectFile.TryWrite(writer.Stream, out var diagnostics);
                diagnostics.CopyTo(writer.Diagnostics);
            }
        }
    }
}