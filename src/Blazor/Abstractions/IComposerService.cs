using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Stl.Fusion;
using Stl.Fusion.Authentication;

namespace Samples.Blazor.Abstractions
{
    public class ComposedValue
    {
        public string Parameter { get; } = "";
        public double Uptime { get; set; }
        public double? Sum { get; set; }
        public string LastChatMessage { get; } = "";
        public User User { get; } = new User("");
        public long ActiveUserCount { get; }

        public ComposedValue() { }
        [JsonConstructor]
        public ComposedValue(string parameter, double uptime, double? sum, string lastChatMessage, User user, long activeUserCount)
        {
            Parameter = parameter;
            Uptime = uptime;
            Sum = sum;
            LastChatMessage = lastChatMessage;
            User = user;
            ActiveUserCount = activeUserCount;
        }
    }

    public interface IComposerService
    {
        [ComputeMethod(KeepAliveTime = 1)]
        Task<ComposedValue> GetComposedValue(string parameter,
            Session session, CancellationToken cancellationToken = default);
    }

    public interface ILocalComposerService : IComposerService { }
}
