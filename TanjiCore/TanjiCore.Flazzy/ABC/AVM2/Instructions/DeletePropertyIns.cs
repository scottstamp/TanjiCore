﻿using TanjiCore.Flazzy.IO;

namespace TanjiCore.Flazzy.ABC.AVM2.Instructions
{
    public class DeletePropertyIns : ASInstruction
    {
        public ASMultiname PropertyName
        {
            get { return ABC.Pool.Multinames[PropertyNameIndex]; }
        }
        public int PropertyNameIndex { get; set; }

        public DeletePropertyIns(ABCFile abc)
            : base(OPCode.DeleteProperty, abc)
        { }
        public DeletePropertyIns(ABCFile abc, FlashReader input)
            : this(abc)
        {
            PropertyNameIndex = input.ReadInt30();
        }

        public override int GetPopCount()
        {
            return (ResolveMultinamePops(PropertyName) + 1);
        }
        public override int GetPushCount()
        {
            return 1;
        }
        public override void Execute(ASMachine machine)
        {
            ResolveMultiname(machine, PropertyName);
            object obj = machine.Values.Pop();
            machine.Values.Push(null);
        }

        protected override void WriteValuesTo(FlashWriter output)
        {
            output.WriteInt30(PropertyNameIndex);
        }
    }
}