//===========================================================
//CopyRight (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//===========================================================

using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Services.Foundations.Guests.Exceptions;
using Xunit;

namespace Sheenam.Api.Tests.Unit.Service.Foundations.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]

        public async Task ShouldThrowValidationExceptionOnAddIfGuestIsNullAndLogItAsync()
        {
            //Given
            Guest nullGuest = null;
            var nullGuestException = new NullGuestException();

            var expectedGuestValidationException =
                new GuestValidationsException(nullGuestException);

            //When
            ValueTask<Guest> addGuestTask =
                this.guestService.AddGuestAsync(nullGuest);

            //Then
            await Assert.ThrowsAnyAsync<GuestValidationsException>(() =>
                addGuestTask.AsTask());
        }
    }
}
