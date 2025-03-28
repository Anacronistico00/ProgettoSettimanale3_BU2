namespace ProgettoSettimanale3_BU2.DTOs.Account
{
    public class TokenResponseDto
    {
        public required string Token { get; set; }

        public required DateTime Expires { get; set; }
    }
}
