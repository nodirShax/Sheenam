﻿//===========================================================
//CopyRight (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//===========================================================

using FluentAssertions;
using Moq;
using Sheenam.Api.Models.Foundations.Guests;
using System.Security.Cryptography;
using Xunit;

namespace Sheenam.Api.Tests.Unit.Service.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task ShouldAddGuestAsync()
        {
            Guest randomGuest = CreateRandomGuest();
            Guest inputGuest = randomGuest;
            Guest returningGuest = inputGuest;
            Guest expectedGuest = returningGuest;

            //When
            Guest actualGuest =
                await this.guestService.AddGuestAsync(inputGuest);

            //Then
            actualGuest.Should().BeEquivalentTo(expectedGuest);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertGuestAsync(inputGuest),
                Times.Once());

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
