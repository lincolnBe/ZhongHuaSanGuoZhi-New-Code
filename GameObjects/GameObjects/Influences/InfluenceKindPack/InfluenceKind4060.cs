﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind4060 : InfluenceKind
    {
        private int radius = 0;

        public override void ApplyInfluenceKind(Person person)
        {
            if (person.LocationTroop != null)
            {
                person.LocationTroop.StuntAttackRadius += this.radius;
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.radius = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Person person)
        {
            if (person.LocationTroop != null)
            {
                person.LocationTroop.StuntAttackRadius -= this.radius;
            }
        }
    }
}

