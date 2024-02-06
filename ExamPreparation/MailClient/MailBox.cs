using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new(capacity);
            Archive = new();
        }
        public int Capacity { get; private set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public void IncomingMail(Mail mail)
        {
            if (Capacity > Inbox.Count)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender) =>
            Inbox.Remove(Inbox.FirstOrDefault(n => n.Sender == sender));

        public int ArchiveInboxMessages()
        {
            int countRemoved = Inbox.Count;
            Archive.AddRange(Inbox);
            Inbox.Clear();
         
            return countRemoved;
        }

        public string GetLongestMessage()
        {
            Mail mail = Inbox.OrderByDescending(m => m.Body.Length).First();
            return mail.ToString();
        }

        public string InboxView()
        {
            return "Inbox:"
                   + Environment.NewLine
                   + $"{string.Join(Environment.NewLine, Inbox)}";
        }
    }
}
