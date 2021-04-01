using System.Configuration;

namespace Domain.Configurations
{
    public class ConfigurationCosts : IConfigurationCosts
    {
        public int BuildCost => GetValueSetting("BUILD_COST");
        public int PricePerfomanceMultiplier => GetValueSetting("PRICE_PERFOMANCE_MULTIPLIER");

        public int GetValueSetting(string name)
        {
            return int.Parse(ConfigurationManager.AppSettings[name]);
        }
    }
}