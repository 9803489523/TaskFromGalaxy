from socket import *

host=5000
address = ('localhost', host)

sock = socket(AF_INET, SOCK_DGRAM)

sock.bind(address)

while True:
    conn, addr=sock.recvfrom(1024)
    sock.sendto(b'receive by the server',addr)

