using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MonitorBoletos.Util
{
    public class SendEmails
    {
        public void SendMail(List<string> Lista)
        {
            //array para ser usado na criação do corpo da mensagem
            var listItens = new List<String>();

            //variavel que armazena o e-mail que recebera a mensagem
            //var toAddress = new MailAddress("financeiro@grupocard.com.br");
            var toAddress = new MailAddress("joao.goncalves@grupocard.com.br");

            //variabel que armazena o e-mail e a senha que será usado para enviar o e-mail
            var fromAddress = new MailAddress("joao.goncalves@grupocard.com.br", "João Paulo");
            const string fromPassword = "joa230987";

            //Cria conexao com o servidor do grupo card
            SmtpClient smtp = new SmtpClient
            {
                Host = "mta01.grupocard.com.br",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            //Cria o titulo da mensagem e gera uma corpo da mensagem a partir da entrada Lista, cria uma List<> e envia pelo SMTP criado acima
            try
            {
                using (var message = new MailMessage(fromAddress, toAddress))
                {
                    message.Subject = "Leitura de Cnab";
                    foreach (var itemList in Lista)
                    {
                        listItens.Add(itemList.ToString());
                    }
                    message.Body += string.Join("\n ", listItens);
                    try
                    {
                        smtp.Send(message);
                    }
                    catch (SmtpException smtpEx)
                    {
                        throw smtpEx;
                    }
                }
            }
            catch (Exception) { throw; }
        }
    }
}
