import smtplib
import sys

from email.mime.text import MIMEText
from email.mime.multipart import MIMEMultipart
from email.header import Header

sender = 'songqiang.1304521@163.com'
receivers = ['songqiang.1304521@163.com']

message = MIMEMultipart()
filePath = sys.argv[1]

if __name__ == '__main__':
    stringSender = 'IESFC Website Server <songqiang.1304521@163.com>'
    message['From'] = Header(stringSender)
    stringReceiver = 'Personal Email Account <songqiang.1304521@163.com>'
    message['To'] = Header(stringReceiver)
    subject = 'IESFC Website Backup Archive'
    message['Subject'] = Header(subject, 'utf-8')
    
    message.attach(MIMEText('IESFC Website Backup files, including SQL file of articles and uploaded files.', 'plain', 'utf-8'))
    
    fileBackup = MIMEText(open(filePath, 'rb').read(), 'base64', 'utf-8')
    fileBackup["Content-Type"] = 'application/octet-stream'
    fileBackup["Content-Disposition"] = 'attachment; filename='+sys.argv[1]
    message.attach(fileBackup)
    
    try:
        smtpObj = smtplib.SMTP_SSL()
        smtpObj.connect('smtp.163.com', 465)
        smtpObj.login('songqiang.1304521@163.com', '1304521qwe')
        smtpObj.sendmail(sender, receivers, message.as_string())
        print('Backup Files Sended')
    except:
        print('Error Sending Backup Files')