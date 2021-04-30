import sys
#sys.path.append('/usr/local/lib/python3.8/site-packages')
sys.path.append('/Users/cenkkaraboa/miniforge3/lib/python3.9/site-packages')

import face_recognition  as fr
import os                       #dosya okuma 
import cv2                      #
import numpy as np              # matrislerdeki işlemler için
from time import sleep          #
import face_recognition 


# videonun çözünürlük , fps ve dosya türünü belirtiyor 
video_capture = cv2.VideoCapture("test.mp4")  
video_capture.set(cv2.CAP_PROP_BUFFERSIZE, 2)
W, H = 500, 500
video_capture.set(cv2.CAP_PROP_FRAME_WIDTH, W)
video_capture.set(cv2.CAP_PROP_FRAME_HEIGHT, H)
video_capture.set(cv2.CAP_PROP_FOURCC, cv2.VideoWriter_fourcc('M', 'J', 'P', 'G'))

#video içinden resim çekme
def get_image():
    retval, im = video_capture.read()
    return im

#sistem içerisinde bulunan dosyaların okunduğu fonksiyon
def get_encoded_faces():
    
    encoded = {}

    for dirpath, dnames, fnames in os.walk("./faces"):
        for f in fnames:
            if f.endswith(".jpg") or f.endswith(".png"):
                face = fr.load_image_file("faces/" + f)
                encoding = fr.face_encodings(face)[0]
                encoded[f.split(".")[0]] = encoding

    return encoded

faces = get_encoded_faces()   #yüz dosyalarının listesini getiiryor.
faces_encoded = list(faces.values()) #dosyaların değerlerini sayısal çeviriyor ve listeliyor.
known_face_names = list(faces.keys())   #dosyalarının idlerini belirliyor.



i = 0
#Kamera sürekli açık kalmasını sağlıyor
while True:
    i = i + 1
    #------ videoyu oepncv de okunabilir hale getiriyor
  
    _, frame = video_capture.read()
    rgb_frame = frame[:, :, ::-1]
    print(video_capture.get(cv2.CAP_PROP_FPS))

    #--- videoyu oepncv de okunabilir hale getiriyor

   

    #--- videodaki yüzleri tarıyor
    face_locations = face_recognition.face_locations(rgb_frame)
    unknown_face_encodings = face_recognition.face_encodings(rgb_frame, face_locations)
    #--- videodaki yüzleri tarıyor

    face_names = []



    #videodaki yüzün sistem de olup olmadığını kontrol ediyor
    for face_encoding in unknown_face_encodings:
        matches = face_recognition.compare_faces(faces_encoded, face_encoding)
        name = "Giris Izniniz Yok"


        #giriş izni yok ise fotoğraf çekiyor
        # images = get_image()    
        # file =  "111.png"
        # cv2.imwrite(file,frame)
      
        #giriş izni yok ise fotoğraf çekiyor


        face_distances = face_recognition.face_distance(faces_encoded, face_encoding)
        best_match_index = np.argmin(face_distances)
        if matches[best_match_index]:
            name = known_face_names[best_match_index]
            face_names.append(name)

        for (top, right, bottom, left), name in zip(face_locations, face_names):

            #yüzün kareye çizildiği karenin rengi
            cv2.rectangle(frame, (left-20, top-20), (right+20, bottom+20), (0,  0, 255), 2)
            cv2.rectangle(frame, (left-20, bottom -15), (right+20, bottom+20), (0, 0, 255), cv2.FILLED)
            #yüzün kareye çizildiği karenin rengi   

            #resmin altına isim yazıyor
            font = cv2.FONT_HERSHEY_DUPLEX
            cv2.putText(frame, name, (left -20, bottom + 15), font, 1.0, (255, 0, 0), 2)


   # cv2.imshow('Video', frame)
    
    # images = get_image()    
    # file =  "222.png"
    # cv2.imwrite(file,frame) 


  
    file =  "1.png"
    path = '/Users/cenkkaraboa/Desktop/web/src/img'
    cv2.imwrite(os.path.join(path , file), frame)
    
 
    print("dadadada")
    print((i))
    #çıkış için
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break 






