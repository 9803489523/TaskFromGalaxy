from socket import *
import time
import os

host=5000
address = ('localhost', host)


sock = socket(AF_INET, SOCK_DGRAM)
message="Hello world"
counter=0
clear=lambda :os.system('cls')
while True:
    clear()
    message=str.encode(message)
    sock.sendto(message,address)
    message,aa=sock.recvfrom(1024)
    message=bytes.decode(message)
    counter=counter+1
    print('сообщений отправлено {}',counter)

    time.sleep(1)

