﻿namespace LibObjectFile.Elf
{
    public struct ElfSymbol
    {
        public ulong Value { get; set; }

        public ulong Size { get; set; }
        
        public ElfSymbolType Type { get; set; }

        public ElfSymbolBind Bind { get; set; }

        public ElfSymbolVisibility Visibility { get; set; }

        public ElfSectionLink Section { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{nameof(Value)}: 0x{Value:X16}, {nameof(Size)}: {Size:#####}, {nameof(Type)}: {Type}, {nameof(Bind)}: {Bind}, {nameof(Visibility)}: {Visibility}, {nameof(Section)}: {Section}, {nameof(Name)}: {Name}";
        }
    }
}