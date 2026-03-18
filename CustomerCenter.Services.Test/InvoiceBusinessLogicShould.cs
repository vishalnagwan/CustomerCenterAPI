using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Uniban.DemoiGlassData.Model;
using Uniban.DemoiGlassData.Repositories.Abstractions;
using Xunit;

using BLModel = Uniban.DemoiGlassData.Domain;

namespace Uniban.DemoiGlassData.Services.Test
{
    public class InvoiceBusinessLogicShould
    {
        public InvoiceBusinessLogicShould()
        {
            Config.Configuration.SetupAutoMap();
        }

        [Fact]
        public void GetAllInvoiceForStatus()
        {
            Mock<IInvoiceRepository> invoiceRepository = new Mock<IInvoiceRepository>();
            invoiceRepository.Setup(x => x.GetAllInvoiceForStatus(It.Is<int>(s => s.Equals(1)))).Returns(new List<BLModel.Invoice>() {
                new BLModel.Invoice() {
                    InvoiceId = 1
                },
                new BLModel.Invoice() {
                    InvoiceId = 2
                },
                new BLModel.Invoice() {
                    InvoiceId = 3
                }
            });

            // find with proper status
            InvoiceBusinessLogic logic = new InvoiceBusinessLogic(invoiceRepository.Object);
            List<IInvoice> result = logic.GetAllInvoiceForStatus(1);
            Assert.True(result != null, "result should not be null");
            Assert.True(result.Count() == 3, "count should be equal to 3");
        }

        [Fact]
        public void GetNullForInvalidInvoiceStatus()
        {
            Mock<IInvoiceRepository> invoiceRepository = new Mock<IInvoiceRepository>();
            invoiceRepository.Setup(x => x.GetAllInvoiceForStatus(It.Is<int>(s => s.Equals(1)))).Returns(new List<BLModel.Invoice>() {
                new BLModel.Invoice() {
                    InvoiceId = 1
                },
                new BLModel.Invoice() {
                    InvoiceId = 2
                },
                new BLModel.Invoice() {
                    InvoiceId = 3
                }
            });

            InvoiceBusinessLogic logic = new InvoiceBusinessLogic(invoiceRepository.Object);
            List<IInvoice> result = logic.GetAllInvoiceForStatus(2);
            Assert.True(result == null, "result should be null for invalid status");
        }

        [Fact]
        public void GetInvoiceByWorkFileId()
        {
            Mock<IInvoiceRepository> invoiceRepository = new Mock<IInvoiceRepository>();
            invoiceRepository.Setup(x => x.GetInvoiceByWorkFileId(It.Is<int>(s => s.Equals(123)))).Returns(new List<BLModel.Invoice>() {
                new BLModel.Invoice() {
                    InvoiceId = 1,
                    WorkFileId = 123
                }
            });

            // find with proper workfileid
            InvoiceBusinessLogic logic = new InvoiceBusinessLogic(invoiceRepository.Object);
            List<IInvoice> result = logic.GetInvoiceByWorkFileId(123);
            Assert.True(result != null, "result should not be null");
            Assert.True(result.Count() == 1, "count should be equal to 1");

            // try to find with invalid(non-existant) workfile id
            result = logic.GetInvoiceByWorkFileId(2234);
            Assert.True(result == null, "result should be null for invalid workfile");
        }
    }
}
