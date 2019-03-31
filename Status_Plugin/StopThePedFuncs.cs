using StopThePed;

namespace Officer_Status_Plugin
{
    internal static class StopThePedFuncs
    {
        internal static void RequestTowTruck()
        {
            Controls.requestTowFromVocalDispatch();
        }
    }
}
