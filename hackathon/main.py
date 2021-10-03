from kivy.app import App
from kivy.graphics import Rectangle
from kivy.graphics import Color
from kivy.uix.widget import Widget
from kivy.config import Config

import generateMatrix as gM
from generatePlants import generatePlant

# set width and height of app window
width = 800
height = 800
Config.set('graphics', 'width', width)
Config.set('graphics', 'height', height)


def drawMap(self, array):
    w = len(array[0])
    h = len(array)

    with self.canvas:
        for i in range(0, h):
            for j in range(0, w):
                # for one point in every array
                if array[i, j] == 1:  # draw rect if pt is water
                    Color(0, 0, 1, 0.5, mode="rgba")
                    self.rect = Rectangle(pos=((height / h) * j, abs((width / w) * i - (width - width / w))),
                                          size=(height / h, width / w))

                if array[i, j] == 2:  # draw rect if pt is f00d
                    Color(0, 1, 0, 0.5, mode="rgba")
                    self.rect = Rectangle(pos=((height / h) * j, abs((width / w) * i - (width - width / w))),
                                          size=(height / h, width / w))

                if array[i, j] == 3:  # draw rect if pt is obstacle
                    Color(1, 0, 0, 0.5, mode="rgba")
                    self.rect = Rectangle(pos=((height / h) * j, abs((width / w) * i - (width - width / w))),
                                          size=(height / h, width / w))

class Touch(Widget):
    def __init__(self, **kwargs):
        super(Touch, self).__init__(**kwargs)
        # get all location arrays
        array_water = gM.getArray('./img/map_water.png', 1)
        array_food = gM.getArray('./img/map_food.png', 2)
        array_obstacle = gM.getArray('./img/map_obstacle.png', 3)

        array = gM.MergeMaps(array_food, array_water, array_obstacle)

        generatePlant(1372, array)

        drawMap(self, array)

class MainApp(App):
    def build(self):
        return Touch()

if __name__ == '__main__':
    app = MainApp()
    app.run()