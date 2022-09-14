using Hemera.Chat.Enums;

namespace Hemera.Chat.Models
{
    public class Response
    {
        public string? RequestId { get; set; }
        public string Status { get; set; } = default!;
        public string? Message { get; set; }
        public object? Result { get; set; }
    }
}