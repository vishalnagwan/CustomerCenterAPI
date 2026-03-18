namespace Uniban.DemoiGlassData.Services.Test.Config {
    public static class Configuration {
        private static object isInitialized = false;

        public static void SetupAutoMap() {
            lock (isInitialized) {
                if ((bool)isInitialized) return;
                API.Config.Configuration.ConfigureMapper();
                isInitialized = true;
            }
        }
    }
}
