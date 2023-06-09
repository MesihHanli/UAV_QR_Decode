// MathLibrary.h - Contains declarations of math functions
#pragma once

#ifdef QRDETECTOR_EXPORTS
#define QRDETECTOR_API __declspec(dllexport)
#else
#define QRDETECTOR_API __declspec(dllimport)
#endif

// Produce the next value in the sequence.
// Returns true on success and updates current value and index;
// false on overflow, leaves current value and index unchanged.
extern "C" QRDETECTOR_API __declspec(dllexport) void read_qr(char*, char***, int*);

extern "C" QRDETECTOR_API void set_val(int);

extern "C" QRDETECTOR_API int get_val();