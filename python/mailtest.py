import smtplib, ssl
from email.mime.text import MIMEText
from email.mime.multipart import MIMEMultipart

smtp_server = input("Server Address: ")
port = input("Port Number: ")
logon = input("Logon: ")
password = input("Password: ")
sender = input("From: ")
receiver_email = input("To: ")

message = MIMEMultipart("alternative")
message["subject"] = "SMTP Python Test"
message["from"] = sender
message["to"] = receiver_email

message_text = """ \
Hi,

This is a test message from Python."""

message_html = """\
<html>
	<body>
		<p>Hi!</p>
		<p>Tihs is a test message from Python.</p>
	</body>
</html>
"""

message.attach(MIMEText(message_text, "plain"))
message.attach(MIMEText(message_html, "html"))

# Create a secure SSL context
context = ssl.create_default_context()

# Try to send message
try:
	server = smtplib.SMTP(smtp_server, port)
	server.ehlo()
	server.starttls(context=context)
	server.ehlo()
	server.login(sender, password)

	#send mail here
	server.sendmail(sender, receiver_email, message.as_string())

	# finalizar conexao
	server.quit()

	# Success message
	print("Success!")
except Exception as e:
	print(e)
