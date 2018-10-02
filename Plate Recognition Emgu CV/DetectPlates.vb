'DetectPlates.vb
'
'Emgu CV 3.0.0

Option Explicit On      'require explicit declaration of variables, this is NOT Python !!
Option Strict On        'restrict implicit data type conversions to only widening conversions

Imports Emgu.CV                     '
Imports Emgu.CV.CvEnum              'Emgu Cv imports
Imports Emgu.CV.Structure           '
Imports Emgu.CV.UI                  '
Imports Emgu.CV.Util                '

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Module DetectPlates

    ' module level variables ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Const PLATE_WIDTH_PADDING_FACTOR As Double = 1.3
    Const PLATE_HEIGHT_PADDING_FACTOR As Double = 1.5

    Dim SCALAR_WHITE As New MCvScalar(255.0, 255.0, 255.0)
    Dim SCALAR_RED As New MCvScalar(0.0, 0.0, 255.0)

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function detectPlatesInScene(imgOriginalScene As Mat) As List(Of PossiblePlate)
        Dim listOfPossiblePlates As List(Of PossiblePlate) = New List(Of PossiblePlate)         'this will be the return value

        Dim imgGrayscaleScene As New Mat()
        Dim imgThreshScene As New Mat()
        Dim imgContours As New Mat(imgOriginalScene.Size, DepthType.Cv8U, 3)

        Dim random As New Random()

        CvInvoke.DestroyAllWindows()



        Preprocess.preprocess(imgOriginalScene, imgGrayscaleScene, imgThreshScene)          'preprocess to get grayscale and threshold images



        'find all possible chars in the scene,
        'this function first finds all contours, then only includes contours that could be chars (without comparison to other chars yet)
        Dim listOfPossibleCharsInScene As List(Of PossibleChar) = findPossibleCharsInScene(imgThreshScene)



        'given a list of all possible chars, find groups of matching chars
        'in the next steps each group of matching chars will attempt to be recognized as a plate
        Dim listOfListsOfMatchingCharsInScene As List(Of List(Of PossibleChar)) = findListOfListsOfMatchingChars(listOfPossibleCharsInScene)



        For Each listOfMatchingChars As List(Of PossibleChar) In listOfListsOfMatchingCharsInScene          'for each group of matching chars
            Dim possiblePlate = extractPlate(imgOriginalScene, listOfMatchingChars)                         'attempt to extract plate

            If (Not possiblePlate.imgPlate Is Nothing) Then                                                 'if plate was found
                listOfPossiblePlates.Add(possiblePlate)                                                     'add to list of possible plates
            End If
        Next

        frmMain.txtInfo.AppendText(vbCrLf + listOfPossiblePlates.Count.ToString + " possible plates found" + vbCrLf)    'update text box with # of plates found



        Return listOfPossiblePlates
    End Function
    
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function findPossibleCharsInScene(imgThresh As Mat) As List(Of PossibleChar)
        Dim listOfPossibleChars As List(Of PossibleChar) = New List(Of PossibleChar)      'this is the return value

        Dim imgContours As New Mat(imgThresh.Size(), DepthType.Cv8U, 3)
        Dim intCountOfPossibleChars As Integer = 0

        Dim imgThreshCopy As Mat = imgThresh.Clone()

        Dim contours As New VectorOfVectorOfPoint()

        CvInvoke.FindContours(imgThreshCopy, contours, Nothing, RetrType.List, ChainApproxMethod.ChainApproxSimple)     'find all contours

        For i As Integer = 0 To contours.Size() - 1                                                     'for each contour


            Dim possibleChar As New PossibleChar(contours(i))

            If (DetectChars.checkIfPossibleChar(possibleChar)) Then         'if contour is a possible char, note this does not compare to other chars (yet) . . .
                intCountOfPossibleChars = intCountOfPossibleChars + 1       'increment count of possible chars
                listOfPossibleChars.Add(possibleChar)                       'and add to list of possible chars
            End If
            
        Next



        Return listOfPossibleChars
    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Function extractPlate(imgOriginal As Mat, listOfMatchingChars As List(Of PossibleChar)) As PossiblePlate
        Dim possiblePlate As PossiblePlate = New PossiblePlate          'this will be the return value

                            'sort chars from left to right based on x position
        listOfMatchingChars.Sort(Function(firstChar, secondChar) firstChar.intCenterX.CompareTo(secondChar.intCenterX))
        
                            'calculate the center point of the plate
        Dim dblPlateCenterX As Double = CDbl(listOfMatchingChars(0).intCenterX + listOfMatchingChars(listOfMatchingChars.Count - 1).intCenterX) / 2.0
        Dim dblPlateCenterY As Double = CDbl(listOfMatchingChars(0).intCenterY + listOfMatchingChars(listOfMatchingChars.Count - 1).intCenterY) / 2.0
        Dim ptfPlateCenter As New PointF(CSng(dblPlateCenterX), CSng(dblPlateCenterY))

                            'calculate plate width and height
        Dim intPlateWidth As Integer = CInt(CDbl(listOfMatchingChars(listOfMatchingChars.Count - 1).boundingRect.X + listOfMatchingChars(listOfMatchingChars.Count - 1).boundingRect.Width - listOfMatchingChars(0).boundingRect.X) * PLATE_WIDTH_PADDING_FACTOR)

        Dim intTotalOfCharHeights As Integer = 0

        For Each matchingChar As PossibleChar In listOfMatchingChars
            intTotalOfCharHeights = intTotalOfCharHeights + matchingChar.boundingRect.Height
        Next

        Dim dblAverageCharHeight = CDbl(intTotalOfCharHeights) / CDbl(listOfMatchingChars.Count)

        Dim intPlateHeight = CInt(dblAverageCharHeight * PLATE_HEIGHT_PADDING_FACTOR)

                            'calculate correction angle of plate region
        Dim dblOpposite As Double = listOfMatchingChars(listOfMatchingChars.Count - 1).intCenterY - listOfMatchingChars(0).intCenterY
        Dim dblHypotenuse As Double = DetectChars.distanceBetweenChars(listOfMatchingChars(0), listOfMatchingChars(listOfMatchingChars.Count - 1))
        Dim dblCorrectionAngleInRad As Double = Math.Asin(dblOpposite / dblHypotenuse)
        Dim dblCorrectionAngleInDeg As Double = dblCorrectionAngleInRad * (180.0 / Math.PI)

                            'assign rotated rect member variable of possible plate
        possiblePlate.rrLocationOfPlateInScene = New RotatedRect(ptfPlateCenter, New SizeF(CSng(intPlateWidth), CSng(intPlateHeight)), CSng(dblCorrectionAngleInDeg))

        Dim rotationMatrix As New Mat()         'final steps are to perform the actual rotation
        Dim imgRotated As New Mat()
        Dim imgCropped As New Mat()
        
        CvInvoke.GetRotationMatrix2D(ptfPlateCenter, dblCorrectionAngleInDeg, 1.0, rotationMatrix)      'get the rotation matrix for our calculated correction angle

        CvInvoke.WarpAffine(imgOriginal, imgRotated, rotationMatrix, imgOriginal.Size)          'rotate the entire image
        
                            'crop out the actual plate portion of the rotated image
        CvInvoke.GetRectSubPix(imgRotated, possiblePlate.rrLocationOfPlateInScene.MinAreaRect.Size, possiblePlate.rrLocationOfPlateInScene.Center, imgCropped)
        
        possiblePlate.imgPlate = imgCropped         'copy the cropped plate image into the applicable member variable of the possible plate
        
        Return possiblePlate
    End Function

End Module
