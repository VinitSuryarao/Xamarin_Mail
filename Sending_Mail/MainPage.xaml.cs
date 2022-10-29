using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Sending_Mail
{
    public partial class MainPage : ContentPage
    {
        SmtpClient smtpserver;
        public MainPage()
        {
            InitializeComponent();
        }

        public  void btnSendMail_Clicked(object sender, EventArgs e)
        {
            
          List<string> toAddress = new List<string>();
          toAddress.Add(txtEmail.Text);
          SendEmail(txtSubject.Text, txtBody.Text, toAddress);
          
        }

        public void SendEmail(string subject, string body, List<string> recipients)
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = subject,
                    Body = body,
                    To = recipients,
                };
                 Email.ComposeAsync(message);
            }
            catch (Exception ex)
            {
                DisplayAlert("Mail Failed", ex.Message, "OK");
            }
        }
    }
}
