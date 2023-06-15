namespace BeehiveManagementSystem
{
    // HoneyVault is a static class that keeps track of the honey and nectar in the hive.Bees use the ConsumeHoney method, which checks if there’s enough honey to do their jobs, and if so subtracts the amount requested.
    internal static class HoneyVault
    {
        public const float NECTAR_CONVERSION_RATIO = 0.9f; //0.19f;
        public const float LOW_LEVEL_WARNING = 10f;

        private static float honey = 250f;
        private static float nectar = 1000f;

        // The CollectNectar method is called by the NectarCollector bee each shift.It takes a parameter, amount. If amount is greater than zero, it adds it to the nectar field. 
        public static void CollectNectar(float amount)
        {
            if (amount > 0) nectar += amount;
        }

        // The ConvertNectarToHoney method converts nectar to honey.It takes a float parameter called amount, subtracts that amount from its nectar field, and adds amount × NECTAR_CONVERSION_RATIO to the honey field. (If the amount passed to the method is greater than the nectar left in the vault, it converts all of the remaining nectar.)
        public static void ConverNectarToHoney(float nectarToConvert)
        {
            if (nectarToConvert > nectar) nectarToConvert = nectar;

            nectar -= nectarToConvert;

            honey += nectarToConvert * NECTAR_CONVERSION_RATIO;
        }

        // The ConsumeHoney method is how the bees use honey to do their jobs.It takes a parameter, amount. If honey is greater than or equal to amount, it subtracts amount from honey and returns true; otherwise it returns false.
        public static bool ConsumeHoney(float amount)
        {
            if (honey >= amount)
            {
                honey -= amount;
                return true;
            }

            return false;
        }


        // The StatusReport property only has a get accessor that returns a string with separate lines with the amount of honey and the amount of nectar in the vault. If the honey is below LOW_LEVEL_WARNING, it adds a warning ("LOW HONEY - ADD A HONEY MANUFACTURER"). It does the same for the nectar field.
        public static string StatusReport
        {
            get
            {
                return $"Honey: {honey:0.0} Nectar:  {nectar:0.0}" +
                    (honey < LOW_LEVEL_WARNING ? "\nLOW HONEY - ADD A HONEY MANUFACTURER" : "") +
                    (nectar < LOW_LEVEL_WARNING ? "\nLOW NECTAR - ADD A NECTAR COLLECTOR" : "");
            }
        }

    }
}