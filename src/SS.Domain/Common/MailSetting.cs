using SS.Domain.Contracts;

namespace SS.Domain.Common;

public class MailSetting : AuditableEntity
{
    public string Host { get; set; }
    public int Port { get; set; }
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
    public string FromName { get; set; }
    public string FromEmail { get; set; }
    public string ToName { get; set; }
    public bool Enabled { get; set; }
}