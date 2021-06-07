using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Timesheets.Domain.Aggregates.SheetAggregate;
using Timesheets.Models;
using Xunit;

namespace TimesheetsTests
{
    public class SheetAggregateTests
    {
        public static Guid EmployeeId = Guid.Parse("8d7fdafb-12ca-403a-bc6d-f45e13499bcb");

        [Fact]
        public void CreateTest()
        {
            var builder = new SheetAggregateBuilder();
            var sheet = SheetAggregate.Create(
                builder.amountForRandomSheets,
                builder.SheetContractId,
                DateTime.Now,
                builder.SheetEmployeeId,
                builder.SheetServiceId);

            sheet.Should().As<SheetAggregate>();
        }

        [Fact]
        public void CreateFromRequestTest()
        {
            var builder = new SheetAggregateBuilder();
            var sheet = builder.CreateRandomSheet();

            sheet.Amount.Should().Be(builder.amountForRandomSheets);
            sheet.ContractId.Should().Be(builder.SheetContractId);
            sheet.EmployeeId.Should().Be(builder.SheetEmployeeId);
            sheet.ServiceId.Should().Be(builder.SheetServiceId);
            sheet.Date.Should().BeExactly(TimeSpan.FromSeconds(DateTimeOffset.Now.ToUnixTimeSeconds()));
        }

        [Fact]
        public void ApproveSheetTest()
        {
            var builder = new SheetAggregateBuilder();
            var sheet = builder.CreateRandomSheet();

            sheet.ApproveSheet();

            sheet.IsApproved.Should().BeTrue();
            sheet.ApprovedDate.Should().BeExactly(TimeSpan.FromSeconds(DateTimeOffset.Now.ToUnixTimeSeconds()));
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void ChangeEmployeeTest(Guid newEmployeeId)
        {
            var builder = new SheetAggregateBuilder();
            var sheet = builder.CreateRandomSheet();

            sheet.ChangeEmployee(newEmployeeId);

            sheet.EmployeeId.Should().Be(newEmployeeId);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { EmployeeId };
        }
    }
}
