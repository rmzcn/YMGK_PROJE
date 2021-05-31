import sys

#sys.path.append('/usr/local/lib/python3.8/site-packages')
sys.path.append('/Users/cenkkaraboa/miniforge3/lib/python3.9/site-packages')
import os
import glob
import requests
import face_recognition  as fr
import os                       #dosya okuma 
import cv2                      #
import numpy as np              # matrislerdeki işlemler için
from time import sleep          #
import face_recognition 
import requests
import urllib3

urllib3.disable_warnings()

def get_image():
    retval, im = video_capture.read()
    return im

def get_encoded_faces():
    
    encoded = {}

    for dirpath, dnames, fnames in os.walk("/Users/cenkkaraboa/Desktop/son/YuzTanima/YuzTanima.WebService/wwwroot/Images/"):
        for f in fnames:
            if f.endswith(".jpg") or f.endswith(".png"):
                face = fr.load_image_file("/Users/cenkkaraboa/Desktop/son/YuzTanima/YuzTanima.WebService/wwwroot/Images/" + f)
                encoding = fr.face_encodings(face)[0]
                encoded[f.split(".")[0]] = encoding

    return encoded



i = 0
belge = ''
sımdı = 'x'
sonraki = 'y'
changeCamera = 0 

while True:
    with os.scandir("/Users/cenkkaraboa/Desktop/son/YuzTanima/YuzTanima.WebService/wwwroot/KameraId/") as tarama:
     for belge in tarama:
        if belge.name.endswith("txt"):
            belge = belge.name.split('.')[0]
            
    print(belge)
    if belge != sımdı :
        sımdı = belge
        print(sımdı)
        video_capture = cv2.VideoCapture(belge+".mp4")
        faces = get_encoded_faces()   
        faces_encoded = list(faces.values()) 
        known_face_names = list(faces.keys())  
    
    i = i + 1
  
    _, frame = video_capture.read()
    rgb_frame = frame[:, :, ::-1]
    print(video_capture.get(cv2.CAP_PROP_FPS))

    face_locations = face_recognition.face_locations(rgb_frame)
    unknown_face_encodings = face_recognition.face_encodings(rgb_frame, face_locations)

    face_names = []

    for face_encoding in unknown_face_encodings:
        matches = face_recognition.compare_faces(faces_encoded, face_encoding)
        name = "Giris Izniniz Yok"

        face_distances = face_recognition.face_distance(faces_encoded, face_encoding)
        best_match_index = np.argmin(face_distances)

       
        if matches[best_match_index]:
            
            url = 'http://localhost:5000/api/report/izinsorgula'            
            myobj = {'ziyaretciId': known_face_names[best_match_index],'kameraId':belge }
            headers = {'Content-Type': 'application/json', 'charset': 'utf-8'}
            print(known_face_names[best_match_index])
            r = requests.post(url ,json =  myobj,headers=headers,verify=False).json()
            typeValue = False 
            if r['success']: 
                name = "izinli"
                typeValue = True 
                face_names.append(name)  
            else :
                name = "izni yok"
                typeValue = False 
                face_names.append(name)  
           
            if typeValue :
                for (top, right, bottom, left), name in zip(face_locations, face_names):
                    cv2.rectangle(frame, (left-20, top-20), (right+20, bottom+20), (0,  128, 0), 2)
                    cv2.rectangle(frame, (left-20, bottom -15), (right+20, bottom+20), (0,  128, 0), cv2.FILLED)
                    font = cv2.FONT_HERSHEY_DUPLEX
                    cv2.putText(frame, name, (left -20, bottom + 15), font, 1.0, (255, 0, 0), 2)
            else :                    
                for (top, right, bottom, left), name in zip(face_locations, face_names):
                
                    cv2.rectangle(frame, (left-20, top-20), (right+20, bottom+20), (0,  0, 255), 2)
                    cv2.rectangle(frame, (left-20, bottom -15), (right+20, bottom+20), (0, 0, 255), cv2.FILLED)
                    font = cv2.FONT_HERSHEY_DUPLEX
                    cv2.putText(frame, name, (left -20, bottom + 15), font, 1.0, (255, 0, 0), 2)
           
        else :
            name = "kayıt olmayan"
            face_names.append(name)
            for (top, right, bottom, left), name in zip(face_locations, face_names):
                
                cv2.rectangle(frame, (left-20, top-20), (right+20, bottom+20), (0,  0, 255), 2)
                cv2.rectangle(frame, (left-20, bottom -15), (right+20, bottom+20), (0, 0, 255), cv2.FILLED)
                font = cv2.FONT_HERSHEY_DUPLEX
                cv2.putText(frame, name, (left -20, bottom + 15), font, 1.0, (255, 0, 0), 2)


    file =  "1.jpg"
    path = '/Users/cenkkaraboa/Desktop/son/web/src/img'
    cv2.imwrite(os.path.join(path , file), frame)
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break 