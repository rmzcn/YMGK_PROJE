import socket, pickle, struct, cv2.cv2

client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
host_ip = '176.53.65.237'  # server ip adresi
port = 9999 #baglanilacak port
client_socket.connect((host_ip, port))
data = b""
payload_size = struct.calcsize("Q")
while True:
    while len(data) < payload_size:
        packet = client_socket.recv(4 * 1024)
        if not packet: break
        data += packet
    packed_msg_size = data[:payload_size]
    data = data[payload_size:]
    msg_size = struct.unpack("Q", packed_msg_size)[0]

    while len(data) < msg_size:
        data += client_socket.recv(4 * 1024)
    frame_data = data[:msg_size]
    data = data[msg_size:]
    # **** IMPORTANT START ****
    # Burasi cok onemli.
    # frame degiskeni icerisine serverdan yayin yapilan frame ler gelir
    # frame aldiktan sonra yapay zeka birimine bu frame'in iletilmesi gerekir
    frame = pickle.loads(frame_data)
    # **** IMPORTANT END ****
    
    # detect_with_ai(frame, camera_id)
    # bu fonksiyon yapay zekayi tetikleyecek.
    # icerisine bir frame ve hangi kameradan bu goruntunun geldigi bilgisini alacak.
    #********* ACIKLAMA START **********
    # frame bilgisi zaten frame degiskeninden geliyor.
    # Burada onemli olan kisim ise camera_id bilgisi.
    # Yazilan server kodunda, bir video_server.py dosyasi sadece tek bir kamera
    # goruntusunu yayinlayabiliyor. Bundan dolayı her bir porttan sadece bir kameranin yayini yapilabilir.
    # camera_id bilgisi de her bir port icin unique(benzersiz)dir.
    # Kameralar sisteme kaydedilirken id bilgileri verilerek kaydedilecek. Bizim de ihtiyacimiz olan parametre ise camera_id.
    # Eger sistme bir kamera eklerken kameranin id bilgisini, yayinin server uzerinde yapilacagi port seklinde girersek
    # (yani: kameranin veritabanindaki id bilgisi = server uzerinde o kameranin yayinin yapilacagi port),
    # bu sayede port bilgisi bizim camera_id parametremiz olur.
    #********* ACIKLAMA END **********
    
    cv2.imshow("RECEIVING VIDEO", frame)
    key = cv2.waitKey(1) & 0xFF
    if key == ord('q'):
        break
client_socket.close()
