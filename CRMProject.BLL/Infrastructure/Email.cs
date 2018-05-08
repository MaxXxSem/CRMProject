using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRMProject.BLL.Infrastructure
{
    // email structure
    public class Email
    {
        // email title
        public string Title { get; private set; }

        // email text
        public string Text { get; private set; }

        // receiver id
        public int ReceiverId { get; set; }

        public Email(string title, string text, int receiverId)
        {
            Title = title;
            Text = text;
            ReceiverId = receiverId;
        }
    }
}
