using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Uniban.DemoiGlassData.Domain;
using Uniban.DemoiGlassData.Proxies.Abstractions;
using Uniban.DemoiGlassData.Repositories.Abstractions;
using Xunit;
using BLModel = Uniban.DemoiGlassData.Domain;

namespace Uniban.DemoiGlassData.Services.Test
{
    public class WorkFileBusinessLogicShould
    {
        private readonly Mock<IWorkOrderRepository> workOrderRepositoryMock;
        private readonly WorkFileBusinessLogic workOrderBusinessLogic;
        private readonly Mock<IPhoenixProxy> phoenixProxyMock;

        public WorkFileBusinessLogicShould()
        {
            Config.Configuration.SetupAutoMap();
            workOrderRepositoryMock = new Mock<IWorkOrderRepository>();
            phoenixProxyMock = new Mock<IPhoenixProxy>();
            workOrderBusinessLogic = new WorkFileBusinessLogic(workOrderRepositoryMock.Object, phoenixProxyMock.Object);
        }

        [Fact]
        public void GetById_ShouldReturnAWorkFileWithTheCorrectIdAndNotBeNull()
        {
            var workOrderId = 1;
            var workOrder = GivenAWorkOrder(workOrderId);
            workOrderRepositoryMock.Setup(x => x.GetById(workOrderId)).Returns(workOrder);

            var result = workOrderBusinessLogic.GetById(workOrderId);

            result.Should().NotBeNull();
            result.WorkFileId.Should().Be(workOrderId);
            workOrderRepositoryMock.Verify(x => x.GetById(workOrderId), Times.Once());
        }

        [Fact]
        public void GetClaimNumberFromJobNumber_ShouldReturnNull_WhenTheClaimNumberGetsNoMatch()
        {
            var jobNumber = "123456";

            var result = workOrderBusinessLogic.GetClaimNumberFromJobNumber(jobNumber);

            result.Should().BeNull();
            workOrderRepositoryMock.Verify(w => w.GetByJobNumber(int.Parse(jobNumber)), Times.Once());
        }

        [Fact]
        public void GetClaimNumberFromJobNumber_ShouldReturnTheClaimNumber_WhenTheJobNumberMatches()
        {
            int jobNumber = 123456;
            var workOrder = new BLModel.WorkOrder()
            {
                WorkOrderId = 1,
                ClaimNumber = "165161"
            };
            workOrderRepositoryMock.Setup(x => x.GetByJobNumber(jobNumber)).Returns(workOrder);

            var result = workOrderBusinessLogic.GetClaimNumberFromJobNumber(jobNumber.ToString());

            result.Should().Be(workOrder.ClaimNumber);
            workOrderRepositoryMock.Verify(x => x.GetByJobNumber(jobNumber), Times.Once());
        }

        [Fact]
        public void GetByPolicyNumberAndDateOfLoss_ShouldFindTheWorkFile()
        {
            var workOrderId = 1;
            var policyNumber = "12345";
            var dateOfLoss = DateTime.Parse("2018-04-13");
            var workOrder = GivenAWorkOrder(workOrderId);
            workOrderRepositoryMock.Setup(x => x.GetByPolicyNumberAndDateOfLoss(policyNumber, dateOfLoss)).Returns(workOrder);

            var result = workOrderBusinessLogic.GetByPolicyNumberAndDateOfLoss(policyNumber, dateOfLoss);

            result.Should().NotBeNull();
            result.WorkFileId.Should().Be(workOrderId);
            workOrderRepositoryMock.Verify(x => x.GetByPolicyNumberAndDateOfLoss(policyNumber, dateOfLoss), Times.Once());
        }

        [Fact]
        public void GetByPolicyNumberAndDateOfLoss_ShouldNotFindTheWorkFile()
        {
            var policyNumber = "12345";
            var dateOfLoss = DateTime.Parse("2018-04-13");

            var result = workOrderBusinessLogic.GetByPolicyNumberAndDateOfLoss(policyNumber, dateOfLoss);

            result.Should().BeNull();
            workOrderRepositoryMock.Verify(x => x.GetByPolicyNumberAndDateOfLoss(policyNumber, dateOfLoss), Times.Once());
        }

        [Fact]
        public void GetInsurerGuidFromWorkOrder_ShouldFindWorkFileInsurers()
        {
            var jobNumbers = new List<int>();
            var workOrder = GivenAWorkOrder(1);
            workOrderRepositoryMock.Setup(x => x.GetWorkFileFromJobNumberList(jobNumbers)).Returns(new List<BLModel.WorkOrder> { workOrder });

            var result = workOrderBusinessLogic.GetInsurerGuidFromWorkOrder(new List<int>());

            result.Count().Should().Be(1);
            workOrderRepositoryMock.Verify(x => x.GetWorkFileFromJobNumberList(jobNumbers), Times.Once());
        }

