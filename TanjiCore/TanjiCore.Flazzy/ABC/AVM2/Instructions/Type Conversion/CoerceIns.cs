﻿using TanjiCore.Flazzy.IO;

namespace TanjiCore.Flazzy.ABC.AVM2.Instructions
{
    public class CoerceIns : ASInstruction
    {
        public ASMultiname TypeName
        {
            get { return ABC.Pool.Multinames[TypeNameIndex]; }
        }
        public int TypeNameIndex { get; set; }

        public CoerceIns(ABCFile abc)
            : base(OPCode.Coerce, abc)
        { }
        public CoerceIns(ABCFile abc, FlashReader input)
            : this(abc)
        {
            TypeNameIndex = input.ReadInt30();
        }

        public override int GetPopCount()
        {
            return 1;
        }
        public override int GetPushCount()
        {
            return 1;
        }
        public override void Execute(ASMachine machine)
        {
            object value = machine.Values.Pop();
            machine.Values.Push(null);
        }

        protected override void WriteValuesTo(FlashWriter output)
        {
            output.WriteInt30(TypeNameIndex);
        }
    }
}