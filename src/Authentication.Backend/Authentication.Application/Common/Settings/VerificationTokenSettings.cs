namespace Authentication.Application.Common.Settings;

public class VerificationTokenSettings
{
    public string IdentityVerificationTokenPurpose { get; set; }
    public int IdentityVerificationExpirationDurationInMinutes { get; set; }
}