        [Fact]
        public void GetInsurerGuidFromWorkOrder_ShouldNotFindAnyWorkFileInsurer()
        {
            var result = workOrderBusinessLogic.GetInsurerGuidFromWorkOrder(new List<int>());

            result.Should().BeEmpty();
            workOrderRepositoryMock.Verify(x => x.GetWorkFileFromJobNumberList(It.IsAny<List<int>>()), Times.Once());
        }

        [Fact]
        public void SearchByVin_ShouldFindAWorkFile_WithOneInvoice_ContainingOneInvoiceDetail()
        {
            var workOrderId = 1;
            var vin = "12345";
            var workOrder = GivenAWorkOrder(workOrderId);
            workOrderRepositoryMock.Setup(x => x.SearchByVIN(vin)).Returns(new List<BLModel.WorkOrder> { workOrder });

            var result = workOrderBusinessLogic.SearchByVIN(vin);

            result.Count().Should().Be(1);
            result.First().Invoices.Count().Should().Be(1);
            result.First().Invoices.First().InvoiceDetails.Count().Should().Be(1);
            workOrderRepositoryMock.Verify(x => x.SearchByVIN(vin), Times.Once());
        }

        [Fact]
        public void SearchByVin_ShouldNotFindAWorkFile()
        {
            var vin = "12345";

            var result = workOrderBusinessLogic.SearchByVIN(vin);

            result.Should().BeEmpty();
            workOrderRepositoryMock.Verify(x => x.SearchByVIN(vin), Times.Once());
        }

        private static WorkOrder GivenAWorkOrder(int workOrderId)
        {
            return new BLModel.WorkOrder()
            {
                WorkOrderId = workOrderId,
                WorkForms = Enumerable.Empty<BLModel.WorkForm>(),
                WorkFileTypeId = 5,
                CreatorId = 7,
                CompanyRefId = 897,
                CreationDate = DateTime.Now,
                PolicyNumber = "a32sd1a5d4a",
                ClaimNumber = "da1sd6a4",
                FirstName = "John",
                LastName = "Doe",
                Mileage = "45477",
                VIN = "12397864",
                DateOfLoss = DateTime.Now.AddMonths(1),
                RefDate2 = null,
                CloseDate = null,
                LockGroupNameId = null,
                WorkOrderNumber = 8798,
                NagsVehicleId = 454,
                Flag4 = 48949,
                IsOEM = 1,
                Flag6 = 4949,
                ShopName = "A name",
                DriverName = "JOHN DOE",
                ProvinceCode = "QC",
                VehicleReference = "d4as6da4",
                RefDate3 = DateTime.Now.AddDays(12),
                RefDate4 = DateTime.Now.AddMonths(13),
                IsRepair = true,
                Flag8 = 9,
                Flag9 = 21,
                Flag10 = 67,
                Longitude = 49,
                Latitude = 351,
                Flag11 = 9756,
                IsManualClaim = true,
                AuthorizationCode = 94382,
                Flag14 = 159,
                Flag15 = 753,
                Flag16 = 684,
                Reference11 = "as5d4as9d4asd9a8d",
                InvoiceNumber = "f7s9d8fsdf897sdfs",
                Reference13 = "21asd3ad1sadd",
                PostalCode = "H0H0H0",
                Reference15 = "yuiyiygrw1r65ee",
                Reference16 = "bv19e8r1cw9ecw",
                WorkFileTransactionTypeId = 59731,
                Status = new WorkOrderStatus(),
                Insurer = new Company(),
                Owner = new User(),
                PolicyHolder = new PolicyHolder(),
                Quote = new Quote(),
                Guardian = new Guardian(),
                Invoices = GivenInvoices(),
                Vehicles = Enumerable.Empty<Vehicle>(),
                WorkFileParticipants = Enumerable.Empty<WorkOrderParticipant>(),
                WorkFileStatusHistories = Enumerable.Empty<WorkOrderStatusHistory>(),
                VendorUser = new User(),
                VendorUserRefId = 2846
            };
        }

        private static List<Invoice> GivenInvoices()
        {
            return new List<Invoice>() { GivenAnInvoice() };
        }

        private static Invoice GivenAnInvoice()
        {
            return new BLModel.Invoice()
            {
                InvoiceId = 1,
                InvoiceDetails = new List<BLModel.InvoiceDetail>() { GivenAnInvoiceDetail() }
            };
        }

        private static InvoiceDetail GivenAnInvoiceDetail()
        {
            return new BLModel.InvoiceDetail()
            {
                InvoiceDetailId = 1
            };
        }
    }
}
