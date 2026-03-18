using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using BLModel = Uniban.DemoiGlassData.Domain;
using Xunit;
using Uniban.DemoiGlassData.Model;
using Uniban.DemoiGlassData.Repositories.Abstractions;

namespace Uniban.DemoiGlassData.Services.Test
{
    public class GpXmlGenBusinessLogicShould
    {
        public GpXmlGenBusinessLogicShould()
        {
            Config.Configuration.SetupAutoMap();
        }


        [Fact]
        public void GetInvoices()
        {
            List<int> goodStatus = new List<int>() { 10, 3, 8, 4, 5, 9 }; // by default we have remove status 1 so that we can have an "invalid" status check that will return no result
            Mock<IInvoiceRepository> invoiceRepository = new Mock<IInvoiceRepository>();
            invoiceRepository.Setup(x => x.GetGpXmlInvoices(It.IsIn<int>(goodStatus), It.IsAny<DateTime>())).Returns(new List<BLModel.ViewGpXmlGetInvoices>() {
                new BLModel.ViewGpXmlGetInvoices() {
                    InvoiceId = 1,
                    WorkFileId = 1,
                    Kilometers = "0"
                },
                new BLModel.ViewGpXmlGetInvoices() {
                    InvoiceId = 2,
                    WorkFileId = 2,
                    Kilometers = "0"
                },
                new BLModel.ViewGpXmlGetInvoices() {
                    InvoiceId = 3,
                    WorkFileId = 3,
                    Kilometers = "0"
                }
            });

            GpXmlGenBusinessLogic logic = new GpXmlGenBusinessLogic(invoiceRepository.Object);


            // check all available status
            // New Status
            List<IGPXmlInvoiceModel> result = logic.GetInvoices("0", DateTime.Now);
            Assert.True(result != null, "result should not be null for status 0");
            Assert.True(result.Count() == 3, "result Count should be 3 for status 0");

            // Closed Status
            result = logic.GetInvoices("Z", DateTime.Now);
            Assert.True(result != null, "result should not be null for status Z");
            Assert.True(result.Count() == 3, "result Count should be 3 for status Z");

            // Faxed Status
            result = logic.GetInvoices("F", DateTime.Now);
            Assert.True(result != null, "result should not be null for status F");
            Assert.True(result.Count() == 3, "result Count should be 3 for status F");

            // Paid Status
            result = logic.GetInvoices("K", DateTime.Now);
            Assert.True(result != null, "result should not be null for status K");
            Assert.True(result.Count() == 3, "result Count should be 3 for status K");

            // Invoiced Status
            result = logic.GetInvoices("M", DateTime.Now);
            Assert.True(result != null, "result should not be null for status M");
            Assert.True(result.Count() == 3, "result Count should be 3 for status M");

            // In_Progress Status
            result = logic.GetInvoices("S", DateTime.Now);
            Assert.True(result != null, "result should not be null for status S");
            Assert.True(result.Count() == 3, "result Count should be 3 for status S");

            // Rejected Status
            result = logic.GetInvoices("J", DateTime.Now);
            Assert.True(result == null, "result should be null for Status J");

            // 2. check with invalid status
            result = logic.GetInvoices("10", DateTime.Now);
            Assert.True(result == null, "Result should be null for invalid status 10");
        }

        [Fact]
        public void GetInvoiceByWorkFileIdList_ResultAvailable()
        {
            Mock<IInvoiceRepository> invoiceRepository = new Mock<IInvoiceRepository>();
            invoiceRepository.Setup(x => x.GetGpXmlInvoices(It.IsAny<List<int>>())).Returns(new List<BLModel.ViewGpXmlGetInvoices>() {
                new BLModel.ViewGpXmlGetInvoices() {
                    WorkFileId = 1,
                    InvoiceId = 1,
                    JOBNBR = 101001,
                    PartCode = "aaaaa-1"
                }, new BLModel.ViewGpXmlGetInvoices() {
                    WorkFileId = 1,
                    InvoiceId = 1,
                    JOBNBR = 101001,
                    PartCode = "aaaaa-2"
                },
                new BLModel.ViewGpXmlGetInvoices() {
                    WorkFileId = 2,
                    InvoiceId = 2
                }
            });

            GpXmlGenBusinessLogic logic = new GpXmlGenBusinessLogic(invoiceRepository.Object);
            var result = logic.GetInvoiceByWorkFileIdList(new List<int>());

            Assert.True(result != null, "Result should not be null");
            Assert.True(result.Count == 2, $"Result count should be 2 instead of : {result.Count}");


            // Validate 1 items to have proper data (make sure mapping was done properly)
            // retrieve workfile id : 1
            var item = result.FirstOrDefault(x => x.workfileId == 1);

            Assert.True(item != null, "item should not be null");
            Assert.True(item.GC_JOBNBR == 101001, $"Expected Job number: 101001 we got : {item.GC_JOBNBR}");
            Assert.True(item.Details.Count == 2, $"Expected details count of 2 we got: {item.Details.Count}");
            Assert.True(item.Details.Any(x => x.GD_PARTIDENT == "aaaaa-1"), $"Product list should contain aaaaa-1");
            Assert.True(item.Details.Any(x => x.GD_PARTIDENT == "aaaaa-2"), $"Product list should contain aaaaa-2");
        }

        [Fact]
        public void GetInvoiceByWorkFileIdList_NoResultAvailable()
        {
            Mock<IInvoiceRepository> invoiceRepository = new Mock<IInvoiceRepository>();
            invoiceRepository.Setup(x => x.GetGpXmlInvoices(It.IsAny<List<int>>())).Returns((List<BLModel.ViewGpXmlGetInvoices>)null);

            GpXmlGenBusinessLogic logic = new GpXmlGenBusinessLogic(invoiceRepository.Object);
            var result = logic.GetInvoiceByWorkFileIdList(new List<int>());

            Assert.True(result == null, "Result should be null");
        }
    }
}
