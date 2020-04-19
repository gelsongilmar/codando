using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codando.Notification
{
    public abstract class Notification
    {

        public List<string> Notifications { get; set; }

        public Notification()
        {
            this.Notifications = new List<string>();
        }

        public bool IsValid()
        {
            this.Validar();
            return this.Notifications.Count == 0;
        }

        public void AddNotification(string msg)
        {
            this.Notifications.Add(msg);
        }

        public void CleanNotifications()
        {
            this.Notifications.Clear();
        }

        public abstract void Validar();

    }
}
