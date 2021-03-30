using System.Configuration;

namespace Application.Configurations.Commands.Edit
{
    public class ConfigurationEditor : IConfigurationEditor
    {
        public void EditCostBuild(int newValue)
        {
            SetSetting("BUILD_COST", newValue);
        }

        public void EditPricePerfomanceMultiplier(int newValue)
        {
            SetSetting("PRICE_PERFOMANCE_MULTIPLIER", newValue);
        }

        private void SetSetting(string key, int value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value.ToString();
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
