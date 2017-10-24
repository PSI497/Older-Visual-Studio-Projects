Public Class Form1
    Dim felsoX As Integer
    Dim felsoY As Integer

    Dim alsoX As Integer
    Dim alsoY As Integer
    Dim namee As Integer = 0
    Dim bounds As Rectangle = Screen.PrimaryScreen.Bounds
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Long) As Integer
    Dim screenshot As System.Drawing.Bitmap
    Dim GFX As System.Drawing.Graphics
    Dim GFX2 As System.Drawing.Graphics

    Dim bmp12 As System.Drawing.Bitmap
    Dim bmp22 As System.Drawing.Bitmap

    Dim kulonbozo As Boolean
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick


        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)

        


        

        If My.Computer.Keyboard.CapsLock AndAlso My.Computer.Keyboard.AltKeyDown Then
            screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
            GFX = System.Drawing.Graphics.FromImage(screenshot)
            GFX.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)


            PictureBox1.Image = screenshot

            namee += 1


            Dim strBasePath As String
            Dim strFilePath As String
            Dim strFileName As String

            strFileName = "cs" & namee & ".jpg"
            strBasePath = Application.StartupPath & "\Photos"
            ' >> Check if Folder Exists 

            ' >> Save Picture 
            Call PictureBox1.Image.Save(strBasePath & "\" & strFileName, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If

        


       
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        
        Dim strBasePath As String
        Dim strFilePath As String
        Dim strFileName As String

        strFileName = "A.jpg"
        strBasePath = Application.StartupPath & "\Photos"
        ' >> Check if Folder Exists 
        
        ' >> Save Picture 
        Call PictureBox1.Image.Save(strBasePath & "\" & strFileName, System.Drawing.Imaging.ImageFormat.Jpeg)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        GFX = System.Drawing.Graphics.FromImage(screenshot)
        GFX.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)


        PictureBox1.Image = screenshot
    End Sub
End Class
