﻿namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using GameObjects.PersonDetail;
    using System;


    internal class EventEffect270 : EventEffectKind
    {
        private int preferredType;

        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.BelongedFaction != null && person.LocationArchitecture != null && person.BelongedCaptive == null)
            {
                PersonGeneratorType type = person.Scenario.GameCommonData.AllPersonGeneratorTypes[preferredType] as PersonGeneratorType;
                person.LocationArchitecture.GenerateOfficer(type,true);
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.preferredType = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}