﻿'PossibleChar.vb
'
'Emgu CV 3.0.0

Option Explicit On      'require explicit declaration of variables, this is NOT Python !!
Option Strict On        'restrict implicit data type conversions to only widening conversions

Imports System.Math

Imports Emgu.CV                     '
Imports Emgu.CV.CvEnum              'Emgu Cv imports
Imports Emgu.CV.Structure           '
Imports Emgu.CV.UI                  '
Imports Emgu.CV.Util                '

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Public Class PossibleChar

    ' member variables ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public contour As VectorOfPoint

    Public boundingRect As Rectangle
    
    Public intCenterX As Integer
    Public intCenterY As Integer

    Public dblDiagonalSize As Double
    Public dblAspectRatio As Double
    Public intRectArea As Integer

    ' constructor '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Sub New(_contour As VectorOfPoint)
        contour = _contour

        boundingRect = CvInvoke.BoundingRectangle(contour)

        intCenterX = CInt((boundingRect.Left + boundingRect.Right) / 2)
        intCenterY = CInt((boundingRect.Top + boundingRect.Bottom) / 2)

        dblDiagonalSize = Math.Sqrt((boundingRect.Width ^ 2) + (boundingRect.Height ^ 2))

        dblAspectRatio = CDbl(boundingRect.Width) / CDbl(boundingRect.Height)
        
        intRectArea = boundingRect.Width * boundingRect.Height
    End Sub

End Class
