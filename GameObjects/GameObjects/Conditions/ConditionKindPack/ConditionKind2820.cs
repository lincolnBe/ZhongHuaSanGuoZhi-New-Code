﻿namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind2820 : ConditionKind
    {
        private int number = 0;

        public override bool CheckConditionKind(Architecture a)
        {
            foreach (Captive p in a.Captives)
            {
                if (p.CaptivePersonID == number)
                {
                    return true;
                }
            }
            return false;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.number = int.Parse(parameter);
            }
            catch
            {
            }
        }

    }
}

