﻿using TanjiCore.Flazzy.IO;

namespace TanjiCore.Flazzy.ABC.AVM2.Instructions
{
    public class InitPropertyIns : ASInstruction
    {
        public ASMultiname PropertyName
        {
            get { return ABC.Pool.Multinames[PropertyNameIndex]; }
        }
        public int PropertyNameIndex { get; set; }

        public InitPropertyIns(ABCFile abc)
            : base(OPCode.InitProperty, abc)
        { }
        public InitPropertyIns(ABCFile abc, FlashReader input)
            : this(abc)
        {
            PropertyNameIndex = input.ReadInt30();
        }
        public InitPropertyIns(ABCFile abc, int propertyNameIndex)
            : this(abc)
        {
            PropertyNameIndex = propertyNameIndex;
        }

        public override int GetPopCount()
        {
            return (1 + ResolveMultinamePops(PropertyName) + 1);
        }
        public override void Execute(ASMachine machine)
        {
            object value = machine.Values.Pop();
            ResolveMultiname(machine, PropertyName);
            object obj = machine.Values.Pop();
        }

        protected override void WriteValuesTo(FlashWriter output)
        {
            output.WriteInt30(PropertyNameIndex);
        }
    }
}