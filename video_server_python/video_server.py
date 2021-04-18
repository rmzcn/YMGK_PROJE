#Bu importlar server icindeki
# /var/www/vhosts/rgolgen.com/video_server/video_server_virtualenv
#dizini icerisinde import edilmis hazir sekildedir.
import socket, cv2, pickle, struct, imutils

server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
host_ip = "176.53.65.237" # server ip adresi
port = 9999 # video yayının yapılacağı port
socket_address = (host_ip, port)

#****START****
#video kaynagi dosya ismi ve yolu olabilir
#ayrica bir video yayin kaynagi da olabilir
#ornegin:
#protocol://host:port/script_name?script_params|auth
video_source = "videos/sample_video.mp4"
#yukaridaki video kaynagina IP kameralarin yayin yaptigi URL 'i verirsek
#bu server kodu, verilen bu URL deki yayini Frame'leri bolup yayin yaptirabilir.
#server kodunun en onemli kismi bu video kaynagidir.
#****END****

server_socket.bind(socket_address)

server_socket.listen(5)
print("LISTENING AT:", socket_address)

# Socket Accept
while True:
    client_socket, addr = server_socket.accept()
    print('GOT CONNECTION FROM:', addr)
    if client_socket:
        vid = cv2.VideoCapture(video_source)

        while (vid.isOpened()):
            img, frame = vid.read()
            frame = imutils.resize(frame, width=320)
            a = pickle.dumps(frame)
            message = struct.pack("Q", len(a)) + a
            client_socket.sendall(message)

            key = cv2.waitKey(1) & 0xFF
            if key == ord('q'):
                client_socket.close()
