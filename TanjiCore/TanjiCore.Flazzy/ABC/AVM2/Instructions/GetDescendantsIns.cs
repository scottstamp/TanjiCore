﻿using TanjiCore.Flazzy.IO;

namespace TanjiCore.Flazzy.ABC.AVM2.Instructions
{
    public class GetDescendantsIns : ASInstruction
    {
        public ASMultiname Descendant
        {
            get { return ABC.Pool.Multinames[DescendantIndex]; }
        }
        public int DescendantIndex { get; set; }

        public GetDescendantsIns(ABCFile abc)
            : base(OPCode.GetDescendants, abc)
        { }
        public GetDescendantsIns(ABCFile abc, FlashReader input)
            : this(abc)
        {
            DescendantIndex = input.ReadInt30();
        }

        public override int GetPopCount()
        {
            return (ResolveMultinamePops(Descendant) + 1);
        }
        public override int GetPushCount()
        {
            return 1;
        }
        public override void Execute(ASMachine machine)
        {
            ResolveMultiname(machine, Descendant);
            object obj = machine.Values.Pop();
            machine.Values.Push(null);
        }

        protected override void WriteValuesTo(FlashWriter output)
        {
            output.WriteInt30(DescendantIndex);
        }
    }
}