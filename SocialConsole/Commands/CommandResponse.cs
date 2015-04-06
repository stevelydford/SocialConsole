using System.Collections.Generic;

namespace SocialConsole.Commands
{
    public class CommandResponse
    {
        public CommandResponseStatus Status { get; set; }
        public List<string> Payload { get; set; }

        public CommandResponse(CommandResponseStatus status, List<string> payload)
        {
            Init(status, payload);
        }

        public CommandResponse(CommandResponseStatus status)
        {
            Init(status, new List<string>());
        }

        private void Init(CommandResponseStatus status, List<string> payload)
        {
            Status = status;
            Payload = payload;
        }
    }

    public enum CommandResponseStatus
    {
        Ok,
        Error
    };
}
