from body import BodyThread
import time
import struct
import global_vars
from sys import exit


thread = BodyThread()
thread.start()
# print(thread.data)
i = input()
global_vars.KILL_THREADS = True
time.sleep(0.5)
exit()