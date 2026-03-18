using AutoMapper;
using AutoMapper.EquivalencyExpression;
using DalModel = Uniban.DemoiGlassData.Data;
using BlModel = Uniban.DemoiGlassData.Domain;

namespace Uniban.DemoiGlassData.API.Config
{
    public static class Configuration
    {
        private static bool IsInitialized { get; set; }

        public static void ConfigureMapper()
        {
            if (IsInitialized)
            {
                return;
            }

            IsInitialized = true;
            Mapper.Initialize(cfg =>
            {
                cfg.AddCollectionMappers();
                // Dal to Bl Model related
                //cfg.CreateMap<DalModel.viewGpXmlGetInvoices, BlModel.ViewGpXmlGetInvoices>();
            });

        }

    }
}
