using System;
using System.Collections.Generic;

namespace Solution
{
    public interface Service
    {
        void OnVideoEncoded();
    }

    public class MailService : Service
    {
        private int sentEmail;

        public MailService()
        {
            sentEmail = 0;
        }

        public void OnVideoEncoded()
        {
            sentEmail++;
        }

        public int getSentEmail()
        {
            return sentEmail;
        }
    }

    public class BrowserNotificationService : Service
    {
        private int notifications;

        public BrowserNotificationService()
        {
            notifications = 0;
        }

        public void OnVideoEncoded(/* Your arguments if required*/)
        {
            notifications++;
        }

        public int getNotifications()
        {
            return notifications;
        }
    }

    public class MessageService : Service
    {
        private int messages;

        public MessageService()
        {
            messages = 0;
        }

        public void OnVideoEncoded()
        {
            messages++;
        }

        public int getMessages()
        {
            return messages;
        }
    }
}
