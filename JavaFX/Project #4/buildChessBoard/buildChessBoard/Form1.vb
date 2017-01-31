Public Class mainForm

    ' List containting each board elements as a dictionary
    Dim chessBoard As List(Of Dictionary(Of String, String))
    ' Boolean that tracks if there are changes unsaved in the application
    Dim unSavedChanges As Boolean

    Private Sub addBtn_Click(sender As Object, e As EventArgs) Handles addBtn.Click
        ' Check if each value entered is correct
        If Not (addColorCB.SelectedIndex > -1 And addPieceCB.SelectedIndex > -1 And addColCB.SelectedIndex > -1 And addRowCB.SelectedIndex > -1) Then
            ' Print message box letting the user know that some input data is missing
            MsgBox("You did not select all the required values to add a piece into the board!", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Missing values!")
            Exit Sub
        End If

        ' Get value selected from the color combo box
        Dim selectedColor As Object
        selectedColor = addColorCB.SelectedItem()
        ' Get value selected from the piece combo box
        Dim selectedPiece As Object
        selectedPiece = addPieceCB.SelectedItem()
        ' Get value selected from the row combo box
        Dim selectedRow As Object
        selectedRow = addRowCB.SelectedItem()
        ' Get value selected from the column combo box
        Dim selectedCol As Object
        selectedCol = addColCB.SelectedItem()


        ' Check if a chess piece is available to use
        Dim pieceAvailability As Boolean = checkPieceAvailability(selectedColor, selectedPiece)
        ' Check availability
        If pieceAvailability = False Then
            ' Print message box letting the user know that the piece selected cannot have more instances in the board
            MsgBox("You can not add more " + selectedColor + " " + selectedPiece, MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Too many pieces!")
            Exit Sub
        End If

        ' Check if there already a piece in the position of the board entered by the user
        Dim piecePosition As Boolean = checkPiecePosition(selectedRow, selectedCol)
        ' Check position
        If piecePosition = False Then
            ' Print message box letting the user know that the position entered is occupied by another piece
            MsgBox("You cannot put two pieces in the same position!", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Wrong spot!")
            Exit Sub
        End If

        ' If everything is ok, then edit buttons image
        'Get image bitmap from resources
        Dim imagePath As Bitmap = getPieceImage(selectedColor, selectedPiece)
        ' Get board button needed to enter piece required by user
        Dim boardBtn As Button = getButtonObject(selectedRow, selectedCol)
        ' Set piece image to the button required
        editTileImage(boardBtn, imagePath)
        ' Create dictionary to hold information about the piece entered to the board
        Dim dictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)
        ' Set piece color
        dictionary.Add("Color", selectedColor.ToString)
        ' Set piece type
        dictionary.Add("Piece", selectedPiece.ToString)
        ' Set piece row
        dictionary.Add("Row", selectedRow.ToString)
        ' Set piece column
        dictionary.Add("Col", selectedCol.ToString)
        ' Add piece to the board
        chessBoard.Add(dictionary)

        ' Clean all combo boxes from the 'Add Element' area
        addColorCB.SelectedIndex = -1
        addPieceCB.SelectedIndex = -1
        addColCB.SelectedIndex = -1
        addRowCB.SelectedIndex = -1

        ' Set changes to unsaved
        unSavedChanges = True

        ' Update the list box with the current elements in the board
        updateDeleteListBox()
    End Sub

    Private Sub deleteBtn_Click(sender As Object, e As EventArgs) Handles deleteBtn.Click
        ' Check if each value entered is correct
        If Not (delPieceLB.SelectedIndex > -1) Then
            ' Print message box letting the user know that some input data is missing
            MsgBox("You did not select a value to delete a piece from the board!", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Upss!")
            Exit Sub
        End If

        ' Split value of the selected item in the list box of elements to be deleted
        Dim selectedValueArray() As String = Split(delPieceLB.SelectedItem)

        ' Get value from the array of values
        Dim selectedColor As Object
        selectedColor = selectedValueArray(0)
        ' Get value from the array of values
        Dim selectedPiece As Object
        selectedPiece = selectedValueArray(1)
        ' Get value from the array of values
        Dim selectedRow As Object
        selectedRow = selectedValueArray(3)
        ' Get value from the array of values
        Dim selectedCol As Object
        selectedCol = selectedValueArray(2)

        'Check if the piece entered by the user exists in the board
        Dim pieceExistance As Boolean = checkPieceExistance(selectedRow, selectedCol)
        ' Check existance
        If pieceExistance = False Then
            ' Print message box letting the user not that the piece entered does not exist in the board and therefore cannot be deleted
            MsgBox("The piece entered does not exists in the current board design!", MsgBoxStyle.DefaultButton2 Or MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, "Upss!")
            Exit Sub
        End If

        ' If everything is ok, then edit buttons image
        ' Get board button needed to delete piece required by user
        Dim boardBtn As Button = getButtonObject(selectedRow, selectedCol)
        ' Set no image to the button required
        editTileImage(boardBtn, Nothing)
        ' Remove piece element from the list containing the board
        removeElement(selectedColor, selectedPiece, selectedRow, selectedCol)

        ' Set changes to unsaved
        unSavedChanges = True

        ' Update the list box with the current elements in the board
        updateDeleteListBox()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        ' Check if there are changes to the board not saved
        If unSavedChanges Then
            ' Ask user if he wants to exit without saving changes or not
            Select Case MsgBox("There are changes unsaved! Are you sure you want to proceed?", MsgBoxStyle.DefaultButton3 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNoCancel, "Unsaved Changes!")
                Case MsgBoxResult.Yes
                    ' Exit application
                    Application.Exit()
                    Exit Sub
                Case MsgBoxResult.Cancel
                    ' Do not exit application
                    Exit Sub
                Case MsgBoxResult.No
                    ' Do not exit application
                    Exit Sub
            End Select
        Else
            ' Exit application
            Application.Exit()
        End If
    End Sub

    Private Sub doneBtn_Click(sender As Object, e As EventArgs) Handles doneBtn.Click
        ' Create SaveFileDialog and set parameters
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Title = "Save The Chess Board"
        saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        ' Show save file dialog to the user and wait for response
        saveFileDialog1.ShowDialog()

        ' If the file name is not an empty string open it for saving.
        If saveFileDialog1.FileName <> "" Then
            ' Create encoding needed for the correct file format
            Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
            ' Open file to be written into
            Dim file As System.IO.StreamWriter = New System.IO.StreamWriter(saveFileDialog1.FileName, True, utf8WithoutBom)
            ' Write each piece of the board into the file
            For Each dic As Dictionary(Of String, String) In chessBoard
                Dim name As String = ""
                Dim position As String = ""
                ' Add first letter of the color to the name
                name = name & dic.Item("Color").Substring(0, 1)
                ' Check if the piece is a 'Knight'
                If String.Compare(dic.Item("Piece"), "Knight") = 0 Then
                    ' Add letter to the name for a Knight type of piece
                    name = name & "N"
                Else
                    ' Add first letter of the piece type to the name
                    name = name & dic.Item("Piece").Substring(0, 1)
                End If
                ' Create position string out of the column and row of the piece
                position = position & dic.Item("Col") + dic.Item("Row")
                ' Print name and position into the file
                file.WriteLine(name + " " + position)
            Next
            ' Close file
            file.Close()
            ' Reset board
            cleanBoard()
        End If
    End Sub

    ' Method that updates the list of current elements in the board
    Private Sub updateDeleteListBox()
        ' Clear all the elements in the list
        delPieceLB.Items.Clear()
        ' For each piece in the board create a new item in the list box
        For Each dic As Dictionary(Of String, String) In chessBoard
            delPieceLB.Items.Add(dic.Item("Color") & " " & dic.Item("Piece") & " " & dic.Item("Col") & " " & dic.Item("Row"))
        Next
    End Sub

    ' Method that removes all pieces of the board, resets combo boxes and deletes all data related to the previous board
    Private Sub cleanBoard()
        ' Remove piece images from buttons related to all current pieces of the board
        For Each dic As Dictionary(Of String, String) In chessBoard
            ' Get button from the board of buttons
            Dim boardBtn As Button = getButtonObject(dic.Item("Row"), dic.Item("Col"))
            ' Remove piece image from the button
            editTileImage(boardBtn, Nothing)
        Next

        ' Reset chess board into a new board
        chessBoard = New List(Of Dictionary(Of String, String))()
        ' Set changes to no changes unsaved
        unSavedChanges = False

        ' Clear all combo boxes in the application
        addColorCB.SelectedIndex = -1
        addPieceCB.SelectedIndex = -1
        addColCB.SelectedIndex = -1
        addRowCB.SelectedIndex = -1

        ' Clear the list box with the current elements in the board
        delPieceLB.Items.Clear()
    End Sub

    ' Method that sets a background image to a button
    Private Sub editTileImage(boardBtn As Button, image As Bitmap)
        ' Set background image
        boardBtn.BackgroundImage = image
        ' Set background image layout
        boardBtn.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    ' Method that checks if a position is occupied by a chess piece
    Private Function checkPiecePosition(row As String, col As String) As Boolean
        ' Check each piece currently in the board
        For Each dic As Dictionary(Of String, String) In chessBoard
            ' Check if the position is the same as the one entered by the user
            If ((String.Compare(dic.Item("Row"), row) = 0) And (String.Compare(dic.Item("Col"), col) = 0)) Then
                Return False
            End If
        Next
        Return True
    End Function

    ' Method that checks if a piece can be entered to the board depending on the amount 
    ' of times a piece type can be entered accordingly to the chess rules
    Private Function checkPieceAvailability(color As String, piece As String) As Boolean
        ' Set amount of times a piece a appears in the board to zero
        Dim count As Integer = 0
        ' Check all pieces in the board
        For Each dic As Dictionary(Of String, String) In chessBoard
            ' Check if the piece is the same as the one entered by the user
            If ((String.Compare(dic.Item("Color"), color) = 0) And (String.Compare(dic.Item("Piece"), piece) = 0)) Then
                ' Add one to the appearances count
                count = count + 1
            End If
        Next

        ' Check for a piece type if one more piece of the kind entered by the user can be entered to the board
        Select Case piece
            Case "Pawn"
                If count > 7 Then
                    Return False
                End If
            Case "Rook"
                If count > 1 Then
                    Return False
                End If
            Case "Knight"
                If count > 1 Then
                    Return False
                End If
            Case "Bishop"
                If count > 1 Then
                    Return False
                End If
            Case "Queen"
                If count > 0 Then
                    Return False
                End If
            Case "King"
                If count > 0 Then
                    Return False
                End If
        End Select
        Return True
    End Function

    ' Method that gets the corresponding image of a piece from the resources of the 
    ' application
    Private Function getPieceImage(color As String, piece As String) As Bitmap
        ' For a piece color and type, return the corresponding image from the resources
        Select Case color
            Case "White"
                Select Case piece
                    Case "Pawn"
                        Return My.Resources.WP
                    Case "Rook"
                        Return My.Resources.WR
                    Case "Knight"
                        Return My.Resources.WN
                    Case "Bishop"
                        Return My.Resources.WB
                    Case "Queen"
                        Return My.Resources.WQ
                    Case "King"
                        Return My.Resources.WK
                End Select
            Case "Black"
                Select Case piece
                    Case "Pawn"
                        Return My.Resources.BP
                    Case "Rook"
                        Return My.Resources.BR
                    Case "Knight"
                        Return My.Resources.BN
                    Case "Bishop"
                        Return My.Resources.BB
                    Case "Queen"
                        Return My.Resources.BQ
                    Case "King"
                        Return My.Resources.BK
                End Select
        End Select
        Return My.Resources._Error
    End Function

    ' Method that returns a button of the board of buttons accordingly to a position
    ' entered by the user
    Private Function getButtonObject(row As String, column As String) As Button
        ' For a position and row, return the corresponding button of the board of buttons
        Select Case column
            Case "A"
                Select Case row
                    Case "1"
                        Return A1btn
                    Case "2"
                        Return A2btn
                    Case "3"
                        Return A3btn
                    Case "4"
                        Return A4btn
                    Case "5"
                        Return A5btn
                    Case "6"
                        Return A6btn
                    Case "7"
                        Return A7btn
                    Case "8"
                        Return A8btn
                End Select
            Case "B"
                Select Case row
                    Case "1"
                        Return B1btn
                    Case "2"
                        Return B2btn
                    Case "3"
                        Return B3btn
                    Case "4"
                        Return B4btn
                    Case "5"
                        Return B5btn
                    Case "6"
                        Return B6btn
                    Case "7"
                        Return B7btn
                    Case "8"
                        Return B8btn
                End Select
            Case "C"
                Select Case row
                    Case "1"
                        Return C1btn
                    Case "2"
                        Return C2btn
                    Case "3"
                        Return C3btn
                    Case "4"
                        Return C4btn
                    Case "5"
                        Return C5btn
                    Case "6"
                        Return C6btn
                    Case "7"
                        Return C7btn
                    Case "8"
                        Return C8btn
                End Select
            Case "D"
                Select Case row
                    Case "1"
                        Return D1btn
                    Case "2"
                        Return D2btn
                    Case "3"
                        Return D3btn
                    Case "4"
                        Return D4btn
                    Case "5"
                        Return D5btn
                    Case "6"
                        Return D6btn
                    Case "7"
                        Return D7btn
                    Case "8"
                        Return D8btn
                End Select
            Case "E"
                Select Case row
                    Case "1"
                        Return E1btn
                    Case "2"
                        Return E2btn
                    Case "3"
                        Return E3btn
                    Case "4"
                        Return E4btn
                    Case "5"
                        Return E5btn
                    Case "6"
                        Return E6btn
                    Case "7"
                        Return E7btn
                    Case "8"
                        Return E8btn
                End Select
            Case "F"
                Select Case row
                    Case "1"
                        Return F1btn
                    Case "2"
                        Return F2btn
                    Case "3"
                        Return F3btn
                    Case "4"
                        Return F4btn
                    Case "5"
                        Return F5btn
                    Case "6"
                        Return F6btn
                    Case "7"
                        Return F7btn
                    Case "8"
                        Return F8btn
                End Select
            Case "G"
                Select Case row
                    Case "1"
                        Return G1btn
                    Case "2"
                        Return G2btn
                    Case "3"
                        Return G3btn
                    Case "4"
                        Return G4btn
                    Case "5"
                        Return G5btn
                    Case "6"
                        Return G6btn
                    Case "7"
                        Return G7btn
                    Case "8"
                        Return G8btn
                End Select
            Case "H"
                Select Case row
                    Case "1"
                        Return H1btn
                    Case "2"
                        Return H2btn
                    Case "3"
                        Return H3btn
                    Case "4"
                        Return H4btn
                    Case "5"
                        Return H5btn
                    Case "6"
                        Return H6btn
                    Case "7"
                        Return H7btn
                    Case "8"
                        Return H8btn
                End Select
        End Select
        Return New Button()
    End Function

    ' Method that removes a piece from the list of pieces in the board
    Private Sub removeElement(color As String, piece As String, row As String, col As String)
        ' Set dictionary to remove as nothing
        Dim elementToRemove As Dictionary(Of String, String) = Nothing
        ' Set found sentinel as false
        Dim found As Boolean = False
        ' Check all pieces of the chess board
        For Each dic As Dictionary(Of String, String) In chessBoard
            ' If the piece in the board is exactly equal to the one entered by the user
            If ((String.Compare(dic.Item("Color"), color) = 0) And (String.Compare(dic.Item("Piece"), piece) = 0) And (String.Compare(dic.Item("Row"), row) = 0) And (String.Compare(dic.Item("Col"), col) = 0)) Then
                ' Set element to be removed as this piece of the board
                elementToRemove = dic
                ' It was found
                found = True
                Exit For
            End If
        Next
        ' Check if a piece was found
        If found Then
            ' Remove piece from the list of pieces of the board
            chessBoard.Remove(elementToRemove)
        End If
    End Sub

    ' Method if a piece entered by the user is in the current chess board
    Private Function checkPieceExistance(row As String, col As String) As Boolean
        ' Check all the pieces in the board
        For Each dic As Dictionary(Of String, String) In chessBoard
            ' Check if the position is equal to the one entered by the user
            If ((String.Compare(dic.Item("Row"), row) = 0) And (String.Compare(dic.Item("Col"), col) = 0)) Then
                ' The position is occupied by another piece already in the board
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ' Check if there are changes to the board not saved
        If unSavedChanges Then
            ' Ask user if he wants to exit without saving changes or not
            Select Case MsgBox("There are changes unsaved! Are you sure you want to proceed?", MsgBoxStyle.DefaultButton3 Or MsgBoxStyle.Critical Or MsgBoxStyle.YesNoCancel, "Unsaved Changes!")
                Case MsgBoxResult.Yes
                    ' Exit application
                    Application.Exit()
                Case MsgBoxResult.Cancel
                    ' Do not exit application
                    e.Cancel = True
                Case MsgBoxResult.No
                    ' Do not exit application
                    e.Cancel = True
            End Select
        Else
            ' Exit application
            Application.Exit()
        End If
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ' Create new chess board
        chessBoard = New List(Of Dictionary(Of String, String))()
        ' No changes made up to this point
        unSavedChanges = False

        delPieceLB.SelectionMode = SelectionMode.One
    End Sub
End Class
