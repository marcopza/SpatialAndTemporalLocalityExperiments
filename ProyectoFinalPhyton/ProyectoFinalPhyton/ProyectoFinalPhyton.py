
  
# importing PIL 
from PIL import Image
import time
img = Image.open('img.bmp') 

width, height = img.size
pixels = img.load()
count = 0
version = ""
start = time.time_ns()

"""
# Version 1
for i in range(width):
    for j in range(height):
      pixel = pixels[i, j]
      pixels[i, j] = (255-pixel[0], 255-pixel[1], 255-pixel[2])
      count = count+3
version = "Version 1"
#""
# Version 2
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
version = "Version 2"
#""

# version 3
for j in range(height):
    for i in range(width):
      pixel = pixels[i, j]
      pixels[i, j] = (255-pixel[0], 255-pixel[1], 255-pixel[2])
      count = count+3
version = "Version 3"
"""
# Version 4
for i in range(width):
    for j in range(height):
       pixel = pixels[i, j]
       pixel = pixel[:0] + (255-pixel[0],) + pixel[0+1:]
       pixels[i, j] =pixel
       count = count+1
for i in range(width-1,0,-1):
    for j in range(height-1,0,-1):
       pixel = pixels[i, j]
       pixel = pixel[:1] + (255-pixel[1],)+ (255-pixel[2],) + pixel[2+1:]
       pixels[i, j] =pixel
       count = count+2
version = "Version 4"
"""
# Version 5
for i in range(0,width,2):
    for j in range(0,height,2):
       pixel = pixels[i, j]
       pixels[i, j] = (255-pixel[0], 255-pixel[1], 255-pixel[2])

       pixel = pixels[i, j+1]
       pixels[i, j+1] = (255-pixel[0], 255-pixel[1], 255-pixel[2])

       pixel = pixels[i+1, j]
       pixels[i+1, j] = (255-pixel[0], 255-pixel[1], 255-pixel[2])

       pixel = pixels[i+1, j+1]
       pixels[i+1, j+1] = (255-pixel[0], 255-pixel[1], 255-pixel[2])
       count = count+12
version = "Version 5"
"""
end = time.time_ns() 
print(version)
print("Tiempo: " + str(end-start))
print("Iteraciones: " + str(count))
#img.save("img.bmp")
img.show()

