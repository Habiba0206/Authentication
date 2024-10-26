using Authentication.Application.Common.Enums;
using Authentication.Application.Common.Identity.Models;

namespace Authentication.Application.Common.Identity.Services;

public interface IVerificationTokenGeneratorService
{
    string GenerateToken(VerificationType verificationType, Guid UserId);
    (VerificationToken VerificationToken, bool IsValid) DecodeToken(string token);
}
