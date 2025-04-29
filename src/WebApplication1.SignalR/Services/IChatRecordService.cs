using WpfApp.Communication.Client1.Models;

namespace WpfApp.Communication.Client1.Services
{
    internal interface IChatRecordService : IDisposable
    {
        Task AddChatRecordAsync(Message message);
        Task<List<Message>> GetChatRecordsAsync(string user1, string user2, int start, int count);
    }
}