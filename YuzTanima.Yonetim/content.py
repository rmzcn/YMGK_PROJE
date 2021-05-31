import face_rec 
from threading import Thread
import time 

class Main():
    def __init__(self):
        print("çalıştı")

        # test1 = Thread(target=face_rec.run, 
        #                    args=("thread1",   "test"))
  
        # test2 = Thread(target=face_rec.run, 
        #                    args=("thread2",   "test2"))
     
        # test1.start()
        # test2.start()
        # test1.join()
        # test2.join()
        face_rec.run("test")
      
     
if __name__=="__main__":
    Main()