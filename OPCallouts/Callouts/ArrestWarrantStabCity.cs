using Rage;
using LSPD_First_Response.Mod.API;
using LSPD_First_Response.Mod.Callouts;
using LSPD_First_Response.Engine.Scripting.Entities;

namespace OPCallouts.Callouts
{
    [CalloutInfo("ArrestWarrantStabCity", CalloutProbability.Medium)]
    public class ArrestWarrantStabCity : Callout
    {
        private Ped suspect;
        private Vector3 spawnPoint;
        private Blip suspectBlip;

        public override bool OnBeforeCalloutDisplayed()
        {
            spawnPoint = new Vector3(91.10989f, 3749.146f, 40.77256f);

            ShowCalloutAreaBlipBeforeAccepting(spawnPoint, 30f);
            AddMinimumDistanceCheck(100f, spawnPoint);

            CalloutMessage = "Arrest Warrant";
            CalloutPosition = spawnPoint;

            return base.OnBeforeCalloutDisplayed();
        }
        public override bool OnCalloutAccepted()
        {
            suspect = new Ped(new Model("a_m_m_beach_01"), spawnPoint, 0f);
            suspect.IsPersistent = true;
            suspect.BlockPermanentEvents = true;

            suspectBlip = suspect.AttachBlip();
            suspectBlip.IsFriendly = false;

            suspect.Tasks.Wander();

            return base.OnCalloutAccepted();
        }
        public override void Process()
        {
            base.Process();
            if (suspect.IsDead)
            {
                End();
            }
        }
        public override void End()
        {
            base.End();
            if(suspect.Exists()) { suspect.Dismiss(); }
            if (suspectBlip.Exists()) { suspectBlip.Delete(); }
        }
    }
}
