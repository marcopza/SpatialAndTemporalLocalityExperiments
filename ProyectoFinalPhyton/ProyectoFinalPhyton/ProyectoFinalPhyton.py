# importing PIL 
from PIL import Image
import time
img = Image.open('resources/3.bmp') 

width, height = img.size
pixels = img.load()
count = 0
version = 5
start = time.time_ns()

# Version 1
if version ==1:
    for i in range(width):
        for j in range(height):
          pixel = pixels[i, j]
          pixels[i, j] = (255-pixel[0], 255-pixel[1], 255-pixel[2])
          count = count+3

# Version 2
if version ==2:
    for i in range(width):
        for j in range(height):
           pixel = pixels[i, j]
           pixel = pixel[:0] + (255-pixel[0],) + pixel[0+1:]
           pixels[i, j] =pixel
           count = count+1
    for i in range(width):
        for j in range(height):
          pixel = pixels[i, j]
          pixel = pixel[:1] + (255-pixel[1],) + pixel[1+1:]
          pixels[i, j] =pixel
          count = count+1
    for i in range(width):
        for j in range(height):
          pixel = pixels[i, j]
          pixel = pixel[:2] + (255-pixel[2],) + pixel[2+1:]
          pixels[i, j] =pixel
          count = count+1

# version 3
if version ==3:
    for j in range(height):
        for i in range(width):
          pixel = pixels[i, j]
          pixels[i, j] = (255-pixel[0], 255-pixel[1], 255-pixel[2])
          count = count+3

# Version 4
if version ==4:
    for i in range(width):
        for j in range(height):
           pixel = pixels[i, j]
           pixel = pixel[:0] + (255-pixel[0],) + pixel[0+1:]
           pixels[i, j] =pixel
           count = count+1
    for i in range(width-1,-1,-1):
        for j in range(height-1,-1,-1):
           pixel = pixels[i, j]
           pixel = pixel[:1] + (255-pixel[1],)+ (255-pixel[2],) + pixel[2+1:]
           pixels[i, j] =pixel
           count = count+2

# Version 5
if version ==5:
    for i in range(0,width,2):
        for j in range(0,height,2):
           pixel = pixels[i, j]
           pixels[i, j] = (255-pixel[0], 255-pixel[1], 255-pixel[2])
           count = count+3
           if i<width-1 and j<height-1:
               pixel = pixels[i, j+1]
               pixels[i, j+1] = (255-pixel[0], 255-pixel[1], 255-pixel[2])

               pixel = pixels[i+1, j]
               pixels[i+1, j] = (255-pixel[0], 255-pixel[1], 255-pixel[2])

               pixel = pixels[i+1, j+1]
               pixels[i+1, j+1] = (255-pixel[0], 255-pixel[1], 255-pixel[2])
               count = count+9
           elif i<width-1 :
                pixel = pixels[i+1, j]
                pixels[i+1, j] = (255-pixel[0], 255-pixel[1], 255-pixel[2])
                count =count+3
           elif j<height-1:
                pixel = pixels[i, j+1]
                pixels[i, j+1] = (255-pixel[0], 255-pixel[1], 255-pixel[2])
                count =count+3

end = time.time_ns() 
print("Version: "+ str(version))
print("Tiempo: " + str(end-start))
print("Llamados: " + str(count))
print("N: " + str(width))
#img.save("img.bmp")
img.show()
