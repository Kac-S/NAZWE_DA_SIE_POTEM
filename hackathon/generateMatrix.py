# generate 2D array from B&W image
from PIL import Image
import numpy as np

#filename = "./img/1.png"  # path to image

def MergeMaps(map1, map2, map3):
    return map1+map2+map3


def getArray(filename, multiplier):
    image = Image.open(filename)  # open image

    image = image.convert('1')  # convert image to bw

    w, h = image.size

    data = np.asarray(image)  # convert image to nparray

    mArray = np.full([h,w], multiplier)

    return data*mArray
