﻿using TanjiCore.Flazzy.IO;

namespace TanjiCore.Flazzy.ABC.AVM2.Instructions
{
    public class SetSlotIns : ASInstruction
    {
        public int SlotIndex { get; set; }

        public SetSlotIns()
            : base(OPCode.SetSlot)
        { }
        public SetSlotIns(FlashReader input)
            : this()
        {
            SlotIndex = input.ReadInt30();
        }

        public override int GetPopCount()
        {
            return 2;
        }
        public override void Execute(ASMachine machine)
        {
            object value = machine.Values.Pop();
            object obj = machine.Values.Pop();
        }

        protected override void WriteValuesTo(FlashWriter output)
        {
            output.WriteInt30(SlotIndex);
        }
    }
}