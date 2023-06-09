// MathLibrary.cpp : Defines the exported functions for the DLL.
#include "pch.h" // use stdafx.h in Visual Studio 2017 and earlier
#include <utility>
#include <limits.h>
#include "QrDetector.h"
#include <opencv2/opencv.hpp>
#include <opencv2/objdetect.hpp>
#include <opencv2/imgproc.hpp>
#include <opencv2/highgui.hpp>
#include <zbar.h>

using namespace cv;
using namespace zbar;
using namespace std;


static int val;

void set_val(int v) {
    val = v;
    return;
}
int get_val() {
    return val;
}

__declspec(dllexport) void read_qr(char* imgpath, char*** stringArr, int *count)
{
    char** decode_list = (char**)malloc(sizeof(char*) * 10);

    Mat img;
    img = imread(imgpath);

    ImageScanner scanner;
    scanner.set_config(ZBAR_NONE, ZBAR_CFG_ENABLE, 1);

    Mat gray;
    cvtColor(img, gray, COLOR_BGR2GRAY);

    Image zbar_image(gray.cols, gray.rows, "Y800", gray.data, gray.cols * gray.rows);
    int n = scanner.scan(zbar_image);


    int ctr = 0;
    for (Image::SymbolIterator symbol = zbar_image.symbol_begin(); symbol != zbar_image.symbol_end() && ctr <= 9; ++symbol) {
        //strcpy_s(decode_list[ctr], 60, symbol->get_data().data());
        string str = symbol->get_data();
        //decode_list[ctr] = (char*)malloc(sizeof(char*) * (str.length() + 1));

        vector<Point> points;
        for (int i = 0; i < symbol->get_location_size(); ++i) {
            points.push_back(Point(symbol->get_location_x(i), symbol->get_location_y(i)));
        }
        RotatedRect r = minAreaRect(points);
        Point2f pts[4];
        r.points(pts);
        for (int i = 0; i < 4; ++i) {
            line(img, pts[i], pts[(i + 1) % 4], Scalar(0, 255, 0), 3);
        }

        decode_list[ctr] = new char[str.length() + 1];
        decode_list[ctr][str.length()] = '\0';
        for (int i = 0; i < str.length(); i++) {
            decode_list[ctr][i] = str[i];
        }
        ctr++;
    }
    decode_list[ctr] = NULL;

    imshow("Barcode Detector", img);
    waitKey(33);

    *stringArr = decode_list;
    *count = ctr;
}