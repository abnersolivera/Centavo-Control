using System;
using System.Collections.Generic;
using CentavoControl.Domain.Notifications;

namespace CentavoControl.Domain
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
