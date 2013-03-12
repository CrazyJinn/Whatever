using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Email
    {
        private SmtpClient smtpClient = null;   //设置SMTP协议
        private MailAddress mailAddressFrom = null; //设置发信人地址  当然还需要密码
        private MailMessage mailMessage = new MailMessage();

        #region 设置Smtp服务器信息
        /// <summary>
        /// 设置Smtp服务器信息
        /// </summary>
        public void SetSmtpClient(string serverHost)
        {
            smtpClient = new SmtpClient();
            smtpClient.Host = serverHost;//指定SMTP服务名  例如QQ邮箱为 smtp.qq.com 新浪cn邮箱为 smtp.sina.cn等
            smtpClient.Timeout = 0;  //超时时间
        }
        #endregion

        #region 验证发件人信息
        /// <summary>
        /// 验证发件人信息
        /// </summary>
        /// <param name="mailAddress">发件邮箱地址</param>
        /// <param name="mailPwd">邮箱密码</param>
        public void SetAddressform(string mailAddress, string mailPwd)
        {
            //创建服务器认证
            NetworkCredential NetworkCredential_my = new NetworkCredential(mailAddress, mailPwd);
            //实例化发件人地址
            mailAddressFrom = new System.Net.Mail.MailAddress(mailAddress, "Whatever!");
            //指定发件人信息  包括邮箱地址和邮箱密码
            smtpClient.Credentials = new System.Net.NetworkCredential(mailAddressFrom.Address, mailPwd);
        }
        #endregion

        #region 发送邮件

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailTo">收件人邮件地址</param>
        /// <param name="mailSubject">邮件标题</param>
        /// <param name="mailBody">邮件正文</param>
        /// <param name="attachedList">附件集合</param>
        public void SendEmail(string mailTo, string mailSubject, string mailBody)
        {
            try
            {
                //清空历史发送信息 以防发送时收件人收到的错误信息(收件人列表会不断重复)
                mailMessage.To.Clear();
                //添加收件人邮箱地址
                mailMessage.To.Add(new MailAddress(mailTo));

                //发件人邮箱
                mailMessage.From = mailAddressFrom;
                //邮件主题
                mailMessage.Subject = mailSubject;
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                //邮件正文
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailBody, null, "text/html");
                mailMessage.AlternateViews.Add(htmlView);

                //清空历史附件  以防附件重复发送
                mailMessage.Attachments.Clear();

                //开始发送邮件
                smtpClient.SendAsync(mailMessage, "0000");

            }
            catch
            {
                StreamWriter sw = File.AppendText("C:\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
                sw.WriteLine("==================================");
                sw.WriteLine("发送邮件出错，准备发送的异常如下:");
                sw.WriteLine(mailBody);
                sw.WriteLine("==================================");
                sw.Flush();
            }
        }
        #endregion
    }

    public static class MyEmail
    {
        public static void Send(string mailBody)
        {
            Email email = new Email();
            email.SetSmtpClient("smtp.126.com");
            email.SetAddressform("crazyjinn@126.com", "19891029");
            email.SendEmail("crazyjinn@qq.com", "数据错误", mailBody);
        }
    }
}
